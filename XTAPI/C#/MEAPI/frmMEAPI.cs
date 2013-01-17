using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using TTMarketExplorer;

namespace MEAPI_Samples
{
    /// <summary>
    /// MEAPI
    /// 
    /// This example demonstrates using the MEAPI to receive available exchanges, 
    /// products, and contract definitions.
    /// </summary>
    public partial class frmMEAPI : Form,
                                    ITTMarketExplorerEvents,
                                    ITTGatewayEvents,
                                    ITTProductEvents
    {
        TTMarketExplorerClass m_marketExplorer = null;

        // Create a hashtable of the MEAPI gateway and product class obejcts 
        // (will be used for gateway and product event handlers)
        private static Hashtable m_gatewayCollection = null;
        private static Hashtable m_productCollection = null;

        // Create a gateway object, this will be set when the user selects a gateway
        private static ITTGateway m_selectedGateway = null;

        // Flag for if the gateway is available when the user selects the prod type
        private static bool m_gatewayAvailable = false;

        // Product Collection used for unregistering the callbacks
        private static ITTProductCollection m_currentRegisteredProducts = null;

        // Contract Collection used for Drag and Drop functionality
        private static Hashtable m_currentContractsFound = null;
        private static string m_parentNodeForDragDrop = null;

        // counters
        private int m_exchangeCount = 0;
        private int m_productCount = 0;

        /// <summary>
        /// Upon the application form loading, the TTMarketExplorer is instantiated.
        /// </summary>
        public frmMEAPI()
        {
            InitializeComponent();
            
            // Instantiate MEAPI object
            m_marketExplorer = new TTMarketExplorer.TTMarketExplorerClass();
            m_gatewayCollection = new Hashtable();
        }

        #region _ITTMarketExplorerEvents Members

        /// <summary>
        /// TT Gateways are found in response to a RequestGateways method call or when
        /// TT Gateways become available.
        /// </summary>
        /// <param name="Gateway">The TT Gateway object found by the MEAPI</param>
        public void OnGateway(ITTGateway Gateway)
        {
            // add the gateway to the collection so we can create our event handlers
            if (!m_gatewayCollection.ContainsKey(Gateway.Name.ToString()))
                m_gatewayCollection.Add(Gateway.Name.ToString(), Gateway);

            // push the gateway name to our mainform class
            PublishGatewayName(Gateway.Name.ToString());
        }

        #endregion

        #region _ITTGatewayEvents Members

        /// <summary>
        /// MEAPI recieves the gateway attribute list (GAL settings) for the TT Gateway.
        /// </summary>
        /// <param name="Gateway">TT Gateway whose GAL settings changed</param>
        /// <param name="attributeList">Comma-separated list of GAL name-value pairs</param>
        /// <param name="service">Service that started or restarted</param>
        public void OnGatewayAttributes(ITTGateway Gateway, string attributeList, enumServiceType service)
        {
            // request the products and product types for our selected gateway
            if (Gateway.Name.ToString() == m_selectedGateway.Name.ToString())
            {
                Gateway.RequestProductTypes();
                Gateway.RequestProducts(0);
            }
        }

        /// <summary>
        /// TT Gateways add new contracts for a product
        /// </summary>
        /// <param name="Gateway">TT Gateway on which the product was added</param>
        /// <param name="Product">Product associated with the new contract</param>
        /// <param name="contractInfo">New Contract</param>
        public void OnNewContract(ITTGateway Gateway, ITTProduct Product, ITTContractInfo contractInfo)
        {
            lboInfo.Items.Add("New Contract Found: " + Product.Name.ToString() + " " + contractInfo.Name.ToString());
        }

        /// <summary>
        /// TT Gateway recieves new products from an exchange.
        /// </summary>
        /// <param name="Gateway"></param>
        /// <param name="Product"></param>
        public void OnNewProduct(ITTGateway Gateway, ITTProduct Product)
        {
            lboInfo.Items.Add("New Product Found: " + Product.Name.ToString());
        }

        /// <summary>
        /// TT Gateways find products that match a product request
        /// </summary>
        /// <param name="Gateway">TT Gateway containing the products</param>
        /// <param name="Products">Collection of products returned by the TT Gateway</param>
        public void OnProductsFound(ITTGateway Gateway, ITTProductCollection Products)
        {
            // set our global values containing our products
            m_currentRegisteredProducts = Products;
        }

        /// <summary>
        /// TT Gateways find no products matching a product request or query.
        /// </summary>
        /// <param name="Gateway">TT Gateway from which you requested products</param>
        public void OnProductsNotFound(ITTGateway Gateway)
        {
            lboInfo.Items.Add("No products found for " + Gateway.Name.ToString());
        }

        /// <summary>
        /// TT Gateways return a list of product types hosted on the TT Gateway
        /// </summary>
        /// <param name="Gateway">TT Gateway containing the product types</param>
        /// <param name="productTypes">Array of product type IDs</param>
        /// <param name="productTypesAsString">Array of product type names</param>
        public void OnProductTypes(ITTGateway Gateway, object productTypes, object productTypesAsString)
        {
            // push the product types to our GUI
            PublishProductTypes(productTypesAsString as string[], productTypes as int[]);
        }

        /// <summary>
        /// Status of a TT Gateway server change
        /// </summary>
        /// <param name="Gateway">Gateway affected by the server status change</param>
        /// <param name="service">Service whose status changed.</param>
        /// <param name="IsAvailable">Current status of the service</param>
        /// <param name="IsLoggedIn">Current logged in status</param>
        public void OnServerStatus(ITTGateway Gateway, enumServiceType service, int IsAvailable, int IsLoggedIn)
        {
            // before requesting products make sure we have a connection to the price server
            if ((service == enumServiceType.PRICE_SERVICE) && (IsAvailable == 1) && (IsLoggedIn == 1))
            {
                // we're connected, let's make sure it's available
                while ((Gateway.get_IsAvailable(enumServiceType.PRICE_SERVICE) != 1) || (Gateway.get_IsLoggedIn(enumServiceType.PRICE_SERVICE) != 1))
                {
                    System.Threading.Thread.Sleep(25);
                }

                // set the flag that the gateway is available
                m_gatewayAvailable = true;
            }

            tsStatus.Text = Gateway.Name.ToString() + ": Connecting to Price Server...";
        }

        /// <summary>
        /// TT Gateways return a list of products hosted on the TT Gateway
        /// </summary>
        /// <param name="Gateway">TT Gateway whose products are requested</param>
        /// <param name="Products">Prodcut collection from the gateway</param>
        public void OnProducts(ITTGateway Gateway, ITTProductCollection Products)
        {
            // set our global values containing our products
            m_currentRegisteredProducts = Products;
        }

        /// <summary>
        /// TT Gateways timeout on a product request
        /// </summary>
        /// <param name="Gateway">TT Gateway which timed out</param>
        public void OnRequestProductsTimeout(ITTGateway Gateway)
        {
            lboInfo.Items.Add("Product Request Timeout for: " + Gateway.Name.ToString());
        }

        #endregion

        #region _ITTProductEvents Members

        /// <summary>
        /// TT Gateways deliver a list of contracts associated with the product
        /// </summary>
        /// <param name="Gateway">TT Gateway on which the product contracts trade</param>
        /// <param name="Product">Product associated with the contracts</param>
        /// <param name="contracts">Collection of the contracts available for the product</param>
        public void OnContracts(ITTGateway Gateway, ITTProduct Product, ITTContractCollection contracts)
        {
            TreeNode parentNode = null;
            TreeNode[] childNodes = new TreeNode[contracts.Count];
            int counter = 0;

            // store our contracts in a hashtable so they can be accessed for drag and drop
            if (!m_currentContractsFound.ContainsKey(Product.Name.ToString()))
                m_currentContractsFound.Add(Product.Name.ToString(), contracts);

            foreach (ITTContractInfo contract in contracts)
            {
                TreeNode tmpChildNode = new TreeNode();
                tmpChildNode.Text = contract.Name;

                childNodes[counter] = tmpChildNode;
                counter++;

                // GC should get it out of scope, but force release our resources
                tmpChildNode = null;
            }

            // push the parent node to the GUI to update
            parentNode = new TreeNode(Product.Name.ToString(), childNodes);
            PublishProducts(parentNode);

            // GC should get it out of scope, but force release our resources
            childNodes = null;
            parentNode = null;
        }

        /// <summary>
        /// Contract download times out
        /// </summary>
        /// <param name="Gateway">TT Gateway on which the contracts product trades</param>
        /// <param name="Product">Product associated with the contract</param>
        public void OnRequestContractsTimeout(ITTGateway Gateway, ITTProduct Product)
        {
            lboInfo.Items.Add("Timeout occured when requesting contracts for " + Gateway.Name.ToString() + " " + Product.Name.ToString());
        }

        #endregion

        #region Delegate Member Functions

        /// <summary>
        /// Add the gateway to the GUI
        /// </summary>
        /// <param name="gatewayName">Gateway name</param>
        public void PublishGatewayName(string gatewayName)
        {
            lboGateways.Items.Add(gatewayName);

            m_exchangeCount++;
            tsStatus.Text = "Exchanges found: " + m_exchangeCount.ToString();
        }

        /// <summary>
        /// Add the product types to the GUI
        /// </summary>
        /// <param name="prodTypes">Array of product types</param>
        /// <param name="prodIndices">Array of the product indices (current not used)</param>
        public void PublishProductTypes(string[] prodTypes, int[] prodIndices)
        {
            // clear and repopulate the list
            lboProductTypes.Items.Clear();

            for (int i = 0; i < prodTypes.Length; i++)
                lboProductTypes.Items.Add(prodTypes[i]);

            tsStatus.Text = "Product Types Found for " + lboGateways.SelectedItem.ToString() + ": " + prodTypes.Length.ToString();
        }

        /// <summary>
        /// Add the products to the GUI
        /// </summary>
        /// <param name="prodNode">Product TreeNode</param>
        public void PublishProducts(TreeNode prodNode)
        {
            lboProductList.Nodes.Add(prodNode);

            tsStatus.Text = "Contracts found for " + lboGateways.SelectedItem.ToString() + " " + lboProductTypes.SelectedItem.ToString() + ": (" + m_currentContractsFound.Count.ToString() + " of " + m_productCount.ToString() + ")";
        }

        #endregion 

        #region Private Member Functions

        /// <summary>
        /// Unregister all the event handlers belonging to the products 
        /// </summary>
        private void ReleaseProductEventHandlers()
        {
            tsStatus.Text = "Releasing event handlers...";
            Application.DoEvents();

            if (m_currentRegisteredProducts != null)
            {
                // unregister for the notifications from previously selected product types
                foreach (ITTProduct product in m_currentRegisteredProducts)
                    product.UnregisterEventHandler(this);
            }
        }

        #endregion

        #region GUI Event Handlers

        /// <summary>
        /// Request gateways
        /// </summary>
        private void btnReqestGateways_Click(object sender, EventArgs e)
        {
            // request our list of gateways
            if (m_marketExplorer.RegisterEventHandler(this) == enumRegisterReturnCode.RR_SUCCESS)
            {
                m_exchangeCount = 0;
                tsStatus.Text = "Requesting Gateways...";
                m_marketExplorer.RequestGateways();

                // request successful - disable re-request
                btnReqestGateways.Enabled = false;
            }
            else
            {
                tsStatus.Text = "Error requesting gateways.";
            }
        }

        /// <summary>
        /// Gateway has been selected
        /// </summary>
        private void lbGateways_SelectedIndexChanged(object sender, EventArgs e)
        {
            // release the product event handler if one exists
            ReleaseProductEventHandlers();

            // clear the current prodtype listbox and product treeview
            lboProductList.Nodes.Clear();
            lboProductTypes.Items.Clear();
            Application.DoEvents();

            ListBox lbTemp = (ListBox)sender;
            m_productCollection = new Hashtable();
            m_currentContractsFound = new Hashtable();

            // release the previous gateway event handler
            if (m_selectedGateway != null)
                m_selectedGateway.UnregisterEventHandler(this);

            // get our gateway object so we can create our event handler
            m_selectedGateway = (ITTGateway)m_gatewayCollection[lbTemp.SelectedItem.ToString()];

            if (m_selectedGateway.RegisterEventHandler(this) != enumRegisterReturnCode.RR_SUCCESS)
                lboInfo.Items.Add("ERROR: Gateway handler did not register properly.");
        }

        /// <summary>
        /// Product has been selected
        /// </summary>
        private void lbProductTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            tsStatus.Text = "Requesting products...";

            // release all previous product event handlers
            ReleaseProductEventHandlers();

            // clear the current treeview
            lboProductList.Nodes.Clear();
            m_currentContractsFound.Clear();
            Application.DoEvents();

            m_productCount = 0;

            // check to see if we have a connection to the gateway
            if (!m_gatewayAvailable)
            {
                MessageBox.Show("Gateway is not yet connected to the Price Server.  " +
                                "Please try again, or if this problem persists make sure " +
                                "you have a valid connection to the price server.",
                                "Gateway Connection Not Established.",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                // deselect the listbox and exit the function
                lboProductTypes.SetSelected(lboProductTypes.SelectedIndex, false);
                return;
            }

            if (m_currentRegisteredProducts == null)
            {
                tsStatus.Text = "Products not fully downloaded or no products found for " + lboGateways.SelectedItem.ToString();
                return;
            }

            foreach (ITTProduct product in m_currentRegisteredProducts)
            {
                // register the event handlers for each product where the prod type matches
                // what is selected on the form.
                if (product.TypeAsString == lboProductTypes.SelectedItem.ToString())
                {
                    if (product.RegisterEventHandler(this) == enumRegisterReturnCode.RR_SUCCESS)
                    {
                        if (product.RequestContracts() != enumQueryReturnCode.QR_SUCCESS)
                            lboInfo.Items.Add("ERROR: RequestContracts failed for " + product.Name.ToString());
                        else
                            m_productCount++;
                    }
                    else
                    {
                        lboInfo.Items.Add("ERROR: Product handler did not register properly for " + product.Name.ToString());
                    }
                }
            }

            if (m_productCount == 0)
                tsStatus.Text = "No products found for " + lboGateways.SelectedItem.ToString() + " " + lboProductTypes.SelectedItem.ToString();

        }

        /// <summary>
        /// Contract has begun it's drag event
        /// </summary>
        private void tvProductList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            try
            {
                ITTContractCollection tmpContractCollection = (ITTContractCollection)m_currentContractsFound[m_parentNodeForDragDrop];

                foreach (ITTContractInfo contract in tmpContractCollection)
                {
                    if (contract.Name.ToString() == Convert.ToString(e.Item).Substring(10))
                    {
                        int rc = contract.CopyToClipboard((uint)this.Handle);

                        lboProductList.DoDragDrop((Object)Clipboard.GetDataObject(), DragDropEffects.Link);
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// Save the parent when the child has been clicked - used to find the correct contract to drag
        /// </summary>
        private void tvProductList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode tmpNode = e.Node.Parent;

            // parent node (product) - do nothing
            if (tmpNode == null)
            {
                m_parentNodeForDragDrop = "";
            }
            // child node (contract) assign name of parent
            else
            {
                m_parentNodeForDragDrop = tmpNode.Text;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About frmDTS = new About();
            frmDTS.ShowDialog();
        }

        private void mainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            tsStatus.Text = "Terminating MEAPI...";
            Application.DoEvents();

            // clean up MEAPI resources
            m_marketExplorer.MEAPITerminate();
        }

        #endregion
    }
}
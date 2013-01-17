/***************************************************************************
 *    
 *      Copyright (c) 2005 Trading Technologies International, Inc.
 *                     All Rights Reserved Worldwide
 *
 *        * * *   S T R I C T L Y   P R O P R I E T A R Y   * * *
 *
 * WARNING:  This file is the confidential property of Trading Technologies
 * International, Inc. and is to be maintained in strict confidence.  For
 * use only by those with the express written permission and license from
 * Trading Technologies International, Inc.  Unauthorized reproduction,
 * distribution, use or disclosure of this file or any program (or document)
 * derived from it is prohibited by State and Federal law, and by local law
 * outside of the U.S. 
 *
 * ***************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XTAPI_Samples
{
    /// <summary>
    /// ManualFill
    /// 
    /// This example demonstrates how to create manual fills using the XTAPI.  This 
    /// sample requires you have administrative risk privileges.
    /// </summary>
    public partial class frmManualFill : Form
    {
        // Declare the XTAPI objects.
        private XTAPI.TTDropHandler m_TTDropHandler = null;
        private XTAPI.TTInstrObj m_TTInstrObj = null;
        private XTAPI.TTInstrNotify m_TTInstrNotify = null;
        private XTAPI.TTManualFill manualFill = null;
        private XTAPI.TTRiskManager m_RiskManager = null;
        private XTAPI.TTGate m_TTGate = null;

        // private member variables
        private bool m_isFillServerUp = false;
        private bool m_isXTPro = false;
        private bool m_isXTConnected = false;
        private bool m_isDataLoaded = false;
        private List<XTAPI.TTManualFill> m_manualFillList = null;

        /// <summary>
        /// Upon the application form loading, the TTGate, TTDropHandler, TTInstrNotify, and
        /// TTRiskManager are initialized and events are subscribed to.
        /// </summary>
        public frmManualFill()
        {
            // Required for Windows Form Designer support
            InitializeComponent();

            // Indicates when the connection is established
            m_TTGate = new XTAPI.TTGate();

            //Subscribe to the OnExchangeStateupdate and OnStatusUpdate events
            m_TTGate.OnExchangeStateUpdate += new XTAPI._ITTGateEvents_OnExchangeStateUpdateEventHandler(m_TTGate_OnExchangeStateUpdate);
            m_TTGate.OnStatusUpdate += new XTAPI._ITTGateEvents_OnStatusUpdateEventHandler(m_TTGate_OnStatusUpdate);

            // Instantiate the drag and drop handler class.					 
            m_TTDropHandler = new XTAPI.TTDropHandler();

            // Register the active form for drag and drop.
            m_TTDropHandler.RegisterDropWindow((int)this.Handle);

            // Associate the drop and drag callback event.
            m_TTDropHandler.OnNotifyDrop += new XTAPI._ITTDropHandlerEvents_OnNotifyDropEventHandler(m_TTDropHandler_OnNotifyDrop);

            // Instantiate the instrumebtnt notification class.
            m_TTInstrNotify = new XTAPI.TTInstrNotify();

            // Setup the instrument notification call back functions.
            m_TTInstrNotify.OnNotifyFound += new XTAPI._ITTInstrNotifyEvents_OnNotifyFoundEventHandler(m_TTInstrNotify_OnNotifyFound);

            //Instantiate the TTRiskManagerClass
            m_RiskManager = new XTAPI.TTRiskManager();

            //Subscribe to the TTRiskManager Events
            m_RiskManager.OnLoginFailed += new XTAPI._ITTRiskManagerEvents_OnLoginFailedEventHandler(m_RiskManager_OnLoginFailed);
            m_RiskManager.OnDataLoaded += new XTAPI._ITTRiskManagerEvents_OnDataLoadedEventHandler(m_RiskManager_OnDataLoaded);

            // Initialize our internal list
            m_manualFillList = new List<XTAPI.TTManualFill>();
        }

        #region TTGate Events

        /// <summary>
        /// This event is triggered when the state of a TT Gateway changes.
        /// </summary>
        /// <param name="sExchange">Name of the exchange sending the message.</param>
        /// <param name="sText">Type of server.</param>
        /// <param name="bOpened">Whether the application is connected to the gateway.</param>
        /// <param name="bServerUp">Whether the server specified in srvType is active.</param>
        private void m_TTGate_OnExchangeStateUpdate(string sExchange, string sText, int bOpened, int bServerUp)
        {
            // Report to the GUI the connection to the fill server is active
            if (sExchange == txtRiskAdminExchange.Text && sText == "Fill" && bOpened == 1 & bServerUp == 1)
            {
                m_isFillServerUp = true;

                lblFillConnection.Text = "UP";
                lblFillConnection.BackColor = Color.Green;
            }

            // Try to enable the SOD Services
            TryEnableSODServices();
        }

        /// <summary>
        /// This event is triggered when the connection with X_TRADER changes.
        /// </summary>
        /// <param name="lHintMask">Current status of X_TRADER</param>
        /// <param name="sText">Description of the status change</param>
        private void m_TTGate_OnStatusUpdate(int lHintMask, string sText)
        {
            if (lHintMask == 1) // X_TRADER is connected
            {
                m_isXTConnected = true;

                lblXTrader.Text = "Connected";
                lblXTrader.BackColor = Color.Green;
            }
            else if (lHintMask == 32) // X_TRADER Pro is enabled
            {
                m_isXTPro = true;

                lblXTPro.Text = "Connected";
                lblXTPro.BackColor = Color.Green;
            }

            // Attempt to establish a connection to the fill server and enable SOD services on the form
            TryOpenFillConnection();
            TryEnableSODServices();
        }

        #endregion

        #region TTDropHandler Events

        /// <summary>
        /// This function is called when an instrument is dragged and dropped from the 
        /// Market Grid in X_TRADER.
        /// </summary>
        private void m_TTDropHandler_OnNotifyDrop()
        {
            // Update the Status Bar text.
            sbaStatus.Text = "Drag & Drop detected.  Initializing instrument...";

            try
            {
                if (m_TTInstrObj != null)
                {
                    // Detach previously attached instrument.
                    m_TTInstrNotify.DetachInstrument(m_TTInstrObj);
                    m_TTInstrObj = null;
                }

                // Obtain the TTInstrObj from the TTDropHandler object.
                m_TTInstrObj = (XTAPI.TTInstrObj)m_TTDropHandler[1];

                // Attach the TTInstrObj to the TTInstrNotify for price update events.
                m_TTInstrNotify.AttachInstrument(m_TTInstrObj);

                // Open the TTInstrObj.
                m_TTInstrObj.Open(0);	// enable Market Depth:  1 - true, 0 - false

                // Clear drop handler list.
                m_TTDropHandler.Reset();
            }
            catch (Exception ex)
            {
                // Display exception message.
                MessageBox.Show(ex.Message, "Exception");
            }
        }

        #endregion

        #region TTInstrNotify Events

        /// <summary>
        /// This function is called when an instrument is located after calling m_TTInstrObj.Open()
        /// </summary>
        /// <param name="pNotify">TTInstrNotify object</param>
        /// <param name="pInstr">TTInstrObj object</param>
        private void m_TTInstrNotify_OnNotifyFound(XTAPI.TTInstrNotify pNotify, XTAPI.TTInstrObj pInstr)
        {
            // Update the Status Bar text.
            sbaStatus.Text = "Instrument Found.";

            // Retrieve the instrument information using the TTInstrObj Get Properties.
            Array data = (Array)pInstr.get_Get("Exchange,Product,ProdType,Contract");

            txtMFoundExchange.Text = (string)data.GetValue(0);
            txtMFoundProduct.Text = (string)data.GetValue(1);
            txtMFoundProdType.Text = (string)data.GetValue(2);
            txtMFoundContract.Text = (string)data.GetValue(3);

            // Enable the other parts of the "Publish" section for publishing SODs
            txtPublishPrice.Enabled = true;
            txtPublishQty.Enabled = true;
            cboMPublishPriceFormat.Enabled = true;
            btnCreateManualFill.Enabled = true;
            optBuy.Enabled = true;
            optSell.Enabled = true;
        }

        #endregion

        #region TTRiskManager Events

        /// <summary>
        /// Guardian rejected the administrator login credentials supplied in the SetAdminLogon method.
        /// </summary>
        /// <param name="sAdminExchange">Exchange Gateway name</param>
        /// <param name="sAdminMember">Administrator member ID</param>
        /// <param name="sAdminGroup">Administrator group ID</param>
        /// <param name="sAdminTrader">Administrator trader ID</param>
        /// <param name="sMsg">Reason for the rejection</param>
        private void m_RiskManager_OnLoginFailed(string sAdminExchange, string sAdminMember, string sAdminGroup, string sAdminTrader, string sMsg)
        {
            string message = "Admin Login failed on exchange: " + sAdminExchange +
                             ", MemberID: " + sAdminMember +
                             ", GroupID: " + sAdminGroup +
                             ", Trader: " + sAdminTrader +
                             ", Error Message: " + sMsg;

            MessageBox.Show(message, "Login ERROR");
            btnLoginRiskAdmin.Enabled = true;
        }

        /// <summary>
        /// Triggered when the application successfully logs into Guardian and retrieves the traders'
        /// risk limits.  This occurs after calling the SetAdminLogin or Reset methods.
        /// </summary>
        private void m_RiskManager_OnDataLoaded()
        {
            // SOD Data has been loaded
            m_isDataLoaded = true;
            lblOnDataLoaded.Text = "Loaded";
            lblOnDataLoaded.BackColor = Color.Green;

            // Reset output and attempt to establish a connection
            ResetOutput();
            TryOpenFillConnection();
            TryEnableSODServices();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Clears the output and starts anew
        /// </summary>
        private void ResetOutput()
        {
            txtManualFillRecords.Clear();
            txtManualFillRecords.Text += "TraderID, Exchange, Product, Product Type, Contract, Price, Quantity, Buy/Sell \r\n\r\n";
        }

        /// <summary>
        /// Loads the current SOD records and publishes to the output TextBox
        /// </summary>
        private void LoadManualFillData()
        {
            ResetOutput();

            if (m_manualFillList.Count == 0)
            {
                txtManualFillRecords.Text += "THERE ARE NO NEW MANUAL FILLS THAT HAVE BEEN PUBLISHED SINCE THIS APPLICATION WAS LOADED";
                return;
            }

            try
            {
                string properties = "Member,Group,Trader,Instr.Exchange,Instr.Product,Instr.ProdType,Instr.Contract,Price$,Qty,BuySell$";
                foreach (XTAPI.TTManualFill manualFill in m_manualFillList)
                {
                    Array returnData = (Array)manualFill.get_Get(properties);

                    this.txtManualFillRecords.Text += (string)returnData.GetValue(0) + "|" +
                                                      (string)returnData.GetValue(1) + "|" +
                                                      (string)returnData.GetValue(2) + ", " +
                                                      (string)returnData.GetValue(3) + ", " +
                                                      (string)returnData.GetValue(4) + ", " +
                                                      (string)returnData.GetValue(5) + ", " +
                                                      (string)returnData.GetValue(6) + ", " +
                                                      (string)returnData.GetValue(7) + ", " +
                                                      Convert.ToString(returnData.GetValue(8)) + ", " +
                                                      (string)returnData.GetValue(9) + "\r\n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
                return;
            }
        }

        /// <summary>
        /// Open connection to the fill server if all flags are set.
        /// </summary>
        private void TryOpenFillConnection()
        {
            // Check if X_TRADER Pro is running and OnDataLoaded has occured
            if (!m_isFillServerUp && m_isXTPro && m_isXTConnected && m_isDataLoaded)
            {
                // Establish a connection to the fill server
                m_TTGate.OpenExchangeFills(this.txtRiskAdminExchange.Text);
            }
        }

        /// <summary>
        /// Enable Manual Fill services on the form if all flags are set.
        /// </summary>
        private void TryEnableSODServices()
        {
            // Check if everything is available to enable the SOD Services
            if (m_isFillServerUp && m_isXTPro && m_isXTConnected && m_isDataLoaded)
            {
                gboManualFillServices.Enabled = true;
                txtMemberManualFill.Enabled = true;
                txtGroupManualFill.Enabled = true;
                txtTraderManualFill.Enabled = true;
                txtAcctManualFill.Enabled = true;
            }
        }

        #endregion

        /// <summary>
        /// Called when the user attempts risk administrator authentication
        /// </summary>
        private void btnLoginRiskAdmin_Click(object sender, EventArgs e)
        {
            // Disable login button 
            btnLoginRiskAdmin.Enabled = false;

            try
            {
                // Send admin login through the risk manager
                m_RiskManager.SetAdminLogon(txtRiskAdminExchange.Text,
                                            txtRiskAdminMember.Text,
                                            txtRiskAdminGroup.Text,
                                            txtRiskAdminTrader.Text,
                                            txtRiskAdminPassword.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login Failed: " + ex.Message, "Exception");
                btnLoginRiskAdmin.Enabled = true;

                return;
            }

            sbaStatus.Text = "Risk Administrator Login Successful";
        }

        /// <summary>
        /// Publishes a manual fill using the user input data
        /// </summary>
        private void btnCreateManualFill_Click(object sender, EventArgs e)
        {
            if (txtPublishPrice.Text == "" || txtPublishQty.Text == "")
            {
                //Display a message saying Price and Qty are mandatory
                MessageBox.Show("Please set both of the Price and the Qty values.", "Error");
                return;
            }

            try
            {
                //Instantiate the Manual Fill class
                manualFill = new XTAPI.TTManualFill();

                //Set the Manual Fill's properties based on the Member Group Trader specified
                manualFill.Set("Member", txtMemberManualFill.Text);
                manualFill.Set("Group", txtGroupManualFill.Text);
                manualFill.Set("Trader", txtTraderManualFill.Text);
                manualFill.Set("Acct", txtAcctManualFill.Text);

                //Set the Manual Fill object to the instrument from the drop handler
                manualFill.Instrument = m_TTInstrObj;

                //Set both Price and Qty
                manualFill.Set("Price" + cboMPublishPriceFormat.SelectedItem, txtPublishPrice.Text);

                //Check if Fill is a Buy or Sell
                if (optBuy.Checked == true)
                {
                    manualFill.Set("Long", txtPublishQty.Text);
                    manualFill.Set("BuySell", "B");
                }
                else
                {
                    manualFill.Set("Short", txtPublishQty.Text);
                    manualFill.Set("BuySell", "S");
                }

                //Publish the Manual Fill records to the Fill Server
                m_RiskManager.PublishManualFill(manualFill);

                //Add Manual Fill Record to ArrayList
                m_manualFillList.Add(manualFill);

                LoadManualFillData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }

        /// <summary>
        /// This function displays the About dialog box.
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.ShowDialog(this);
        }
    }
}
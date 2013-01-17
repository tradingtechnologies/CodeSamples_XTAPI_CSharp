using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace XTAPI_Samples
{
    /// <summary>
    /// OrderUpdate
    /// 
    /// This example demonstrates using the XTAPI to retrieve order status updates from
    /// the TTOrderSet.  The TTDropHandler object is used to resolve an instrument 
    /// dragged and dropped from the X_TRADER Market Grid.
    /// </summary>
    public partial class frmOrderUpdate : Form
    {
        // Declare the XTAPI objects.
        private XTAPI.TTDropHandlerClass m_TTDropHandler = null;
        private XTAPI.TTInstrNotifyClass m_TTInstrNotify = null;
        private XTAPI.TTOrderSetClass m_TTOrderSet = null;
        private XTAPI.TTInstrObj m_TTInstrObj = null;

        /// <summary>
        /// Upon the application form loading, the TTDropHandler, TTOrderSet, and TTInstrNotify 
        /// objects are initialized, and the required events are subscribed.
        /// </summary>
        public frmOrderUpdate()
        {
            InitializeComponent();

            // Instantiate the TTDropHandler class.
            m_TTDropHandler = new XTAPI.TTDropHandlerClass();

            // Register the active form for drag and drop.
            m_TTDropHandler.RegisterDropWindow((int) this.Handle);

            // Subscribe to the OnNotifyDrop event.
            m_TTDropHandler.OnNotifyDrop += new XTAPI._ITTDropHandlerEvents_OnNotifyDropEventHandler(this.m_TTDropHandler_OnNotifyDrop);

            // Instantiate the TTInstrNotify class.
            m_TTInstrNotify = new XTAPI.TTInstrNotifyClass();

            // Subscribe to the OnNotifyFound event.
            m_TTInstrNotify.OnNotifyFound += new XTAPI._ITTInstrNotifyEvents_OnNotifyFoundEventHandler(this.m_TTInstrNotify_OnNotifyFound);

            // Instantiate the TTOrderSet class.
            m_TTOrderSet = new XTAPI.TTOrderSetClass();

            // Enable reject events
            m_TTOrderSet.EnableOrderRejectData = 1;

            // Set normal level of detail in our order status events
            m_TTOrderSet.OrderStatusNotifyMode = XTAPI.enumOrderStatusNotifyMode.ORD_NOTIFY_NORMAL;

            // Subscribe to the order status update events
            m_TTOrderSet.OnOrderDeleted += new XTAPI._ITTOrderSetEvents_OnOrderDeletedEventHandler(m_TTOrderSet_OnOrderDeleted);
            m_TTOrderSet.OnOrderFilled += new XTAPI._ITTOrderSetEvents_OnOrderFilledEventHandler(m_TTOrderSet_OnOrderFilled);
            m_TTOrderSet.OnOrderHeld += new XTAPI._ITTOrderSetEvents_OnOrderHeldEventHandler(m_TTOrderSet_OnOrderHeld);
            m_TTOrderSet.OnOrderSubmitted += new XTAPI._ITTOrderSetEvents_OnOrderSubmittedEventHandler(m_TTOrderSet_OnOrderSubmitted);
            m_TTOrderSet.OnOrderUpdated += new XTAPI._ITTOrderSetEvents_OnOrderUpdatedEventHandler(m_TTOrderSet_OnOrderUpdated);
            m_TTOrderSet.OnOrderRejected += new XTAPI._ITTOrderSetEvents_OnOrderRejectedEventHandler(m_TTOrderSet_OnOrderRejected);

            // Set the Net Limits to false.
            m_TTOrderSet.Set("NetLimits", false);
        }

        /// <summary>
        /// Triggered when the XTAPI receives an order rejection message from the exchange for an 
        /// order in the order set.
        /// </summary>
        /// <param name="pRejectedOrderObj">Order object for the rejected order</param>
        void m_TTOrderSet_OnOrderRejected(XTAPI.TTOrderObj pRejectedOrderObj)
        {
            string siteOrderKey = (string)pRejectedOrderObj.get_Get("SiteOrderKey");

            txtStatusOut.Text += "Order Rejected by Exchange: " + siteOrderKey + "\r\n\r\n";
        }

        /// <summary>
        /// Triggered when there is a change in the existing orders state.
        /// </summary>
        /// <param name="pNewOrderObj">Order obj containing the updated order info</param>
        /// <param name="pOldOrderObj">Order obj containing the previous order</param>
        /// <param name="sSiteOrderKey">UID for the order</param>
        /// <param name="eOrderState">State of the updated order</param>
        /// <param name="eOrderAction">Action associated with the submitted order</param>
        /// <param name="updQty">Working qty if the updated order was in a working state</param>
        /// <param name="sOrderType">Order Type associated with the order</param>
        /// <param name="sOrderTraits">Traits associated with the order</param>
        void m_TTOrderSet_OnOrderUpdated(XTAPI.TTOrderObj pNewOrderObj, XTAPI.TTOrderObj pOldOrderObj, string sSiteOrderKey, XTAPI.enumOrderNotifyState eOrderState, XTAPI.enumOrderAction eOrderAction, int updQty, string sOrderType, string sOrderTraits)
        {
            txtStatusOut.Text += "Order Updated: " + sSiteOrderKey + "\r\n\r\n";

            PublishEventOrderData(pNewOrderObj, pOldOrderObj);
        }

        /// <summary>
        /// Triggered when a new order is submitted to the exchange or a held order is resubmitted.
        /// </summary>
        /// <param name="pNewOrderObj">Order obj containing the updated order info</param>
        /// <param name="pOldOrderObj">Order obj containing the previous order</param>
        /// <param name="sSiteOrderKey">UID for the order</param>
        /// <param name="eOrderAction">Action associated with the submitted order</param>
        /// <param name="wrkQty">Working qty for the order</param>
        /// <param name="sOrderType">Order Type associated with the order</param>
        /// <param name="sOrderTraits">Traits associated with the order</param>
        void m_TTOrderSet_OnOrderSubmitted(XTAPI.TTOrderObj pNewOrderObj, XTAPI.TTOrderObj pOldOrderObj, string sSiteOrderKey, XTAPI.enumOrderAction eOrderAction, int wrkQty, string sOrderType, string sOrderTraits)
        {
            txtStatusOut.Text += "Order Submitted: " + sSiteOrderKey + "\r\n\r\n";

            PublishEventOrderData(pNewOrderObj, pOldOrderObj);
        }

        /// <summary>
        /// Triggered when a TT Gateway receives a hold order
        /// </summary>
        /// <param name="pNewOrderObj">Order obj containing the updated order info</param>
        /// <param name="pOldOrderObj">Order obj containing the previous order</param>
        /// <param name="sSiteOrderKey">UID for the order</param>
        /// <param name="eOrderAction">Action associated with the submitted order</param>
        /// <param name="ordQty">Quantity of the held order.</param>
        void m_TTOrderSet_OnOrderHeld(XTAPI.TTOrderObj pNewOrderObj, XTAPI.TTOrderObj pOldOrderObj, string sSiteOrderKey, XTAPI.enumOrderAction eOrderAction, int ordQty)
        {

            txtStatusOut.Text += "Order Held: " + sSiteOrderKey + "\r\n\r\n";

            PublishEventOrderData(pNewOrderObj, pOldOrderObj);
        }

        /// <summary>
        /// Triggered when an order is filled
        /// </summary>
        /// <param name="pNewOrderObj">Order obj containing the updated order info</param>
        /// <param name="pOldOrderObj">Order obj containing the previous order</param>
        /// <param name="sSiteOrderKey">UID for the order</param>
        /// <param name="eOrderState">Action associated with the submitted order</param>
        /// <param name="fillQty">Quantity of the fill.</param>
        void m_TTOrderSet_OnOrderFilled(XTAPI.TTOrderObj pNewOrderObj, XTAPI.TTOrderObj pOldOrderObj, string sSiteOrderKey, XTAPI.enumOrderNotifyState eOrderState, int fillQty)
        {
            txtStatusOut.Text += "Order Filled: " + sSiteOrderKey + "\r\n\r\n";

            PublishEventOrderData(pNewOrderObj, pOldOrderObj);
        }

        /// <summary>
        /// Triggered when orders are taken out of the market.
        /// </summary>
        /// <param name="pNewOrderObj">Order obj containing the updated order info</param>
        /// <param name="pOldOrderObj">Order obj containing the previous order</param>
        /// <param name="sSiteOrderKey">UID for the order</param>
        /// <param name="eOrderState">State of the order before being deleted</param>
        /// <param name="eOrderAction">Action associated with the submitted order</param>
        /// <param name="fillQty">Quantity of the delete.</param>
        void m_TTOrderSet_OnOrderDeleted(XTAPI.TTOrderObj pNewOrderObj, XTAPI.TTOrderObj pOldOrderObj, string sSiteOrderKey, XTAPI.enumOrderNotifyState eOrderState, XTAPI.enumOrderAction eOrderAction, int delQty)
        {
            txtStatusOut.Text += "Order Deleted: " + sSiteOrderKey + "\r\n\r\n";

            PublishEventOrderData(pNewOrderObj, pOldOrderObj);
        }

        /// <summary>
        /// This function is called when one or more instruments are dragged and dropped from 
        /// the Market Grid in X_TRADER.
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

        /// <summary>
        /// Called when an instrument is found after it's opened.
        /// </summary>
        /// <param name="pNotify">Instrument Notification Object</param>
        /// <param name="pInstr">Instrument Object</param>
        private void m_TTInstrNotify_OnNotifyFound(XTAPI.TTInstrNotify pNotify, XTAPI.TTInstrObj pInstr)
        {
            // Update the Status Bar text.
            sbaStatus.Text = "Instrument Found.";

            // Retrieve the instrument information using the TTInstrObj Get Properties.
            Array data = (Array)pInstr.get_Get("Exchange,Product,ProdType,Contract");

            txtExchange.Text = (string)data.GetValue(0);
            txtProduct.Text = (string)data.GetValue(1);
            txtProductType.Text = (string)data.GetValue(2);
            txtContract.Text = (string)data.GetValue(3);

            // Obtain the available customer names and add them to the ComboBox.
            XTAPI.TTOrderProfileClass orderProfile = new XTAPI.TTOrderProfileClass();
            foreach (string entry in orderProfile.Customers as Array)
            {
                cboCustomer.Items.Add(entry);
            }

            // Set the first item in the customer combo boxes.
            cboCustomer.SelectedIndex = 0;

            // Enable the user interface items.	
            cboCustomer.Enabled = true;

            // Set the Net Limits to false.
            m_TTOrderSet.Set("NetLimits", false);
            // Open the TTOrderSet with send orders enabled.
            m_TTOrderSet.Open(1);
        }

        /// <summary>
        /// This function is called when the user clicks the buy button.
        /// </summary>
        /// <param name="sender">Object which fires the method</param>
        /// <param name="e">Event arguments of the callback</param>
        private void BuyButton_Click(object sender, EventArgs e)
        {
            SendOrder("Buy");
        }

        /// <summary>
        /// This function is called when the user clicks the sell button.
        /// </summary>
        /// <param name="sender">Object which fires the method</param>
        /// <param name="e">Event arguments of the callback</param>
        private void SellButton_Click(object sender, EventArgs e)
        {
            SendOrder("Sell");
        }

        /// <summary>
        /// This function sets up the TTOrderProfile and submits the order using the 
        /// TTOrderSet SendOrder method.
        /// </summary>
        /// <param name="buySell">The side of the market to place the order on.</param>
        private void SendOrder(string buySell)
        {
            try
            {
                XTAPI.TTOrderProfileClass orderProfile = new XTAPI.TTOrderProfileClass();

                // Set the TTInstrObj to the TTOrderProfile.
                orderProfile.Instrument = m_TTInstrObj;
                // Set the customer default property (e.g. "<Default>").
                orderProfile.Customer = cboCustomer.SelectedItem.ToString();
                // Set for Buy or Sell.
                orderProfile.Set("BuySell", buySell);
                // Set the quantity.
                orderProfile.Set("Qty", txtQuantity.Text);
                // Set the order type to "L" for a limit order.
                orderProfile.Set("OrderType", "L");
                // Set the limit order price.
                orderProfile.Set("Limit$", txtPrice.Text);

                // Send the order by submitting the TTOrderProfile through the TTOrderSet.
                int submittedQuantity = m_TTOrderSet.get_SendOrder(orderProfile);
            }
            catch (Exception ex)
            {
                // Display exception message.
				MessageBox.Show(ex.Message, "Exception");
            }
        }

        /// <summary>
        /// Publish specific information about each order to the GUI
        /// </summary>
        /// <param name="pNewOrderObj">New order object</param>
        /// <param name="pOldOrderObj">Old order object</param>
        private void PublishEventOrderData(XTAPI.TTOrderObj pNewOrderObj, XTAPI.TTOrderObj pOldOrderObj)
        {
            if (pOldOrderObj.IsNull != 0)
            {
                txtStatusOut.Text += "Old Order: NULL\r\n";
            }
            else
            {
                try
                {
                    Array oldOrderData = (Array)pOldOrderObj.get_Get("Contract$,BuySell,OrderQty,Price,OrderNo,ExecutionType");

                    txtStatusOut.Text += "Old Order: " + oldOrderData.GetValue(0).ToString() + ", " +
                                                         oldOrderData.GetValue(1).ToString() + ", " +
                                                         oldOrderData.GetValue(2).ToString() + ", " +
                                                         oldOrderData.GetValue(3).ToString() + ", " +
                                                         oldOrderData.GetValue(4).ToString() + ", " +
                                                         oldOrderData.GetValue(5).ToString() + "\r\n";
                }
                catch (Exception ex)
                {
                    txtStatusOut.Text += "Old Order: Error Message - " + ex.Message + "\r\n";
                }
            }

            if (pNewOrderObj.IsNull != 0)
            {
                txtStatusOut.Text += "New Order: NULL\r\n";
            }
            else
            {
                try
                {
                    Array newOrderData = (Array)pNewOrderObj.get_Get("Contract$,BuySell,OrderQty,Price,OrderNo,ExecutionType");

                    txtStatusOut.Text += "New Order: " + newOrderData.GetValue(0).ToString() + ", " +
                                                         newOrderData.GetValue(1).ToString() + ", " +
                                                         newOrderData.GetValue(2).ToString() + ", " +
                                                         newOrderData.GetValue(3).ToString() + ", " +
                                                         newOrderData.GetValue(4).ToString() + ", " +
                                                         newOrderData.GetValue(5).ToString() + "\r\n";
                }
                catch (Exception ex)
                {
                    txtStatusOut.Text += "New Order: Error Message - " + ex.Message + "\r\n";
                }
            }

            txtStatusOut.Text += "\r\n";
        }

        /// <summary>
        /// Display the About dialog box.
        /// </summary>
        /// <param name="sender">Object which fires the method</param>
        /// <param name="e">Event arguments of the callback</param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About frmAbout = new About();
            frmAbout.ShowDialog();
        }
    }
}
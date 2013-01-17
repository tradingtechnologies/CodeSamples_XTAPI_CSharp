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
 ***************************************************************************/

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace XTAPI_Samples
{
	/// <summary>
	/// OrderSelector
    /// 
    /// This example demonstrates using the XTAPI to filter the order updates using the
    /// TTOrderSelector object.  
    /// 
    /// Note:	Separate TTOrderSet objects are created for submitting orders and
    /// 		receiving order updates.  This is the recommended practice, as orders 
    /// 		sent on a filtered TTOrderSet must match the filter, or will be 
    /// 		rejected.
	/// </summary>
	public class frmOrderSelector : Form
    {
        // Declare the XTAPI objects.
		private XTAPI.TTDropHandlerClass m_TTDropHandler = null;
		private XTAPI.TTInstrObj m_TTInstrObj = null;
		private XTAPI.TTInstrNotifyClass m_TTInstrNotify = null;
		private XTAPI.TTOrderSetClass m_TTOrderSetSendOrder = null;
		private XTAPI.TTOrderSetClass m_TTOrderSetReceiveOrder = null;
		private XTAPI.TTOrderSelector m_TTOrderSelector = null;

        /// <summary>
        /// Upon the application form loading, the TTDropHandler and TTInstrNotify 
        /// objects are initialized, and the required events are subscribed.
        /// </summary>
		public frmOrderSelector()
		{
			// Required for Windows Form Designer support
			InitializeComponent();

			// Instantiate the drag and drop handler class.					 
			m_TTDropHandler = new XTAPI.TTDropHandlerClass();	
			// Register the active form for drag and drop.
			m_TTDropHandler.RegisterDropWindow((int) this.Handle);	
			// Associate the drop and drag callback event.
			m_TTDropHandler.OnNotifyDrop += new XTAPI._ITTDropHandlerEvents_OnNotifyDropEventHandler(this.m_TTDropHandler_OnNotifyDrop);
			
			// Instantiate the instrument notification class.
			m_TTInstrNotify = new XTAPI.TTInstrNotifyClass();
			// Subscribe to the TTInstrNotify events.
			m_TTInstrNotify.OnNotifyFound += new XTAPI._ITTInstrNotifyEvents_OnNotifyFoundEventHandler(this.m_TTInstrNotify_OnNotifyFound);		

			// Instantiate a TTOrderSet object for submitting orders.
			m_TTOrderSetSendOrder = new XTAPI.TTOrderSetClass();
			m_TTOrderSetSendOrder.Set("NetLimits",false);
			m_TTOrderSetSendOrder.Open(1);

			// Instantiate the the TTOrderSelector object.
			m_TTOrderSelector = new XTAPI.TTOrderSelectorClass();

			// Instantiate a TTOrderSet object for receiving orders.
			m_TTOrderSetReceiveOrder = new XTAPI.TTOrderSetClass();
			m_TTOrderSetReceiveOrder.OnOrderSetUpdate += new XTAPI._ITTOrderSetEvents_OnOrderSetUpdateEventHandler(m_TTOrderSet_OnOrderSetUpdate);

            // Enable the TTOrderTracker and order updates.
			m_TTOrderSetReceiveOrder.EnableOrderUpdateData = 1;
			m_TTOrderSetReceiveOrder.EnableOrderSetUpdates = 1;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

        private IContainer components;
        private System.Windows.Forms.StatusBar sbaStatus;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem mnuAbout;
        private System.Windows.Forms.GroupBox gboInstrumentInfo;
        private System.Windows.Forms.Label lblProductType;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblExchange;
        private System.Windows.Forms.TextBox txtContract;
        private System.Windows.Forms.Label lblContract;
        private System.Windows.Forms.TextBox txtExchange;
        private System.Windows.Forms.TextBox txtProductType;
        private System.Windows.Forms.GroupBox gboLimitOrderEntry;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblNotProduction;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.GroupBox gboOrderSelector;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.CheckBox chkSell;
        private System.Windows.Forms.CheckBox chkBuy;
        private System.Windows.Forms.RadioButton optAllMatchesRequired;
        private System.Windows.Forms.RadioButton optAllowAnyMatches;
        private System.Windows.Forms.Button btnSetSelector;
        private System.Windows.Forms.CheckBox chkXTraderOrders;
        private System.Windows.Forms.CheckBox chkXTAPIOrders;
        private System.Windows.Forms.TextBox txtContractSelector;
        private System.Windows.Forms.TextBox txtExchangeSelector;
        private System.Windows.Forms.CheckBox chkContract;
        private System.Windows.Forms.CheckBox chkExchange;

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.sbaStatus = new System.Windows.Forms.StatusBar();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.mnuAbout = new System.Windows.Forms.MenuItem();
            this.gboInstrumentInfo = new System.Windows.Forms.GroupBox();
            this.lblProductType = new System.Windows.Forms.Label();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblExchange = new System.Windows.Forms.Label();
            this.txtContract = new System.Windows.Forms.TextBox();
            this.lblContract = new System.Windows.Forms.Label();
            this.txtExchange = new System.Windows.Forms.TextBox();
            this.txtProductType = new System.Windows.Forms.TextBox();
            this.gboLimitOrderEntry = new System.Windows.Forms.GroupBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.btnSell = new System.Windows.Forms.Button();
            this.btnBuy = new System.Windows.Forms.Button();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.gboOrderSelector = new System.Windows.Forms.GroupBox();
            this.chkExchange = new System.Windows.Forms.CheckBox();
            this.chkContract = new System.Windows.Forms.CheckBox();
            this.txtExchangeSelector = new System.Windows.Forms.TextBox();
            this.txtContractSelector = new System.Windows.Forms.TextBox();
            this.chkXTAPIOrders = new System.Windows.Forms.CheckBox();
            this.chkXTraderOrders = new System.Windows.Forms.CheckBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.chkSell = new System.Windows.Forms.CheckBox();
            this.chkBuy = new System.Windows.Forms.CheckBox();
            this.optAllMatchesRequired = new System.Windows.Forms.RadioButton();
            this.optAllowAnyMatches = new System.Windows.Forms.RadioButton();
            this.btnSetSelector = new System.Windows.Forms.Button();
            this.lblNotProduction = new System.Windows.Forms.Label();
            this.lblWarning = new System.Windows.Forms.Label();
            this.gboInstrumentInfo.SuspendLayout();
            this.gboLimitOrderEntry.SuspendLayout();
            this.gboOrderSelector.SuspendLayout();
            this.SuspendLayout();
            // 
            // sbaStatus
            // 
            this.sbaStatus.Location = new System.Drawing.Point(0, 519);
            this.sbaStatus.Name = "sbaStatus";
            this.sbaStatus.Size = new System.Drawing.Size(431, 22);
            this.sbaStatus.SizingGrip = false;
            this.sbaStatus.TabIndex = 63;
            this.sbaStatus.Text = "Drag and Drop an instrument from the Market Grid in X_TRADER to this window.";
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuAbout});
            // 
            // mnuAbout
            // 
            this.mnuAbout.Index = 0;
            this.mnuAbout.Text = "About...";
            this.mnuAbout.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // gboInstrumentInfo
            // 
            this.gboInstrumentInfo.Controls.Add(this.lblProductType);
            this.gboInstrumentInfo.Controls.Add(this.txtProduct);
            this.gboInstrumentInfo.Controls.Add(this.lblProduct);
            this.gboInstrumentInfo.Controls.Add(this.lblExchange);
            this.gboInstrumentInfo.Controls.Add(this.txtContract);
            this.gboInstrumentInfo.Controls.Add(this.lblContract);
            this.gboInstrumentInfo.Controls.Add(this.txtExchange);
            this.gboInstrumentInfo.Controls.Add(this.txtProductType);
            this.gboInstrumentInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gboInstrumentInfo.Location = new System.Drawing.Point(8, 53);
            this.gboInstrumentInfo.Name = "gboInstrumentInfo";
            this.gboInstrumentInfo.Size = new System.Drawing.Size(216, 136);
            this.gboInstrumentInfo.TabIndex = 64;
            this.gboInstrumentInfo.TabStop = false;
            this.gboInstrumentInfo.Text = "Instrument Information";
            // 
            // lblProductType
            // 
            this.lblProductType.Location = new System.Drawing.Point(8, 69);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(80, 16);
            this.lblProductType.TabIndex = 38;
            this.lblProductType.Text = "Product Type:";
            this.lblProductType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProduct
            // 
            this.txtProduct.Location = new System.Drawing.Point(96, 45);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(100, 20);
            this.txtProduct.TabIndex = 35;
            // 
            // lblProduct
            // 
            this.lblProduct.Location = new System.Drawing.Point(40, 45);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(48, 16);
            this.lblProduct.TabIndex = 36;
            this.lblProduct.Text = "Product:";
            this.lblProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblExchange
            // 
            this.lblExchange.Location = new System.Drawing.Point(24, 21);
            this.lblExchange.Name = "lblExchange";
            this.lblExchange.Size = new System.Drawing.Size(64, 16);
            this.lblExchange.TabIndex = 34;
            this.lblExchange.Text = "Exchange:";
            this.lblExchange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtContract
            // 
            this.txtContract.Location = new System.Drawing.Point(96, 93);
            this.txtContract.Name = "txtContract";
            this.txtContract.Size = new System.Drawing.Size(100, 20);
            this.txtContract.TabIndex = 39;
            // 
            // lblContract
            // 
            this.lblContract.Location = new System.Drawing.Point(32, 93);
            this.lblContract.Name = "lblContract";
            this.lblContract.Size = new System.Drawing.Size(56, 16);
            this.lblContract.TabIndex = 40;
            this.lblContract.Text = "Contract:";
            this.lblContract.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtExchange
            // 
            this.txtExchange.Location = new System.Drawing.Point(96, 21);
            this.txtExchange.Name = "txtExchange";
            this.txtExchange.Size = new System.Drawing.Size(100, 20);
            this.txtExchange.TabIndex = 33;
            // 
            // txtProductType
            // 
            this.txtProductType.Location = new System.Drawing.Point(96, 69);
            this.txtProductType.Name = "txtProductType";
            this.txtProductType.Size = new System.Drawing.Size(100, 20);
            this.txtProductType.TabIndex = 37;
            // 
            // gboLimitOrderEntry
            // 
            this.gboLimitOrderEntry.Controls.Add(this.lblCustomer);
            this.gboLimitOrderEntry.Controls.Add(this.cboCustomer);
            this.gboLimitOrderEntry.Controls.Add(this.btnSell);
            this.gboLimitOrderEntry.Controls.Add(this.btnBuy);
            this.gboLimitOrderEntry.Controls.Add(this.lblQuantity);
            this.gboLimitOrderEntry.Controls.Add(this.txtQuantity);
            this.gboLimitOrderEntry.Controls.Add(this.lblPrice);
            this.gboLimitOrderEntry.Controls.Add(this.txtPrice);
            this.gboLimitOrderEntry.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gboLimitOrderEntry.Location = new System.Drawing.Point(232, 53);
            this.gboLimitOrderEntry.Name = "gboLimitOrderEntry";
            this.gboLimitOrderEntry.Size = new System.Drawing.Size(188, 136);
            this.gboLimitOrderEntry.TabIndex = 66;
            this.gboLimitOrderEntry.TabStop = false;
            this.gboLimitOrderEntry.Text = "Limit Order Entry";
            // 
            // lblCustomer
            // 
            this.lblCustomer.Location = new System.Drawing.Point(11, 21);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(64, 16);
            this.lblCustomer.TabIndex = 47;
            this.lblCustomer.Text = "Customer:";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboCustomer
            // 
            this.cboCustomer.Enabled = false;
            this.cboCustomer.Location = new System.Drawing.Point(83, 21);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(88, 21);
            this.cboCustomer.TabIndex = 46;
            // 
            // btnSell
            // 
            this.btnSell.Enabled = false;
            this.btnSell.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSell.Location = new System.Drawing.Point(115, 101);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(56, 23);
            this.btnSell.TabIndex = 43;
            this.btnSell.Text = "Sell";
            this.btnSell.Click += new System.EventHandler(this.SellButton_Click);
            // 
            // btnBuy
            // 
            this.btnBuy.Enabled = false;
            this.btnBuy.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBuy.Location = new System.Drawing.Point(59, 101);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(56, 23);
            this.btnBuy.TabIndex = 42;
            this.btnBuy.Text = "Buy";
            this.btnBuy.Click += new System.EventHandler(this.BuyButton_Click);
            // 
            // lblQuantity
            // 
            this.lblQuantity.Location = new System.Drawing.Point(11, 69);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(64, 16);
            this.lblQuantity.TabIndex = 38;
            this.lblQuantity.Text = "Quantity:";
            this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(83, 69);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(88, 20);
            this.txtQuantity.TabIndex = 37;
            // 
            // lblPrice
            // 
            this.lblPrice.Location = new System.Drawing.Point(11, 45);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(64, 16);
            this.lblPrice.TabIndex = 36;
            this.lblPrice.Text = "Price:";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(83, 45);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(88, 20);
            this.txtPrice.TabIndex = 35;
            // 
            // gboOrderSelector
            // 
            this.gboOrderSelector.Controls.Add(this.chkExchange);
            this.gboOrderSelector.Controls.Add(this.chkContract);
            this.gboOrderSelector.Controls.Add(this.txtExchangeSelector);
            this.gboOrderSelector.Controls.Add(this.txtContractSelector);
            this.gboOrderSelector.Controls.Add(this.chkXTAPIOrders);
            this.gboOrderSelector.Controls.Add(this.chkXTraderOrders);
            this.gboOrderSelector.Controls.Add(this.txtOutput);
            this.gboOrderSelector.Controls.Add(this.chkSell);
            this.gboOrderSelector.Controls.Add(this.chkBuy);
            this.gboOrderSelector.Controls.Add(this.optAllMatchesRequired);
            this.gboOrderSelector.Controls.Add(this.optAllowAnyMatches);
            this.gboOrderSelector.Controls.Add(this.btnSetSelector);
            this.gboOrderSelector.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gboOrderSelector.Location = new System.Drawing.Point(8, 195);
            this.gboOrderSelector.Name = "gboOrderSelector";
            this.gboOrderSelector.Size = new System.Drawing.Size(412, 313);
            this.gboOrderSelector.TabIndex = 67;
            this.gboOrderSelector.TabStop = false;
            this.gboOrderSelector.Text = "Order Selector";
            // 
            // chkExchange
            // 
            this.chkExchange.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkExchange.Location = new System.Drawing.Point(68, 101);
            this.chkExchange.Name = "chkExchange";
            this.chkExchange.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkExchange.Size = new System.Drawing.Size(72, 16);
            this.chkExchange.TabIndex = 65;
            this.chkExchange.Text = "Exchange";
            // 
            // chkContract
            // 
            this.chkContract.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkContract.Location = new System.Drawing.Point(76, 77);
            this.chkContract.Name = "chkContract";
            this.chkContract.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkContract.Size = new System.Drawing.Size(64, 16);
            this.chkContract.TabIndex = 64;
            this.chkContract.Text = "Contract";
            // 
            // txtExchangeSelector
            // 
            this.txtExchangeSelector.Location = new System.Drawing.Point(146, 99);
            this.txtExchangeSelector.Name = "txtExchangeSelector";
            this.txtExchangeSelector.Size = new System.Drawing.Size(80, 20);
            this.txtExchangeSelector.TabIndex = 62;
            // 
            // txtContractSelector
            // 
            this.txtContractSelector.Location = new System.Drawing.Point(146, 75);
            this.txtContractSelector.Name = "txtContractSelector";
            this.txtContractSelector.Size = new System.Drawing.Size(80, 20);
            this.txtContractSelector.TabIndex = 60;
            // 
            // chkXTAPIOrders
            // 
            this.chkXTAPIOrders.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkXTAPIOrders.Location = new System.Drawing.Point(12, 44);
            this.chkXTAPIOrders.Name = "chkXTAPIOrders";
            this.chkXTAPIOrders.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkXTAPIOrders.Size = new System.Drawing.Size(128, 16);
            this.chkXTAPIOrders.TabIndex = 59;
            this.chkXTAPIOrders.Text = "XTAPI Orders";
            // 
            // chkXTraderOrders
            // 
            this.chkXTraderOrders.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkXTraderOrders.Location = new System.Drawing.Point(12, 20);
            this.chkXTraderOrders.Name = "chkXTraderOrders";
            this.chkXTraderOrders.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkXTraderOrders.Size = new System.Drawing.Size(128, 16);
            this.chkXTraderOrders.TabIndex = 58;
            this.chkXTraderOrders.Text = "X_TRADER Orders";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(10, 127);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(392, 176);
            this.txtOutput.TabIndex = 57;
            this.txtOutput.WordWrap = false;
            // 
            // chkSell
            // 
            this.chkSell.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSell.Location = new System.Drawing.Point(170, 20);
            this.chkSell.Name = "chkSell";
            this.chkSell.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkSell.Size = new System.Drawing.Size(56, 16);
            this.chkSell.TabIndex = 54;
            this.chkSell.Text = "Sell";
            // 
            // chkBuy
            // 
            this.chkBuy.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkBuy.Location = new System.Drawing.Point(170, 44);
            this.chkBuy.Name = "chkBuy";
            this.chkBuy.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkBuy.Size = new System.Drawing.Size(56, 16);
            this.chkBuy.TabIndex = 53;
            this.chkBuy.Text = "Buy";
            // 
            // optAllMatchesRequired
            // 
            this.optAllMatchesRequired.Checked = true;
            this.optAllMatchesRequired.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optAllMatchesRequired.Location = new System.Drawing.Point(266, 20);
            this.optAllMatchesRequired.Name = "optAllMatchesRequired";
            this.optAllMatchesRequired.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.optAllMatchesRequired.Size = new System.Drawing.Size(136, 16);
            this.optAllMatchesRequired.TabIndex = 52;
            this.optAllMatchesRequired.TabStop = true;
            this.optAllMatchesRequired.Text = "All Matches Required";
            // 
            // optAllowAnyMatches
            // 
            this.optAllowAnyMatches.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optAllowAnyMatches.Location = new System.Drawing.Point(266, 44);
            this.optAllowAnyMatches.Name = "optAllowAnyMatches";
            this.optAllowAnyMatches.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.optAllowAnyMatches.Size = new System.Drawing.Size(136, 16);
            this.optAllowAnyMatches.TabIndex = 51;
            this.optAllowAnyMatches.Text = "Allow Any Matches";
            // 
            // btnSetSelector
            // 
            this.btnSetSelector.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSetSelector.Location = new System.Drawing.Point(322, 96);
            this.btnSetSelector.Name = "btnSetSelector";
            this.btnSetSelector.Size = new System.Drawing.Size(80, 23);
            this.btnSetSelector.TabIndex = 50;
            this.btnSetSelector.Text = "Set Selector";
            this.btnSetSelector.Click += new System.EventHandler(this.SetSelectorButton_Click);
            // 
            // lblNotProduction
            // 
            this.lblNotProduction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotProduction.Location = new System.Drawing.Point(8, 34);
            this.lblNotProduction.Name = "lblNotProduction";
            this.lblNotProduction.Size = new System.Drawing.Size(412, 14);
            this.lblNotProduction.TabIndex = 69;
            this.lblNotProduction.Text = "This sample is NOT to be used in production or during conformance testing.";
            this.lblNotProduction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWarning
            // 
            this.lblWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarning.Location = new System.Drawing.Point(8, 9);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(412, 23);
            this.lblWarning.TabIndex = 68;
            this.lblWarning.Text = "WARNING!";
            this.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmOrderSelector
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(431, 541);
            this.Controls.Add(this.lblNotProduction);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.gboOrderSelector);
            this.Controls.Add(this.gboLimitOrderEntry);
            this.Controls.Add(this.gboInstrumentInfo);
            this.Controls.Add(this.sbaStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Menu = this.mainMenu1;
            this.Name = "frmOrderSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrderSelector";
            this.gboInstrumentInfo.ResumeLayout(false);
            this.gboInstrumentInfo.PerformLayout();
            this.gboLimitOrderEntry.ResumeLayout(false);
            this.gboLimitOrderEntry.PerformLayout();
            this.gboOrderSelector.ResumeLayout(false);
            this.gboOrderSelector.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			// Enable Visual Styles for XP Look and Feel.
			Application.EnableVisualStyles();
			Application.Run(new frmOrderSelector());
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
                    m_TTInstrObj = null;
				}

				// Obtain the TTInstrObj from the TTDropHandler object.
				m_TTInstrObj = (XTAPI.TTInstrObj) m_TTDropHandler[1];

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
        /// This function is called when an instrument is found after it is opened.
        /// </summary>
        /// <param name="pNotify">TTInstrNotify object</param>
        /// <param name="pInstr">TTInstrObj object</param>
		private void m_TTInstrNotify_OnNotifyFound(XTAPI.TTInstrNotify pNotify, XTAPI.TTInstrObj pInstr)
		{
			// Update the Status Bar text.
			sbaStatus.Text = "Instrument Found.";
			
			// Retrieve the instrument information using the TTInstrObj Get Properties.
			Array data = (Array) pInstr.get_Get("Exchange,Product,ProdType,Contract");

			txtExchange.Text = (string)data.GetValue(0);
			txtProduct.Text = (string)data.GetValue(1);
			txtProductType.Text = (string)data.GetValue(2);
			txtContract.Text = (string)data.GetValue(3);

			// Auto-populate the selector text boxes.
			txtContractSelector.Text = (string)data.GetValue(3);
			txtExchangeSelector.Text = (string)data.GetValue(0);

            // Obtain the available customer names and add them to the ComboBox.
            XTAPI.TTOrderProfileClass orderProfile = new XTAPI.TTOrderProfileClass();
            foreach (string entry in orderProfile.Customers as Array)
            {
                cboCustomer.Items.Add(entry);
            }

            // Set the first item in the customer combo boxes.
            cboCustomer.SelectedIndex = 0;

			// Enable the user interface items.
			btnBuy.Enabled = true;
			btnSell.Enabled = true;	
			cboCustomer.Enabled = true;
		}

        /// <summary>
        /// This function is called when the user clicks the buy button.
        /// </summary>
        /// <param name="sender">Object which fires the method</param>
        /// <param name="e">Event arguments of the callback</param>
		private void BuyButton_Click(object sender, System.EventArgs e)
		{
			// Call the SendOrder function with a Buy request.
			SendOrder("Buy");
		}

        /// <summary>
        /// This function is called when the user clicks the sell button.
        /// </summary>
        /// <param name="sender">Object which fires the method</param>
        /// <param name="e">Event arguments of the callback</param>
		private void SellButton_Click(object sender, System.EventArgs e)
		{
			// Call the SendOrder function with a Sell request.
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
                int submittedQuantity = m_TTOrderSetSendOrder.get_SendOrder(orderProfile);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Exception");
			}
		}

        /// <summary>
        /// This function is called for every order update received by the XTAPI.
        /// 
        /// Note:   The TTOrderTrackerObj has been deprecated in favor of the order status 
        ///         events, and remains in this sample for legacy code review.  
        ///         TT recommends monitoring orders through the events outlined in the
        ///         OrderUpdate example.
        /// </summary>
        /// <param name="pOrderSet">TTOrderSetObj object</param>
		private void m_TTOrderSet_OnOrderSetUpdate(XTAPI.TTOrderSet pOrderSet)
		{         		
			// Obtain the Next TTOrderTrackerObj object from the TTOrderSet.
            XTAPI.TTOrderTrackerObj tempOrderTrackerObj = pOrderSet.NextOrderTracker;

			// Iterate through the list of TTOrderTrackerObj objects.
			while (tempOrderTrackerObj != null)
			{
				// Test if an Old Order (past state) exists.
				if (tempOrderTrackerObj.HasOldOrder != 0)
				{
					txtOutput.Text += "Old Order: ";

					// Obtain the TTOrderObj from the TTOrderTrackerObj.
                    XTAPI.TTOrderObj tempOldOrder = tempOrderTrackerObj.OldOrder;
					Array tempOrderData = (Array) tempOldOrder.get_Get("Instr.Exchange,Contract$,BuySell,OrderSource");
			
					// Display the information on the interface.
					for(int i=0; i<tempOrderData.Length; i++)
						txtOutput.Text += tempOrderData.GetValue(i) + ",  ";

					txtOutput.Text += "\r\n";
				}

				// Test if an New Order (current state) exists.
				if (tempOrderTrackerObj.HasNewOrder != 0)
				{
					txtOutput.Text += "New Order: ";

					// Obtain the TTOrderObj from the TTOrderTrackerObj.
                    XTAPI.TTOrderObj tempNewOrder = tempOrderTrackerObj.NewOrder;
					Array tempOrderData = (Array) tempNewOrder.get_Get("Instr.Exchange,Contract$,BuySell,OrderSource");
					
					// Display the information on the interface.
					for(int i=0; i<tempOrderData.Length; i++)
						txtOutput.Text += tempOrderData.GetValue(i) + ",  ";

					txtOutput.Text += "\r\n";
				}

				// Obtain the Next TTOrderTrackerObj object from the TTOrderSet.
				tempOrderTrackerObj = pOrderSet.NextOrderTracker;
			}
		}

        /// <summary>
        /// This function configures the TTOrderSelector based on the user selected iterface items.
        /// </summary>
        /// <param name="sender">Object which fires the method</param>
        /// <param name="e">Event arguments of the callback</param>
		private void SetSelectorButton_Click(object sender, System.EventArgs e)
		{
			txtOutput.Text = "Order State:  Exchange,  Contract$,  BuySell,  OrderSource\r\n";

			// Reset the TTOrderSelector.
			m_TTOrderSelector.Reset();

            // Filter orders placed through X_TRADER.
			if( chkXTraderOrders.Checked )	
				m_TTOrderSelector.AddTest("OrderSource","0");

            // Filter orders placed through XTAPI.
			if( chkXTAPIOrders.Checked )	
				m_TTOrderSelector.AddTest("OrderSource","3");

            // Filter sell orders.
			if( chkSell.Checked )	
				m_TTOrderSelector.AddTest("IsSell","True");

            // Filter buy orders.
			if( chkBuy.Checked )	
				m_TTOrderSelector.AddTest("IsBuy","True");

            // Filter by contract.
			if( chkContract.Checked )	
				m_TTOrderSelector.AddTest("Contract$",txtContractSelector.Text);

            // Filter by exchange.
			if( chkExchange.Checked )	
				m_TTOrderSelector.AddTest("Instr.Exchange",txtExchangeSelector.Text);

            // "AND" all filters.
			if( optAllMatchesRequired.Checked )	
			{
				m_TTOrderSelector.AllMatchesRequired = 1;
				m_TTOrderSelector.AllowAnyMatches = 0;
			}
            // "OR" all filters.
			else	
			{
				m_TTOrderSelector.AllMatchesRequired = 0;
				m_TTOrderSelector.AllowAnyMatches = 1;
			}

			// Set the TTOrderSelector to the receiving TTOrderSet.
			m_TTOrderSetReceiveOrder.OrderSelector = m_TTOrderSelector;
			
			// Each time a new OrderSelector is set, the TTOrderSet must be re-opened.
			m_TTOrderSetReceiveOrder.Open(0);
		}

        /// <summary>
        /// Display the About dialog box.
        /// </summary>
        /// <param name="sender">Object which fires the method</param>
        /// <param name="e">Event arguments of the callback</param>
		private void AboutMenuItem_Click(object sender, System.EventArgs e)
		{
			About aboutForm = new About();
			aboutForm.ShowDialog(this);
		}
	}
}

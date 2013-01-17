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
	/// ModifyOrder
    /// 
    /// This example demonstrates using the XTAPI to modify an order.  Modifications 
    /// include change, cancel/replace, delete last order, delete all orders and delete
    /// a specified range of orders.
    /// 
    /// Note:	Deleting all orders or deleting a range of orders can include orders 
    /// 		placed outside of the XTAPI application.
	/// </summary>
	public class frmModifyOrder : Form
    {
        // Declare the XTAPI objects.
		private XTAPI.TTDropHandlerClass m_TTDropHandler = null;
		private XTAPI.TTInstrObj m_TTInstrObj = null;
		private XTAPI.TTInstrNotifyClass m_TTInstrNotify = null;
		private XTAPI.TTOrderSetClass m_TTOrderSet = null;

        // Record the SiteOrderKey of the last order placed through the application
		private string m_LastOrderSiteOrderKey;

        /// <summary>
        /// Upon the application form loading, the TTDropHandler, TTOrderSet, and 
        /// TTInstrNotify objects are initialized, and the required events are subscribed.
        /// </summary>
		public frmModifyOrder()
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

			// Instantiate the TTOrderSet object.
			m_TTOrderSet = new XTAPI.TTOrderSetClass();
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
        private System.Windows.Forms.GroupBox gboLimtOrderEntry;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblSiteOrderKey;
        private System.Windows.Forms.TextBox txtSiteOrderKey;
        private System.Windows.Forms.GroupBox gboLastOrder;
        private System.Windows.Forms.Label lblNotProduction;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Label lblLowPrice;
        private System.Windows.Forms.Label lblHighPrice;
        private System.Windows.Forms.Label lblNewQuantity;
        private System.Windows.Forms.Label lblNewPrice;
        private System.Windows.Forms.ComboBox cboDeleteType;
        private System.Windows.Forms.Button btnINvokeDelete;
        private System.Windows.Forms.TextBox txtLowPrice;
        private System.Windows.Forms.TextBox txtHighPrice;
        private System.Windows.Forms.RadioButton optIncludeRange;
        private System.Windows.Forms.RadioButton optExcludeRange;
        private System.Windows.Forms.ComboBox cboSide;
        private System.Windows.Forms.GroupBox gboDeleteOrder;
        private System.Windows.Forms.Button btnInvokeModify;
        private System.Windows.Forms.ComboBox cboModifyType;
        private System.Windows.Forms.TextBox txtNewQuantity;
        private System.Windows.Forms.TextBox txtNewPrice;
        private System.Windows.Forms.GroupBox gboModifyOrder;

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
            this.gboLimtOrderEntry = new System.Windows.Forms.GroupBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.btnSell = new System.Windows.Forms.Button();
            this.btnBuy = new System.Windows.Forms.Button();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.gboDeleteOrder = new System.Windows.Forms.GroupBox();
            this.cboSide = new System.Windows.Forms.ComboBox();
            this.optExcludeRange = new System.Windows.Forms.RadioButton();
            this.optIncludeRange = new System.Windows.Forms.RadioButton();
            this.txtHighPrice = new System.Windows.Forms.TextBox();
            this.lblHighPrice = new System.Windows.Forms.Label();
            this.txtLowPrice = new System.Windows.Forms.TextBox();
            this.lblLowPrice = new System.Windows.Forms.Label();
            this.cboDeleteType = new System.Windows.Forms.ComboBox();
            this.btnINvokeDelete = new System.Windows.Forms.Button();
            this.lblSiteOrderKey = new System.Windows.Forms.Label();
            this.txtSiteOrderKey = new System.Windows.Forms.TextBox();
            this.gboModifyOrder = new System.Windows.Forms.GroupBox();
            this.txtNewQuantity = new System.Windows.Forms.TextBox();
            this.lblNewQuantity = new System.Windows.Forms.Label();
            this.txtNewPrice = new System.Windows.Forms.TextBox();
            this.lblNewPrice = new System.Windows.Forms.Label();
            this.cboModifyType = new System.Windows.Forms.ComboBox();
            this.btnInvokeModify = new System.Windows.Forms.Button();
            this.gboLastOrder = new System.Windows.Forms.GroupBox();
            this.lblNotProduction = new System.Windows.Forms.Label();
            this.lblWarning = new System.Windows.Forms.Label();
            this.gboInstrumentInfo.SuspendLayout();
            this.gboLimtOrderEntry.SuspendLayout();
            this.gboDeleteOrder.SuspendLayout();
            this.gboModifyOrder.SuspendLayout();
            this.gboLastOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // sbaStatus
            // 
            this.sbaStatus.Location = new System.Drawing.Point(0, 452);
            this.sbaStatus.Name = "sbaStatus";
            this.sbaStatus.Size = new System.Drawing.Size(426, 22);
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
            this.gboInstrumentInfo.Location = new System.Drawing.Point(8, 57);
            this.gboInstrumentInfo.Name = "gboInstrumentInfo";
            this.gboInstrumentInfo.Size = new System.Drawing.Size(216, 136);
            this.gboInstrumentInfo.TabIndex = 64;
            this.gboInstrumentInfo.TabStop = false;
            this.gboInstrumentInfo.Text = "Instrument Information";
            // 
            // lblProductType
            // 
            this.lblProductType.Location = new System.Drawing.Point(8, 72);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(80, 16);
            this.lblProductType.TabIndex = 38;
            this.lblProductType.Text = "Product Type:";
            this.lblProductType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProduct
            // 
            this.txtProduct.Location = new System.Drawing.Point(96, 48);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(100, 20);
            this.txtProduct.TabIndex = 35;
            // 
            // lblProduct
            // 
            this.lblProduct.Location = new System.Drawing.Point(40, 48);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(48, 16);
            this.lblProduct.TabIndex = 36;
            this.lblProduct.Text = "Product:";
            this.lblProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblExchange
            // 
            this.lblExchange.Location = new System.Drawing.Point(24, 24);
            this.lblExchange.Name = "lblExchange";
            this.lblExchange.Size = new System.Drawing.Size(64, 16);
            this.lblExchange.TabIndex = 34;
            this.lblExchange.Text = "Exchange:";
            this.lblExchange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtContract
            // 
            this.txtContract.Location = new System.Drawing.Point(96, 96);
            this.txtContract.Name = "txtContract";
            this.txtContract.Size = new System.Drawing.Size(100, 20);
            this.txtContract.TabIndex = 39;
            // 
            // lblContract
            // 
            this.lblContract.Location = new System.Drawing.Point(32, 96);
            this.lblContract.Name = "lblContract";
            this.lblContract.Size = new System.Drawing.Size(56, 16);
            this.lblContract.TabIndex = 40;
            this.lblContract.Text = "Contract:";
            this.lblContract.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtExchange
            // 
            this.txtExchange.Location = new System.Drawing.Point(96, 24);
            this.txtExchange.Name = "txtExchange";
            this.txtExchange.Size = new System.Drawing.Size(100, 20);
            this.txtExchange.TabIndex = 33;
            // 
            // txtProductType
            // 
            this.txtProductType.Location = new System.Drawing.Point(96, 72);
            this.txtProductType.Name = "txtProductType";
            this.txtProductType.Size = new System.Drawing.Size(100, 20);
            this.txtProductType.TabIndex = 37;
            // 
            // gboLimtOrderEntry
            // 
            this.gboLimtOrderEntry.Controls.Add(this.lblCustomer);
            this.gboLimtOrderEntry.Controls.Add(this.cboCustomer);
            this.gboLimtOrderEntry.Controls.Add(this.btnSell);
            this.gboLimtOrderEntry.Controls.Add(this.btnBuy);
            this.gboLimtOrderEntry.Controls.Add(this.lblQuantity);
            this.gboLimtOrderEntry.Controls.Add(this.txtQuantity);
            this.gboLimtOrderEntry.Controls.Add(this.lblPrice);
            this.gboLimtOrderEntry.Controls.Add(this.txtPrice);
            this.gboLimtOrderEntry.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gboLimtOrderEntry.Location = new System.Drawing.Point(232, 57);
            this.gboLimtOrderEntry.Name = "gboLimtOrderEntry";
            this.gboLimtOrderEntry.Size = new System.Drawing.Size(184, 136);
            this.gboLimtOrderEntry.TabIndex = 66;
            this.gboLimtOrderEntry.TabStop = false;
            this.gboLimtOrderEntry.Text = "Limit Order Entry";
            // 
            // lblCustomer
            // 
            this.lblCustomer.Location = new System.Drawing.Point(8, 24);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(64, 16);
            this.lblCustomer.TabIndex = 47;
            this.lblCustomer.Text = "Customer:";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboCustomer
            // 
            this.cboCustomer.Enabled = false;
            this.cboCustomer.Location = new System.Drawing.Point(80, 24);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(88, 21);
            this.cboCustomer.TabIndex = 46;
            // 
            // btnSell
            // 
            this.btnSell.Enabled = false;
            this.btnSell.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSell.Location = new System.Drawing.Point(112, 104);
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
            this.btnBuy.Location = new System.Drawing.Point(56, 104);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(56, 23);
            this.btnBuy.TabIndex = 42;
            this.btnBuy.Text = "Buy";
            this.btnBuy.Click += new System.EventHandler(this.BuyButton_Click);
            // 
            // lblQuantity
            // 
            this.lblQuantity.Location = new System.Drawing.Point(8, 72);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(64, 16);
            this.lblQuantity.TabIndex = 38;
            this.lblQuantity.Text = "Quantity:";
            this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(80, 72);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(88, 20);
            this.txtQuantity.TabIndex = 37;
            // 
            // lblPrice
            // 
            this.lblPrice.Location = new System.Drawing.Point(8, 48);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(64, 16);
            this.lblPrice.TabIndex = 36;
            this.lblPrice.Text = "Price:";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(80, 48);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(88, 20);
            this.txtPrice.TabIndex = 35;
            // 
            // gboDeleteOrder
            // 
            this.gboDeleteOrder.Controls.Add(this.cboSide);
            this.gboDeleteOrder.Controls.Add(this.optExcludeRange);
            this.gboDeleteOrder.Controls.Add(this.optIncludeRange);
            this.gboDeleteOrder.Controls.Add(this.txtHighPrice);
            this.gboDeleteOrder.Controls.Add(this.lblHighPrice);
            this.gboDeleteOrder.Controls.Add(this.txtLowPrice);
            this.gboDeleteOrder.Controls.Add(this.lblLowPrice);
            this.gboDeleteOrder.Controls.Add(this.cboDeleteType);
            this.gboDeleteOrder.Controls.Add(this.btnINvokeDelete);
            this.gboDeleteOrder.Enabled = false;
            this.gboDeleteOrder.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gboDeleteOrder.Location = new System.Drawing.Point(232, 201);
            this.gboDeleteOrder.Name = "gboDeleteOrder";
            this.gboDeleteOrder.Size = new System.Drawing.Size(184, 240);
            this.gboDeleteOrder.TabIndex = 67;
            this.gboDeleteOrder.TabStop = false;
            this.gboDeleteOrder.Text = "Delete Order";
            // 
            // cboSide
            // 
            this.cboSide.Enabled = false;
            this.cboSide.Items.AddRange(new object[] {
            "Buy",
            "Sell"});
            this.cboSide.Location = new System.Drawing.Point(88, 56);
            this.cboSide.Name = "cboSide";
            this.cboSide.Size = new System.Drawing.Size(72, 21);
            this.cboSide.TabIndex = 52;
            this.cboSide.Text = "Buy";
            // 
            // optExcludeRange
            // 
            this.optExcludeRange.Enabled = false;
            this.optExcludeRange.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optExcludeRange.Location = new System.Drawing.Point(64, 168);
            this.optExcludeRange.Name = "optExcludeRange";
            this.optExcludeRange.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.optExcludeRange.Size = new System.Drawing.Size(96, 16);
            this.optExcludeRange.TabIndex = 51;
            this.optExcludeRange.Text = "Exclude Range";
            // 
            // optIncludeRange
            // 
            this.optIncludeRange.Checked = true;
            this.optIncludeRange.Enabled = false;
            this.optIncludeRange.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optIncludeRange.Location = new System.Drawing.Point(64, 144);
            this.optIncludeRange.Name = "optIncludeRange";
            this.optIncludeRange.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.optIncludeRange.Size = new System.Drawing.Size(96, 16);
            this.optIncludeRange.TabIndex = 50;
            this.optIncludeRange.TabStop = true;
            this.optIncludeRange.Text = "Include Range";
            // 
            // txtHighPrice
            // 
            this.txtHighPrice.Enabled = false;
            this.txtHighPrice.Location = new System.Drawing.Point(88, 112);
            this.txtHighPrice.Name = "txtHighPrice";
            this.txtHighPrice.Size = new System.Drawing.Size(72, 20);
            this.txtHighPrice.TabIndex = 48;
            // 
            // lblHighPrice
            // 
            this.lblHighPrice.Location = new System.Drawing.Point(8, 112);
            this.lblHighPrice.Name = "lblHighPrice";
            this.lblHighPrice.Size = new System.Drawing.Size(72, 16);
            this.lblHighPrice.TabIndex = 49;
            this.lblHighPrice.Text = "High Price:";
            this.lblHighPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLowPrice
            // 
            this.txtLowPrice.Enabled = false;
            this.txtLowPrice.Location = new System.Drawing.Point(88, 88);
            this.txtLowPrice.Name = "txtLowPrice";
            this.txtLowPrice.Size = new System.Drawing.Size(72, 20);
            this.txtLowPrice.TabIndex = 46;
            // 
            // lblLowPrice
            // 
            this.lblLowPrice.Location = new System.Drawing.Point(16, 88);
            this.lblLowPrice.Name = "lblLowPrice";
            this.lblLowPrice.Size = new System.Drawing.Size(64, 16);
            this.lblLowPrice.TabIndex = 47;
            this.lblLowPrice.Text = "Low Price:";
            this.lblLowPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboDeleteType
            // 
            this.cboDeleteType.Items.AddRange(new object[] {
            "Delete Last Order",
            "Delete All Orders",
            "Delete Range of Orders"});
            this.cboDeleteType.Location = new System.Drawing.Point(24, 24);
            this.cboDeleteType.Name = "cboDeleteType";
            this.cboDeleteType.Size = new System.Drawing.Size(136, 21);
            this.cboDeleteType.TabIndex = 45;
            this.cboDeleteType.Text = "Select Delete Type";
            this.cboDeleteType.SelectedIndexChanged += new System.EventHandler(this.deleteOrderComboBox_SelectedIndexChanged);
            // 
            // btnINvokeDelete
            // 
            this.btnINvokeDelete.Enabled = false;
            this.btnINvokeDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnINvokeDelete.Location = new System.Drawing.Point(88, 200);
            this.btnINvokeDelete.Name = "btnINvokeDelete";
            this.btnINvokeDelete.Size = new System.Drawing.Size(72, 23);
            this.btnINvokeDelete.TabIndex = 39;
            this.btnINvokeDelete.Text = "Invoke";
            this.btnINvokeDelete.Click += new System.EventHandler(this.InvokeDeleteButton_Click);
            // 
            // lblSiteOrderKey
            // 
            this.lblSiteOrderKey.Location = new System.Drawing.Point(8, 27);
            this.lblSiteOrderKey.Name = "lblSiteOrderKey";
            this.lblSiteOrderKey.Size = new System.Drawing.Size(80, 14);
            this.lblSiteOrderKey.TabIndex = 36;
            this.lblSiteOrderKey.Text = "SiteOrderKey:";
            this.lblSiteOrderKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSiteOrderKey
            // 
            this.txtSiteOrderKey.Location = new System.Drawing.Point(96, 24);
            this.txtSiteOrderKey.Name = "txtSiteOrderKey";
            this.txtSiteOrderKey.Size = new System.Drawing.Size(104, 20);
            this.txtSiteOrderKey.TabIndex = 35;
            // 
            // gboModifyOrder
            // 
            this.gboModifyOrder.Controls.Add(this.txtNewQuantity);
            this.gboModifyOrder.Controls.Add(this.lblNewQuantity);
            this.gboModifyOrder.Controls.Add(this.txtNewPrice);
            this.gboModifyOrder.Controls.Add(this.lblNewPrice);
            this.gboModifyOrder.Controls.Add(this.cboModifyType);
            this.gboModifyOrder.Controls.Add(this.btnInvokeModify);
            this.gboModifyOrder.Enabled = false;
            this.gboModifyOrder.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gboModifyOrder.Location = new System.Drawing.Point(8, 265);
            this.gboModifyOrder.Name = "gboModifyOrder";
            this.gboModifyOrder.Size = new System.Drawing.Size(216, 176);
            this.gboModifyOrder.TabIndex = 68;
            this.gboModifyOrder.TabStop = false;
            this.gboModifyOrder.Text = "Modify Order";
            // 
            // txtNewQuantity
            // 
            this.txtNewQuantity.Enabled = false;
            this.txtNewQuantity.Location = new System.Drawing.Point(120, 80);
            this.txtNewQuantity.Name = "txtNewQuantity";
            this.txtNewQuantity.Size = new System.Drawing.Size(72, 20);
            this.txtNewQuantity.TabIndex = 52;
            // 
            // lblNewQuantity
            // 
            this.lblNewQuantity.Location = new System.Drawing.Point(24, 80);
            this.lblNewQuantity.Name = "lblNewQuantity";
            this.lblNewQuantity.Size = new System.Drawing.Size(88, 16);
            this.lblNewQuantity.TabIndex = 53;
            this.lblNewQuantity.Text = "New Quantity:";
            this.lblNewQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNewPrice
            // 
            this.txtNewPrice.Enabled = false;
            this.txtNewPrice.Location = new System.Drawing.Point(120, 56);
            this.txtNewPrice.Name = "txtNewPrice";
            this.txtNewPrice.Size = new System.Drawing.Size(72, 20);
            this.txtNewPrice.TabIndex = 50;
            // 
            // lblNewPrice
            // 
            this.lblNewPrice.Location = new System.Drawing.Point(48, 56);
            this.lblNewPrice.Name = "lblNewPrice";
            this.lblNewPrice.Size = new System.Drawing.Size(64, 16);
            this.lblNewPrice.TabIndex = 51;
            this.lblNewPrice.Text = "New Price:";
            this.lblNewPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboModifyType
            // 
            this.cboModifyType.Items.AddRange(new object[] {
            "Change Last Order",
            "Cancel/Replace Last Order"});
            this.cboModifyType.Location = new System.Drawing.Point(24, 24);
            this.cboModifyType.Name = "cboModifyType";
            this.cboModifyType.Size = new System.Drawing.Size(168, 21);
            this.cboModifyType.TabIndex = 47;
            this.cboModifyType.Text = "Select Modify Type";
            this.cboModifyType.SelectedIndexChanged += new System.EventHandler(this.modifyTypeComboBox_SelectedIndexChanged);
            // 
            // btnInvokeModify
            // 
            this.btnInvokeModify.Enabled = false;
            this.btnInvokeModify.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnInvokeModify.Location = new System.Drawing.Point(120, 112);
            this.btnInvokeModify.Name = "btnInvokeModify";
            this.btnInvokeModify.Size = new System.Drawing.Size(72, 23);
            this.btnInvokeModify.TabIndex = 37;
            this.btnInvokeModify.Text = "Invoke";
            this.btnInvokeModify.Click += new System.EventHandler(this.InvokeModifyOrderButton_Click);
            // 
            // gboLastOrder
            // 
            this.gboLastOrder.Controls.Add(this.lblSiteOrderKey);
            this.gboLastOrder.Controls.Add(this.txtSiteOrderKey);
            this.gboLastOrder.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gboLastOrder.Location = new System.Drawing.Point(8, 201);
            this.gboLastOrder.Name = "gboLastOrder";
            this.gboLastOrder.Size = new System.Drawing.Size(216, 56);
            this.gboLastOrder.TabIndex = 69;
            this.gboLastOrder.TabStop = false;
            this.gboLastOrder.Text = "Last Order";
            // 
            // lblNotProduction
            // 
            this.lblNotProduction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotProduction.Location = new System.Drawing.Point(8, 34);
            this.lblNotProduction.Name = "lblNotProduction";
            this.lblNotProduction.Size = new System.Drawing.Size(408, 14);
            this.lblNotProduction.TabIndex = 71;
            this.lblNotProduction.Text = "This sample is NOT to be used in production or during conformance testing.";
            this.lblNotProduction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWarning
            // 
            this.lblWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarning.Location = new System.Drawing.Point(8, 9);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(408, 23);
            this.lblWarning.TabIndex = 70;
            this.lblWarning.Text = "WARNING!";
            this.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmModifyOrder
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(426, 474);
            this.Controls.Add(this.lblNotProduction);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.gboLastOrder);
            this.Controls.Add(this.gboDeleteOrder);
            this.Controls.Add(this.gboLimtOrderEntry);
            this.Controls.Add(this.gboInstrumentInfo);
            this.Controls.Add(this.sbaStatus);
            this.Controls.Add(this.gboModifyOrder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Menu = this.mainMenu1;
            this.Name = "frmModifyOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ModifyOrder";
            this.gboInstrumentInfo.ResumeLayout(false);
            this.gboInstrumentInfo.PerformLayout();
            this.gboLimtOrderEntry.ResumeLayout(false);
            this.gboLimtOrderEntry.PerformLayout();
            this.gboDeleteOrder.ResumeLayout(false);
            this.gboDeleteOrder.PerformLayout();
            this.gboModifyOrder.ResumeLayout(false);
            this.gboModifyOrder.PerformLayout();
            this.gboLastOrder.ResumeLayout(false);
            this.gboLastOrder.PerformLayout();
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
			Application.Run(new frmModifyOrder());
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

            // Obtain the available customer names and add them to the ComboBox.
            XTAPI.TTOrderProfileClass orderProfile = new XTAPI.TTOrderProfileClass();
            foreach (string entry in orderProfile.Customers as Array)
            {
                cboCustomer.Items.Add(entry);
            }
	
			// Set the first item in the customer combo boxes.
            cboCustomer.SelectedIndex = 0;

			// Set the Net Limits to false.
			m_TTOrderSet.Set("NetLimits",false);
			// Open the TTOrderSet with send orders enabled.
			m_TTOrderSet.Open(1);

			// Enable the user interface items.
			btnBuy.Enabled = true;
			btnSell.Enabled = true;	
			cboCustomer.Enabled = true;
			gboDeleteOrder.Enabled = true;
			gboModifyOrder.Enabled = true;
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
        /// TTOrderSet SendOrder method.  The SiteOrderKey from the order submission
        /// is saved internally and pushed to the UI.
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
                orderProfile.Set("Qty", txtQuantity.Text.ToString());
				// Set the order type to "L" for a limit order.
                orderProfile.Set("OrderType", "L");	
				// Set the limit order price.
                orderProfile.Set("Limit$", txtPrice.Text.ToString());

                // Send the order by submitting the TTOrderProfile through the TTOrderSet.
                int submittedQuantity = m_TTOrderSet.get_SendOrder(orderProfile);

				// Obtain the SiteOrderKey for the last order submitted.
                m_LastOrderSiteOrderKey = (string)orderProfile.get_GetLast("SiteOrderKey");

				// Print the SiteOrderKey to the user interface.
				txtSiteOrderKey.Text = m_LastOrderSiteOrderKey;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Exception");
			}
		}

        /// <summary>
        /// This function is called when the Invoke button in the Delete Order group is clicked.
        /// Three ways of deleting orders are demonstrated.
        /// </summary>
        /// <param name="sender">Object which fires the method</param>
        /// <param name="e">Event arguments of the callback</param>
		private void InvokeDeleteButton_Click(object sender, System.EventArgs e)
		{
			// Test if the TTOrderSet contains orders.
			if(m_TTOrderSet.Count <= 0)
			{
				MessageBox.Show(this, "There are no orders in the TTOrderSet to delete!");
				return;
			}

            // Record the quantity deleted for output to the user.
            int quantityDeleted = 0;

            switch (cboDeleteType.SelectedIndex)
            {
                ///////////////////////////
                // Delete the last order //
                ///////////////////////////
                case 0:
                    // Obtain the TTOrderObj of the last order using the saved SiteOrderKey.
                    XTAPI.TTOrderObj tempOrderObj = (XTAPI.TTOrderObj)m_TTOrderSet.get_SiteKeyLookup(m_LastOrderSiteOrderKey);

                    // Invoke the Delete order property.
                    quantityDeleted = tempOrderObj.Delete;

                    break;
                ///////////////////////
                // Delete all orders //
                ///////////////////////
                case 1:
                    // Delete all of the orders.
                    quantityDeleted = m_TTOrderSet.get_DeleteOrders(System.Type.Missing, null, null, 0, null);

                    break;
                //////////////////////////////
                // Delete a range of orders //
                //////////////////////////////
                case 2:
                    int buySell;
                    int inclusiveRange;
                    double lowTick;
                    double highTick;

                    // Obtain the tick price of the instrument.
                    double tickPrice = Convert.ToDouble(m_TTInstrObj.get_TickPrice(0, 1, "#"));
                    // Obtain the tick increment of the instrument.
                    int tickIncrement = (int)m_TTInstrObj.get_Get("TickIncrement");

                    // Calculate the lowTick and highTick based on the user input price value.
                    lowTick = Convert.ToDouble(m_TTInstrObj.get_TickPrice(txtLowPrice.Text, 0, "#")) / tickPrice * tickIncrement;
                    highTick = Convert.ToDouble(m_TTInstrObj.get_TickPrice(txtHighPrice.Text, 0, "#")) / tickPrice * tickIncrement;

                    // Determine whether Buy or Sell is selected.
                    if (cboSide.SelectedIndex == 1)
                        buySell = 0;	// sell
                    else
                        buySell = 1;	// buy

                    // Determine whether to include or exclude the range specified.
                    if (optIncludeRange.Checked)
                        inclusiveRange = 1;
                    else
                        inclusiveRange = 0;

                    // Delete the order(s) based on the user selected options.
                    // Note:  TTOrderSelector is not used in this example.
                    quantityDeleted = m_TTOrderSet.get_DeleteOrders(buySell, lowTick, highTick, inclusiveRange, null);

                    break;

                default:
                    break;
            }

            // show the number of deleted contracts to the user.
            MessageBox.Show(this, "Quanitity Deleted: " + quantityDeleted.ToString());
		}

        /// <summary>
        /// This function is called whenever the deleteOrder combo box is changed.  The appropriate 
        /// items are enabled or disabled.
        /// </summary>
        /// <param name="sender">Object which fires the method</param>
        /// <param name="e">Event arguments of the callback</param>
		private void deleteOrderComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            switch (cboDeleteType.SelectedIndex)
            {
                ///////////////////////////
                // Delete the last order //
                ///////////////////////////
                case 0:
                    cboSide.Enabled = false;
                    txtLowPrice.Enabled = false;
                    txtHighPrice.Enabled = false;
                    optIncludeRange.Enabled = false;
                    optExcludeRange.Enabled = false;
                    btnINvokeDelete.Enabled = true;

                    break;
                ///////////////////////
                // Delete all orders //
                ///////////////////////
                case 1:
                    cboSide.Enabled = false;
                    txtLowPrice.Enabled = false;
                    txtHighPrice.Enabled = false;
                    optIncludeRange.Enabled = false;
                    optExcludeRange.Enabled = false;
                    btnINvokeDelete.Enabled = true;

                    break;
                //////////////////////////////
                // Delete a range of orders //
                //////////////////////////////
                case 2:
                    cboSide.Enabled = true;
                    txtLowPrice.Enabled = true;
                    txtHighPrice.Enabled = true;
                    optIncludeRange.Enabled = true;
                    optExcludeRange.Enabled = true;
                    btnINvokeDelete.Enabled = true;

                    break;
                ///////////////////////////////////////
                // Unhandled (should never get here) //
                ///////////////////////////////////////
                default:
                    break;
            }
		}

        /// <summary>
        /// This function is called when the Invoke button in the Modify Order group is 
        /// clicked.  The order can be either Change or Cancel/Replace.
        /// </summary>
        /// <param name="sender">Object which fires the method</param>
        /// <param name="e">Event arguments of the callback</param>
		private void InvokeModifyOrderButton_Click(object sender, System.EventArgs e)
		{
			// Test if the TTOrderSet contains orders.
			if( m_TTOrderSet.Count <= 0 )
			{
				MessageBox.Show(this, "There are no orders in the TTOrderSet to modify!");
				return;
			}

			// Obtain the TTOrderObj of the last order using the saved SiteOrderKey.
			XTAPI.TTOrderObj tempOrderObj = (XTAPI.TTOrderObj) m_TTOrderSet.get_SiteKeyLookup(m_LastOrderSiteOrderKey);

			// Obtain the TTOrderProfile from the last order.
			XTAPI.TTOrderProfile tempOrderProfile = tempOrderObj.CreateOrderProfile;

			// Set the new price and quantity.
			tempOrderProfile.Set("Limit$",txtNewPrice.Text);
			tempOrderProfile.Set("Qty",txtNewQuantity.Text);
			
			// Update Order as change or cancel/replace (0 - change, 1 - cancel/replace).
			m_TTOrderSet.UpdateOrder(tempOrderProfile, cboModifyType.SelectedIndex);
		}

        /// <summary>
        /// This function is called when the modify type combo box is changed. The appropriate 
        /// items are enabled.
        /// </summary>
        /// <param name="sender">Object which fires the method</param>
        /// <param name="e">Event arguments of the callback</param>
		private void modifyTypeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtNewPrice.Enabled = true;
			txtNewQuantity.Enabled = true;
			btnInvokeModify.Enabled = true;
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
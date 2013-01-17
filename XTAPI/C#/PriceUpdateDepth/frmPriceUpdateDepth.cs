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

namespace XTAPI_Samples
{
	/// <summary>
    /// PriceUpdateDepth
    /// 
	/// This example demonstrates using the XTAPI to retrieve market depth data from a 
	/// single instrument.  The TTDropHandler object is used to resolve an instrument 
	/// dragged and dropped from the X_TRADER Market Grid.  Bid and ask depth size can 
	/// be selected as well as enabling or disabling depth updates.  The default level 
	/// is set to "0" which means that all available depth will be displayed.  
	/// 
    /// Note: The maximum level of depth can differ by exchange.
	/// </summary>
	public class frmPriceUpdateDepth : Form
	{
        // Declare the XTAPI objects.
		private XTAPI.TTDropHandlerClass m_TTDropHandler = null;
		private XTAPI.TTInstrNotifyClass m_TTInstrNotify = null;
		private XTAPI.TTInstrObj m_TTInstrObj = null;
		
        // Private class member variables
		private string m_bidDepthValue;
		private string m_askDepthValue;

        /// <summary>
        /// Upon the application form loading, the TTDropHandler and TTInstrNotify objects 
        /// are initialized, and the required events are subscribed.
        /// </summary>
		public frmPriceUpdateDepth()
		{
			// Required for Windows Form Designer support
			InitializeComponent();	

			// Instantiate the drag and drop handler class.					 
			m_TTDropHandler = new XTAPI.TTDropHandlerClass();
			
			// Register the active form for drag and drop.
			m_TTDropHandler.RegisterDropWindow((int) this.Handle);
			
			// Associate the drop and drag callback event.
			m_TTDropHandler.OnNotifyDrop += new XTAPI._ITTDropHandlerEvents_OnNotifyDropEventHandler(this.m_TTDropHandler_OnNotifyDrop);
			
			// Instantiate the instrument notification class
			m_TTInstrNotify = new XTAPI.TTInstrNotifyClass();
			
			// Setup the instrument notification call back functions
			m_TTInstrNotify.OnNotifyFound += new XTAPI._ITTInstrNotifyEvents_OnNotifyFoundEventHandler(this.m_TTInstrNotify_OnNotifyFound);
			m_TTInstrNotify.OnNotifyDepthData += new XTAPI._ITTInstrNotifyEvents_OnNotifyDepthDataEventHandler(pNotify_OnNotifyDepthData);		
			
			// Enable the depth updates.
			m_TTInstrNotify.EnableDepthUpdates = 1;

			// Set the Depth levels to "0" which will return all available depth.
			m_bidDepthValue = "BidDepth(0)";
			m_askDepthValue = "AskDepth(0)";
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
        private System.Windows.Forms.Label lblExchange;
        private System.Windows.Forms.Label lblAskDepth;
        private System.Windows.Forms.Label lblBidDepth;
        private System.Windows.Forms.Label lblNotProduction;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.StatusBar sbaStatus;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.TextBox txtExchange;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.TextBox txtProductType;
        private System.Windows.Forms.TextBox txtContract;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblProductType;
        private System.Windows.Forms.Label lblContract;
        private System.Windows.Forms.GroupBox gboInstrumentInfo;
        private System.Windows.Forms.GroupBox gboInstrumentDepthData;
        private System.Windows.Forms.GroupBox gboInstrumentDepthOptions;
        private System.Windows.Forms.CheckBox chkEnableDepth;
        private System.Windows.Forms.Label lvlLevelsBidDepth;
        private System.Windows.Forms.ComboBox cboLevelsBidDepth;
        private System.Windows.Forms.Label lblLevelsAskDepth;
        private System.Windows.Forms.ComboBox cboLevelsAskDepth;
        private System.Windows.Forms.ListBox lboBidDepth;
        private System.Windows.Forms.ListBox lboAskDepth;
        private System.Windows.Forms.MenuItem mnuAbout;

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.lblExchange = new System.Windows.Forms.Label();
            this.lboBidDepth = new System.Windows.Forms.ListBox();
            this.lboAskDepth = new System.Windows.Forms.ListBox();
            this.lblAskDepth = new System.Windows.Forms.Label();
            this.lblBidDepth = new System.Windows.Forms.Label();
            this.sbaStatus = new System.Windows.Forms.StatusBar();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.mnuAbout = new System.Windows.Forms.MenuItem();
            this.txtExchange = new System.Windows.Forms.TextBox();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.txtProductType = new System.Windows.Forms.TextBox();
            this.txtContract = new System.Windows.Forms.TextBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblProductType = new System.Windows.Forms.Label();
            this.lblContract = new System.Windows.Forms.Label();
            this.gboInstrumentInfo = new System.Windows.Forms.GroupBox();
            this.gboInstrumentDepthData = new System.Windows.Forms.GroupBox();
            this.gboInstrumentDepthOptions = new System.Windows.Forms.GroupBox();
            this.lblLevelsAskDepth = new System.Windows.Forms.Label();
            this.cboLevelsAskDepth = new System.Windows.Forms.ComboBox();
            this.lvlLevelsBidDepth = new System.Windows.Forms.Label();
            this.cboLevelsBidDepth = new System.Windows.Forms.ComboBox();
            this.chkEnableDepth = new System.Windows.Forms.CheckBox();
            this.lblNotProduction = new System.Windows.Forms.Label();
            this.lblWarning = new System.Windows.Forms.Label();
            this.gboInstrumentInfo.SuspendLayout();
            this.gboInstrumentDepthData.SuspendLayout();
            this.gboInstrumentDepthOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblExchange
            // 
            this.lblExchange.Location = new System.Drawing.Point(16, 24);
            this.lblExchange.Name = "lblExchange";
            this.lblExchange.Size = new System.Drawing.Size(72, 16);
            this.lblExchange.TabIndex = 14;
            this.lblExchange.Text = "Exchange:";
            this.lblExchange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lboBidDepth
            // 
            this.lboBidDepth.Location = new System.Drawing.Point(16, 40);
            this.lboBidDepth.Name = "lboBidDepth";
            this.lboBidDepth.Size = new System.Drawing.Size(184, 212);
            this.lboBidDepth.TabIndex = 95;
            // 
            // lboAskDepth
            // 
            this.lboAskDepth.Location = new System.Drawing.Point(208, 40);
            this.lboAskDepth.Name = "lboAskDepth";
            this.lboAskDepth.Size = new System.Drawing.Size(184, 212);
            this.lboAskDepth.TabIndex = 96;
            // 
            // lblAskDepth
            // 
            this.lblAskDepth.Location = new System.Drawing.Point(208, 24);
            this.lblAskDepth.Name = "lblAskDepth";
            this.lblAskDepth.Size = new System.Drawing.Size(96, 16);
            this.lblAskDepth.TabIndex = 97;
            this.lblAskDepth.Text = "AskDepth:";
            // 
            // lblBidDepth
            // 
            this.lblBidDepth.Location = new System.Drawing.Point(16, 24);
            this.lblBidDepth.Name = "lblBidDepth";
            this.lblBidDepth.Size = new System.Drawing.Size(96, 16);
            this.lblBidDepth.TabIndex = 98;
            this.lblBidDepth.Text = "BidDepth:";
            // 
            // sbaStatus
            // 
            this.sbaStatus.Location = new System.Drawing.Point(0, 325);
            this.sbaStatus.Name = "sbaStatus";
            this.sbaStatus.Size = new System.Drawing.Size(650, 22);
            this.sbaStatus.SizingGrip = false;
            this.sbaStatus.TabIndex = 99;
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
            // txtExchange
            // 
            this.txtExchange.Location = new System.Drawing.Point(96, 24);
            this.txtExchange.Name = "txtExchange";
            this.txtExchange.Size = new System.Drawing.Size(100, 20);
            this.txtExchange.TabIndex = 100;
            // 
            // txtProduct
            // 
            this.txtProduct.Location = new System.Drawing.Point(96, 48);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(100, 20);
            this.txtProduct.TabIndex = 101;
            // 
            // txtProductType
            // 
            this.txtProductType.Location = new System.Drawing.Point(96, 72);
            this.txtProductType.Name = "txtProductType";
            this.txtProductType.Size = new System.Drawing.Size(100, 20);
            this.txtProductType.TabIndex = 102;
            // 
            // txtContract
            // 
            this.txtContract.Location = new System.Drawing.Point(96, 96);
            this.txtContract.Name = "txtContract";
            this.txtContract.Size = new System.Drawing.Size(100, 20);
            this.txtContract.TabIndex = 103;
            // 
            // lblProduct
            // 
            this.lblProduct.Location = new System.Drawing.Point(16, 48);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(72, 16);
            this.lblProduct.TabIndex = 104;
            this.lblProduct.Text = "Product:";
            this.lblProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProductType
            // 
            this.lblProductType.Location = new System.Drawing.Point(8, 72);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(80, 16);
            this.lblProductType.TabIndex = 105;
            this.lblProductType.Text = "Product Type:";
            this.lblProductType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblContract
            // 
            this.lblContract.Location = new System.Drawing.Point(16, 96);
            this.lblContract.Name = "lblContract";
            this.lblContract.Size = new System.Drawing.Size(72, 16);
            this.lblContract.TabIndex = 106;
            this.lblContract.Text = "Contract:";
            this.lblContract.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gboInstrumentInfo
            // 
            this.gboInstrumentInfo.Controls.Add(this.txtExchange);
            this.gboInstrumentInfo.Controls.Add(this.txtContract);
            this.gboInstrumentInfo.Controls.Add(this.lblProductType);
            this.gboInstrumentInfo.Controls.Add(this.lblExchange);
            this.gboInstrumentInfo.Controls.Add(this.lblContract);
            this.gboInstrumentInfo.Controls.Add(this.lblProduct);
            this.gboInstrumentInfo.Controls.Add(this.txtProduct);
            this.gboInstrumentInfo.Controls.Add(this.txtProductType);
            this.gboInstrumentInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gboInstrumentInfo.Location = new System.Drawing.Point(9, 53);
            this.gboInstrumentInfo.Name = "gboInstrumentInfo";
            this.gboInstrumentInfo.Size = new System.Drawing.Size(216, 136);
            this.gboInstrumentInfo.TabIndex = 107;
            this.gboInstrumentInfo.TabStop = false;
            this.gboInstrumentInfo.Text = "Instrument Information";
            // 
            // gboInstrumentDepthData
            // 
            this.gboInstrumentDepthData.Controls.Add(this.lboBidDepth);
            this.gboInstrumentDepthData.Controls.Add(this.lboAskDepth);
            this.gboInstrumentDepthData.Controls.Add(this.lblAskDepth);
            this.gboInstrumentDepthData.Controls.Add(this.lblBidDepth);
            this.gboInstrumentDepthData.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gboInstrumentDepthData.Location = new System.Drawing.Point(233, 53);
            this.gboInstrumentDepthData.Name = "gboInstrumentDepthData";
            this.gboInstrumentDepthData.Size = new System.Drawing.Size(408, 264);
            this.gboInstrumentDepthData.TabIndex = 108;
            this.gboInstrumentDepthData.TabStop = false;
            this.gboInstrumentDepthData.Text = "Instrument Depth Data";
            // 
            // gboInstrumentDepthOptions
            // 
            this.gboInstrumentDepthOptions.Controls.Add(this.lblLevelsAskDepth);
            this.gboInstrumentDepthOptions.Controls.Add(this.cboLevelsAskDepth);
            this.gboInstrumentDepthOptions.Controls.Add(this.lvlLevelsBidDepth);
            this.gboInstrumentDepthOptions.Controls.Add(this.cboLevelsBidDepth);
            this.gboInstrumentDepthOptions.Controls.Add(this.chkEnableDepth);
            this.gboInstrumentDepthOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gboInstrumentDepthOptions.Location = new System.Drawing.Point(9, 197);
            this.gboInstrumentDepthOptions.Name = "gboInstrumentDepthOptions";
            this.gboInstrumentDepthOptions.Size = new System.Drawing.Size(216, 120);
            this.gboInstrumentDepthOptions.TabIndex = 109;
            this.gboInstrumentDepthOptions.TabStop = false;
            this.gboInstrumentDepthOptions.Text = "Instrument Depth Options";
            // 
            // lblLevelsAskDepth
            // 
            this.lblLevelsAskDepth.Location = new System.Drawing.Point(80, 58);
            this.lblLevelsAskDepth.Name = "lblLevelsAskDepth";
            this.lblLevelsAskDepth.Size = new System.Drawing.Size(120, 16);
            this.lblLevelsAskDepth.TabIndex = 109;
            this.lblLevelsAskDepth.Text = "Levels of Ask Depth";
            this.lblLevelsAskDepth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboLevelsAskDepth
            // 
            this.cboLevelsAskDepth.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cboLevelsAskDepth.Location = new System.Drawing.Point(32, 56);
            this.cboLevelsAskDepth.Name = "cboLevelsAskDepth";
            this.cboLevelsAskDepth.Size = new System.Drawing.Size(40, 21);
            this.cboLevelsAskDepth.TabIndex = 108;
            this.cboLevelsAskDepth.Text = "0";
            this.cboLevelsAskDepth.SelectedIndexChanged += new System.EventHandler(this.askDepthComboBox_SelectedIndexChanged);
            // 
            // lvlLevelsBidDepth
            // 
            this.lvlLevelsBidDepth.Location = new System.Drawing.Point(80, 32);
            this.lvlLevelsBidDepth.Name = "lvlLevelsBidDepth";
            this.lvlLevelsBidDepth.Size = new System.Drawing.Size(128, 16);
            this.lvlLevelsBidDepth.TabIndex = 107;
            this.lvlLevelsBidDepth.Text = "Levels of Bid Depth";
            this.lvlLevelsBidDepth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboLevelsBidDepth
            // 
            this.cboLevelsBidDepth.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cboLevelsBidDepth.Location = new System.Drawing.Point(32, 30);
            this.cboLevelsBidDepth.Name = "cboLevelsBidDepth";
            this.cboLevelsBidDepth.Size = new System.Drawing.Size(40, 21);
            this.cboLevelsBidDepth.TabIndex = 1;
            this.cboLevelsBidDepth.Text = "0";
            this.cboLevelsBidDepth.SelectedIndexChanged += new System.EventHandler(this.bidDepthComboBox_SelectedIndexChanged);
            // 
            // chkEnableDepth
            // 
            this.chkEnableDepth.Checked = true;
            this.chkEnableDepth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnableDepth.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkEnableDepth.Location = new System.Drawing.Point(32, 88);
            this.chkEnableDepth.Name = "chkEnableDepth";
            this.chkEnableDepth.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkEnableDepth.Size = new System.Drawing.Size(88, 24);
            this.chkEnableDepth.TabIndex = 0;
            this.chkEnableDepth.Text = "Enable Depth";
            this.chkEnableDepth.CheckedChanged += new System.EventHandler(this.enableDepthCheckBox_CheckedChanged);
            // 
            // lblNotProduction
            // 
            this.lblNotProduction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotProduction.Location = new System.Drawing.Point(12, 34);
            this.lblNotProduction.Name = "lblNotProduction";
            this.lblNotProduction.Size = new System.Drawing.Size(629, 14);
            this.lblNotProduction.TabIndex = 111;
            this.lblNotProduction.Text = "This sample is NOT to be used in production or during conformance testing.";
            this.lblNotProduction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWarning
            // 
            this.lblWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarning.Location = new System.Drawing.Point(12, 9);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(629, 23);
            this.lblWarning.TabIndex = 110;
            this.lblWarning.Text = "WARNING!";
            this.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmPriceUpdateDepth
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(650, 347);
            this.Controls.Add(this.lblNotProduction);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.gboInstrumentDepthOptions);
            this.Controls.Add(this.gboInstrumentDepthData);
            this.Controls.Add(this.gboInstrumentInfo);
            this.Controls.Add(this.sbaStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Menu = this.mainMenu1;
            this.Name = "frmPriceUpdateDepth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PriceUpdateDepth";
            this.gboInstrumentInfo.ResumeLayout(false);
            this.gboInstrumentInfo.PerformLayout();
            this.gboInstrumentDepthData.ResumeLayout(false);
            this.gboInstrumentDepthOptions.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		/// 
		[STAThread]
		static void Main() 
		{
			// Enable Visual Styles for XP Look and Feel.
			Application.EnableVisualStyles();
			Application.Run(new frmPriceUpdateDepth());
		}

        /// <summary>
        /// This function is called when an instrument is
        /// dragged and dropped from the Market Grid in X_TRADER.
        /// </summary>
		private void m_TTDropHandler_OnNotifyDrop()
		{	
			// Update the Status Bar text.
			sbaStatus.Text = "Drag & Drop detected.  Initializing instrument...";

			try
			{	
				// Test if a TTInstrObj currently exists.
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
				m_TTInstrObj.Open(1);	// enable Market Depth:  1 - true, 0 - false
				
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
			// The use of a tilde before the property name will return the delta (current - previous).
			Array data = (Array) pInstr.get_Get("Exchange,Product,ProdType,Contract");

			txtExchange.Text = (string)data.GetValue(0);
			txtProduct.Text = (string)data.GetValue(1);
			txtProductType.Text = (string)data.GetValue(2);
			txtContract.Text = (string)data.GetValue(3);
		}

        /// <summary>
        /// This function displays is called for every change to the instrument depth.
        /// </summary>
        /// <param name="pNotify">TTInstrNotify object</param>
        /// <param name="pInstr">TTInstrObj object</param>
		private void pNotify_OnNotifyDepthData(XTAPI.TTInstrNotify pNotify, XTAPI.TTInstrObj pInstr)
		{
			// Clear the depth list boxes.
			lboBidDepth.Items.Clear();
			lboAskDepth.Items.Clear();				
			
			// Obtain the bid depth (Level based on user selection).
            Array dataArrayBid = (Array)pInstr.get_Get(m_bidDepthValue);

			// Test if depth exists.
			if (dataArrayBid != null)
			{
				// Iterate through the depth array.
				for (int i = 0; i <= dataArrayBid.GetUpperBound(0); i++)		
				{	
					// Break out of FOR LOOP if index value is null.
					if (dataArrayBid.GetValue(i,0) == null)	
						break;

					// Update the bid depth list box.
					lboBidDepth.Items.Add("BidPrice: " + dataArrayBid.GetValue(i,0) + 
                                          " | " +
						                  " BidQty: " + dataArrayBid.GetValue(i,1));
				}
			}

			// Obtain the ask depth (Level based on user selection).
			Array dataArrayAsk = (Array) pInstr.get_Get(m_askDepthValue);
			
			// Test if depth exists.
			if (dataArrayAsk != null)
			{
				// Iterate through the depth array.
				for (int i = 0; i <= dataArrayAsk.GetUpperBound(0); i++)
				{
					// Break out of FOR LOOP if index value is null.
					if (dataArrayAsk.GetValue(i,0) == null)	
						break;

					// Update the bid depth list box.
					lboAskDepth.Items.Add(" AskPrice: " + dataArrayAsk.GetValue(i,0) + 
                                          " | " +
						                  " AskQty: " + dataArrayAsk.GetValue(i,1));
				}
			}
		}

        /// <summary>
        /// TThis function enables or disables the Depth Updates based on user selection.
        /// </summary>
        /// <param name="sender">Object which fires the method</param>
        /// <param name="e">Event arguments of the callback</param>
		private void enableDepthCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			// Determine check box state.
			if( chkEnableDepth.Checked )
			{
				// Enable depth if check box is checked.
				m_TTInstrNotify.EnableDepthUpdates = 1;
			}
			else
			{
				// Disable depth if check box is unchecked.
				m_TTInstrNotify.EnableDepthUpdates = 0;
	
				// Clear Bid and Ask list boxes.
				lboBidDepth.Items.Clear();
				lboAskDepth.Items.Clear();
			}
		}

        /// <summary>
        /// This function constructs the TTInstrObj BidDepth() property based on the 
        /// user selected bid depth.
        /// </summary>
        /// <param name="sender">Object which fires the method</param>
        /// <param name="e">Event arguments of the callback</param>
		private void bidDepthComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Construct the TTInstrObj BidDepth() property.
			// example: "BidDepth(3)"
			m_bidDepthValue = "BidDepth(" + cboLevelsBidDepth.SelectedItem.ToString() + ")";
		}

        /// <summary>
        /// This function constructs the TTInstrObj AskDepth() property based on the 
        /// user selected ask depth.
        /// </summary>
        /// <param name="sender">Object which fires the method</param>
        /// <param name="e">Event arguments of the callback</param>
		private void askDepthComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Construct the TTInstrObj AskDepth() property.
			// example: "AskDepth(3)"
			m_askDepthValue = "AskDepth(" + cboLevelsAskDepth.SelectedItem.ToString() + ")";
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

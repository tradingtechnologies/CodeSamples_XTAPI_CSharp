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
    /// PriceUpdateManual
    /// 
	/// This example demonstrates using the XTAPI to retrieve market data from a single 
    /// instrument by manually specifying the contract parameters.
	/// </summary>
	public class frmPriceUpdateManual : Form
    {
        // Declare the XTAPI objects.
		private XTAPI.TTInstrObj m_TTInstrObj = null;
		private XTAPI.TTInstrNotifyClass m_TTInstrNotify = null;

        /// <summary>
        /// Upon the application form loading, the TTInstrNotify object is initialized,
        /// and the required events are subscribed.
        /// </summary>
		public frmPriceUpdateManual()
		{
			// Required for Windows Form Designer support
			InitializeComponent();	
			
			// Instantiate the instrument notification class.
			m_TTInstrNotify = new XTAPI.TTInstrNotifyClass();
			
			// Setup the instrument notification call back functions.
			m_TTInstrNotify.OnNotifyFound += new XTAPI._ITTInstrNotifyEvents_OnNotifyFoundEventHandler(this.m_TTInstrNotify_OnNotifyFound);
			m_TTInstrNotify.OnNotifyUpdate += new XTAPI._ITTInstrNotifyEvents_OnNotifyUpdateEventHandler(this.m_TTInstrNotify_OnNotifyUpdate);
            m_TTInstrNotify.OnNotifyNotFound += new XTAPI._ITTInstrNotifyEvents_OnNotifyNotFoundEventHandler(m_TTInstrNotify_OnNotifyNotFound);
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
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblProductType;
        private System.Windows.Forms.Label lblContract;
        private System.Windows.Forms.Label lblBidPrice;
        private System.Windows.Forms.Label lblBidQty;
        private System.Windows.Forms.Label lblAskPrice;
        private System.Windows.Forms.Label lblAskQty;
        private System.Windows.Forms.Label lblLastPrice;
        private System.Windows.Forms.Label lblLastQty;
        private System.Windows.Forms.GroupBox gboInstrumentInfo;
        private System.Windows.Forms.GroupBox gboInstrumentMarketData;
        private System.Windows.Forms.StatusBar sbaStatus;
        private System.Windows.Forms.Label lblLastQtyDelta;
        private System.Windows.Forms.Label lblNotProduction;
        private System.Windows.Forms.Label lblAbout;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtExchange;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.TextBox txtProductType;
        private System.Windows.Forms.TextBox txtContract;
        private System.Windows.Forms.TextBox txtBidPrice;
        private System.Windows.Forms.TextBox txtBidQty;
        private System.Windows.Forms.TextBox txtAskPrice;
        private System.Windows.Forms.TextBox txtAskQty;
        private System.Windows.Forms.TextBox txtLastPrice;
        private System.Windows.Forms.TextBox txtLastQty;
        private System.Windows.Forms.TextBox txtLastQtyDelta;
        private System.Windows.Forms.MenuItem mnuAbout;

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.txtExchange = new System.Windows.Forms.TextBox();
            this.lblExchange = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.lblProductType = new System.Windows.Forms.Label();
            this.txtProductType = new System.Windows.Forms.TextBox();
            this.lblContract = new System.Windows.Forms.Label();
            this.txtContract = new System.Windows.Forms.TextBox();
            this.lblBidPrice = new System.Windows.Forms.Label();
            this.txtBidPrice = new System.Windows.Forms.TextBox();
            this.lblBidQty = new System.Windows.Forms.Label();
            this.txtBidQty = new System.Windows.Forms.TextBox();
            this.lblAskPrice = new System.Windows.Forms.Label();
            this.txtAskPrice = new System.Windows.Forms.TextBox();
            this.lblAskQty = new System.Windows.Forms.Label();
            this.txtAskQty = new System.Windows.Forms.TextBox();
            this.lblLastPrice = new System.Windows.Forms.Label();
            this.txtLastPrice = new System.Windows.Forms.TextBox();
            this.lblLastQty = new System.Windows.Forms.Label();
            this.txtLastQty = new System.Windows.Forms.TextBox();
            this.gboInstrumentInfo = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.gboInstrumentMarketData = new System.Windows.Forms.GroupBox();
            this.lblLastQtyDelta = new System.Windows.Forms.Label();
            this.txtLastQtyDelta = new System.Windows.Forms.TextBox();
            this.sbaStatus = new System.Windows.Forms.StatusBar();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.mnuAbout = new System.Windows.Forms.MenuItem();
            this.lblNotProduction = new System.Windows.Forms.Label();
            this.lblAbout = new System.Windows.Forms.Label();
            this.gboInstrumentInfo.SuspendLayout();
            this.gboInstrumentMarketData.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtExchange
            // 
            this.txtExchange.Location = new System.Drawing.Point(96, 24);
            this.txtExchange.Name = "txtExchange";
            this.txtExchange.Size = new System.Drawing.Size(100, 20);
            this.txtExchange.TabIndex = 33;
            this.txtExchange.Text = "CME";
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
            // lblProduct
            // 
            this.lblProduct.Location = new System.Drawing.Point(40, 48);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(48, 16);
            this.lblProduct.TabIndex = 36;
            this.lblProduct.Text = "Product:";
            this.lblProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProduct
            // 
            this.txtProduct.Location = new System.Drawing.Point(96, 48);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(100, 20);
            this.txtProduct.TabIndex = 35;
            this.txtProduct.Text = "ES";
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
            // txtProductType
            // 
            this.txtProductType.Location = new System.Drawing.Point(96, 72);
            this.txtProductType.Name = "txtProductType";
            this.txtProductType.Size = new System.Drawing.Size(100, 20);
            this.txtProductType.TabIndex = 37;
            this.txtProductType.Text = "FUTURE";
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
            // txtContract
            // 
            this.txtContract.Location = new System.Drawing.Point(96, 96);
            this.txtContract.Name = "txtContract";
            this.txtContract.Size = new System.Drawing.Size(100, 20);
            this.txtContract.TabIndex = 39;
            this.txtContract.Text = "Mar13";
            // 
            // lblBidPrice
            // 
            this.lblBidPrice.Location = new System.Drawing.Point(16, 24);
            this.lblBidPrice.Name = "lblBidPrice";
            this.lblBidPrice.Size = new System.Drawing.Size(96, 16);
            this.lblBidPrice.TabIndex = 42;
            this.lblBidPrice.Text = "Bid Price:";
            this.lblBidPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBidPrice
            // 
            this.txtBidPrice.Location = new System.Drawing.Point(120, 24);
            this.txtBidPrice.Name = "txtBidPrice";
            this.txtBidPrice.Size = new System.Drawing.Size(72, 20);
            this.txtBidPrice.TabIndex = 41;
            // 
            // lblBidQty
            // 
            this.lblBidQty.Location = new System.Drawing.Point(16, 48);
            this.lblBidQty.Name = "lblBidQty";
            this.lblBidQty.Size = new System.Drawing.Size(96, 16);
            this.lblBidQty.TabIndex = 44;
            this.lblBidQty.Text = "Bid Qty:";
            this.lblBidQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBidQty
            // 
            this.txtBidQty.Location = new System.Drawing.Point(120, 48);
            this.txtBidQty.Name = "txtBidQty";
            this.txtBidQty.Size = new System.Drawing.Size(72, 20);
            this.txtBidQty.TabIndex = 43;
            // 
            // lblAskPrice
            // 
            this.lblAskPrice.Location = new System.Drawing.Point(16, 72);
            this.lblAskPrice.Name = "lblAskPrice";
            this.lblAskPrice.Size = new System.Drawing.Size(96, 16);
            this.lblAskPrice.TabIndex = 46;
            this.lblAskPrice.Text = "Ask Price:";
            this.lblAskPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAskPrice
            // 
            this.txtAskPrice.Location = new System.Drawing.Point(120, 72);
            this.txtAskPrice.Name = "txtAskPrice";
            this.txtAskPrice.Size = new System.Drawing.Size(72, 20);
            this.txtAskPrice.TabIndex = 45;
            // 
            // lblAskQty
            // 
            this.lblAskQty.Location = new System.Drawing.Point(16, 96);
            this.lblAskQty.Name = "lblAskQty";
            this.lblAskQty.Size = new System.Drawing.Size(96, 16);
            this.lblAskQty.TabIndex = 48;
            this.lblAskQty.Text = "Ask Qty:";
            this.lblAskQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAskQty
            // 
            this.txtAskQty.Location = new System.Drawing.Point(120, 96);
            this.txtAskQty.Name = "txtAskQty";
            this.txtAskQty.Size = new System.Drawing.Size(72, 20);
            this.txtAskQty.TabIndex = 47;
            // 
            // lblLastPrice
            // 
            this.lblLastPrice.Location = new System.Drawing.Point(16, 120);
            this.lblLastPrice.Name = "lblLastPrice";
            this.lblLastPrice.Size = new System.Drawing.Size(96, 16);
            this.lblLastPrice.TabIndex = 50;
            this.lblLastPrice.Text = "Last Price:";
            this.lblLastPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLastPrice
            // 
            this.txtLastPrice.Location = new System.Drawing.Point(120, 120);
            this.txtLastPrice.Name = "txtLastPrice";
            this.txtLastPrice.Size = new System.Drawing.Size(72, 20);
            this.txtLastPrice.TabIndex = 49;
            // 
            // lblLastQty
            // 
            this.lblLastQty.Location = new System.Drawing.Point(16, 144);
            this.lblLastQty.Name = "lblLastQty";
            this.lblLastQty.Size = new System.Drawing.Size(96, 16);
            this.lblLastQty.TabIndex = 52;
            this.lblLastQty.Text = "Last Qty:";
            this.lblLastQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLastQty
            // 
            this.txtLastQty.Location = new System.Drawing.Point(120, 144);
            this.txtLastQty.Name = "txtLastQty";
            this.txtLastQty.Size = new System.Drawing.Size(72, 20);
            this.txtLastQty.TabIndex = 51;
            // 
            // gboInstrumentInfo
            // 
            this.gboInstrumentInfo.Controls.Add(this.btnConnect);
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
            this.gboInstrumentInfo.Size = new System.Drawing.Size(216, 168);
            this.gboInstrumentInfo.TabIndex = 53;
            this.gboInstrumentInfo.TabStop = false;
            this.gboInstrumentInfo.Text = "Instrument Information";
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.SystemColors.Control;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnConnect.Location = new System.Drawing.Point(121, 122);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 41;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // gboInstrumentMarketData
            // 
            this.gboInstrumentMarketData.Controls.Add(this.lblLastQtyDelta);
            this.gboInstrumentMarketData.Controls.Add(this.txtLastQtyDelta);
            this.gboInstrumentMarketData.Controls.Add(this.lblAskPrice);
            this.gboInstrumentMarketData.Controls.Add(this.txtAskPrice);
            this.gboInstrumentMarketData.Controls.Add(this.txtBidPrice);
            this.gboInstrumentMarketData.Controls.Add(this.lblLastQty);
            this.gboInstrumentMarketData.Controls.Add(this.txtLastQty);
            this.gboInstrumentMarketData.Controls.Add(this.lblBidPrice);
            this.gboInstrumentMarketData.Controls.Add(this.lblAskQty);
            this.gboInstrumentMarketData.Controls.Add(this.txtAskQty);
            this.gboInstrumentMarketData.Controls.Add(this.lblLastPrice);
            this.gboInstrumentMarketData.Controls.Add(this.lblBidQty);
            this.gboInstrumentMarketData.Controls.Add(this.txtBidQty);
            this.gboInstrumentMarketData.Controls.Add(this.txtLastPrice);
            this.gboInstrumentMarketData.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gboInstrumentMarketData.Location = new System.Drawing.Point(232, 53);
            this.gboInstrumentMarketData.Name = "gboInstrumentMarketData";
            this.gboInstrumentMarketData.Size = new System.Drawing.Size(208, 200);
            this.gboInstrumentMarketData.TabIndex = 54;
            this.gboInstrumentMarketData.TabStop = false;
            this.gboInstrumentMarketData.Text = "Instrument Market Data";
            // 
            // lblLastQtyDelta
            // 
            this.lblLastQtyDelta.Location = new System.Drawing.Point(16, 168);
            this.lblLastQtyDelta.Name = "lblLastQtyDelta";
            this.lblLastQtyDelta.Size = new System.Drawing.Size(96, 16);
            this.lblLastQtyDelta.TabIndex = 54;
            this.lblLastQtyDelta.Text = "Last Qty (delta):";
            this.lblLastQtyDelta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLastQtyDelta
            // 
            this.txtLastQtyDelta.Location = new System.Drawing.Point(120, 168);
            this.txtLastQtyDelta.Name = "txtLastQtyDelta";
            this.txtLastQtyDelta.Size = new System.Drawing.Size(72, 20);
            this.txtLastQtyDelta.TabIndex = 53;
            // 
            // sbaStatus
            // 
            this.sbaStatus.Location = new System.Drawing.Point(0, 262);
            this.sbaStatus.Name = "sbaStatus";
            this.sbaStatus.Size = new System.Drawing.Size(448, 22);
            this.sbaStatus.SizingGrip = false;
            this.sbaStatus.TabIndex = 55;
            this.sbaStatus.Text = "Complete the Instrument Information and click the Connect button.";
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
            // lblNotProduction
            // 
            this.lblNotProduction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotProduction.Location = new System.Drawing.Point(12, 32);
            this.lblNotProduction.Name = "lblNotProduction";
            this.lblNotProduction.Size = new System.Drawing.Size(424, 14);
            this.lblNotProduction.TabIndex = 78;
            this.lblNotProduction.Text = "This sample is NOT to be used in production or during conformance testing.";
            this.lblNotProduction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAbout
            // 
            this.lblAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbout.Location = new System.Drawing.Point(12, 7);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(424, 23);
            this.lblAbout.TabIndex = 77;
            this.lblAbout.Text = "WARNING!";
            this.lblAbout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmPriceUpdateManualConnection
            // 
            this.AcceptButton = this.btnConnect;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(448, 284);
            this.Controls.Add(this.lblNotProduction);
            this.Controls.Add(this.lblAbout);
            this.Controls.Add(this.sbaStatus);
            this.Controls.Add(this.gboInstrumentMarketData);
            this.Controls.Add(this.gboInstrumentInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Menu = this.mainMenu1;
            this.Name = "frmPriceUpdateManualConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PriceUpdateManual";
            this.gboInstrumentInfo.ResumeLayout(false);
            this.gboInstrumentInfo.PerformLayout();
            this.gboInstrumentMarketData.ResumeLayout(false);
            this.gboInstrumentMarketData.PerformLayout();
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
			Application.Run(new frmPriceUpdateManual());
		}

        /// <summary>
        /// Connect to the instruments
        /// </summary>
        /// <param name="sender">Object which fires the method</param>
        /// <param name="e">Event arguments of the callback</param>
		private void connectButton_Click(object sender, System.EventArgs e)
		{
			// Update the Status Bar text.
			sbaStatus.Text = "Connecting to Instrument...";
			
			try
			{
				if (m_TTInstrObj != null)	
				{
					// Detach previously attached instrument.
					m_TTInstrNotify.DetachInstrument(m_TTInstrObj);
					m_TTInstrObj = null;
				}

				// Instantiate a new instrument object.
				m_TTInstrObj = new XTAPI.TTInstrObjClass();

				// Obtain the instrument information from the user input.
				m_TTInstrObj.Exchange = txtExchange.Text;
				m_TTInstrObj.Product = txtProduct.Text;
				m_TTInstrObj.ProdType = txtProductType.Text;
				m_TTInstrObj.Contract = txtContract.Text;

				// Attach the TTInstrObj to the TTInstrNotify for price update events.
				m_TTInstrNotify.AttachInstrument(m_TTInstrObj);
				
				// Open the TTInstrObj.
				m_TTInstrObj.Open(0);	// enable Market Depth:  1 - true, 0 - false
			}
			catch (Exception ex)
			{
				// Display exception message.
				MessageBox.Show(ex.Message, "Exception");
			}
		}

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
            //
            // Notes:
            //  1) The tilde (~) prefix returns the last change, or delta (delta = current - previous), in the attribute.
			Array data = (Array) pInstr.get_Get("Exchange,Product,ProdType,Contract,Bid$,BidQty$,Ask$,AskQty$,Last$,LastQty$,~LastQty$");

			txtExchange.Text = (string)data.GetValue(0);
			txtProduct.Text = (string)data.GetValue(1);
			txtProductType.Text = (string)data.GetValue(2);
			txtContract.Text = (string)data.GetValue(3);

            txtBidPrice.Text = (string)data.GetValue(4);
			txtBidQty.Text = (string)data.GetValue(5);
			txtAskPrice.Text = (string)data.GetValue(6);
			txtAskQty.Text = (string)data.GetValue(7);
			txtLastPrice.Text = (string)data.GetValue(8);
			txtLastQty.Text = (string)data.GetValue(9);
			txtLastQtyDelta.Text = (string)data.GetValue(10);
		}

        /// <summary>
        /// This function is called when an instrument is not found after it is opened.
        /// </summary>
        /// <param name="pNotify">TTInstrNotify object</param>
        /// <param name="pInstr">TTInstrObj object</param>
        private void m_TTInstrNotify_OnNotifyNotFound(XTAPI.TTInstrNotify pNotify, XTAPI.TTInstrObj pInstr)
        {
            MessageBox.Show("The Contract: " + pInstr.Contract + " was not found", "Error");
        }

        /// <summary>
        /// This function is called when an instrument update occurs (e.g. LTP changes).
        /// </summary>
        /// <param name="pNotify">TTInstrNotify object</param>
        /// <param name="pInstr">TTInstrObj object</param>
		private void m_TTInstrNotify_OnNotifyUpdate(XTAPI.TTInstrNotify pNotify, XTAPI.TTInstrObj pInstr)
		{
            // Retrieve the instrument information using the TTInstrObj Get Properties.
			Array data = (Array) pInstr.get_Get("Bid$,BidQty$,Ask$,AskQty$,Last$,LastQty$,~LastQty$");

            txtBidPrice.Text = (string)data.GetValue(0);
			txtBidQty.Text = (string)data.GetValue(1);
			txtAskPrice.Text = (string)data.GetValue(2);
			txtAskQty.Text = (string)data.GetValue(3);
			txtLastPrice.Text = (string)data.GetValue(4);
			txtLastQty.Text = (string)data.GetValue(5);
			txtLastQtyDelta.Text = (string)data.GetValue(6);
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
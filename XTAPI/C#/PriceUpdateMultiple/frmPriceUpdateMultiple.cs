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
    /// PriceUpdateMultiple
    /// 
    /// This example demonstrates using the XTAPI to retrieve market data from multiple 
    /// instruments.  The TTDropHandler object is used to resolve instrument(s) dragged 
    /// and dropped from the X_TRADER Market Grid.  The TTInstrObj Alias property is 
    /// used to distiguish between each instrument.
    /// </summary>
	public class frmPriceUpdateMultiple : System.Windows.Forms.Form
    {
        // Declare the neccessary XTAPI objects.
		private XTAPI.TTDropHandlerClass m_TTDropHandler = null;
		private XTAPI.TTInstrObj[] m_TTInstrObj;
		private XTAPI.TTInstrNotifyClass m_TTInstrNotify = null;

        // Store the count of instruments found
        private int m_instrFoundCount = 0;

        /// <summary>
        /// Upon the application form loading, the TTDropHandler and TTInstrNotify objects
        /// are initialized, and the required events are subscribed.
        /// </summary>
		public frmPriceUpdateMultiple()
		{
			// Required for Windows Form Designer support
			InitializeComponent();	

			// Instantiate the drag and drop handler class.					 
			m_TTDropHandler = new XTAPI.TTDropHandlerClass();
			
			// Register the active form for drag and drop.
			m_TTDropHandler.RegisterDropWindow((int) this.Handle);

			// Subscribe to the drop and drag callback event.
			m_TTDropHandler.OnNotifyDrop += new XTAPI._ITTDropHandlerEvents_OnNotifyDropEventHandler(m_TTDropHandler_OnNotifyDrop);

			// Instantiate the TTInstrObj array for four TTInstrObj objects.
			m_TTInstrObj = new XTAPI.TTInstrObj[4];

			// Instantiate the instrument notification class
			m_TTInstrNotify = new XTAPI.TTInstrNotifyClass();

			// Subscribe to the necessary TTInstrNotify events.
			m_TTInstrNotify.OnNotifyFound +=new XTAPI._ITTInstrNotifyEvents_OnNotifyFoundEventHandler(m_TTInstrNotify_OnNotifyFound);
			m_TTInstrNotify.OnNotifyUpdate +=new XTAPI._ITTInstrNotifyEvents_OnNotifyUpdateEventHandler(m_TTInstrNotify_OnNotifyUpdate);
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
        private System.Windows.Forms.Label lblNotProduction;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Label lblExchange2;
        private System.Windows.Forms.Label lblProduct2;
        private System.Windows.Forms.Label lblProductType2;
        private System.Windows.Forms.Label lblContract2;
        private System.Windows.Forms.Label lblBidPrice2;
        private System.Windows.Forms.Label lblAskPrice2;
        private System.Windows.Forms.Label lblLastPrice2;
        private System.Windows.Forms.GroupBox gboInstrument2;
        private System.Windows.Forms.GroupBox gboInstrument1;
        private System.Windows.Forms.Label lblAskPrice1;
        private System.Windows.Forms.Label lblExchange1;
        private System.Windows.Forms.Label lblContract1;
        private System.Windows.Forms.Label lblLastPrice1;
        private System.Windows.Forms.Label lblProduct1;
        private System.Windows.Forms.Label lblBidPrice1;
        private System.Windows.Forms.Label lblProductType1;
        private System.Windows.Forms.GroupBox gboInstrument3;
        private System.Windows.Forms.Label lblAskPrice3;
        private System.Windows.Forms.Label lblExchange3;
        private System.Windows.Forms.Label lblContract3;
        private System.Windows.Forms.Label lblLastPrice3;
        private System.Windows.Forms.Label lblProduct3;
        private System.Windows.Forms.Label lblBidPrice3;
        private System.Windows.Forms.Label lblProductType3;
        private System.Windows.Forms.GroupBox gboInstrument4;
        private System.Windows.Forms.Label lblAskPrice4;
        private System.Windows.Forms.Label lblExchange4;
        private System.Windows.Forms.Label lblContract4;
        private System.Windows.Forms.Label lblLastPrice4;
        private System.Windows.Forms.Label lblProduct4;
        private System.Windows.Forms.Label lblBidPrice4;
        private System.Windows.Forms.Label lblProductType4;
        private System.Windows.Forms.TextBox productTextBox1;
        private System.Windows.Forms.TextBox prodTypeTextBox1;
        private System.Windows.Forms.TextBox lastPriceTextBox1;
        private System.Windows.Forms.TextBox exchangeTextBox1;
        private System.Windows.Forms.TextBox bidPriceTextBox1;
        private System.Windows.Forms.TextBox askPriceTextBox1;
        private System.Windows.Forms.TextBox contractTextBox1;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem mnuAbout;
        private System.Windows.Forms.TextBox exchangeTextBox2;
        private System.Windows.Forms.TextBox productTextBox2;
        private System.Windows.Forms.TextBox prodTypeTextBox2;
        private System.Windows.Forms.TextBox bidPriceTextBox2;
        private System.Windows.Forms.TextBox askPriceTextBox2;
        private System.Windows.Forms.TextBox lastPriceTextBox2;
        private System.Windows.Forms.TextBox productTextBox3;
        private System.Windows.Forms.TextBox prodTypeTextBox3;
        private System.Windows.Forms.TextBox lastPriceTextBox3;
        private System.Windows.Forms.TextBox exchangeTextBox3;
        private System.Windows.Forms.TextBox bidPriceTextBox3;
        private System.Windows.Forms.TextBox askPriceTextBox3;
        private System.Windows.Forms.TextBox contractTextBox3;
        private System.Windows.Forms.TextBox productTextBox4;
        private System.Windows.Forms.TextBox prodTypeTextBox4;
        private System.Windows.Forms.TextBox lastPriceTextBox4;
        private System.Windows.Forms.TextBox exchangeTextBox4;
        private System.Windows.Forms.TextBox bidPriceTextBox4;
        private System.Windows.Forms.TextBox askPriceTextBox4;
        private System.Windows.Forms.TextBox contractTextBox4;
        private System.Windows.Forms.TextBox contractTextBox2;

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.sbaStatus = new System.Windows.Forms.StatusBar();
            this.lblExchange2 = new System.Windows.Forms.Label();
            this.lblProduct2 = new System.Windows.Forms.Label();
            this.lblProductType2 = new System.Windows.Forms.Label();
            this.lblContract2 = new System.Windows.Forms.Label();
            this.lblBidPrice2 = new System.Windows.Forms.Label();
            this.lblAskPrice2 = new System.Windows.Forms.Label();
            this.lblLastPrice2 = new System.Windows.Forms.Label();
            this.exchangeTextBox2 = new System.Windows.Forms.TextBox();
            this.productTextBox2 = new System.Windows.Forms.TextBox();
            this.prodTypeTextBox2 = new System.Windows.Forms.TextBox();
            this.contractTextBox2 = new System.Windows.Forms.TextBox();
            this.bidPriceTextBox2 = new System.Windows.Forms.TextBox();
            this.askPriceTextBox2 = new System.Windows.Forms.TextBox();
            this.lastPriceTextBox2 = new System.Windows.Forms.TextBox();
            this.gboInstrument2 = new System.Windows.Forms.GroupBox();
            this.gboInstrument1 = new System.Windows.Forms.GroupBox();
            this.lblAskPrice1 = new System.Windows.Forms.Label();
            this.lblExchange1 = new System.Windows.Forms.Label();
            this.productTextBox1 = new System.Windows.Forms.TextBox();
            this.prodTypeTextBox1 = new System.Windows.Forms.TextBox();
            this.lblContract1 = new System.Windows.Forms.Label();
            this.lblLastPrice1 = new System.Windows.Forms.Label();
            this.lastPriceTextBox1 = new System.Windows.Forms.TextBox();
            this.exchangeTextBox1 = new System.Windows.Forms.TextBox();
            this.lblProduct1 = new System.Windows.Forms.Label();
            this.bidPriceTextBox1 = new System.Windows.Forms.TextBox();
            this.lblBidPrice1 = new System.Windows.Forms.Label();
            this.askPriceTextBox1 = new System.Windows.Forms.TextBox();
            this.contractTextBox1 = new System.Windows.Forms.TextBox();
            this.lblProductType1 = new System.Windows.Forms.Label();
            this.gboInstrument3 = new System.Windows.Forms.GroupBox();
            this.lblAskPrice3 = new System.Windows.Forms.Label();
            this.lblExchange3 = new System.Windows.Forms.Label();
            this.productTextBox3 = new System.Windows.Forms.TextBox();
            this.prodTypeTextBox3 = new System.Windows.Forms.TextBox();
            this.lblContract3 = new System.Windows.Forms.Label();
            this.lblLastPrice3 = new System.Windows.Forms.Label();
            this.lastPriceTextBox3 = new System.Windows.Forms.TextBox();
            this.exchangeTextBox3 = new System.Windows.Forms.TextBox();
            this.lblProduct3 = new System.Windows.Forms.Label();
            this.bidPriceTextBox3 = new System.Windows.Forms.TextBox();
            this.lblBidPrice3 = new System.Windows.Forms.Label();
            this.askPriceTextBox3 = new System.Windows.Forms.TextBox();
            this.contractTextBox3 = new System.Windows.Forms.TextBox();
            this.lblProductType3 = new System.Windows.Forms.Label();
            this.gboInstrument4 = new System.Windows.Forms.GroupBox();
            this.lblAskPrice4 = new System.Windows.Forms.Label();
            this.lblExchange4 = new System.Windows.Forms.Label();
            this.productTextBox4 = new System.Windows.Forms.TextBox();
            this.prodTypeTextBox4 = new System.Windows.Forms.TextBox();
            this.lblContract4 = new System.Windows.Forms.Label();
            this.lblLastPrice4 = new System.Windows.Forms.Label();
            this.lastPriceTextBox4 = new System.Windows.Forms.TextBox();
            this.exchangeTextBox4 = new System.Windows.Forms.TextBox();
            this.lblProduct4 = new System.Windows.Forms.Label();
            this.bidPriceTextBox4 = new System.Windows.Forms.TextBox();
            this.lblBidPrice4 = new System.Windows.Forms.Label();
            this.askPriceTextBox4 = new System.Windows.Forms.TextBox();
            this.contractTextBox4 = new System.Windows.Forms.TextBox();
            this.lblProductType4 = new System.Windows.Forms.Label();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.mnuAbout = new System.Windows.Forms.MenuItem();
            this.lblNotProduction = new System.Windows.Forms.Label();
            this.lblWarning = new System.Windows.Forms.Label();
            this.gboInstrument2.SuspendLayout();
            this.gboInstrument1.SuspendLayout();
            this.gboInstrument3.SuspendLayout();
            this.gboInstrument4.SuspendLayout();
            this.SuspendLayout();
            // 
            // sbaStatus
            // 
            this.sbaStatus.Location = new System.Drawing.Point(0, 505);
            this.sbaStatus.Name = "sbaStatus";
            this.sbaStatus.Size = new System.Drawing.Size(456, 22);
            this.sbaStatus.SizingGrip = false;
            this.sbaStatus.TabIndex = 56;
            this.sbaStatus.Text = "Drag and Drop multiple instruments from the Market Grid in X_TRADER to this windo" +
    "w.";
            // 
            // lblExchange2
            // 
            this.lblExchange2.Location = new System.Drawing.Point(8, 24);
            this.lblExchange2.Name = "lblExchange2";
            this.lblExchange2.Size = new System.Drawing.Size(80, 16);
            this.lblExchange2.TabIndex = 57;
            this.lblExchange2.Text = "Exchange:";
            this.lblExchange2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProduct2
            // 
            this.lblProduct2.Location = new System.Drawing.Point(8, 48);
            this.lblProduct2.Name = "lblProduct2";
            this.lblProduct2.Size = new System.Drawing.Size(80, 16);
            this.lblProduct2.TabIndex = 58;
            this.lblProduct2.Text = "Product:";
            this.lblProduct2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProductType2
            // 
            this.lblProductType2.Location = new System.Drawing.Point(8, 72);
            this.lblProductType2.Name = "lblProductType2";
            this.lblProductType2.Size = new System.Drawing.Size(80, 16);
            this.lblProductType2.TabIndex = 59;
            this.lblProductType2.Text = "Product Type:";
            this.lblProductType2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblContract2
            // 
            this.lblContract2.Location = new System.Drawing.Point(8, 96);
            this.lblContract2.Name = "lblContract2";
            this.lblContract2.Size = new System.Drawing.Size(80, 16);
            this.lblContract2.TabIndex = 60;
            this.lblContract2.Text = "Contract:";
            this.lblContract2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBidPrice2
            // 
            this.lblBidPrice2.Location = new System.Drawing.Point(8, 128);
            this.lblBidPrice2.Name = "lblBidPrice2";
            this.lblBidPrice2.Size = new System.Drawing.Size(80, 16);
            this.lblBidPrice2.TabIndex = 61;
            this.lblBidPrice2.Text = "Bid Price:";
            this.lblBidPrice2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAskPrice2
            // 
            this.lblAskPrice2.Location = new System.Drawing.Point(8, 152);
            this.lblAskPrice2.Name = "lblAskPrice2";
            this.lblAskPrice2.Size = new System.Drawing.Size(80, 16);
            this.lblAskPrice2.TabIndex = 62;
            this.lblAskPrice2.Text = "Ask Price:";
            this.lblAskPrice2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLastPrice2
            // 
            this.lblLastPrice2.Location = new System.Drawing.Point(8, 176);
            this.lblLastPrice2.Name = "lblLastPrice2";
            this.lblLastPrice2.Size = new System.Drawing.Size(80, 16);
            this.lblLastPrice2.TabIndex = 63;
            this.lblLastPrice2.Text = "Last Price:";
            this.lblLastPrice2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // exchangeTextBox2
            // 
            this.exchangeTextBox2.Location = new System.Drawing.Point(96, 24);
            this.exchangeTextBox2.Name = "exchangeTextBox2";
            this.exchangeTextBox2.Size = new System.Drawing.Size(96, 20);
            this.exchangeTextBox2.TabIndex = 64;
            // 
            // productTextBox2
            // 
            this.productTextBox2.Location = new System.Drawing.Point(96, 48);
            this.productTextBox2.Name = "productTextBox2";
            this.productTextBox2.Size = new System.Drawing.Size(96, 20);
            this.productTextBox2.TabIndex = 65;
            // 
            // prodTypeTextBox2
            // 
            this.prodTypeTextBox2.Location = new System.Drawing.Point(96, 72);
            this.prodTypeTextBox2.Name = "prodTypeTextBox2";
            this.prodTypeTextBox2.Size = new System.Drawing.Size(96, 20);
            this.prodTypeTextBox2.TabIndex = 66;
            // 
            // contractTextBox2
            // 
            this.contractTextBox2.Location = new System.Drawing.Point(96, 96);
            this.contractTextBox2.Name = "contractTextBox2";
            this.contractTextBox2.Size = new System.Drawing.Size(96, 20);
            this.contractTextBox2.TabIndex = 67;
            // 
            // bidPriceTextBox2
            // 
            this.bidPriceTextBox2.Location = new System.Drawing.Point(96, 128);
            this.bidPriceTextBox2.Name = "bidPriceTextBox2";
            this.bidPriceTextBox2.Size = new System.Drawing.Size(96, 20);
            this.bidPriceTextBox2.TabIndex = 68;
            // 
            // askPriceTextBox2
            // 
            this.askPriceTextBox2.Location = new System.Drawing.Point(96, 152);
            this.askPriceTextBox2.Name = "askPriceTextBox2";
            this.askPriceTextBox2.Size = new System.Drawing.Size(96, 20);
            this.askPriceTextBox2.TabIndex = 69;
            // 
            // lastPriceTextBox2
            // 
            this.lastPriceTextBox2.Location = new System.Drawing.Point(96, 176);
            this.lastPriceTextBox2.Name = "lastPriceTextBox2";
            this.lastPriceTextBox2.Size = new System.Drawing.Size(96, 20);
            this.lastPriceTextBox2.TabIndex = 70;
            // 
            // gboInstrument2
            // 
            this.gboInstrument2.Controls.Add(this.lblAskPrice2);
            this.gboInstrument2.Controls.Add(this.lblExchange2);
            this.gboInstrument2.Controls.Add(this.productTextBox2);
            this.gboInstrument2.Controls.Add(this.prodTypeTextBox2);
            this.gboInstrument2.Controls.Add(this.lblContract2);
            this.gboInstrument2.Controls.Add(this.lblLastPrice2);
            this.gboInstrument2.Controls.Add(this.lastPriceTextBox2);
            this.gboInstrument2.Controls.Add(this.exchangeTextBox2);
            this.gboInstrument2.Controls.Add(this.lblProduct2);
            this.gboInstrument2.Controls.Add(this.bidPriceTextBox2);
            this.gboInstrument2.Controls.Add(this.lblBidPrice2);
            this.gboInstrument2.Controls.Add(this.askPriceTextBox2);
            this.gboInstrument2.Controls.Add(this.contractTextBox2);
            this.gboInstrument2.Controls.Add(this.lblProductType2);
            this.gboInstrument2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gboInstrument2.Location = new System.Drawing.Point(232, 51);
            this.gboInstrument2.Name = "gboInstrument2";
            this.gboInstrument2.Size = new System.Drawing.Size(208, 216);
            this.gboInstrument2.TabIndex = 71;
            this.gboInstrument2.TabStop = false;
            this.gboInstrument2.Text = "Instrument 2";
            // 
            // gboInstrument1
            // 
            this.gboInstrument1.Controls.Add(this.lblAskPrice1);
            this.gboInstrument1.Controls.Add(this.lblExchange1);
            this.gboInstrument1.Controls.Add(this.productTextBox1);
            this.gboInstrument1.Controls.Add(this.prodTypeTextBox1);
            this.gboInstrument1.Controls.Add(this.lblContract1);
            this.gboInstrument1.Controls.Add(this.lblLastPrice1);
            this.gboInstrument1.Controls.Add(this.lastPriceTextBox1);
            this.gboInstrument1.Controls.Add(this.exchangeTextBox1);
            this.gboInstrument1.Controls.Add(this.lblProduct1);
            this.gboInstrument1.Controls.Add(this.bidPriceTextBox1);
            this.gboInstrument1.Controls.Add(this.lblBidPrice1);
            this.gboInstrument1.Controls.Add(this.askPriceTextBox1);
            this.gboInstrument1.Controls.Add(this.contractTextBox1);
            this.gboInstrument1.Controls.Add(this.lblProductType1);
            this.gboInstrument1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gboInstrument1.Location = new System.Drawing.Point(16, 51);
            this.gboInstrument1.Name = "gboInstrument1";
            this.gboInstrument1.Size = new System.Drawing.Size(208, 216);
            this.gboInstrument1.TabIndex = 72;
            this.gboInstrument1.TabStop = false;
            this.gboInstrument1.Text = "Instrument 1";
            // 
            // lblAskPrice1
            // 
            this.lblAskPrice1.Location = new System.Drawing.Point(8, 152);
            this.lblAskPrice1.Name = "lblAskPrice1";
            this.lblAskPrice1.Size = new System.Drawing.Size(80, 16);
            this.lblAskPrice1.TabIndex = 62;
            this.lblAskPrice1.Text = "Ask Price:";
            this.lblAskPrice1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblExchange1
            // 
            this.lblExchange1.Location = new System.Drawing.Point(8, 24);
            this.lblExchange1.Name = "lblExchange1";
            this.lblExchange1.Size = new System.Drawing.Size(80, 16);
            this.lblExchange1.TabIndex = 57;
            this.lblExchange1.Text = "Exchange:";
            this.lblExchange1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // productTextBox1
            // 
            this.productTextBox1.Location = new System.Drawing.Point(96, 48);
            this.productTextBox1.Name = "productTextBox1";
            this.productTextBox1.Size = new System.Drawing.Size(96, 20);
            this.productTextBox1.TabIndex = 65;
            // 
            // prodTypeTextBox1
            // 
            this.prodTypeTextBox1.Location = new System.Drawing.Point(96, 72);
            this.prodTypeTextBox1.Name = "prodTypeTextBox1";
            this.prodTypeTextBox1.Size = new System.Drawing.Size(96, 20);
            this.prodTypeTextBox1.TabIndex = 66;
            // 
            // lblContract1
            // 
            this.lblContract1.Location = new System.Drawing.Point(8, 96);
            this.lblContract1.Name = "lblContract1";
            this.lblContract1.Size = new System.Drawing.Size(80, 16);
            this.lblContract1.TabIndex = 60;
            this.lblContract1.Text = "Contract:";
            this.lblContract1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLastPrice1
            // 
            this.lblLastPrice1.Location = new System.Drawing.Point(8, 176);
            this.lblLastPrice1.Name = "lblLastPrice1";
            this.lblLastPrice1.Size = new System.Drawing.Size(80, 16);
            this.lblLastPrice1.TabIndex = 63;
            this.lblLastPrice1.Text = "Last Price:";
            this.lblLastPrice1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lastPriceTextBox1
            // 
            this.lastPriceTextBox1.Location = new System.Drawing.Point(96, 176);
            this.lastPriceTextBox1.Name = "lastPriceTextBox1";
            this.lastPriceTextBox1.Size = new System.Drawing.Size(96, 20);
            this.lastPriceTextBox1.TabIndex = 70;
            // 
            // exchangeTextBox1
            // 
            this.exchangeTextBox1.Location = new System.Drawing.Point(96, 24);
            this.exchangeTextBox1.Name = "exchangeTextBox1";
            this.exchangeTextBox1.Size = new System.Drawing.Size(96, 20);
            this.exchangeTextBox1.TabIndex = 64;
            // 
            // lblProduct1
            // 
            this.lblProduct1.Location = new System.Drawing.Point(8, 48);
            this.lblProduct1.Name = "lblProduct1";
            this.lblProduct1.Size = new System.Drawing.Size(80, 16);
            this.lblProduct1.TabIndex = 58;
            this.lblProduct1.Text = "Product:";
            this.lblProduct1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bidPriceTextBox1
            // 
            this.bidPriceTextBox1.Location = new System.Drawing.Point(96, 128);
            this.bidPriceTextBox1.Name = "bidPriceTextBox1";
            this.bidPriceTextBox1.Size = new System.Drawing.Size(96, 20);
            this.bidPriceTextBox1.TabIndex = 68;
            // 
            // lblBidPrice1
            // 
            this.lblBidPrice1.Location = new System.Drawing.Point(8, 128);
            this.lblBidPrice1.Name = "lblBidPrice1";
            this.lblBidPrice1.Size = new System.Drawing.Size(80, 16);
            this.lblBidPrice1.TabIndex = 61;
            this.lblBidPrice1.Text = "Bid Price:";
            this.lblBidPrice1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // askPriceTextBox1
            // 
            this.askPriceTextBox1.Location = new System.Drawing.Point(96, 152);
            this.askPriceTextBox1.Name = "askPriceTextBox1";
            this.askPriceTextBox1.Size = new System.Drawing.Size(96, 20);
            this.askPriceTextBox1.TabIndex = 69;
            // 
            // contractTextBox1
            // 
            this.contractTextBox1.Location = new System.Drawing.Point(96, 96);
            this.contractTextBox1.Name = "contractTextBox1";
            this.contractTextBox1.Size = new System.Drawing.Size(96, 20);
            this.contractTextBox1.TabIndex = 67;
            // 
            // lblProductType1
            // 
            this.lblProductType1.Location = new System.Drawing.Point(8, 72);
            this.lblProductType1.Name = "lblProductType1";
            this.lblProductType1.Size = new System.Drawing.Size(80, 16);
            this.lblProductType1.TabIndex = 59;
            this.lblProductType1.Text = "Product Type:";
            this.lblProductType1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gboInstrument3
            // 
            this.gboInstrument3.Controls.Add(this.lblAskPrice3);
            this.gboInstrument3.Controls.Add(this.lblExchange3);
            this.gboInstrument3.Controls.Add(this.productTextBox3);
            this.gboInstrument3.Controls.Add(this.prodTypeTextBox3);
            this.gboInstrument3.Controls.Add(this.lblContract3);
            this.gboInstrument3.Controls.Add(this.lblLastPrice3);
            this.gboInstrument3.Controls.Add(this.lastPriceTextBox3);
            this.gboInstrument3.Controls.Add(this.exchangeTextBox3);
            this.gboInstrument3.Controls.Add(this.lblProduct3);
            this.gboInstrument3.Controls.Add(this.bidPriceTextBox3);
            this.gboInstrument3.Controls.Add(this.lblBidPrice3);
            this.gboInstrument3.Controls.Add(this.askPriceTextBox3);
            this.gboInstrument3.Controls.Add(this.contractTextBox3);
            this.gboInstrument3.Controls.Add(this.lblProductType3);
            this.gboInstrument3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gboInstrument3.Location = new System.Drawing.Point(16, 275);
            this.gboInstrument3.Name = "gboInstrument3";
            this.gboInstrument3.Size = new System.Drawing.Size(208, 216);
            this.gboInstrument3.TabIndex = 73;
            this.gboInstrument3.TabStop = false;
            this.gboInstrument3.Text = "Instrument 3";
            // 
            // lblAskPrice3
            // 
            this.lblAskPrice3.Location = new System.Drawing.Point(8, 152);
            this.lblAskPrice3.Name = "lblAskPrice3";
            this.lblAskPrice3.Size = new System.Drawing.Size(80, 16);
            this.lblAskPrice3.TabIndex = 62;
            this.lblAskPrice3.Text = "Ask Price:";
            this.lblAskPrice3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblExchange3
            // 
            this.lblExchange3.Location = new System.Drawing.Point(8, 24);
            this.lblExchange3.Name = "lblExchange3";
            this.lblExchange3.Size = new System.Drawing.Size(80, 16);
            this.lblExchange3.TabIndex = 57;
            this.lblExchange3.Text = "Exchange:";
            this.lblExchange3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // productTextBox3
            // 
            this.productTextBox3.Location = new System.Drawing.Point(96, 48);
            this.productTextBox3.Name = "productTextBox3";
            this.productTextBox3.Size = new System.Drawing.Size(96, 20);
            this.productTextBox3.TabIndex = 65;
            // 
            // prodTypeTextBox3
            // 
            this.prodTypeTextBox3.Location = new System.Drawing.Point(96, 72);
            this.prodTypeTextBox3.Name = "prodTypeTextBox3";
            this.prodTypeTextBox3.Size = new System.Drawing.Size(96, 20);
            this.prodTypeTextBox3.TabIndex = 66;
            // 
            // lblContract3
            // 
            this.lblContract3.Location = new System.Drawing.Point(8, 96);
            this.lblContract3.Name = "lblContract3";
            this.lblContract3.Size = new System.Drawing.Size(80, 16);
            this.lblContract3.TabIndex = 60;
            this.lblContract3.Text = "Contract:";
            this.lblContract3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLastPrice3
            // 
            this.lblLastPrice3.Location = new System.Drawing.Point(8, 176);
            this.lblLastPrice3.Name = "lblLastPrice3";
            this.lblLastPrice3.Size = new System.Drawing.Size(80, 16);
            this.lblLastPrice3.TabIndex = 63;
            this.lblLastPrice3.Text = "Last Price:";
            this.lblLastPrice3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lastPriceTextBox3
            // 
            this.lastPriceTextBox3.Location = new System.Drawing.Point(96, 176);
            this.lastPriceTextBox3.Name = "lastPriceTextBox3";
            this.lastPriceTextBox3.Size = new System.Drawing.Size(96, 20);
            this.lastPriceTextBox3.TabIndex = 70;
            // 
            // exchangeTextBox3
            // 
            this.exchangeTextBox3.Location = new System.Drawing.Point(96, 24);
            this.exchangeTextBox3.Name = "exchangeTextBox3";
            this.exchangeTextBox3.Size = new System.Drawing.Size(96, 20);
            this.exchangeTextBox3.TabIndex = 64;
            // 
            // lblProduct3
            // 
            this.lblProduct3.Location = new System.Drawing.Point(8, 48);
            this.lblProduct3.Name = "lblProduct3";
            this.lblProduct3.Size = new System.Drawing.Size(80, 16);
            this.lblProduct3.TabIndex = 58;
            this.lblProduct3.Text = "Product:";
            this.lblProduct3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bidPriceTextBox3
            // 
            this.bidPriceTextBox3.Location = new System.Drawing.Point(96, 128);
            this.bidPriceTextBox3.Name = "bidPriceTextBox3";
            this.bidPriceTextBox3.Size = new System.Drawing.Size(96, 20);
            this.bidPriceTextBox3.TabIndex = 68;
            // 
            // lblBidPrice3
            // 
            this.lblBidPrice3.Location = new System.Drawing.Point(8, 128);
            this.lblBidPrice3.Name = "lblBidPrice3";
            this.lblBidPrice3.Size = new System.Drawing.Size(80, 16);
            this.lblBidPrice3.TabIndex = 61;
            this.lblBidPrice3.Text = "Bid Price:";
            this.lblBidPrice3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // askPriceTextBox3
            // 
            this.askPriceTextBox3.Location = new System.Drawing.Point(96, 152);
            this.askPriceTextBox3.Name = "askPriceTextBox3";
            this.askPriceTextBox3.Size = new System.Drawing.Size(96, 20);
            this.askPriceTextBox3.TabIndex = 69;
            // 
            // contractTextBox3
            // 
            this.contractTextBox3.Location = new System.Drawing.Point(96, 96);
            this.contractTextBox3.Name = "contractTextBox3";
            this.contractTextBox3.Size = new System.Drawing.Size(96, 20);
            this.contractTextBox3.TabIndex = 67;
            // 
            // lblProductType3
            // 
            this.lblProductType3.Location = new System.Drawing.Point(8, 72);
            this.lblProductType3.Name = "lblProductType3";
            this.lblProductType3.Size = new System.Drawing.Size(80, 16);
            this.lblProductType3.TabIndex = 59;
            this.lblProductType3.Text = "Product Type:";
            this.lblProductType3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gboInstrument4
            // 
            this.gboInstrument4.Controls.Add(this.lblAskPrice4);
            this.gboInstrument4.Controls.Add(this.lblExchange4);
            this.gboInstrument4.Controls.Add(this.productTextBox4);
            this.gboInstrument4.Controls.Add(this.prodTypeTextBox4);
            this.gboInstrument4.Controls.Add(this.lblContract4);
            this.gboInstrument4.Controls.Add(this.lblLastPrice4);
            this.gboInstrument4.Controls.Add(this.lastPriceTextBox4);
            this.gboInstrument4.Controls.Add(this.exchangeTextBox4);
            this.gboInstrument4.Controls.Add(this.lblProduct4);
            this.gboInstrument4.Controls.Add(this.bidPriceTextBox4);
            this.gboInstrument4.Controls.Add(this.lblBidPrice4);
            this.gboInstrument4.Controls.Add(this.askPriceTextBox4);
            this.gboInstrument4.Controls.Add(this.contractTextBox4);
            this.gboInstrument4.Controls.Add(this.lblProductType4);
            this.gboInstrument4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gboInstrument4.Location = new System.Drawing.Point(232, 275);
            this.gboInstrument4.Name = "gboInstrument4";
            this.gboInstrument4.Size = new System.Drawing.Size(208, 216);
            this.gboInstrument4.TabIndex = 74;
            this.gboInstrument4.TabStop = false;
            this.gboInstrument4.Text = "Instrument 4";
            // 
            // lblAskPrice4
            // 
            this.lblAskPrice4.Location = new System.Drawing.Point(8, 152);
            this.lblAskPrice4.Name = "lblAskPrice4";
            this.lblAskPrice4.Size = new System.Drawing.Size(80, 16);
            this.lblAskPrice4.TabIndex = 62;
            this.lblAskPrice4.Text = "Ask Price:";
            this.lblAskPrice4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblExchange4
            // 
            this.lblExchange4.Location = new System.Drawing.Point(8, 24);
            this.lblExchange4.Name = "lblExchange4";
            this.lblExchange4.Size = new System.Drawing.Size(80, 16);
            this.lblExchange4.TabIndex = 57;
            this.lblExchange4.Text = "Exchange:";
            this.lblExchange4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // productTextBox4
            // 
            this.productTextBox4.Location = new System.Drawing.Point(96, 48);
            this.productTextBox4.Name = "productTextBox4";
            this.productTextBox4.Size = new System.Drawing.Size(96, 20);
            this.productTextBox4.TabIndex = 65;
            // 
            // prodTypeTextBox4
            // 
            this.prodTypeTextBox4.Location = new System.Drawing.Point(96, 72);
            this.prodTypeTextBox4.Name = "prodTypeTextBox4";
            this.prodTypeTextBox4.Size = new System.Drawing.Size(96, 20);
            this.prodTypeTextBox4.TabIndex = 66;
            // 
            // lblContract4
            // 
            this.lblContract4.Location = new System.Drawing.Point(8, 96);
            this.lblContract4.Name = "lblContract4";
            this.lblContract4.Size = new System.Drawing.Size(80, 16);
            this.lblContract4.TabIndex = 60;
            this.lblContract4.Text = "Contract:";
            this.lblContract4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLastPrice4
            // 
            this.lblLastPrice4.Location = new System.Drawing.Point(8, 176);
            this.lblLastPrice4.Name = "lblLastPrice4";
            this.lblLastPrice4.Size = new System.Drawing.Size(80, 16);
            this.lblLastPrice4.TabIndex = 63;
            this.lblLastPrice4.Text = "Last Price:";
            this.lblLastPrice4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lastPriceTextBox4
            // 
            this.lastPriceTextBox4.Location = new System.Drawing.Point(96, 176);
            this.lastPriceTextBox4.Name = "lastPriceTextBox4";
            this.lastPriceTextBox4.Size = new System.Drawing.Size(96, 20);
            this.lastPriceTextBox4.TabIndex = 70;
            // 
            // exchangeTextBox4
            // 
            this.exchangeTextBox4.Location = new System.Drawing.Point(96, 24);
            this.exchangeTextBox4.Name = "exchangeTextBox4";
            this.exchangeTextBox4.Size = new System.Drawing.Size(96, 20);
            this.exchangeTextBox4.TabIndex = 64;
            // 
            // lblProduct4
            // 
            this.lblProduct4.Location = new System.Drawing.Point(8, 48);
            this.lblProduct4.Name = "lblProduct4";
            this.lblProduct4.Size = new System.Drawing.Size(80, 16);
            this.lblProduct4.TabIndex = 58;
            this.lblProduct4.Text = "Product:";
            this.lblProduct4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bidPriceTextBox4
            // 
            this.bidPriceTextBox4.Location = new System.Drawing.Point(96, 128);
            this.bidPriceTextBox4.Name = "bidPriceTextBox4";
            this.bidPriceTextBox4.Size = new System.Drawing.Size(96, 20);
            this.bidPriceTextBox4.TabIndex = 68;
            // 
            // lblBidPrice4
            // 
            this.lblBidPrice4.Location = new System.Drawing.Point(8, 128);
            this.lblBidPrice4.Name = "lblBidPrice4";
            this.lblBidPrice4.Size = new System.Drawing.Size(80, 16);
            this.lblBidPrice4.TabIndex = 61;
            this.lblBidPrice4.Text = "Bid Price:";
            this.lblBidPrice4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // askPriceTextBox4
            // 
            this.askPriceTextBox4.Location = new System.Drawing.Point(96, 152);
            this.askPriceTextBox4.Name = "askPriceTextBox4";
            this.askPriceTextBox4.Size = new System.Drawing.Size(96, 20);
            this.askPriceTextBox4.TabIndex = 69;
            // 
            // contractTextBox4
            // 
            this.contractTextBox4.Location = new System.Drawing.Point(96, 96);
            this.contractTextBox4.Name = "contractTextBox4";
            this.contractTextBox4.Size = new System.Drawing.Size(96, 20);
            this.contractTextBox4.TabIndex = 67;
            // 
            // lblProductType4
            // 
            this.lblProductType4.Location = new System.Drawing.Point(8, 72);
            this.lblProductType4.Name = "lblProductType4";
            this.lblProductType4.Size = new System.Drawing.Size(80, 16);
            this.lblProductType4.TabIndex = 59;
            this.lblProductType4.Text = "Product Type:";
            this.lblProductType4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.lblNotProduction.Location = new System.Drawing.Point(16, 32);
            this.lblNotProduction.Name = "lblNotProduction";
            this.lblNotProduction.Size = new System.Drawing.Size(424, 14);
            this.lblNotProduction.TabIndex = 76;
            this.lblNotProduction.Text = "This sample is NOT to be used in production or during conformance testing.";
            this.lblNotProduction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWarning
            // 
            this.lblWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarning.Location = new System.Drawing.Point(16, 7);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(424, 23);
            this.lblWarning.TabIndex = 75;
            this.lblWarning.Text = "WARNING!";
            this.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmPriceUpdateMultipleInstruments
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(456, 527);
            this.Controls.Add(this.lblNotProduction);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.gboInstrument4);
            this.Controls.Add(this.gboInstrument3);
            this.Controls.Add(this.gboInstrument2);
            this.Controls.Add(this.sbaStatus);
            this.Controls.Add(this.gboInstrument1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Menu = this.mainMenu1;
            this.Name = "frmPriceUpdateMultipleInstruments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PriceUpdateMultiple";
            this.gboInstrument2.ResumeLayout(false);
            this.gboInstrument2.PerformLayout();
            this.gboInstrument1.ResumeLayout(false);
            this.gboInstrument1.PerformLayout();
            this.gboInstrument3.ResumeLayout(false);
            this.gboInstrument3.PerformLayout();
            this.gboInstrument4.ResumeLayout(false);
            this.gboInstrument4.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		public static void Main() 
		{
			// Enable Visual Styles for XP Look and Feel.
			Application.EnableVisualStyles();
			Application.Run(new frmPriceUpdateMultiple());
		}

        /// <summary>
        /// This function is called when instrument(s) are dragged and dropped from the 
        /// Market Grid in X_TRADER.
        /// </summary>
		private void m_TTDropHandler_OnNotifyDrop()
		{	
			// Update the Status Bar text.
			sbaStatus.Text = "Drag & Drop detected.  Initializing instrument(s)...";

            // Reset the located instrument count
            m_instrFoundCount = 0;

			try
			{	
				// Obtain the number of instruments dropped.
				int count = m_TTDropHandler.Count;

				// Only support a maximum of four instruments.
				if(count > 4)	
				{
					count = 4;		
				}

				for (int i = 0; i < count; i++)
				{
					// Test is TTInstrObj currently exist.
					if( m_TTInstrObj[i] != null )
					{
						// Remove the Instrument and reset the Alias.
						m_TTInstrNotify.DetachInstrument(m_TTInstrObj[i]);
						m_TTInstrObj[i].Alias = "";
						m_TTInstrObj[i] = null;
					}

					// Obtain the TTInstrObj from the TTDropHandler object.
					// The TTDropHandler index begins at 1.
					m_TTInstrObj[i] = (XTAPI.TTInstrObj) m_TTDropHandler[i+1];		

					// Attach the TTInstrObj to the TTInstrNotify.
					m_TTInstrNotify.AttachInstrument(m_TTInstrObj[i]);
					
					// Set the TTInstrObj Alias to the index for identification.
					m_TTInstrObj[i].Alias = i.ToString();
					
					// Open the TTInstrObj with depth disabled.								
                    m_TTInstrObj[i].Open(0);  // enable Market Depth:  1 - true, 0 - false
				}	

				// Clear drop handler list
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
			// Increment the located instruments and update the StatusBar text.
            sbaStatus.Text = "Instrument(s) Found: " + ++m_instrFoundCount;

			// Retrieve and display the instrument information.
			DisplayInstrumentInformation(pInstr);
		}

        /// <summary>
        /// This function is called when an instrument update occurs (i.e. LTP changes).
        /// </summary>
        /// <param name="pNotify">TTInstrNotify object</param>
        /// <param name="pInstr">TTInstrObj object</param>
		private void m_TTInstrNotify_OnNotifyUpdate(XTAPI.TTInstrNotify pNotify, XTAPI.TTInstrObj pInstr)
		{			
			// Retrieve and display the instrument information.
			DisplayInstrumentInformation(pInstr);			
		}

        /// <summary>
        /// Display the information from the instrument object(s) to the GUI.
        /// 
        /// Note:   The TTInstrObj Alias property set in the m_TTDropHandler.OnNotifyDrop()
        ///         is used to determine the instrument invoking the update.
        /// </summary>
        /// <param name="pInstr">TTInstrObj object</param>
		private void DisplayInstrumentInformation(XTAPI.TTInstrObj pInstr)
		{	
			// Retrieve the instrument information using the TTInstrObj Get Properties.
            //
			// Note:    For simplicity, the Exchange, Product, ProdType and Contract request 
            //          is redundant for market data updates.  Ideally you would only need
            //          to request this information in the OnNotifyFound event.
			Array data = (Array) pInstr.get_Get("Exchange,Product,ProdType,Contract,Bid$,Ask$,Last$");					
			
			// Switch is based on Alias property set during the OnNotifyDrop event
			switch (pInstr.Alias)
			{
				case "0":
					exchangeTextBox1.Text = (string)data.GetValue(0);
					productTextBox1.Text = (string)data.GetValue(1);
					prodTypeTextBox1.Text = (string)data.GetValue(2);
					contractTextBox1.Text = (string)data.GetValue(3);					
					bidPriceTextBox1.Text = (string)data.GetValue(4);
					askPriceTextBox1.Text = (string)data.GetValue(5);
					lastPriceTextBox1.Text = (string)data.GetValue(6);
					break;
				case "1":
					exchangeTextBox2.Text = (string)data.GetValue(0);
					productTextBox2.Text = (string)data.GetValue(1);
					prodTypeTextBox2.Text = (string)data.GetValue(2);
					contractTextBox2.Text = (string)data.GetValue(3);					
					bidPriceTextBox2.Text = (string)data.GetValue(4);
					askPriceTextBox2.Text = (string)data.GetValue(5);
					lastPriceTextBox2.Text = (string)data.GetValue(6);
					break;
				case "2":
					exchangeTextBox3.Text = (string)data.GetValue(0);
					productTextBox3.Text = (string)data.GetValue(1);
					prodTypeTextBox3.Text = (string)data.GetValue(2);
					contractTextBox3.Text = (string)data.GetValue(3);					
					bidPriceTextBox3.Text = (string)data.GetValue(4);
					askPriceTextBox3.Text = (string)data.GetValue(5);
					lastPriceTextBox3.Text = (string)data.GetValue(6);
					break;
				case "3":
					exchangeTextBox4.Text = (string)data.GetValue(0);
					productTextBox4.Text = (string)data.GetValue(1);
					prodTypeTextBox4.Text = (string)data.GetValue(2);
					contractTextBox4.Text = (string)data.GetValue(3);					
					bidPriceTextBox4.Text = (string)data.GetValue(4);
					askPriceTextBox4.Text = (string)data.GetValue(5);
					lastPriceTextBox4.Text = (string)data.GetValue(6);
					break;
				default:
					MessageBox.Show("DisplayInstrumentInformation: Invalid Index");
					break;
			}
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
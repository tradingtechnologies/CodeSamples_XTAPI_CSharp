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
	/// ProfitLoss
    /// 
    /// This example demonstrates using the XTAPI to retrieve the open P&L (profit & 
    /// loss) for multiple instruments.  The TTDropHandler object is used to resolve an 
    /// instrument dragged and dropped from the X_TRADER Market Grid.  The TTInstrObj 
    /// Alias property is used to distiguish between each instrument.
    /// 
    /// Note:   By default the format of the P&L from the XTAPI does not match the 
    ///         default setting in X_TRADER.  Please see the following knowledge
    ///         base article for further information:
    ///         
    ///         https://www.tradingtechnologies.com/support/knowledge-base/1/1894/
	/// </summary>
	public class frmProfitLoss : Form
    {
        // Declare the XTAPI objects.
		private XTAPI.TTDropHandlerClass m_TTDropHandler = null;
		private XTAPI.TTInstrObj[] m_TTInstrObj;
		private XTAPI.TTInstrNotifyClass m_TTInstrNotify = null;
        private XTAPI.TTOrderSetClass m_TTOrderSet = null;

        /// <summary>
        /// Upon the application form loading, the TTDropHandler and TTInstrNotify objects 
        /// are initialized, and the required events are subscribed.
        /// </summary>
		public frmProfitLoss()
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
			m_TTInstrNotify.OnOrderSetUpdate +=new XTAPI._ITTInstrNotifyEvents_OnOrderSetUpdateEventHandler(m_TTInstrNotify_OnOrderSetUpdate);
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
        private System.Windows.Forms.Label lblExchange2;
        private System.Windows.Forms.Label lblProduct2;
        private System.Windows.Forms.Label lblProductType2;
        private System.Windows.Forms.Label lblContract2;
        private System.Windows.Forms.GroupBox gboContract2;
        private System.Windows.Forms.GroupBox gboContract1;
        private System.Windows.Forms.Label lblNetPosition1;
        private System.Windows.Forms.Label lblExchange1;
        private System.Windows.Forms.Label lblContract1;
        private System.Windows.Forms.Label lblProduct1;
        private System.Windows.Forms.Label lblPL1;
        private System.Windows.Forms.Label lblProductType1;
        private System.Windows.Forms.GroupBox gboContract3;
        private System.Windows.Forms.Label lblExchange3;
        private System.Windows.Forms.Label lblContract3;
        private System.Windows.Forms.Label lblProduct3;
        private System.Windows.Forms.Label lblProductType3;
        private System.Windows.Forms.GroupBox gboContract4;
        private System.Windows.Forms.Label lblExchange4;
        private System.Windows.Forms.Label lblContract4;
        private System.Windows.Forms.Label lblProduct4;
        private System.Windows.Forms.Label lblProductType4;
        private System.Windows.Forms.TextBox txtProduct1;
        private System.Windows.Forms.TextBox txtProductType1;
        private System.Windows.Forms.TextBox txtExchange1;
        private System.Windows.Forms.TextBox txtContract1;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem mnuAbout;
        private System.Windows.Forms.TextBox txtExchange2;
        private System.Windows.Forms.TextBox txtProduct2;
        private System.Windows.Forms.TextBox txtProductType2;
        private System.Windows.Forms.TextBox txtProduct3;
        private System.Windows.Forms.TextBox txtProductType3;
        private System.Windows.Forms.TextBox txtExchange3;
        private System.Windows.Forms.TextBox txtContract3;
        private System.Windows.Forms.TextBox txtProduct4;
        private System.Windows.Forms.TextBox txtProductType4;
        private System.Windows.Forms.TextBox txtExchange4;
        private System.Windows.Forms.TextBox txtContract4;
        private System.Windows.Forms.TextBox txtContract2;
        private System.Windows.Forms.Label lblNetPosition2;
        private System.Windows.Forms.Label lblPL2;
        private System.Windows.Forms.Label lblNetPosition3;
        private System.Windows.Forms.Label lblPL3;
        private System.Windows.Forms.Label lblNetPosition4;
        private System.Windows.Forms.Label lblPL4;
        private System.Windows.Forms.Label lblNotProduction;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.TextBox txtPL1;
        private System.Windows.Forms.TextBox txtNetPosition1;
        private System.Windows.Forms.TextBox txtPL2;
        private System.Windows.Forms.TextBox txtNetPosition2;
        private System.Windows.Forms.TextBox txtPL3;
        private System.Windows.Forms.TextBox txtNetPosition3;
        private System.Windows.Forms.TextBox txtPL4;
        private System.Windows.Forms.TextBox txtNetPosition4;

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
            this.txtExchange2 = new System.Windows.Forms.TextBox();
            this.txtProduct2 = new System.Windows.Forms.TextBox();
            this.txtProductType2 = new System.Windows.Forms.TextBox();
            this.txtContract2 = new System.Windows.Forms.TextBox();
            this.gboContract2 = new System.Windows.Forms.GroupBox();
            this.lblNetPosition2 = new System.Windows.Forms.Label();
            this.txtPL2 = new System.Windows.Forms.TextBox();
            this.lblPL2 = new System.Windows.Forms.Label();
            this.txtNetPosition2 = new System.Windows.Forms.TextBox();
            this.gboContract1 = new System.Windows.Forms.GroupBox();
            this.lblExchange1 = new System.Windows.Forms.Label();
            this.txtProduct1 = new System.Windows.Forms.TextBox();
            this.txtProductType1 = new System.Windows.Forms.TextBox();
            this.lblContract1 = new System.Windows.Forms.Label();
            this.txtExchange1 = new System.Windows.Forms.TextBox();
            this.lblProduct1 = new System.Windows.Forms.Label();
            this.txtContract1 = new System.Windows.Forms.TextBox();
            this.lblProductType1 = new System.Windows.Forms.Label();
            this.lblNetPosition1 = new System.Windows.Forms.Label();
            this.txtPL1 = new System.Windows.Forms.TextBox();
            this.lblPL1 = new System.Windows.Forms.Label();
            this.txtNetPosition1 = new System.Windows.Forms.TextBox();
            this.gboContract3 = new System.Windows.Forms.GroupBox();
            this.lblNetPosition3 = new System.Windows.Forms.Label();
            this.txtPL3 = new System.Windows.Forms.TextBox();
            this.lblPL3 = new System.Windows.Forms.Label();
            this.txtNetPosition3 = new System.Windows.Forms.TextBox();
            this.lblExchange3 = new System.Windows.Forms.Label();
            this.txtProduct3 = new System.Windows.Forms.TextBox();
            this.txtProductType3 = new System.Windows.Forms.TextBox();
            this.lblContract3 = new System.Windows.Forms.Label();
            this.txtExchange3 = new System.Windows.Forms.TextBox();
            this.lblProduct3 = new System.Windows.Forms.Label();
            this.txtContract3 = new System.Windows.Forms.TextBox();
            this.lblProductType3 = new System.Windows.Forms.Label();
            this.gboContract4 = new System.Windows.Forms.GroupBox();
            this.lblExchange4 = new System.Windows.Forms.Label();
            this.txtProduct4 = new System.Windows.Forms.TextBox();
            this.txtProductType4 = new System.Windows.Forms.TextBox();
            this.lblContract4 = new System.Windows.Forms.Label();
            this.txtExchange4 = new System.Windows.Forms.TextBox();
            this.lblProduct4 = new System.Windows.Forms.Label();
            this.txtContract4 = new System.Windows.Forms.TextBox();
            this.lblProductType4 = new System.Windows.Forms.Label();
            this.txtPL4 = new System.Windows.Forms.TextBox();
            this.lblPL4 = new System.Windows.Forms.Label();
            this.txtNetPosition4 = new System.Windows.Forms.TextBox();
            this.lblNetPosition4 = new System.Windows.Forms.Label();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.mnuAbout = new System.Windows.Forms.MenuItem();
            this.lblNotProduction = new System.Windows.Forms.Label();
            this.lblWarning = new System.Windows.Forms.Label();
            this.gboContract2.SuspendLayout();
            this.gboContract1.SuspendLayout();
            this.gboContract3.SuspendLayout();
            this.gboContract4.SuspendLayout();
            this.SuspendLayout();
            // 
            // sbaStatus
            // 
            this.sbaStatus.Location = new System.Drawing.Point(0, 450);
            this.sbaStatus.Name = "sbaStatus";
            this.sbaStatus.Size = new System.Drawing.Size(445, 22);
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
            // txtExchange2
            // 
            this.txtExchange2.Location = new System.Drawing.Point(96, 24);
            this.txtExchange2.Name = "txtExchange2";
            this.txtExchange2.Size = new System.Drawing.Size(96, 20);
            this.txtExchange2.TabIndex = 64;
            // 
            // txtProduct2
            // 
            this.txtProduct2.Location = new System.Drawing.Point(96, 48);
            this.txtProduct2.Name = "txtProduct2";
            this.txtProduct2.Size = new System.Drawing.Size(96, 20);
            this.txtProduct2.TabIndex = 65;
            // 
            // txtProductType2
            // 
            this.txtProductType2.Location = new System.Drawing.Point(96, 72);
            this.txtProductType2.Name = "txtProductType2";
            this.txtProductType2.Size = new System.Drawing.Size(96, 20);
            this.txtProductType2.TabIndex = 66;
            // 
            // txtContract2
            // 
            this.txtContract2.Location = new System.Drawing.Point(96, 96);
            this.txtContract2.Name = "txtContract2";
            this.txtContract2.Size = new System.Drawing.Size(96, 20);
            this.txtContract2.TabIndex = 67;
            // 
            // gboContract2
            // 
            this.gboContract2.Controls.Add(this.lblNetPosition2);
            this.gboContract2.Controls.Add(this.txtPL2);
            this.gboContract2.Controls.Add(this.lblPL2);
            this.gboContract2.Controls.Add(this.txtNetPosition2);
            this.gboContract2.Controls.Add(this.lblExchange2);
            this.gboContract2.Controls.Add(this.txtProduct2);
            this.gboContract2.Controls.Add(this.txtProductType2);
            this.gboContract2.Controls.Add(this.lblContract2);
            this.gboContract2.Controls.Add(this.txtExchange2);
            this.gboContract2.Controls.Add(this.lblProduct2);
            this.gboContract2.Controls.Add(this.txtContract2);
            this.gboContract2.Controls.Add(this.lblProductType2);
            this.gboContract2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gboContract2.Location = new System.Drawing.Point(226, 60);
            this.gboContract2.Name = "gboContract2";
            this.gboContract2.Size = new System.Drawing.Size(208, 186);
            this.gboContract2.TabIndex = 71;
            this.gboContract2.TabStop = false;
            this.gboContract2.Text = "Contract 2";
            // 
            // lblNetPosition2
            // 
            this.lblNetPosition2.Location = new System.Drawing.Point(24, 154);
            this.lblNetPosition2.Name = "lblNetPosition2";
            this.lblNetPosition2.Size = new System.Drawing.Size(88, 16);
            this.lblNetPosition2.TabIndex = 71;
            this.lblNetPosition2.Text = "Net Position:";
            this.lblNetPosition2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPL2
            // 
            this.txtPL2.Location = new System.Drawing.Point(120, 128);
            this.txtPL2.Name = "txtPL2";
            this.txtPL2.Size = new System.Drawing.Size(72, 20);
            this.txtPL2.TabIndex = 72;
            // 
            // lblPL2
            // 
            this.lblPL2.Location = new System.Drawing.Point(32, 130);
            this.lblPL2.Name = "lblPL2";
            this.lblPL2.Size = new System.Drawing.Size(80, 16);
            this.lblPL2.TabIndex = 70;
            this.lblPL2.Text = "P/L:";
            this.lblPL2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNetPosition2
            // 
            this.txtNetPosition2.Location = new System.Drawing.Point(120, 152);
            this.txtNetPosition2.Name = "txtNetPosition2";
            this.txtNetPosition2.Size = new System.Drawing.Size(72, 20);
            this.txtNetPosition2.TabIndex = 73;
            // 
            // gboContract1
            // 
            this.gboContract1.Controls.Add(this.lblExchange1);
            this.gboContract1.Controls.Add(this.txtProduct1);
            this.gboContract1.Controls.Add(this.txtProductType1);
            this.gboContract1.Controls.Add(this.lblContract1);
            this.gboContract1.Controls.Add(this.txtExchange1);
            this.gboContract1.Controls.Add(this.lblProduct1);
            this.gboContract1.Controls.Add(this.txtContract1);
            this.gboContract1.Controls.Add(this.lblProductType1);
            this.gboContract1.Controls.Add(this.lblNetPosition1);
            this.gboContract1.Controls.Add(this.txtPL1);
            this.gboContract1.Controls.Add(this.lblPL1);
            this.gboContract1.Controls.Add(this.txtNetPosition1);
            this.gboContract1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gboContract1.Location = new System.Drawing.Point(12, 60);
            this.gboContract1.Name = "gboContract1";
            this.gboContract1.Size = new System.Drawing.Size(208, 186);
            this.gboContract1.TabIndex = 72;
            this.gboContract1.TabStop = false;
            this.gboContract1.Text = "Contract 1";
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
            // txtProduct1
            // 
            this.txtProduct1.Location = new System.Drawing.Point(96, 48);
            this.txtProduct1.Name = "txtProduct1";
            this.txtProduct1.Size = new System.Drawing.Size(96, 20);
            this.txtProduct1.TabIndex = 65;
            // 
            // txtProductType1
            // 
            this.txtProductType1.Location = new System.Drawing.Point(96, 72);
            this.txtProductType1.Name = "txtProductType1";
            this.txtProductType1.Size = new System.Drawing.Size(96, 20);
            this.txtProductType1.TabIndex = 66;
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
            // txtExchange1
            // 
            this.txtExchange1.Location = new System.Drawing.Point(96, 24);
            this.txtExchange1.Name = "txtExchange1";
            this.txtExchange1.Size = new System.Drawing.Size(96, 20);
            this.txtExchange1.TabIndex = 64;
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
            // txtContract1
            // 
            this.txtContract1.Location = new System.Drawing.Point(96, 96);
            this.txtContract1.Name = "txtContract1";
            this.txtContract1.Size = new System.Drawing.Size(96, 20);
            this.txtContract1.TabIndex = 67;
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
            // lblNetPosition1
            // 
            this.lblNetPosition1.Location = new System.Drawing.Point(24, 154);
            this.lblNetPosition1.Name = "lblNetPosition1";
            this.lblNetPosition1.Size = new System.Drawing.Size(88, 16);
            this.lblNetPosition1.TabIndex = 62;
            this.lblNetPosition1.Text = "Net Position:";
            this.lblNetPosition1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPL1
            // 
            this.txtPL1.Location = new System.Drawing.Point(120, 128);
            this.txtPL1.Name = "txtPL1";
            this.txtPL1.Size = new System.Drawing.Size(72, 20);
            this.txtPL1.TabIndex = 68;
            // 
            // lblPL1
            // 
            this.lblPL1.Location = new System.Drawing.Point(32, 130);
            this.lblPL1.Name = "lblPL1";
            this.lblPL1.Size = new System.Drawing.Size(80, 16);
            this.lblPL1.TabIndex = 61;
            this.lblPL1.Text = "P/L:";
            this.lblPL1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNetPosition1
            // 
            this.txtNetPosition1.Location = new System.Drawing.Point(120, 152);
            this.txtNetPosition1.Name = "txtNetPosition1";
            this.txtNetPosition1.Size = new System.Drawing.Size(72, 20);
            this.txtNetPosition1.TabIndex = 69;
            // 
            // gboContract3
            // 
            this.gboContract3.Controls.Add(this.lblNetPosition3);
            this.gboContract3.Controls.Add(this.txtPL3);
            this.gboContract3.Controls.Add(this.lblPL3);
            this.gboContract3.Controls.Add(this.txtNetPosition3);
            this.gboContract3.Controls.Add(this.lblExchange3);
            this.gboContract3.Controls.Add(this.txtProduct3);
            this.gboContract3.Controls.Add(this.txtProductType3);
            this.gboContract3.Controls.Add(this.lblContract3);
            this.gboContract3.Controls.Add(this.txtExchange3);
            this.gboContract3.Controls.Add(this.lblProduct3);
            this.gboContract3.Controls.Add(this.txtContract3);
            this.gboContract3.Controls.Add(this.lblProductType3);
            this.gboContract3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gboContract3.Location = new System.Drawing.Point(12, 252);
            this.gboContract3.Name = "gboContract3";
            this.gboContract3.Size = new System.Drawing.Size(208, 186);
            this.gboContract3.TabIndex = 73;
            this.gboContract3.TabStop = false;
            this.gboContract3.Text = "Contract 3";
            // 
            // lblNetPosition3
            // 
            this.lblNetPosition3.Location = new System.Drawing.Point(24, 154);
            this.lblNetPosition3.Name = "lblNetPosition3";
            this.lblNetPosition3.Size = new System.Drawing.Size(88, 16);
            this.lblNetPosition3.TabIndex = 71;
            this.lblNetPosition3.Text = "Net Position:";
            this.lblNetPosition3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPL3
            // 
            this.txtPL3.Location = new System.Drawing.Point(120, 128);
            this.txtPL3.Name = "txtPL3";
            this.txtPL3.Size = new System.Drawing.Size(72, 20);
            this.txtPL3.TabIndex = 72;
            // 
            // lblPL3
            // 
            this.lblPL3.Location = new System.Drawing.Point(32, 130);
            this.lblPL3.Name = "lblPL3";
            this.lblPL3.Size = new System.Drawing.Size(80, 16);
            this.lblPL3.TabIndex = 70;
            this.lblPL3.Text = "P/L:";
            this.lblPL3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNetPosition3
            // 
            this.txtNetPosition3.Location = new System.Drawing.Point(120, 152);
            this.txtNetPosition3.Name = "txtNetPosition3";
            this.txtNetPosition3.Size = new System.Drawing.Size(72, 20);
            this.txtNetPosition3.TabIndex = 73;
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
            // txtProduct3
            // 
            this.txtProduct3.Location = new System.Drawing.Point(96, 48);
            this.txtProduct3.Name = "txtProduct3";
            this.txtProduct3.Size = new System.Drawing.Size(96, 20);
            this.txtProduct3.TabIndex = 65;
            // 
            // txtProductType3
            // 
            this.txtProductType3.Location = new System.Drawing.Point(96, 72);
            this.txtProductType3.Name = "txtProductType3";
            this.txtProductType3.Size = new System.Drawing.Size(96, 20);
            this.txtProductType3.TabIndex = 66;
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
            // txtExchange3
            // 
            this.txtExchange3.Location = new System.Drawing.Point(96, 24);
            this.txtExchange3.Name = "txtExchange3";
            this.txtExchange3.Size = new System.Drawing.Size(96, 20);
            this.txtExchange3.TabIndex = 64;
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
            // txtContract3
            // 
            this.txtContract3.Location = new System.Drawing.Point(96, 96);
            this.txtContract3.Name = "txtContract3";
            this.txtContract3.Size = new System.Drawing.Size(96, 20);
            this.txtContract3.TabIndex = 67;
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
            // gboContract4
            // 
            this.gboContract4.Controls.Add(this.lblExchange4);
            this.gboContract4.Controls.Add(this.txtProduct4);
            this.gboContract4.Controls.Add(this.txtProductType4);
            this.gboContract4.Controls.Add(this.lblContract4);
            this.gboContract4.Controls.Add(this.txtExchange4);
            this.gboContract4.Controls.Add(this.lblProduct4);
            this.gboContract4.Controls.Add(this.txtContract4);
            this.gboContract4.Controls.Add(this.lblProductType4);
            this.gboContract4.Controls.Add(this.txtPL4);
            this.gboContract4.Controls.Add(this.lblPL4);
            this.gboContract4.Controls.Add(this.txtNetPosition4);
            this.gboContract4.Controls.Add(this.lblNetPosition4);
            this.gboContract4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gboContract4.Location = new System.Drawing.Point(225, 252);
            this.gboContract4.Name = "gboContract4";
            this.gboContract4.Size = new System.Drawing.Size(208, 186);
            this.gboContract4.TabIndex = 74;
            this.gboContract4.TabStop = false;
            this.gboContract4.Text = "Contract 4";
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
            // txtProduct4
            // 
            this.txtProduct4.Location = new System.Drawing.Point(96, 48);
            this.txtProduct4.Name = "txtProduct4";
            this.txtProduct4.Size = new System.Drawing.Size(96, 20);
            this.txtProduct4.TabIndex = 65;
            // 
            // txtProductType4
            // 
            this.txtProductType4.Location = new System.Drawing.Point(96, 72);
            this.txtProductType4.Name = "txtProductType4";
            this.txtProductType4.Size = new System.Drawing.Size(96, 20);
            this.txtProductType4.TabIndex = 66;
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
            // txtExchange4
            // 
            this.txtExchange4.Location = new System.Drawing.Point(96, 24);
            this.txtExchange4.Name = "txtExchange4";
            this.txtExchange4.Size = new System.Drawing.Size(96, 20);
            this.txtExchange4.TabIndex = 64;
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
            // txtContract4
            // 
            this.txtContract4.Location = new System.Drawing.Point(96, 96);
            this.txtContract4.Name = "txtContract4";
            this.txtContract4.Size = new System.Drawing.Size(96, 20);
            this.txtContract4.TabIndex = 67;
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
            // txtPL4
            // 
            this.txtPL4.Location = new System.Drawing.Point(120, 128);
            this.txtPL4.Name = "txtPL4";
            this.txtPL4.Size = new System.Drawing.Size(72, 20);
            this.txtPL4.TabIndex = 76;
            // 
            // lblPL4
            // 
            this.lblPL4.Location = new System.Drawing.Point(32, 130);
            this.lblPL4.Name = "lblPL4";
            this.lblPL4.Size = new System.Drawing.Size(80, 16);
            this.lblPL4.TabIndex = 74;
            this.lblPL4.Text = "P/L:";
            this.lblPL4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNetPosition4
            // 
            this.txtNetPosition4.Location = new System.Drawing.Point(120, 152);
            this.txtNetPosition4.Name = "txtNetPosition4";
            this.txtNetPosition4.Size = new System.Drawing.Size(72, 20);
            this.txtNetPosition4.TabIndex = 77;
            // 
            // lblNetPosition4
            // 
            this.lblNetPosition4.Location = new System.Drawing.Point(24, 154);
            this.lblNetPosition4.Name = "lblNetPosition4";
            this.lblNetPosition4.Size = new System.Drawing.Size(88, 16);
            this.lblNetPosition4.TabIndex = 75;
            this.lblNetPosition4.Text = "Net Position:";
            this.lblNetPosition4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.lblNotProduction.Location = new System.Drawing.Point(12, 34);
            this.lblNotProduction.Name = "lblNotProduction";
            this.lblNotProduction.Size = new System.Drawing.Size(422, 14);
            this.lblNotProduction.TabIndex = 76;
            this.lblNotProduction.Text = "This sample is NOT to be used in production or during conformance testing.";
            this.lblNotProduction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWarning
            // 
            this.lblWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarning.Location = new System.Drawing.Point(12, 9);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(422, 23);
            this.lblWarning.TabIndex = 75;
            this.lblWarning.Text = "WARNING!";
            this.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmProfitLoss
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(445, 472);
            this.Controls.Add(this.lblNotProduction);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.gboContract4);
            this.Controls.Add(this.gboContract3);
            this.Controls.Add(this.gboContract2);
            this.Controls.Add(this.sbaStatus);
            this.Controls.Add(this.gboContract1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Menu = this.mainMenu1;
            this.Name = "frmProfitLoss";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProfitLoss";
            this.gboContract2.ResumeLayout(false);
            this.gboContract2.PerformLayout();
            this.gboContract1.ResumeLayout(false);
            this.gboContract1.PerformLayout();
            this.gboContract3.ResumeLayout(false);
            this.gboContract3.PerformLayout();
            this.gboContract4.ResumeLayout(false);
            this.gboContract4.PerformLayout();
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
			Application.Run(new frmProfitLoss());
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
				// Obtain the number of instruments dropped.
				int instrCount = m_TTDropHandler.Count;

				// Only support a maximum of four instruments.
                if (instrCount > 4)
                {
                    instrCount = 4;
                }

				for (int i=0; i<instrCount; i++)
				{
					// Test is TTInstrObj currently exist.
					if (m_TTInstrObj[i] != null)
					{
						// Remove the Instrument and reset the Alias.
						m_TTInstrNotify.DetachInstrument(m_TTInstrObj[i]);
						m_TTInstrObj[i].Alias = "";
						m_TTInstrObj[i] = null;
					}

                    // Obtain the TTInstrObj from the TTDropHandler object.
                    // The TTDropHandler index begins at 1.
                    m_TTInstrObj[i] = (XTAPI.TTInstrObj)m_TTDropHandler[i + 1];	

					// Attach the TTInstrObj to the TTInstrNotify.
					m_TTInstrNotify.AttachInstrument(m_TTInstrObj[i]);
					
					// Set the TTInstrObj Alias to the index for identification.
					m_TTInstrObj[i].Alias = i.ToString();

					// Open the TTInstrObj with depth disabled.								
					m_TTInstrObj[i].Open(0);

					// Instantiate the TTOrderSet object.
					m_TTOrderSet = new XTAPI.TTOrderSetClass();

					// Set the OrderSelector to the instrument so that P/L per contract
					// will be displayed.  If omitted the overall P/L per user will be displayed.
					m_TTOrderSet.OrderSelector = m_TTInstrObj[i].CreateOrderSelector;

                    m_TTOrderSet.EnableFillCaching = 1;
                    m_TTOrderSet.AvgOpenPriceMode = XTAPI.enumAvgOpenPriceMode.LIFO;

					// Attach the TTOrderSet to the TTInstrObj.
					m_TTInstrObj[i].OrderSet = m_TTOrderSet;
					// Open the TTOrderSet.
					m_TTInstrObj[i].OrderSet.Open(0);
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
			// Update the Status Bar text.
			sbaStatus.Text = "Instrument Found.";

			// Retrieve and display the instrument information.
			Array data = (Array) pInstr.get_Get("Exchange,Product,ProdType,Contract");					
			
			// Test based on Alias property
			switch (pInstr.Alias)
			{
				case "0":
					txtExchange1.Text = (string)data.GetValue(0);
					txtProduct1.Text = (string)data.GetValue(1);
					txtProductType1.Text = (string)data.GetValue(2);
					txtContract1.Text = (string)data.GetValue(3);					
					break;
				case "1":
					txtExchange2.Text = (string)data.GetValue(0);
					txtProduct2.Text = (string)data.GetValue(1);
					txtProductType2.Text = (string)data.GetValue(2);
					txtContract2.Text = (string)data.GetValue(3);					
					break;
				case "2":
					txtExchange3.Text = (string)data.GetValue(0);
					txtProduct3.Text = (string)data.GetValue(1);
					txtProductType3.Text = (string)data.GetValue(2);
					txtContract3.Text = (string)data.GetValue(3);					
					break;
				case "3":
					txtExchange4.Text = (string)data.GetValue(0);
					txtProduct4.Text = (string)data.GetValue(1);
					txtProductType4.Text = (string)data.GetValue(2);
					txtContract4.Text = (string)data.GetValue(3);					
					break;
				default:
					MessageBox.Show(this,"DisplayInstrumentInformation ERROR");
					break;
			}

		}

        /// <summary>
        /// This function is called when an instrument update occurs (i.e. LTP changes).
        /// </summary>
        /// <param name="pNotify">TTInstrNotify object</param>
        /// <param name="pInstr">TTInstrObj object</param>
		private void m_TTInstrNotify_OnNotifyUpdate(XTAPI.TTInstrNotify pNotify, XTAPI.TTInstrObj pInstr)
		{			
			// Update the P/L text boxes.
			DisplayPLInformation(pInstr);
		}

        /// <summary>
        /// This function is called when the TTOrderSet is opened and
        /// for every order placed by the user.
        /// </summary>
        /// <param name="pNotify">TTInstrNotify object</param>
        /// <param name="pInstr">TTInstrObj object</param>
        /// <param name="pOrderSet">TTOrderSetObj object</param>
		private void m_TTInstrNotify_OnOrderSetUpdate(XTAPI.TTInstrNotify pNotify, XTAPI.TTInstrObj pInstr, XTAPI.TTOrderSet pOrderSet)
		{
			// Update the P/L text boxes.
			DisplayPLInformation(pInstr);
		}

        /// <summary>
        /// Display the profit and loss and net position for each instrument.
        /// </summary>
        /// <param name="pInstr">TTInstrObj object</param>
		private void DisplayPLInformation(XTAPI.TTInstrObj pInstr)
		{	
			// Get the P/L and Net Position per instrument.
			Array data = (Array) pInstr.get_Get("PL$,NetPos");
			
			switch (pInstr.Alias)
			{
				case "0":
					txtPL1.Text = Convert.ToString(data.GetValue(0));	
					txtNetPosition1.Text = Convert.ToString(data.GetValue(1));
					break;
				case "1":
                    txtPL2.Text = Convert.ToString(data.GetValue(0));	
					txtNetPosition2.Text = Convert.ToString(data.GetValue(1));
					break;
				case "2":
                    txtPL3.Text = Convert.ToString(data.GetValue(0));	
					txtNetPosition3.Text = Convert.ToString(data.GetValue(1));
					break;
				case "3":
                    txtPL4.Text = Convert.ToString(data.GetValue(0));	
					txtNetPosition4.Text = Convert.ToString(data.GetValue(1));
					break;
				default:
					MessageBox.Show(this,"PL ERROR");
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
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
	/// FillUpdate
    /// 
    /// This example demonstrates using the XTAPI to retrieve fills for the
    /// authenticated X_TRADER user.
	/// </summary>
	public class frmFillUpdate : Form
    {
        // Declare the XTAPI objects.
		private XTAPI.TTOrderSetClass m_TTOrderSet = null;

        /// <summary>
        /// Initialize the TTOrderSet object and subscribe to the three fill events.
        /// </summary>
		public frmFillUpdate()
		{
			// Required for Windows Form Designer support
			InitializeComponent();

			// Update the Status Bar text.
			sbaStatus.Text = "Downloading Fill Information...  (This may take a moment)";

			// Instantiate the TTOrderSet object.
			m_TTOrderSet = new XTAPI.TTOrderSetClass();	

			// Enable the fill updates.
			m_TTOrderSet.EnableOrderFillData = 1;	

			// Subscribe to the fill events.
			m_TTOrderSet.OnOrderFillData += new XTAPI._ITTOrderSetEvents_OnOrderFillDataEventHandler(m_TTOrderSet_OnOrderFillData);
			m_TTOrderSet.OnOrderFillBlockEnd += new XTAPI._ITTOrderSetEvents_OnOrderFillBlockEndEventHandler(m_TTOrderSet_OnOrderFillBlockEnd);
			m_TTOrderSet.OnOrderFillBlockStart += new XTAPI._ITTOrderSetEvents_OnOrderFillBlockStartEventHandler(m_TTOrderSet_OnOrderFillBlockStart);	
            
			// Open the TTOrderSet with sending orders disabled.
			m_TTOrderSet.Open(0);

			// Print the TTFillObj Get properties header to the text box.
			txtFillData.Text += "Contract,  Price,  Qty,  FillType,  OrderNo,  SiteOrderKey\r\n\r\n";
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
        private System.Windows.Forms.TextBox txtFillData;
        private System.Windows.Forms.GroupBox gboFillData;
        private System.Windows.Forms.Label lblNotProduction;
        private System.Windows.Forms.Label lblWarning;

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
            this.txtFillData = new System.Windows.Forms.TextBox();
            this.gboFillData = new System.Windows.Forms.GroupBox();
            this.lblNotProduction = new System.Windows.Forms.Label();
            this.lblWarning = new System.Windows.Forms.Label();
            this.gboFillData.SuspendLayout();
            this.SuspendLayout();
            // 
            // sbaStatus
            // 
            this.sbaStatus.Location = new System.Drawing.Point(0, 396);
            this.sbaStatus.Name = "sbaStatus";
            this.sbaStatus.Size = new System.Drawing.Size(432, 22);
            this.sbaStatus.SizingGrip = false;
            this.sbaStatus.TabIndex = 109;
            this.sbaStatus.Text = "status bar text";
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
            // txtFillData
            // 
            this.txtFillData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFillData.Location = new System.Drawing.Point(16, 24);
            this.txtFillData.Multiline = true;
            this.txtFillData.Name = "txtFillData";
            this.txtFillData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFillData.Size = new System.Drawing.Size(384, 290);
            this.txtFillData.TabIndex = 110;
            // 
            // gboFillData
            // 
            this.gboFillData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gboFillData.Controls.Add(this.txtFillData);
            this.gboFillData.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gboFillData.Location = new System.Drawing.Point(8, 58);
            this.gboFillData.Name = "gboFillData";
            this.gboFillData.Size = new System.Drawing.Size(416, 330);
            this.gboFillData.TabIndex = 111;
            this.gboFillData.TabStop = false;
            this.gboFillData.Text = "Fill Data";
            // 
            // lblNotProduction
            // 
            this.lblNotProduction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotProduction.Location = new System.Drawing.Point(4, 34);
            this.lblNotProduction.Name = "lblNotProduction";
            this.lblNotProduction.Size = new System.Drawing.Size(420, 14);
            this.lblNotProduction.TabIndex = 113;
            this.lblNotProduction.Text = "This sample is NOT to be used in production or during conformance testing.";
            this.lblNotProduction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWarning
            // 
            this.lblWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarning.Location = new System.Drawing.Point(4, 9);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(420, 23);
            this.lblWarning.TabIndex = 112;
            this.lblWarning.Text = "WARNING!";
            this.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmFillUpdate
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(432, 418);
            this.Controls.Add(this.lblNotProduction);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.gboFillData);
            this.Controls.Add(this.sbaStatus);
            this.Menu = this.mainMenu1;
            this.Name = "frmFillUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FillUpdate";
            this.gboFillData.ResumeLayout(false);
            this.gboFillData.PerformLayout();
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
			Application.Run(new frmFillUpdate());
		}

        /// <summary>
        /// This function is called for every fill update.  Obtain the fill 
        /// information by calling the Get() properties from the TTFillObj 
        /// passed as an argument.   
        /// </summary>
        /// <param name="pFillObj">XTAPI Fill Object</param>
		private void m_TTOrderSet_OnOrderFillData(XTAPI.TTFillObj pFillObj)
		{
			// Update the Status Bar text.
			sbaStatus.Text = "Fill Recieved.";

			// Retrieve the fill information using the TTFillObj Get Properties.
			Array fillData = (Array) pFillObj.get_Get("Contract,Price,Qty,FillType,OrderNo,SiteOrderKey");

			txtFillData.Text += (string)fillData.GetValue(0) + ",  ";
			txtFillData.Text += (string)fillData.GetValue(1) + ",  ";
            txtFillData.Text += Convert.ToString(fillData.GetValue(2)) + ",  ";
			txtFillData.Text += (string)fillData.GetValue(3) + ",  ";	
			txtFillData.Text += (string)fillData.GetValue(4) + ",  ";
			txtFillData.Text += (string)fillData.GetValue(5) + "\r\n";
		}

        /// <summary>
        /// This function is called when a set of fills is about to be sent.  
        /// </summary>
		private void m_TTOrderSet_OnOrderFillBlockStart()
		{
			// Update the text box.
			txtFillData.Text += "FillBlockStart\r\n";
		}

        /// <summary>
        /// This function is called when a set of fills has been delivered. 
        /// </summary>
		private void m_TTOrderSet_OnOrderFillBlockEnd()
		{
			// Update the text box.
			txtFillData.Text += "FillBlockEnd\r\n";
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
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
	/// HotKey
    /// 
    /// This example demonstrates using the XTAPI capture a specific keystroke from the
    /// users keyboard.
	/// </summary>
	public class frmHotKey : Form
	{
        // Declare XTAPI variables.
		private XTAPI.TTHotKeyNotify m_hotKey;

		/// <summary>
        /// Setup the TTHotKey and subscibe to the event.
		/// </summary>
		public frmHotKey()
		{
			// Required for Windows Form Designer support
			InitializeComponent();

			m_hotKey = new XTAPI.TTHotKeyNotifyClass();
            m_hotKey.OnHotKey += new XTAPI._ITTHotKeyNotifyEvents_OnHotKeyEventHandler(XTOnHotKey);
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
        private System.Windows.Forms.ListBox lboDisplay;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem mnuAbout;
        private System.Windows.Forms.StatusBar sbaStatus;

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.lboDisplay = new System.Windows.Forms.ListBox();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.mnuAbout = new System.Windows.Forms.MenuItem();
            this.sbaStatus = new System.Windows.Forms.StatusBar();
            this.SuspendLayout();
            // 
            // lboDisplay
            // 
            this.lboDisplay.Items.AddRange(new object[] {
            "\"b\" - Buy",
            "\"s\" - Sell",
            "\"CTRL-d\" - Delete all orders",
            "---------------------------------------------------------"});
            this.lboDisplay.Location = new System.Drawing.Point(8, 8);
            this.lboDisplay.Name = "lboDisplay";
            this.lboDisplay.Size = new System.Drawing.Size(272, 251);
            this.lboDisplay.TabIndex = 0;
            this.lboDisplay.TabStop = false;
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
            // sbaStatus
            // 
            this.sbaStatus.Location = new System.Drawing.Point(0, 266);
            this.sbaStatus.Name = "sbaStatus";
            this.sbaStatus.Size = new System.Drawing.Size(288, 22);
            this.sbaStatus.SizingGrip = false;
            this.sbaStatus.TabIndex = 64;
            this.sbaStatus.Text = "Click a key to trigger the HotKey event.";
            // 
            // frmHotKey
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(288, 288);
            this.Controls.Add(this.sbaStatus);
            this.Controls.Add(this.lboDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Menu = this.mainMenu1;
            this.Name = "frmHotKey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HotKey";
            this.Load += new System.EventHandler(this.frmHotKey_Load);
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
			Application.Run(new frmHotKey());
		}

        /// <summary>
        /// Triggered when a registered HotKey is pressed
        /// </summary>
        /// <param name="str">Name of the key pressed</param>
        private void XTOnHotKey(String keyName)
        {
            if (keyName.Equals("Buy"))
            {
                this.lboDisplay.Items.Add(string.Format("The 'b' key was pressed."));
            }
            else if (keyName.Equals("Sell"))
            {
                this.lboDisplay.Items.Add(string.Format("The 's' key was pressed."));
            }
            else if (keyName.Equals("Delete"))
            {
                this.lboDisplay.Items.Add(string.Format("The 'Ctrl-d' key was pressed."));
            }
            else if (keyName.Equals("F1 Key"))
            {
                this.lboDisplay.Items.Add(string.Format("The 'F1' key was pressed."));
            }
        }

        /// <summary>
        /// Registers HotKey events upon form loading
        /// </summary>
        private void frmHotKey_Load(object sender, EventArgs e)
        {
            try
            {
                // AddHotKey method parameters
                //
                // 1)  "Buy" is the string passed to the event function
                // 2)  "B" is the key which invokes the event
                // 3)  0 is the modifier key (e.g. ALT=1)
                //
                // Note:    Valid modifiers are ALT = 1, CTRL = 2, SHIFT = 4, WIN = 8.  
                //          WIN is not supported in .NET applications.
                m_hotKey.AddHotKey("Buy", "B", 0);
                m_hotKey.AddHotKey("Sell", "S", 0);

                // HotKey using the CTRL modifier
                m_hotKey.AddHotKey("Delete", "D", 8);

                // HotKey for non-ASCII characters
                //
                // For more information about non-ASCII characters, see: 
                // https://www.tradingtechnologies.com/support/knowledge-base/2/2763/
                m_hotKey.AddHotKey("F1 Key", Convert.ToString(Convert.ToChar(0x70)), 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }

		/// <summary>
        /// This function displays the About dialog box.
		/// </summary>
		private void AboutMenuItem_Click(object sender, System.EventArgs e)
		{
			About aboutForm = new About();
			aboutForm.ShowDialog(this);
		}
	}
}
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
    /// ServerMode
    /// 
	/// This example demonstrates using the XTAPI in Server Mode to monitor order
	/// actions.  Settings EnableServerMode also requires the application to 
	/// authenticate using SetUniversalLogin.
	/// 
	/// Note:	Server Mode allows XTAPI applications to run independent of X_TRADER.
	/// 		Since X_TRADER is not required, a Server Mode XTAPI application will
	/// 		consume it's own X_TRADER Pro license, and orders cannot be placed or
    /// 		modified.
	/// </summary>
	public class frmServerMode : System.Windows.Forms.Form
	{
        // Declare the XTAPI objects
		private XTAPI.TTGateClass m_TTGate = null;
		private XTAPI.TTOrderSetClass m_TTOrderSet = null;

		/// <summary>
		/// Upon the application form loading, setup the TTGate and TTOrderSet objects.
		/// </summary>
		public frmServerMode()
		{
			// Required for Windows Form Designer support
			InitializeComponent();

			// Instantiate the TTGate.
			m_TTGate = new XTAPI.TTGateClass();
			
			// Enable Server Mode (X_TRADER does not need to be running).
			m_TTGate.EnableServerMode();

			// Instantiate the TTOrderSet object.
			m_TTOrderSet = new XTAPI.TTOrderSetClass();

            // Set normal level of detail in our order status events
            m_TTOrderSet.OrderStatusNotifyMode = XTAPI.enumOrderStatusNotifyMode.ORD_NOTIFY_NORMAL;

            // Subscribe to OrderSet events (for all available events, see the OrderUpdate sample)
            m_TTOrderSet.OnOrderSubmitted += new XTAPI._ITTOrderSetEvents_OnOrderSubmittedEventHandler(m_TTOrderSet_OnOrderSubmitted);
            m_TTOrderSet.OnOrderUpdated += new XTAPI._ITTOrderSetEvents_OnOrderUpdatedEventHandler(m_TTOrderSet_OnOrderUpdated);
            m_TTOrderSet.OnOrderDeleted += new XTAPI._ITTOrderSetEvents_OnOrderDeletedEventHandler(m_TTOrderSet_OnOrderDeleted);
            m_TTOrderSet.OnOrderFilled += new XTAPI._ITTOrderSetEvents_OnOrderFilledEventHandler(m_TTOrderSet_OnOrderFilled);

			txtOrderAuditTrail.Text = "Order State:   Acct, OrdStatus, OrdAction, Contract$, BuySell, OrderQty, Price, SiteOrderKey, OrderNo\r\n\r\n";
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
            // Close XTAPI objects
			m_TTOrderSet.Close();
			m_TTGate.XTAPITerminate();
			
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
        private System.Windows.Forms.GroupBox gboOrderAuditTrail;
        private System.Windows.Forms.GroupBox gboUniversalLogin;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtOrderAuditTrail;

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
            this.gboOrderAuditTrail = new System.Windows.Forms.GroupBox();
            this.txtOrderAuditTrail = new System.Windows.Forms.TextBox();
            this.gboUniversalLogin = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.gboOrderAuditTrail.SuspendLayout();
            this.gboUniversalLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // sbaStatus
            // 
            this.sbaStatus.Location = new System.Drawing.Point(0, 210);
            this.sbaStatus.Name = "sbaStatus";
            this.sbaStatus.Size = new System.Drawing.Size(794, 22);
            this.sbaStatus.SizingGrip = false;
            this.sbaStatus.TabIndex = 63;
            this.sbaStatus.Text = "Enter the Server Mode login information and click the Connect button.";
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
            // gboOrderAuditTrail
            // 
            this.gboOrderAuditTrail.Controls.Add(this.txtOrderAuditTrail);
            this.gboOrderAuditTrail.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gboOrderAuditTrail.Location = new System.Drawing.Point(232, 8);
            this.gboOrderAuditTrail.Name = "gboOrderAuditTrail";
            this.gboOrderAuditTrail.Size = new System.Drawing.Size(552, 192);
            this.gboOrderAuditTrail.TabIndex = 67;
            this.gboOrderAuditTrail.TabStop = false;
            this.gboOrderAuditTrail.Text = "Order Audit Trail";
            // 
            // txtOrderAuditTrail
            // 
            this.txtOrderAuditTrail.Location = new System.Drawing.Point(6, 19);
            this.txtOrderAuditTrail.Multiline = true;
            this.txtOrderAuditTrail.Name = "txtOrderAuditTrail";
            this.txtOrderAuditTrail.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOrderAuditTrail.Size = new System.Drawing.Size(540, 167);
            this.txtOrderAuditTrail.TabIndex = 4;
            this.txtOrderAuditTrail.WordWrap = false;
            // 
            // gboUniversalLogin
            // 
            this.gboUniversalLogin.Controls.Add(this.txtPassword);
            this.gboUniversalLogin.Controls.Add(this.lblPassword);
            this.gboUniversalLogin.Controls.Add(this.lblUsername);
            this.gboUniversalLogin.Controls.Add(this.txtUsername);
            this.gboUniversalLogin.Controls.Add(this.btnConnect);
            this.gboUniversalLogin.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gboUniversalLogin.Location = new System.Drawing.Point(8, 8);
            this.gboUniversalLogin.Name = "gboUniversalLogin";
            this.gboUniversalLogin.Size = new System.Drawing.Size(216, 192);
            this.gboUniversalLogin.TabIndex = 70;
            this.gboUniversalLogin.TabStop = false;
            this.gboUniversalLogin.Text = "Universal Login";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(84, 50);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(126, 20);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(6, 51);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(72, 16);
            this.lblPassword.TabIndex = 60;
            this.lblPassword.Text = "Password:";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUsername
            // 
            this.lblUsername.Location = new System.Drawing.Point(14, 23);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(64, 16);
            this.lblUsername.TabIndex = 52;
            this.lblUsername.Text = "Username:";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(84, 24);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(126, 20);
            this.txtUsername.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnConnect.Location = new System.Drawing.Point(130, 76);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(80, 23);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // frmServerMode
            // 
            this.AcceptButton = this.btnConnect;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(794, 232);
            this.Controls.Add(this.gboUniversalLogin);
            this.Controls.Add(this.gboOrderAuditTrail);
            this.Controls.Add(this.sbaStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Menu = this.mainMenu1;
            this.Name = "frmServerMode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MonitorOrders";
            this.gboOrderAuditTrail.ResumeLayout(false);
            this.gboOrderAuditTrail.PerformLayout();
            this.gboUniversalLogin.ResumeLayout(false);
            this.gboUniversalLogin.PerformLayout();
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
			Application.Run(new frmServerMode());
		}
	
		/// <summary>
		/// Retrieve the login information and connect
		/// </summary>
		private void ConnectButton_Click(object sender, System.EventArgs e)
		{
            try
            {
                // Attempt to authenticate
                m_TTGate.SetUniversalLogin(txtUsername.Text, txtPassword.Text);
            }
            catch (Exception ex)
            {
                // Display exception message.
                MessageBox.Show(ex.Message, "Exception - Failed to Authenticate");

                // Login failed - abort
                return;
            }

			// Open the TTOrderSet with sending orders disabled.
			m_TTOrderSet.Open(0);

			sbaStatus.Text = "Authenticated";
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
            PublishEventOrderData("OnOrderSubmitted", pNewOrderObj, pOldOrderObj);
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
            PublishEventOrderData("OnOrderUpdated", pNewOrderObj, pOldOrderObj);
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
            PublishEventOrderData("OnOrderDeleted", pNewOrderObj, pOldOrderObj);
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
            PublishEventOrderData("OnOrderFilled", pNewOrderObj, pOldOrderObj);
        }

        /// <summary>
        /// Publish specific information about each order to the GUI
        /// </summary>
        /// <param name="callingMethod">Method that called the publish</param>
        /// <param name="pNewOrderObj">New order object</param>
        /// <param name="pOldOrderObj">Old order object</param>
        private void PublishEventOrderData(string callingMethod, XTAPI.TTOrderObj pNewOrderObj, XTAPI.TTOrderObj pOldOrderObj)
        {
            if (pOldOrderObj.IsNull != 0)
            {
                txtOrderAuditTrail.Text += callingMethod + " - Old Order: NULL\r\n";
            }
            else
            {
                try
                {
                    Array oldOrderData = (Array)pOldOrderObj.get_Get("Acct,OrdStatus,OrdAction,Contract$,BuySell,OrderQty,Price,SiteOrderKey,OrderNo");

                    txtOrderAuditTrail.Text += callingMethod + " - Old Order: " + oldOrderData.GetValue(0).ToString() + ", " +
                                                                                  oldOrderData.GetValue(1).ToString() + ", " +
                                                                                  oldOrderData.GetValue(2).ToString() + ", " +
                                                                                  oldOrderData.GetValue(3).ToString() + ", " +
                                                                                  oldOrderData.GetValue(4).ToString() + ", " +
                                                                                  oldOrderData.GetValue(5).ToString() + ", " +
                                                                                  oldOrderData.GetValue(6).ToString() + ", " +
                                                                                  oldOrderData.GetValue(7).ToString() + ", " +
                                                                                  oldOrderData.GetValue(8).ToString() + "\r\n";
                }
                catch (Exception ex)
                {
                    txtOrderAuditTrail.Text += callingMethod + " - Old Order: Error Message - " + ex.Message + "\r\n";
                }
            }

            if (pNewOrderObj.IsNull != 0)
            {
                txtOrderAuditTrail.Text += callingMethod + " - New Order: NULL\r\n";
            }
            else
            {
                try
                {
                    Array newOrderData = (Array)pNewOrderObj.get_Get("Acct,OrdStatus,OrdAction,Contract$,BuySell,OrderQty,Price,SiteOrderKey,OrderNo");

                    txtOrderAuditTrail.Text += callingMethod + " - New Order: " + newOrderData.GetValue(0).ToString() + ", " +
                                                                                  newOrderData.GetValue(1).ToString() + ", " +
                                                                                  newOrderData.GetValue(2).ToString() + ", " +
                                                                                  newOrderData.GetValue(3).ToString() + ", " +
                                                                                  newOrderData.GetValue(4).ToString() + ", " +
                                                                                  newOrderData.GetValue(5).ToString() + ", " +
                                                                                  newOrderData.GetValue(6).ToString() + ", " +
                                                                                  newOrderData.GetValue(7).ToString() + ", " +
                                                                                  newOrderData.GetValue(8).ToString() + "\r\n";
                }
                catch (Exception ex)
                {
                    txtOrderAuditTrail.Text += callingMethod + " - New Order: Error Message - " + ex.Message + "\r\n";
                }
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
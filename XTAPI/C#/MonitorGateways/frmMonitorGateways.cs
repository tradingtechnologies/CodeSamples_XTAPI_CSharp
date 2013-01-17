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
using System.Collections.Generic;

namespace XTAPI_Samples
{
	/// <summary>
    /// MonitorGateways
    /// 
    /// This example demonstrates using the XTAPI to monitor the status of TT Gateways.
	/// </summary>
	public class frmMonitorGateways : Form
	{
        // Declare the XTAPI objects.
		private XTAPI.TTGateClass m_TTGate = null;

		// Class member variables
        private Dictionary<String, GatewayStatusData> m_gatewayStatus = null;

		/// <summary>
		/// Upon the application form loading, setup the TTGate object and subscribe to the events.
		/// </summary>
		public frmMonitorGateways()
		{
			// Required for Windows Form Designer support
			InitializeComponent();

			// This ArrayList will contain all of the available TT Gateways and their current state.
            m_gatewayStatus = new Dictionary<String, GatewayStatusData>();

			// Instantiate the TTGate and subscribe to gateway status events.
			m_TTGate = new XTAPI.TTGateClass();
			m_TTGate.OnExchangeStateUpdate += new XTAPI._ITTGateEvents_OnExchangeStateUpdateEventHandler(m_TTGate_OnExchangeStateUpdate);
			m_TTGate.OnStatusUpdate += new XTAPI._ITTGateEvents_OnStatusUpdateEventHandler(m_TTGate_OnStatusUpdate);
			m_TTGate.OnExchangeMessage += new XTAPI._ITTGateEvents_OnExchangeMessageEventHandler(m_TTGate_OnExchangeMessage);
		
			// Print text box headers.
			txtOnExchangeStateUpdateOutput.Text = "sExchange,  sText,  bOpenned,  bServerUp\r\n";
			txtOnStatusUpdateOutput.Text = "lHintMask,  sText\r\n";
			txtOnExchangeMessageOutput.Text = "sExchange,  sTimeStamp,  sInfo,  sText\r\n";
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
        private System.Windows.Forms.GroupBox gboOnExchangeStateUpdate;
        private System.Windows.Forms.Label lblPriceConnection;
        private System.Windows.Forms.Label lblOrderConnection;
        private System.Windows.Forms.Label lblFillConnection;
        private System.Windows.Forms.Label lblPriceConnectionValue;
        private System.Windows.Forms.Label lblOrderConnectionValue;
        private System.Windows.Forms.Label lblFillConnectionValue;
        private System.Windows.Forms.GroupBox gboOnStatusUpdate;
        private System.Windows.Forms.GroupBox gboOnExchangeMessage;
        private System.Windows.Forms.TextBox txtOnExchangeStateUpdateOutput;
        private System.Windows.Forms.TextBox txtOnStatusUpdateOutput;
        private System.Windows.Forms.TextBox txtOnExchangeMessageOutput;
        private System.Windows.Forms.GroupBox gboGatewayConnections;
        private System.Windows.Forms.Label lblAvailableGateways;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cboAvailableGateways;
        private System.Windows.Forms.GroupBox gboGatewayStatus;
        private System.Windows.Forms.CheckBox chkOpenPriceServer;
        private System.Windows.Forms.CheckBox chkOpenOrderServer;
        private System.Windows.Forms.CheckBox chkOpenFillServer;
        private System.Windows.Forms.GroupBox gboXTraderStatus;
        private System.Windows.Forms.Label lblXTrader;
        private System.Windows.Forms.Label lblXTraderPro;
        private System.Windows.Forms.Label lblXTraderProValue;
        private System.Windows.Forms.Label lblXTraderValue;

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
            this.gboOnExchangeStateUpdate = new System.Windows.Forms.GroupBox();
            this.txtOnExchangeStateUpdateOutput = new System.Windows.Forms.TextBox();
            this.gboGatewayStatus = new System.Windows.Forms.GroupBox();
            this.lblFillConnectionValue = new System.Windows.Forms.Label();
            this.lblOrderConnectionValue = new System.Windows.Forms.Label();
            this.lblPriceConnectionValue = new System.Windows.Forms.Label();
            this.lblFillConnection = new System.Windows.Forms.Label();
            this.lblPriceConnection = new System.Windows.Forms.Label();
            this.lblOrderConnection = new System.Windows.Forms.Label();
            this.gboOnStatusUpdate = new System.Windows.Forms.GroupBox();
            this.txtOnStatusUpdateOutput = new System.Windows.Forms.TextBox();
            this.gboOnExchangeMessage = new System.Windows.Forms.GroupBox();
            this.txtOnExchangeMessageOutput = new System.Windows.Forms.TextBox();
            this.gboGatewayConnections = new System.Windows.Forms.GroupBox();
            this.chkOpenFillServer = new System.Windows.Forms.CheckBox();
            this.chkOpenOrderServer = new System.Windows.Forms.CheckBox();
            this.chkOpenPriceServer = new System.Windows.Forms.CheckBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblAvailableGateways = new System.Windows.Forms.Label();
            this.cboAvailableGateways = new System.Windows.Forms.ComboBox();
            this.gboXTraderStatus = new System.Windows.Forms.GroupBox();
            this.lblXTraderProValue = new System.Windows.Forms.Label();
            this.lblXTraderValue = new System.Windows.Forms.Label();
            this.lblXTrader = new System.Windows.Forms.Label();
            this.lblXTraderPro = new System.Windows.Forms.Label();
            this.gboOnExchangeStateUpdate.SuspendLayout();
            this.gboGatewayStatus.SuspendLayout();
            this.gboOnStatusUpdate.SuspendLayout();
            this.gboOnExchangeMessage.SuspendLayout();
            this.gboGatewayConnections.SuspendLayout();
            this.gboXTraderStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // sbaStatus
            // 
            this.sbaStatus.Location = new System.Drawing.Point(0, 490);
            this.sbaStatus.Name = "sbaStatus";
            this.sbaStatus.Size = new System.Drawing.Size(522, 22);
            this.sbaStatus.SizingGrip = false;
            this.sbaStatus.TabIndex = 63;
            this.sbaStatus.Text = "Select a TT Gateways a click the Connect button.";
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
            // gboOnExchangeStateUpdate
            // 
            this.gboOnExchangeStateUpdate.Controls.Add(this.txtOnExchangeStateUpdateOutput);
            this.gboOnExchangeStateUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gboOnExchangeStateUpdate.Location = new System.Drawing.Point(8, 184);
            this.gboOnExchangeStateUpdate.Name = "gboOnExchangeStateUpdate";
            this.gboOnExchangeStateUpdate.Size = new System.Drawing.Size(248, 144);
            this.gboOnExchangeStateUpdate.TabIndex = 67;
            this.gboOnExchangeStateUpdate.TabStop = false;
            this.gboOnExchangeStateUpdate.Text = "OnExchangeStateUpdate Output";
            // 
            // txtOnExchangeStateUpdateOutput
            // 
            this.txtOnExchangeStateUpdateOutput.Location = new System.Drawing.Point(16, 24);
            this.txtOnExchangeStateUpdateOutput.Multiline = true;
            this.txtOnExchangeStateUpdateOutput.Name = "txtOnExchangeStateUpdateOutput";
            this.txtOnExchangeStateUpdateOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOnExchangeStateUpdateOutput.Size = new System.Drawing.Size(216, 104);
            this.txtOnExchangeStateUpdateOutput.TabIndex = 0;
            this.txtOnExchangeStateUpdateOutput.WordWrap = false;
            // 
            // gboGatewayStatus
            // 
            this.gboGatewayStatus.Controls.Add(this.lblFillConnectionValue);
            this.gboGatewayStatus.Controls.Add(this.lblOrderConnectionValue);
            this.gboGatewayStatus.Controls.Add(this.lblPriceConnectionValue);
            this.gboGatewayStatus.Controls.Add(this.lblFillConnection);
            this.gboGatewayStatus.Controls.Add(this.lblPriceConnection);
            this.gboGatewayStatus.Controls.Add(this.lblOrderConnection);
            this.gboGatewayStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gboGatewayStatus.Location = new System.Drawing.Point(296, 8);
            this.gboGatewayStatus.Name = "gboGatewayStatus";
            this.gboGatewayStatus.Size = new System.Drawing.Size(216, 88);
            this.gboGatewayStatus.TabIndex = 68;
            this.gboGatewayStatus.TabStop = false;
            this.gboGatewayStatus.Text = "Gateway Status";
            // 
            // lblFillConnectionValue
            // 
            this.lblFillConnectionValue.BackColor = System.Drawing.SystemColors.Control;
            this.lblFillConnectionValue.Location = new System.Drawing.Point(120, 56);
            this.lblFillConnectionValue.Name = "lblFillConnectionValue";
            this.lblFillConnectionValue.Size = new System.Drawing.Size(80, 16);
            this.lblFillConnectionValue.TabIndex = 53;
            this.lblFillConnectionValue.Text = "-";
            this.lblFillConnectionValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOrderConnectionValue
            // 
            this.lblOrderConnectionValue.BackColor = System.Drawing.SystemColors.Control;
            this.lblOrderConnectionValue.Location = new System.Drawing.Point(120, 40);
            this.lblOrderConnectionValue.Name = "lblOrderConnectionValue";
            this.lblOrderConnectionValue.Size = new System.Drawing.Size(80, 16);
            this.lblOrderConnectionValue.TabIndex = 52;
            this.lblOrderConnectionValue.Text = "-";
            this.lblOrderConnectionValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPriceConnectionValue
            // 
            this.lblPriceConnectionValue.BackColor = System.Drawing.SystemColors.Control;
            this.lblPriceConnectionValue.Location = new System.Drawing.Point(120, 24);
            this.lblPriceConnectionValue.Name = "lblPriceConnectionValue";
            this.lblPriceConnectionValue.Size = new System.Drawing.Size(80, 16);
            this.lblPriceConnectionValue.TabIndex = 51;
            this.lblPriceConnectionValue.Text = "-";
            this.lblPriceConnectionValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFillConnection
            // 
            this.lblFillConnection.Location = new System.Drawing.Point(16, 56);
            this.lblFillConnection.Name = "lblFillConnection";
            this.lblFillConnection.Size = new System.Drawing.Size(96, 16);
            this.lblFillConnection.TabIndex = 50;
            this.lblFillConnection.Text = "Fill Connection:";
            this.lblFillConnection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPriceConnection
            // 
            this.lblPriceConnection.Location = new System.Drawing.Point(16, 24);
            this.lblPriceConnection.Name = "lblPriceConnection";
            this.lblPriceConnection.Size = new System.Drawing.Size(96, 16);
            this.lblPriceConnection.TabIndex = 48;
            this.lblPriceConnection.Text = "Price Connection:";
            this.lblPriceConnection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOrderConnection
            // 
            this.lblOrderConnection.Location = new System.Drawing.Point(8, 40);
            this.lblOrderConnection.Name = "lblOrderConnection";
            this.lblOrderConnection.Size = new System.Drawing.Size(104, 16);
            this.lblOrderConnection.TabIndex = 49;
            this.lblOrderConnection.Text = "Order Connection:";
            this.lblOrderConnection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gboOnStatusUpdate
            // 
            this.gboOnStatusUpdate.Controls.Add(this.txtOnStatusUpdateOutput);
            this.gboOnStatusUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gboOnStatusUpdate.Location = new System.Drawing.Point(264, 184);
            this.gboOnStatusUpdate.Name = "gboOnStatusUpdate";
            this.gboOnStatusUpdate.Size = new System.Drawing.Size(248, 144);
            this.gboOnStatusUpdate.TabIndex = 69;
            this.gboOnStatusUpdate.TabStop = false;
            this.gboOnStatusUpdate.Text = "OnStatusUpdate Output";
            // 
            // txtOnStatusUpdateOutput
            // 
            this.txtOnStatusUpdateOutput.Location = new System.Drawing.Point(16, 24);
            this.txtOnStatusUpdateOutput.Multiline = true;
            this.txtOnStatusUpdateOutput.Name = "txtOnStatusUpdateOutput";
            this.txtOnStatusUpdateOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOnStatusUpdateOutput.Size = new System.Drawing.Size(216, 104);
            this.txtOnStatusUpdateOutput.TabIndex = 0;
            this.txtOnStatusUpdateOutput.WordWrap = false;
            // 
            // gboOnExchangeMessage
            // 
            this.gboOnExchangeMessage.Controls.Add(this.txtOnExchangeMessageOutput);
            this.gboOnExchangeMessage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gboOnExchangeMessage.Location = new System.Drawing.Point(8, 336);
            this.gboOnExchangeMessage.Name = "gboOnExchangeMessage";
            this.gboOnExchangeMessage.Size = new System.Drawing.Size(504, 144);
            this.gboOnExchangeMessage.TabIndex = 68;
            this.gboOnExchangeMessage.TabStop = false;
            this.gboOnExchangeMessage.Text = "OnExchangeMessage Output";
            // 
            // txtOnExchangeMessageOutput
            // 
            this.txtOnExchangeMessageOutput.Location = new System.Drawing.Point(16, 24);
            this.txtOnExchangeMessageOutput.Multiline = true;
            this.txtOnExchangeMessageOutput.Name = "txtOnExchangeMessageOutput";
            this.txtOnExchangeMessageOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOnExchangeMessageOutput.Size = new System.Drawing.Size(472, 104);
            this.txtOnExchangeMessageOutput.TabIndex = 0;
            this.txtOnExchangeMessageOutput.WordWrap = false;
            // 
            // gboGatewayConnections
            // 
            this.gboGatewayConnections.Controls.Add(this.chkOpenFillServer);
            this.gboGatewayConnections.Controls.Add(this.chkOpenOrderServer);
            this.gboGatewayConnections.Controls.Add(this.chkOpenPriceServer);
            this.gboGatewayConnections.Controls.Add(this.btnConnect);
            this.gboGatewayConnections.Controls.Add(this.lblAvailableGateways);
            this.gboGatewayConnections.Controls.Add(this.cboAvailableGateways);
            this.gboGatewayConnections.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gboGatewayConnections.Location = new System.Drawing.Point(8, 8);
            this.gboGatewayConnections.Name = "gboGatewayConnections";
            this.gboGatewayConnections.Size = new System.Drawing.Size(280, 168);
            this.gboGatewayConnections.TabIndex = 70;
            this.gboGatewayConnections.TabStop = false;
            this.gboGatewayConnections.Text = "Gateway Connections";
            // 
            // chkOpenFillServer
            // 
            this.chkOpenFillServer.Checked = true;
            this.chkOpenFillServer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOpenFillServer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkOpenFillServer.Location = new System.Drawing.Point(144, 96);
            this.chkOpenFillServer.Name = "chkOpenFillServer";
            this.chkOpenFillServer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkOpenFillServer.Size = new System.Drawing.Size(120, 16);
            this.chkOpenFillServer.TabIndex = 53;
            this.chkOpenFillServer.Text = "Open Fill Server";
            // 
            // chkOpenOrderServer
            // 
            this.chkOpenOrderServer.Checked = true;
            this.chkOpenOrderServer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOpenOrderServer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkOpenOrderServer.Location = new System.Drawing.Point(144, 80);
            this.chkOpenOrderServer.Name = "chkOpenOrderServer";
            this.chkOpenOrderServer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkOpenOrderServer.Size = new System.Drawing.Size(120, 16);
            this.chkOpenOrderServer.TabIndex = 52;
            this.chkOpenOrderServer.Text = "Open Order Server";
            // 
            // chkOpenPriceServer
            // 
            this.chkOpenPriceServer.Checked = true;
            this.chkOpenPriceServer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOpenPriceServer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkOpenPriceServer.Location = new System.Drawing.Point(144, 64);
            this.chkOpenPriceServer.Name = "chkOpenPriceServer";
            this.chkOpenPriceServer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkOpenPriceServer.Size = new System.Drawing.Size(120, 16);
            this.chkOpenPriceServer.TabIndex = 51;
            this.chkOpenPriceServer.Text = "Open Price Server";
            // 
            // btnConnect
            // 
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnConnect.Location = new System.Drawing.Point(192, 128);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(72, 23);
            this.btnConnect.TabIndex = 50;
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // lblAvailableGateways
            // 
            this.lblAvailableGateways.Location = new System.Drawing.Point(8, 32);
            this.lblAvailableGateways.Name = "lblAvailableGateways";
            this.lblAvailableGateways.Size = new System.Drawing.Size(112, 16);
            this.lblAvailableGateways.TabIndex = 49;
            this.lblAvailableGateways.Text = "Available Gateways:";
            this.lblAvailableGateways.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboAvailableGateways
            // 
            this.cboAvailableGateways.Location = new System.Drawing.Point(128, 32);
            this.cboAvailableGateways.Name = "cboAvailableGateways";
            this.cboAvailableGateways.Size = new System.Drawing.Size(136, 21);
            this.cboAvailableGateways.TabIndex = 48;
            this.cboAvailableGateways.SelectedIndexChanged += new System.EventHandler(this.gatewayComboBox_SelectedIndexChanged);
            // 
            // gboXTraderStatus
            // 
            this.gboXTraderStatus.Controls.Add(this.lblXTraderProValue);
            this.gboXTraderStatus.Controls.Add(this.lblXTraderValue);
            this.gboXTraderStatus.Controls.Add(this.lblXTrader);
            this.gboXTraderStatus.Controls.Add(this.lblXTraderPro);
            this.gboXTraderStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gboXTraderStatus.Location = new System.Drawing.Point(296, 104);
            this.gboXTraderStatus.Name = "gboXTraderStatus";
            this.gboXTraderStatus.Size = new System.Drawing.Size(216, 72);
            this.gboXTraderStatus.TabIndex = 71;
            this.gboXTraderStatus.TabStop = false;
            this.gboXTraderStatus.Text = "X_TRADER Status";
            // 
            // lblXTraderProValue
            // 
            this.lblXTraderProValue.BackColor = System.Drawing.SystemColors.Control;
            this.lblXTraderProValue.Location = new System.Drawing.Point(120, 40);
            this.lblXTraderProValue.Name = "lblXTraderProValue";
            this.lblXTraderProValue.Size = new System.Drawing.Size(80, 16);
            this.lblXTraderProValue.TabIndex = 52;
            this.lblXTraderProValue.Text = "-";
            this.lblXTraderProValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblXTraderValue
            // 
            this.lblXTraderValue.BackColor = System.Drawing.SystemColors.Control;
            this.lblXTraderValue.Location = new System.Drawing.Point(120, 24);
            this.lblXTraderValue.Name = "lblXTraderValue";
            this.lblXTraderValue.Size = new System.Drawing.Size(80, 16);
            this.lblXTraderValue.TabIndex = 51;
            this.lblXTraderValue.Text = "-";
            this.lblXTraderValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblXTrader
            // 
            this.lblXTrader.Location = new System.Drawing.Point(16, 24);
            this.lblXTrader.Name = "lblXTrader";
            this.lblXTrader.Size = new System.Drawing.Size(96, 16);
            this.lblXTrader.TabIndex = 48;
            this.lblXTrader.Text = "X_TRADER:";
            this.lblXTrader.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblXTraderPro
            // 
            this.lblXTraderPro.Location = new System.Drawing.Point(24, 40);
            this.lblXTraderPro.Name = "lblXTraderPro";
            this.lblXTraderPro.Size = new System.Drawing.Size(88, 16);
            this.lblXTraderPro.TabIndex = 49;
            this.lblXTraderPro.Text = "X_TRADER Pro:";
            this.lblXTraderPro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmMonitorGateways
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(522, 512);
            this.Controls.Add(this.gboXTraderStatus);
            this.Controls.Add(this.gboGatewayStatus);
            this.Controls.Add(this.gboGatewayConnections);
            this.Controls.Add(this.gboOnStatusUpdate);
            this.Controls.Add(this.gboOnExchangeStateUpdate);
            this.Controls.Add(this.sbaStatus);
            this.Controls.Add(this.gboOnExchangeMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Menu = this.mainMenu1;
            this.Name = "frmMonitorGateways";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MonitorGateways";
            this.gboOnExchangeStateUpdate.ResumeLayout(false);
            this.gboOnExchangeStateUpdate.PerformLayout();
            this.gboGatewayStatus.ResumeLayout(false);
            this.gboOnStatusUpdate.ResumeLayout(false);
            this.gboOnStatusUpdate.PerformLayout();
            this.gboOnExchangeMessage.ResumeLayout(false);
            this.gboOnExchangeMessage.PerformLayout();
            this.gboGatewayConnections.ResumeLayout(false);
            this.gboXTraderStatus.ResumeLayout(false);
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
			Application.Run(new frmMonitorGateways());
		}

        /// <summary>
        /// This event is triggered when the state of a TT Gateway changes.
        /// </summary>
        /// <param name="sExchange">Name of the exchange sending the message.</param>
        /// <param name="sText">Type of server.</param>
        /// <param name="bOpened">Whether the application is connected to the gateway.</param>
        /// <param name="bServerUp">Whether the server specified in srvType is active.</param>
		private void m_TTGate_OnExchangeStateUpdate(string sExchange, string sText, int bOpened, int bServerUp)
		{
			// Output the parameters to the user interface.
			txtOnExchangeStateUpdateOutput.Text += sExchange + ",  " + sText + ",  " + bOpened + ",  " + bServerUp + "\r\n";

            if (!m_gatewayStatus.ContainsKey(sExchange))
            {
                // New exchange found - Add it to the list
                m_gatewayStatus.Add(sExchange, new GatewayStatusData(sExchange, sText, bOpened, bServerUp));

                // Add it to the ComboBox
                cboAvailableGateways.Items.Add(sExchange);

                if (cboAvailableGateways.SelectedIndex < 0)
                {
                    cboAvailableGateways.SelectedIndex = 0;
                }
            }
            else
            {
                // Exchange already exists - update the values
                m_gatewayStatus[sExchange].SetStatusData(sText, bOpened, bServerUp);
            }

            // Update the GUI if the update is for the selected exchange
            if (cboAvailableGateways.SelectedItem.ToString() == sExchange)
            {
                DisplayStatusUpdate(cboAvailableGateways.SelectedItem.ToString());
            }
		}

		/// <summary>
        /// This event is triggered when the connection with X_TRADER changes.
		/// </summary>
        /// <param name="lHintMask">Current status of X_TRADER</param>
        /// <param name="sText">Description of the status change</param>
		private void m_TTGate_OnStatusUpdate(int lHintMask, string sText)
		{
			txtOnStatusUpdateOutput.Text += lHintMask + ",  " + sText + "\r\n";

            switch (lHintMask)
            {
                case 1:         // X_TRADER is connected
                    lblXTraderValue.Text = "Connected";
                    break;
                case 16:        // X_TRADER Pro is unavailable
                    lblXTraderProValue.Text = "Unavailable";
                    break;
                case 32:        // X_TRADER Pro is available
                    lblXTraderProValue.Text = "Available";
                    break;
                default:
                    break;
            }
		}

		/// <summary>
        /// This event is triggered when the gateway sends a informational message.
		/// </summary>
        /// <param name="sExchange">Name of the exchange sending the message</param>
        /// <param name="sTimeStamp">Time, to the millisecond, when the message was sent</param>
        /// <param name="sInfo">Type of message.</param>
        /// <param name="sText">Text of the message from the exchange</param>
		private void m_TTGate_OnExchangeMessage(string sExchange, string sTimeStamp, string sInfo, string sText)
		{
			txtOnExchangeMessageOutput.Text += sExchange + ",  " + sTimeStamp + ",  " + sInfo + ",  " + sText + "\r\n";
		}	
		
		/// <summary>
        /// Open each server that is selected for the exchange.
		/// </summary>
		private void ConnectButton_Click(object sender, System.EventArgs e)
		{
			if (chkOpenPriceServer.Checked)
			{
				m_TTGate.OpenExchangePrices(cboAvailableGateways.SelectedItem.ToString());
			}

			if (chkOpenOrderServer.Checked)
			{
				m_TTGate.OpenExchangeOrders(cboAvailableGateways.SelectedItem.ToString());
			}

			if (chkOpenFillServer.Checked)
			{
				m_TTGate.OpenExchangeFills(cboAvailableGateways.SelectedItem.ToString());
			}
		}

		/// <summary>
		/// This event is triggered when the user selects a different exchange.
		/// </summary>
		private void gatewayComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Update the gateway status group box.
			gboGatewayStatus.Text = "Gateway Status - " + cboAvailableGateways.SelectedItem.ToString();

			// Reset all connection labels.
			lblPriceConnectionValue.Text = "-";
			lblPriceConnectionValue.BackColor = Color.LightGray;
			lblOrderConnectionValue.Text = "-";
			lblOrderConnectionValue.BackColor = Color.LightGray;
			lblFillConnectionValue.Text = "-";
			lblFillConnectionValue.BackColor = Color.LightGray;

            DisplayStatusUpdate(cboAvailableGateways.SelectedItem.ToString());
		}

        /// <summary>
        /// Publish the gateway statuses to the GUI
        /// </summary>
        /// <param name="sExchange">Exchange to retrieve statuses for</param>
        private void DisplayStatusUpdate(string sExchange)
        {
            if (!m_gatewayStatus.ContainsKey(sExchange))
                return;

            GatewayStatusData gwStatus = m_gatewayStatus[sExchange];

            // Check and display the price server status
            if (!gwStatus.IsOpen(ServerType.PRICE) && !gwStatus.IsServerUp(ServerType.PRICE))
            {
                lblPriceConnectionValue.Text = "EXISTS";
                lblPriceConnectionValue.BackColor = Color.LightBlue;
            }
            else if (gwStatus.IsOpen(ServerType.PRICE) && !gwStatus.IsServerUp(ServerType.PRICE))
            {
                lblPriceConnectionValue.Text = "DOWN";
                lblPriceConnectionValue.BackColor = Color.FromArgb(255, 128, 128);
            }
            else if (gwStatus.IsOpen(ServerType.PRICE) && gwStatus.IsServerUp(ServerType.PRICE))
            {
                lblPriceConnectionValue.Text = "UP";
                lblPriceConnectionValue.BackColor = Color.LightGreen;
            }

            // Check and display the order server status
            if (!gwStatus.IsDownloading(ServerType.ORDER))
            {
                if (!gwStatus.IsOpen(ServerType.ORDER) && !gwStatus.IsServerUp(ServerType.ORDER))
                {
                    lblOrderConnectionValue.Text = "EXISTS";
                    lblOrderConnectionValue.BackColor = Color.LightBlue;
                }
                else if (gwStatus.IsOpen(ServerType.ORDER) && !gwStatus.IsServerUp(ServerType.ORDER))
                {
                    lblOrderConnectionValue.Text = "DOWN";
                    lblOrderConnectionValue.BackColor = Color.FromArgb(255, 128, 128);
                }
                else if (gwStatus.IsOpen(ServerType.ORDER) && gwStatus.IsServerUp(ServerType.ORDER))
                {
                    lblOrderConnectionValue.Text = "UP";
                    lblOrderConnectionValue.BackColor = Color.LightGreen;
                }
            }
            else
            {
                lblOrderConnectionValue.Text = "Downloading...";
                lblOrderConnectionValue.BackColor = Color.LightYellow;
            }

            // Check and display the fill server status
            if (!gwStatus.IsDownloading(ServerType.FILL))
            {
                if (!gwStatus.IsOpen(ServerType.FILL) && !gwStatus.IsServerUp(ServerType.FILL))
                {
                    lblFillConnectionValue.Text = "EXISTS";
                    lblFillConnectionValue.BackColor = Color.LightBlue;
                }
                else if (gwStatus.IsOpen(ServerType.FILL) && !gwStatus.IsServerUp(ServerType.FILL))
                {
                    lblFillConnectionValue.Text = "DOWN";
                    lblFillConnectionValue.BackColor = Color.FromArgb(255, 128, 128);
                }
                else if (gwStatus.IsOpen(ServerType.FILL) && gwStatus.IsServerUp(ServerType.FILL))
                {
                    lblFillConnectionValue.Text = "UP";
                    lblFillConnectionValue.BackColor = Color.LightGreen;
                }
            }
            else
            {
                lblFillConnectionValue.Text = "Downloading...";
                lblFillConnectionValue.BackColor = Color.LightYellow;
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

    /// <summary>
    /// Enumeration of all server types
    /// </summary>
    public enum ServerType
    {
        UNKNOWN = -1,
        PRICE = 0,
        ORDER = 1,
        FILL = 2
    }

    /// <summary>
    /// Placeholder class to store all the exchange statuses
    /// </summary>
    public class GatewayStatusData
    {
        // private member variables
        private List<ServerStatus> m_servers;

        public GatewayStatusData(string sExchange, string sText, int bOpened, int bServerUp)
        {
            this.Exchange = sExchange;

            // Instantiate and initialize our server list
            m_servers = new List<ServerStatus>(Enum.GetNames(typeof(ServerType)).Length - 1);
            m_servers.Insert((int)ServerType.PRICE, new ServerStatus(false, false, false));
            m_servers.Insert((int)ServerType.ORDER, new ServerStatus(false, false, false));
            m_servers.Insert((int)ServerType.FILL, new ServerStatus(false, false, false));

            // Set the ServerStatus based on the constructor parameters
            SetStatusData(sText, bOpened, bServerUp);
        }

        /// <summary>
        /// Exchange
        /// </summary>
        public string Exchange { get; set; }
        
        /// <summary>
        /// Check if the server is open
        /// </summary>
        /// <param name="type">ServerType to request</param>
        /// <returns>true if open</returns>
        public bool IsOpen(ServerType type)
        {
            return m_servers[(int)type].IsOpened;
        }

        /// <summary>
        /// Check if the server is up
        /// </summary>
        /// <param name="type">ServerType to request</param>
        /// <returns>true if up</returns>
        public bool IsServerUp(ServerType type)
        {
            return m_servers[(int)type].IsServerUp;
        }

        /// <summary>
        /// Check if the server is currently downloading
        /// </summary>
        /// <param name="type">ServerType to request</param>
        /// <returns>true if in downloading state</returns>
        public bool IsDownloading(ServerType type)
        {
            return m_servers[(int)type].IsDownloading;
        }

        /// <summary>
        /// Set the status data
        /// </summary>
        /// <param name="sText">sText value from OnExchangeStateUpdate</param>
        /// <param name="bOpened">bOpened value from OnExchangeStateUpdate</param>
        /// <param name="bServerUp">bServerUp value from OnExchangeStateUpdate</param>
        public void SetStatusData(string sText, int bOpened, int bServerUp)
        {
            // get the server type from the text
            ServerType type = GatewayStatusData.GetServerType(sText);

            // check if the server is downloading
            bool downloading = sText.Contains("(Downloading)");

            // set the new value
            m_servers[(int)type] = new ServerStatus(Convert.ToBoolean(bOpened), Convert.ToBoolean(bServerUp), downloading);
        }

        /// <summary>
        /// Returns the ServerType enumeration value based on the string parameter
        /// </summary>
        /// <param name="server">String representation of the server type</param>
        /// <returns>ServerType value</returns>
        private static ServerType GetServerType(string server)
        {
            if (server.ToUpper().StartsWith("PRICE"))
            {
                return ServerType.PRICE;
            }
            else if (server.ToUpper().StartsWith("ORDER"))
            {
                return ServerType.ORDER;
            }
            else if (server.ToUpper().StartsWith("FILL"))
            {
                return ServerType.FILL;
            }

            return ServerType.UNKNOWN;
        }

        /// <summary>
        /// Values of a specific servers status
        /// </summary>
        private struct ServerStatus
        {
            public bool IsOpened, IsServerUp, IsDownloading;

            public ServerStatus(bool isOpen, bool isServerUp, bool isDownloading)
            {
                IsOpened = isOpen;
                IsServerUp = isServerUp;
                IsDownloading = isDownloading;
            }
        }
    }
}
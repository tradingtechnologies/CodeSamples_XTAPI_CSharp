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
 * ***************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XTAPI_Samples
{
    /// <summary>
    /// StartOfDay
    /// 
    /// This example demonstrates using the XTAPI to monitor and set StartOfDay (SOD)
    /// records.  This sample requires you have administrative risk privileges.
    /// </summary>
    public partial class frmStartOfDay : Form
    {
        // Declare the XTAPI objects.
        private XTAPI.TTDropHandler m_TTDropHandler = null;
        private XTAPI.TTInstrObj m_TTInstrObj = null;
        private XTAPI.TTInstrNotify m_TTInstrNotify = null;
        private XTAPI.TTRiskManager m_RiskManager = null;
        private XTAPI.TTGate m_TTGate = null;

        // private member variables
        private bool m_isFillServerUp = false;
        private bool m_isXTPro = false;
        private bool m_isXTConnected = false;
        private bool m_isDataLoaded = false;

        /// <summary>
        /// Upon the application form loading, the TTGate, TTDropHandler, TTInstrNotify, and
        /// TTRiskManager are initialized and events are subscribed to.
        /// </summary>
        public frmStartOfDay()
        {
            // Required for Windows Form Designer support
            InitializeComponent();

            // Indicates when the connection is established
            m_TTGate = new XTAPI.TTGate();

            //Subscribe to the OnExchangeStateupdate and OnStatusUpdate events
            m_TTGate.OnExchangeStateUpdate += new XTAPI._ITTGateEvents_OnExchangeStateUpdateEventHandler(m_TTGate_OnExchangeStateUpdate);
            m_TTGate.OnStatusUpdate += new XTAPI._ITTGateEvents_OnStatusUpdateEventHandler(m_TTGate_OnStatusUpdate);

            // Instantiate the drag and drop handler class.					 
            m_TTDropHandler = new XTAPI.TTDropHandler();

            // Register the active form for drag and drop.
            m_TTDropHandler.RegisterDropWindow((int)this.Handle);

            // Associate the drop and drag callback event.
            m_TTDropHandler.OnNotifyDrop += new XTAPI._ITTDropHandlerEvents_OnNotifyDropEventHandler(m_TTDropHandler_OnNotifyDrop);

            // Instantiate the instrument notification class.
            m_TTInstrNotify = new XTAPI.TTInstrNotify();

            // Setup the instrument notification call back functions.
            m_TTInstrNotify.OnNotifyFound += new XTAPI._ITTInstrNotifyEvents_OnNotifyFoundEventHandler(m_TTInstrNotify_OnNotifyFound);

            //Instantiate the TTRiskManagerClass
            m_RiskManager = new XTAPI.TTRiskManager();

            //Subscribe to the TTRiskManager Events
            m_RiskManager.OnLoginFailed += new XTAPI._ITTRiskManagerEvents_OnLoginFailedEventHandler(m_RiskManager_OnLoginFailed);
            m_RiskManager.OnDataLoaded += new XTAPI._ITTRiskManagerEvents_OnDataLoadedEventHandler(m_RiskManager_OnDataLoaded);
            m_RiskManager.OnSODDataDownloaded += new XTAPI._ITTRiskManagerEvents_OnSODDataDownloadedEventHandler(m_RiskManager_OnSODDataDownloaded);
        }

        #region TTGate Events

        /// <summary>
        /// This event is triggered when the state of a TT Gateway changes.
        /// </summary>
        /// <param name="sExchange">Name of the exchange sending the message.</param>
        /// <param name="sText">Type of server.</param>
        /// <param name="bOpened">Whether the application is connected to the gateway.</param>
        /// <param name="bServerUp">Whether the server specified in srvType is active.</param>
        private void m_TTGate_OnExchangeStateUpdate(string sExchange, string sText, int bOpened, int bServerUp)
        {
            // Report to the GUI the connection to the fill server is active
            if (sExchange == txtRiskAdminExchange.Text && sText == "Fill" && bOpened == 1 & bServerUp == 1)
            {
                m_isFillServerUp = true;

                lblFillConnection.Text = "UP";
                lblFillConnection.BackColor = Color.Green;
            }

            // Try to enable the SOD Services
            TryEnableSODServices();
        }

        /// <summary>
        /// This event is triggered when the connection with X_TRADER changes.
        /// </summary>
        /// <param name="lHintMask">Current status of X_TRADER</param>
        /// <param name="sText">Description of the status change</param>
        private void m_TTGate_OnStatusUpdate(int lHintMask, string sText)
        {
            if (lHintMask == 1) // X_TRADER is connected
            {
                m_isXTConnected = true;

                lblXTrader.Text = "Connected";
                lblXTrader.BackColor = Color.Green;
            }
            else if (lHintMask == 32) // X_TRADER Pro is enabled
            {
                m_isXTPro = true;

                lblXTPro.Text = "Connected";
                lblXTPro.BackColor = Color.Green;
            }

            // Attempt to establish a connection to the fill server and enable SOD services on the form
            TryOpenFillConnection();
            TryEnableSODServices();
        }

        #endregion

        #region TTDropHandler Events

        /// <summary>
        /// This function is called when an instrument is dragged and dropped from the 
        /// Market Grid in X_TRADER.
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
                m_TTInstrObj = (XTAPI.TTInstrObj)m_TTDropHandler[1];

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

        #endregion

        #region TTInstrNotify Events

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
            Array data = (Array)pInstr.get_Get("Exchange,Product,ProdType,Contract");

            txtFoundExchange.Text = (string)data.GetValue(0);
            txtFoundProduct.Text = (string)data.GetValue(1);
            txtFoundProdType.Text = (string)data.GetValue(2);
            txtFoundContract.Text = (string)data.GetValue(3);

            // Enable the other parts of the "Publish" section for publishing SODs
            txtPublishNewNetPosition.Enabled = true;
            txtPublishNewAvgPrice.Enabled = true;
            cboPublishPriceFormat.Enabled = true;
            btnAddSod.Enabled = true;
            btnDelete.Enabled = true;
        }

        #endregion

        #region TTRiskManager Events

        /// <summary>
        /// Guardian rejected the administrator login credentials supplied in the SetAdminLogon method.
        /// </summary>
        /// <param name="sAdminExchange">Exchange Gateway name</param>
        /// <param name="sAdminMember">Administrator member ID</param>
        /// <param name="sAdminGroup">Administrator group ID</param>
        /// <param name="sAdminTrader">Administrator trader ID</param>
        /// <param name="sMsg">Reason for the rejection</param>
        private void m_RiskManager_OnLoginFailed(string sAdminExchange, string sAdminMember, string sAdminGroup, string sAdminTrader, string sMsg)
        {

            string message = "Admin Login failed on exchange: " + sAdminExchange +
                             ", MemberID: " + sAdminMember + 
                             ", GroupID: " + sAdminGroup + 
                             ", Trader: " + sAdminTrader +
                             ", Error Message: " + sMsg;

            MessageBox.Show(message, "Login ERROR");
            btnLoginRiskAdmin.Enabled = true;
        }

        /// <summary>
        /// Triggered when the application successfully logs into Guardian and retrieves the traders'
        /// risk limits.  This occurs after calling the SetAdminLogin or Reset methods.
        /// </summary>
        private void m_RiskManager_OnDataLoaded()
        {
            // SOD Data has been loaded
            m_isDataLoaded = true;
            lblOnDataLoaded.Text = "Loaded";
            lblOnDataLoaded.BackColor = Color.Green;

            // Reset output and attempt to establish a connection
            ResetOutput();
            TryOpenFillConnection();
            TryEnableSODServices();
        }

        /// <summary>
        /// SOD records from the specified exchange have been successfully downloaded.
        /// 
        /// Note:   This occurs when the client application opens a connection to the 
        ///         fill server after receiving the initial OnDataLoaded event.
        ///         
        ///         If the connection to the fill server is established prior to the
        ///         OnDataLoaded event, the event will not fire.
        /// </summary>
        /// <param name="sExch">Exchange associated with the SOD record.</param>
        private void m_RiskManager_OnSODDataDownloaded(string sExch)
        {
            Console.WriteLine("SOD Records have been downloaded for " + sExch);
        }

        #endregion

        #region GUI Event Handlers

        /// <summary>
        /// Called when the user attempts risk administrator authentication
        /// </summary>
        private void btnLoginRiskAdmin_Click(object sender, EventArgs e)
        {
            // Disable login button 
            btnLoginRiskAdmin.Enabled = false;

            try
            {
                // Send admin login through the risk manager
                m_RiskManager.SetAdminLogon(txtRiskAdminExchange.Text,
                                            txtRiskAdminMember.Text,
                                            txtRiskAdminGroup.Text,
                                            txtRiskAdminTrader.Text,
                                            txtRiskAdminPassword.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login Failed: " + ex.Message, "Exception");
                btnLoginRiskAdmin.Enabled = true;

                return;
            }

            sbaStatus.Text = "Risk Administrator Login Successful";
        }

        /// <summary>
        /// Display SOD records for the trader provided in the form
        /// </summary>
        private void btnGetSodSet_Click(object sender, EventArgs e)
        {
            LoadSODData();
        }

        /// <summary>
        /// Add the SOD Record to the SOD object
        /// </summary>
        private void btnAddSod_Click(object sender, EventArgs e)
        {
            if (txtPublishNewAvgPrice.Text == "" || txtPublishNewNetPosition.Text == "")
            {
                //Display a message saying NewAvgPrice and NewNetPosition are mandatory
                MessageBox.Show("Please set both of the NewAvgPrice and the NewNetPosition values.", "Error");
                return;
            }

            try
            {
                // Create the SOD object
                XTAPI.TTSODObj newSod = m_RiskManager.SODSet.CreateSODObject;

                // Set the SOD MGT Data
                newSod.Set("Member", txtMember.Text);
                newSod.Set("Group", txtGroup.Text);
                newSod.Set("Trader", txtTrader.Text);

                // Set the SOD object to the instrument from the drop handler
                newSod.Instrument = m_TTInstrObj;

                // Set both NewAvgPrice and NewNetPosition
                newSod.Set("NewAvgPrice" + cboPublishPriceFormat.SelectedItem, txtPublishNewAvgPrice.Text);
                newSod.Set("NewNetPosition", txtPublishNewNetPosition.Text);

                // If IsComplete is set to true call SetRecord
                if (newSod.IsComplete != 0)
                {
                    m_RiskManager.SODSet.SetRecord(newSod);

                    //Enable the Save and Disable the buttons
                    btnSave.Enabled = true;
                    btnDelete.Enabled = false;
                    btnDeleteAll.Enabled = false;
                }
                else
                {
                    MessageBox.Show("SOD Object is not complete.", "Error");
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "Exception");
            }
        }

        /// <summary>
        /// Delete the SOD record of the contract dragged on the form from the SOD object
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve SOD Records by MGT
                m_RiskManager.SODSet.RetrieveByTrader(txtMember.Text, txtGroup.Text, txtTrader.Text);

                for (int i = 1; i <= m_RiskManager.SODSet.Count; i++)
                {
                    // Create an SOD Object and set it to the objects retrieved from the SODSet
                    XTAPI.TTSODObj sod = m_RiskManager.SODSet[i];

                    // Check if the contract matches the dragged instrument
                    if (sod.Instrument.Contract == m_TTInstrObj.Contract)
                    {
                        // Delete the SOD record for the dropped instrument object     
                        m_RiskManager.SODSet.DeleteRecord(sod);

                        // Disable the Add/DeleteAll buttons and enable the Save button
                        btnDeleteAll.Enabled = false;
                        btnAddSod.Enabled = false;
                        btnSave.Enabled = true;

                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "Exception");
            }
        }

        /// <summary>
        /// Delete all SOD records
        /// </summary>
        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve SOD Records by MGT
                m_RiskManager.SODSet.RetrieveByTrader(txtMember.Text, txtGroup.Text, txtTrader.Text);
                // Delete all SOD records for the MGT     
                m_RiskManager.SODSet.DeleteAll(txtMember.Text, txtGroup.Text, txtTrader.Text);

                // Disable the Add/Delete buttons and enable the Save button
                btnDelete.Enabled = false;
                btnAddSod.Enabled = false;
                btnSave.Enabled = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "Exception");
            }
        }

        /// <summary>
        /// This functions saves the SOD Records after they have been Added to the Risk Manager
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                m_RiskManager.SODSet.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "Exception");
                return;
            }

            // Setup the form for the next steps
            lblDragNDrop.ForeColor = System.Drawing.Color.Red;
            lblDragNDrop.Text = "Add/Delete another SOD or Click Publish";
            btnPublish.Enabled = true;
            btnSave.Enabled = false;
            btnAddSod.Enabled = true;
            btnDelete.Enabled = true;
            btnDeleteAll.Enabled = true;
        }

        /// <summary>
        /// This function publishses the SOD Records after they have been saved in the Risk Manager
        /// </summary>
        private void btnPublish_Click(object sender, EventArgs e)
        {
            try
            {
                m_RiskManager.Publish();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "Exception");
                return;
            }

            // Setup the form to display the updated SOD set, and accept new records
            lblDragNDrop.ForeColor = System.Drawing.Color.Black;
            lblDragNDrop.Text = "Drag and Drop a contract from X_TRADER";
            this.btnPublish.Enabled = false;
            this.btnSave.Enabled = false;
            this.btnAddSod.Enabled = true;
            this.btnDelete.Enabled = true;
            this.btnDeleteAll.Enabled = true;

            LoadSODData();
        }

        /// <summary>
        /// This function displays the About dialog box.
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.ShowDialog(this);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Clears the output and starts anew
        /// </summary>
        private void ResetOutput()
        {
            txtSODRecords.Clear();
            txtSODRecords.Text += "TraderID, Exchange, Product, Product Type, Contract, NewNetPosition,  NewAvgPrice($)\r\n\r\n";
        }

        /// <summary>
        /// Loads the current SOD records and publishes to the output TextBox
        /// </summary>
        private void LoadSODData()
        {
            ResetOutput();

            try
            {
                // Retrieve the entered traders' SOD records
                m_RiskManager.SODSet.RetrieveByTrader(txtMember.Text, txtGroup.Text, txtTrader.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot load SOD records: " + ex.Message, "Exception");
                return;
            }

            // Check if there are no existing SOD records
            if (m_RiskManager.SODSet.Count <= 0)
            {
                txtSODRecords.Text += "THERE ARE CURRENTLY NO START OF DAY RECORDS FOR THIS TRADER";
                return;
            }

            // Iterate through the SOD List and pubolish to the GUI
            // Note: The SODSet index begins at 1
            for (int i = 1; i <= m_RiskManager.SODSet.Count; i++)
            {
                try
                {
                    XTAPI.TTSODObj sod = m_RiskManager.SODSet[i]; 

                    // Get properties from SOD set object
                    string properties = "Member,Group,Trader,Instr.Exchange,Instr.Product,Instr.ProdType,Instr.Contract,NewNetPosition,NewAvgPrice$";
                    Array data = (Array)sod.get_Get(properties);

                    // Print the fill information to the screen.
                    txtSODRecords.Text += (string)data.GetValue(0) + "|";
                    txtSODRecords.Text += (string)data.GetValue(1) + "|";
                    txtSODRecords.Text += (string)data.GetValue(2) + ", ";
                    txtSODRecords.Text += (string)data.GetValue(3) + ", ";
                    txtSODRecords.Text += (string)data.GetValue(4) + ", ";
                    txtSODRecords.Text += (string)data.GetValue(5) + ", ";
                    txtSODRecords.Text += (string)data.GetValue(6) + ", ";
                    txtSODRecords.Text += Convert.ToString(data.GetValue(7)) + ", ";
                    txtSODRecords.Text += (string)data.GetValue(8) + "\r\n";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception");
                    return;
                }
            }

            // Delete all SOD Records from the SOD set object
            m_RiskManager.SODSet.Empty();
        }

        /// <summary>
        /// Open connection to the fill server if all flags are set.
        /// </summary>
        private void TryOpenFillConnection()
        {
            // Check if X_TRADER Pro is running and OnDataLoaded has occured
            if (!m_isFillServerUp && m_isXTPro && m_isXTConnected && m_isDataLoaded)
            {
                // Establish a connection to the fill server
                m_TTGate.OpenExchangeFills(this.txtRiskAdminExchange.Text); 
            }
        }

        /// <summary>
        /// Enable SOD services on the form if all flags are set.
        /// </summary>
        private void TryEnableSODServices()
        {
            // Check if everything is available to enable the SOD Services
            if (m_isFillServerUp && m_isXTPro && m_isXTConnected && m_isDataLoaded)
            {
                gboSODServices.Enabled = true;
                btnGetSodSet.Enabled = true;
                txtMember.Enabled = true;
                txtGroup.Enabled = true;
                txtTrader.Enabled = true;
            }
        }

        #endregion
    }
}
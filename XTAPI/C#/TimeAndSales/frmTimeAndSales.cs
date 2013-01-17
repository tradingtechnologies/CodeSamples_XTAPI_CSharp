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
    /// TimeAndSales
    /// 
	/// This example demonstrates using the XTAPI to retrieve time & sales data from a 
	/// single instrument.  The TTDropHandler object is used to resolve an instrument 
    /// dragged and dropped from the X_TRADER Market Grid.
	/// </summary>
	public class frmTimeAndSales : Form
    {
        // Declare the XTAPI objects.
		private XTAPI.TTDropHandler m_TTDropHandler;
		private XTAPI.TTInstrNotifyClass m_TTInstrNotify;
		private XTAPI.TTInstrObj m_TTInstrObj = null;

        /// <summary>
        /// Upon the application form loading, the TTDropHandler and TTInstrNotify objects 
        /// are initialized, and the required events are subscribed.
        /// </summary>
		public frmTimeAndSales()
		{
			// Required for Windows Form Designer support
			InitializeComponent();

            // Instantiate the drag and drop handler class.					 
            m_TTDropHandler = new XTAPI.TTDropHandlerClass();

            // Register the active form for drag and drop.
            m_TTDropHandler.RegisterDropWindow((int)this.Handle);

            // Subscribe to the drop and drag callback event.
			m_TTDropHandler.OnNotifyDrop +=new XTAPI._ITTDropHandlerEvents_OnNotifyDropEventHandler(m_TTDropHandler_OnNotifyDrop);

            // Instantiate the instrument notification class
            m_TTInstrNotify = new XTAPI.TTInstrNotifyClass();

            // Turn on trade data updates
			m_TTInstrNotify.DeliverAllPriceUpdates = 1;
            m_TTInstrNotify.EnablePriceUpdates = 1;

			// Setup instrument notifier callbacks			
			m_TTInstrNotify.OnNotifyFound +=new XTAPI._ITTInstrNotifyEvents_OnNotifyFoundEventHandler(m_TTInstrNotify_OnNotifyFound);	
			m_TTInstrNotify.OnPriceListUpdate +=new XTAPI._ITTInstrNotifyEvents_OnPriceListUpdateEventHandler(m_TTInstrNotify_OnPriceListUpdate);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if(disposing)
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
        private System.Windows.Forms.ListBox lboPriceList;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem mnuAbout;
        private System.Windows.Forms.StatusBar sbaStatus;
        private System.Windows.Forms.GroupBox gboPriceListUpdates;
        private System.Windows.Forms.Label lblNotProduction;
        private System.Windows.Forms.Label lblWarning;

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.lboPriceList = new System.Windows.Forms.ListBox();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.mnuAbout = new System.Windows.Forms.MenuItem();
            this.sbaStatus = new System.Windows.Forms.StatusBar();
            this.gboPriceListUpdates = new System.Windows.Forms.GroupBox();
            this.lblNotProduction = new System.Windows.Forms.Label();
            this.lblWarning = new System.Windows.Forms.Label();
            this.gboPriceListUpdates.SuspendLayout();
            this.SuspendLayout();
            // 
            // lboPriceList
            // 
            this.lboPriceList.Location = new System.Drawing.Point(16, 24);
            this.lboPriceList.Name = "lboPriceList";
            this.lboPriceList.Size = new System.Drawing.Size(627, 368);
            this.lboPriceList.TabIndex = 1;
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
            this.sbaStatus.Location = new System.Drawing.Point(0, 472);
            this.sbaStatus.Name = "sbaStatus";
            this.sbaStatus.Size = new System.Drawing.Size(688, 22);
            this.sbaStatus.SizingGrip = false;
            this.sbaStatus.TabIndex = 56;
            this.sbaStatus.Text = "Drag and Drop an instrument from the Market Grid in X_TRADER to this window.";
            // 
            // gboPriceListUpdates
            // 
            this.gboPriceListUpdates.Controls.Add(this.lboPriceList);
            this.gboPriceListUpdates.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gboPriceListUpdates.Location = new System.Drawing.Point(16, 58);
            this.gboPriceListUpdates.Name = "gboPriceListUpdates";
            this.gboPriceListUpdates.Size = new System.Drawing.Size(659, 408);
            this.gboPriceListUpdates.TabIndex = 58;
            this.gboPriceListUpdates.TabStop = false;
            this.gboPriceListUpdates.Text = "OnPriceListUpdates Event";
            // 
            // lblNotProduction
            // 
            this.lblNotProduction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotProduction.Location = new System.Drawing.Point(26, 38);
            this.lblNotProduction.Name = "lblNotProduction";
            this.lblNotProduction.Size = new System.Drawing.Size(621, 14);
            this.lblNotProduction.TabIndex = 78;
            this.lblNotProduction.Text = "This sample is NOT to be used in production or during conformance testing.";
            this.lblNotProduction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWarning
            // 
            this.lblWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarning.Location = new System.Drawing.Point(25, 9);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(621, 23);
            this.lblWarning.TabIndex = 77;
            this.lblWarning.Text = "WARNING!";
            this.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmTimeAndSales
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(688, 494);
            this.Controls.Add(this.lblNotProduction);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.sbaStatus);
            this.Controls.Add(this.gboPriceListUpdates);
            this.Menu = this.mainMenu1;
            this.Name = "frmTimeAndSales";
            this.Text = "TimeAndSales";
            this.gboPriceListUpdates.ResumeLayout(false);
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
			Application.Run(new frmTimeAndSales());
		}

        /// <summary>
        /// This function is called when one or more instruments are dragged and dropped from 
        /// the Market Grid in X_TRADER.
        /// </summary>
		private void m_TTDropHandler_OnNotifyDrop()
		{	
			// Update the Status Bar text.
			sbaStatus.Text = "Drag & Drop detected.  Initializing instrument...";

            // Clear items in listbox
            lboPriceList.Items.Clear();	

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
                
                // Set an update filter to stop receiving OnPriceListUpdate for volume
                m_TTInstrNotify.UpdateFilter = "Last,LastQty,HitTake";
				
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
		}
       
        /// <summary>
        /// This function is called when a trade data update occurs.  This will only
        /// fired when DeliverAllPriceUpdates is enabled.
        /// </summary>
        /// <param name="pNotify">TTInstrNotify object</param>
		private void m_TTInstrNotify_OnPriceListUpdate(XTAPI.TTInstrNotify pNotify)
		{
            if (pNotify == null)
                return;

            double ltp = 0.0f;
            int ltq = 0;
            string direction = "";

			try
			{
                // Loop through each ITTPriceUpdate in the ITTPriceList.  The list will contain
                // all entries which occurred since the last time the OnPriceListUpdate was fired.
                foreach (XTAPI.ITTPriceUpdate priceUpdate in pNotify.PriceList)
                {
                    //Loop through PriceEntries in PriceUpdate
                    foreach (XTAPI.ITTPriceEntry priceEntry in priceUpdate)
                    {
                        switch (priceEntry.PriceID)
                        {
                            // Get Last Traded Price
                            case XTAPI.enumPriceID.ttLastTradedPrice:
                                ltp = priceEntry.toDouble();
                                break;

                            // Get Last Traded Quantity
                            case XTAPI.enumPriceID.ttLastTradedQty:
                                ltq = (int)priceEntry.toDouble();
                                break;

                            // Get Hit or Take
                            case XTAPI.enumPriceID.ttHitTake:
                                    
                                if (priceEntry.toDouble() == Convert.ToDouble(XTAPI.enumTradeIndicator.TRADE_INDICATOR_HIT))
                                {
                                    direction = "Hit"; // Sell
                                }
                                else if (priceEntry.toDouble() == Convert.ToDouble(XTAPI.enumTradeIndicator.TRADE_INDICATOR_TAKE))
                                {
                                    direction = "Take"; // Buy
                                }
                                else if (priceEntry.toDouble() == Convert.ToDouble(XTAPI.enumTradeIndicator.TRADE_INDICATOR_UNKNOWN))
                                {
                                    direction = "Indeterminate"; // Indeterminate
                                }
                                break;

                            default:
                                break;
                        }
                    }

                    // Build message to output
                    string tsMessage = priceUpdate.TimeStamp.Substring(0, 8) + ", " + // removes date, concatinate to timestamp only
                                       priceUpdate.Instrument.Exchange + ", " + 
                                       priceUpdate.Instrument.Product + ", " + 
                                       priceUpdate.Instrument.get_Get("Expiry") + ", " + 
                                       direction + ", " + 
                                       ltp + ", " + 
                                       ltq;

                    // Add message to ListBox
                    lboPriceList.Items.Add(tsMessage);

                    // Reset data 
                    ltp = 0.0f;
                    ltq = 0;
                    direction = "";
                }
			}
			catch (Exception ex)
			{
                // Display exception message.
				Console.WriteLine(ex.Message, "Exception");
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

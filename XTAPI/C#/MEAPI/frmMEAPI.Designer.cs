namespace MEAPI_Samples
{
    partial class frmMEAPI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lboProductList = new System.Windows.Forms.TreeView();
            this.lboGateways = new System.Windows.Forms.ListBox();
            this.btnReqestGateways = new System.Windows.Forms.Button();
            this.sbaStatus = new System.Windows.Forms.StatusStrip();
            this.tsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.gboExchangeList = new System.Windows.Forms.GroupBox();
            this.gboProductList = new System.Windows.Forms.GroupBox();
            this.gboProductTypes = new System.Windows.Forms.GroupBox();
            this.lboProductTypes = new System.Windows.Forms.ListBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.gboInfo = new System.Windows.Forms.GroupBox();
            this.lboInfo = new System.Windows.Forms.ListBox();
            this.lblNotProduction = new System.Windows.Forms.Label();
            this.lblWarning = new System.Windows.Forms.Label();
            this.sbaStatus.SuspendLayout();
            this.gboExchangeList.SuspendLayout();
            this.gboProductList.SuspendLayout();
            this.gboProductTypes.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.gboInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lboProductList
            // 
            this.lboProductList.Location = new System.Drawing.Point(6, 19);
            this.lboProductList.Name = "lboProductList";
            this.lboProductList.Size = new System.Drawing.Size(246, 173);
            this.lboProductList.TabIndex = 0;
            this.lboProductList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvProductList_ItemDrag);
            this.lboProductList.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvProductList_NodeMouseClick);
            // 
            // lboGateways
            // 
            this.lboGateways.FormattingEnabled = true;
            this.lboGateways.Location = new System.Drawing.Point(6, 19);
            this.lboGateways.Name = "lboGateways";
            this.lboGateways.Size = new System.Drawing.Size(120, 173);
            this.lboGateways.Sorted = true;
            this.lboGateways.TabIndex = 2;
            this.lboGateways.SelectedIndexChanged += new System.EventHandler(this.lbGateways_SelectedIndexChanged);
            // 
            // btnReqestGateways
            // 
            this.btnReqestGateways.Location = new System.Drawing.Point(395, 395);
            this.btnReqestGateways.Name = "btnReqestGateways";
            this.btnReqestGateways.Size = new System.Drawing.Size(120, 23);
            this.btnReqestGateways.TabIndex = 3;
            this.btnReqestGateways.Text = "Request Gateways";
            this.btnReqestGateways.UseVisualStyleBackColor = true;
            this.btnReqestGateways.Click += new System.EventHandler(this.btnReqestGateways_Click);
            // 
            // sbaStatus
            // 
            this.sbaStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatus});
            this.sbaStatus.Location = new System.Drawing.Point(0, 427);
            this.sbaStatus.Name = "sbaStatus";
            this.sbaStatus.Size = new System.Drawing.Size(529, 22);
            this.sbaStatus.SizingGrip = false;
            this.sbaStatus.TabIndex = 4;
            // 
            // tsStatus
            // 
            this.tsStatus.Name = "tsStatus";
            this.tsStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // gboExchangeList
            // 
            this.gboExchangeList.Controls.Add(this.lboGateways);
            this.gboExchangeList.Location = new System.Drawing.Point(11, 74);
            this.gboExchangeList.Name = "gboExchangeList";
            this.gboExchangeList.Size = new System.Drawing.Size(131, 199);
            this.gboExchangeList.TabIndex = 5;
            this.gboExchangeList.TabStop = false;
            this.gboExchangeList.Text = "Exchange List";
            // 
            // gboProductList
            // 
            this.gboProductList.Controls.Add(this.lboProductList);
            this.gboProductList.Location = new System.Drawing.Point(259, 74);
            this.gboProductList.Name = "gboProductList";
            this.gboProductList.Size = new System.Drawing.Size(258, 199);
            this.gboProductList.TabIndex = 6;
            this.gboProductList.TabStop = false;
            this.gboProductList.Text = "Product List";
            // 
            // gboProductTypes
            // 
            this.gboProductTypes.Controls.Add(this.lboProductTypes);
            this.gboProductTypes.Location = new System.Drawing.Point(148, 74);
            this.gboProductTypes.Name = "gboProductTypes";
            this.gboProductTypes.Size = new System.Drawing.Size(105, 199);
            this.gboProductTypes.TabIndex = 6;
            this.gboProductTypes.TabStop = false;
            this.gboProductTypes.Text = "Product Types";
            // 
            // lboProductTypes
            // 
            this.lboProductTypes.FormattingEnabled = true;
            this.lboProductTypes.Location = new System.Drawing.Point(6, 19);
            this.lboProductTypes.Name = "lboProductTypes";
            this.lboProductTypes.Size = new System.Drawing.Size(93, 173);
            this.lboProductTypes.TabIndex = 2;
            this.lboProductTypes.SelectedIndexChanged += new System.EventHandler(this.lbProductTypes_SelectedIndexChanged);
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(12, 400);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(277, 13);
            this.lblNote.TabIndex = 9;
            this.lblNote.Text = "Note:  Single contracts can be dragged into X_TRADER.";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(529, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(61, 20);
            this.mnuAbout.Text = "About...";
            this.mnuAbout.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // gboInfo
            // 
            this.gboInfo.Controls.Add(this.lboInfo);
            this.gboInfo.Location = new System.Drawing.Point(11, 280);
            this.gboInfo.Name = "gboInfo";
            this.gboInfo.Size = new System.Drawing.Size(506, 109);
            this.gboInfo.TabIndex = 11;
            this.gboInfo.TabStop = false;
            this.gboInfo.Text = "Info";
            // 
            // lboInfo
            // 
            this.lboInfo.FormattingEnabled = true;
            this.lboInfo.Location = new System.Drawing.Point(6, 19);
            this.lboInfo.Name = "lboInfo";
            this.lboInfo.Size = new System.Drawing.Size(494, 82);
            this.lboInfo.TabIndex = 0;
            // 
            // lblNotProduction
            // 
            this.lblNotProduction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotProduction.Location = new System.Drawing.Point(12, 53);
            this.lblNotProduction.Name = "lblNotProduction";
            this.lblNotProduction.Size = new System.Drawing.Size(505, 14);
            this.lblNotProduction.TabIndex = 75;
            this.lblNotProduction.Text = "This sample is NOT to be used in production or during conformance testing.";
            this.lblNotProduction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWarning
            // 
            this.lblWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarning.Location = new System.Drawing.Point(12, 28);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(505, 23);
            this.lblWarning.TabIndex = 74;
            this.lblWarning.Text = "WARNING!";
            this.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMEAPI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 449);
            this.Controls.Add(this.lblNotProduction);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.gboInfo);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.gboProductTypes);
            this.Controls.Add(this.gboProductList);
            this.Controls.Add(this.gboExchangeList);
            this.Controls.Add(this.btnReqestGateways);
            this.Controls.Add(this.sbaStatus);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMEAPI";
            this.Text = "MEAPI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainWindow_FormClosed);
            this.sbaStatus.ResumeLayout(false);
            this.sbaStatus.PerformLayout();
            this.gboExchangeList.ResumeLayout(false);
            this.gboProductList.ResumeLayout(false);
            this.gboProductTypes.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gboInfo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView lboProductList;
        private System.Windows.Forms.ListBox lboGateways;
        private System.Windows.Forms.Button btnReqestGateways;
        private System.Windows.Forms.StatusStrip sbaStatus;
        private System.Windows.Forms.ToolStripStatusLabel tsStatus;
        private System.Windows.Forms.GroupBox gboExchangeList;
        private System.Windows.Forms.GroupBox gboProductList;
        private System.Windows.Forms.GroupBox gboProductTypes;
        private System.Windows.Forms.ListBox lboProductTypes;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.GroupBox gboInfo;
        private System.Windows.Forms.ListBox lboInfo;
        private System.Windows.Forms.Label lblNotProduction;
        private System.Windows.Forms.Label lblWarning;
    }
}


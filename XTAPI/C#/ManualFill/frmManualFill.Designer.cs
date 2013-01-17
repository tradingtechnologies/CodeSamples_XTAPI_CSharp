namespace XTAPI_Samples
{
    partial class frmManualFill
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
            this.gboManualFillServices = new System.Windows.Forms.GroupBox();
            this.lblDragNDrop = new System.Windows.Forms.Label();
            this.optSell = new System.Windows.Forms.RadioButton();
            this.optBuy = new System.Windows.Forms.RadioButton();
            this.btnCreateManualFill = new System.Windows.Forms.Button();
            this.cboMPublishPriceFormat = new System.Windows.Forms.ComboBox();
            this.lblPriceFormat = new System.Windows.Forms.Label();
            this.txtPublishPrice = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtPublishQty = new System.Windows.Forms.TextBox();
            this.gboMGTInfo = new System.Windows.Forms.GroupBox();
            this.lblMFAccount = new System.Windows.Forms.Label();
            this.txtAcctManualFill = new System.Windows.Forms.TextBox();
            this.txtMemberManualFill = new System.Windows.Forms.TextBox();
            this.txtGroupManualFill = new System.Windows.Forms.TextBox();
            this.lblMFGroup = new System.Windows.Forms.Label();
            this.lblMFTrader = new System.Windows.Forms.Label();
            this.txtTraderManualFill = new System.Windows.Forms.TextBox();
            this.lblMFMember = new System.Windows.Forms.Label();
            this.gboExchangeInfo = new System.Windows.Forms.GroupBox();
            this.txtMFoundExchange = new System.Windows.Forms.TextBox();
            this.txtMFoundProduct = new System.Windows.Forms.TextBox();
            this.lblMFProduct = new System.Windows.Forms.Label();
            this.lblMFProductType = new System.Windows.Forms.Label();
            this.lblMFExchange = new System.Windows.Forms.Label();
            this.txtMFoundProdType = new System.Windows.Forms.TextBox();
            this.lblMFContract = new System.Windows.Forms.Label();
            this.txtMFoundContract = new System.Windows.Forms.TextBox();
            this.sbaStatus = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.gboConnectionStatus = new System.Windows.Forms.GroupBox();
            this.lblOnDataLoaded = new System.Windows.Forms.Label();
            this.lblSODOnDataLoaded = new System.Windows.Forms.Label();
            this.lblXTPro = new System.Windows.Forms.Label();
            this.lblXTraderProConnection = new System.Windows.Forms.Label();
            this.lblXTrader = new System.Windows.Forms.Label();
            this.lblXTraderConnection = new System.Windows.Forms.Label();
            this.lblFillConnection = new System.Windows.Forms.Label();
            this.lblFillServerConnection = new System.Windows.Forms.Label();
            this.gboAdminRiskLogin = new System.Windows.Forms.GroupBox();
            this.btnLoginRiskAdmin = new System.Windows.Forms.Button();
            this.txtRiskAdminTrader = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtRiskAdminPassword = new System.Windows.Forms.TextBox();
            this.lblTrader = new System.Windows.Forms.Label();
            this.txtRiskAdminGroup = new System.Windows.Forms.TextBox();
            this.lblGroup = new System.Windows.Forms.Label();
            this.txtRiskAdminMember = new System.Windows.Forms.TextBox();
            this.lblMember = new System.Windows.Forms.Label();
            this.txtRiskAdminExchange = new System.Windows.Forms.TextBox();
            this.lblExchange = new System.Windows.Forms.Label();
            this.gboManualFillRecords = new System.Windows.Forms.GroupBox();
            this.txtManualFillRecords = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gboManualFillServices.SuspendLayout();
            this.gboMGTInfo.SuspendLayout();
            this.gboExchangeInfo.SuspendLayout();
            this.sbaStatus.SuspendLayout();
            this.gboConnectionStatus.SuspendLayout();
            this.gboAdminRiskLogin.SuspendLayout();
            this.gboManualFillRecords.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboManualFillServices
            // 
            this.gboManualFillServices.Controls.Add(this.lblDragNDrop);
            this.gboManualFillServices.Controls.Add(this.optSell);
            this.gboManualFillServices.Controls.Add(this.optBuy);
            this.gboManualFillServices.Controls.Add(this.btnCreateManualFill);
            this.gboManualFillServices.Controls.Add(this.cboMPublishPriceFormat);
            this.gboManualFillServices.Controls.Add(this.lblPriceFormat);
            this.gboManualFillServices.Controls.Add(this.txtPublishPrice);
            this.gboManualFillServices.Controls.Add(this.lblPrice);
            this.gboManualFillServices.Controls.Add(this.lblQty);
            this.gboManualFillServices.Controls.Add(this.txtPublishQty);
            this.gboManualFillServices.Controls.Add(this.gboMGTInfo);
            this.gboManualFillServices.Controls.Add(this.gboExchangeInfo);
            this.gboManualFillServices.Enabled = false;
            this.gboManualFillServices.Location = new System.Drawing.Point(580, 27);
            this.gboManualFillServices.Name = "gboManualFillServices";
            this.gboManualFillServices.Size = new System.Drawing.Size(248, 452);
            this.gboManualFillServices.TabIndex = 128;
            this.gboManualFillServices.TabStop = false;
            this.gboManualFillServices.Text = "Manual Fill Services";
            // 
            // lblDragNDrop
            // 
            this.lblDragNDrop.AutoSize = true;
            this.lblDragNDrop.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDragNDrop.Location = new System.Drawing.Point(18, 387);
            this.lblDragNDrop.Name = "lblDragNDrop";
            this.lblDragNDrop.Size = new System.Drawing.Size(212, 12);
            this.lblDragNDrop.TabIndex = 29;
            this.lblDragNDrop.Text = "Drag and Drop a contrct from X_TRADER";
            // 
            // optSell
            // 
            this.optSell.AutoSize = true;
            this.optSell.Enabled = false;
            this.optSell.Location = new System.Drawing.Point(181, 322);
            this.optSell.Name = "optSell";
            this.optSell.Size = new System.Drawing.Size(42, 17);
            this.optSell.TabIndex = 130;
            this.optSell.TabStop = true;
            this.optSell.Text = "Sell";
            this.optSell.UseVisualStyleBackColor = true;
            // 
            // optBuy
            // 
            this.optBuy.AutoSize = true;
            this.optBuy.Checked = true;
            this.optBuy.Enabled = false;
            this.optBuy.Location = new System.Drawing.Point(181, 296);
            this.optBuy.Name = "optBuy";
            this.optBuy.Size = new System.Drawing.Size(43, 17);
            this.optBuy.TabIndex = 129;
            this.optBuy.TabStop = true;
            this.optBuy.Text = "Buy";
            this.optBuy.UseVisualStyleBackColor = true;
            // 
            // btnCreateManualFill
            // 
            this.btnCreateManualFill.Enabled = false;
            this.btnCreateManualFill.Location = new System.Drawing.Point(69, 409);
            this.btnCreateManualFill.Name = "btnCreateManualFill";
            this.btnCreateManualFill.Size = new System.Drawing.Size(110, 36);
            this.btnCreateManualFill.TabIndex = 128;
            this.btnCreateManualFill.Text = "Create Manual Fill";
            this.btnCreateManualFill.UseVisualStyleBackColor = true;
            this.btnCreateManualFill.Click += new System.EventHandler(this.btnCreateManualFill_Click);
            // 
            // cboMPublishPriceFormat
            // 
            this.cboMPublishPriceFormat.Enabled = false;
            this.cboMPublishPriceFormat.FormattingEnabled = true;
            this.cboMPublishPriceFormat.Items.AddRange(new object[] {
            "$",
            "&",
            "#"});
            this.cboMPublishPriceFormat.Location = new System.Drawing.Point(96, 353);
            this.cboMPublishPriceFormat.Name = "cboMPublishPriceFormat";
            this.cboMPublishPriceFormat.Size = new System.Drawing.Size(79, 21);
            this.cboMPublishPriceFormat.TabIndex = 127;
            this.cboMPublishPriceFormat.Text = "$";
            // 
            // lblPriceFormat
            // 
            this.lblPriceFormat.AutoSize = true;
            this.lblPriceFormat.Location = new System.Drawing.Point(24, 356);
            this.lblPriceFormat.Name = "lblPriceFormat";
            this.lblPriceFormat.Size = new System.Drawing.Size(66, 13);
            this.lblPriceFormat.TabIndex = 126;
            this.lblPriceFormat.Text = "Price Format";
            // 
            // txtPublishPrice
            // 
            this.txtPublishPrice.Enabled = false;
            this.txtPublishPrice.Location = new System.Drawing.Point(96, 324);
            this.txtPublishPrice.Name = "txtPublishPrice";
            this.txtPublishPrice.Size = new System.Drawing.Size(79, 20);
            this.txtPublishPrice.TabIndex = 125;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(56, 327);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(31, 13);
            this.lblPrice.TabIndex = 124;
            this.lblPrice.Text = "Price";
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(64, 298);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(23, 13);
            this.lblQty.TabIndex = 122;
            this.lblQty.Text = "Qty";
            // 
            // txtPublishQty
            // 
            this.txtPublishQty.Enabled = false;
            this.txtPublishQty.Location = new System.Drawing.Point(96, 295);
            this.txtPublishQty.Name = "txtPublishQty";
            this.txtPublishQty.Size = new System.Drawing.Size(79, 20);
            this.txtPublishQty.TabIndex = 123;
            // 
            // gboMGTInfo
            // 
            this.gboMGTInfo.Controls.Add(this.lblMFAccount);
            this.gboMGTInfo.Controls.Add(this.txtAcctManualFill);
            this.gboMGTInfo.Controls.Add(this.txtMemberManualFill);
            this.gboMGTInfo.Controls.Add(this.txtGroupManualFill);
            this.gboMGTInfo.Controls.Add(this.lblMFGroup);
            this.gboMGTInfo.Controls.Add(this.lblMFTrader);
            this.gboMGTInfo.Controls.Add(this.txtTraderManualFill);
            this.gboMGTInfo.Controls.Add(this.lblMFMember);
            this.gboMGTInfo.Location = new System.Drawing.Point(6, 19);
            this.gboMGTInfo.Name = "gboMGTInfo";
            this.gboMGTInfo.Size = new System.Drawing.Size(236, 124);
            this.gboMGTInfo.TabIndex = 121;
            this.gboMGTInfo.TabStop = false;
            this.gboMGTInfo.Text = "MGT Info";
            // 
            // lblMFAccount
            // 
            this.lblMFAccount.AutoSize = true;
            this.lblMFAccount.Location = new System.Drawing.Point(23, 101);
            this.lblMFAccount.Name = "lblMFAccount";
            this.lblMFAccount.Size = new System.Drawing.Size(47, 13);
            this.lblMFAccount.TabIndex = 19;
            this.lblMFAccount.Text = "Account";
            // 
            // txtAcctManualFill
            // 
            this.txtAcctManualFill.Enabled = false;
            this.txtAcctManualFill.Location = new System.Drawing.Point(76, 98);
            this.txtAcctManualFill.Name = "txtAcctManualFill";
            this.txtAcctManualFill.Size = new System.Drawing.Size(144, 20);
            this.txtAcctManualFill.TabIndex = 18;
            // 
            // txtMemberManualFill
            // 
            this.txtMemberManualFill.Enabled = false;
            this.txtMemberManualFill.Location = new System.Drawing.Point(76, 19);
            this.txtMemberManualFill.Name = "txtMemberManualFill";
            this.txtMemberManualFill.Size = new System.Drawing.Size(144, 20);
            this.txtMemberManualFill.TabIndex = 13;
            this.txtMemberManualFill.Text = "TTORDDS";
            // 
            // txtGroupManualFill
            // 
            this.txtGroupManualFill.Enabled = false;
            this.txtGroupManualFill.Location = new System.Drawing.Point(76, 45);
            this.txtGroupManualFill.Name = "txtGroupManualFill";
            this.txtGroupManualFill.Size = new System.Drawing.Size(144, 20);
            this.txtGroupManualFill.TabIndex = 15;
            this.txtGroupManualFill.Text = "001";
            // 
            // lblMFGroup
            // 
            this.lblMFGroup.AutoSize = true;
            this.lblMFGroup.Location = new System.Drawing.Point(34, 48);
            this.lblMFGroup.Name = "lblMFGroup";
            this.lblMFGroup.Size = new System.Drawing.Size(36, 13);
            this.lblMFGroup.TabIndex = 14;
            this.lblMFGroup.Text = "Group";
            // 
            // lblMFTrader
            // 
            this.lblMFTrader.AutoSize = true;
            this.lblMFTrader.Location = new System.Drawing.Point(32, 75);
            this.lblMFTrader.Name = "lblMFTrader";
            this.lblMFTrader.Size = new System.Drawing.Size(38, 13);
            this.lblMFTrader.TabIndex = 16;
            this.lblMFTrader.Text = "Trader";
            // 
            // txtTraderManualFill
            // 
            this.txtTraderManualFill.Enabled = false;
            this.txtTraderManualFill.Location = new System.Drawing.Point(76, 72);
            this.txtTraderManualFill.Name = "txtTraderManualFill";
            this.txtTraderManualFill.Size = new System.Drawing.Size(144, 20);
            this.txtTraderManualFill.TabIndex = 17;
            this.txtTraderManualFill.Text = "001";
            // 
            // lblMFMember
            // 
            this.lblMFMember.AutoSize = true;
            this.lblMFMember.Location = new System.Drawing.Point(25, 22);
            this.lblMFMember.Name = "lblMFMember";
            this.lblMFMember.Size = new System.Drawing.Size(45, 13);
            this.lblMFMember.TabIndex = 12;
            this.lblMFMember.Text = "Member";
            // 
            // gboExchangeInfo
            // 
            this.gboExchangeInfo.Controls.Add(this.txtMFoundExchange);
            this.gboExchangeInfo.Controls.Add(this.txtMFoundProduct);
            this.gboExchangeInfo.Controls.Add(this.lblMFProduct);
            this.gboExchangeInfo.Controls.Add(this.lblMFProductType);
            this.gboExchangeInfo.Controls.Add(this.lblMFExchange);
            this.gboExchangeInfo.Controls.Add(this.txtMFoundProdType);
            this.gboExchangeInfo.Controls.Add(this.lblMFContract);
            this.gboExchangeInfo.Controls.Add(this.txtMFoundContract);
            this.gboExchangeInfo.Location = new System.Drawing.Point(6, 149);
            this.gboExchangeInfo.Name = "gboExchangeInfo";
            this.gboExchangeInfo.Size = new System.Drawing.Size(236, 137);
            this.gboExchangeInfo.TabIndex = 120;
            this.gboExchangeInfo.TabStop = false;
            this.gboExchangeInfo.Text = "Exchange Info";
            // 
            // txtMFoundExchange
            // 
            this.txtMFoundExchange.Enabled = false;
            this.txtMFoundExchange.Location = new System.Drawing.Point(94, 23);
            this.txtMFoundExchange.Name = "txtMFoundExchange";
            this.txtMFoundExchange.ReadOnly = true;
            this.txtMFoundExchange.Size = new System.Drawing.Size(121, 20);
            this.txtMFoundExchange.TabIndex = 22;
            // 
            // txtMFoundProduct
            // 
            this.txtMFoundProduct.Enabled = false;
            this.txtMFoundProduct.Location = new System.Drawing.Point(94, 49);
            this.txtMFoundProduct.Name = "txtMFoundProduct";
            this.txtMFoundProduct.ReadOnly = true;
            this.txtMFoundProduct.Size = new System.Drawing.Size(121, 20);
            this.txtMFoundProduct.TabIndex = 24;
            // 
            // lblMFProduct
            // 
            this.lblMFProduct.AutoSize = true;
            this.lblMFProduct.Location = new System.Drawing.Point(39, 52);
            this.lblMFProduct.Name = "lblMFProduct";
            this.lblMFProduct.Size = new System.Drawing.Size(44, 13);
            this.lblMFProduct.TabIndex = 23;
            this.lblMFProduct.Text = "Product";
            // 
            // lblMFProductType
            // 
            this.lblMFProductType.AutoSize = true;
            this.lblMFProductType.Location = new System.Drawing.Point(30, 81);
            this.lblMFProductType.Name = "lblMFProductType";
            this.lblMFProductType.Size = new System.Drawing.Size(53, 13);
            this.lblMFProductType.TabIndex = 25;
            this.lblMFProductType.Text = "ProdType";
            // 
            // lblMFExchange
            // 
            this.lblMFExchange.AutoSize = true;
            this.lblMFExchange.Location = new System.Drawing.Point(28, 26);
            this.lblMFExchange.Name = "lblMFExchange";
            this.lblMFExchange.Size = new System.Drawing.Size(55, 13);
            this.lblMFExchange.TabIndex = 21;
            this.lblMFExchange.Text = "Exchange";
            // 
            // txtMFoundProdType
            // 
            this.txtMFoundProdType.Enabled = false;
            this.txtMFoundProdType.Location = new System.Drawing.Point(94, 78);
            this.txtMFoundProdType.Name = "txtMFoundProdType";
            this.txtMFoundProdType.ReadOnly = true;
            this.txtMFoundProdType.Size = new System.Drawing.Size(121, 20);
            this.txtMFoundProdType.TabIndex = 26;
            // 
            // lblMFContract
            // 
            this.lblMFContract.AutoSize = true;
            this.lblMFContract.Location = new System.Drawing.Point(36, 107);
            this.lblMFContract.Name = "lblMFContract";
            this.lblMFContract.Size = new System.Drawing.Size(47, 13);
            this.lblMFContract.TabIndex = 27;
            this.lblMFContract.Text = "Contract";
            // 
            // txtMFoundContract
            // 
            this.txtMFoundContract.Enabled = false;
            this.txtMFoundContract.Location = new System.Drawing.Point(94, 104);
            this.txtMFoundContract.Name = "txtMFoundContract";
            this.txtMFoundContract.ReadOnly = true;
            this.txtMFoundContract.Size = new System.Drawing.Size(121, 20);
            this.txtMFoundContract.TabIndex = 28;
            this.txtMFoundContract.Text = " ";
            // 
            // sbaStatus
            // 
            this.sbaStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.sbaStatus.Location = new System.Drawing.Point(0, 492);
            this.sbaStatus.Name = "sbaStatus";
            this.sbaStatus.Size = new System.Drawing.Size(840, 22);
            this.sbaStatus.SizingGrip = false;
            this.sbaStatus.TabIndex = 127;
            this.sbaStatus.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // gboConnectionStatus
            // 
            this.gboConnectionStatus.Controls.Add(this.lblOnDataLoaded);
            this.gboConnectionStatus.Controls.Add(this.lblSODOnDataLoaded);
            this.gboConnectionStatus.Controls.Add(this.lblXTPro);
            this.gboConnectionStatus.Controls.Add(this.lblXTraderProConnection);
            this.gboConnectionStatus.Controls.Add(this.lblXTrader);
            this.gboConnectionStatus.Controls.Add(this.lblXTraderConnection);
            this.gboConnectionStatus.Controls.Add(this.lblFillConnection);
            this.gboConnectionStatus.Controls.Add(this.lblFillServerConnection);
            this.gboConnectionStatus.Location = new System.Drawing.Point(316, 29);
            this.gboConnectionStatus.Name = "gboConnectionStatus";
            this.gboConnectionStatus.Size = new System.Drawing.Size(258, 141);
            this.gboConnectionStatus.TabIndex = 126;
            this.gboConnectionStatus.TabStop = false;
            this.gboConnectionStatus.Text = "Connection Status";
            // 
            // lblOnDataLoaded
            // 
            this.lblOnDataLoaded.BackColor = System.Drawing.Color.Red;
            this.lblOnDataLoaded.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOnDataLoaded.Location = new System.Drawing.Point(124, 111);
            this.lblOnDataLoaded.Name = "lblOnDataLoaded";
            this.lblOnDataLoaded.Size = new System.Drawing.Size(121, 18);
            this.lblOnDataLoaded.TabIndex = 9;
            this.lblOnDataLoaded.Text = "- not downloaded";
            this.lblOnDataLoaded.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSODOnDataLoaded
            // 
            this.lblSODOnDataLoaded.AutoSize = true;
            this.lblSODOnDataLoaded.Location = new System.Drawing.Point(6, 114);
            this.lblSODOnDataLoaded.Name = "lblSODOnDataLoaded";
            this.lblSODOnDataLoaded.Size = new System.Drawing.Size(106, 13);
            this.lblSODOnDataLoaded.TabIndex = 8;
            this.lblSODOnDataLoaded.Text = "SOD OnDataLoaded";
            // 
            // lblXTPro
            // 
            this.lblXTPro.BackColor = System.Drawing.Color.Red;
            this.lblXTPro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblXTPro.Location = new System.Drawing.Point(124, 82);
            this.lblXTPro.Name = "lblXTPro";
            this.lblXTPro.Size = new System.Drawing.Size(121, 18);
            this.lblXTPro.TabIndex = 5;
            this.lblXTPro.Text = "- not connected";
            this.lblXTPro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblXTraderProConnection
            // 
            this.lblXTraderProConnection.AutoSize = true;
            this.lblXTraderProConnection.Location = new System.Drawing.Point(6, 85);
            this.lblXTraderProConnection.Name = "lblXTraderProConnection";
            this.lblXTraderProConnection.Size = new System.Drawing.Size(84, 13);
            this.lblXTraderProConnection.TabIndex = 4;
            this.lblXTraderProConnection.Text = "X_TRADER Pro";
            // 
            // lblXTrader
            // 
            this.lblXTrader.BackColor = System.Drawing.Color.Red;
            this.lblXTrader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblXTrader.Location = new System.Drawing.Point(124, 51);
            this.lblXTrader.Name = "lblXTrader";
            this.lblXTrader.Size = new System.Drawing.Size(121, 18);
            this.lblXTrader.TabIndex = 3;
            this.lblXTrader.Text = "- not connected";
            this.lblXTrader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblXTraderConnection
            // 
            this.lblXTraderConnection.AutoSize = true;
            this.lblXTraderConnection.Location = new System.Drawing.Point(6, 54);
            this.lblXTraderConnection.Name = "lblXTraderConnection";
            this.lblXTraderConnection.Size = new System.Drawing.Size(65, 13);
            this.lblXTraderConnection.TabIndex = 2;
            this.lblXTraderConnection.Text = "X_TRADER";
            // 
            // lblFillConnection
            // 
            this.lblFillConnection.BackColor = System.Drawing.Color.Red;
            this.lblFillConnection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFillConnection.Location = new System.Drawing.Point(124, 23);
            this.lblFillConnection.Name = "lblFillConnection";
            this.lblFillConnection.Size = new System.Drawing.Size(121, 18);
            this.lblFillConnection.TabIndex = 1;
            this.lblFillConnection.Text = "- not connected";
            this.lblFillConnection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFillServerConnection
            // 
            this.lblFillServerConnection.AutoSize = true;
            this.lblFillServerConnection.Location = new System.Drawing.Point(6, 26);
            this.lblFillServerConnection.Name = "lblFillServerConnection";
            this.lblFillServerConnection.Size = new System.Drawing.Size(110, 13);
            this.lblFillServerConnection.TabIndex = 0;
            this.lblFillServerConnection.Text = "Fill Server Connection";
            // 
            // gboAdminRiskLogin
            // 
            this.gboAdminRiskLogin.Controls.Add(this.btnLoginRiskAdmin);
            this.gboAdminRiskLogin.Controls.Add(this.txtRiskAdminTrader);
            this.gboAdminRiskLogin.Controls.Add(this.lblPassword);
            this.gboAdminRiskLogin.Controls.Add(this.txtRiskAdminPassword);
            this.gboAdminRiskLogin.Controls.Add(this.lblTrader);
            this.gboAdminRiskLogin.Controls.Add(this.txtRiskAdminGroup);
            this.gboAdminRiskLogin.Controls.Add(this.lblGroup);
            this.gboAdminRiskLogin.Controls.Add(this.txtRiskAdminMember);
            this.gboAdminRiskLogin.Controls.Add(this.lblMember);
            this.gboAdminRiskLogin.Controls.Add(this.txtRiskAdminExchange);
            this.gboAdminRiskLogin.Controls.Add(this.lblExchange);
            this.gboAdminRiskLogin.Location = new System.Drawing.Point(12, 27);
            this.gboAdminRiskLogin.Name = "gboAdminRiskLogin";
            this.gboAdminRiskLogin.Size = new System.Drawing.Size(298, 143);
            this.gboAdminRiskLogin.TabIndex = 125;
            this.gboAdminRiskLogin.TabStop = false;
            this.gboAdminRiskLogin.Text = "Admin Risk Login";
            // 
            // btnLoginRiskAdmin
            // 
            this.btnLoginRiskAdmin.Location = new System.Drawing.Point(185, 81);
            this.btnLoginRiskAdmin.Name = "btnLoginRiskAdmin";
            this.btnLoginRiskAdmin.Size = new System.Drawing.Size(100, 35);
            this.btnLoginRiskAdmin.TabIndex = 9;
            this.btnLoginRiskAdmin.Text = "Login";
            this.btnLoginRiskAdmin.UseVisualStyleBackColor = true;
            this.btnLoginRiskAdmin.Click += new System.EventHandler(this.btnLoginRiskAdmin_Click);
            // 
            // txtRiskAdminTrader
            // 
            this.txtRiskAdminTrader.Location = new System.Drawing.Point(70, 113);
            this.txtRiskAdminTrader.Name = "txtRiskAdminTrader";
            this.txtRiskAdminTrader.Size = new System.Drawing.Size(100, 20);
            this.txtRiskAdminTrader.TabIndex = 7;
            this.txtRiskAdminTrader.Text = "MGR";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(209, 32);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 10;
            this.lblPassword.Text = "Password";
            // 
            // txtRiskAdminPassword
            // 
            this.txtRiskAdminPassword.Location = new System.Drawing.Point(185, 53);
            this.txtRiskAdminPassword.Name = "txtRiskAdminPassword";
            this.txtRiskAdminPassword.PasswordChar = '*';
            this.txtRiskAdminPassword.Size = new System.Drawing.Size(100, 20);
            this.txtRiskAdminPassword.TabIndex = 11;
            this.txtRiskAdminPassword.Text = "12345678";
            // 
            // lblTrader
            // 
            this.lblTrader.AutoSize = true;
            this.lblTrader.Location = new System.Drawing.Point(26, 116);
            this.lblTrader.Name = "lblTrader";
            this.lblTrader.Size = new System.Drawing.Size(38, 13);
            this.lblTrader.TabIndex = 6;
            this.lblTrader.Text = "Trader";
            // 
            // txtRiskAdminGroup
            // 
            this.txtRiskAdminGroup.Location = new System.Drawing.Point(70, 84);
            this.txtRiskAdminGroup.Name = "txtRiskAdminGroup";
            this.txtRiskAdminGroup.Size = new System.Drawing.Size(100, 20);
            this.txtRiskAdminGroup.TabIndex = 5;
            this.txtRiskAdminGroup.Text = "XXX";
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(28, 87);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(36, 13);
            this.lblGroup.TabIndex = 4;
            this.lblGroup.Text = "Group";
            // 
            // txtRiskAdminMember
            // 
            this.txtRiskAdminMember.Location = new System.Drawing.Point(70, 53);
            this.txtRiskAdminMember.Name = "txtRiskAdminMember";
            this.txtRiskAdminMember.Size = new System.Drawing.Size(100, 20);
            this.txtRiskAdminMember.TabIndex = 3;
            this.txtRiskAdminMember.Text = "TTORDDS";
            // 
            // lblMember
            // 
            this.lblMember.AutoSize = true;
            this.lblMember.Location = new System.Drawing.Point(19, 56);
            this.lblMember.Name = "lblMember";
            this.lblMember.Size = new System.Drawing.Size(45, 13);
            this.lblMember.TabIndex = 2;
            this.lblMember.Text = "Member";
            // 
            // txtRiskAdminExchange
            // 
            this.txtRiskAdminExchange.Location = new System.Drawing.Point(70, 25);
            this.txtRiskAdminExchange.Name = "txtRiskAdminExchange";
            this.txtRiskAdminExchange.Size = new System.Drawing.Size(100, 20);
            this.txtRiskAdminExchange.TabIndex = 1;
            this.txtRiskAdminExchange.Text = "CME";
            // 
            // lblExchange
            // 
            this.lblExchange.AutoSize = true;
            this.lblExchange.Location = new System.Drawing.Point(9, 28);
            this.lblExchange.Name = "lblExchange";
            this.lblExchange.Size = new System.Drawing.Size(55, 13);
            this.lblExchange.TabIndex = 0;
            this.lblExchange.Text = "Exchange";
            // 
            // gboManualFillRecords
            // 
            this.gboManualFillRecords.Controls.Add(this.txtManualFillRecords);
            this.gboManualFillRecords.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gboManualFillRecords.Location = new System.Drawing.Point(12, 176);
            this.gboManualFillRecords.Name = "gboManualFillRecords";
            this.gboManualFillRecords.Size = new System.Drawing.Size(562, 303);
            this.gboManualFillRecords.TabIndex = 124;
            this.gboManualFillRecords.TabStop = false;
            this.gboManualFillRecords.Text = "ManualFill Records";
            // 
            // txtManualFillRecords
            // 
            this.txtManualFillRecords.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtManualFillRecords.Location = new System.Drawing.Point(6, 23);
            this.txtManualFillRecords.Multiline = true;
            this.txtManualFillRecords.Name = "txtManualFillRecords";
            this.txtManualFillRecords.ReadOnly = true;
            this.txtManualFillRecords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtManualFillRecords.Size = new System.Drawing.Size(550, 273);
            this.txtManualFillRecords.TabIndex = 114;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(840, 24);
            this.menuStrip1.TabIndex = 129;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // frmManualFill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 514);
            this.Controls.Add(this.gboManualFillServices);
            this.Controls.Add(this.sbaStatus);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.gboConnectionStatus);
            this.Controls.Add(this.gboAdminRiskLogin);
            this.Controls.Add(this.gboManualFillRecords);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmManualFill";
            this.Text = "ManualFill";
            this.gboManualFillServices.ResumeLayout(false);
            this.gboManualFillServices.PerformLayout();
            this.gboMGTInfo.ResumeLayout(false);
            this.gboMGTInfo.PerformLayout();
            this.gboExchangeInfo.ResumeLayout(false);
            this.gboExchangeInfo.PerformLayout();
            this.sbaStatus.ResumeLayout(false);
            this.sbaStatus.PerformLayout();
            this.gboConnectionStatus.ResumeLayout(false);
            this.gboConnectionStatus.PerformLayout();
            this.gboAdminRiskLogin.ResumeLayout(false);
            this.gboAdminRiskLogin.PerformLayout();
            this.gboManualFillRecords.ResumeLayout(false);
            this.gboManualFillRecords.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gboManualFillServices;
        private System.Windows.Forms.Label lblDragNDrop;
        private System.Windows.Forms.RadioButton optSell;
        private System.Windows.Forms.RadioButton optBuy;
        private System.Windows.Forms.Button btnCreateManualFill;
        private System.Windows.Forms.ComboBox cboMPublishPriceFormat;
        private System.Windows.Forms.Label lblPriceFormat;
        private System.Windows.Forms.TextBox txtPublishPrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.TextBox txtPublishQty;
        private System.Windows.Forms.GroupBox gboMGTInfo;
        private System.Windows.Forms.Label lblMFAccount;
        private System.Windows.Forms.TextBox txtAcctManualFill;
        private System.Windows.Forms.TextBox txtMemberManualFill;
        private System.Windows.Forms.TextBox txtGroupManualFill;
        private System.Windows.Forms.Label lblMFGroup;
        private System.Windows.Forms.Label lblMFTrader;
        private System.Windows.Forms.TextBox txtTraderManualFill;
        private System.Windows.Forms.Label lblMFMember;
        private System.Windows.Forms.GroupBox gboExchangeInfo;
        private System.Windows.Forms.TextBox txtMFoundExchange;
        private System.Windows.Forms.TextBox txtMFoundProduct;
        private System.Windows.Forms.Label lblMFProduct;
        private System.Windows.Forms.Label lblMFProductType;
        private System.Windows.Forms.Label lblMFExchange;
        private System.Windows.Forms.TextBox txtMFoundProdType;
        private System.Windows.Forms.Label lblMFContract;
        private System.Windows.Forms.TextBox txtMFoundContract;
        private System.Windows.Forms.StatusStrip sbaStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox gboConnectionStatus;
        private System.Windows.Forms.Label lblOnDataLoaded;
        private System.Windows.Forms.Label lblSODOnDataLoaded;
        private System.Windows.Forms.Label lblXTPro;
        private System.Windows.Forms.Label lblXTraderProConnection;
        private System.Windows.Forms.Label lblXTrader;
        private System.Windows.Forms.Label lblXTraderConnection;
        private System.Windows.Forms.Label lblFillConnection;
        private System.Windows.Forms.Label lblFillServerConnection;
        private System.Windows.Forms.GroupBox gboAdminRiskLogin;
        private System.Windows.Forms.Button btnLoginRiskAdmin;
        private System.Windows.Forms.TextBox txtRiskAdminTrader;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtRiskAdminPassword;
        private System.Windows.Forms.Label lblTrader;
        private System.Windows.Forms.TextBox txtRiskAdminGroup;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.TextBox txtRiskAdminMember;
        private System.Windows.Forms.Label lblMember;
        private System.Windows.Forms.TextBox txtRiskAdminExchange;
        private System.Windows.Forms.Label lblExchange;
        private System.Windows.Forms.GroupBox gboManualFillRecords;
        private System.Windows.Forms.TextBox txtManualFillRecords;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}


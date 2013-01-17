namespace XTAPI_Samples
{
    partial class frmStartOfDay
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gboSODServices = new System.Windows.Forms.GroupBox();
            this.lblDragNDrop = new System.Windows.Forms.Label();
            this.gboMGTInfo = new System.Windows.Forms.GroupBox();
            this.txtMember = new System.Windows.Forms.TextBox();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.btnGetSodSet = new System.Windows.Forms.Button();
            this.lblSODGroup = new System.Windows.Forms.Label();
            this.lblSODTrader = new System.Windows.Forms.Label();
            this.txtTrader = new System.Windows.Forms.TextBox();
            this.lblSODMember = new System.Windows.Forms.Label();
            this.btnAddSod = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.txtPublishNewNetPosition = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cboPublishPriceFormat = new System.Windows.Forms.ComboBox();
            this.lblNewNetPos = new System.Windows.Forms.Label();
            this.lblNewAvgPrice = new System.Windows.Forms.Label();
            this.lblPriceFormat = new System.Windows.Forms.Label();
            this.txtPublishNewAvgPrice = new System.Windows.Forms.TextBox();
            this.gboExchangeInfo = new System.Windows.Forms.GroupBox();
            this.txtFoundExchange = new System.Windows.Forms.TextBox();
            this.txtFoundProduct = new System.Windows.Forms.TextBox();
            this.lblSODProduct = new System.Windows.Forms.Label();
            this.lblSODProductType = new System.Windows.Forms.Label();
            this.lblSODExchange = new System.Windows.Forms.Label();
            this.txtFoundProdType = new System.Windows.Forms.TextBox();
            this.lblSODContract = new System.Windows.Forms.Label();
            this.txtFoundContract = new System.Windows.Forms.TextBox();
            this.btnPublish = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gboConnectionStatus = new System.Windows.Forms.GroupBox();
            this.lblOnDataLoaded = new System.Windows.Forms.Label();
            this.lblSODOnDataLoaded = new System.Windows.Forms.Label();
            this.lblXTPro = new System.Windows.Forms.Label();
            this.lblXTraderProStatus = new System.Windows.Forms.Label();
            this.lblXTrader = new System.Windows.Forms.Label();
            this.lblXTraderStatus = new System.Windows.Forms.Label();
            this.lblFillConnection = new System.Windows.Forms.Label();
            this.lblFillServerConnection = new System.Windows.Forms.Label();
            this.gboAdminRisk = new System.Windows.Forms.GroupBox();
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
            this.gboSODRecords = new System.Windows.Forms.GroupBox();
            this.txtSODRecords = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sbaStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.gboSODServices.SuspendLayout();
            this.gboMGTInfo.SuspendLayout();
            this.gboExchangeInfo.SuspendLayout();
            this.gboConnectionStatus.SuspendLayout();
            this.gboAdminRisk.SuspendLayout();
            this.gboSODRecords.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(848, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // gboSODServices
            // 
            this.gboSODServices.Controls.Add(this.lblDragNDrop);
            this.gboSODServices.Controls.Add(this.gboMGTInfo);
            this.gboSODServices.Controls.Add(this.btnAddSod);
            this.gboSODServices.Controls.Add(this.btnDeleteAll);
            this.gboSODServices.Controls.Add(this.txtPublishNewNetPosition);
            this.gboSODServices.Controls.Add(this.btnDelete);
            this.gboSODServices.Controls.Add(this.cboPublishPriceFormat);
            this.gboSODServices.Controls.Add(this.lblNewNetPos);
            this.gboSODServices.Controls.Add(this.lblNewAvgPrice);
            this.gboSODServices.Controls.Add(this.lblPriceFormat);
            this.gboSODServices.Controls.Add(this.txtPublishNewAvgPrice);
            this.gboSODServices.Controls.Add(this.gboExchangeInfo);
            this.gboSODServices.Controls.Add(this.btnPublish);
            this.gboSODServices.Controls.Add(this.btnSave);
            this.gboSODServices.Enabled = false;
            this.gboSODServices.Location = new System.Drawing.Point(580, 29);
            this.gboSODServices.Name = "gboSODServices";
            this.gboSODServices.Size = new System.Drawing.Size(258, 450);
            this.gboSODServices.TabIndex = 125;
            this.gboSODServices.TabStop = false;
            this.gboSODServices.Text = "SOD Services";
            // 
            // lblDragNDrop
            // 
            this.lblDragNDrop.AutoSize = true;
            this.lblDragNDrop.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDragNDrop.Location = new System.Drawing.Point(32, 381);
            this.lblDragNDrop.Name = "lblDragNDrop";
            this.lblDragNDrop.Size = new System.Drawing.Size(218, 12);
            this.lblDragNDrop.TabIndex = 29;
            this.lblDragNDrop.Text = "Drag and Drop a contract from X_TRADER";
            // 
            // gboMGTInfo
            // 
            this.gboMGTInfo.Controls.Add(this.txtMember);
            this.gboMGTInfo.Controls.Add(this.txtGroup);
            this.gboMGTInfo.Controls.Add(this.btnGetSodSet);
            this.gboMGTInfo.Controls.Add(this.lblSODGroup);
            this.gboMGTInfo.Controls.Add(this.lblSODTrader);
            this.gboMGTInfo.Controls.Add(this.txtTrader);
            this.gboMGTInfo.Controls.Add(this.lblSODMember);
            this.gboMGTInfo.Location = new System.Drawing.Point(10, 17);
            this.gboMGTInfo.Name = "gboMGTInfo";
            this.gboMGTInfo.Size = new System.Drawing.Size(243, 124);
            this.gboMGTInfo.TabIndex = 117;
            this.gboMGTInfo.TabStop = false;
            this.gboMGTInfo.Text = "MGT Info";
            // 
            // txtMember
            // 
            this.txtMember.Enabled = false;
            this.txtMember.Location = new System.Drawing.Point(82, 15);
            this.txtMember.Name = "txtMember";
            this.txtMember.Size = new System.Drawing.Size(144, 20);
            this.txtMember.TabIndex = 13;
            this.txtMember.Text = "TTORDDS";
            // 
            // txtGroup
            // 
            this.txtGroup.Enabled = false;
            this.txtGroup.Location = new System.Drawing.Point(82, 41);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(144, 20);
            this.txtGroup.TabIndex = 15;
            this.txtGroup.Text = "001";
            // 
            // btnGetSodSet
            // 
            this.btnGetSodSet.Enabled = false;
            this.btnGetSodSet.Location = new System.Drawing.Point(82, 97);
            this.btnGetSodSet.Name = "btnGetSodSet";
            this.btnGetSodSet.Size = new System.Drawing.Size(144, 23);
            this.btnGetSodSet.TabIndex = 14;
            this.btnGetSodSet.Text = "Get All Records by MGT";
            this.btnGetSodSet.UseVisualStyleBackColor = true;
            this.btnGetSodSet.Click += new System.EventHandler(this.btnGetSodSet_Click);
            // 
            // lblSODGroup
            // 
            this.lblSODGroup.AutoSize = true;
            this.lblSODGroup.Location = new System.Drawing.Point(40, 44);
            this.lblSODGroup.Name = "lblSODGroup";
            this.lblSODGroup.Size = new System.Drawing.Size(36, 13);
            this.lblSODGroup.TabIndex = 14;
            this.lblSODGroup.Text = "Group";
            // 
            // lblSODTrader
            // 
            this.lblSODTrader.AutoSize = true;
            this.lblSODTrader.Location = new System.Drawing.Point(38, 71);
            this.lblSODTrader.Name = "lblSODTrader";
            this.lblSODTrader.Size = new System.Drawing.Size(38, 13);
            this.lblSODTrader.TabIndex = 16;
            this.lblSODTrader.Text = "Trader";
            // 
            // txtTrader
            // 
            this.txtTrader.Enabled = false;
            this.txtTrader.Location = new System.Drawing.Point(82, 68);
            this.txtTrader.Name = "txtTrader";
            this.txtTrader.Size = new System.Drawing.Size(144, 20);
            this.txtTrader.TabIndex = 17;
            this.txtTrader.Text = "001";
            // 
            // lblSODMember
            // 
            this.lblSODMember.AutoSize = true;
            this.lblSODMember.Location = new System.Drawing.Point(31, 18);
            this.lblSODMember.Name = "lblSODMember";
            this.lblSODMember.Size = new System.Drawing.Size(45, 13);
            this.lblSODMember.TabIndex = 12;
            this.lblSODMember.Text = "Member";
            // 
            // btnAddSod
            // 
            this.btnAddSod.Enabled = false;
            this.btnAddSod.Location = new System.Drawing.Point(176, 289);
            this.btnAddSod.Name = "btnAddSod";
            this.btnAddSod.Size = new System.Drawing.Size(76, 23);
            this.btnAddSod.TabIndex = 38;
            this.btnAddSod.Text = "Add SOD";
            this.btnAddSod.UseVisualStyleBackColor = true;
            this.btnAddSod.Click += new System.EventHandler(this.btnAddSod_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(176, 348);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(76, 23);
            this.btnDeleteAll.TabIndex = 119;
            this.btnDeleteAll.Text = "Delete All";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // txtPublishNewNetPosition
            // 
            this.txtPublishNewNetPosition.Enabled = false;
            this.txtPublishNewNetPosition.Location = new System.Drawing.Point(91, 291);
            this.txtPublishNewNetPosition.Name = "txtPublishNewNetPosition";
            this.txtPublishNewNetPosition.Size = new System.Drawing.Size(79, 20);
            this.txtPublishNewNetPosition.TabIndex = 30;
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(176, 318);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(76, 23);
            this.btnDelete.TabIndex = 41;
            this.btnDelete.Text = "Delete SOD";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cboPublishPriceFormat
            // 
            this.cboPublishPriceFormat.Enabled = false;
            this.cboPublishPriceFormat.FormattingEnabled = true;
            this.cboPublishPriceFormat.Items.AddRange(new object[] {
            "$",
            "&",
            "#"});
            this.cboPublishPriceFormat.Location = new System.Drawing.Point(91, 349);
            this.cboPublishPriceFormat.Name = "cboPublishPriceFormat";
            this.cboPublishPriceFormat.Size = new System.Drawing.Size(79, 21);
            this.cboPublishPriceFormat.TabIndex = 36;
            this.cboPublishPriceFormat.Text = "$";
            // 
            // lblNewNetPos
            // 
            this.lblNewNetPos.AutoSize = true;
            this.lblNewNetPos.Location = new System.Drawing.Point(18, 294);
            this.lblNewNetPos.Name = "lblNewNetPos";
            this.lblNewNetPos.Size = new System.Drawing.Size(67, 13);
            this.lblNewNetPos.TabIndex = 29;
            this.lblNewNetPos.Text = "New NetPos";
            // 
            // lblNewAvgPrice
            // 
            this.lblNewAvgPrice.AutoSize = true;
            this.lblNewAvgPrice.Location = new System.Drawing.Point(7, 323);
            this.lblNewAvgPrice.Name = "lblNewAvgPrice";
            this.lblNewAvgPrice.Size = new System.Drawing.Size(78, 13);
            this.lblNewAvgPrice.TabIndex = 31;
            this.lblNewAvgPrice.Text = "New Avg Price";
            // 
            // lblPriceFormat
            // 
            this.lblPriceFormat.AutoSize = true;
            this.lblPriceFormat.Location = new System.Drawing.Point(19, 352);
            this.lblPriceFormat.Name = "lblPriceFormat";
            this.lblPriceFormat.Size = new System.Drawing.Size(66, 13);
            this.lblPriceFormat.TabIndex = 33;
            this.lblPriceFormat.Text = "Price Format";
            // 
            // txtPublishNewAvgPrice
            // 
            this.txtPublishNewAvgPrice.Enabled = false;
            this.txtPublishNewAvgPrice.Location = new System.Drawing.Point(91, 320);
            this.txtPublishNewAvgPrice.Name = "txtPublishNewAvgPrice";
            this.txtPublishNewAvgPrice.Size = new System.Drawing.Size(79, 20);
            this.txtPublishNewAvgPrice.TabIndex = 32;
            // 
            // gboExchangeInfo
            // 
            this.gboExchangeInfo.Controls.Add(this.txtFoundExchange);
            this.gboExchangeInfo.Controls.Add(this.txtFoundProduct);
            this.gboExchangeInfo.Controls.Add(this.lblSODProduct);
            this.gboExchangeInfo.Controls.Add(this.lblSODProductType);
            this.gboExchangeInfo.Controls.Add(this.lblSODExchange);
            this.gboExchangeInfo.Controls.Add(this.txtFoundProdType);
            this.gboExchangeInfo.Controls.Add(this.lblSODContract);
            this.gboExchangeInfo.Controls.Add(this.txtFoundContract);
            this.gboExchangeInfo.Location = new System.Drawing.Point(9, 149);
            this.gboExchangeInfo.Name = "gboExchangeInfo";
            this.gboExchangeInfo.Size = new System.Drawing.Size(243, 127);
            this.gboExchangeInfo.TabIndex = 118;
            this.gboExchangeInfo.TabStop = false;
            this.gboExchangeInfo.Text = "Exchange Info";
            // 
            // txtFoundExchange
            // 
            this.txtFoundExchange.Enabled = false;
            this.txtFoundExchange.Location = new System.Drawing.Point(114, 16);
            this.txtFoundExchange.Name = "txtFoundExchange";
            this.txtFoundExchange.ReadOnly = true;
            this.txtFoundExchange.Size = new System.Drawing.Size(121, 20);
            this.txtFoundExchange.TabIndex = 22;
            // 
            // txtFoundProduct
            // 
            this.txtFoundProduct.Enabled = false;
            this.txtFoundProduct.Location = new System.Drawing.Point(114, 42);
            this.txtFoundProduct.Name = "txtFoundProduct";
            this.txtFoundProduct.ReadOnly = true;
            this.txtFoundProduct.Size = new System.Drawing.Size(121, 20);
            this.txtFoundProduct.TabIndex = 24;
            // 
            // lblSODProduct
            // 
            this.lblSODProduct.AutoSize = true;
            this.lblSODProduct.Location = new System.Drawing.Point(59, 45);
            this.lblSODProduct.Name = "lblSODProduct";
            this.lblSODProduct.Size = new System.Drawing.Size(44, 13);
            this.lblSODProduct.TabIndex = 23;
            this.lblSODProduct.Text = "Product";
            // 
            // lblSODProductType
            // 
            this.lblSODProductType.AutoSize = true;
            this.lblSODProductType.Location = new System.Drawing.Point(50, 74);
            this.lblSODProductType.Name = "lblSODProductType";
            this.lblSODProductType.Size = new System.Drawing.Size(53, 13);
            this.lblSODProductType.TabIndex = 25;
            this.lblSODProductType.Text = "ProdType";
            // 
            // lblSODExchange
            // 
            this.lblSODExchange.AutoSize = true;
            this.lblSODExchange.Location = new System.Drawing.Point(48, 19);
            this.lblSODExchange.Name = "lblSODExchange";
            this.lblSODExchange.Size = new System.Drawing.Size(55, 13);
            this.lblSODExchange.TabIndex = 21;
            this.lblSODExchange.Text = "Exchange";
            // 
            // txtFoundProdType
            // 
            this.txtFoundProdType.Enabled = false;
            this.txtFoundProdType.Location = new System.Drawing.Point(114, 71);
            this.txtFoundProdType.Name = "txtFoundProdType";
            this.txtFoundProdType.ReadOnly = true;
            this.txtFoundProdType.Size = new System.Drawing.Size(121, 20);
            this.txtFoundProdType.TabIndex = 26;
            // 
            // lblSODContract
            // 
            this.lblSODContract.AutoSize = true;
            this.lblSODContract.Location = new System.Drawing.Point(56, 100);
            this.lblSODContract.Name = "lblSODContract";
            this.lblSODContract.Size = new System.Drawing.Size(47, 13);
            this.lblSODContract.TabIndex = 27;
            this.lblSODContract.Text = "Contract";
            // 
            // txtFoundContract
            // 
            this.txtFoundContract.Enabled = false;
            this.txtFoundContract.Location = new System.Drawing.Point(114, 97);
            this.txtFoundContract.Name = "txtFoundContract";
            this.txtFoundContract.ReadOnly = true;
            this.txtFoundContract.Size = new System.Drawing.Size(121, 20);
            this.txtFoundContract.TabIndex = 28;
            this.txtFoundContract.Text = " ";
            // 
            // btnPublish
            // 
            this.btnPublish.Enabled = false;
            this.btnPublish.Location = new System.Drawing.Point(145, 406);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(99, 37);
            this.btnPublish.TabIndex = 40;
            this.btnPublish.Text = "Publish";
            this.btnPublish.UseVisualStyleBackColor = true;
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(22, 405);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 37);
            this.btnSave.TabIndex = 39;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gboConnectionStatus
            // 
            this.gboConnectionStatus.Controls.Add(this.lblOnDataLoaded);
            this.gboConnectionStatus.Controls.Add(this.lblSODOnDataLoaded);
            this.gboConnectionStatus.Controls.Add(this.lblXTPro);
            this.gboConnectionStatus.Controls.Add(this.lblXTraderProStatus);
            this.gboConnectionStatus.Controls.Add(this.lblXTrader);
            this.gboConnectionStatus.Controls.Add(this.lblXTraderStatus);
            this.gboConnectionStatus.Controls.Add(this.lblFillConnection);
            this.gboConnectionStatus.Controls.Add(this.lblFillServerConnection);
            this.gboConnectionStatus.Location = new System.Drawing.Point(316, 29);
            this.gboConnectionStatus.Name = "gboConnectionStatus";
            this.gboConnectionStatus.Size = new System.Drawing.Size(258, 141);
            this.gboConnectionStatus.TabIndex = 124;
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
            // lblXTraderProStatus
            // 
            this.lblXTraderProStatus.AutoSize = true;
            this.lblXTraderProStatus.Location = new System.Drawing.Point(6, 85);
            this.lblXTraderProStatus.Name = "lblXTraderProStatus";
            this.lblXTraderProStatus.Size = new System.Drawing.Size(84, 13);
            this.lblXTraderProStatus.TabIndex = 4;
            this.lblXTraderProStatus.Text = "X_TRADER Pro";
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
            // lblXTraderStatus
            // 
            this.lblXTraderStatus.AutoSize = true;
            this.lblXTraderStatus.Location = new System.Drawing.Point(6, 54);
            this.lblXTraderStatus.Name = "lblXTraderStatus";
            this.lblXTraderStatus.Size = new System.Drawing.Size(65, 13);
            this.lblXTraderStatus.TabIndex = 2;
            this.lblXTraderStatus.Text = "X_TRADER";
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
            // gboAdminRisk
            // 
            this.gboAdminRisk.Controls.Add(this.btnLoginRiskAdmin);
            this.gboAdminRisk.Controls.Add(this.txtRiskAdminTrader);
            this.gboAdminRisk.Controls.Add(this.lblPassword);
            this.gboAdminRisk.Controls.Add(this.txtRiskAdminPassword);
            this.gboAdminRisk.Controls.Add(this.lblTrader);
            this.gboAdminRisk.Controls.Add(this.txtRiskAdminGroup);
            this.gboAdminRisk.Controls.Add(this.lblGroup);
            this.gboAdminRisk.Controls.Add(this.txtRiskAdminMember);
            this.gboAdminRisk.Controls.Add(this.lblMember);
            this.gboAdminRisk.Controls.Add(this.txtRiskAdminExchange);
            this.gboAdminRisk.Controls.Add(this.lblExchange);
            this.gboAdminRisk.Location = new System.Drawing.Point(12, 27);
            this.gboAdminRisk.Name = "gboAdminRisk";
            this.gboAdminRisk.Size = new System.Drawing.Size(298, 143);
            this.gboAdminRisk.TabIndex = 123;
            this.gboAdminRisk.TabStop = false;
            this.gboAdminRisk.Text = "Admin Risk Login";
            // 
            // btnLoginRiskAdmin
            // 
            this.btnLoginRiskAdmin.Location = new System.Drawing.Point(192, 84);
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
            this.lblPassword.Location = new System.Drawing.Point(214, 30);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 10;
            this.lblPassword.Text = "Password";
            // 
            // txtRiskAdminPassword
            // 
            this.txtRiskAdminPassword.Location = new System.Drawing.Point(192, 53);
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
            // gboSODRecords
            // 
            this.gboSODRecords.Controls.Add(this.txtSODRecords);
            this.gboSODRecords.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gboSODRecords.Location = new System.Drawing.Point(12, 176);
            this.gboSODRecords.Name = "gboSODRecords";
            this.gboSODRecords.Size = new System.Drawing.Size(562, 303);
            this.gboSODRecords.TabIndex = 122;
            this.gboSODRecords.TabStop = false;
            this.gboSODRecords.Text = "Start Of Day Records";
            // 
            // txtSODRecords
            // 
            this.txtSODRecords.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtSODRecords.Location = new System.Drawing.Point(6, 23);
            this.txtSODRecords.Multiline = true;
            this.txtSODRecords.Name = "txtSODRecords";
            this.txtSODRecords.ReadOnly = true;
            this.txtSODRecords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSODRecords.Size = new System.Drawing.Size(550, 273);
            this.txtSODRecords.TabIndex = 114;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbaStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 488);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(848, 22);
            this.statusStrip1.TabIndex = 126;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sbaStatus
            // 
            this.sbaStatus.Name = "sbaStatus";
            this.sbaStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // frmStartOfDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 510);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gboSODServices);
            this.Controls.Add(this.gboConnectionStatus);
            this.Controls.Add(this.gboAdminRisk);
            this.Controls.Add(this.gboSODRecords);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmStartOfDay";
            this.Text = "StartOfDay";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gboSODServices.ResumeLayout(false);
            this.gboSODServices.PerformLayout();
            this.gboMGTInfo.ResumeLayout(false);
            this.gboMGTInfo.PerformLayout();
            this.gboExchangeInfo.ResumeLayout(false);
            this.gboExchangeInfo.PerformLayout();
            this.gboConnectionStatus.ResumeLayout(false);
            this.gboConnectionStatus.PerformLayout();
            this.gboAdminRisk.ResumeLayout(false);
            this.gboAdminRisk.PerformLayout();
            this.gboSODRecords.ResumeLayout(false);
            this.gboSODRecords.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox gboSODServices;
        private System.Windows.Forms.Label lblDragNDrop;
        private System.Windows.Forms.GroupBox gboMGTInfo;
        private System.Windows.Forms.TextBox txtMember;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.Button btnGetSodSet;
        private System.Windows.Forms.Label lblSODGroup;
        private System.Windows.Forms.Label lblSODTrader;
        private System.Windows.Forms.TextBox txtTrader;
        private System.Windows.Forms.Label lblSODMember;
        private System.Windows.Forms.Button btnAddSod;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.TextBox txtPublishNewNetPosition;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cboPublishPriceFormat;
        private System.Windows.Forms.Label lblNewNetPos;
        private System.Windows.Forms.Label lblNewAvgPrice;
        private System.Windows.Forms.Label lblPriceFormat;
        private System.Windows.Forms.TextBox txtPublishNewAvgPrice;
        private System.Windows.Forms.GroupBox gboExchangeInfo;
        private System.Windows.Forms.TextBox txtFoundExchange;
        private System.Windows.Forms.TextBox txtFoundProduct;
        private System.Windows.Forms.Label lblSODProduct;
        private System.Windows.Forms.Label lblSODProductType;
        private System.Windows.Forms.Label lblSODExchange;
        private System.Windows.Forms.TextBox txtFoundProdType;
        private System.Windows.Forms.Label lblSODContract;
        private System.Windows.Forms.TextBox txtFoundContract;
        private System.Windows.Forms.Button btnPublish;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gboConnectionStatus;
        private System.Windows.Forms.Label lblOnDataLoaded;
        private System.Windows.Forms.Label lblSODOnDataLoaded;
        private System.Windows.Forms.Label lblXTPro;
        private System.Windows.Forms.Label lblXTraderProStatus;
        private System.Windows.Forms.Label lblXTrader;
        private System.Windows.Forms.Label lblXTraderStatus;
        private System.Windows.Forms.Label lblFillConnection;
        private System.Windows.Forms.Label lblFillServerConnection;
        private System.Windows.Forms.GroupBox gboAdminRisk;
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
        private System.Windows.Forms.GroupBox gboSODRecords;
        private System.Windows.Forms.TextBox txtSODRecords;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sbaStatus;
    }
}


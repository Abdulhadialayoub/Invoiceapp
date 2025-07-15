namespace Fatureapp
{
    partial class invoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(invoice));
            this.panelMain = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageInvoice = new System.Windows.Forms.TabPage();
            this.groupBoxSeller = new System.Windows.Forms.GroupBox();
            this.txtSellerAddress = new System.Windows.Forms.TextBox();
            this.txtSellerPhone = new System.Windows.Forms.TextBox();
            this.txtTaxID = new System.Windows.Forms.TextBox();
            this.txtSellerName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelBankName = new System.Windows.Forms.Label();
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.labelIBAN = new System.Windows.Forms.Label();
            this.txtIBAN = new System.Windows.Forms.TextBox();
            this.groupBoxBuyer = new System.Windows.Forms.GroupBox();
            this.labelBuyerName = new System.Windows.Forms.Label();
            this.txtBuyerName = new System.Windows.Forms.TextBox();
            this.labelBuyerTaxID = new System.Windows.Forms.Label();
            this.txtBuyerTaxID = new System.Windows.Forms.TextBox();
            this.labelBuyerPhone = new System.Windows.Forms.Label();
            this.txtBuyerPhone = new System.Windows.Forms.TextBox();
            this.labelBuyerAddress = new System.Windows.Forms.Label();
            this.txtBuyerAddress = new System.Windows.Forms.TextBox();
            this.groupBoxInvoice = new System.Windows.Forms.GroupBox();
            this.cbPaymentTerms = new System.Windows.Forms.ComboBox();
            this.labelPaymentTerms = new System.Windows.Forms.Label();
            this.txtTaxAmount = new System.Windows.Forms.TextBox();
            this.labelTaxAmount = new System.Windows.Forms.Label();
            this.txtShippingCost = new System.Windows.Forms.TextBox();
            this.labelShippingCost = new System.Windows.Forms.Label();
            this.dtInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbInvoiceType = new System.Windows.Forms.ComboBox();
            this.labelInvoiceType = new System.Windows.Forms.Label();
            this.groupBoxItems = new System.Windows.Forms.GroupBox();
            this.dataGridViewItems = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabPageList = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewInvoices = new System.Windows.Forms.DataGridView();
            this.panelMain.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageInvoice.SuspendLayout();
            this.groupBoxSeller.SuspendLayout();
            this.groupBoxBuyer.SuspendLayout();
            this.groupBoxInvoice.SuspendLayout();
            this.groupBoxItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
            this.tabPageList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInvoices)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.tabControl1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1264, 681);
            this.panelMain.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageInvoice);
            this.tabControl1.Controls.Add(this.tabPageList);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1264, 681);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageInvoice
            // 
            this.tabPageInvoice.Controls.Add(this.groupBoxSeller);
            this.tabPageInvoice.Controls.Add(this.groupBoxBuyer);
            this.tabPageInvoice.Controls.Add(this.groupBoxInvoice);
            this.tabPageInvoice.Controls.Add(this.groupBoxItems);
            this.tabPageInvoice.Controls.Add(this.btnSave);
            this.tabPageInvoice.Location = new System.Drawing.Point(4, 22);
            this.tabPageInvoice.Name = "tabPageInvoice";
            this.tabPageInvoice.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInvoice.Size = new System.Drawing.Size(1256, 655);
            this.tabPageInvoice.TabIndex = 0;
            this.tabPageInvoice.Text = "Fatura Girişi";
            this.tabPageInvoice.UseVisualStyleBackColor = true;
            // 
            // groupBoxSeller
            // 
            this.groupBoxSeller.Controls.Add(this.txtSellerAddress);
            this.groupBoxSeller.Controls.Add(this.txtSellerPhone);
            this.groupBoxSeller.Controls.Add(this.txtTaxID);
            this.groupBoxSeller.Controls.Add(this.txtSellerName);
            this.groupBoxSeller.Controls.Add(this.label4);
            this.groupBoxSeller.Controls.Add(this.label3);
            this.groupBoxSeller.Controls.Add(this.label2);
            this.groupBoxSeller.Controls.Add(this.label1);
            this.groupBoxSeller.Controls.Add(this.labelBankName);
            this.groupBoxSeller.Controls.Add(this.txtBankName);
            this.groupBoxSeller.Controls.Add(this.labelIBAN);
            this.groupBoxSeller.Controls.Add(this.txtIBAN);
            this.groupBoxSeller.Location = new System.Drawing.Point(8, 6);
            this.groupBoxSeller.Name = "groupBoxSeller";
            this.groupBoxSeller.Size = new System.Drawing.Size(600, 150);
            this.groupBoxSeller.TabIndex = 0;
            this.groupBoxSeller.TabStop = false;
            this.groupBoxSeller.Text = "Satıcı Bilgileri";
            // 
            // txtSellerAddress
            // 
            this.txtSellerAddress.Location = new System.Drawing.Point(100, 110);
            this.txtSellerAddress.Multiline = true;
            this.txtSellerAddress.Name = "txtSellerAddress";
            this.txtSellerAddress.Size = new System.Drawing.Size(300, 30);
            this.txtSellerAddress.TabIndex = 3;
            // 
            // txtSellerPhone
            // 
            this.txtSellerPhone.Location = new System.Drawing.Point(100, 80);
            this.txtSellerPhone.Name = "txtSellerPhone";
            this.txtSellerPhone.Size = new System.Drawing.Size(150, 20);
            this.txtSellerPhone.TabIndex = 2;
            this.txtSellerPhone.Text = "05369200907";
            // 
            // txtTaxID
            // 
            this.txtTaxID.Location = new System.Drawing.Point(100, 50);
            this.txtTaxID.Name = "txtTaxID";
            this.txtTaxID.Size = new System.Drawing.Size(150, 20);
            this.txtTaxID.TabIndex = 1;
            this.txtTaxID.Text = "0022461289";
            // 
            // txtSellerName
            // 
            this.txtSellerName.Location = new System.Drawing.Point(100, 20);
            this.txtSellerName.Name = "txtSellerName";
            this.txtSellerName.Size = new System.Drawing.Size(200, 20);
            this.txtSellerName.TabIndex = 0;
            this.txtSellerName.Text = "ABU ALHUDA FOOD LIMITED COMPANY /   ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Adres:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Telefon:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Vergi No:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Firma Adı:";
            // 
            // labelBankName
            // 
            this.labelBankName.Location = new System.Drawing.Point(320, 23);
            this.labelBankName.Name = "labelBankName";
            this.labelBankName.Size = new System.Drawing.Size(54, 23);
            this.labelBankName.TabIndex = 8;
            this.labelBankName.Text = "Banka:";
            // 
            // txtBankName
            // 
            this.txtBankName.Location = new System.Drawing.Point(380, 20);
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Size = new System.Drawing.Size(200, 20);
            this.txtBankName.TabIndex = 9;
            // 
            // labelIBAN
            // 
            this.labelIBAN.Location = new System.Drawing.Point(320, 53);
            this.labelIBAN.Name = "labelIBAN";
            this.labelIBAN.Size = new System.Drawing.Size(54, 23);
            this.labelIBAN.TabIndex = 10;
            this.labelIBAN.Text = "IBAN:";
            // 
            // txtIBAN
            // 
            this.txtIBAN.Location = new System.Drawing.Point(380, 50);
            this.txtIBAN.Name = "txtIBAN";
            this.txtIBAN.Size = new System.Drawing.Size(200, 20);
            this.txtIBAN.TabIndex = 11;
            // 
            // groupBoxBuyer
            // 
            this.groupBoxBuyer.Controls.Add(this.labelBuyerName);
            this.groupBoxBuyer.Controls.Add(this.txtBuyerName);
            this.groupBoxBuyer.Controls.Add(this.labelBuyerTaxID);
            this.groupBoxBuyer.Controls.Add(this.txtBuyerTaxID);
            this.groupBoxBuyer.Controls.Add(this.labelBuyerPhone);
            this.groupBoxBuyer.Controls.Add(this.txtBuyerPhone);
            this.groupBoxBuyer.Controls.Add(this.labelBuyerAddress);
            this.groupBoxBuyer.Controls.Add(this.txtBuyerAddress);
            this.groupBoxBuyer.Location = new System.Drawing.Point(620, 6);
            this.groupBoxBuyer.Name = "groupBoxBuyer";
            this.groupBoxBuyer.Size = new System.Drawing.Size(600, 150);
            this.groupBoxBuyer.TabIndex = 4;
            this.groupBoxBuyer.TabStop = false;
            this.groupBoxBuyer.Text = "Alıcı Bilgileri";
            // 
            // labelBuyerName
            // 
            this.labelBuyerName.Location = new System.Drawing.Point(10, 23);
            this.labelBuyerName.Name = "labelBuyerName";
            this.labelBuyerName.Size = new System.Drawing.Size(100, 23);
            this.labelBuyerName.TabIndex = 0;
            this.labelBuyerName.Text = "Firma Adı:";
            // 
            // txtBuyerName
            // 
            this.txtBuyerName.Location = new System.Drawing.Point(119, 20);
            this.txtBuyerName.Name = "txtBuyerName";
            this.txtBuyerName.Size = new System.Drawing.Size(200, 20);
            this.txtBuyerName.TabIndex = 1;
            // 
            // labelBuyerTaxID
            // 
            this.labelBuyerTaxID.Location = new System.Drawing.Point(10, 53);
            this.labelBuyerTaxID.Name = "labelBuyerTaxID";
            this.labelBuyerTaxID.Size = new System.Drawing.Size(100, 23);
            this.labelBuyerTaxID.TabIndex = 2;
            this.labelBuyerTaxID.Text = "Vergi No:";
            // 
            // txtBuyerTaxID
            // 
            this.txtBuyerTaxID.Location = new System.Drawing.Point(120, 50);
            this.txtBuyerTaxID.Name = "txtBuyerTaxID";
            this.txtBuyerTaxID.Size = new System.Drawing.Size(150, 20);
            this.txtBuyerTaxID.TabIndex = 3;
            // 
            // labelBuyerPhone
            // 
            this.labelBuyerPhone.Location = new System.Drawing.Point(10, 83);
            this.labelBuyerPhone.Name = "labelBuyerPhone";
            this.labelBuyerPhone.Size = new System.Drawing.Size(100, 23);
            this.labelBuyerPhone.TabIndex = 4;
            this.labelBuyerPhone.Text = "Telefon:";
            // 
            // txtBuyerPhone
            // 
            this.txtBuyerPhone.Location = new System.Drawing.Point(121, 80);
            this.txtBuyerPhone.Name = "txtBuyerPhone";
            this.txtBuyerPhone.Size = new System.Drawing.Size(150, 20);
            this.txtBuyerPhone.TabIndex = 5;
            // 
            // labelBuyerAddress
            // 
            this.labelBuyerAddress.Location = new System.Drawing.Point(10, 113);
            this.labelBuyerAddress.Name = "labelBuyerAddress";
            this.labelBuyerAddress.Size = new System.Drawing.Size(100, 23);
            this.labelBuyerAddress.TabIndex = 6;
            this.labelBuyerAddress.Text = "Adres:";
            // 
            // txtBuyerAddress
            // 
            this.txtBuyerAddress.Location = new System.Drawing.Point(118, 110);
            this.txtBuyerAddress.Multiline = true;
            this.txtBuyerAddress.Name = "txtBuyerAddress";
            this.txtBuyerAddress.Size = new System.Drawing.Size(300, 30);
            this.txtBuyerAddress.TabIndex = 7;
            // 
            // groupBoxInvoice
            // 
            this.groupBoxInvoice.Controls.Add(this.cbPaymentTerms);
            this.groupBoxInvoice.Controls.Add(this.labelPaymentTerms);
            this.groupBoxInvoice.Controls.Add(this.txtTaxAmount);
            this.groupBoxInvoice.Controls.Add(this.labelTaxAmount);
            this.groupBoxInvoice.Controls.Add(this.txtShippingCost);
            this.groupBoxInvoice.Controls.Add(this.labelShippingCost);
            this.groupBoxInvoice.Controls.Add(this.dtInvoiceDate);
            this.groupBoxInvoice.Controls.Add(this.txtInvoiceNo);
            this.groupBoxInvoice.Controls.Add(this.label6);
            this.groupBoxInvoice.Controls.Add(this.label5);
            this.groupBoxInvoice.Controls.Add(this.cbInvoiceType);
            this.groupBoxInvoice.Controls.Add(this.labelInvoiceType);
            this.groupBoxInvoice.Location = new System.Drawing.Point(8, 162);
            this.groupBoxInvoice.Name = "groupBoxInvoice";
            this.groupBoxInvoice.Size = new System.Drawing.Size(600, 80);
            this.groupBoxInvoice.TabIndex = 1;
            this.groupBoxInvoice.TabStop = false;
            this.groupBoxInvoice.Text = "Fatura Bilgileri";
            // 
            // cbPaymentTerms
            // 
            this.cbPaymentTerms.FormattingEnabled = true;
            this.cbPaymentTerms.Items.AddRange(new object[] {
            "100% CAD AFTER SHIPMENT",
            "30% ADVANCE PAYMENT / 70% CAD AFTER SHIPMENT",
            "100% ADVANCE PAYMENT"});
            this.cbPaymentTerms.Location = new System.Drawing.Point(100, 110);
            this.cbPaymentTerms.Name = "cbPaymentTerms";
            this.cbPaymentTerms.Size = new System.Drawing.Size(200, 21);
            this.cbPaymentTerms.TabIndex = 9;
            // 
            // labelPaymentTerms
            // 
            this.labelPaymentTerms.AutoSize = true;
            this.labelPaymentTerms.Location = new System.Drawing.Point(10, 113);
            this.labelPaymentTerms.Name = "labelPaymentTerms";
            this.labelPaymentTerms.Size = new System.Drawing.Size(64, 13);
            this.labelPaymentTerms.TabIndex = 8;
            this.labelPaymentTerms.Text = "Ödeme Tipi:";
            // 
            // txtTaxAmount
            // 
            this.txtTaxAmount.Location = new System.Drawing.Point(425, 50);
            this.txtTaxAmount.Name = "txtTaxAmount";
            this.txtTaxAmount.Size = new System.Drawing.Size(100, 20);
            this.txtTaxAmount.TabIndex = 7;
            // 
            // labelTaxAmount
            // 
            this.labelTaxAmount.Location = new System.Drawing.Point(320, 53);
            this.labelTaxAmount.Name = "labelTaxAmount";
            this.labelTaxAmount.Size = new System.Drawing.Size(100, 23);
            this.labelTaxAmount.TabIndex = 6;
            this.labelTaxAmount.Text = "Vergi Tutarı:";
            // 
            // txtShippingCost
            // 
            this.txtShippingCost.Location = new System.Drawing.Point(424, 20);
            this.txtShippingCost.Name = "txtShippingCost";
            this.txtShippingCost.Size = new System.Drawing.Size(100, 20);
            this.txtShippingCost.TabIndex = 5;
            // 
            // labelShippingCost
            // 
            this.labelShippingCost.Location = new System.Drawing.Point(320, 23);
            this.labelShippingCost.Name = "labelShippingCost";
            this.labelShippingCost.Size = new System.Drawing.Size(100, 23);
            this.labelShippingCost.TabIndex = 4;
            this.labelShippingCost.Text = "Kargo Tutarı:";
            // 
            // dtInvoiceDate
            // 
            this.dtInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInvoiceDate.Location = new System.Drawing.Point(100, 50);
            this.dtInvoiceDate.Name = "dtInvoiceDate";
            this.dtInvoiceDate.Size = new System.Drawing.Size(150, 20);
            this.dtInvoiceDate.TabIndex = 1;
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(100, 20);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(150, 20);
            this.txtInvoiceNo.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Fatura Tarih:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Fatura No:";
            // 
            // cbInvoiceType
            // 
            this.cbInvoiceType.FormattingEnabled = true;
            this.cbInvoiceType.Items.AddRange(new object[] {
            "COMMERCIAL",
            "PROFORMA"});
            this.cbInvoiceType.Location = new System.Drawing.Point(400, 110);
            this.cbInvoiceType.Name = "cbInvoiceType";
            this.cbInvoiceType.Size = new System.Drawing.Size(180, 21);
            this.cbInvoiceType.TabIndex = 11;
            // 
            // labelInvoiceType
            // 
            this.labelInvoiceType.AutoSize = true;
            this.labelInvoiceType.Location = new System.Drawing.Point(320, 113);
            this.labelInvoiceType.Name = "labelInvoiceType";
            this.labelInvoiceType.Size = new System.Drawing.Size(60, 13);
            this.labelInvoiceType.TabIndex = 10;
            this.labelInvoiceType.Text = "Fatura Tipi:";
            // 
            // groupBoxItems
            // 
            this.groupBoxItems.Controls.Add(this.dataGridViewItems);
            this.groupBoxItems.Location = new System.Drawing.Point(8, 248);
            this.groupBoxItems.Name = "groupBoxItems";
            this.groupBoxItems.Size = new System.Drawing.Size(1200, 400);
            this.groupBoxItems.TabIndex = 2;
            this.groupBoxItems.TabStop = false;
            this.groupBoxItems.Text = "Fatura Kalemleri";
            // 
            // dataGridViewItems
            // 
            this.dataGridViewItems.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItems.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewItems.Name = "dataGridViewItems";
            this.dataGridViewItems.Size = new System.Drawing.Size(1188, 350);
            this.dataGridViewItems.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1102, 215);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabPageList
            // 
            this.tabPageList.Controls.Add(this.button1);
            this.tabPageList.Controls.Add(this.dataGridViewInvoices);
            this.tabPageList.Location = new System.Drawing.Point(4, 22);
            this.tabPageList.Name = "tabPageList";
            this.tabPageList.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageList.Size = new System.Drawing.Size(1256, 655);
            this.tabPageList.TabIndex = 1;
            this.tabPageList.Text = "Fatura Listesi";
            this.tabPageList.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1173, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Yenile";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridViewInvoices
            // 
            this.dataGridViewInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInvoices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewInvoices.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewInvoices.Name = "dataGridViewInvoices";
            this.dataGridViewInvoices.Size = new System.Drawing.Size(1250, 649);
            this.dataGridViewInvoices.TabIndex = 0;
            this.dataGridViewInvoices.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInvoices_CellDoubleClick);
            // 
            // invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panelMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "invoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fatura Yönetim Sistemi";
            this.Load += new System.EventHandler(this.invoice_Load);
            this.panelMain.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageInvoice.ResumeLayout(false);
            this.groupBoxSeller.ResumeLayout(false);
            this.groupBoxSeller.PerformLayout();
            this.groupBoxBuyer.ResumeLayout(false);
            this.groupBoxBuyer.PerformLayout();
            this.groupBoxInvoice.ResumeLayout(false);
            this.groupBoxInvoice.PerformLayout();
            this.groupBoxItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
            this.tabPageList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInvoices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        // --- Form Kontrolleri Field Tanımları ---
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageInvoice;
        private System.Windows.Forms.TabPage tabPageList;
        private System.Windows.Forms.DataGridView dataGridViewInvoices;
        private System.Windows.Forms.GroupBox groupBoxSeller;
        private System.Windows.Forms.GroupBox groupBoxBuyer;
        private System.Windows.Forms.GroupBox groupBoxInvoice;
        private System.Windows.Forms.GroupBox groupBoxItems;
        private System.Windows.Forms.DataGridView dataGridViewItems;
        private System.Windows.Forms.TextBox txtSellerName;
        private System.Windows.Forms.TextBox txtTaxID;
        private System.Windows.Forms.TextBox txtSellerPhone;
        private System.Windows.Forms.TextBox txtSellerAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.DateTimePicker dtInvoiceDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtBuyerName;
        private System.Windows.Forms.TextBox txtBuyerTaxID;
        private System.Windows.Forms.TextBox txtBuyerPhone;
        private System.Windows.Forms.TextBox txtBuyerAddress;
        private System.Windows.Forms.Label labelBuyerName;
        private System.Windows.Forms.Label labelBuyerTaxID;
        private System.Windows.Forms.Label labelBuyerPhone;
        private System.Windows.Forms.Label labelBuyerAddress;
        private System.Windows.Forms.TextBox txtBankName;
        private System.Windows.Forms.TextBox txtIBAN;
        private System.Windows.Forms.TextBox txtShippingCost;
        private System.Windows.Forms.TextBox txtTaxAmount;
        private System.Windows.Forms.Label labelBankName;
        private System.Windows.Forms.Label labelIBAN;
        private System.Windows.Forms.Label labelShippingCost;
        private System.Windows.Forms.Label labelTaxAmount;
        private System.Windows.Forms.ComboBox cbPaymentTerms;
        private System.Windows.Forms.Label labelPaymentTerms;
        private System.Windows.Forms.ComboBox cbInvoiceType;
        private System.Windows.Forms.Label labelInvoiceType;
        private System.Windows.Forms.Button button1;
    }
}
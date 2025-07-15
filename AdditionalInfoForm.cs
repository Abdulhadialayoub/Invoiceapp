using System;
using System.Windows.Forms;

namespace Fatureapp
{
    public partial class AdditionalInfoForm : Form
    {
        public string AdditionalInfo { get; private set; }
        public string BuyerBankInfo { get; private set; }
        public string InvoiceType { get; private set; }
        
        private TextBox txtAdditionalInfo;
        private TextBox txtBuyerBankInfo;
        private Button btnOK;
        private Button btnCancel;
        private Label lblTitle;
        private Label lblBankTitle;
        private Label lblInvoiceType;
        private ComboBox cbInvoiceType;
        
        public AdditionalInfoForm()
        {
            //InitializeComponent();
            SetupForm();
        }
        
        private void SetupForm()
        {
            // Form ayarları
            this.Text = "Ek Bilgiler ve Banka Bilgileri";
            this.Size = new System.Drawing.Size(500, 450);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            
            // Ek bilgiler başlığı
            lblTitle = new Label();
            lblTitle.Text = "Fatura alt kısmında gösterilecek ek bilgileri giriniz:";
            lblTitle.Location = new System.Drawing.Point(12, 12);
            lblTitle.Size = new System.Drawing.Size(460, 20);
            this.Controls.Add(lblTitle);
            
            // Ek bilgiler metin kutusu
            txtAdditionalInfo = new TextBox();
            txtAdditionalInfo.Multiline = true;
            txtAdditionalInfo.ScrollBars = ScrollBars.Vertical;
            txtAdditionalInfo.Location = new System.Drawing.Point(12, 40);
            txtAdditionalInfo.Size = new System.Drawing.Size(460, 120);
            txtAdditionalInfo.Font = new System.Drawing.Font("Arial", 10);
            // Örnek metin
            txtAdditionalInfo.Text = "PROVENANCE: TURKEY\r\nINCOTERM: CFR ALGERIA PORT\r\nORIGIN: TURKEY\r\nPAYMENT: 100% CAD AFTER SHIPMENT";
            this.Controls.Add(txtAdditionalInfo);
            
            // Banka bilgileri başlığı
            lblBankTitle = new Label();
            lblBankTitle.Text = "Alıcı Banka Bilgileri:";
            lblBankTitle.Location = new System.Drawing.Point(12, 175);
            lblBankTitle.Size = new System.Drawing.Size(460, 20);
            this.Controls.Add(lblBankTitle);
            
            // Banka bilgileri metin kutusu
            txtBuyerBankInfo = new TextBox();
            txtBuyerBankInfo.Multiline = true;
            txtBuyerBankInfo.ScrollBars = ScrollBars.Vertical;
            txtBuyerBankInfo.Location = new System.Drawing.Point(12, 200);
            txtBuyerBankInfo.Size = new System.Drawing.Size(460, 120);
            txtBuyerBankInfo.Font = new System.Drawing.Font("Arial", 10);
            // Örnek banka bilgileri
            txtBuyerBankInfo.Text = "Bank Name: ABC Bank\r\nAccount Number: 1234567890\r\nSwift Code: ABCDEF12\r\nIBAN: TR123456789012345678901234\r\nBranch: Main Branch";
            this.Controls.Add(txtBuyerBankInfo);
            
            // Tamam butonu
            btnOK = new Button();
            btnOK.Text = "Tamam";
            btnOK.Location = new System.Drawing.Point(316, 340);
            btnOK.Size = new System.Drawing.Size(75, 25);
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Click += BtnOK_Click;
            this.Controls.Add(btnOK);
            
            // İptal butonu
            btnCancel = new Button();
            btnCancel.Text = "İptal";
            btnCancel.Location = new System.Drawing.Point(397, 340);
            btnCancel.Size = new System.Drawing.Size(75, 25);
            btnCancel.DialogResult = DialogResult.Cancel;
            this.Controls.Add(btnCancel);
            
            // Fatura Tipi başlığı
            lblInvoiceType = new Label();
            lblInvoiceType.Text = "Fatura Tipi:";
            lblInvoiceType.Location = new System.Drawing.Point(12, 330);
            lblInvoiceType.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(lblInvoiceType);

            // Fatura Tipi ComboBox
            cbInvoiceType = new ComboBox();
            cbInvoiceType.Items.AddRange(new object[] { "COMMERCIAL", "PROFORMA" });
            cbInvoiceType.Location = new System.Drawing.Point(120, 330);
            cbInvoiceType.Size = new System.Drawing.Size(150, 21);
            cbInvoiceType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(cbInvoiceType);
            
            // Tamam butonu konumunu ayarla
            btnOK.Location = new System.Drawing.Point(316, 360);
            btnCancel.Location = new System.Drawing.Point(397, 360);

            // Form boyutunu ayarla
            this.Size = new System.Drawing.Size(500, 480);

            // Default butonlar
            this.AcceptButton = btnOK;
            this.CancelButton = btnCancel;
        }
        
        private void BtnOK_Click(object sender, EventArgs e)
        {
            AdditionalInfo = txtAdditionalInfo.Text;
            BuyerBankInfo = txtBuyerBankInfo.Text;
            InvoiceType = cbInvoiceType.SelectedItem?.ToString() ?? string.Empty;
            this.Close();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdditionalInfoForm));
            this.SuspendLayout();
            // 
            // AdditionalInfoForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdditionalInfoForm";
            this.ResumeLayout(false);

        }
    }
}

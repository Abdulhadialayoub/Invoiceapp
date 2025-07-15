using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Fatureapp;


namespace Fatureapp
{

    public partial class invoice : Form
    {
        private void ClearForm()
        {
            // Formları temizle
            txtInvoiceNo.Clear();
            txtSellerName.Clear();
            txtTaxID.Clear();
            txtSellerPhone.Clear();
            txtSellerAddress.Clear();
            txtBankName.Clear();
            txtIBAN.Clear();
            txtBuyerName.Clear();
            txtBuyerTaxID.Clear();
            txtBuyerPhone.Clear();
            txtBuyerAddress.Clear();
            txtShippingCost.Clear();
            txtTaxAmount.Clear();
            cbPaymentTerms.SelectedIndex = -1;
            dtInvoiceDate.Value = DateTime.Now;

            // DataGridView'i temizle
            dataGridViewItems.Rows.Clear();
        }
        public invoice()
        {

            InitializeComponent();

            // DataGridView sütunlarını ayarla
            dataGridViewItems.AutoGenerateColumns = false;
            dataGridViewItems.Columns.Clear();

            // No sütunu
            var noColumn = new DataGridViewTextBoxColumn
            {
                Name = "No",
                HeaderText = "No",
                Width = 50,
                ReadOnly = true
            };

            // Description (Açıklama) sütunu
            var descriptionColumn = new DataGridViewTextBoxColumn
            {
                Name = "Description",
                HeaderText = "Açıklama",
                Width = 300
            };

            // Quantity (Miktar) sütunu
            var quantityColumn = new DataGridViewTextBoxColumn
            {
                Name = "Quantity",
                HeaderText = "Miktar",
                Width = 100
            };

            // Unit (Birim) sütunu
            var unitColumn = new DataGridViewTextBoxColumn
            {
                Name = "Unit",
                HeaderText = "Birim",
                Width = 100
            };

            // Unit Price (Birim Fiyat) sütunu
            var unitPriceColumn = new DataGridViewTextBoxColumn
            {
                Name = "UnitPrice",
                HeaderText = "Birim Fiyat",
                Width = 150
            };

            // Total Price (Toplam Fiyat) sütunu
            var totalPriceColumn = new DataGridViewTextBoxColumn
            {
                Name = "TotalPrice",
                HeaderText = "Toplam Fiyat",
                Width = 150,
                ReadOnly = true
            };

            // Sütunları DataGridView'e ekle
            dataGridViewItems.Columns.AddRange(new DataGridViewColumn[]
            {
                noColumn,
                descriptionColumn,
                quantityColumn,
                unitColumn,
                unitPriceColumn,
                totalPriceColumn
            });

            // DataGridView olaylarını ekle
            dataGridViewItems.CellValueChanged += DataGridViewItems_CellValueChanged;
            dataGridViewItems.RowsAdded += DataGridViewItems_RowsAdded;
        }

        // Satır numaralarını güncelle
        private void DataGridViewItems_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < dataGridViewItems.Rows.Count; i++)
            {
                if (!dataGridViewItems.Rows[i].IsNewRow)
                {
                    dataGridViewItems.Rows[i].Cells["No"].Value = (i + 1).ToString();
                }
            }
        }

        // Toplam fiyatı hesapla
        private void DataGridViewItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !dataGridViewItems.Rows[e.RowIndex].IsNewRow)
            {
                var row = dataGridViewItems.Rows[e.RowIndex];

                if (e.ColumnIndex == dataGridViewItems.Columns["Quantity"].Index ||
                    e.ColumnIndex == dataGridViewItems.Columns["UnitPrice"].Index)
                {
                    decimal quantity = 0;
                    decimal unitPrice = 0;

                    decimal.TryParse(row.Cells["Quantity"].Value?.ToString(), out quantity);
                    decimal.TryParse(row.Cells["UnitPrice"].Value?.ToString(), out unitPrice);

                    row.Cells["TotalPrice"].Value = (quantity * unitPrice).ToString("N2");
                }
            }
        }

        // Event handlerlar eklendi
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtInvoiceNo.Text))
                {
                    MessageBox.Show("Fatura numarası boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dataGridViewItems.Rows.Count <= 1) // Sadece yeni satır varsa
                {
                    MessageBox.Show("En az bir fatura kalemi girmelisiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Fatura başlığını kaydet
                string invoiceQuery = @"INSERT INTO Invoices 
                                 (invoice_id, invoice_date, subtotal, shipping_cost, tax, total_amount, payment_terms)
                                 VALUES (@invoice_id, @invoice_date, @subtotal, @shipping_cost, @tax, @total_amount, @payment_terms)";

                int sellerID = SaveSeller();
                int buyerID = SaveBuyer();

                decimal subTotal = CalculateSubTotal();
                decimal shipping = 0;
                decimal.TryParse(txtShippingCost.Text, out shipping);
                decimal tax = 0;
                decimal.TryParse(txtTaxAmount.Text, out tax);
                decimal totalAmount = subTotal + shipping + tax;

                SqlParameter[] invoiceParams = {
                    new SqlParameter("@invoice_id", txtInvoiceNo.Text),
                    new SqlParameter("@invoice_date", dtInvoiceDate.Value),
                    new SqlParameter("@subtotal", subTotal),
                    new SqlParameter("@shipping_cost", shipping),
                    new SqlParameter("@tax", tax),
                    new SqlParameter("@total_amount", totalAmount),
                    new SqlParameter("@payment_terms", cbPaymentTerms.SelectedItem?.ToString() ?? "")
                };

                DatabaseHelper.ExecuteNonQuery(invoiceQuery, invoiceParams);

                // Invoice_Relations tablosuna ilişki ekle
                string relationQuery = @"INSERT INTO Invoice_Relations (invoice_id, seller_id, buyer_id) 
                                       VALUES (@invoice_id, @seller_id, @buyer_id)";
                SqlParameter[] relationParams = {
                    new SqlParameter("@invoice_id", txtInvoiceNo.Text),
                    new SqlParameter("@seller_id", sellerID),
                    new SqlParameter("@buyer_id", buyerID)
                };
                DatabaseHelper.ExecuteNonQuery(relationQuery, relationParams);

                // Fatura kalemlerini kaydet
                foreach (DataGridViewRow row in dataGridViewItems.Rows)
                {
                    if (!row.IsNewRow && row.Cells["Description"].Value != null)
                    {
                        string itemQuery = @"INSERT INTO Invoice_Items 
                                            (invoice_id, description, quantity, unit, unit_price, total_price) 
                                            VALUES (@invoice_id, @description, @quantity, @unit, @unit_price, @total_price)";

                        decimal quantity = 0;
                        decimal.TryParse(row.Cells["Quantity"].Value?.ToString(), out quantity);

                        decimal unitPrice = 0;
                        decimal.TryParse(row.Cells["UnitPrice"].Value?.ToString(), out unitPrice);

                        decimal totalPrice = 0;
                        decimal.TryParse(row.Cells["TotalPrice"].Value?.ToString(), out totalPrice);

                        SqlParameter[] itemParams = {
                            new SqlParameter("@invoice_id", txtInvoiceNo.Text),
                            new SqlParameter("@description", row.Cells["Description"].Value?.ToString()),
                            new SqlParameter("@quantity", quantity),
                            new SqlParameter("@unit", row.Cells["Unit"].Value?.ToString()),
                            new SqlParameter("@unit_price", unitPrice),
                            new SqlParameter("@total_price", totalPrice)
                        };

                        DatabaseHelper.ExecuteNonQuery(itemQuery, itemParams);
                    }
                }

                MessageBox.Show("Fatura başarıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Formu temizle
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            // Kalem Ekle butonu tıklandığında yapılacak işlemler
        }

        private void invoice_Load(object sender, EventArgs e)
        {
            try
            {
                // DataGridView ayarlarını yap
                dataGridViewInvoices.AutoGenerateColumns = false;
                dataGridViewInvoices.Columns.Clear();

                // Sütunları ekle
                dataGridViewInvoices.Columns.AddRange(new DataGridViewColumn[] {
                    new DataGridViewTextBoxColumn
                    {
                        Name = "InvoiceNo",
                        HeaderText = "Fatura No",
                        DataPropertyName = "InvoiceNo",
                        Width = 100
                    },
                    new DataGridViewTextBoxColumn
                    {
                        Name = "Tarih",
                        HeaderText = "Tarih",
                        DataPropertyName = "Tarih",
                        Width = 100
                    },
                    new DataGridViewTextBoxColumn
                    {
                        Name = "Seller",
                        HeaderText = "Satıcı",
                        DataPropertyName = "Seller",
                        Width = 200
                    },
                    new DataGridViewTextBoxColumn
                    {
                        Name = "Buyer",
                        HeaderText = "Alıcı",
                        DataPropertyName = "Buyer",
                        Width = 200
                    },
                    new DataGridViewTextBoxColumn
                    {
                        Name = "ToplamTutar",
                        HeaderText = "Toplam Tutar",
                        DataPropertyName = "ToplamTutar",
                        Width = 120,
                        DefaultCellStyle = new DataGridViewCellStyle
                        {
                            Format = "N2",
                            Alignment = DataGridViewContentAlignment.MiddleRight
                        }
                    },
                    
                });

                // Verileri getir
                string query = @"SELECT 
                    i.invoice_id AS InvoiceNo,
                    i.invoice_date AS Tarih,
                    s.company_name AS Seller,
                    b.company_name AS Buyer,
                    i.total_amount AS ToplamTutar,
                    i.payment_terms AS OdemeSekli
                FROM Invoices i
                JOIN Invoice_Relations ir ON i.invoice_id = ir.invoice_id
                JOIN Sellers s ON ir.seller_id = s.seller_id
                JOIN Buyers b ON ir.buyer_id = b.buyer_id
                ORDER BY i.invoice_date DESC";

                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                dataGridViewInvoices.DataSource = dt;

                // DataGridView görünüm ayarları
                dataGridViewInvoices.AllowUserToAddRows = false;
                dataGridViewInvoices.AllowUserToDeleteRows = false;
                dataGridViewInvoices.ReadOnly = true;
                dataGridViewInvoices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewInvoices.MultiSelect = false;
                dataGridViewInvoices.RowHeadersVisible = false;

                dataGridViewInvoices.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Faturalar yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int SaveSeller()
        {
            string query = @"IF NOT EXISTS (SELECT 1 FROM Sellers WHERE tax_id = @tax_id)
                            BEGIN
                                INSERT INTO Sellers (company_name, tax_id, phone_number, address, bank_name, iban)
                                VALUES (@company_name, @tax_id, @phone_number, @address, @bank_name, @iban);
                            END
                            SELECT seller_id FROM Sellers WHERE tax_id = @tax_id";
            SqlParameter[] parameters = {
                new SqlParameter("@company_name", txtSellerName.Text),
                new SqlParameter("@tax_id", txtTaxID.Text),
                new SqlParameter("@phone_number", txtSellerPhone.Text),
                new SqlParameter("@address", txtSellerAddress.Text),
                new SqlParameter("@bank_name", txtBankName.Text),
                new SqlParameter("@iban", txtIBAN.Text)
            };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            return Convert.ToInt32(dt.Rows[0]["seller_id"]);
        }

        private int SaveBuyer()
        {
            string query = @"IF NOT EXISTS (SELECT 1 FROM Buyers WHERE tax_id = @tax_id)
                            BEGIN
                                INSERT INTO Buyers (company_name, tax_id, address)
                                VALUES (@company_name, @tax_id, @address);
                            END
                            SELECT buyer_id FROM Buyers WHERE tax_id = @tax_id";
            SqlParameter[] parameters = {
                new SqlParameter("@company_name", txtBuyerName.Text),
                new SqlParameter("@tax_id", txtBuyerTaxID.Text),
                new SqlParameter("@address", txtBuyerAddress.Text)
            };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            return Convert.ToInt32(dt.Rows[0]["buyer_id"]);
        }

        private void SaveInvoiceItems(string invoiceID)
        {
            string query = "INSERT INTO Invoice_Items (invoice_id, description, quantity, unit, unit_price, total_price) VALUES (@invoice_id, @description, @quantity, @unit, @unit_price, @total_price)";
            foreach (DataGridViewRow row in dataGridViewItems.Rows)
            {
                if (!row.IsNewRow)
                {
                    SqlParameter[] parameters = {
                        new SqlParameter("@invoice_id", invoiceID),
                        new SqlParameter("@description", row.Cells["Description"].Value?.ToString() ?? ""),
                        new SqlParameter("@quantity", row.Cells["Quantity"].Value ?? 0),
                        new SqlParameter("@unit", row.Cells["Unit"].Value?.ToString() ?? ""),
                        new SqlParameter("@unit_price", row.Cells["UnitPrice"].Value ?? 0),
                        new SqlParameter("@total_price", row.Cells["TotalPrice"].Value ?? 0)
                    };
                    DatabaseHelper.ExecuteNonQuery(query, parameters);
                }
            }
        }

        private decimal CalculateSubTotal()
        {
            decimal subTotal = 0;
            foreach (DataGridViewRow row in dataGridViewItems.Rows)
            {
                if (!row.IsNewRow && row.Cells["TotalPrice"].Value != null)
                {
                    decimal price = 0;
                    decimal.TryParse(row.Cells["TotalPrice"].Value.ToString(), out price);
                    subTotal += price;
                }
            }
            return subTotal;
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Fatura başlık bilgileri için DataTable oluştur
                DataTable dtHeader = new DataTable();
                dtHeader.Columns.Add("InvoiceNo", typeof(string));
                dtHeader.Columns.Add("InvoiceDate", typeof(DateTime));
                dtHeader.Columns.Add("seller_name", typeof(string));
                dtHeader.Columns.Add("seller_tax_id", typeof(string));
                dtHeader.Columns.Add("seller_phone", typeof(string));
                dtHeader.Columns.Add("seller_address", typeof(string));
                dtHeader.Columns.Add("bank_name", typeof(string));
                dtHeader.Columns.Add("iban", typeof(string));
                dtHeader.Columns.Add("buyer_name", typeof(string));
                dtHeader.Columns.Add("buyer_tax_id", typeof(string));
                dtHeader.Columns.Add("buyer_address", typeof(string));
                dtHeader.Columns.Add("Subtotal", typeof(decimal));
                dtHeader.Columns.Add("ShippingCost", typeof(decimal));
                dtHeader.Columns.Add("Tax", typeof(decimal));
                dtHeader.Columns.Add("TotalAmount", typeof(decimal));
                dtHeader.Columns.Add("PaymentTerms", typeof(string));

                decimal subTotal = CalculateSubTotal();
                decimal shipping = 0;
                decimal.TryParse(txtShippingCost.Text, out shipping);
                decimal tax = 0;
                decimal.TryParse(txtTaxAmount.Text, out tax);
                decimal totalAmount = subTotal + shipping + tax;

                dtHeader.Rows.Add(
                    txtInvoiceNo.Text,
                    dtInvoiceDate.Value,
                    txtSellerName.Text,
                    txtTaxID.Text,
                    txtSellerPhone.Text,
                    txtSellerAddress.Text,
                    txtBankName.Text,
                    txtIBAN.Text,
                    txtBuyerName.Text,
                    txtBuyerTaxID.Text,
                    txtBuyerAddress.Text,
                    subTotal,
                    shipping,
                    tax,
                    totalAmount,
                    cbPaymentTerms.SelectedItem?.ToString() ?? ""
                );

                // 2. Fatura kalemleri için DataTable oluştur
                DataTable dtItems = new DataTable();
                dtItems.Columns.Add("No", typeof(string));
                dtItems.Columns.Add("Description", typeof(string));
                dtItems.Columns.Add("Quantity", typeof(string));
                dtItems.Columns.Add("Unit", typeof(string));
                dtItems.Columns.Add("UnitPrice", typeof(string));
                dtItems.Columns.Add("TotalAmount", typeof(string));

                foreach (DataGridViewRow row in dataGridViewItems.Rows)
                {
                    if (!row.IsNewRow && row.Cells["Description"].Value != null)
                    {
                        dtItems.Rows.Add(
                            (row.Index + 1).ToString(),
                            row.Cells["Description"].Value?.ToString(),
                            row.Cells["Quantity"].Value?.ToString(),
                            row.Cells["Unit"].Value?.ToString(),
                            row.Cells["UnitPrice"].Value?.ToString(),
                            row.Cells["TotalPrice"].Value?.ToString()
                        );
                    }
                }

                // 3. iText7 belgesini oluştur ve kaydet
                string additionalInfo = string.Empty;
                string buyerBankInfo = string.Empty;
                string invoiceType = string.Empty;

                using (var additionalForm = new Fatureapp.AdditionalInfoForm())
                {
                    if (additionalForm.ShowDialog() == DialogResult.OK)
                    {
                        additionalInfo = additionalForm.AdditionalInfo;
                        buyerBankInfo = additionalForm.BuyerBankInfo;
                        invoiceType = additionalForm.InvoiceType;
                    }
                }

                var document = new InvoiceDocument(dtHeader, dtItems, additionalInfo, buyerBankInfo, invoiceType);

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PDF Files|*.pdf";
                    sfd.FileName = $"Fatura_{txtInvoiceNo.Text}.pdf";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        document.GeneratePdf(sfd.FileName);
                        MessageBox.Show("PDF başarıyla oluşturuldu!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PDF oluşturulurken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewInvoices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string selectedInvoiceNo = dataGridViewInvoices.Rows[e.RowIndex].Cells["InvoiceNo"].Value.ToString();
                GenerateInvoicePDF(selectedInvoiceNo);
            }
        }

        private void GenerateInvoicePDF(string invoiceNo)
        {
            try
            {
                // Fatura başlık bilgilerini al
                string headerQuery = @"SELECT 
                    i.invoice_id as InvoiceNo, i.invoice_date as InvoiceDate, 
                    i.subtotal as Subtotal, i.shipping_cost as ShippingCost, 
                    i.tax as Tax, i.total_amount as TotalAmount, 
                    i.payment_terms as PaymentTerms,
                    s.company_name as seller_name, s.tax_id as seller_tax_id,
                    s.phone_number as seller_phone, s.address as seller_address,
                    s.bank_name, s.iban,
                    b.company_name as buyer_name, b.tax_id as buyer_tax_id,
                    b.address as buyer_address
                FROM Invoices i
                JOIN Invoice_Relations ir ON i.invoice_id = ir.invoice_id
                JOIN Sellers s ON ir.seller_id = s.seller_id
                JOIN Buyers b ON ir.buyer_id = b.buyer_id
                WHERE i.invoice_id = @invoice_id";

                SqlParameter[] headerParams = { new SqlParameter("@invoice_id", invoiceNo) };
                DataTable dtHeader = DatabaseHelper.ExecuteQuery(headerQuery, headerParams);

                if (dtHeader.Rows.Count == 0)
                {
                    MessageBox.Show("Fatura bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Fatura kalemlerini al
                string itemsQuery = @"SELECT
                    ROW_NUMBER() OVER (ORDER BY description) as No,
                    description as Description,
                    quantity as Quantity,
                    unit as Unit,
                    unit_price as UnitPrice,
                    total_price as TotalAmount
                FROM Invoice_Items
                WHERE invoice_id = @invoice_id";

                SqlParameter[] itemsParams = { new SqlParameter("@invoice_id", invoiceNo) };
                DataTable dtItems = DatabaseHelper.ExecuteQuery(itemsQuery, itemsParams);

                // iText7 belgesini oluştur ve kaydet
                string additionalInfo = string.Empty;
                string buyerBankInfo = string.Empty;
                string invoiceType = string.Empty;

                using (var additionalForm = new AdditionalInfoForm())
                {
                    if (additionalForm.ShowDialog() == DialogResult.OK)
                    {
                        additionalInfo = additionalForm.AdditionalInfo;
                        buyerBankInfo = additionalForm.BuyerBankInfo;
                        invoiceType = additionalForm.InvoiceType;
                    }
                }

                var document = new InvoiceDocument(dtHeader, dtItems, additionalInfo, buyerBankInfo, invoiceType);

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PDF Dosyaları|*.pdf";
                    sfd.FileName = $"Fatura_{invoiceNo}.pdf";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        document.GeneratePdf(sfd.FileName);
                        MessageBox.Show("PDF Açılıyor...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // PDF'i otomatik aç
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PDF oluşturulurken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            invoice_Load(sender, e);
        }
    }
}
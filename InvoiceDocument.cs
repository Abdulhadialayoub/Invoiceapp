using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Fatureapp
{
    public class InvoiceDocument
    {
        public DataTable HeaderData { get; set; }
        public DataTable ItemsData { get; set; }
        public string AdditionalInfo { get; set; }
        public string BuyerBankInfo { get; set; }
        public string InvoiceType { get; set; }

        public InvoiceDocument(DataTable headerData, DataTable itemsData, string additionalInfo, string buyerBankInfo, string invoiceType)
        {
            HeaderData = headerData ?? throw new ArgumentNullException(nameof(headerData));
            ItemsData = itemsData ?? throw new ArgumentNullException(nameof(itemsData));
            AdditionalInfo = additionalInfo;
            BuyerBankInfo = buyerBankInfo;
            InvoiceType = invoiceType;
        }

        public void GeneratePdf(string filePath)
        {
            try
            {
                // 1. Validate file path
                if (string.IsNullOrWhiteSpace(filePath))
                    throw new ArgumentException("Invalid file path");

                // 2. Ensure directory exists
                var directory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                // 3. Generate PDF with proper error handling
                using (var writer = new PdfWriter(filePath))
                using (var pdf = new PdfDocument(writer))
                using (var document = new Document(pdf))
                {
                    // Set document properties
                    document.SetMargins(50, 50, 50, 50);

                    // Load fonts safely
                    var normalFont = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA);
                    var boldFont = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD);

                    // Add content sections
                    ComposeHeader(document, boldFont);
                    document.Add(new Paragraph("\n"));
                    ComposeSellerBuyerInfo(document, boldFont);
                    document.Add(new Paragraph("\n"));
                    //ComposeInvoiceDetails(document, boldFont);
                    document.Add(new Paragraph("\n"));
                    ComposeItemsTable(document, boldFont);
                    document.Add(new Paragraph("\n"));
                    ComposeTotals(document, boldFont);
                    ComposeDollarTotals(document);
                    ComposeSignatureAndSeal(document);
                    ComposeFooter(document, pdf, normalFont);
                }

                MessageBox.Show("PDF successfully created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create PDF: {ex.Message}\n\nTechnical details:\n{ex}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void ComposeHeader(Document document, PdfFont boldFont)
        {
            if (HeaderData.Rows.Count == 0) return;
            var header = HeaderData.Rows[0];

            // Create a table with 2 columns
            Table headerTable = new Table(new float[] { 1, 1 }) // Equal width columns
                .UseAllAvailableWidth()
                .SetMarginBottom(20);

            // Left cell - INVOICE title
            var invoiceTitleParagraph = new Paragraph("INVOICE")
                .SetFont(boldFont)
                .SetFontSize(24)
                .SetFontColor(ColorConstants.BLUE);

            if (!string.IsNullOrEmpty(InvoiceType))
            {
                invoiceTitleParagraph.Add(new Text($" {InvoiceType}")
                    .SetFontSize(16)
                    .SetFontColor(ColorConstants.DARK_GRAY));
            }

            headerTable.AddCell(new Cell()
                .Add(invoiceTitleParagraph)
                .SetTextAlignment(TextAlignment.LEFT)
                .SetBorder(Border.NO_BORDER));

            // Right cell - Date and Invoice No together
            string dateString = (header["InvoiceDate"] is DBNull) ?
                "N/A" :
                ((DateTime)header["InvoiceDate"]).ToString("dd/MM/yyyy");

            var rightCellContent = new Paragraph()
                .Add(new Text(dateString + "\n")
                    .SetFontSize(12)
                    .SetFontColor(ColorConstants.DARK_GRAY))
                .Add(new Text($"Invoice No: {header["InvoiceNo"]?.ToString() ?? "N/A"}")
                    .SetFontSize(12)
                    .SetFontColor(ColorConstants.DARK_GRAY))
                .SetTextAlignment(TextAlignment.RIGHT);

            headerTable.AddCell(new Cell()
                .Add(rightCellContent)
                .SetBorder(Border.NO_BORDER));

            document.Add(headerTable);
        }

        private void ComposeSellerBuyerInfo(Document document, PdfFont boldFont)
        {
            if (HeaderData.Rows.Count == 0) return;

            var header = HeaderData.Rows[0];
            var table = new Table(new float[] { 1, 0.1f, 1 }).UseAllAvailableWidth();

            // Seller Info
            var sellerCell = new Cell()
                .Add(new Paragraph("SELLER INFORMATION").SetFont(boldFont).SetFontSize(14))
                .Add(new Paragraph($"Name: {header["seller_name"]?.ToString() ?? "N/A"}"))
                .Add(new Paragraph($"Tax ID: {header["seller_tax_id"]?.ToString() ?? "N/A"}"))
                .Add(new Paragraph($"Phone: {header["seller_phone"]?.ToString() ?? "N/A"}"))
                .Add(new Paragraph($"Address: {header["seller_address"]?.ToString() ?? "N/A"}"))
                .Add(new Paragraph($"Bank: {header["bank_name"]?.ToString() ?? "N/A"}"))
                .Add(new Paragraph($"IBAN: {header["iban"]?.ToString() ?? "N/A"}"))
                .SetPadding(10)
                .SetBorder(new iText.Layout.Borders.SolidBorder(1));

            // Buyer Info
            var buyerCell = new Cell()
                .Add(new Paragraph("BUYER INFORMATION").SetFont(boldFont).SetFontSize(14))
                .Add(new Paragraph($"Name: {header["buyer_name"]?.ToString() ?? "N/A"}"))
                .Add(new Paragraph($"Tax ID: {header["buyer_tax_id"]?.ToString() ?? "N/A"}"))
                .Add(new Paragraph($"Address: {header["buyer_address"]?.ToString() ?? "N/A"}"))
                .SetPadding(10)
                .SetBorder(new iText.Layout.Borders.SolidBorder(1));

            if (!string.IsNullOrEmpty(BuyerBankInfo))
            {
                buyerCell.Add(new Paragraph($"Bank Info:\n{BuyerBankInfo}"));
            }

            table.AddCell(sellerCell);
            table.AddCell(new Cell().SetBorder(iText.Layout.Borders.Border.NO_BORDER)); // Spacer
            table.AddCell(buyerCell);

            document.Add(table);
        }
        private void ComposeSignatureAndSeal(Document document)
        {
            try
            {
                // Create signature container (right-aligned)
                Div signatureDiv = new Div()
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetMarginTop(30)
                    .SetPadding(10);

                // Add signature title
                signatureDiv.Add(new Paragraph("[Signature-Seal of the Offering Company]")
                    .SetFontSize(10)
                    .SetMarginBottom(10)); // Increased bottom margin

                // Let user select signature image
                string imagePath = SelectSignatureImage();

                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    try
                    {
                        // Load and display signature image
                        ImageData imageData = ImageDataFactory.Create(imagePath);
                        Image signatureImage = new Image(imageData)
                            .SetAutoScale(true)
                            .SetWidth(550)  // Optimal width for signatures
                            .SetMaxHeight(400) // Constrain height
                            .SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.RIGHT);

                        // Add image inside a cell for better positioning
                        Table signatureTable = new Table(1)
                            .SetWidth(UnitValue.CreatePercentValue(40))
                            .SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.RIGHT);

                        signatureTable.AddCell(new Cell()
                            .Add(signatureImage)
                            .SetBorder(Border.NO_BORDER)
                            .SetPadding(2));

                        signatureDiv.Add(signatureTable);
                    }
                    catch (Exception imgEx)
                    {
                        signatureDiv.Add(new Paragraph("[Invalid Signature Image]")
                            .SetFontColor(ColorConstants.RED));
                    }
                }
             

                document.Add(signatureDiv);
            }
            catch (Exception ex)
            {
                document.Add(new Paragraph("[Signature Section Error]")
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetFontColor(ColorConstants.RED));
            }
        }

        private string SelectSignatureImage()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select Signature Image";
                openFileDialog.Filter = "Signature Images|*.png;*.jpg;*.jpeg|All Files|*.*";
                openFileDialog.InitialDirectory =
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Return path if valid image
                    try
                    {
                        using (var img = System.Drawing.Image.FromFile(openFileDialog.FileName))
                        {
                            return openFileDialog.FileName;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Selected file is not a valid image", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }
            }
            return null;
        }
        private void ComposeDollarTotals(Document document)
        {
            if (HeaderData.Rows.Count == 0) return;

            var header = HeaderData.Rows[0];

            // Get values from DataTable with null checks
            decimal subtotal = GetDecimalValue(header, "Subtotal");
            decimal shipping = GetDecimalValue(header, "ShippingCost");
            decimal assemblyFee = GetDecimalValue(header, "AssemblyFee"); // 0 if column doesn't exist
            decimal tax = GetDecimalValue(header, "Tax");
            decimal total = GetDecimalValue(header, "TotalAmount");

            // Create and populate table
            Table dollarTable = new Table(new float[] { 2, 1 })
                .UseAllAvailableWidth()
                .SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.RIGHT)
                .SetWidth(UnitValue.CreatePercentValue(40));

            // Add rows with actual values
            AddDollarRow(dollarTable, "Subtotal in dollars", subtotal);
            AddDollarRow(dollarTable, "Shipping Cost", shipping);
            AddDollarRow(dollarTable, "Assembly Fee", assemblyFee);
            AddDollarRow(dollarTable, "KDV", tax);

            // Add total row
            AddDollarRow(dollarTable, "Total in dollars", total);

            document.Add(dollarTable);
        }

        // Helper method to safely get decimal values
        private decimal GetDecimalValue(DataRow row, string columnName)
        {
            if (!row.Table.Columns.Contains(columnName))
                return 0m;

            object value = row[columnName];
            if (value == null || value == DBNull.Value)
                return 0m;

            decimal result;
            return decimal.TryParse(value.ToString(), out result) ? result : 0m;
        }

        private void AddDollarRow(Table table, string label, decimal amount)
        {
            // Label cell
            table.AddCell(new Cell()
                .Add(new Paragraph(label))
                .SetBorder(Border.NO_BORDER)
                .SetPaddingTop(3)
                .SetPaddingBottom(3));

            // Value cell
            table.AddCell(new Cell()
                .Add(new Paragraph(FormatDollar(amount)))
                .SetTextAlignment(TextAlignment.RIGHT)
                .SetBorder(Border.NO_BORDER)
                .SetPaddingTop(3)
                .SetPaddingBottom(3));
        }

        // Improved formatting method
        private string FormatDollar(decimal amount)
        {
            var formattedAmount = amount.ToString("N2", System.Globalization.CultureInfo.InvariantCulture);
            formattedAmount = formattedAmount.Replace(",", "X"); // Temporary placeholder
            formattedAmount = formattedAmount.Replace(".", ",");
            formattedAmount = formattedAmount.Replace("X", ".");
            return $"USD {formattedAmount}";
        }
        //private void ComposeInvoiceDetails(Document document, PdfFont boldFont)
        //{
        //    if (HeaderData.Rows.Count == 0) return;

        //    var header = HeaderData.Rows[0];
        //    string paymentTerms = "100% CAD AFTER SHIPMENT"; // Default value

        //    // Only try to get from DataTable if column exists
        //    if (HeaderData.Columns.Contains("payment_terms") &&
        //        !string.IsNullOrEmpty(header["payment_terms"]?.ToString()))
        //    {
        //        paymentTerms = header["payment_terms"].ToString();
        //    }

        //    var detailsTable = new Table(1).UseAllAvailableWidth();
        //    var detailsCell = new Cell()
        //        .Add(new Paragraph("INVOICE DETAILS").SetFont(boldFont).SetFontSize(14))
        //        .Add(new Paragraph($"Payment Terms: {paymentTerms}"))
        //        .SetPadding(10)
        //        .SetBorder(new iText.Layout.Borders.SolidBorder(1));

        //    document.Add(detailsTable.AddCell(detailsCell));
        //}

        private void ComposeItemsTable(Document document, PdfFont boldFont)
        {
            if (ItemsData.Rows.Count == 0) return;

            var table = new Table(new float[] { 0.5f, 3, 1, 1, 1, 1 }).UseAllAvailableWidth();

            // Table Header
            table.AddHeaderCell(CreateHeaderCell("No", boldFont));
            table.AddHeaderCell(CreateHeaderCell("Description", boldFont));
            table.AddHeaderCell(CreateHeaderCell("Qty", boldFont, TextAlignment.RIGHT));
            table.AddHeaderCell(CreateHeaderCell("Unit", boldFont, TextAlignment.RIGHT));
            table.AddHeaderCell(CreateHeaderCell("Unit Price", boldFont, TextAlignment.RIGHT));
            table.AddHeaderCell(CreateHeaderCell("Total", boldFont, TextAlignment.RIGHT));

            // Table Content
            foreach (DataRow row in ItemsData.Rows)
            {
                table.AddCell(CreateCell(row["No"]?.ToString()));
                table.AddCell(CreateCell(row["Description"]?.ToString()));
                table.AddCell(CreateCell(row["Quantity"]?.ToString(), TextAlignment.RIGHT));
                table.AddCell(CreateCell(row["Unit"]?.ToString(), TextAlignment.RIGHT));
                table.AddCell(CreateCell(row["UnitPrice"]?.ToString(), TextAlignment.RIGHT));
                table.AddCell(CreateCell(row["TotalAmount"]?.ToString(), TextAlignment.RIGHT));
            }

            document.Add(table);
        }

        private Cell CreateHeaderCell(string text, PdfFont font, TextAlignment alignment = TextAlignment.LEFT)
        {
            return new Cell()
                .Add(new Paragraph(text).SetFont(font).SetFontSize(10))
                .SetTextAlignment(alignment);
        }

        private Cell CreateCell(string text, TextAlignment alignment = TextAlignment.LEFT)
        {
            return new Cell()
                .Add(new Paragraph(text ?? string.Empty))
                .SetTextAlignment(alignment)
                .SetPaddingTop(5) // Replace SetPaddingVertical with SetPaddingTop and SetPaddingBottom
                .SetPaddingBottom(5);
        }

        private void ComposeFooter(Document document, PdfDocument pdf, PdfFont font)
        {
            var pageSize = pdf.GetDefaultPageSize();
            var pageCount = pdf.GetNumberOfPages();

            for (int i = 1; i <= pageCount; i++)
            {
                document.ShowTextAligned(
                    new Paragraph()
                        .Add("Page ")
                        .Add($"{i}")
                        .Add(" of ")
                        .Add($"{pageCount}")
                        .SetFont(font)
                        .SetFontSize(10),
                    pageSize.GetWidth() / 2,
                    20,
                    i,
                    TextAlignment.CENTER,
                    VerticalAlignment.BOTTOM,
                    0
                );

                if (!string.IsNullOrEmpty(AdditionalInfo))
                {
                    document.ShowTextAligned(
                        new Paragraph(AdditionalInfo)
                            .SetFont(font)
                            .SetFontSize(9)
                            .SetFontColor(ColorConstants.DARK_GRAY),
                        pageSize.GetLeft() + 50, // Left margin
                        20, // Bottom margin
                        i,
                        TextAlignment.LEFT,
                        VerticalAlignment.BOTTOM,
                        0
                    );
                }
            }
        }
        private void ComposeTotals(Document document, PdfFont boldFont)
        {
            if (ItemsData.Rows.Count == 0) return;

            decimal totalAmount = 0;

            foreach (DataRow row in ItemsData.Rows)
            {
                if (decimal.TryParse(row["TotalAmount"]?.ToString(), out decimal rowTotal))
                {
                    totalAmount += rowTotal;
                }
            }

            var totalParagraph = new Paragraph($"Total: {totalAmount:C}")
                .SetFont(boldFont)
                .SetFontSize(12)
                .SetTextAlignment(TextAlignment.RIGHT);

            document.Add(totalParagraph);
        }
    }
}
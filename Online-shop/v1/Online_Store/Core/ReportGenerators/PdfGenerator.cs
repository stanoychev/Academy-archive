using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Online_Store.Data;

namespace Online_Store.ReportGenerators
{
    public class PdfGenerators
    {
        private const int TableColumnsNumber = 6;


        public void GeneratePdf(IStoreContext context, string pathToSave, string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.CreateNew);
            Document doc = new Document(PageSize.A4);
            PdfWriter pdfWriter = PdfWriter.GetInstance(doc, fs);

            doc.Open();

            var products = context.Products.ToList();
            foreach (var product in products)
            {
                PdfPTable table = CreateTable(TableColumnsNumber);

                var productId = CreateColumn(product.Id.ToString(), 1);
                table.AddCell(productId);

                var productName = CreateColumn(product.ProductName, 1);
                table.AddCell(productName);

                var price = CreateColumn(product.Price.ToString(), 1);
                table.AddCell(price);

                var date = CreateColumn(product.Date.ToString(), 1);
                table.AddCell(date);

                var sellerId = CreateColumn(product.SellerId.ToString(), 1);
                table.AddCell(sellerId);

                var paymentMethod = CreateColumn(product.PaymentMethod.ToString(), 1);
                table.AddCell(paymentMethod);

                doc.Add(table);
            }
            doc.Close();
        }
        private PdfPTable CreateTable(int tableColumnsNumber)
        {
            PdfPTable table = new PdfPTable(TableColumnsNumber);
            table.SpacingBefore = 25f;
            table.TotalWidth = 550f;
            table.LockedWidth = true;
            float[] widths = new float[] { 140f, 90, 80f, 70f, 90f, 80f };
            table.SetWidths(widths);

            return table;
        }

        private PdfPCell CreateColumn(string columnName, int alignment)
        {
            PdfPCell column = new PdfPCell(new Phrase(columnName));
            column.HorizontalAlignment = alignment;

            return column;
        }
    }
}

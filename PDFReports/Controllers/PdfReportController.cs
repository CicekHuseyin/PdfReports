using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace PDFReports.Controllers
{
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StaticPdfReport()
        {
            //Pdf Rapor oluşturuldu. Ve indirildi.
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PDFReports/" + "file1.pdf");
            var stream = new FileStream(path, FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();
            Paragraph paragraph = new Paragraph("Raporumuz Hazırlandı.");
            document.Add(paragraph);
            document.Close();
            return File("/pdfreports/file1.pdf", "application/pdf", "file1.pdf");
        }
        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PDFReports/" + "file2.pdf");
            var stream = new FileStream(path, FileMode.Create);
            var document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.OpenDocument();
            //3 sütün sayısı
            PdfPTable pdfPTable = new PdfPTable(3);
            pdfPTable.AddCell("Müşteri Adı");
            pdfPTable.AddCell("Müşteri Soyadı");
            pdfPTable.AddCell("Müşteri Şehri");

            pdfPTable.AddCell("Hüseyin");
            pdfPTable.AddCell("Çiçek");
            pdfPTable.AddCell("Van");

            pdfPTable.AddCell("Hasa");
            pdfPTable.AddCell("Çiçek");
            pdfPTable.AddCell("İstanbul");

            document.Add(pdfPTable);
            document.Close();
            return File("/pdfreports/file2.pdf", "application/pdf", "file2.pdf");

        }
    }
}

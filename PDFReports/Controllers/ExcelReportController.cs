using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;

namespace PDFReports.Controllers
{
    public class ExcelReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CustomerExcelReport()
        {
            var workBook = new XLWorkbook();
            var workSheet = workBook.Worksheets.Add("Müşteri Listesi");
            workSheet.Cell(1, 1).Value = "Müşteri ID";
            workSheet.Cell(1, 2).Value = "Müşteri Adı";
            workSheet.Cell(1, 3).Value = "Müşteri Soyadı";
            workSheet.Cell(1, 4).Value = "Müşteri Şehri";

            workSheet.Cell(2, 1).Value = "1";
            workSheet.Cell(2, 2).Value = "Hüseyin";
            workSheet.Cell(2, 3).Value = "Çiçek";
            workSheet.Cell(2, 4).Value = "Van";

            workSheet.Cell(3, 1).Value = "2";
            workSheet.Cell(3, 2).Value = "Hasan";
            workSheet.Cell(3, 3).Value = "Çiçek";
            workSheet.Cell(3, 4).Value = "Bursa";

            var stream = new MemoryStream();
            workBook.SaveAs(stream);
            var content = stream.ToArray();
            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetnl.sheet", "customerlist.xlsx");
        }
    }
}

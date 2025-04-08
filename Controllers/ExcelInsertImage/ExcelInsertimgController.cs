using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Excel;

namespace Aceoffix7_NetCore.Controllers.ExcelInsertImage
{
    public class ExcelInsertImageController : Controller
    {
        public IActionResult Excel()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);

            WorkbookWriter worbBook = new WorkbookWriter();
            SheetWriter Sheetl = worbBook.OpenSheet("Sheet1");
            ExcelCellWriter cell1 = Sheetl.OpenCell("A1");
            cell1.Value = "[image]/ExcelInsertImage/doc/logo.png[/image]";
            aceCtrl.SetWriter(worbBook);

            aceCtrl.WebOpen("doc/test.xlsx", OpenModeType.xlsNormalEdit, "Tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }

    }
}
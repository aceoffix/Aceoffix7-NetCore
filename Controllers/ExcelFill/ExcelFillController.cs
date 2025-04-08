using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Excel;

namespace Aceoffix7_NetCore.Controllers.ExcelFill
{
    public class ExcelFillController : Controller
    {

        public IActionResult Excel()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);

            WorkbookWriter workBook = new WorkbookWriter();
            SheetWriter sheet = workBook.OpenSheet("Sheet1");
            ExcelCellWriter cellB4 = sheet.OpenCell("B4");
            cellB4.Value = "Jan";
            ExcelCellWriter cellD2 = sheet.OpenCell("D2");
            cellD2.Value = "Sales Report (2015)";
            ExcelCellWriter cellF14 = sheet.OpenCell("F14");
            cellF14.Value = "100%";
            aceCtrl.SetWriter(workBook);
            aceCtrl.WebOpen("doc/test.xlsx", OpenModeType.xlsNormalEdit, "Luna");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }


    }
}
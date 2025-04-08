using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Excel;

namespace Aceoffix7_NetCore.Controllers.ExcelFill2
{
    public class ExcelFill2Controller : Controller
    {
        public IActionResult Excel()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);

            WorkbookWriter workBook = new WorkbookWriter();
            SheetWriter sheet = workBook.OpenSheet("Sheet1");
            ExcelCellWriter cellB4 = sheet.OpenCell("B4");
            cellB4.Value = "Jan";
            cellB4.ForeColor = Color.Red;

            ExcelCellWriter cellC4 = sheet.OpenCell("C4");
            cellC4.Value = "300";
            cellC4.ForeColor = Color.Blue;

            ExcelCellWriter cellD4 = sheet.OpenCell("D4");
            cellD4.Value = "270";
            cellD4.ForeColor = Color.Orange;

            ExcelCellWriter cellE4 = sheet.OpenCell("E4");
            cellE4.Value = "270";
            cellE4.ForeColor = Color.Green;

            ExcelCellWriter cellF4 = sheet.OpenCell("F4");
            cellF4.Value = string.Format("{0:P}", 270.0 / 300);
            cellF4.ForeColor = Color.Gray;

            aceCtrl.SetWriter(workBook);
            aceCtrl.WebOpen("doc/test.xlsx", OpenModeType.xlsNormalEdit, "Luna");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }

    }
}
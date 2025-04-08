using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Excel;

namespace Aceoffix7_NetCore.Controllers.ExcelAdjustRC
{
    public class ExcelAdjustRCController : Controller
    {
        public IActionResult Excel()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);

            WorkbookWriter wb = new WorkbookWriter();
            SheetWriter sheet1 = wb.OpenSheet("Sheet1");
            // Set whether to allow users to manually adjust rows and columns when the worksheet is read-only.
            sheet1.AllowAdjustRC = true;

            aceCtrl.SetWriter(wb);

            aceCtrl.WebOpen("doc/test.xlsx", OpenModeType.xlsReadOnly, "tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }
    }
}
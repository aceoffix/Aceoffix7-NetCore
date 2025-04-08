using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Excel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Aceoffix7_NetCore.Controllers.ExcelDisableRight
{
    public class ExcelDisableRightController : Controller
    {

        public IActionResult Excel()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);

            WorkbookWriter workBook = new WorkbookWriter();
            // Disable the right -click function of the mouse on the current worksheet
            workBook.DisableSheetRightClick = true;
            // Disable the double - click function of the mouse on the current worksheet
            // workBook.DisableSheetDoubleClick = true; 
            aceCtrl.SetWriter(workBook);

            aceCtrl.WebOpen("doc/test.xlsx", OpenModeType.xlsNormalEdit, "tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }

    }
}
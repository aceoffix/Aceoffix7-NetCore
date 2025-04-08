using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Excel;

namespace Aceoffix7_NetCore.Controllers.DefinedNameCell
{
    public class DefinedNameCellController : Controller
    {
        public IActionResult Excel()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);

            WorkbookWriter workBook = new WorkbookWriter();
            SheetWriter sheet = workBook.OpenSheet("Sheet1");
            sheet.OpenCellByDefinedName("testA").Value = "Sales Report (2015)";
            sheet.OpenCellByDefinedName("testB").Value = "100";
            aceCtrl.SetWriter(workBook);

            aceCtrl.WebOpen("doc/test.xlsx", OpenModeType.xlsSubmitForm, "tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }

    }
}
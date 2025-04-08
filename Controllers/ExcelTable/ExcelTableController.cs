using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Excel;

namespace Aceoffix7_NetCore.Controllers.ExcelTable
{
    public class ExcelTableController : Controller
    {
        public IActionResult Excel()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);

            // Define a Workbook object
            WorkbookWriter workBook = new WorkbookWriter();
            // Define a Sheet object. "Sheet1" is the name of the opened Excel worksheet.
            SheetWriter sheet = workBook.OpenSheet("Sheet1");
            // Define a Table object
            ExcelTableWriter table = sheet.OpenTable("B4:F13");
            for (int i = 0; i < 50; i++)
            {
                table.DataFields[0].Value = "Product " + i.ToString();
                table.DataFields[1].Value = "100";
                table.DataFields[2].Value = (100 + i).ToString();
                table.NextRow();
            }
            table.Close();
            aceCtrl.SetWriter(workBook);
            // Note: Don't forget this line of code. If this line is missing, the value assignment won't succeed.
            aceCtrl.WebOpen("doc/test.xlsx", OpenModeType.xlsNormalEdit, "Operator's Name");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }
    }
}
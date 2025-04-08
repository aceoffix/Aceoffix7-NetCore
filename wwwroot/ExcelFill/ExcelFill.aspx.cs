using Aceoffix;
using Aceoffix.Excel;
using System;


namespace Aceoffix7_Net.ExcelFill
{
    public partial class ExcelFill : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            
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
        }
    }
}
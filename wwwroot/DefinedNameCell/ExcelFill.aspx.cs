using Aceoffix;
using Aceoffix.Excel;
using System;

namespace Aceoffix7_Net.DefineNameCell
{
    public partial class ExcelFill : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {

            WorkbookWriter workBook = new WorkbookWriter();
            SheetWriter sheet = workBook.OpenSheet("Sheet1");
            sheet.OpenCellByDefinedName("testA").Value = "Sales Report (2015)";
            sheet.OpenCellByDefinedName("testB").Value = "100";

            aceCtrl.SetWriter(workBook);
            aceCtrl.WebOpen("doc/test.xlsx", OpenModeType.xlsNormalEdit, "Luna");
        }
    }
}
using Aceoffix;
using Aceoffix.Excel;
using System;
namespace Aceoffix7_Net.ExcelAdjustRC
{
    public partial class Excel : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)

        {
            WorkbookWriter wb = new WorkbookWriter();
            SheetWriter sheet1 = wb.OpenSheet("Sheet1");

            sheet1.AllowAdjustRC = true;// Set whether to allow users to manually adjust rows and columns when the worksheet is read-only.

            aceCtrl.SetWriter(wb);
            aceCtrl.WebOpen("doc/test.xlsx", OpenModeType.xlsReadOnly, "Tom");
        }
    }
}
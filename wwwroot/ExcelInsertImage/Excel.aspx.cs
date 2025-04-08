using Aceoffix;
using Aceoffix.Excel;
using System;


namespace Aceoffix7_Net.ExcelInsertImage
{
    public partial class Excel : System.Web.UI.Page
    {

        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            WorkbookWriter worbBook = new WorkbookWriter();
            SheetWriter Sheetl = worbBook.OpenSheet("Sheet1");
            ExcelCellWriter cell1 = Sheetl.OpenCell("A1");
            cell1.Value = "[image]/ExcelInsertImage/doc/logo.png[/image]";
            aceCtrl.SetWriter(worbBook);

            aceCtrl.WebOpen("doc/test.xlsx",OpenModeType.xlsNormalEdit, "Tom");
        }
    }
}
using Aceoffix;
using Aceoffix.Excel;
using System;
using System.Drawing;


namespace Aceoffix7_Net.MergeExcelCell
{
    public partial class Default : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            WorkbookWriter wb = new WorkbookWriter();
            SheetWriter sheet = wb.OpenSheet("Sheet1");
            sheet.OpenTable("B2:F2").Merge();

            ExcelCellWriter cellB2 = sheet.OpenCell("B2");
            cellB2.Value = "Products for Sale";
            cellB2.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            cellB2.ForeColor = Color.Red;
            cellB2.Font.Size = 16;

            sheet.OpenTable("B4:B6").Merge();
            ExcelCellWriter cellB4 = sheet.OpenCell("B4");
            cellB4.Value = "Product A:";
            cellB4.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            cellB4.VerticalAlignment = XlVAlign.xlVAlignCenter;
            cellB4.ForeColor = Color.Red;

            sheet.OpenTable("B7:B9").Merge();
            ExcelCellWriter cellB7 = sheet.OpenCell("B7");
            cellB7.Value = "Product B:";
            cellB7.HorizontalAlignment =XlHAlign.xlHAlignCenter;
            cellB7.VerticalAlignment = XlVAlign.xlVAlignCenter;
            cellB7.ForeColor = Color.Red;

            aceCtrl.SetWriter(wb);
            aceCtrl.WebOpen("doc/test.xlsx", OpenModeType.xlsNormalEdit, "John Scott");

        }
    }
}
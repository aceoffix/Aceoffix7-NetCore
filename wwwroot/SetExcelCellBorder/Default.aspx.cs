
using Aceoffix;
using Aceoffix.Excel;
using System;
using System.Drawing;


namespace Aceoffix7_Net.SetExcelCellBorder
{
    public partial class Default : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            WorkbookWriter wb = new WorkbookWriter();
            SheetWriter sheet = wb.OpenSheet("Sheet1");
            // Set the background
            ExcelTableWriter backGroundTable = sheet.OpenTable("A1:P200");
            // Set the table border style
            backGroundTable.Border.LineColor = Color.White;

            // Set the cell border style
            ExcelBorder C4Border = sheet.OpenTable("C4:C4").Border;
            C4Border.Weight = XlBorderWeight.xlThick;
            C4Border.LineColor = Color.Yellow;
            C4Border.BorderType = XlBorderType.xlAllEdges;

            // Set the cell border style
            ExcelBorder B6Border = sheet.OpenTable("B6:B6").Border;
            B6Border.Weight = XlBorderWeight.xlHairline;
            B6Border.LineColor = Color.Purple;
            B6Border.LineStyle = XlBorderLineStyle.xlSlantDashDot;
            B6Border.BorderType = XlBorderType.xlAllEdges;

            // Set the table border style
            ExcelTableWriter titleTable = sheet.OpenTable("B4:F5");
            titleTable.Border.Weight = XlBorderWeight.xlThick;
            titleTable.Border.LineColor = Color.FromArgb(0, 128, 128);
            titleTable.Border.BorderType = XlBorderType.xlAllEdges;

            // Set the table border style
            ExcelTableWriter bodyTable2 = sheet.OpenTable("B6:F15");
            bodyTable2.Border.Weight = XlBorderWeight.xlThick;
            bodyTable2.Border.LineColor = Color.FromArgb(0, 128, 128);
            bodyTable2.Border.BorderType = XlBorderType.xlAllEdges;

            aceCtrl.SetWriter(wb); // Don't forget this line of code
            aceCtrl.WebOpen("doc/test.xlsx", OpenModeType.xlsNormalEdit, "Tom");
        }
    }
}
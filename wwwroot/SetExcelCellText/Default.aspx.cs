using Aceoffix;
using Aceoffix.Excel;
using System;
using System.Drawing;


namespace Aceoffix7_Net.SetExcelCellText
{
    public partial class Default : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            WorkbookWriter wb = new WorkbookWriter();
            SheetWriter sheet = wb.OpenSheet("Sheet1");

            ExcelCellWriter cC3 = sheet.OpenCell("C3");
            // Set the cell background style
            cC3.BackColor = Color.AntiqueWhite;
            cC3.Value = "January";
            cC3.ForeColor = Color.Green;
            cC3.HorizontalAlignment = XlHAlign.xlHAlignCenter;

            ExcelCellWriter cD3 = sheet.OpenCell("D3");
            // Set the cell background style
            cD3.BackColor = Color.AntiqueWhite;
            cD3.Value = "February";
            cD3.ForeColor = Color.Green;
            cD3.HorizontalAlignment = XlHAlign.xlHAlignCenter;

            ExcelCellWriter cE3 = sheet.OpenCell("E3");
            // Set the cell background style
            cE3.BackColor = Color.AntiqueWhite;
            cE3.Value = "March";
            cE3.ForeColor = Color.Green;
            cE3.HorizontalAlignment = XlHAlign.xlHAlignCenter;

            ExcelCellWriter cB4 = sheet.OpenCell("B4");
            // Set the cell background style
            cB4.BackColor = Color.SkyBlue;
            cB4.Value = "Goods 1";
            cB4.HorizontalAlignment = XlHAlign.xlHAlignCenter;

            ExcelCellWriter cB5 = sheet.OpenCell("B5");
            // Set the cell background style
            cB5.BackColor = Color.Teal;
            cB5.Value = "Goods 2";
            cB5.HorizontalAlignment = XlHAlign.xlHAlignCenter;

            ExcelCellWriter cB6 = sheet.OpenCell("B6");
            // Set the cell background style
            cB6.BackColor = Color.MediumPurple;
            cB6.Value = "Goods 3";
            cB6.HorizontalAlignment = XlHAlign.xlHAlignCenter;

            ExcelCellWriter cB7 = sheet.OpenCell("B7");
            // Set the cell background style
            cB7.BackColor = Color.SteelBlue;
            cB7.Value = "goods 4";
            cB7.HorizontalAlignment = XlHAlign.xlHAlignCenter;

            // Draw the table lines
            ExcelTableWriter titleTable = sheet.OpenTable("B3:E10");
            titleTable.Border.Weight = XlBorderWeight.xlThick;
            titleTable.Border.LineColor = Color.FromArgb(0, 128, 128);
            titleTable.Border.BorderType = XlBorderType.xlAllEdges;

            // Merge cells and then assign a value
            sheet.OpenTable("B1:E2").Merge();
            sheet.OpenTable("B1:E2").RowHeight = 15; // Set the row height
            ExcelCellWriter B1 = sheet.OpenCell("B1");
            // Set the cell text style
            B1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            B1.VerticalAlignment = XlVAlign.xlVAlignCenter;
            B1.ForeColor = Color.FromArgb(0, 128, 128);
            B1.Value = "Business Trip Expense Budget";
            B1.Font.Bold = true;
            B1.Font.Size = 12;

            aceCtrl.SetWriter(wb); // Don't forget this line of code
            aceCtrl.WebOpen("doc/test.xlsx", OpenModeType.xlsNormalEdit, "Tom");
        }
    }
}
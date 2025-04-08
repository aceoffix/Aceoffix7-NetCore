using Aceoffix;
using Aceoffix.Excel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aceoffix7_Net.DrawExcel
{
    public partial class Excel : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            WorkbookWriter wb = new WorkbookWriter();

            ExcelTableWriter backGroundTable = wb.OpenSheet("Sheet1").OpenTable("A1:P200");
            backGroundTable.Border.LineColor = Color.White;

            wb.OpenSheet("Sheet1").OpenTable("A1:H2").Merge();
            wb.OpenSheet("Sheet1").OpenTable("A1:H2").RowHeight = 30;
            ExcelCellWriter A1 = wb.OpenSheet("Sheet1").OpenCell("A1");
            A1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            A1.VerticalAlignment = XlVAlign.xlVAlignCenter;
            A1.ForeColor = Color.FromArgb(255, 64, 0);
            A1.Value = "Consumption";

            wb.OpenSheet("Sheet1").OpenTable("A1:A1").Font.Bold = true;
            wb.OpenSheet("Sheet1").OpenTable("A1:A1").Font.Size = 25;


            ExcelTableWriter titleTable = wb.OpenSheet("Sheet1").OpenTable("B4:H5");
            titleTable.Border.BorderType = XlBorderType.xlAllEdges;
            titleTable.Border.Weight = XlBorderWeight.xlThick;
            titleTable.Border.LineColor = Color.FromArgb(255, 64, 0);

            ExcelTableWriter bodyTable = wb.OpenSheet("Sheet1").OpenTable("B6:H15");
            bodyTable.Border.LineColor = Color.Gray;
            bodyTable.Border.Weight = XlBorderWeight.xlHairline;

            ExcelBorder B7Border = wb.OpenSheet("Sheet1").OpenTable("B7:B7").Border;
            B7Border.LineColor = Color.White;

            ExcelBorder B9Border = wb.OpenSheet("Sheet1").OpenTable("B9:B9").Border;
            B9Border.BorderType = XlBorderType.xlBottomEdge;
            B9Border.LineColor = Color.White;

            ExcelBorder C6C15BorderLeft = wb.OpenSheet("Sheet1").OpenTable("C6:C15").Border;
            C6C15BorderLeft.LineColor = Color.White;
            C6C15BorderLeft.BorderType = XlBorderType.xlLeftEdge;

            ExcelBorder C6C15BorderRight = wb.OpenSheet("Sheet1").OpenTable("C6:C15").Border;
            C6C15BorderRight.LineColor = Color.Yellow;
            C6C15BorderRight.LineStyle = XlBorderLineStyle.xlDot;
            C6C15BorderRight.BorderType = XlBorderType.xlRightEdge;

            ExcelBorder E6E15Border = wb.OpenSheet("Sheet1").OpenTable("E6:E15").Border;
            E6E15Border.LineStyle = XlBorderLineStyle.xlDot;
            E6E15Border.BorderType = XlBorderType.xlAllEdges;
            E6E15Border.LineColor = Color.Yellow;

            ExcelBorder G6G15BorderRight = wb.OpenSheet("Sheet1").OpenTable("G6:G15").Border;
            G6G15BorderRight.BorderType = XlBorderType.xlRightEdge;
            G6G15BorderRight.LineColor = Color.White;

            ExcelBorder G6G15BorderLeft = wb.OpenSheet("Sheet1").OpenTable("G6:G15").Border;
            G6G15BorderLeft.LineStyle = XlBorderLineStyle.xlDot;
            G6G15BorderLeft.BorderType = XlBorderType.xlLeftEdge;
            G6G15BorderLeft.LineColor = Color.Yellow;

            ExcelTableWriter bodyTable2 = wb.OpenSheet("Sheet1").OpenTable("B6:H15");
            bodyTable2.Border.Weight = XlBorderWeight.xlThick;
            bodyTable2.Border.LineColor = Color.FromArgb(255, 64, 0);
            bodyTable2.Border.BorderType = XlBorderType.xlAllEdges;

            ExcelBorder H16H17Border = wb.OpenSheet("Sheet1").OpenTable("H16:H17").Border;
            H16H17Border.LineColor = Color.FromArgb(204, 255, 204);

            ExcelBorder E16G17Border = wb.OpenSheet("Sheet1").OpenTable("E16:G17").Border;
            E16G17Border.LineColor = Color.FromArgb(255, 64, 0);

            ExcelTableWriter footTable = wb.OpenSheet("Sheet1").OpenTable("B16:H17");
            footTable.Border.Weight = XlBorderWeight.xlThick;
            footTable.Border.LineColor = Color.FromArgb(255, 64, 0);
            footTable.Border.BorderType = XlBorderType.xlAllEdges;

            wb.OpenSheet("Sheet1").OpenTable("A1:A1").ColumnWidth = 1;
            wb.OpenSheet("Sheet1").OpenTable("B1:B1").ColumnWidth = 20;
            wb.OpenSheet("Sheet1").OpenTable("C1:C1").ColumnWidth = 15;
            wb.OpenSheet("Sheet1").OpenTable("D1:D1").ColumnWidth = 10;
            wb.OpenSheet("Sheet1").OpenTable("E1:E1").ColumnWidth = 8;
            wb.OpenSheet("Sheet1").OpenTable("F1:F1").ColumnWidth = 3;
            wb.OpenSheet("Sheet1").OpenTable("G1:G1").ColumnWidth = 12;
            wb.OpenSheet("Sheet1").OpenTable("H1:H1").ColumnWidth = 20;

            wb.OpenSheet("Sheet1").OpenTable("A16:A16").RowHeight = 20;
            wb.OpenSheet("Sheet1").OpenTable("A17:A17").RowHeight = 20;

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    wb.OpenSheet("Sheet1").OpenCellRC(4 + i, 2 + j).Font.Size = 10;
                }
            }


            for (int i = 0; i < 10; i++)
            {
                wb.OpenSheet("Sheet1").OpenCell("H" + (6 + i)).BackColor = Color.FromArgb(255, 255, 153);
            }

            wb.OpenSheet("Sheet1").OpenCell("E16").BackColor = Color.FromArgb(255, 64, 0);
            wb.OpenSheet("Sheet1").OpenCell("F16").BackColor = Color.FromArgb(255, 64, 0);
            wb.OpenSheet("Sheet1").OpenCell("G16").BackColor = Color.FromArgb(255, 64, 0);
            wb.OpenSheet("Sheet1").OpenCell("E17").BackColor = Color.FromArgb(255, 64, 0);
            wb.OpenSheet("Sheet1").OpenCell("F17").BackColor = Color.FromArgb(255, 64, 0);
            wb.OpenSheet("Sheet1").OpenCell("G17").BackColor = Color.FromArgb(255, 64, 0);
            wb.OpenSheet("Sheet1").OpenCell("H16").BackColor = Color.FromArgb(204, 255, 204);
            wb.OpenSheet("Sheet1").OpenCell("H17").BackColor = Color.FromArgb(204, 255, 204);

            ExcelCellWriter B4 = wb.OpenSheet("Sheet1").OpenCell("B4");
            B4.Font.Bold = true;
            B4.Value = "Consumption";
            ExcelCellWriter H5 = wb.OpenSheet("Sheet1").OpenCell("H5");
            H5.Font.Bold = true;
            H5.Value = "total";
            H5.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            ExcelCellWriter B6 = wb.OpenSheet("Sheet1").OpenCell("B6");
            B6.Font.Bold = true;
            B6.Value = "airfare";
            ExcelCellWriter B9 = wb.OpenSheet("Sheet1").OpenCell("B9");
            B9.Font.Bold = true;
            B9.Value = "hotel";
            ExcelCellWriter B11 = wb.OpenSheet("Sheet1").OpenCell("B11");
            B11.Font.Bold = true;
            B11.Value = "repast";
            ExcelCellWriter B12 = wb.OpenSheet("Sheet1").OpenCell("B12");
            B12.Font.Bold = true;
            B12.Value = "transportation fee";
            ExcelCellWriter B13 = wb.OpenSheet("Sheet1").OpenCell("B13");
            B13.Font.Bold = true;
            B13.Value = "entertainment";
            ExcelCellWriter B14 = wb.OpenSheet("Sheet1").OpenCell("B14");
            B14.Font.Bold = true;
            B14.Value = "gift";
            ExcelCellWriter B15 = wb.OpenSheet("Sheet1").OpenCell("B15");
            B15.Font.Bold = true;
            B15.Font.Size = 10;
            B15.Value = "other";

            wb.OpenSheet("Sheet1").OpenCell("C6").Value = "air fare";
            wb.OpenSheet("Sheet1").OpenCell("C7").Value = "air fare(back)";
            wb.OpenSheet("Sheet1").OpenCell("C8").Value = "other";
            wb.OpenSheet("Sheet1").OpenCell("C9").Value = "Daily National Consumption";
            wb.OpenSheet("Sheet1").OpenCell("C10").Value = "other";
            wb.OpenSheet("Sheet1").OpenCell("C11").Value = "Daily National Consumption";
            wb.OpenSheet("Sheet1").OpenCell("C12").Value = "Daily National Consumption";
            wb.OpenSheet("Sheet1").OpenCell("C13").Value = "total";
            wb.OpenSheet("Sheet1").OpenCell("C14").Value = "total";
            wb.OpenSheet("Sheet1").OpenCell("C15").Value = "total";

            wb.OpenSheet("Sheet1").OpenCell("G6");
            wb.OpenSheet("Sheet1").OpenCell("G7");
            wb.OpenSheet("Sheet1").OpenCell("G9");
            wb.OpenSheet("Sheet1").OpenCell("G10");
            wb.OpenSheet("Sheet1").OpenCell("G11").Value = " day";
            wb.OpenSheet("Sheet1").OpenCell("G12").Value = " day";

            wb.OpenSheet("Sheet1").OpenCell("H6").Formula = "=D6*F6";
            wb.OpenSheet("Sheet1").OpenCell("H7").Formula = "=D7*F7";
            wb.OpenSheet("Sheet1").OpenCell("H8").Formula = "=D8*F8";
            wb.OpenSheet("Sheet1").OpenCell("H9").Formula = "=D9*F9";
            wb.OpenSheet("Sheet1").OpenCell("H10").Formula = "=D10*F10";
            wb.OpenSheet("Sheet1").OpenCell("H11").Formula = "=D11*F11";
            wb.OpenSheet("Sheet1").OpenCell("H12").Formula = "=D12*F12";
            wb.OpenSheet("Sheet1").OpenCell("H13").Formula = "=D13*F13";
            wb.OpenSheet("Sheet1").OpenCell("H14").Formula = "=D14*F14";
            wb.OpenSheet("Sheet1").OpenCell("H15").Formula = "=D15*F15";

            for (int i = 0; i < 10; i++)
            {

                wb.OpenSheet("Sheet1").OpenCell("D" + (6 + i)).NumberFormatLocal = "$#,##0.00;$-#,##0.00";
                wb.OpenSheet("Sheet1").OpenCell("H" + (6 + i)).NumberFormatLocal = "$#,##0.00;$-#,##0.00";
            }

            ExcelCellWriter E16 = wb.OpenSheet("Sheet1").OpenCell("E16");
            E16.Font.Bold = true;
            E16.Font.Size = 11;
            E16.ForeColor = Color.White;
            E16.Value = "The total amount";
            E16.VerticalAlignment = XlVAlign.xlVAlignCenter;
            ExcelCellWriter E17 = wb.OpenSheet("Sheet1").OpenCell("E17");
            E17.Font.Bold = true;
            E17.Font.Size = 11;
            E17.ForeColor = Color.White;
            E17.Formula = "=IF(C4>H16,\"budget\",\"budget\")";
            E17.VerticalAlignment = XlVAlign.xlVAlignCenter;
            ExcelCellWriter H16 = wb.OpenSheet("Sheet1").OpenCell("H16");
            H16.VerticalAlignment = XlVAlign.xlVAlignCenter;
            H16.NumberFormatLocal = "$#,##0.00;$-#,##0.00";
            H16.Font.Name = "Arial";
            H16.Font.Size = 11;
            H16.Font.Bold = true;
            H16.Formula = "=SUM(H6:H15)";
            ExcelCellWriter H17 = wb.OpenSheet("Sheet1").OpenCell("H17");
            H17.VerticalAlignment =XlVAlign.xlVAlignCenter;
            H17.NumberFormatLocal = "$#,##0.00;$-#,##0.00";
            H17.Font.Name = "Arial";
            H17.Font.Size = 11;
            H17.Font.Bold = true;
            H17.Formula = "=(C4-H16)";

            ExcelCellWriter C4 = wb.OpenSheet("Sheet1").OpenCell("C4");
            C4.NumberFormatLocal = "$#,##0.00;$-#,##0.00";
            C4.Value = "2500";
            ExcelCellWriter D6 = wb.OpenSheet("Sheet1").OpenCell("D6");
            D6.NumberFormatLocal = "$#,##0.00;$-#,##0.00";
            D6.Value = "1200";
            wb.OpenSheet("Sheet1").OpenCell("F6").Font.Size = 10;
            wb.OpenSheet("Sheet1").OpenCell("F6").Value = "1";
            ExcelCellWriter D7 = wb.OpenSheet("Sheet1").OpenCell("D7");
            D7.NumberFormatLocal = "$#,##0.00;$-#,##0.00";
            D7.Value = "875";
            wb.OpenSheet("Sheet1").OpenCell("F7").Value = "1";

            aceCtrl.SetWriter(wb);
            aceCtrl.WebOpen("doc/test.xlsx", OpenModeType.xlsReadOnly, "Tom");

        }
    }
}
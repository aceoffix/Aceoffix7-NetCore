using Aceoffix;
using Aceoffix.Excel;
using System;

namespace Aceoffix7_Net.SubmitExcel
{
    public partial class SubmitExcel : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            WorkbookWriter wb = new WorkbookWriter();
            SheetWriter sheet1 = wb.OpenSheet("Purchase Order");

            System.Random rd = new Random(System.DateTime.Now.Millisecond);
            sheet1.OpenCell("D8").Value = "XYZ-11-" + (10001 + rd.Next(10000)).ToString();
            sheet1.OpenCell("D8").ReadOnly = true;

            ExcelCellWriter  cellDate = sheet1.OpenCell("I6");
            string dt = DateTime.Now.ToString();
            cellDate.Value = dt;
            sheet1.OpenCell("J31").Value = dt;

            sheet1.OpenCell("D15").ReadOnly = false; // Enabled edit

            ExcelTableWriter  table1 = sheet1.OpenTable("B18:J23");
            table1.ReadOnly = false; // Enabled edit

            sheet1.OpenCell("J24").ReadOnly = true;
            sheet1.OpenCell("J26").ReadOnly = true;
            sheet1.OpenCell("J28").ReadOnly = true;

            sheet1.OpenCell("G31").Value = "John Scott";

           aceCtrl.SetWriter(wb);
           aceCtrl.WebOpen("doc/test.xlsx", OpenModeType.xlsSubmitForm, "John Scott");

        }
    }
}
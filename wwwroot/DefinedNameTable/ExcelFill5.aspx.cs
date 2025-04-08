
using Aceoffix;
using Aceoffix.Excel;
using System;


namespace Aceoffix7_Net.DefinedNameTable
{
    public partial class ExcelFill5 : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            WorkbookWriter wb = new WorkbookWriter();
            SheetWriter sheet = wb.OpenSheet("Sheet1");
            ExcelTableWriter table = sheet.OpenTableByDefinedName("report", 4, 5, true);
            int rowCount = 12; // Assume the actual number of records to be automatically filled is 12.
            for (int i = 1; i <= rowCount; i++)
            {
                table.DataFields[0].Value = i + " month";
                table.DataFields[1].Value = "100";
                table.DataFields[2].Value = "120";
                table.DataFields[3].Value = "500";
                table.DataFields[4].Value = "120%";
                table.NextRow();
            }
            table.Close();

            // Define another table
            ExcelTableWriter table2 = sheet.OpenTableByDefinedName("report2", 4, 5, true);
            int rowCount2 = 4; // Assume the actual number of records to be automatically filled is 4.
            for (int i = 1; i <= rowCount2; i++)
            {
                table2.DataFields[0].Value = i + " quarter";
                table2.DataFields[1].Value = "300";
                table2.DataFields[2].Value = "300";
                table2.DataFields[3].Value = "300";
                table2.DataFields[4].Value = "100%";
                table2.NextRow();
            }
            table2.Close();

            aceCtrl.SetWriter(wb);
            aceCtrl.WebOpen("doc/test4.xlsx", OpenModeType.xlsNormalEdit, "Luna");

        }
    }
}
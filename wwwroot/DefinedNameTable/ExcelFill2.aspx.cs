using Aceoffix;
using Aceoffix.Excel;
using System;


namespace Aceoffix7_Net.DefinedNameTable
{
    public partial class ExcelFill2 : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            string tempFileName = Request.QueryString["temp"];
            WorkbookWriter wb = new WorkbookWriter();
            SheetWriter sheet = wb.OpenSheet("Sheet1");

            ExcelTableWriter table = sheet.OpenTableByDefinedName("report", 10, 5, false);
            table.DataFields[0].Value = "Jan";
            table.DataFields[1].Value = "100";
            table.DataFields[2].Value = "120";
            table.DataFields[3].Value = "500";
            table.DataFields[4].Value = "120%";
            table.NextRow();
            table.Close();

            ExcelCellWriter cellName = sheet.OpenCellByDefinedName("Name");
            cellName.Value = "Tom";

            aceCtrl.SetWriter(wb);
            aceCtrl.WebOpen("doc/"+tempFileName, OpenModeType.xlsNormalEdit, "Luna");

        }
    }
}
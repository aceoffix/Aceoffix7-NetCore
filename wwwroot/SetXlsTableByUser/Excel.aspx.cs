using Aceoffix;
using Aceoffix.Excel;
using System;
using System.Drawing;


namespace Aceoffix7_Net.SetXlsTableByUser
{
    public partial class Excel : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        public string userName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
           userName = Request.QueryString["userName"];

            WorkbookWriter wb = new WorkbookWriter();
            SheetWriter sheet = wb.OpenSheet("Sheet1");
            ExcelTableWriter tableA = sheet.OpenTable("C4:D6");
            ExcelTableWriter tableB = sheet.OpenTable("C7:D9");
            if (userName.Equals("Tom"))
            {
                tableA.ReadOnly = false;
                tableA.BackColor = Color.Yellow;
                tableB.ReadOnly = true;
                tableB.BackColor = Color.White;
            }
            else
            {
                tableB.ReadOnly = false;
                tableB.BackColor = Color.Yellow;
                tableA.ReadOnly = true;
                tableA.BackColor = Color.White;
            }

            aceCtrl.SetWriter(wb);
            aceCtrl.WebOpen("doc/test.xlsx",OpenModeType.xlsSubmitForm, "John Scott");

        }
    }
}
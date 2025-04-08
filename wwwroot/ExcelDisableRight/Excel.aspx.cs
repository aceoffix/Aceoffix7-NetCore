using Aceoffix;
using Aceoffix.Excel;
using System;


namespace Aceoffix7_Net.ExcelDisableRight
{
    public partial class Excel : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            WorkbookWriter workBook = new WorkbookWriter();
            // Disable the right - click function of the mouse on the current worksheet
            workBook.DisableSheetRightClick = true;
            // Disable the double - click function of the mouse on the current worksheet
            // workBook.DisableSheetDoubleClick = true; 
           aceCtrl.SetWriter(workBook);

           aceCtrl.WebOpen("doc/test.xlsx", OpenModeType.xlsNormalEdit, "Tom");
        }
    }
}
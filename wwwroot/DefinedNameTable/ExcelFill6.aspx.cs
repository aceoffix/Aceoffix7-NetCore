using Aceoffix;
using System;


namespace Aceoffix7_Net.DefinedNameTable
{
    public partial class ExcelFill6 : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            aceCtrl.WebOpen("doc/test4.xlsx", OpenModeType.xlsNormalEdit, "Luna");

        }
    }
}
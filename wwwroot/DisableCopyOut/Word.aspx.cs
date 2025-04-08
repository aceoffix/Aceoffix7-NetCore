using Aceoffix;
using System;


namespace Aceoffix7_Net.DisableCopyOut
{
    public partial class Word : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)

        {
            aceCtrl.DisableCopyOnly=true;
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docNormalEdit, "Tom");
        }
    }
}
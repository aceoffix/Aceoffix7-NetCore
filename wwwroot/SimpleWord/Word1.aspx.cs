using Aceoffix;
using System;


namespace Aceoffix7_Net.SimpleWord
{
    public partial class Word1 : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)

        {
            string filePath = Server.MapPath("doc/test.docx");
            aceCtrl.WebOpen(filePath, OpenModeType.docNormalEdit, "Tom");
        }
    }
}
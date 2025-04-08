using Aceoffix;
using System;


namespace Aceoffix7_Net.WordCompare
{
    public partial class Compare : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
           aceCtrl.WordCompare("doc/test1.docx", "doc/test2.docx", OpenModeType.docAdmin, "Tom");
        }
    }
}
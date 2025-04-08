using Aceoffix;
using System;


namespace Aceoffix7_Net.CommentsList
{
    public partial class Word : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docRevisionOnly, "John");
        }
    }
}
using Aceoffix;
using System;


namespace Aceoffix7_Net.SwitchFile
{
    public partial class Word : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            string  fileName = Request["fileName"];
            // Open the file
            aceCtrl.WebOpen("doc/" + fileName, OpenModeType.docReadOnly, "Tom");
            Response.Write(aceCtrl.GetHtml());
        }
    }
}
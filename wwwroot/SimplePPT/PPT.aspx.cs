using Aceoffix;
using System;
namespace Aceoffix7_Net.SimplePPT
{
    public partial class PPT : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)

        {
            aceCtrl.WebOpen("doc/test.pptx", OpenModeType.pptNormalEdit, "Tom");
        }
    }
}
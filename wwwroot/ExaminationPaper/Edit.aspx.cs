using Aceoffix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aceoffix7_Net.ExaminationPaper
{
    public partial class Edit : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        public string id = "";
        protected void Page_Load(object sender, EventArgs e)

        {
            id = Request.QueryString["id"];
            aceCtrl.WebOpen("OpenFile?id=" + id, OpenModeType.docNormalEdit, "Tom");
        }
    }
}
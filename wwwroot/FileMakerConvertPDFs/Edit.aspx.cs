using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aceoffix7_Net.FileMakerConvertPDFs
{
    public partial class Edit : System.Web.UI.Page
    {

        public Aceoffix.AceoffixCtrl aceCtrl = new Aceoffix.AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"].Trim();
            string filePath = "";

            if ("1".Equals(id))
            {
                filePath = Server.MapPath("doc/Aceoffix Product Overview.docx");
            }
            if ("2".Equals(id))
            {
                filePath = Server.MapPath("doc/Aceoffix Trial Limits.docx");
            }
            if ("3".Equals(id))
            {
                filePath = Server.MapPath("doc/Aceoffix License Policy.docx");
            }
            if ("4".Equals(id))
            {
                filePath = Server.MapPath("doc/Introduction to Aceoffix.docx");
            }

            aceCtrl.WebOpen(filePath, Aceoffix.OpenModeType.docNormalEdit, "Tom");
        }
    }
}
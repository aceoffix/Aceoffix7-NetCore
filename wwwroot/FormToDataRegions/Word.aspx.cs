using Aceoffix.Word;
using Aceoffix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aceoffix7_Net.FormToDataRegions
{
    public partial class Word1 : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            WordDocumentWriter worddoc = new WordDocumentWriter();
            worddoc.OpenDataRegion("ACE_purchaser").Editing = true;
            worddoc.OpenDataRegion("ACE_supplier").Editing = true;
            worddoc.OpenDataRegion("ACE_project_number").Editing = true;
            worddoc.OpenDataRegion("ACE_buyer_company").Editing = true;
            worddoc.OpenDataRegion("ACE_table").Editing = true;
            worddoc.OpenDataRegion("ACE_totalPrice").Editing = true;

            aceCtrl.SetWriter(worddoc);
            aceCtrl.WebOpen(Server.MapPath("doc/test.docx"), OpenModeType.docSubmitForm, "Luna");
        }
    }
}

using System;
using Aceoffix.Word;
using Aceoffix;

namespace Aceoffix7_Net.DataRegionEdit
{
    public partial class Word : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            WordDocumentWriter doc = new WordDocumentWriter();
            doc.Template.DefineDataRegion("ACE_contract_number", "[contract number]");
            doc.Template.DefineDataRegion("ACE_purchasers_name", "[Purchasers full name]");
            doc.Template.DefineDataRegion("ACE_purchasers_email", "[Purchasers email]");
            doc.Template.DefineDataRegion("ACE_purchasers_address", "[Purchasers address]");
            doc.Template.DefineDataRegion("ACE_suppliers_name", "[Suppliers full name]");
            doc.Template.DefineDataRegion("ACE_suppliers_email", "[Suppliers email]");
            doc.Template.DefineDataRegion("ACE_suppliers_address", "[Suppliers address]");

            aceCtrl.SetWriter(doc);
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docNormalEdit, "Tom");
        }
    }
}
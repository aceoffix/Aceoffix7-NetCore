using Aceoffix;
using Aceoffix.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aceoffix7_Net.DataTagEdit
{
    public partial class Word : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            WordDocumentWriter doc = new WordDocumentWriter();
            doc.Template.DefineDataTag("{contract number}");
            doc.Template.DefineDataTag("{Purchasers full name}");
            doc.Template.DefineDataTag("{Purchasers email}");
            doc.Template.DefineDataTag("{Purchasers address}");
            doc.Template.DefineDataTag("{Suppliers full name}");
            doc.Template.DefineDataTag("{Suppliers email}");
            doc.Template.DefineDataTag("{Suppliers address}");

            aceCtrl.SetWriter(doc);
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docNormalEdit, "Tom");
        }
    }
}
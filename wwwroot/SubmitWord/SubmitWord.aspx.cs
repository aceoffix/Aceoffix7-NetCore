using Aceoffix;
using Aceoffix.Word;
using System;

namespace Aceoffix7_Net.SubmitWord
{
    public partial class Word : System.Web.UI.Page
    {

        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            WordDocumentWriter wordDoc = new WordDocumentWriter();
            // Get the data region object and then assign a value
            DataRegionWriter dataRegion1 = wordDoc.OpenDataRegion("ACE_Name");
            dataRegion1.Editing = true;
            dataRegion1.Value = " ";
            // You can also assign a value directly
            DataRegionWriter dataRegion2 = wordDoc.OpenDataRegion("ACE_department");
            dataRegion2.Editing = true;
            dataRegion2.Value = " ";

            aceCtrl.SetWriter(wordDoc); // Note that you must not forget this line of code. If this line is missing, the assignment will not succeed.
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docSubmitForm, "Luna");
        }
    }
}
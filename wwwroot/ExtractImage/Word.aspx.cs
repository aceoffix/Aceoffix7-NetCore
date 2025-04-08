using Aceoffix;
using Aceoffix.Word;
using System;


namespace Aceoffix7_Net.ExtractImage
{
    public partial class Word : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            WordDocumentWriter wordDoc = new WordDocumentWriter();
            DataRegionWriter dataRegion1 = wordDoc.OpenDataRegion("ACE_image");
            dataRegion1.Editing = true;
            aceCtrl.SetWriter(wordDoc);

            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docSubmitForm, "Tom");
        }
    }
}
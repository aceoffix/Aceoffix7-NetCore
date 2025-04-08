using Aceoffix;
using Aceoffix.Word;
using System;


namespace Aceoffix7_Net.SplitWord
{
    public partial class Word : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {

            WordDocumentWriter wordDoc = new WordDocumentWriter();

            DataRegionWriter dataRegion1 = wordDoc.OpenDataRegion("ACE_paragraph1");
            dataRegion1.SubmitAsFile = true;

            DataRegionWriter dataRegion2 = wordDoc.OpenDataRegion("ACE_paragraph2");
            dataRegion2.SubmitAsFile = true;
            dataRegion2.Editing = true;

            DataRegionWriter dataRegion3 = wordDoc.OpenDataRegion("ACE_paragraph3");
            dataRegion3.SubmitAsFile = true;

            aceCtrl.SetWriter(wordDoc);
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docSubmitForm, "Tom");
        }
    }
}
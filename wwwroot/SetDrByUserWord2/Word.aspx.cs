
using Aceoffix;
using Aceoffix.Word;
using System;


namespace Aceoffix7_Net.SetDrByUserWord2
{
    public partial class Word : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();

        public string userName = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            userName = Request.QueryString["userName"];
            WordDocumentWriter doc = new WordDocumentWriter();
            DataRegionWriter dataRegion1 = doc.OpenDataRegion("ACE_Paragraph1");
            DataRegionWriter dataRegion2 = doc.OpenDataRegion("ACE_Paragraph2");

            dataRegion1.Value = "[word]doc/paragraph1.docx[/word]";
            dataRegion2.Value = "[word]doc/paragraph2.docx[/word]";

            if (userName.Equals("Tom"))
            {
                dataRegion1.Editing = true;
                dataRegion2.Editing = false;
                dataRegion1.SubmitAsFile = true;

            }

            else
            {
                dataRegion1.Editing = false;
                dataRegion2.Editing = true;
                dataRegion2.SubmitAsFile = true;
            }

            aceCtrl.SetWriter(doc);
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docSubmitForm, userName);
        }
    }
}
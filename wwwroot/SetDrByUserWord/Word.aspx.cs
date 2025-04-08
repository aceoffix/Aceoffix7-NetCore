
using Aceoffix;
using Aceoffix.Word;
using System;


namespace Aceoffix7_Net.SetDrByUserWord
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

            if (userName.Equals("Tom"))
            {
                dataRegion1.Editing = true;
                dataRegion2.Editing = false;
       
            }

            else
            {
                dataRegion1.Editing = false;
                dataRegion2.Editing = true;
            }

            aceCtrl.SetWriter(doc);
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docSubmitForm, userName);
        }
    }
}
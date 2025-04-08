using Aceoffix;
using Aceoffix.Word;
using System;


namespace Aceoffix7_Net.WordTextBox
{
    public partial class Word : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            WordDocumentWriter wordDoc = new WordDocumentWriter();
            wordDoc.OpenDataRegion("ACE_logo").Value = "[image]doc/logo.png[/image]";

            aceCtrl.SetWriter(wordDoc);
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docNormalEdit, "Tom");
        }
    }
}
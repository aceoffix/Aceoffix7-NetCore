using Aceoffix;
using Aceoffix.Word;
using System;

namespace Aceoffix7_Net.AddWaterMark
{
    public partial class Word : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            WordDocumentWriter wordDoc = new WordDocumentWriter();
            wordDoc.WaterMark.Text = "Aceoffix";
            aceCtrl.SetWriter(wordDoc); // Note that you must not forget this line of code. If this line is missing, the assignment will not succeed.
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docNormalEdit, "Luna");
        }
    }
}
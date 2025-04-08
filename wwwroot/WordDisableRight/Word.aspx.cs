
using Aceoffix;
using Aceoffix.Word;
using System;


namespace Aceoffix7_Net.WordDisableRight
{
    public partial class Word : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)

        {
            WordDocumentWriter doc = new WordDocumentWriter();
            doc.DisableWindowRightClick=true;
            //doc.DisableWindowDoubleClick = true;    // Disable the double-click function in Word
            aceCtrl.SetWriter(doc);
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docNormalEdit, "Tom");
        }
    }
}
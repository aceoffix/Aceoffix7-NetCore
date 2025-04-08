using System;
using Aceoffix;
using Aceoffix.Word;

namespace Aceoffix7_Net.InsertPageBreak2
{
    public partial class Word : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            WordDocumentWriter wordDocument = new WordDocumentWriter();

            // Insert a page break at the end of the document and create a new data region to insert another document on the new page.
            DataRegionWriter mydr1 = wordDocument.CreateDataRegion("ACE_first", DataRegionInsertType.After, "[end]");
            mydr1.SelectEnd();
            wordDocument.InsertPageBreak(); // Insert a page break

            DataRegionWriter mydr2 = wordDocument.CreateDataRegion("ACE_second", DataRegionInsertType.After, "[end]");
            mydr2.Value = "[word]/InsertPageBreak2/doc/test2.docx[/word]";

            aceCtrl.SetWriter(wordDocument);

            aceCtrl.WebOpen("doc/test1.docx", OpenModeType.docNormalEdit, "Tom");
        }
    }
}
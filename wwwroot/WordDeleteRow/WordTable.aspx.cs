
using Aceoffix;
using Aceoffix.Word;
using System;

namespace Aceoffix7_Net.WordDeleteRow
{
    public partial class WordTable : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        public string filePath = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            filePath=Request.ApplicationPath + "WordDeleteRow/doc";
            WordDocumentWriter doc = new WordDocumentWriter();
            WordTableWriter table1 = doc.OpenDataRegion("ACE_table").OpenTable(1);
            WordCellWriter cell = table1.OpenCellRC(2, 1);
            table1.RemoveRowAt(cell);// Delete the row where the cell at coordinates (2, 1) is located.

            aceCtrl.SetWriter(doc);
            aceCtrl.WebOpen("doc/test_table.docx", OpenModeType.docNormalEdit, "Tom");
        }
    }
}
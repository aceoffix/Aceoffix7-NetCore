using Aceoffix;
using Aceoffix.Word;
using System;
using System.Drawing;


namespace Aceoffix7_Net.MergeWordCell
{
    public partial class Default : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            WordDocumentWriter doc =new WordDocumentWriter();
            WordTableWriter table = doc.OpenDataRegion("Table1").OpenTable(1);

            table.OpenCellRC(1, 1).MergeTo(1, 5);
            table.OpenCellRC(1, 1).Value = "Aceoffix";
            table.OpenCellRC(1, 1).Font.Color = Color.Red;
            table.OpenCellRC(1, 1).Font.Size = 24;
            table.OpenCellRC(1, 1).Font.Name = "Andalus";
            table.OpenCellRC(1, 1).ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

            aceCtrl.SetWriter(doc);
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docNormalEdit, "John Scott");

        }
    }
}
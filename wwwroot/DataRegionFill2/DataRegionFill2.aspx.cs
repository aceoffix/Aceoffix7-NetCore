
using Aceoffix;
using Aceoffix.Word;
using System;
using System.Drawing;

namespace Aceoffix7_Net.DataRegionFill2
{
    public partial class DataRegionFill2 : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            WordDocumentWriter wordDoc = new WordDocumentWriter();

            DataRegionWriter dataRegion1 = wordDoc.OpenDataRegion("ACE_Name");
            dataRegion1.Value = "John";
            dataRegion1.Font.Color = Color.Orange;//Font Color
            dataRegion1.Font.Name = "Algerian";// Font Style
            dataRegion1.Font.Size = 14;
            dataRegion1.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;//Alignment

   
            DataRegionWriter dataRegion2 = wordDoc.OpenDataRegion("ACE_department");
            dataRegion2.Value = "Sales Department";
            dataRegion2.Font.Color = Color.Magenta;//Font Color
            dataRegion2.Font.Name = "Blackadder ITC";// Font Style
            dataRegion2.Font.Size = 12;
            dataRegion2.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;//Alignment


            aceCtrl.SetWriter(wordDoc); // Note that you must not forget this line of code. If this line is missing, the assignment will not succeed.
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docNormalEdit, "Luna");
        }
    }
}
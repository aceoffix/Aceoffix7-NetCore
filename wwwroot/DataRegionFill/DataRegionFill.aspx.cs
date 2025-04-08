using Aceoffix;
using Aceoffix.Word;
using System;

namespace Aceoffix7_Net.DataRegionFill
{
    public partial class DataRegionFill : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            WordDocumentWriter wordDoc = new WordDocumentWriter();
            // Get the data region object and then assign a value
            DataRegionWriter dataRegion1 = wordDoc.OpenDataRegion("ACE_Name");
            dataRegion1.Value = "John";
            // You can also assign a value directly
            wordDoc.OpenDataRegion("ACE_department").Value = "Sales Department";
            aceCtrl.SetWriter(wordDoc); // Note that you must not forget this line of code. If this line is missing, the assignment will not succeed.
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docNormalEdit, "Luna");
        }
    }
}
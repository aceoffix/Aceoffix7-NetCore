
using Aceoffix;
using Aceoffix.Word;
using System;

namespace Aceoffix7_Net.DataRegionTable
{
    public partial class Default : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            WordDocumentWriter doc = new WordDocumentWriter();
            // Open the data region
            DataRegionWriter dTable = doc.OpenDataRegion("ACE_table");
            // Set the editability of the data region
            dTable.Editing = true;
            // Open the table in the data region. The 'index' in the OpenTable(index) method is the sub - index of the table in the Word document, starting from 1.
            WordTableWriter table1 = doc.OpenDataRegion("ACE_table").OpenTable(1);
            // Assign values to the header cells of the table
            table1.OpenCellRC(1, 2).Value = "Product 1";
            table1.OpenCellRC(1, 3).Value = "Product 2";
            table1.OpenCellRC(2, 1).Value = "Department A";
            table1.OpenCellRC(3, 1).Value = "Department B";
            aceCtrl.SetWriter(doc);
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docSubmitForm, "Tom");
        }
    }
}
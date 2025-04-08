
using Aceoffix;
using Aceoffix.Word;
using System;
using System.Drawing;

namespace Aceoffix7_Net.WordTableBorder
{
    public partial class TableBorder : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            WordDocumentWriter doc = new WordDocumentWriter();

            // Get the data region object where the table is located
            DataRegionWriter dataRegion = doc.OpenDataRegion("ACE_table");

            // Open the table. The index in the OpenTable(index) method represents the position of the table in the Word document, starting from 1.
            WordTableWriter table = dataRegion.OpenTable(1);

            // Insert an empty row below a specified cell. The parameter in the InsertRowAfter method indicates which cell to insert the row after.
            table.InsertRowAfter(table.OpenCellRC(3, 3));

            // Assign values to the cells in the table using OpenCellRC(row, column)
            table.OpenCellRC(3, 1).Value = "Company A";
            table.OpenCellRC(3, 2).Value = "Development Department";
            table.OpenCellRC(3, 3).Value = "John";

            // Assign values to the newly inserted row
            table.OpenCellRC(4, 1).Value = "Company B";
            table.OpenCellRC(4, 2).Value = "Sales Department";
            table.OpenCellRC(4, 3).Value = "Lisa";

            // Set the height of the table rows
            table.SetRowsHeight(25.5f);

            // Set the border style of the table
            WordBorder border = table.Border;

            // Set the type of the border
            border.BorderType = WdBorderType.wdFullGrid; // Includes inner borders

            // Set the color of the border
            border.LineColor = Color.Red;

            // Set the line style of the border
            border.LineStyle = WdLineStyle.wdLineStyleDot;

            // Set the thickness of the border
            border.LineWidth = WdLineWidth.wdLineWidth150pt;

            // Set the font style for the table
            WordFont font = dataRegion.Font;

            // Set whether the font is bold
            font.Bold = true;

            // Set the font color
            font.Color = Color.Blue;

            // Set whether the font is italicized
            font.Italic = true;

            // Set the font name
            font.Name = "Arial"; 
            // Set the font size
            font.Size = 12.5f;

            // Set the document writer and open the document for editing
            aceCtrl.SetWriter(doc);
            aceCtrl.WebOpen("doc/test_table.docx", OpenModeType.docNormalEdit, "Tom");
        }
    }
}
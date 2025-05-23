﻿
using Aceoffix;
using Aceoffix.Word;
using System;

namespace Aceoffix7_Net.WordTableSetImg
{
    public partial class WordTable : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            WordDocumentWriter doc = new WordDocumentWriter();
            WordTableWriter table1 = doc.OpenDataRegion("ACE_T001").OpenTable(1);
            table1.OpenCellRC(1, 1).Value = "[image]/ExcelInsertImage/doc/logo.png[/image]";
            int oldRowCount = 3; // The original number of rows in the table.
            int dataRowCount = 5; // The number of rows to be filled with data.

            // Expand the table.
            for (int j = 0; j < dataRowCount - oldRowCount; j++)
            {
                // Insert a new row after the last cell in the second row.
                table1.InsertRowAfter(table1.OpenCellRC(2, 5));
            }

            int i = 1;
            while (i <= dataRowCount)
            {
                table1.OpenCellRC(i, 2).Value = "AA" + i.ToString();
                table1.OpenCellRC(i, 3).Value = "BB" + i.ToString();
                table1.OpenCellRC(i, 4).Value = "CC" + i.ToString();
                table1.OpenCellRC(i, 5).Value = "DD" + i.ToString();
                i++;
            }

            aceCtrl.SetWriter(doc);
            aceCtrl.WebOpen("doc/test_table.docx", OpenModeType.docNormalEdit, "Tom");
        }
    }
}
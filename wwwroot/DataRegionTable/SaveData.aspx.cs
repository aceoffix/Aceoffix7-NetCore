
using Aceoffix.Word;
using System;
using System.Text;

namespace Aceoffix7_Net.DataRegionTable
{
    public partial class SaveData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WordDocumentReader doc = new WordDocumentReader();

            // Open the data region with the specified name
            DataRegionReader dataReg = doc.OpenDataRegion("ACE_table");

            // Open the first table in the data region
            WordTableReader table = dataReg.OpenTable(1);

            /**
             * In actual development, generally, after obtaining the value of the data region, it is used to interact with the database.
             * For example, new records can be added, existing records can be updated, or records can be deleted in the database based on the obtained data.
             * Here, in order to show the obtained data content to the user, the value of the obtained data region is returned to the front - end page through setCustomSaveResult for the user to check the execution result.
             * If you only want to return a save result, you can use something like: setCustomSaveResult("ok"). The front - end can perform the next logical processing based on this save result.
             */
            StringBuilder dataStr = new StringBuilder();
            for (int i = 1; i <= table.RowsCount; i++)
            {
                for (int j = 1; j <= table.ColumnsCount; j++)
                {
                    dataStr.Append("The value of cell (" + i + "," + j + ") is: " + table.OpenCellRC(i, j).Value+ "\r\n");
                }
            }

            // Return data to the front - end page through CustomSaveResult
            doc.CustomSaveResult= dataStr.ToString();

            // This is necessary and should be placed on the last line
            doc.Close();
        }
    }
}
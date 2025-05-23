﻿
using Aceoffix;
using Aceoffix.Word;
using System;

namespace Aceoffix7_Net.DataRegionCreate
{
    public partial class DataRegionCreate : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {

            WordDocumentWriter wordDoc = new WordDocumentWriter();
            // The three parameters of the CreateDataRegion method represent respectively: the name of the tag where the new data region will be created, the insertion position of the DataRegion, and the name of the bookmark associated with the DataRegion to be created.
            // If there are no bookmarks in the opened Word document or you want to create a new data region at the beginning of the Word document, use "[home]" as the third parameter. If you want to create it at the end, use "[end]".
            DataRegionWriter dataRegion1 = wordDoc.CreateDataRegion("createDataRegion1", DataRegionInsertType.After, "[home]");
            // Assign a value to the created DataRegion
            dataRegion1.Value = "new DataRegion1\r\n";
            DataRegionWriter dataRegion2 = wordDoc.CreateDataRegion("createDataRegion2", DataRegionInsertType.After, "createDataRegion1");
            dataRegion2.Value = "new DataRegion2\r\n";
            aceCtrl.SetWriter(wordDoc);
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docNormalEdit, "Tom");
        }
    }
}
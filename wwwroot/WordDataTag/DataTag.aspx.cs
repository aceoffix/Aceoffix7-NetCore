﻿
using Aceoffix;
using Aceoffix.Word;
using System;
using System.Drawing;


namespace Aceoffix7_Net.WordDataTag
{
    public partial class DataTag : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {

            WordDocumentWriter wd = new WordDocumentWriter();
            DataTagWriter dataTag1 = wd.OpenDataTag("{name}");
            dataTag1.Value = "Tom";
            dataTag1.Font.Color=Color.Red;
            dataTag1.Font.Bold = true;

            DataTagWriter dataTag2 = wd.OpenDataTag("{Number}");
            dataTag2.Value = "201501";
            dataTag2.Font.Bold= true;

            DataTagWriter dataTag3 = wd.OpenDataTag("{Department}");
            dataTag3.Value = "Development";
            dataTag3.Font.Italic= true;

            DataTagWriter dataTag4 = wd.OpenDataTag("{Manager}");
            dataTag4.Value = "John Scott";
            dataTag4.Font.Color = Color.Green;

            DataTagWriter dataTag5 = wd.OpenDataTag("{Salary}");
            dataTag5.Value = "$5000";
            dataTag5.Font.Bold= true;

            aceCtrl.SetWriter(wd);
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docNormalEdit, "John Scott");

        }
    }
}
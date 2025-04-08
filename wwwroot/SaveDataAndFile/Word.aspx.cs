using Aceoffix;
using Aceoffix.Word;
using System;

namespace Aceoffix7_Net.SaveDataAndFile
{
    public partial class Word : System.Web.UI.Page
    {
        public AceoffixCtrl aceCtrl = new AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {

            WordDocumentWriter wd = new WordDocumentWriter();
            DataRegionWriter dataRegion1 = wd.OpenDataRegion("ACE_Name");
            dataRegion1.Editing = true;
            dataRegion1.Value = "Tom";
            DataRegionWriter dataRegion3 = wd.OpenDataRegion("ACE_Department");
            dataRegion3.Editing = true;
            dataRegion3.Value = "Development";

            aceCtrl.SetWriter(wd);

            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docSubmitForm, "John Scott");
        }
    }
}
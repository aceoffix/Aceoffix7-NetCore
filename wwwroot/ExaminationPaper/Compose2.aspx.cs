using Aceoffix.Word;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aceoffix7_Net.ExaminationPaper
{
    public partial class Compose2 : System.Web.UI.Page
    {
        public Aceoffix.AceoffixCtrl aceCtrl = new Aceoffix.AceoffixCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            int num = 1; // Question number
            if (Request.QueryString["ids"] == null || Request.QueryString["ids"] == "")
            {
                return;
            }
            string idlist = Request.QueryString["ids"].Trim();
            string[] ids = idlist.Split(','); 

            string temp = "ACE_begin"; 
            WordDocumentWriter doc = new WordDocumentWriter();
            for (int i = 0; i < ids.Length; i++)
            {
                DataRegionWriter dataNum = doc.CreateDataRegion("ACE_" + num, DataRegionInsertType.After, temp);
                dataNum.Value = num + ".\t";
                DataRegionWriter dataReg = doc.CreateDataRegion("ACE_begin" + (i + 1), DataRegionInsertType.After, "ACE_" + num);
                dataReg.Value = "[word]OpenFile?id=" + ids[i] + "[/word]";
                num++;
                temp = "ACE_begin" + (i + 1);
            }

            aceCtrl.SetWriter(doc);
            aceCtrl.WebOpen("doc/test.docx", Aceoffix.OpenModeType.docReadOnly, "Tom");
        }
    }
}

using Aceoffix.Word;
using System;
using System.IO;


namespace Aceoffix7_Net.SplitWord
{
    public partial class SaveData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WordDocumentReader doc = new WordDocumentReader();
            Byte[] bWord;

            DataRegionReader dr1 = doc.OpenDataRegion("ACE_paragraph1");
            bWord = dr1.FileBytes;
            Stream s1 = new FileStream(Server.MapPath("doc/") + "paragraph1.docx", FileMode.Create);
            s1.Write(bWord, 0, bWord.Length);
            s1.Close();


            DataRegionReader dr2 = doc.OpenDataRegion("ACE_paragraph2");
            bWord = dr2.FileBytes;
            Stream s2 = new FileStream(Server.MapPath("doc/") + "paragraph2.docx", FileMode.Create);
            s2.Write(bWord, 0, bWord.Length);
            s2.Close();

            DataRegionReader dr3 = doc.OpenDataRegion("ACE_paragraph3");
            bWord = dr3.FileBytes;
            Stream s3 = new FileStream(Server.MapPath("doc/") + "paragraph3.docx", FileMode.Create);
            s3.Write(bWord, 0, bWord.Length);
            s3.Close();

            doc.Close();
        }
    }
}
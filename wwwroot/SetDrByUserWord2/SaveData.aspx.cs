
using Aceoffix.Word;
using System;
using System.IO;

namespace Aceoffix7_Net.SetDrByUserWord2
{
    public partial class SaveFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WordDocumentReader doc = new WordDocumentReader();

            if (Request.QueryString["userName"] != null && Request.QueryString["userName"].Equals("Tom"))
            {
                saveBytesToFile(doc.OpenDataRegion("ACE_Paragraph1").FileBytes, Server.MapPath("doc/paragraph1.docx"));
            }
            else
            {
                saveBytesToFile(doc.OpenDataRegion("ACE_Paragraph2").FileBytes, Server.MapPath("doc/paragraph2.docx"));
            }
            doc.Close();
        }
        private void saveBytesToFile(byte[] bytes, string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();
        }
    }
}
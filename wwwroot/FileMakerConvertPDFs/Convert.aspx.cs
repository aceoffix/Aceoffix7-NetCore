using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aceoffix7_Net.FileMakerConvertPDFs
{
    public partial class Convert : System.Web.UI.Page
    {

        public Aceoffix.FileMakerCtrl fmCtrl = new Aceoffix.FileMakerCtrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"].Trim();
            string filePath = "";
            string pdfName = "";

            if ("1".Equals(id))
            {
                filePath = Server.MapPath("doc/Aceoffix Product Overview.docx");
                pdfName = "Aceoffix Product Overview.pdf";
            }
            if ("2".Equals(id))
            {
                filePath = Server.MapPath("doc/Aceoffix Trial Limits.docx");
                pdfName = "Aceoffix Trial Limits.pdf";
            }
            if ("3".Equals(id))
            {
                filePath = Server.MapPath("doc/Aceoffix License Policy.docx");
                pdfName = "Aceoffix License Policy.pdf";
            }
            if ("4".Equals(id))
            {
                filePath = Server.MapPath("doc/Introduction to Aceoffix.docx");
                pdfName = "Introduction to Aceoffix.pdf";
            }

            fmCtrl.FillDocumentAsPDF(filePath, Aceoffix.DocumentOpenType.Word, pdfName);
        }
    }
}
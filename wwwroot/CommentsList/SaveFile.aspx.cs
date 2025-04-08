using System;


namespace Aceoffix7_Net.CommentsList
{
    public partial class SaveFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Aceoffix.FileSaver fs = new Aceoffix.FileSaver();
            fs.SaveToFile(Server.MapPath("doc/") + fs.FileName);
            fs.Close();
        }
    }
}
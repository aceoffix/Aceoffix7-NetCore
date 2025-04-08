using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aceoffix7_Net.FileMaker
{
    public partial class SaveMaker : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);
            Aceoffix.FileSaver fs = new Aceoffix.FileSaver();
            fs.SaveToFile(Server.MapPath("doc/") + "maker" + id + fs.FileExtName);
            // Set the custom save result to be returned to the front - end page. The parameter of CustomSaveResult can also be in the form of a JSON string.
            fs.CustomSaveResult = "ok";
            fs.Close();
        }
    }
}
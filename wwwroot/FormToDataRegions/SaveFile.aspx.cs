using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aceoffix7_Net.FormToDataRegions
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
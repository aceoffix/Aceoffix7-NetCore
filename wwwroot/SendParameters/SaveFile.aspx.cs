using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aceoffix7_Net.SendParameters
{
    public partial class SaveFile : System.Web.UI.Page
    {
        public int id = 0;
        public string userName = "";
        public int age = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Aceoffix.FileSaver fs = new Aceoffix.FileSaver();
            fs.SaveToFile(Server.MapPath("doc/") + fs.FileName);

            // Get the value passed via the URL
            if (Request.QueryString["id"] != null && Request.QueryString["id"].Trim().Length > 0)
                id = int.Parse(Request.QueryString["id"].Trim());

            // Get the parameter value passed via the web page label control. Note that the parameter name in the fs.GetFormField("name of the HTML label") method refers to the ID of the label.
            // Get the value passed via the text box <input type="text" /> label
            if (fs.GetFormField("userName") != null && fs.GetFormField("userName").Trim().Length > 0)
            {
                userName = fs.GetFormField("userName");
                userName = HttpUtility.UrlDecode(userName);
            }

            // Get the value passed via the hidden field
            if (fs.GetFormField("age") != null && fs.GetFormField("age").Trim().Length > 0)
            {
                age = int.Parse(fs.GetFormField("age"));
            }

            //string connstring = "Data Source=" + Server.MapPath("/App_Data/SendParameters.db");
            //SQLiteConnection conn = new SQLiteConnection(connstring);
            //conn.Open();
            //string strsql;
            //SQLiteCommand cmd = new SQLiteCommand();
            //cmd.Connection = conn;
            //cmd.CommandType = CommandType.Text;
            //strsql = "Update Users set UserName = '" + userName + "', age = " + age + ",sex = '" + sex + "' where id = " + id;
            //cmd.CommandText = strsql;
            //cmd.ExecuteNonQuery();
            //conn.Close();

            JObject jsonObject = new JObject();
            jsonObject["id"] = id;
            jsonObject["userName"] = userName;
            jsonObject["age"] = age;
            // Convert the JObject to a JSON string
            string jsonString = jsonObject.ToString();
            // Return a JSON - formatted result to the aceoffix control page
            fs.CustomSaveResult = jsonString;
            // Close the FileSaver object            
            fs.Close();
        }
    }
}
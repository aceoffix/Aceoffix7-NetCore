
using Aceoffix.Word;
using System;


namespace Aceoffix7_Net.SaveDataAndFile
{
    public partial class SaveData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WordDocumentReader doc = new WordDocumentReader();
            // Get the submitted values
            string dataUserName = doc.OpenDataRegion("ACE_Name").Value;
            string dataDeptName = doc.OpenDataRegion("ACE_Department").Value;
            string companyName = doc.GetFormField("CompanyName");

            /**The retrieved content such as company name, employee name, and department name can be saved to the database. 
             * Here, developers can connect to their own databases, for example, connect to a SQL Server 2008 database.
             * string constr = "server=ACER-PC\\LI;database=db_test;uid=sa;pwd=123";
             * conn = new SqlConnection(constr);  // Database connection
             * conn.Open();
             * SqlCommand cmd = new SqlCommand("update user set userName='" + dataUserName + "',deptName='" + dataDeptName + "',companyName='" + companyName + "' where userId=1", conn);
             * cmd.ExecuteNonQuery();
             * conn.Close();
             */
            doc.CustomSaveResult = "ok1";
            doc.Close();
        }
    }
}
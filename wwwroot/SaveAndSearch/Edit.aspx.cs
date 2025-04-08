using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aceoffix7_Net.SaveAndSearch
{
    public partial class Edit : System.Web.UI.Page
    {
        public Aceoffix.AceoffixCtrl aceCtrl = new Aceoffix.AceoffixCtrl();
        public string strKey = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString().Trim().Length > 0)
            {
                string id = Request.QueryString["id"].ToString().Trim();
                string strConn = "Data Source=" + Server.MapPath("/App_Data/SaveAndSearch.db");
                string sql = "SELECT * FROM word WHERE id = @id"; 

                try
                {
                    using (SQLiteConnection conn = new SQLiteConnection(strConn))
                    {
                        using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id); 
                            conn.Open();
                            cmd.CommandType = CommandType.Text;

                            using (SQLiteDataReader Reader = cmd.ExecuteReader())
                            {
                                if (Reader.Read())
                                {
                                    string fileName = "";
                                    if (Reader["FileName"] != null && Reader["FileName"].ToString().Length > 0)
                                    {
                                        fileName = Reader["FileName"].ToString().Trim() + ".docx";
                                        aceCtrl.WebOpen(Server.MapPath("doc/") + fileName, Aceoffix.OpenModeType.docNormalEdit, "Tom");
                                    }
                                    else
                                    {
                                        Response.Write("<script>alert('Not FileName');</script>");
                                        return;
                                    }
                                }
                                else
                                {
                                    Response.Write("<script>alert('No record found with the given ID.');</script>");
                                    return;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('An error occurred: {ex.Message}');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Not ID');</script>");
                return;
            }
        }
    }
}
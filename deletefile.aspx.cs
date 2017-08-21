using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System.Configuration;
using System.IO;

public partial class deletefile : System.Web.UI.Page
{
    MySqlConnection con;
    MySqlCommand cmd;

    private void GetConnection()
    {
        string cs = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        con = new MySqlConnection(cs);
        con.Open();
    }

    private void CloseConnection()
    {
        con.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["userid"] != null)
            {
                String userid = Session["userid"].ToString();
                if (Request["filename"] != null || Request["srno"]!=null)
                {                    
                    String filename = Request["filename"];
                    TxtFileName.Text = filename;
                }
                else
                {
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                    LblMsg.Text = "Request error..";
                    return;
                }
            }
            else
            {
                Response.Redirect("~/pagenotfound.aspx");
            }
        }// end if ispostback
    }
    protected void IBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        if (Request["srno"] != null)
        {
            int srno = int.Parse(Request["srno"]);
            String userid = Session["userid"].ToString();
            String sql = "select accesskey from filecloud where srno=@srno";
            GetConnection();
            cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@srno", srno);
            MySqlDataReader rd = cmd.ExecuteReader();
            rd.Read();
            String pkey = rd.GetString("accesskey");
            rd.Dispose();
            rd.Close();
            cmd.Dispose();
            CloseConnection();
            String userkey = TxtKey.Text.Trim();
            if (pkey.Equals(userkey))
            {
                sql = "delete from filecloud where srno=@srno";
                GetConnection();
                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@srno", srno);
                int n = cmd.ExecuteNonQuery();
                cmd.Dispose();
                CloseConnection();
                if (n == 1)
                {
                    String filename = TxtFileName.Text;
                    String fpath = Server.MapPath("~/users/" + userid + "/" + filename);
                    File.Delete(fpath);                    
                    Response.Redirect("~/accessfile.aspx");
                }
                else
                {
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                    LblMsg.Text = "Unable to delete file..";
                    return;
                }
            }
            else
            {
                LblMsg.ForeColor = System.Drawing.Color.Red;
                LblMsg.Text = "Invalid private key..";
            }
        }// end if Request["srno"]!=null
    }// end btndelete_click
}
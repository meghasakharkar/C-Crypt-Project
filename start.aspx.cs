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

public partial class start : System.Web.UI.Page
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

    }
    protected void BtnLogin_Click(object sender, ImageClickEventArgs e)
    {
        if (Page.IsValid)
        {
            String userid = TxtUserid.Text;
            String pwd = TxtPassword.Text;
            if (userid.Equals("admin@admin.com") && pwd.Equals("admin"))
            {
                Session["userid"] = "admin";
                Response.Redirect("~/adminhome.aspx");
            }
            else
            {
                String sql = "select upassword from regusers where emailid = @uid";
                GetConnection();
                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@uid", userid);               
                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    String password = rd.GetString("upassword");
                    rd.Dispose();
                    cmd.Dispose();
                    CloseConnection();
                    if (pwd.Equals(password))
                    {
                        Session["userid"] = userid;
                        Response.Redirect("~/userhome.aspx");
                    }
                    else
                    {
                        LblMsg.ForeColor = System.Drawing.Color.Red;
                        LblMsg.Text = "Invalid userid or password..";
                    }
                }
                else
                {
                    rd.Dispose();
                    cmd.Dispose();
                    CloseConnection();
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                    LblMsg.Text = "Invalid user..";
                }              
            }
        }
        else
        {
            LblMsg.ForeColor = System.Drawing.Color.Red;
            LblMsg.Text = "Validation Failed..";
        }
    }
}
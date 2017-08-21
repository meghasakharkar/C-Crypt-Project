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

public partial class changepwd : System.Web.UI.Page
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
    protected void BtnChangePwd_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                String userid = Session["userid"].ToString();
                String cpwd = TxtCurrentPassword.Text;
                String npwd = TxtNewPassword.Text;
                String sql = "select upassword from regusers where emailid=@userid";
                GetConnection();
                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@userid", userid);
                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    String pwd = rd.GetString("upassword");
                    rd.Dispose();
                    cmd.Dispose();
                    CloseConnection();
                    if (cpwd.Equals(pwd))
                    {
                        sql = "update regusers set upassword=@upwd where emailid=@uid";
                        GetConnection();
                        cmd = new MySqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("@upwd", npwd);
                        cmd.Parameters.AddWithValue("@uid", userid);
                        int n = cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        CloseConnection();
                        if (n == 1)
                        {
                            LblMsg.ForeColor = System.Drawing.Color.Green;
                            LblMsg.Text = "Password changed..";
                        }
                        else
                        {
                            LblMsg.ForeColor = System.Drawing.Color.Red;
                            LblMsg.Text = "Password not changed..";
                        }
                    }
                    else
                    {
                        LblMsg.ForeColor = System.Drawing.Color.Red;
                        LblMsg.Text = "Invalid current password..";
                    }
                }
                else
                {
                    rd.Dispose();
                    cmd.Dispose();
                    CloseConnection();
                }
            }
            catch (Exception ex)
            {
                LblMsg.ForeColor = System.Drawing.Color.Red;
                LblMsg.Text = ex.Message;
            }
        }
        else
        {
            LblMsg.ForeColor = System.Drawing.Color.Red;
            LblMsg.Text = "Validation errors..";
        }
    }
}
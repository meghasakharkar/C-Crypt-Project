using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System.Configuration;
using System.IO;

public partial class users : System.Web.UI.MasterPage
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
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }

        if (Session["userid"] != null)
        {
            String userid = Session["userid"].ToString();
            String sql = "select fullname from regusers where emailid = @uid";
            GetConnection();
            cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@uid", userid);
            MySqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                String fullname = rd.GetString("fullname");
                LblSession.Text = "Welcome " + fullname;
            }
            rd.Dispose();
            cmd.Dispose();
            CloseConnection();
        }
        else
            Response.Redirect("~/pagenotfound.aspx");
    }
    protected void BtnLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        FormsAuthentication.SignOut();
        Response.Redirect("~/start.aspx");
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/savefile.aspx");
    }
    protected void BtnAccess_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/accessfile.aspx");
    }
    protected void BtnEditProfile_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/editprofile.aspx");
    }
    protected void BtnChangePwd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/changepwd.aspx");
    }
    protected void BtnSaveTextFile_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/savetextfile.aspx");
    }
}

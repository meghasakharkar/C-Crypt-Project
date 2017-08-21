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

public partial class editprofile : System.Web.UI.Page
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
            String userid = Session["userid"].ToString();
            String sql = "select fullname, contactno, gender, securityque, answer from regusers where emailid=@uid";
            GetConnection();
            cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@uid", userid);
            MySqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                TxtFName.Text = rd.GetString("fullname");
                TxtContactNo.Text = rd.GetString("contactno");
                String gender = rd.GetString("gender");
                this.DdlGender.SelectedIndex = this.DdlGender.Items.IndexOf(new ListItem(gender, gender));
                String sque = rd.GetString("securityque");
                this.DdlSecQue.SelectedIndex =DdlSecQue.Items.IndexOf(new ListItem(sque, sque));
                TxtAnswer.Text = rd.GetString("answer");
            }
            rd.Dispose();
            rd.Close();
            cmd.Dispose();
            CloseConnection();
        }
    }
    protected void BtnSaveChanges_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                String userid = Session["userid"].ToString();
                String fname, cno="Not Specified", gender="Not Specified", secque="Not Specified", ans="Not Specified";
                fname = TxtFName.Text.ToUpper().Trim();
                if (TxtContactNo.Text.Trim().Length == 10)
                    cno = TxtContactNo.Text.Trim();
                if (DdlGender.SelectedValue != "-1")
                    gender = DdlGender.SelectedItem.Text.ToUpper().Trim();
                if (DdlSecQue.SelectedValue != "-1")
                    secque = DdlSecQue.SelectedItem.Text.ToUpper().Trim();
                if (TxtAnswer.Text.Trim().Length != 0)
                    ans = TxtAnswer.Text.ToUpper().Trim();
                String sql = "update regusers set fullname=@fname, contactno=@cno, gender=@gender, securityque=@sque, answer=@ans where emailid=@uid";
                GetConnection();
                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@fname", fname);
                cmd.Parameters.AddWithValue("@cno", cno);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@sque", secque);
                cmd.Parameters.AddWithValue("@ans", ans);
                cmd.Parameters.AddWithValue("@uid", userid);
                int n = cmd.ExecuteNonQuery();
                cmd.Dispose();
                CloseConnection();
                if (n == 1)
                {
                    LblMsg.ForeColor = System.Drawing.Color.Green;
                    LblMsg.Text = "Changes saved..";
                }
                else
                {
                    LblMsg.ForeColor = System.Drawing.Color.Green;
                    LblMsg.Text = "Changes not saved..";
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
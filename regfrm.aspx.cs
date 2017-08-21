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

public partial class regfrm : System.Web.UI.Page
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
    
    protected void BtnRegister_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                String fname, cno = "Not Specified", gender = "Not Specified", emailid, pwd, secque = "Not Specified", answer = "Not Specified";
                fname = TxtFName.Text.ToUpper().Trim();

                if (TxtContactNo.Text.Trim().Length == 10)
                cno = TxtContactNo.Text.Trim();
                                                   
                if(DdlGender.SelectedValue != "-1")
                gender = DdlGender.SelectedItem.Text.Trim().ToUpper();

                emailid = TxtEmailId.Text.ToLower().Trim();
                pwd = TxtPassword.Text;

                if(DdlSecQue.SelectedValue != "-1")
                secque = DdlSecQue.SelectedItem.Text.Trim().ToUpper();

                if (TxtAnswer.Text.Trim().ToUpper().Length > 0)
                    answer = TxtAnswer.Text.Trim().ToUpper();

                String sql = "insert into regusers values(@fname, @cno, @gender, @emailid, @pwd, @sque, @ans)";
                GetConnection();
                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@fname", fname);
                cmd.Parameters.AddWithValue("@cno", cno);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@emailid", emailid);
                cmd.Parameters.AddWithValue("@pwd", pwd);
                cmd.Parameters.AddWithValue("@sque", secque);
                cmd.Parameters.AddWithValue("@ans", answer);
                int n = cmd.ExecuteNonQuery();
                cmd.Dispose();
                CloseConnection();
                if (n == 1)
                {
                    Directory.CreateDirectory(Server.MapPath("~/users/" + emailid));
                    Response.Redirect("~/success.aspx");
                }
                else
                    Response.Redirect("~/notsuccess.aspx");
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
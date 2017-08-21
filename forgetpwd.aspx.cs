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

using System.Net.Mail;
using System.Net;

public partial class forgetpwd : System.Web.UI.Page
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
   
    protected void BtnSendRequest_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                String userid = TxtUserId.Text.ToLower().Trim();
                String sque = DdlSecurityQuestion.SelectedItem.Text.ToUpper().Trim();
                String ans = TxtAnswer.Text.ToUpper().Trim();
                String sql = "select fullname,upassword,securityque,answer from regusers where emailid=@emailid";
                GetConnection();
                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@emailid", userid);
                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    String fullname = rd.GetString("fullname");
                    String upwd = rd.GetString("upassword");
                    String question = rd.GetString("securityque");
                    String answer = rd.GetString("answer");
                    if (sque.Equals(question) && ans.Equals(answer))
                    {
                        String emailto = userid;
                        String subject = "Returning forget password";
                        String emailbody = "Dear user " + fullname + " your password for cloud computing project is " + upwd;
                        String from = "projecttestsipna@gmail.com";
                        String from_pwd = "projecttestsipna2017";
                        MailMessage mm = new MailMessage(from, emailto,subject,emailbody);
                        mm.IsBodyHtml = false;

                        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = true;

                        NetworkCredential netcred = new NetworkCredential(from,from_pwd);
                        smtp.Credentials = netcred;

                        smtp.Send(mm);
                        LblMsg.ForeColor = System.Drawing.Color.Green;
                        LblMsg.Text = "Dear user "+fullname+" your password is sent to emailid "+userid+"! Thank you..";
                    }
                    else
                    {
                        LblMsg.ForeColor = System.Drawing.Color.Red;
                        LblMsg.Text = "Security question or answer not matched";
                    }
                }
                else
                {
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                    LblMsg.Text = "Invalid userid..";
                }
                rd.Dispose();
                cmd.Dispose();
                CloseConnection();
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        { }
    }    
}
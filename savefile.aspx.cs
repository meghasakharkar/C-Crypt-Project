using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System.Configuration;

using System.Net.Mail;
using System.Net;

public partial class savefile : System.Web.UI.Page
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

    protected void BtnSaveToCloud_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                if (Fupload.HasFile)
                {
                    string filename = Fupload.FileName.ToLower().Trim().Replace(" ", "_");
                    String fileExtension = Path.GetExtension(filename);
                    if (fileExtension == ".txt" || fileExtension == ".bat" || fileExtension == ".exe" || fileExtension == ".mal" || fileExtension == ".vir" || fileExtension == ".smtmp" || fileExtension == ".buk")
                    {
                        LblMsg.ForeColor = System.Drawing.Color.Red;
                        LblMsg.Text = "File not allowed to save on cloud..";
                        return;
                    }
                    else
                    {
                        long fileSize = Fupload.PostedFile.ContentLength;
                        if (fileSize > 1073741824) // 1GB
                        {
                            LblMsg.ForeColor = System.Drawing.Color.Red;
                            LblMsg.Text = "Maximum file size (1GB) exceeded..";
                            return;
                        }
                        else
                        {
                            String userid = Session["userid"].ToString();
                            String fileDescription = TxtFileDescription.Text.ToUpper().Trim();
                            String savedate = DateTime.Today.ToString("dd/MM/yyyy");
                            String dtime = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_tt");
                            filename = dtime + "_" + filename;
                            Random rnd = new Random();
                            String accesskey = rnd.Next(99999).ToString();
                            string msql = "insert into filecloud (emailid, filedescription, filename, savedate, savetime, accesskey) values(@emailid, @filedescription, @filename, @savedate, @savetime, @accesskey )";
                            GetConnection();
                            cmd = new MySqlCommand(msql, con);
                            cmd.Parameters.AddWithValue("@emailid", userid);
                            cmd.Parameters.AddWithValue("@filedescription", fileDescription);
                            cmd.Parameters.AddWithValue("@filename", filename);
                            cmd.Parameters.AddWithValue("@savedate", savedate);
                            cmd.Parameters.AddWithValue("@savetime", dtime);
                            cmd.Parameters.AddWithValue("@accesskey", accesskey);
                            int n = cmd.ExecuteNonQuery();
                            cmd.Dispose();
                            CloseConnection();
                            if (n == 1)
                            {
                                Fupload.SaveAs(Server.MapPath("~/users/" + userid + "/" + filename));
                                String emailto = userid;
                                String subject = "Access key of file "+filename;
                                String emailbody = "Dear user " + userid + ", the access key of file " + filename+" having description "+ fileDescription+" is: "+accesskey;
                                String from = "projecttestsipna@gmail.com";
                                String from_pwd = "projecttestsipna2017";
                                MailMessage mm = new MailMessage(from, emailto, subject, emailbody);
                                mm.IsBodyHtml = false;

                                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                                smtp.EnableSsl = true;
                                smtp.UseDefaultCredentials = true;

                                NetworkCredential netcred = new NetworkCredential(from, from_pwd);
                                smtp.Credentials = netcred;

                                smtp.Send(mm);
                                
                                LblMsg.ForeColor = System.Drawing.Color.Green;
                                LblMsg.Text = "File saved to cloud..";
                            }
                            else
                            {
                                LblMsg.ForeColor = System.Drawing.Color.Red;
                                LblMsg.Text = "Unable to save file to cloud..";
                            }
                        }
                    }
                }
                else
                {
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                    LblMsg.Text = "Please, select a file";
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
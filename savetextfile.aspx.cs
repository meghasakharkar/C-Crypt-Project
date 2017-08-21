using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Security.Cryptography;

using System.Net.Mail;
using System.Net;

using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System.Configuration;

public partial class savetextfile : System.Web.UI.Page
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

    private string EncryptData(string clearText)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    }

    private string DecryptData(string cipherText)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return cipherText;
    }

    protected void BtnSaveToCloud_Click(object sender, EventArgs e)
    {
        if (Fupload.HasFile)
        {
            LblMsg.Text = "";
            String filename = Fupload.FileName.ToLower().Trim().Replace(" ", "_");
            String fileExtension = Path.GetExtension(filename);
            if (fileExtension == ".txt")
            {
                String filepath = Server.MapPath("~/temp/" + filename);
                Fupload.SaveAs(filepath);
                String oriData = File.ReadAllText(filepath);
                System.IO.File.Delete(filepath);
                TxtOriginal.Text = oriData;
                TxtEncrypted.Text = EncryptData(oriData);
                TxtDecrypt.Text = DecryptData(TxtEncrypted.Text);

                String savedate = DateTime.Today.ToString("dd/MM/yyyy");
                String dtime = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_tt");
                String dfilename = dtime + "_" + filename;
                Random rnd = new Random();
                String accesskey = rnd.Next(99999).ToString();
                String userid = Session["userid"].ToString();

                String dfilepath = Server.MapPath("~/users/" + userid + "/" + dfilename);
                System.IO.File.WriteAllText(dfilepath, TxtEncrypted.Text);

                String fileDescription = TxtFileDescription.Text.ToUpper().Trim();
                string msql = "insert into filecloud (emailid, filedescription, filename, savedate, savetime, accesskey) values(@emailid, @filedescription, @filename, @savedate, @savetime, @accesskey )";
                GetConnection();
                cmd = new MySqlCommand(msql, con);
                cmd.Parameters.AddWithValue("@emailid", userid);
                cmd.Parameters.AddWithValue("@filedescription", fileDescription);
                cmd.Parameters.AddWithValue("@filename", dfilename);
                cmd.Parameters.AddWithValue("@savedate", savedate);
                cmd.Parameters.AddWithValue("@savetime", dtime);
                cmd.Parameters.AddWithValue("@accesskey", accesskey);
                int n = cmd.ExecuteNonQuery();
                cmd.Dispose();
                CloseConnection();
                if (n == 1)
                {
                    String emailto = userid;
                    String subject = "Access key of file "+dfilename;
                    String emailbody = "Dear user " + userid + ", the access key of file " + dfilename + " having description " + fileDescription + " is: " + accesskey;
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
            else
            {
                LblMsg.ForeColor = System.Drawing.Color.Red;
                LblMsg.Text = "Invalid text file..";
            }
        }
        else
        {
            LblMsg.ForeColor = System.Drawing.Color.Red;
            LblMsg.Text = "Please select a file to upload";
        }// end if hasFile
    }
}
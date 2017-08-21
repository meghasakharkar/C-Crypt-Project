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
using System.Text;
using System.Security.Cryptography;

public partial class downloadfile : System.Web.UI.Page
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["userid"] != null)
            {
                String userid = Session["userid"].ToString();
                if (Request["filename"] != null)
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

    protected void IBtnDownload_Click(object sender, ImageClickEventArgs e)
    {
        if (Page.IsValid)
        {
            if (Session["userid"] != null)
            {
                String userid = Session["userid"].ToString();
                
                String filename = TxtFileName.Text;
                String sql = "select accesskey from filecloud where emailid=@userid and filename=@filename";
                GetConnection();
                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@userid", userid);
                cmd.Parameters.AddWithValue("@filename", filename);
                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    String pkey = rd.GetString("accesskey");
                    rd.Dispose();
                    rd.Close();
                    cmd.Dispose();
                    CloseConnection();
                    // LblMsg.Text = pkey;
                    String userkey = TxtKey.Text.Trim();
                    TxtKey.Text = "";
                    if (pkey.Equals(userkey))
                    {
                        String fileextension = Path.GetExtension(filename);
                        if (fileextension == ".txt")
                        {
                            String fpath = Server.MapPath("~/users/" + userid + "/" + filename);
                            String decryptedData = File.ReadAllText(fpath);
                            String originaldata = DecryptData(decryptedData);
                            String temppath = Server.MapPath("~/temp/" + filename);
                            System.IO.File.WriteAllText(temppath, originaldata);
                            FileInfo f = new FileInfo(temppath);
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment;filename=" + temppath);
                            Response.AddHeader("Content-Length", f.Length.ToString());
                            Response.ContentType = "application/octet-stream";
                            Response.WriteFile(f.FullName);
                            //System.IO.File.Delete(temppath);
                            Response.End();                            
                        }
                        else
                        {
                            String fpath = Server.MapPath("~/users/" + userid + "/" + filename);
                            FileInfo f = new FileInfo(fpath);
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment;filename=" + fpath);
                            Response.AddHeader("Content-Length", f.Length.ToString());
                            Response.ContentType = "application/octet-stream";
                            Response.WriteFile(f.FullName);
                            Response.End();
                        }
                    }
                    else
                    {
                        LblMsg.ForeColor = System.Drawing.Color.Red;
                        LblMsg.Text = "Invalid private key..";
                    }
                 }
                 else
                 {
                     rd.Dispose();
                     rd.Close();
                     cmd.Dispose();
                     CloseConnection();
                     LblMsg.ForeColor = System.Drawing.Color.Red;
                     LblMsg.Text = "Private key not available in the database";
                     return;
                 }                
            }
            else
            Response.Redirect("~/pagenotfound.aspx");            
        }
        else
        {
            LblMsg.ForeColor = System.Drawing.Color.Red;
            LblMsg.Text = "Validation failed..";
        }
    }
}
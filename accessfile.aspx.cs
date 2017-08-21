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

public partial class accessfile : System.Web.UI.Page
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
                Table1.Rows.Clear();
                TableRow tr = null;
                TableCell tc = null;
                String[] captions = { "File Description", "File Name", "Save Date", "Download", "Delete" };
                tr = new TableRow();
                for (int i = 0; i < captions.Length; i++)
                {
                    tc = new TableCell();
                    tc.BackColor = System.Drawing.Color.Teal;
                    tc.ForeColor = System.Drawing.Color.White;
                    tc.Height = 50;
                    tc.Font.Bold = true;
                    tc.Text = captions[i];
                    tr.Cells.Add(tc);
                }
                Table1.Rows.Add(tr);

                String userid = Session["userid"].ToString();
                String sql = "select srno,filedescription,filename,savedate from filecloud where emailid=@userid";
                GetConnection();
                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@userid", userid);
                MySqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    int srno = rd.GetInt32("srno");
                    String fd = rd.GetString("filedescription");
                    String fname = rd.GetString("filename");                    
                    String sd = rd.GetString("savedate");

                    tr = new TableRow();
                    tc = new TableCell();
                    tc.Text = fd;
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.Text = fname;
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.Text = sd;
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.Text = "<a href=\"downloadfile.aspx?filename=" + fname + "\">Download</a>";
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.Text = "<a href=deletefile.aspx?srno=" + srno + "&filename="+fname+">Delete</a>";
                    tr.Cells.Add(tc);

                    Table1.Rows.Add(tr);
                }
                rd.Dispose();
                rd.Close();
                cmd.Dispose();
                CloseConnection();
            }
            else
            {
                Response.Redirect("~/pagenotfound.aspx");
            }
        }// end if ispostback
    }
}
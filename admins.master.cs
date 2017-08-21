using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class admins : System.Web.UI.MasterPage
{
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
            LblSession.Text = "Welcome Administrator";
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

    protected void BtnRegUsers_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/regusers.aspx");
    }
}

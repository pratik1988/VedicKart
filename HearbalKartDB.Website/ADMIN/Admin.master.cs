using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ADMIN_Admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] != null)
        {
            LblUserNme.Text = Session["UserName"].ToString();
            LblDttime.Text = DateTime.Now.ToString("F");
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
    }
    protected void lnkclearecache_Click(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
    }
}

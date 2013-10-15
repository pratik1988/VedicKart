#region Using Directives
using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HearbalKartDB.Data;
using HearbalKartDB.Entities;
using HearbalKart.Business.Classes;
using System.Linq;
using System.IO;
using System.Web.UI.WebControls;
#endregion

public partial class Mainmaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        UserControls_HOME_Header ctrl2 = new UserControls_HOME_Header();
        if (Request.Url.AbsolutePath.Contains("Home.aspx") || Request.Url.AbsolutePath.Contains("home.aspx"))
        {
            ctrl2 = (UserControls_HOME_Header)Page.Master.Master.FindControl("Header");
        }
        else if (Request.Url.AbsolutePath.Contains("CategoryProducts.aspx") || Request.Url.AbsolutePath.Contains("categoryproducts.aspx"))
        {
            ctrl2 = (UserControls_HOME_Header)Page.Master.FindControl("Header");
        }
        else if (Request.Url.AbsolutePath.Contains("ControlPanel.aspx") || Request.Url.AbsolutePath.Contains("controlpanel.aspx"))
        {
            ctrl2 = (UserControls_HOME_Header)Page.Master.Master.FindControl("Header");
        }
        List<ProdTable> objprod4cart = new List<ProdTable>();
        if (Session["cart"] != null)
        {
            objprod4cart = (List<ProdTable>)Session["cart"];
            ctrl2.Cartitemtext(objprod4cart.Count().ToString());
            Session["itmno"] = objprod4cart.Count().ToString();
        }
        else
        {
            ctrl2.Cartitemtext("0");
            Session["itmno"] = "0";
        }
    }
}

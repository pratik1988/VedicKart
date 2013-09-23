#region Using Directives
using System;
using System.Data;
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
#endregion

public partial class ADMIN_DashBoard : System.Web.UI.Page
{
    TList<Orders> objorders = new TList<Orders>();
    Order objorderclass = new Order();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] != null)
        {
            BindAllGrid();
        }
    }

    private void BindAllGrid()
    {
        objorders = objorderclass.GetAllOrders();
        grdOrdtotal.DataSource = objorders;
        grdOrdtotal.DataBind();
    }

    protected void grdstaff_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
}
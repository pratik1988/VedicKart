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

public partial class ADMIN_ProductDashBoard : System.Web.UI.Page
{
    Product ObjprodClass = new Product();
    TList<ProdCategory> objprodctgList = new TList<ProdCategory>();
    ProdCategory objprodctg = new ProdCategory();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }
   
}
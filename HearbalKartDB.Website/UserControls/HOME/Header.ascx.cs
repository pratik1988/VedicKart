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
using System.Collections.Generic;
#endregion

public partial class UserControls_HOME_Header : System.Web.UI.UserControl
{
    Product ObjprodClass = new Product();
    TList<ProdCategory> objprodctglist = new TList<ProdCategory>();
    TList<ProdSubcategory> objprodsubctglist = new TList<ProdSubcategory>();
    TList<ProdCategoryMapping> objprodctgmappinglist = new TList<ProdCategoryMapping>();
    ProdSubcategory objprodctg = new ProdSubcategory();
    ProdCategory objprodmainctg = new ProdCategory();
    string Status;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCtgRtp();
        }
    }
    public void Cartitemtext(string text)
    {
        txtcartitm.Text = text;
    }
    #region Custom Methods
    public void BindCtgRtp()
    {
        objprodctglist = ObjprodClass.GetAllProdCategories();
        rptmnctg.DataSource = objprodctglist;
        rptmnctg.DataBind();
        
    }
    #endregion
    #region DataBound
    protected void rptmnctg_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ProdCategory objproddtabound = e.Item.DataItem as ProdCategory;
            LinkButton lnkmainCTG = (LinkButton)e.Item.FindControl("lnkmainCTG");
            Repeater rptsubctg = (Repeater)e.Item.FindControl("rptsubctg");
            TList<ProdSubcategory> objprodsubctglist1 = new TList<ProdSubcategory>();
            List<int> objsubctgID = new List<int>();
            objsubctgID = ObjprodClass.GetAllProdmapBymainCtgID(objproddtabound.Id);
            if (objsubctgID != null)
            {
                foreach (int a in objsubctgID)
                {
                    objprodctg = null;
                    objprodctg = ObjprodClass.GetProdSubcategoryByID(a);
                    objprodsubctglist1.Add(objprodctg);
                }
            }
            rptsubctg.DataSource = objprodsubctglist1;
            rptsubctg.DataBind();
            lnkmainCTG.Text = objproddtabound.Name;
        }
    }
    #endregion
    protected void btnSubmitLgn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx", false);

    }

    protected void rptsubctg_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ProdSubcategory objprodsubctgbound = e.Item.DataItem as ProdSubcategory;
            LinkButton lnksubctg = (LinkButton)e.Item.FindControl("lnksubctg");
            lnksubctg.Text = objprodsubctgbound.SubCategoryName;

        }
    }
}
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
#endregion

public partial class Home : System.Web.UI.Page
{
    #region Pageload
    TList<ProdTable> objprodtablelist = new TList<ProdTable>();
    IEnumerable<ProdTable> objenumprodtable;
    CategoryProd objctgprodclass = new CategoryProd();
    TList<ProdCategory> objprodctg = new TList<ProdCategory>();
    Items objitem = new Items();
    Product ObjprodClass = new Product();
    ItemSell objitemsell = new ItemSell();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindprodTable();
        }
    }
    #endregion

    #region BindDatalist
    private void BindprodTable()
    {
        objprodctg = ObjprodClass.GetAllProdCategories();
        if (objprodctg != null)
        {
            rptctg.DataSource = objprodctg;
            rptctg.DataBind();
        }
        objprodtablelist = objctgprodclass.GetproductsByCtgID((int)CategoryTypes.Liquid);
        if (objprodtablelist != null)
        {
            //rptctglqd.DataSource = objprodtablelist;
            //rptctglqd.DataBind();
            
        }
        objprodtablelist = null;
        objprodtablelist = objctgprodclass.GetproductsByCtgID((int)CategoryTypes.Solid);
        if (objprodtablelist != null)
        {
            //rptctgsolid.DataSource = objprodtablelist;
            //rptctgsolid.DataBind();
        }
    }
    #endregion


    #region DataList Databound
    protected void rptctglqd_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ProdTable Prod = e.Item.DataItem as ProdTable;
            HyperLink lnkProdLqdName = (HyperLink)e.Item.FindControl("lnkProdLqdName");
            Label lblLqdprodSum = (Label)e.Item.FindControl("lblLqdprodSum");
            Image IMGLqdProd = (Image)e.Item.FindControl("IMGLqdProd");
            if (Prod != null)
            {
                objitem = null;
                objitem = ObjprodClass.GetItemsByID(Convert.ToInt32(Prod.ItemId));
                objitemsell = ObjprodClass.GetItemsellByID(Convert.ToInt32(Prod.SellId));
                lnkProdLqdName.Text = objitem.ItemName;
                IMGLqdProd.ImageUrl = Prod.ImageUrl;
                lblLqdprodSum.Text = objitemsell.Cost;
            }
        }
    }
    #endregion

    protected void rptctg_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ProdCategory Prod = e.Item.DataItem as ProdCategory;
            LinkButton lnkCtgName = (LinkButton)e.Item.FindControl("lnkCtgName");
            DataList rptctglqd = (DataList)e.Item.FindControl("rptctglqd");
            IEnumerable<int> objprodsubCtg;
            objprodsubCtg = ObjprodClass.GetAllProdmapBymainCtgID(Prod.Id);
            if (objprodsubCtg != null)
            {
                objenumprodtable = objctgprodclass.GetproductsByCtgID(objprodsubCtg);
                if (objenumprodtable != null)
                {
                    rptctglqd.DataSource = objenumprodtable;
                    rptctglqd.DataBind();
                }
            }
            
            lnkCtgName.Text = Prod.Name;
        }
    }
    protected void lnkCtgName_Click(object sender, EventArgs e)
    {
        Session["CTGID"] = null;
        Session["ProdSubCTG"] = null;
        LinkButton lnk = (LinkButton)sender;
        int CTGID = Convert.ToInt32(lnk.CommandArgument);
        IEnumerable<int> objprodsubCtg;
        objprodsubCtg = ObjprodClass.GetAllProdmapBymainCtgID(CTGID);
        Session["CTGID"] = CTGID;
        Session["ProdSubCTG"] = objprodsubCtg;
        if ((Session["CTGID"] != null) && (Session["ProdSubCTG"] != null))
        {
            Response.Redirect("~/CategoryProducts.aspx", false);
        }
    }
}
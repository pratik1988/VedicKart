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

public partial class Home : System.Web.UI.Page
{
    #region Pageload
    TList<ProdTable> objprodtablelist = new TList<ProdTable>();
    ProdTable objprod = new ProdTable();
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
            LinkButton addcartID = (LinkButton)e.Item.FindControl("addcartID");
            if (Prod != null)
            {
                objitem = null;
                objitem = ObjprodClass.GetItemsByID(Convert.ToInt32(Prod.ItemId));
                objitemsell = ObjprodClass.GetItemsellByID(Convert.ToInt32(Prod.SellId));
                lnkProdLqdName.Text = objitem.ItemName;
                //IMGLqdProd.ImageUrl = Prod.ImageUrl;
                addcartID.CommandArgument = Convert.ToString(Prod.Id);
                lblLqdprodSum.Text = objitemsell.Cost;
            }
        }
    }


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
    #endregion

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
            Response.Redirect("~/CategoryProducts.aspx", true);
        }
    }

    #region DataList ItmCommand
    protected void rptctglqd_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "addtocart")
        {
            UserControls_HOME_Header ctrl2 = (UserControls_HOME_Header)Page.Master.Master.FindControl("Header");
            UserControls_HOME_Cart ct = (UserControls_HOME_Cart)ctrl2.FindControl("cartprod");
            DataList gv = ct.Dlst;
            List<ProdTable> objprod4cart = new List<ProdTable>();
            objprod = ObjprodClass.GetProdByID(Convert.ToInt32(e.CommandArgument));
            if (Session["cart"] != null)
            {
                int val = 0;
                objprod4cart = (List<ProdTable>)Session["cart"];
                if (objprod != null)
                {
                    foreach (var item in objprod4cart)
                    {
                        if (item.Id == objprod.Id)
                        {
                            val = 1;
                        }
                    }
                    if (val != 1)
                    {
                        Session["cart"] = null;
                        objprod4cart.Add(objprod);
                        Session["cart"] = objprod4cart;
                        ct.CartDivdisplay(true);
                    }
                }
            }
            else
            {
                Session["cart"] = objprod4cart;
                ct.CartDivdisplay(true);
                objprod4cart.Add(objprod);

            }
            ct.ttlcost(0);
            gv.DataSource = objprod4cart;
            ctrl2.Cartitemtext(objprod4cart.Count().ToString());
            ct.Cartitems(objprod4cart.Count().ToString());
            ct.ttlitems(objprod4cart.Count.ToString());
            gv.DataBind();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowCart('true');});", true);
        }

    }

    #endregion
}
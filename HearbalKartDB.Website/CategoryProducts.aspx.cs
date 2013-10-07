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


public partial class CategoryProducts : System.Web.UI.Page
{
    #region Pageload
    TList<ProdTable> objprodtablelist = new TList<ProdTable>();
    IEnumerable<ProdTable> objenumprodtable;
    CategoryProd objctgprodclass = new CategoryProd();
    TList<ProdCategory> objprodctglist = new TList<ProdCategory>();
    ProdCategory objprodctg = new ProdCategory();
    Items objitem = new Items();
    Product ObjprodClass = new Product();
    ItemSell objitemsell = new ItemSell();
    ItemPurchase objitempurchase = new ItemPurchase();
    List<int> objbrandID = new List<int>();
    List<int> objpriceID = new List<int>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["CTGID"] != null)
            {
                BindRepeater();
            }
            else
            {
                Response.Redirect("~/Home.aspx", false);
            }
        }
    }
    #endregion

    #region Bind Repeater
    private void BindRepeater()
    {
        objprodctg = ObjprodClass.GetProdcategoryByID(Convert.ToInt32(Session["CTGID"]));
        if (objprodctg != null)
        {
            prodCtgName.Text = objprodctg.Name;
            IEnumerable<int> objprodsubCtg;
            objprodsubCtg = ObjprodClass.GetAllProdmapBymainCtgID(objprodctg.Id);
            if (objprodsubCtg != null)
            {
                objenumprodtable = objctgprodclass.GetproductsByCtgID(objprodsubCtg);
                if (objenumprodtable != null)
                {
                    rptProdByctg.DataSource = objenumprodtable;
                    rptProdByctg.DataBind();
                    TtlProds.Text = objenumprodtable.Count() + " Products";
                }
            }
            List<Product> objp = new List<Product>();
            objp = Product.AddValuesToDataList();
            MnuDtlst.DataSource = objp;
            MnuDtlst.DataBind();
        }
        else
        {
            Response.Redirect("~/Home.aspx", false);
        }
    }
    #endregion

    protected void rptProdByctg_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ProdTable Prod = e.Item.DataItem as ProdTable;
            LinkButton lnkprodName = (LinkButton)e.Item.FindControl("lnkprodName");
            Image prodImgCtg = (Image)e.Item.FindControl("prodImgCtg");
            Label lblitmsell = (Label)e.Item.FindControl("lblitmsell");
            Label lblitmpurchase = (Label)e.Item.FindControl("lblitmpurchase");
            objitem = null;
            objitem = ObjprodClass.GetItemsByID(Convert.ToInt32(Prod.ItemId));
            objitemsell = ObjprodClass.GetItemsellByID(Convert.ToInt32(Prod.SellId));
            objitempurchase = ObjprodClass.GetItempurchaseByID(Convert.ToInt32(Prod.PurchaseId));
            objbrandID.Add(Convert.ToInt32(Prod.CompanyId));
            lnkprodName.Text = objitem.ItemName;
            prodImgCtg.ImageUrl = Prod.ImageUrl;
            lblitmsell.Text = objitemsell.Cost;
            lblitmpurchase.Text = objitempurchase.Cost.ToString();
        }
    }
    protected void MnuDtlst_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Product Prod = e.Item.DataItem as Product;
            Label lblmnuheader = (Label)e.Item.FindControl("lblmnuheader");
            DataList MnuDlstsub = (DataList)e.Item.FindControl("MnuDlstsub");
            lblmnuheader.Text = Prod.Name.ToString();
            switch (Prod.ID)
            {
                case 1:
                    IEnumerable<ProdCompany> objprodcomp;
                    objprodcomp = objctgprodclass.GetCompanyByID(objbrandID);
                    MnuDlstsub.DataSource = objprodcomp;
                    MnuDlstsub.DataBind();
                    break;
                case 2:
                    break;
            }
        }
    }
    protected void MnuDlstsub_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ProdCompany Prod = e.Item.DataItem as ProdCompany;
            HyperLink Hyperlnk = (HyperLink)e.Item.FindControl("Hyperlnk");
            Hyperlnk.Text = Prod.CompanyName;
        }
    }
}
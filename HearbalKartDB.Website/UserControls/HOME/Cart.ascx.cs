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

public partial class UserControls_HOME_Cart : System.Web.UI.UserControl
{
    Product ObjprodClass = new Product();
    Items objitem = new Items();
    ItemSell objitemsell = new ItemSell();
    List<ProdTable> objprod4cart = new List<ProdTable>();
    string Status;
    int itmttl = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["cart"] != null)
            {

                emptycart.Style.Add("display", "none");
                fillcart.Style.Add("display", "block");
                Bindcart();

            }
            else
            {
                emptycart.Style.Add("display", "block");
                fillcart.Style.Add("display", "none");
            }
        }
        hrdttlitems.Text = Session["itmno"].ToString();

    }
    public void CartDivdisplay(bool val)
    {
        if (val == true)
        {
            emptycart.Style.Add("display", "none");
            fillcart.Style.Add("display", "block");
        }
        else
        {
            emptycart.Style.Add("display", "block");
            fillcart.Style.Add("display", "none");
        }
    }
    public void Bindcart()
    {
        if (Session["cart"] != null)
        {
            itmttl = 0;
            objprod4cart = (List<ProdTable>)Session["cart"];
            emptycart.Style.Add("display", "none");
            fillcart.Style.Add("display", "block");
            cartttlitemsres.Text = objprod4cart.Count.ToString();
            dlstcartlist.DataSource = objprod4cart;
            dlstcartlist.DataBind();
            
        }
        else
        {
            itmttl = 0;
            emptycart.Style.Add("display", "block");
            fillcart.Style.Add("display", "none");
            cartttlitemsres.Text = "0";
        }
    }
    public void Cartitems(string text)
    {
        hrdttlitems.Text = text;
        Session["itmno"] = text;
    }
    public void ttlitems(string text)
    {
        cartttlitemsres.Text = text;
    }
    public void ttlcost(int val)
    {
        itmttl = val;
    }
    public DataList Dlst
    {

        get
        {
            return this.dlstcartlist;

        }

    }
    protected void dlstcartlist_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ProdTable objprodcart = e.Item.DataItem as ProdTable;
            Image imgcart = (Image)e.Item.FindControl("imgcart");
            Label lblitmname = (Label)e.Item.FindControl("lblitmname");
            Label itmcost = (Label)e.Item.FindControl("itmcost");
            Label lblttlcost = (Label)e.Item.FindControl("lblttlcost");
            LinkButton imgremove = (LinkButton)e.Item.FindControl("imgremove");

            objitem = null;
            objitem = ObjprodClass.GetItemsByID(Convert.ToInt32(objprodcart.ItemId));
            {
                objitemsell = ObjprodClass.GetItemsellByID(Convert.ToInt32(objprodcart.SellId));
                lblitmname.Text = objitem.ItemName.ToString().Trim();
                imgcart.ImageUrl = objprodcart.ImageUrl;
                itmcost.Text = objitemsell.Cost.ToString().Trim();
                lblttlcost.Text = objitemsell.Cost.ToString().Trim();
                imgremove.CommandArgument = Convert.ToString(objprodcart.Id);
                if (itmttl == 0)
                {
                    itmttl = Convert.ToInt32(lblttlcost.Text);
                }
                else
                {
                    itmttl =itmttl + Convert.ToInt32(lblttlcost.Text);
                }
                lblttlamnt.Text = itmttl.ToString();
            }
        }
    }
    protected void dlstcartlist_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            if (Session["cart"] != null)
            {
                objprod4cart = null;
                objprod4cart = (List<ProdTable>)Session["cart"];
                objprod4cart.RemoveAll(x => x.Id == Convert.ToInt32(e.CommandArgument));
                Session["cart"] = objprod4cart;
                string prodcount;
                prodcount = objprod4cart.Count.ToString();
                if (prodcount == "0")
                {
                    emptycart.Style.Add("display", "block");
                    fillcart.Style.Add("display", "none");
                    Session["cart"] = null;
                    itmttl = 0;
                }
                else
                {
                    emptycart.Style.Add("display", "none");
                    fillcart.Style.Add("display", "block");
                }
                
                ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowCart('true');});", true);
                //UserControls_HOME_Cart c = (UserControls_HOME_Cart)this.Parent;
                //c.Cartitems(objprod4cart.Count.ToString());
                hrdttlitems.Text = prodcount;
                Label parnttxtcartitm = (Label)(this.Parent.FindControl("txtcartitm"));
                parnttxtcartitm.Text = prodcount;
                Bindcart();
                lblttlamnt.Text = itmttl.ToString();
            }
        }
    }
}
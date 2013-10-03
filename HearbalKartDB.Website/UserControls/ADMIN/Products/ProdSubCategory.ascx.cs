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

public partial class UserControls_ADMIN_Products_ProdSubCategory : System.Web.UI.UserControl
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
            errorpopheaderprodsubctg.Style.Add("display", "none");
            errorpopheaderprodsubctg.Attributes.Add("class", "fk-err-all");
            if (Session["UserName"] != null)
            {
                bindGrid();
            }
        }
    }

    #region Custom Methods
    private void bindGrid()
    {
        objprodsubctglist = ObjprodClass.GetAllProdSubCategories();
        grdprodsubctg.DataSource = objprodsubctglist;
        grdprodsubctg.DataBind();
    }
    private void bindlistitems()
    {
        objprodctglist = ObjprodClass.GetAllProdCategories();
        lstprntctg.DataSource = objprodctglist;
        lstprntctg.DataTextField = "Name";
        lstprntctg.DataValueField = "ID";
        lstprntctg.DataBind();
    }
    #endregion
    #region Row DataBound
    protected void grdprodsubctg_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
        {
            try
            {
                GridViewRow gr = e.Row;
                Label lblCategoryname = (Label)gr.FindControl("lblCategoryname");
                Label lblProdparentctg = (Label)gr.FindControl("lblProdparentctg");
                HiddenField HDFID = (HiddenField)gr.FindControl("HDFProdsubctgID");
                ImageButton IMGBTNProdsubCTGisActive = (ImageButton)gr.FindControl("IMGBTNProdsubCTGisActive");
                ProdSubcategory u = e.Row.DataItem as ProdSubcategory;
                objprodctgmappinglist = ObjprodClass.GetAllProdCategoriesmapping(u.Id);
                string name = null;
                if (objprodctgmappinglist != null)
                {
                    name = null;
                    foreach (var r in objprodctgmappinglist)
                    {
                        objprodmainctg = ObjprodClass.GetProdcategoryByID( Convert.ToInt32(r.CategoryId));
                        if (name != null)
                        {
                            name = name + "," + objprodmainctg.Name;
                        }
                        else
                        {
                            name = objprodmainctg.Name;
                        }
                    }
                }
                lblCategoryname.Text = u.SubCategoryName.Trim().ToString();
                HDFID.Value = u.Id.ToString();
                lblProdparentctg.Text = name.ToString();
                if (u.IsActive == true)
                {
                    IMGBTNProdsubCTGisActive.ImageUrl = "~/images/tick.png";
                }
                else
                    IMGBTNProdsubCTGisActive.ImageUrl = "~/images/close.jpg";
            }
            catch
            {
            }
        }
    }
    #endregion
    protected void btnSubmit_Click1(object sender, EventArgs e)
    {
        string categoryname = TXTprodsubctg.Text;
        if (categoryname != null)
        {
            objprodctg.SubCategoryName = categoryname.ToString();
            objprodctg.CreatedDate = DateTime.Now;

            List<int> objID = new List<int>();
            switch (btnSubmitprodsubctg.Text.Trim())
            {
                case "Submit":
                    ViewState["popupID"] = null;
                    foreach (ListItem item in lstprntctg.Items)
                    {

                        if (item.Selected)
                        {

                            try
                            {
                                objID.Add(Convert.ToInt32(item.Value));
                            }
                            catch
                            {

                            }
                        }
                    }
                    Status = ObjprodClass.insertProdSubCategory(objprodctg, objID);
                    if (Status == "Information Insert successfully.")
                    {
                        errorpopheaderprodsubctg.Visible = true;
                        errorpopheaderprodsubctg.Style.Add("display", "block");
                        errorpopheaderprodsubctg.Attributes.Add("class", "fk-msg-success");
                        errorpopheaderprodsubctg.InnerHtml = "ProductSubcategory Inserted successfully";
                        bindGrid();
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPprodsubctg('false');});", true);
                    }
                    else
                    {
                        errorpopheaderprodsubctg.Visible = true;
                        errorpopheaderprodsubctg.Style.Add("display", "block");
                        errorpopheaderprodsubctg.Attributes.Add("class", "fk-err-all");
                        errorpopheaderprodsubctg.InnerHtml = Status;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPprodsubctg('false');});", true);
                    }
                    break;
                case "Update":
                    if (ViewState["popupID"] != null && ViewState["popupID"] != "")
                    {
                        List<int> objID1 = new List<int>();
                        objprodctg = null;
                        objprodctg = ObjprodClass.GetProdSubcategoryByID(Convert.ToInt32(ViewState["popupID"]));
                        foreach (ListItem item in lstprntctg.Items)
                        {

                            if (item.Selected)
                            {

                                try
                                {
                                    objID1.Add(Convert.ToInt32(item.Value));
                                }
                                catch
                                {

                                }
                            }
                        }
                        objprodctg.SubCategoryName = categoryname.ToString();
                        Status = ObjprodClass.UpdateProdSubCategory(objprodctg, objID1);
                        if (Status == "Information Update successfully.")
                        {
                            errorpopheaderprodsubctg.Visible = true;
                            errorpopheaderprodsubctg.Style.Add("display", "block");
                            errorpopheaderprodsubctg.Attributes.Add("class", "fk-msg-success");
                            errorpopheaderprodsubctg.InnerHtml = "ProductSubcategory Updated successfully";
                            bindGrid();
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPupdateprodsubctg('true');});", true);
                        }
                        else
                        {
                            errorpopheaderprodsubctg.Visible = true;
                            errorpopheaderprodsubctg.Style.Add("display", "block");
                            errorpopheaderprodsubctg.Attributes.Add("class", "fk-err-all");
                            errorpopheaderprodsubctg.InnerHtml = Status;
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPupdateprodsubctg('true');});", true);
                        }
                    }
                    break;
            }


        }
    }
    protected void lnkAddNewSubctg_Click(object sender, EventArgs e)
    {
        btnSubmitprodsubctg.Text = "Submit";
        errorpopheaderprodsubctg.Style.Add("display", "none");
        bindlistitems();
        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPprodsubctg('true');});", true);
    }

    protected void IMGBTNProdsubCTGisActive_Click(object sender, ImageClickEventArgs e)
    {
        bindlistitems();
        ImageButton lnk = (ImageButton)sender;
        int userid = Convert.ToInt32(lnk.CommandArgument);
        objprodctg = null;
        objprodctg = ObjprodClass.GetProdSubcategoryByID(userid);
        objprodctgmappinglist = ObjprodClass.GetAllProdCategoriesmapping(userid);
        foreach (var r in objprodctgmappinglist)
        {
            lstprntctg.SelectionMode = ListSelectionMode.Multiple;
            for (int i = 0; i < lstprntctg.Items.Count; i++)
            {
                if (lstprntctg.Items[i].Value==r.CategoryId.ToString())
                {
                    int j = i;
                    lstprntctg.Items[j].Selected = true;
                }
            }
        }
        if (objprodctg != null)
        {
            TXTprodsubctg.Text = objprodctg.SubCategoryName;
            errorpopheaderprodsubctg.Style.Add("display", "none");
            btnSubmitprodsubctg.Text = "Update";
            ViewState["popupID"] = userid.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPupdateprodsubctg('true');});", true);
        }
    }
}
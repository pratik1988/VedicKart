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

public partial class UserControls_ADMIN_Products_ProdSupplement : System.Web.UI.UserControl
{
    Product ObjprodClass = new Product();
    TList<ProdSupplymentType> objprodctgList = new TList<ProdSupplymentType>();
    ProdSupplymentType objprodctg = new ProdSupplymentType();
    string Status;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            errorpopheadersuppli.Style.Add("display", "none");
            errorpopheadersuppli.Attributes.Add("class", "fk-err-all");
            if (Session["UserName"] != null)
            {
                BindProdCategoryGrid();
            }
        }
    }

    #region Custom Methods
    private void BindProdCategoryGrid()
    {
        objprodctgList = ObjprodClass.GetAllProdSupplyment();
        grdprodsupplementfor.DataSource = objprodctgList;
        grdprodsupplementfor.DataBind();
    }
    #endregion

    #region Row DataBound
    protected void grdprodsupplementfor_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
        {
            try
            {
                GridViewRow gr = e.Row;
                Label lblCategoryname = (Label)gr.FindControl("lblSupplementname");
                HiddenField HDFID = (HiddenField)gr.FindControl("HDFsupplementID");
                ImageButton IMGBTNcategoryisActive = (ImageButton)gr.FindControl("IMGBTNSupplementeisActive");
                ProdSupplymentType u = e.Row.DataItem as ProdSupplymentType;
                lblCategoryname.Text = u.Name.Trim().ToString();
                HDFID.Value = u.Id.ToString();
                if (u.IsActive == true)
                {
                    IMGBTNcategoryisActive.ImageUrl = "~/images/tick.png";
                }
                else
                    IMGBTNcategoryisActive.ImageUrl = "~/images/close.jpg";
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
    #endregion

    #region Link Active OR Deactive
    protected void IMGBTNcategoryisActive_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton lnk = (ImageButton)sender;
        int userid = Convert.ToInt32(lnk.CommandArgument);
        objprodctg = null;
        objprodctg = ObjprodClass.GetProdsupplymentByID(userid);
        if (objprodctg != null)
        {
            if (objprodctg.IsActive == true)
                ChkIsActivesupply.Checked = true;
            TXTsupplyment.Text = objprodctg.Name;
            errorpopheadersuppli.Style.Add("display", "none");
            DIVIsActive.Style.Add("display", "block");
            btnSubmitsupply.Text = "Update";
            ViewState["popupID"] = userid.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPSupplyUpdate('true');});", true);
        }
    }
    #endregion

    protected void btnSubmit_Click1(object sender, EventArgs e)
    {
        string categoryname = TXTsupplyment.Text;
        if (categoryname != null)
        {
            objprodctg.Name = categoryname.ToString();
            objprodctg.CreatedDate = DateTime.Now;
            switch (btnSubmitsupply.Text.Trim())
            {
                case "Submit":
                    ViewState["popupID"] = null;
                    Status = ObjprodClass.insertProdSupplymentType(objprodctg);
                    if (Status == "Information Insert successfully.")
                    {
                        errorpopheadersuppli.Visible = true;
                        errorpopheadersuppli.Style.Add("display", "block");
                        errorpopheadersuppli.Attributes.Add("class", "fk-msg-success");
                        errorpopheadersuppli.InnerHtml = "ProductSupplymentType Inserted successfully";
                        BindProdCategoryGrid();
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPSupply('true');});", true);
                    }
                    else
                    {
                        errorpopheadersuppli.Visible = true;
                        errorpopheadersuppli.Style.Add("display", "block");
                        errorpopheadersuppli.Attributes.Add("class", "fk-err-all");
                        errorpopheadersuppli.InnerHtml = Status;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPSupply('true');});", true);
                    }
                    break;
                case "Update":
                    if (ViewState["popupID"] != null && ViewState["popupID"] != "")
                    {
                        objprodctg = null;
                        objprodctg = ObjprodClass.GetProdsupplymentByID(Convert.ToInt32(ViewState["popupID"]));
                        objprodctg.Name = categoryname.ToString();
                        if (ChkIsActivesupply.Checked)
                            objprodctg.IsActive = true;
                        else
                            objprodctg.IsActive = false;
                        Status = ObjprodClass.UpdateProdSupplymentType(objprodctg);
                        if (Status == "Information Update successfully.")
                        {
                            errorpopheadersuppli.Visible = true;
                            errorpopheadersuppli.Style.Add("display", "block");
                            errorpopheadersuppli.Attributes.Add("class", "fk-msg-success");
                            errorpopheadersuppli.InnerHtml = "ProductSupplymentType Updated successfully";
                            BindProdCategoryGrid();
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPSupplyUpdate('true');});", true);
                        }
                        else
                        {
                            errorpopheadersuppli.Visible = true;
                            errorpopheadersuppli.Style.Add("display", "block");
                            errorpopheadersuppli.Attributes.Add("class", "fk-err-all");
                            errorpopheadersuppli.InnerHtml = Status;
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPSupplyUpdate('true');});", true);
                        }
                    }
                    break;
            }


        }
    }
    protected void lnkAddNewprodsupplement_Click(object sender, EventArgs e)
    {
        btnSubmitsupply.Text = "Submit";
        errorpopheadersuppli.Style.Add("display", "none");
        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPSupply('true');});", true);
    }
}
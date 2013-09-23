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

public partial class UserControls_ADMIN_ProdCategory : System.Web.UI.UserControl
{
    Product ObjprodClass = new Product();
    TList<ProdCategory> objprodctgList = new TList<ProdCategory>();
    ProdCategory objprodctg = new ProdCategory();
    string Status;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            errorpopupStatus.Style.Add("display", "none");
            errorpopupStatus.Attributes.Add("class", "fk-err-all");
            if (Session["UserName"] != null)
            {
                BindProdCategoryGrid();
            }
        }
    }

    #region Custom Methods
    private void BindProdCategoryGrid()
    {
        objprodctgList = ObjprodClass.GetAllProdCategories();
        grdprodCategory.DataSource = objprodctgList;
        grdprodCategory.DataBind();
    }
    #endregion

    #region Row DataBound
    protected void grdprodCategory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
        {
            try
            {
                GridViewRow gr = e.Row;
                Label lblCategoryname = (Label)gr.FindControl("lblCategoryname");
                HiddenField HDFID = (HiddenField)gr.FindControl("HDFCategoryID");
                ImageButton IMGBTNcategoryisActive = (ImageButton)gr.FindControl("IMGBTNcategoryisActive");
                ProdCategory u = e.Row.DataItem as ProdCategory;
                lblCategoryname.Text = u.Name.Trim().ToString();
                HDFID.Value = u.Id.ToString();
                if (u.IsActive == true)
                {
                    IMGBTNcategoryisActive.ImageUrl = "~/images/tick.png";
                }
                else
                    IMGBTNcategoryisActive.ImageUrl = "~/images/close.jpg";
            }
            catch
            {
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
        objprodctg = ObjprodClass.GetProdcategoryByID(userid);
        if (objprodctg != null)
        {
            if (objprodctg.IsActive == true)
                ChkIsActive.Checked = true;
            TXTcategory.Text = objprodctg.Name;
            errorpopupStatus.Style.Add("display", "none");
            DIVIsActive.Style.Add("display", "block");
            btnSubmit.Text = "Update";
            ViewState["popupID"] = userid.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPUpdate('true');});", true);
        }
    }
    #endregion

    protected void btnSubmit_Click1(object sender, EventArgs e)
    {
        string categoryname = TXTcategory.Text;
        if (categoryname != null)
        {
            objprodctg.Name = categoryname.ToString();
            objprodctg.CreatedDate = DateTime.Now;
            switch (btnSubmit.Text.Trim())
            {
                case "Submit":
                    ViewState["popupID"] = null;
                    Status = ObjprodClass.insertProdCategory(objprodctg);
                    if (Status == "Information Insert successfully.")
                    {
                        errorpopupStatus.Visible = true;
                        errorpopupStatus.Style.Add("display", "block");
                        errorpopupStatus.Attributes.Add("class", "fk-msg-success");
                        errorpopupStatus.InnerHtml = "Productcategory Inserted successfully";
                        BindProdCategoryGrid();
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUP('true');});", true);
                    }
                    else
                    {
                        errorpopupStatus.Visible = true;
                        errorpopupStatus.Style.Add("display", "block");
                        errorpopupStatus.Attributes.Add("class", "fk-err-all");
                        errorpopupStatus.InnerHtml = Status;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUP('true');});", true);
                    }
                    break;
                case "Update":
                    if (ViewState["popupID"] != null && ViewState["popupID"] != "")
                    {
                        objprodctg = null;
                        objprodctg = ObjprodClass.GetProdcategoryByID(Convert.ToInt32(ViewState["popupID"]));
                        objprodctg.Name = categoryname.ToString();
                        if (ChkIsActive.Checked)
                            objprodctg.IsActive = true;
                        else
                            objprodctg.IsActive = false;
                        Status = ObjprodClass.UpdateProdCategory(objprodctg);
                        if (Status == "Information Update successfully.")
                        {
                            errorpopupStatus.Visible = true;
                            errorpopupStatus.Style.Add("display", "block");
                            errorpopupStatus.Attributes.Add("class", "fk-msg-success");
                            errorpopupStatus.InnerHtml = "Productcategory Updated successfully";
                            BindProdCategoryGrid();
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPUpdate('true');});", true);
                        }
                        else
                        {
                            errorpopupStatus.Visible = true;
                            errorpopupStatus.Style.Add("display", "block");
                            errorpopupStatus.Attributes.Add("class", "fk-err-all");
                            errorpopupStatus.InnerHtml = Status;
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPUpdate('true');});", true);
                        }
                    }
                    break;
            }


        }
    }
    protected void lnkAddNewordStats_Click(object sender, EventArgs e)
    {
        btnSubmit.Text = "Submit";
        errorpopupStatus.Style.Add("display", "none");
        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUP('true');});", true);
    }
}
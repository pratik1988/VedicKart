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

public partial class UserControls_ADMIN_Customers_CountryCityState : System.Web.UI.UserControl
{
    CustomerClass ObjprodClass = new CustomerClass();
    TList<Countries> objprodctgList = new TList<Countries>();
    Countries objprodctg = new Countries();
    string Status;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            errorpopheaderCSC.Style.Add("display", "none");
            errorpopheaderCSC.Attributes.Add("class", "fk-err-all");
            if (Session["UserName"] != null)
            {
                BindProdCategoryGrid();
            }
        }
    }

    #region Custom Methods
    private void BindProdCategoryGrid()
    {
        objprodctgList = ObjprodClass.GetAllCountries();
        grdCsC.DataSource = objprodctgList;
        grdCsC.DataBind();
    }
    #endregion

    #region Row DataBound
    protected void grdCsC_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
        {
            try
            {
                GridViewRow gr = e.Row;
                Label lblCategoryname = (Label)gr.FindControl("lblcountry");
                HiddenField HDFID = (HiddenField)gr.FindControl("HDFCSCID");
                ImageButton IMGBTNcategoryisActive = (ImageButton)gr.FindControl("IMGBTNCSCisActive");
                Countries u = e.Row.DataItem as Countries;
                lblCategoryname.Text = u.Name.ToString();
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
    protected void IMGBTNCSCisActive_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton lnk = (ImageButton)sender;
        int userid = Convert.ToInt32(lnk.CommandArgument);
        objprodctg = null;
        objprodctg = ObjprodClass.GetCountriesByID(userid);
        if (objprodctg != null)
        {
            if (objprodctg.IsActive == true)
                ChkIsActiveCSC.Checked = true;
            TXTCSC.Text = objprodctg.Name.ToString();
            errorpopheaderCSC.Style.Add("display", "none");
            DIVIsActive.Style.Add("display", "block");
            btnSubmitCSC.Text = "Update";
            ViewState["popupID"] = userid.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPCSCUpdate('true');});", true);
        }
    }
    #endregion

    protected void btnSubmitCSC_Click(object sender, EventArgs e)
    {
        string categoryname = TXTCSC.Text;
        if (categoryname != null)
        {
            objprodctg.Name = categoryname.ToString();
            objprodctg.CreatedDate = DateTime.Now;
            switch (btnSubmitCSC.Text.Trim())
            {
                case "Submit":
                    ViewState["popupID"] = null;
                    Status = ObjprodClass.insertCountries(objprodctg);
                    if (Status == "Information Insert successfully.")
                    {
                        errorpopheaderCSC.Visible = true;
                        errorpopheaderCSC.Style.Add("display", "block");
                        errorpopheaderCSC.Attributes.Add("class", "fk-msg-success");
                        errorpopheaderCSC.InnerHtml = "Country Inserted successfully";
                        BindProdCategoryGrid();
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPCSC('true');});", true);
                    }
                    else
                    {
                        errorpopheaderCSC.Visible = true;
                        errorpopheaderCSC.Style.Add("display", "block");
                        errorpopheaderCSC.Attributes.Add("class", "fk-err-all");
                        errorpopheaderCSC.InnerHtml = Status;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPCSC('true');});", true);
                    }
                    break;
                case "Update":
                    if (ViewState["popupID"] != null && ViewState["popupID"] != "")
                    {
                        objprodctg = null;
                        objprodctg = ObjprodClass.GetCountriesByID(Convert.ToInt32(ViewState["popupID"]));
                        objprodctg.Name = categoryname.ToString();
                        if (ChkIsActiveCSC.Checked)
                            objprodctg.IsActive = true;
                        else
                            objprodctg.IsActive = false;
                        Status = ObjprodClass.UpdateCountries(objprodctg);
                        if (Status == "Information Update successfully.")
                        {
                            errorpopheaderCSC.Visible = true;
                            errorpopheaderCSC.Style.Add("display", "block");
                            errorpopheaderCSC.Attributes.Add("class", "fk-msg-success");
                            errorpopheaderCSC.InnerHtml = "Country Updated successfully";
                            BindProdCategoryGrid();
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPCSCUpdate('true');});", true);
                        }
                        else
                        {
                            errorpopheaderCSC.Visible = true;
                            errorpopheaderCSC.Style.Add("display", "block");
                            errorpopheaderCSC.Attributes.Add("class", "fk-err-all");
                            errorpopheaderCSC.InnerHtml = Status;
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPCSCUpdate('true');});", true);
                        }
                    }
                    break;
            }


        }
    }
    protected void lnkAddNewCsC_Click(object sender, EventArgs e)
    {
        btnSubmitCSC.Text = "Submit";
        errorpopheaderCSC.Style.Add("display", "none");
        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPCSC('true');});", true);
    }
}
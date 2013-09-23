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

public partial class UserControls_ADMIN_Customers_Gender : System.Web.UI.UserControl
{
    CustomerClass ObjprodClass = new CustomerClass();
    TList<Gender> objprodctgList = new TList<Gender>();
    Gender objprodctg = new Gender();
    string Status;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            errorpopheadergender.Style.Add("display", "none");
            errorpopheadergender.Attributes.Add("class", "fk-err-all");
            if (Session["UserName"] != null)
            {
                BindProdCategoryGrid();
            }
        }
    }

    #region Custom Methods
    private void BindProdCategoryGrid()
    {
        objprodctgList = ObjprodClass.GetAllGender();
        grdgender.DataSource = objprodctgList;
        grdgender.DataBind();
    }
    #endregion

    #region Row DataBound
    protected void grdgender_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
        {
            try
            {
                GridViewRow gr = e.Row;
                Label lblCategoryname = (Label)gr.FindControl("lblGender");
                HiddenField HDFID = (HiddenField)gr.FindControl("HDFGenderID");
                ImageButton IMGBTNcategoryisActive = (ImageButton)gr.FindControl("IMGBTNgenderisActive");
                Gender u = e.Row.DataItem as Gender;
                lblCategoryname.Text = u.Gname.ToString();
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
    protected void IMGBTNgenderisActive_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton lnk = (ImageButton)sender;
        int userid = Convert.ToInt32(lnk.CommandArgument);
        objprodctg = null;
        objprodctg = ObjprodClass.GetGenderByID(userid);
        if (objprodctg != null)
        {
            if (objprodctg.IsActive == true)
                ChkIsActivegender.Checked = true;
            TXTGender.Text = objprodctg.Gname.ToString();
            errorpopheadergender.Style.Add("display", "none");
            DIVIsActive.Style.Add("display", "block");
            btnSubmitgender.Text = "Update";
            ViewState["popupID"] = userid.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPgenderUpdate('true');});", true);
        }
    }
    #endregion

    protected void btnSubmitgender_Click(object sender, EventArgs e)
    {
        string categoryname = TXTGender.Text;
        if (categoryname != null)
        {
            objprodctg.Gname = categoryname.ToString();
            objprodctg.CreatedDate = DateTime.Now;
            switch (btnSubmitgender.Text.Trim())
            {
                case "Submit":
                    ViewState["popupID"] = null;
                    Status = ObjprodClass.insertGender(objprodctg);
                    if (Status == "Information Insert successfully.")
                    {
                        errorpopheadergender.Visible = true;
                        errorpopheadergender.Style.Add("display", "block");
                        errorpopheadergender.Attributes.Add("class", "fk-msg-success");
                        errorpopheadergender.InnerHtml = "Gender Inserted successfully";
                        BindProdCategoryGrid();
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPgender('true');});", true);
                    }
                    else
                    {
                        errorpopheadergender.Visible = true;
                        errorpopheadergender.Style.Add("display", "block");
                        errorpopheadergender.Attributes.Add("class", "fk-err-all");
                        errorpopheadergender.InnerHtml = Status;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPgender('true');});", true);
                    }
                    break;
                case "Update":
                    if (ViewState["popupID"] != null && ViewState["popupID"] != "")
                    {
                        objprodctg = null;
                        objprodctg = ObjprodClass.GetGenderByID(Convert.ToInt32(ViewState["popupID"]));
                        objprodctg.Gname = categoryname.ToString();
                        if (ChkIsActivegender.Checked)
                            objprodctg.IsActive = true;
                        else
                            objprodctg.IsActive = false;
                        Status = ObjprodClass.UpdateGender(objprodctg);
                        if (Status == "Information Update successfully.")
                        {
                            errorpopheadergender.Visible = true;
                            errorpopheadergender.Style.Add("display", "block");
                            errorpopheadergender.Attributes.Add("class", "fk-msg-success");
                            errorpopheadergender.InnerHtml = "Gender Updated successfully";
                            BindProdCategoryGrid();
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPgenderUpdate('true');});", true);
                        }
                        else
                        {
                            errorpopheadergender.Visible = true;
                            errorpopheadergender.Style.Add("display", "block");
                            errorpopheadergender.Attributes.Add("class", "fk-err-all");
                            errorpopheadergender.InnerHtml = Status;
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPgenderUpdate('true');});", true);
                        }
                    }
                    break;
            }


        }
    }
    protected void lnkAddNewGender_Click(object sender, EventArgs e)
    {
        btnSubmitgender.Text = "Submit";
        errorpopheadergender.Style.Add("display", "none");
        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPgender('true');});", true);
    }
}
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

public partial class UserControls_ADMIN_Customers_UserType : System.Web.UI.UserControl
{
    CustomerClass ObjprodClass = new CustomerClass();
    TList<UserType> objprodctgList = new TList<UserType>();
    UserType objprodctg = new UserType();
    string Status;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            errorpopheaderusertype.Style.Add("display", "none");
            errorpopheaderusertype.Attributes.Add("class", "fk-err-all");
            if (Session["UserName"] != null)
            {
                BindProdCategoryGrid();
            }
        }
    }

    #region Custom Methods
    private void BindProdCategoryGrid()
    {
        objprodctgList = ObjprodClass.GetAllUserType();
        grdusrtype.DataSource = objprodctgList;
        grdusrtype.DataBind();
    }
    #endregion

    #region Row DataBound
    protected void grdusrtype_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
        {
            try
            {
                GridViewRow gr = e.Row;
                Label lblCategoryname = (Label)gr.FindControl("lblusertype");
                HiddenField HDFID = (HiddenField)gr.FindControl("HDFusertypeID");
                ImageButton IMGBTNcategoryisActive = (ImageButton)gr.FindControl("IMGBTNusertypeisActive");
                UserType u = e.Row.DataItem as UserType;
                lblCategoryname.Text = u.UserType.ToString();
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
    protected void IMGBTNusertypeisActive_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton lnk = (ImageButton)sender;
        int userid = Convert.ToInt32(lnk.CommandArgument);
        objprodctg = null;
        objprodctg = ObjprodClass.GetUserTypeByID(userid);
        if (objprodctg != null)
        {
            if (objprodctg.IsActive == true)
                ChkIsActiveusertype.Checked = true;
            TXTusertype.Text = objprodctg.UserType.ToString();
            errorpopheaderusertype.Style.Add("display", "none");
            DIVIsActive.Style.Add("display", "block");
            btnSubmitusertype.Text = "Update";
            ViewState["popupID"] = userid.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPusertypeUpdate('true');});", true);
        }
    }
    #endregion

    protected void btnSubmitusertype_Click(object sender, EventArgs e)
    {
        string categoryname = TXTusertype.Text;
        if (categoryname != null)
        {
            objprodctg.UserType = categoryname.ToString();
            objprodctg.CreatedDate = DateTime.Now;
            switch (btnSubmitusertype.Text.Trim())
            {
                case "Submit":
                    ViewState["popupID"] = null;
                    Status = ObjprodClass.insertUserType(objprodctg);
                    if (Status == "Information Insert successfully.")
                    {
                        errorpopheaderusertype.Visible = true;
                        errorpopheaderusertype.Style.Add("display", "block");
                        errorpopheaderusertype.Attributes.Add("class", "fk-msg-success");
                        errorpopheaderusertype.InnerHtml = "UserType Inserted successfully";
                        BindProdCategoryGrid();
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPusertype('true');});", true);
                    }
                    else
                    {
                        errorpopheaderusertype.Visible = true;
                        errorpopheaderusertype.Style.Add("display", "block");
                        errorpopheaderusertype.Attributes.Add("class", "fk-err-all");
                        errorpopheaderusertype.InnerHtml = Status;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPusertype('true');});", true);
                    }
                    break;
                case "Update":
                    if (ViewState["popupID"] != null && ViewState["popupID"] != "")
                    {
                        objprodctg = null;
                        objprodctg = ObjprodClass.GetUserTypeByID(Convert.ToInt32(ViewState["popupID"]));
                        objprodctg.UserType = categoryname.ToString();
                        if (ChkIsActiveusertype.Checked)
                            objprodctg.IsActive = true;
                        else
                            objprodctg.IsActive = false;
                        Status = ObjprodClass.UpdateUserType(objprodctg);
                        if (Status == "Information Update successfully.")
                        {
                            errorpopheaderusertype.Visible = true;
                            errorpopheaderusertype.Style.Add("display", "block");
                            errorpopheaderusertype.Attributes.Add("class", "fk-msg-success");
                            errorpopheaderusertype.InnerHtml = "UserType Updated successfully";
                            BindProdCategoryGrid();
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPusertypeUpdate('true');});", true);
                        }
                        else
                        {
                            errorpopheaderusertype.Visible = true;
                            errorpopheaderusertype.Style.Add("display", "block");
                            errorpopheaderusertype.Attributes.Add("class", "fk-err-all");
                            errorpopheaderusertype.InnerHtml = Status;
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPusertypeUpdate('true');});", true);
                        }
                    }
                    break;
            }


        }
    }
    protected void lnkAddNewusrtype_Click(object sender, EventArgs e)
    {
        btnSubmitusertype.Text = "Submit";
        errorpopheaderusertype.Style.Add("display", "none");
        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPusertype('true');});", true);
    }
}
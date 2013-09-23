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
using System.Linq;
using System.IO;
#endregion

public partial class UserControls_ADMIN_Customers_Customer : System.Web.UI.UserControl
{
    CustomerClass ObjcustClass = new CustomerClass();
    TList<Customers> objcustlist = new TList<Customers>();
    Customers objcust = new Customers();
    TList<UserType> objUsertyplist = new TList<UserType>();
    UserType objusertype = new UserType();
    TList<Gender> objgenderlist = new TList<Gender>();
    Gender objgender = new Gender();
    string Status;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            errorpopheadercust.Style.Add("display", "none");
            errorpopheadercust.Attributes.Add("class", "fk-err-all");
            if (Session["UserName"] != null)
            {
                BindProdGrid();
                binddrpdowns();
            }
        }
    }
    #region Custom Methods
    private void BindProdGrid()
    {
        objcustlist = ObjcustClass.GetAllCustomers();
        grdcust.DataSource = objcustlist;
        grdcust.DataBind();
    }


    #endregion

    #region Row DataBound
    protected void grdcust_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
        {
            try
            {
                GridViewRow gr = e.Row;
                Label lblcustname = (Label)gr.FindControl("lblcustname");
                Label lblemailID = (Label)gr.FindControl("lblemailID");
                Label lblcustType = (Label)gr.FindControl("lblcustType");
                Label lblcustGender = (Label)gr.FindControl("lblcustGender");
                Label lblcustFname = (Label)gr.FindControl("lblcustFname");
                Label lblcustLname = (Label)gr.FindControl("lblcustLname");
                Label lblcustmobNo = (Label)gr.FindControl("lblcustmobNo");
                Label lblcustlandNo = (Label)gr.FindControl("lblcustlandNo");
                HiddenField HDFID = (HiddenField)gr.FindControl("HDFcustID");
                ImageButton IMGBTNcategoryisActive = (ImageButton)gr.FindControl("IMGBTNCustisActive");
                Customers u = e.Row.DataItem as Customers;
                objusertype = null;
                objgender = null;
                objusertype = ObjcustClass.GetUserTypeByID(Convert.ToInt32(u.UserType));
                objgender = ObjcustClass.GetGenderByID(Convert.ToInt32(u.Gender));
                if (objusertype != null && objgender != null)
                {
                    lblcustname.Text = u.Name.ToString().Trim();
                    lblemailID.Text = u.EmailId.ToString().Trim();
                    lblcustGender.Text = u.Gender.ToString().Trim();
                    lblcustFname.Text = u.FirstName.ToString().Trim();
                    lblcustType.Text = objusertype.UserType.ToString().Trim();
                    lblcustLname.Text = u.LastName.ToString().Trim();
                    lblcustmobNo.Text = u.MobileNumber.ToString().Trim();
                    lblcustlandNo.Text = string.IsNullOrEmpty(u.LandNumber) ? "N/A" : u.LandNumber;
                    HDFID.Value = u.Id.ToString();
                    if (u.IsActive == true)
                    {
                        IMGBTNcategoryisActive.ImageUrl = "~/images/tick.png";
                    }
                    else
                        IMGBTNcategoryisActive.ImageUrl = "~/images/close.jpg";
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
    #endregion

    #region Link Active OR Deactive
    protected void IMGBTNCustisActive_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton lnk = (ImageButton)sender;
        int userid = Convert.ToInt32(lnk.CommandArgument);
        
        objcust = null;
        objcust = ObjcustClass.GetCustomersByID(userid);
        if (objcust != null)
        {
            TXTcust.Text = objcust.Name.ToString().Trim();
            txtcustfrstname.Text = objcust.FirstName.ToString().Trim();
            txtcustlastnme.Text = objcust.LastName.ToString().Trim();
            TXTcustEmail.Text = objcust.EmailId.ToString().Trim();
            txtcustlandNo.Text = string.IsNullOrEmpty(objcust.LandNumber) ? "" : objcust.LandNumber;
            txtcustMobileNo.Text = objcust.MobileNumber.ToString().Trim();
            txtcustPass.Text = objcust.Password.ToString().Trim();
            drpUserType.SelectedValue = objcust.UserType.ToString().Trim();
            Drpgender.SelectedValue = objcust.Gender.ToString().Trim();
            errorpopheadercust.Style.Add("display", "none");
            //DIVIsActive.Style.Add("display", "block");
            btnSubmitCust.Text = "Update";
            ViewState["popupID"] = userid.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPprodUpdatecust('true');});", true);
        }
    }
    #endregion

    #region Bind DropDowns
    public void binddrpdowns()
    {
        drpUserType.DataSource = ObjcustClass.GetAllUserType();
        drpUserType.DataTextField = "UserType";
        drpUserType.DataValueField = "ID";
        drpUserType.DataBind();
        drpUserType.Items.Insert(0, new ListItem("--Select UserType--", "0"));

        Drpgender.DataSource = ObjcustClass.GetAllGender();
        Drpgender.DataTextField = "GName";
        Drpgender.DataValueField = "ID";
        Drpgender.DataBind();
        Drpgender.Items.Insert(0, new ListItem("--Select Gender--", "0"));
    }
    #endregion

    #region Button Click
    protected void lnkAddNewcust_Click(object sender, EventArgs e)
    {

        errorpopheadercust.Style.Add("display", "none");
        btnSubmitCust.Text = "Submit";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPCust('false');});", true);
    }
    protected void btnSubmitCust_Click(object sender, EventArgs e)
    {
        switch (btnSubmitCust.Text)
        {
            case "Submit":
                objcust.Name = TXTcust.Text.ToString().Trim();
                objcust.FirstName = txtcustfrstname.Text.ToString().Trim();
                objcust.LastName = txtcustlastnme.Text.ToString().Trim();
                objcust.MobileNumber = txtcustMobileNo.Text.ToString().Trim();
                objcust.LandNumber = txtcustlandNo.Text.ToString().Trim();
                objcust.Password = txtcustPass.Text.ToString().Trim();
                objcust.EmailId = TXTcustEmail.Text.ToString().Trim();
                objcust.IsActive = true;
                objcust.UserType = Convert.ToInt32(drpUserType.SelectedValue);
                objcust.Gender = Convert.ToInt32(Drpgender.SelectedValue);
                objcust.CreatedDate = DateTime.Now;
                    Status = null;
                    Status = ObjcustClass.insertCustomers(objcust);
                    if (Status == "Information Insert successfully.")
                    {
                        errorpopheadercust.Visible = true;
                        errorpopheadercust.Style.Add("display", "block");
                        errorpopheadercust.Attributes.Add("class", "fk-msg-success");
                        errorpopheadercust.InnerHtml = "Customer Inserted successfully";
                        binddrpdowns();
                        BindProdGrid();
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPCust('false');});", true);
                    }
                    else
                    {
                        errorpopheadercust.Visible = true;
                        errorpopheadercust.Style.Add("display", "block");
                        errorpopheadercust.Attributes.Add("class", "fk-err-all");
                        errorpopheadercust.InnerHtml = Status;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPCust('true');});", true);
                    }


                
                break;
            case "Update":
                if (ViewState["popupID"] != null && ViewState["popupID"] != "")
                {
                    objcust = null;
                    objcust = ObjcustClass.GetCustomersByID(Convert.ToInt32(ViewState["popupID"]));
                    objcust.Name = TXTcust.Text.ToString().Trim();
                    objcust.FirstName = txtcustfrstname.Text.ToString().Trim();
                    objcust.LastName = txtcustlastnme.Text.ToString().Trim();
                    objcust.MobileNumber = txtcustMobileNo.Text.ToString().Trim();
                    objcust.LandNumber = txtcustlandNo.Text.ToString().Trim();
                    objcust.Password = txtcustPass.Text.ToString().Trim();
                    objcust.EmailId = TXTcustEmail.Text.ToString().Trim();
                    objcust.IsActive = true;
                    objcust.UserType = Convert.ToInt32(drpUserType.SelectedValue);
                    objcust.Gender = Convert.ToInt32(Drpgender.SelectedValue);
                    objcust.ModifiedDate = DateTime.Now;
                    Status = null;
                    Status = ObjcustClass.UpdateCustomers(objcust);
                    if (Status == "Information Update successfully.")
                    {
                        errorpopheadercust.Visible = true;
                        errorpopheadercust.Style.Add("display", "block");
                        errorpopheadercust.Attributes.Add("class", "fk-msg-success");
                        errorpopheadercust.InnerHtml = "Product Updated successfully";

                        BindProdGrid();
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPupdateCust('true');});", true);
                    }
                    else
                    {
                        errorpopheadercust.Visible = true;
                        errorpopheadercust.Style.Add("display", "block");
                        errorpopheadercust.Attributes.Add("class", "fk-err-all");
                        errorpopheadercust.InnerHtml = Status;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPupdateCust('true');});", true);
                    }



                }
                break;
        }
    }
    #endregion
}
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

public partial class UserControls_ADMIN_ProdCompany : System.Web.UI.UserControl
{
    Product ObjprodClass = new Product();
    TList<ProdCompany> Objprodcomplist = new TList<ProdCompany>();
    ProdCompany objprodcomp = new ProdCompany();
    string Status;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            errorpopupcompany.Style.Add("display", "none");
            errorpopupcompany.Attributes.Add("class", "fk-err-all");
            if (Session["UserName"] != null)
            {
                BindProdCompanyGrid();
            }
        }
    }
    private void BindProdCompanyGrid()
    {
        Objprodcomplist = ObjprodClass.GetAllProdCompanies();
        grdprodcompany.DataSource = Objprodcomplist;
        grdprodcompany.DataBind();
    }

    protected void grdprodcompany_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
        {
            try
            {
                GridViewRow gr = e.Row;
                Label lblCompanyname = (Label)gr.FindControl("lblCompanyname");
                HiddenField HDFID = (HiddenField)gr.FindControl("HDFCompanyID");
                ImageButton IMGBTNcompanyisActive = (ImageButton)gr.FindControl("IMGBTNcompanyisActive");
                ProdCompany u = e.Row.DataItem as ProdCompany;
                lblCompanyname.Text = u.CompanyName.Trim().ToString();
                HDFID.Value = u.Id.ToString();
                if (u.IsActive == true)
                {
                    IMGBTNcompanyisActive.ImageUrl = "~/images//tick.png";
                }
                else
                    IMGBTNcompanyisActive.ImageUrl = "~/images/close.jpg";
            }
            catch
            {
            }
        }
    }

    protected void btnsubmitcompany_Click1(object sender, EventArgs e)
    {
        string compname = txtcompname.Text;
        if (compname != null)
        {
            objprodcomp.CompanyName = compname.ToString();
            objprodcomp.CreatedDate = DateTime.Now;
            switch (btnsubmitcompany.Text.Trim())
            {
                case "Submit":
                    ViewState["popupID"] = null;
                    Status = ObjprodClass.insertProdCompany(objprodcomp);
                    if (Status == "Information Insert successfully.")
                    {
                        errorpopupcompany.Visible = true;
                        errorpopupcompany.Style.Add("display", "block");
                        errorpopupcompany.Attributes.Add("class", "fk-msg-success");
                        errorpopupcompany.InnerHtml = "Productcompany Inserted successfully";
                        BindProdCompanyGrid();
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPCompany('true');});", true);
                    }
                    else
                    {
                        errorpopupcompany.Visible = true;
                        errorpopupcompany.Style.Add("display", "block");
                        errorpopupcompany.Attributes.Add("class", "fk-err-all");
                        errorpopupcompany.InnerHtml = Status;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPCompany('true');});", true);
                    }
                    break;
                case "Update":
                    if (ViewState["popupID"] != null && ViewState["popupID"] != "")
                    {
                        objprodcomp = null;
                        objprodcomp = ObjprodClass.GetProdcompByID(Convert.ToInt32(ViewState["popupID"]));
                        objprodcomp.CompanyName = compname.ToString();
                        if (chkisactivecomp.Checked)
                            objprodcomp.IsActive = true;
                        else
                            objprodcomp.IsActive = false;
                        Status = ObjprodClass.UpdateProdCompany(objprodcomp);
                        if (Status == "Information Update successfully.")
                        {
                            errorpopupcompany.Visible = true;
                            errorpopupcompany.Style.Add("display", "block");
                            errorpopupcompany.Attributes.Add("class", "fk-msg-success");
                            errorpopupcompany.InnerHtml = "Productcompany Updated successfully";
                            BindProdCompanyGrid();
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPUpdatecomp('true');});", true);
                        }
                        else
                        {
                            errorpopupcompany.Visible = true;
                            errorpopupcompany.Style.Add("display", "block");
                            errorpopupcompany.Attributes.Add("class", "fk-err-all");
                            errorpopupcompany.InnerHtml = Status;
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPUpdatecomp('true');});", true);
                        }
                    }
                    break;
            }


        }
    }
    protected void lnkaddnewcomp_Click(object sender, EventArgs e)
    {
        btnsubmitcompany.Text = "Submit";
        errorpopupcompany.Style.Add("display", "none");
        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPCompany('true');});", true);
    }

    #region Link Active OR Deactive
    protected void IMGBTNcompanyisActive_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton lnk = (ImageButton)sender;
        int userid = Convert.ToInt32(lnk.CommandArgument);
        objprodcomp = null;
        objprodcomp = ObjprodClass.GetProdcompByID(userid);
        if (objprodcomp != null)
        {
            if (objprodcomp.IsActive == true)
                chkisactivecomp.Checked = true;
            txtcompname.Text = "";
            txtcompname.Text = objprodcomp.CompanyName;
            errorpopupcompany.Style.Add("display", "none");
            DIVIsActivecomp.Style.Add("display", "block");
            btnsubmitcompany.Text = "Update";
            ViewState["popupID"] = userid.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPUpdatecomp('true');});", true);
        }
    }
    #endregion
}
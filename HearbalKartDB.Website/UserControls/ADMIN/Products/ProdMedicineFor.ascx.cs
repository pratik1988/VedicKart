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

public partial class UserControls_ADMIN_Products_ProdMedicineFor : System.Web.UI.UserControl
{
    Product ObjprodClass = new Product();
    TList<ProdMedicineFor> objprodctgList = new TList<ProdMedicineFor>();
    ProdMedicineFor objprodctg = new ProdMedicineFor();
    string Status;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            errorpopupmedicine.Style.Add("display", "none");
            errorpopupmedicine.Attributes.Add("class", "fk-err-all");
            if (Session["UserName"] != null)
            {
                BindProdCategoryGrid();
            }
        }
    }

    #region Custom Methods
    private void BindProdCategoryGrid()
    {
        objprodctgList = ObjprodClass.GetAllProdmedicines();
        grdprodmedicnfr.DataSource = objprodctgList;
        grdprodmedicnfr.DataBind();
    }
    #endregion

    #region Row DataBound
    protected void grdprodmedicnfr_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
        {
            try
            {
                GridViewRow gr = e.Row;
                Label lblCategoryname = (Label)gr.FindControl("lblmedicinename");
                HiddenField HDFID = (HiddenField)gr.FindControl("HDFmedicineID");
                ImageButton IMGBTNcategoryisActive = (ImageButton)gr.FindControl("IMGBTNmedicineisActive");
                ProdMedicineFor u = e.Row.DataItem as ProdMedicineFor;
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
        objprodctg = ObjprodClass.GetProdmedicineByID(userid);
        if (objprodctg != null)
        {
            if (objprodctg.IsActive == true)
                ChkIsActivemedicine.Checked = true;
            TXTmedicine.Text = objprodctg.Name;
            errorpopupmedicine.Style.Add("display", "none");
            DIVIsActive.Style.Add("display", "block");
            btnSubmitmedicine.Text = "Update";
            ViewState["popupID"] = userid.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPmedicineUpdate('true');});", true);
        }
    }
    #endregion

    protected void btnSubmit_Click1(object sender, EventArgs e)
    {
        string categoryname = TXTmedicine.Text;
        if (categoryname != null)
        {
            objprodctg.Name = categoryname.ToString();
            objprodctg.CreatedDate = DateTime.Now;
            switch (btnSubmitmedicine.Text.Trim())
            {
                case "Submit":
                    ViewState["popupID"] = null;
                    Status = ObjprodClass.insertProdmedicinefor(objprodctg);
                    if (Status == "Information Insert successfully.")
                    {
                        errorpopupmedicine.Visible = true;
                        errorpopupmedicine.Style.Add("display", "block");
                        errorpopupmedicine.Attributes.Add("class", "fk-msg-success");
                        errorpopupmedicine.InnerHtml = "ProductMedicine Inserted successfully";
                        BindProdCategoryGrid();
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPmedicine('true');});", true);
                    }
                    else
                    {
                        errorpopupmedicine.Visible = true;
                        errorpopupmedicine.Style.Add("display", "block");
                        errorpopupmedicine.Attributes.Add("class", "fk-err-all");
                        errorpopupmedicine.InnerHtml = Status;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPmedicine('true');});", true);
                    }
                    break;
                case "Update":
                    if (ViewState["popupID"] != null && ViewState["popupID"] != "")
                    {
                        objprodctg = null;
                        objprodctg = ObjprodClass.GetProdmedicineByID(Convert.ToInt32(ViewState["popupID"]));
                        objprodctg.Name = categoryname.ToString();
                        if (ChkIsActivemedicine.Checked)
                            objprodctg.IsActive = true;
                        else
                            objprodctg.IsActive = false;
                        Status = ObjprodClass.UpdateProdMedicine(objprodctg);
                        if (Status == "Information Update successfully.")
                        {
                            errorpopupmedicine.Visible = true;
                            errorpopupmedicine.Style.Add("display", "block");
                            errorpopupmedicine.Attributes.Add("class", "fk-msg-success");
                            errorpopupmedicine.InnerHtml = "Productmedicine Updated successfully";
                            BindProdCategoryGrid();
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPmedicineUpdate('true');});", true);
                        }
                        else
                        {
                            errorpopupmedicine.Visible = true;
                            errorpopupmedicine.Style.Add("display", "block");
                            errorpopupmedicine.Attributes.Add("class", "fk-err-all");
                            errorpopupmedicine.InnerHtml = Status;
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPmedicineUpdate('true');});", true);
                        }
                    }
                    break;
            }


        }
    }
    protected void lnkAddNewprodmedicine_Click(object sender, EventArgs e)
    {
        btnSubmitmedicine.Text = "Submit";
        errorpopupmedicine.Style.Add("display", "none");
        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPmedicine('true');});", true);
    }
}
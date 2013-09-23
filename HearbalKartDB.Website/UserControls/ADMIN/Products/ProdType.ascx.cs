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

public partial class UserControls_ADMIN_Products_ProdType : System.Web.UI.UserControl
{
    Product ObjprodClass = new Product();
    TList<ProdType> objprodctgList = new TList<ProdType>();
    ProdType objprodctg = new ProdType();
    string Status;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            errorpopheaderprodtype.Style.Add("display", "none");
            errorpopheaderprodtype.Attributes.Add("class", "fk-err-all");
            if (Session["UserName"] != null)
            {
                BindProdCategoryGrid();
            }
        }
    }

    #region Custom Methods
    private void BindProdCategoryGrid()
    {
        objprodctgList = ObjprodClass.GetAllProdType();
        grdprodtype.DataSource = objprodctgList;
        grdprodtype.DataBind();
    }

   
    #endregion

    #region Row DataBound
    protected void grdprodtype_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
        {
            try
            {
                GridViewRow gr = e.Row;
                Label lblCategoryname = (Label)gr.FindControl("lblProdType");
                HiddenField HDFID = (HiddenField)gr.FindControl("HDFProdTypeID");
                ImageButton IMGBTNcategoryisActive = (ImageButton)gr.FindControl("IMGBTNProdtypeisActive");
                ProdType u = e.Row.DataItem as ProdType;
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
        objprodctg = ObjprodClass.GetProdTypeByID(userid);
        if (objprodctg != null)
        {
            if (objprodctg.IsActive == true)
                ChkIsActiveprodtype.Checked = true;
            TXTprodType.Text = objprodctg.Name;
            errorpopheaderprodtype.Style.Add("display", "none");
            DIVIsActive.Style.Add("display", "block");
            btnSubmitprodtype.Text = "Update";
            ViewState["popupID"] = userid.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPprodtypeUpdate('true');});", true);
        }
    }
    #endregion

    protected void btnSubmit_Click1(object sender, EventArgs e)
    {
        string categoryname = TXTprodType.Text;
        if (categoryname != null)
        {
            objprodctg.Name = categoryname.ToString();
            objprodctg.CreatedDate = DateTime.Now;
            switch (btnSubmitprodtype.Text.Trim())
            {
                case "Submit":
                    ViewState["popupID"] = null;
                    Status = ObjprodClass.insertProdType(objprodctg);
                    if (Status == "Information Insert successfully.")
                    {
                        errorpopheaderprodtype.Visible = true;
                        errorpopheaderprodtype.Style.Add("display", "block");
                        errorpopheaderprodtype.Attributes.Add("class", "fk-msg-success");
                        errorpopheaderprodtype.InnerHtml = "ProductType Inserted successfully";
                        BindProdCategoryGrid();
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPprodtype('true');});", true);
                    }
                    else
                    {
                        errorpopheaderprodtype.Visible = true;
                        errorpopheaderprodtype.Style.Add("display", "block");
                        errorpopheaderprodtype.Attributes.Add("class", "fk-err-all");
                        errorpopheaderprodtype.InnerHtml = Status;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPprodtype('true');});", true);
                    }
                    break;
                case "Update":
                    if (ViewState["popupID"] != null && ViewState["popupID"] != "")
                    {
                        objprodctg = null;
                        objprodctg = ObjprodClass.GetProdTypeByID(Convert.ToInt32(ViewState["popupID"]));
                        objprodctg.Name = categoryname.ToString();
                        if (ChkIsActiveprodtype.Checked)
                            objprodctg.IsActive = true;
                        else
                            objprodctg.IsActive = false;
                        Status = ObjprodClass.UpdateProdType(objprodctg);
                        if (Status == "Information Update successfully.")
                        {
                            errorpopheaderprodtype.Visible = true;
                            errorpopheaderprodtype.Style.Add("display", "block");
                            errorpopheaderprodtype.Attributes.Add("class", "fk-msg-success");
                            errorpopheaderprodtype.InnerHtml = "ProductType Updated successfully";
                            BindProdCategoryGrid();
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPprodtypeUpdate('true');});", true);
                        }
                        else
                        {
                            errorpopheaderprodtype.Visible = true;
                            errorpopheaderprodtype.Style.Add("display", "block");
                            errorpopheaderprodtype.Attributes.Add("class", "fk-err-all");
                            errorpopheaderprodtype.InnerHtml = Status;
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPprodtypeUpdate('true');});", true);
                        }
                    }
                    break;
            }


        }
    }
    protected void lnkAddNewprodtype_Click(object sender, EventArgs e)
    {
        btnSubmitprodtype.Text = "Submit";
        errorpopheaderprodtype.Style.Add("display", "none");
        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPprodtype('true');});", true);
    }
}
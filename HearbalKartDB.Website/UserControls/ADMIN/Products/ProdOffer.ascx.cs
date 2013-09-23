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

public partial class UserControls_ADMIN_Products_ProdOffer : System.Web.UI.UserControl
{
    Product ObjprodClass = new Product();
    TList<ProdOffer> objprodctgList = new TList<ProdOffer>();
    ProdOffer objprodctg = new ProdOffer();
    string Status;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            errorpopheaderprodoffer.Style.Add("display", "none");
            errorpopheaderprodoffer.Attributes.Add("class", "fk-err-all");
            if (Session["UserName"] != null)
            {
                BindProdCategoryGrid();
            }
        }
    }

    #region Custom Methods
    private void BindProdCategoryGrid()
    {
        objprodctgList = ObjprodClass.GetAllProdOffer() ;
        grdprodoffer.DataSource = objprodctgList;
        grdprodoffer.DataBind();
    }
    #endregion

    #region Row DataBound
    protected void grdprodoffer_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
        {
            try
            {
                GridViewRow gr = e.Row;
                Label lblCategoryname = (Label)gr.FindControl("lblProdOffer");
                HiddenField HDFID = (HiddenField)gr.FindControl("HDFProdOfferID");
                ImageButton IMGBTNcategoryisActive = (ImageButton)gr.FindControl("IMGBTNProdofferisActive");
                ProdOffer u = e.Row.DataItem as ProdOffer;
                lblCategoryname.Text = u.OfferPercent.ToString();
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
        objprodctg = ObjprodClass.GetProdOfferByID(userid);
        if (objprodctg != null)
        {
            if (objprodctg.IsActive == true)
                ChkIsActiveprodoffer.Checked = true;
            TXTprodOffer.Text = objprodctg.OfferPercent.ToString();
            errorpopheaderprodoffer.Style.Add("display", "none");
            DIVIsActive.Style.Add("display", "block");
            btnSubmitprodoffer.Text = "Update";
            ViewState["popupID"] = userid.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPprodofferUpdate('true');});", true);
        }
    }
    #endregion

    protected void btnSubmit_Click1(object sender, EventArgs e)
    {
        string categoryname = TXTprodOffer.Text;
        if (categoryname != null)
        {
            objprodctg.OfferPercent = Convert.ToDecimal(categoryname.ToString());
            objprodctg.CreatedDate = DateTime.Now;
            switch (btnSubmitprodoffer.Text.Trim())
            {
                case "Submit":
                    ViewState["popupID"] = null;
                    Status = ObjprodClass.insertProdOffer(objprodctg);
                    if (Status == "Information Insert successfully.")
                    {
                        errorpopheaderprodoffer.Visible = true;
                        errorpopheaderprodoffer.Style.Add("display", "block");
                        errorpopheaderprodoffer.Attributes.Add("class", "fk-msg-success");
                        errorpopheaderprodoffer.InnerHtml = "ProductType Inserted successfully";
                        BindProdCategoryGrid();
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPprodoffer('true');});", true);
                    }
                    else
                    {
                        errorpopheaderprodoffer.Visible = true;
                        errorpopheaderprodoffer.Style.Add("display", "block");
                        errorpopheaderprodoffer.Attributes.Add("class", "fk-err-all");
                        errorpopheaderprodoffer.InnerHtml = Status;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPprodoffer('true');});", true);
                    }
                    break;
                case "Update":
                    if (ViewState["popupID"] != null && ViewState["popupID"] != "")
                    {
                        objprodctg = null;
                        objprodctg = ObjprodClass.GetProdOfferByID(Convert.ToInt32(ViewState["popupID"]));
                        objprodctg.OfferPercent = Convert.ToDecimal(categoryname.ToString());
                        if (ChkIsActiveprodoffer.Checked)
                            objprodctg.IsActive = true;
                        else
                            objprodctg.IsActive = false;
                        Status = ObjprodClass.UpdateProdOffer(objprodctg);
                        if (Status == "Information Update successfully.")
                        {
                            errorpopheaderprodoffer.Visible = true;
                            errorpopheaderprodoffer.Style.Add("display", "block");
                            errorpopheaderprodoffer.Attributes.Add("class", "fk-msg-success");
                            errorpopheaderprodoffer.InnerHtml = "ProductType Updated successfully";
                            BindProdCategoryGrid();
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPprodofferUpdate('true');});", true);
                        }
                        else
                        {
                            errorpopheaderprodoffer.Visible = true;
                            errorpopheaderprodoffer.Style.Add("display", "block");
                            errorpopheaderprodoffer.Attributes.Add("class", "fk-err-all");
                            errorpopheaderprodoffer.InnerHtml = Status;
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPprodofferUpdate('true');});", true);
                        }
                    }
                    break;
            }


        }
    }
    protected void lnkAddNewprodoffer_Click(object sender, EventArgs e)
    {
        btnSubmitprodoffer.Text = "Submit";
        errorpopheaderprodoffer.Style.Add("display", "none");
        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPprodoffer('true');});", true);
    }
}
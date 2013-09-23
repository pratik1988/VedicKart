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

public partial class UserControls_ADMIN_Products_ProdTable : System.Web.UI.UserControl
{
    Product ObjprodClass = new Product();
    TList<ProdType> objprodtypeList = new TList<ProdType>();
    TList<ProdCategory> objprodctgList = new TList<ProdCategory>();
    TList<ProdCompany> Objprodcomplist = new TList<ProdCompany>();
    TList<ProdMedicineFor> objprodmedList = new TList<ProdMedicineFor>();
    TList<ProdOffer> objprodofferList = new TList<ProdOffer>();
    TList<ProdSupplymentType> objprodsupplyList = new TList<ProdSupplymentType>();
    TList<ProdTable> ObjProdTablelist = new TList<ProdTable>();
    ProdTable objprod = new ProdTable();
    Items objitem = new Items();
    ItemPurchase objitempurchase = new ItemPurchase();
    ItemSell objitemsell = new ItemSell();
    bool isactive = true;
    ProdCompany Objprodcomp = new ProdCompany();
    ProdType objprodtype = new ProdType();
    ProdCategory objprodctg = new ProdCategory();
    ProdSupplymentType objprodsupple = new ProdSupplymentType();
    ProdMedicineFor objmed = new ProdMedicineFor();
    ProdOffer objoffer = new ProdOffer();
    string Status;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            file_upload.Attributes.Add("onchange", "SetFileName('" + file_upload.ClientID + "','" + TXTProdimg.ClientID + "')");
            errorpopheaderprod.Style.Add("display", "none");
            errorpopheaderprod.Attributes.Add("class", "fk-err-all");
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
        ObjProdTablelist = ObjprodClass.GetAllProd();
        grdprod.DataSource = ObjProdTablelist;
        grdprod.DataBind();
    }


    #endregion

    #region Row DataBound
    protected void grdprod_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
        {
            try
            {
                GridViewRow gr = e.Row;
                Label lblprodname = (Label)gr.FindControl("lblProdname");
                Label lblProdctg = (Label)gr.FindControl("lblProdctg");
                Label lblProdcomp = (Label)gr.FindControl("lblProdcomp");
                Label lblProdtype = (Label)gr.FindControl("lblProdtype");
                Label lblProdsupp = (Label)gr.FindControl("lblProdsupp");
                Label lblProdmedicinefor = (Label)gr.FindControl("lblProdmedicinefor");
                Label lblProdPcost = (Label)gr.FindControl("lblProdPcost");
                Label lblProdScost = (Label)gr.FindControl("lblProdScost");
                Label lblProdoffer = (Label)gr.FindControl("lblProdoffer");
                HiddenField HDFID = (HiddenField)gr.FindControl("HDFProdID");
                ImageButton IMGBTNcategoryisActive = (ImageButton)gr.FindControl("IMGBTNProdisActive");
                Image IMGProd = (Image)gr.FindControl("IMGProd");
                ProdTable u = e.Row.DataItem as ProdTable;
                objitem = null;
                objitem = ObjprodClass.GetItemsByID(Convert.ToInt32(u.ItemId));
                if (objitem != null)
                {
                    objitempurchase = ObjprodClass.GetItempurchaseByID(Convert.ToInt32(u.PurchaseId));
                    objitemsell = ObjprodClass.GetItemsellByID(Convert.ToInt32(u.SellId));
                    objprodctg = ObjprodClass.GetProdcategoryByID(Convert.ToInt32(u.CategoryId));
                    objprodtype = ObjprodClass.GetProdTypeByID(Convert.ToInt32(u.TypeId));
                    objprodsupple = ObjprodClass.GetProdsupplymentByID(Convert.ToInt32(u.SupplementId));
                    Objprodcomp = ObjprodClass.GetProdcompByID(Convert.ToInt32(u.CompanyId));
                    objmed = ObjprodClass.GetProdmedicineByID(Convert.ToInt32(u.MedicineForId));
                    objoffer = ObjprodClass.GetProdOfferByID(Convert.ToInt32(u.OfferId));
                    if (objitempurchase != null && objitemsell != null & objprodctg != null
                        && objprodtype != null & objprodsupple != null && Objprodcomp != null
                        & objmed != null && objoffer != null)
                    {
                        lblprodname.Text = objitem.ItemName.ToString().Trim();
                        lblProdctg.Text = objprodctg.Name.ToString().Trim();
                        lblProdtype.Text = objprodtype.Name.ToString().Trim();
                        lblProdsupp.Text = objprodsupple.Name.ToString().Trim();
                        lblProdcomp.Text = Objprodcomp.CompanyName.ToString().Trim();
                        lblProdmedicinefor.Text = objmed.Name.ToString().Trim();
                        lblProdoffer.Text = objoffer.OfferPercent.ToString().Trim();
                        lblProdPcost.Text = objitempurchase.Cost.ToString().Trim();
                        lblProdScost.Text = objitemsell.Cost.ToString().Trim();
                        HDFID.Value = u.Id.ToString();
                        IMGProd.ImageUrl = u.ImageUrl;

                        if (u.IsActive == true)
                        {
                            IMGBTNcategoryisActive.ImageUrl = "~/images/tick.png";
                        }
                        else
                            IMGBTNcategoryisActive.ImageUrl = "~/images/close.jpg";
                    }
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
    protected void IMGBTNProdisActive_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton lnk = (ImageButton)sender;
        int userid = Convert.ToInt32(lnk.CommandArgument);
        objitem = null;
        objprod = null;
        objprod = ObjprodClass.GetProdByID(userid);
        objitem = ObjprodClass.GetItemsByID(Convert.ToInt32(objprod.ItemId));
        objitempurchase = ObjprodClass.GetItempurchaseByID(Convert.ToInt32(objprod.PurchaseId));
        objitemsell = ObjprodClass.GetItemsellByID(Convert.ToInt32(objprod.SellId));
        if (objitem != null)
        {
            TXTprod.Text = objitem.ItemName;
            DrpCategory.SelectedValue = objprod.CategoryId.ToString();
            drpcompany.SelectedValue = objprod.CompanyId.ToString();
            DrpmedicineFor.SelectedValue = objprod.MedicineForId.ToString();
            DrpOffer.SelectedValue = objprod.OfferId.ToString();
            Drpsupplement.SelectedValue = objprod.SupplementId.ToString();
            Drptype.SelectedValue = objprod.TypeId.ToString();
            txtitmpurchase.Text = objitempurchase.Cost.ToString();
            txtitmSell.Text = objitemsell.Cost.ToString();
            string url = objprod.ImageUrl.ToString().Trim();
            string[] spliturl = url.Split('/');
            TXTProdimg.Text = spliturl[2];
            errorpopheaderprod.Style.Add("display", "none");
            //DIVIsActive.Style.Add("display", "block");
            btnSubmitprod.Text = "Update";
            ViewState["popupID"] = userid.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPprodUpdate('true');});", true);
        }
    }
    #endregion

    #region Bind DropDowns
    public void binddrpdowns()
    {
        objprodctgList = ObjprodClass.GetAllProdCategories();
        Objprodcomplist = ObjprodClass.GetAllProdCompanies();
        objprodmedList = ObjprodClass.GetAllProdmedicines();
        objprodtypeList = ObjprodClass.GetAllProdType();
        objprodsupplyList = ObjprodClass.GetAllProdSupplyment();
        objprodofferList = ObjprodClass.GetAllProdOffer();
        DrpCategory.DataSource = objprodctgList;
        DrpCategory.DataTextField = "Name";
        DrpCategory.DataValueField = "ID";
        DrpCategory.DataBind();
        DrpCategory.Items.Insert(0, new ListItem("--Select Category--", "0"));

        drpcompany.DataSource = ObjprodClass.GetAllProdCompanies();
        drpcompany.DataTextField = "CompanyName";
        drpcompany.DataValueField = "ID";
        drpcompany.DataBind();
        drpcompany.Items.Insert(0, new ListItem("--Select Company--", "0"));

        Drptype.DataSource = ObjprodClass.GetAllProdType();
        Drptype.DataTextField = "Name";
        Drptype.DataValueField = "ID";
        Drptype.DataBind();
        Drptype.Items.Insert(0, new ListItem("--Select Type--", "0"));

        Drpsupplement.DataSource = ObjprodClass.GetAllProdSupplyment();
        Drpsupplement.DataTextField = "Name";
        Drpsupplement.DataValueField = "ID";
        Drpsupplement.DataBind();
        Drpsupplement.Items.Insert(0, new ListItem("--Select SupplyMent--", "0"));

        DrpmedicineFor.DataSource = ObjprodClass.GetAllProdmedicines();
        DrpmedicineFor.DataTextField = "Name";
        DrpmedicineFor.DataValueField = "ID";
        DrpmedicineFor.DataBind();
        DrpmedicineFor.Items.Insert(0, new ListItem("--Select Medicinefor--", "0"));

        DrpOffer.DataSource = ObjprodClass.GetAllProdOffer();
        DrpOffer.DataTextField = "Offerpercent";
        DrpOffer.DataValueField = "ID";
        DrpOffer.DataBind();
        DrpOffer.Items.Insert(0, new ListItem("--Select Offer--", "0"));
    }
    #endregion

    #region Button Click
    protected void lnkAddNewprod_Click(object sender, EventArgs e)
    {

        errorpopheaderprod.Style.Add("display", "none");
        btnSubmitprod.Text = "Submit";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPprodtable('false');});", true);
    }
    protected void btnSubmitprod_Click(object sender, EventArgs e)
    {
        //objitem = null;
        //objitempurchase = null;
        //objitemsell = null;
        //objitem = null;
        switch (btnSubmitprod.Text)
        {
            case "Submit":
                if (file_upload.HasFile)
                {
                    objitem.ItemName = TXTprod.Text.ToString().Trim();
                    objitem.CreatedDate = DateTime.Now;
                    objitem.IsActive = true;
                    objitempurchase.Cost = Convert.ToInt64(txtitmpurchase.Text.Trim());
                    objitempurchase.IsActive = true;
                    objitempurchase.CreatedDate = DateTime.Now;
                    objitemsell.Cost = txtitmSell.Text.Trim();
                    objitemsell.Createdate = DateTime.Now;
                    objitemsell.CostVary = Convert.ToDecimal(Convert.ToInt32(txtitmSell.Text.Trim()) - Convert.ToInt32(txtitmpurchase.Text.Trim()));
                    objprod.CategoryId = Convert.ToInt32(DrpCategory.SelectedItem.Value);
                    objprod.CompanyId = Convert.ToInt32(drpcompany.SelectedItem.Value);
                    objprod.TypeId = Convert.ToInt32(Drptype.SelectedItem.Value);
                    objprod.SupplementId = Convert.ToInt32(Drpsupplement.SelectedItem.Value);
                    objprod.MedicineForId = Convert.ToInt32(DrpmedicineFor.SelectedItem.Value);
                    if (DrpOffer.SelectedItem.Value == "0")
                    {
                        objprod.OfferId = 1;
                    }
                    else
                    {
                        objprod.OfferId = Convert.ToInt32(DrpOffer.SelectedItem.Value);
                    }
                    objprod.IsActive = true;
                    objprod.CreatedDate = DateTime.Now;
                    //Get Filename from fileupload control
                    string filename = Path.GetFileName(file_upload.PostedFile.FileName);
                    //Save images into Images folder
                    file_upload.SaveAs(Server.MapPath("~/ProdImages/" + filename));
                    objprod.ImageUrl = "~/ProdImages/" + filename;
                    Status = null;
                    Status = ObjprodClass.insertProd(objitem, objitempurchase, objitemsell, objprod);
                    if (Status == "Information Insert successfully.")
                    {
                        errorpopheaderprod.Visible = true;
                        errorpopheaderprod.Style.Add("display", "block");
                        errorpopheaderprod.Attributes.Add("class", "fk-msg-success");
                        errorpopheaderprod.InnerHtml = "ProductType Inserted successfully";
                        binddrpdowns();
                        BindProdGrid();
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPprodtable('false');});", true);
                    }
                    else
                    {
                        errorpopheaderprod.Visible = true;
                        errorpopheaderprod.Style.Add("display", "block");
                        errorpopheaderprod.Attributes.Add("class", "fk-err-all");
                        errorpopheaderprod.InnerHtml = Status;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPprodtable('true');});", true);
                    }


                }
                break;
            case "Update":
                if (ViewState["popupID"] != null && ViewState["popupID"] != "")
                {
                    objprod = null;
                    objitem = null;
                    objitempurchase = null;
                    objitemsell = null;
                    objprod = ObjprodClass.GetProdByID(Convert.ToInt32(ViewState["popupID"]));
                    objitem = ObjprodClass.GetItemsByID(Convert.ToInt32(objprod.ItemId));
                    objitempurchase = ObjprodClass.GetItempurchaseByID(Convert.ToInt32(objprod.PurchaseId));
                    objitemsell = ObjprodClass.GetItemsellByID(Convert.ToInt32(objprod.SellId));

                    objitem.ItemName = TXTprod.Text.ToString().Trim();
                    objitem.Modifieddate = DateTime.Now;
                    objitem.IsActive = true;
                    objitempurchase.Cost = Convert.ToInt64(txtitmpurchase.Text.Trim());
                    objitempurchase.IsActive = true;
                    objitempurchase.Modifieddate = DateTime.Now;
                    objitemsell.Cost = txtitmSell.Text.Trim();
                    objitemsell.ModifiedDate = DateTime.Now;
                    objitemsell.CostVary = Convert.ToDecimal(Convert.ToInt32(txtitmSell.Text.Trim()) - Convert.ToInt32(txtitmpurchase.Text.Trim()));
                    objprod.CategoryId = Convert.ToInt32(DrpCategory.SelectedItem.Value);
                    objprod.CompanyId = Convert.ToInt32(drpcompany.SelectedItem.Value);
                    objprod.TypeId = Convert.ToInt32(Drptype.SelectedItem.Value);
                    objprod.SupplementId = Convert.ToInt32(Drpsupplement.SelectedItem.Value);
                    objprod.MedicineForId = Convert.ToInt32(DrpmedicineFor.SelectedItem.Value);
                    if (DrpOffer.SelectedItem.Value == "0")
                    {
                        objprod.OfferId = 1;
                    }
                    else
                    {
                        objprod.OfferId = Convert.ToInt32(DrpOffer.SelectedItem.Value);
                    }
                    objprod.IsActive = true;
                    objprod.ModifiedDate = DateTime.Now;
                    //Get Filename from fileupload control
                    //string filename = Path.GetFileName(file_upload.PostedFile.FileName);
                    ////Save images into Images folder
                    
                    objprod.ImageUrl = "~/ProdImages/" + TXTProdimg.Text;
                    file_upload.SaveAs(Server.MapPath("~/ProdImages/" + TXTProdimg.Text));
                    Status = null;
                    Status = ObjprodClass.UpdateProd(objitem, objitempurchase, objitemsell, objprod);
                    if (Status == "Information Update successfully.")
                    {
                        errorpopheaderprod.Visible = true;
                        errorpopheaderprod.Style.Add("display", "block");
                        errorpopheaderprod.Attributes.Add("class", "fk-msg-success");
                        errorpopheaderprod.InnerHtml = "Product Updated successfully";
                        
                        BindProdGrid();
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPupdateprodtable('true');});", true);
                    }
                    else
                    {
                        errorpopheaderprod.Visible = true;
                        errorpopheaderprod.Style.Add("display", "block");
                        errorpopheaderprod.Attributes.Add("class", "fk-err-all");
                        errorpopheaderprod.InnerHtml = Status;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPupdateprodtable('true');});", true);
                    }



                }
                break;
        }
    }
    #endregion
}
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

public partial class ADMIN_OrderDashBoard : System.Web.UI.Page
{
    TList<Orders> objorders = new TList<Orders>();
    TList<OrderStatus> objOrderstatuslist = new TList<OrderStatus>();
    OrderStatus objordstatus = new OrderStatus();
    Order objorderclass = new Order();
    string Status;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            errorPopup.Style.Add("display", "none");
            //block
            errorPopup.Attributes.Add("class", "fk-err-all");
            if (Session["UserName"] != null)
            {
                BindAllGrid();
            }
        }

    }
    private void BindAllGrid()
    {
        objOrderstatuslist = objorderclass.GetallOrderStatus();
        grdOrdstatus.DataSource = objOrderstatuslist;
        grdOrdstatus.DataBind();
    }
    protected void btnSubmit_Click1(object sender, EventArgs e)
    {
        string Ordname = TXTOrdstas.Text;
        if (Ordname != null)
        {
            objordstatus.Name = Ordname.ToString();
            objordstatus.CreatedDate = DateTime.Now;
            switch (btnSubmit.Text.Trim())
            {
                case "Submit":
                    ViewState["popupID"] = null;
                    Status = objorderclass.insertOrderStatus(objordstatus);
                    if (Status == "Information Insert successfully.")
                    {
                        errorPopup.Visible = true;
                        errorPopup.Style.Add("display", "block");
                        errorPopup.Attributes.Add("class", "fk-msg-success");
                        errorPopup.InnerHtml = "OrderStatus Inserted successfully";
                        BindAllGrid();
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUP('true');});", true);
                    }
                    else
                    {
                        errorPopup.Visible = true;
                        errorPopup.Style.Add("display", "block");
                        errorPopup.Attributes.Add("class", "fk-err-all");
                        errorPopup.InnerHtml = Status;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUP('true');});", true);
                    }
                    break;
                case "Update":
                    if (ViewState["popupID"] != null && ViewState["popupID"] != "")
                    {
                        objordstatus = null;
                        objordstatus = objorderclass.GetStatusByID(Convert.ToInt32(ViewState["popupID"]));
                        objordstatus.Name = Ordname.ToString();
                        if (ChkIsActive.Checked)
                            objordstatus.IsActive = true;
                        else
                            objordstatus.IsActive = false;
                        Status = objorderclass.UpdateOrderStatus(objordstatus);
                        if (Status == "Information Update successfully.")
                        {
                            errorPopup.Visible = true;
                            errorPopup.Style.Add("display", "block");
                            errorPopup.Attributes.Add("class", "fk-msg-success");
                            errorPopup.InnerHtml = "OrderStatus Updated successfully";
                            BindAllGrid();
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPUpdate('true');});", true);
                        }
                        else
                        {
                            errorPopup.Visible = true;
                            errorPopup.Style.Add("display", "block");
                            errorPopup.Attributes.Add("class", "fk-err-all");
                            errorPopup.InnerHtml = Status;
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPUpdate('true');});", true);
                        }
                    }
                    break;
            }


        }
    }
    #region Row DataBound
    protected void grdOrdstatus_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
        {
            try
            {
                GridViewRow gr = e.Row;
                Label lblOrderStatusName = (Label)gr.FindControl("lblOrdStatusname");
                HiddenField HDFID = (HiddenField)gr.FindControl("HDFOrderStatsID");
                ImageButton IMGBTNOrdStatusisActive = (ImageButton)gr.FindControl("IMGBTNOrdStatusisActive");
                OrderStatus u = e.Row.DataItem as OrderStatus;
                lblOrderStatusName.Text = u.Name.Trim().ToString();
                HDFID.Value = u.Id.ToString();
                if (u.IsActive == true)
                {
                    IMGBTNOrdStatusisActive.ImageUrl = "../images/tick.png";
                }
                else
                    IMGBTNOrdStatusisActive.ImageUrl = "../images/close.jpg";
            }
            catch
            {
            }
        }
    }
    #endregion

    #region Link Active OR Deactive

    protected void IMGBTNOrdStatusisActive_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton lnk = (ImageButton)sender;
        int userid = Convert.ToInt32(lnk.CommandArgument);
        objordstatus = null;
        objordstatus = objorderclass.GetStatusByID(userid);
        if (objordstatus != null)
        {
            if (objordstatus.IsActive == true)
                ChkIsActive.Checked = true;
            TXTOrdstas.Text = objordstatus.Name;
            errorPopup.Style.Add("display", "none");
            DIVIsActive.Style.Add("display", "block");
            btnSubmit.Text = "Update";
            ViewState["popupID"] = userid.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "aa", "jQuery(document).ready(function(){ShowPOPUPUpdate('true');});", true);
        }
    }
    #endregion
}
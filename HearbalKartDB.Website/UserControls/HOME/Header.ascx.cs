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

public partial class UserControls_HOME_Header : System.Web.UI.UserControl
{
    /// <summary>
    /// Handles the Load event of the Page class.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    AccountValidation objaccount = new AccountValidation();
    Customers objcust = new Customers();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //errorpopheader.Style.Add("display", "none");
            //errorpopheader.Attributes.Add("class", "fk-err-all");
        }
    }
    protected void btnSubmitLgn_Click(object sender, EventArgs e)
    {
        //String Email = TXTEmail.Text;
        //String Pass = TXTPassword.Text;
        //if (Email != null && Pass != null)
        //{
        //    objcust = objaccount.validateUser(Email, Pass);
        //    if (objcust != null)
        //    {

        //        switch (objcust.UserType)
        //        {
        //            case (int)Usertypes.Superadmin:
        //                Session["UserName"] = Email;
        //                Response.Redirect("~/ADMIN/DashBoard.aspx", false);
        //                break;
        //            case (int) Usertypes.Customer:
        //                break;
        //        }
                
        //    }
        //}
        Response.Redirect("~/Default.aspx", false);

    }
}
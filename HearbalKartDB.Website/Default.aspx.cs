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

namespace HearbalKartDB.Website
{
	public partial class _Default : System.Web.UI.Page 
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
		}
        protected void btnSub_Click(object sender, EventArgs e)
        {
            String UserName = TxtUser.Text;
            String Pass = Txtpass.Text;
            if (UserName != null && Pass != null)
            {
                objcust = objaccount.validateUser(UserName, Pass);
                if (objcust != null)
                {
                    Session["UserName"] = UserName;
                    Response.Redirect("~/ADMIN/DashBoard.aspx", false);
                }
            }

        }
}
}

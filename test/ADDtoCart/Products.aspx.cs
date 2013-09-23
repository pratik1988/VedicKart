using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class Products : System.Web.UI.Page
{
   SqlConnection con = new SqlConnection();
SqlDataAdapter adp = new SqlDataAdapter();
SqlCommand cmd;
DataTable tb;

DataTable dt = new DataTable();

//string a, b;
//string a, save, fn, b, aguid,fn1,aguid1,save1;
private PagedDataSource pagedData = new PagedDataSource();
decimal last1;
Int32 count, no;

protected void Page_Load(object sender, EventArgs e)
{

con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
try
{
con.Open();
//TeSection_txt.Text = Request.QueryString["a"].ToString();

if (Page.IsPostBack == false)
{
try
{

    getTheData();

}
catch
{

}
}
}
catch
{
if (con.State == ConnectionState.Closed)
{
con.Open();
}
}
con.Close();

}

//fetching the records

public DataTable getTheData()
{

dt = new DataTable();
adp = new SqlDataAdapter("select * from tbl_Product", con);

adp.Fill(dt);
adp.Dispose();
DataList1.DataSource = dt;
DataList1.DataBind();
if (dt.Rows.Count == 0)
{
//lbl_msg.Text = "Gallery is empty ";
}
else
{
Session["cnt"] = Convert.ToInt32((dt.Rows.Count));

}
return dt;
}



}


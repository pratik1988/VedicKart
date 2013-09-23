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

public partial class Shopping_Cart : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(); // for connection
    SqlDataAdapter adp = new SqlDataAdapter();  // for fetch the records acc. to condition
    DataTable dt = new DataTable(); // fill the fetched records
    DataTable tb; // will store the session
    TextBox txt_qty; // for Product Quantity
    Label lb_Footer_total = null; // for total Product Price
    DataRowView r; // for Datarows

    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        try
        {
            con.Open();
        }
        catch
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        finally
        {
            con.Close();
        }

        try
        {
            if (Session["ss"] != null) // first attempt to check whether the session is null or not
            {
            }
            else
            {
                //will create a temporary datatable for shopping cart
                //*NOTE column name must be same as in database table
                DataTable shop = new DataTable("Table"); // create a dataTable name shop ["Table"] always be same.

                // declare the columns name according to your need.
                shop.Columns.Add(new DataColumn("id", Type.GetType("System.Int32")));
                shop.Columns.Add(new DataColumn("title", Type.GetType("System.String")));
                shop.Columns.Add(new DataColumn("product_code", Type.GetType("System.String")));
                shop.Columns.Add(new DataColumn("our_price", Type.GetType("System.Int32")));
                shop.Columns.Add(new DataColumn("quantity", Type.GetType("System.Int32")));
                shop.Columns.Add(new DataColumn("total", Type.GetType("System.Decimal")));
                shop.Columns["total"].Expression = "our_price*quantity";

                Session["ss"] = shop;  // storing in sessi on

            }
        }

        catch (Exception ex)
        {
        }

        if (!IsPostBack)
        {
            try
            {
                adp = new SqlDataAdapter("select * from tbl_Product where id=@id", con); // will fetch the record acc. to product id
                adp.SelectCommand.Parameters.AddWithValue("@id", Convert.ToInt32(Request.QueryString["cart_id"])); // query string of product id.
                dt = new DataTable();
                adp.Fill(dt);
                adp.Dispose();

                r = dt.DefaultView[0]; // creating DataRow
                tb = (DataTable)(Session["ss"]);

                // ***************** will append the same id with Quantity. it will not insert if the same product id request  *************************//
                Int32 a = tb.Rows.Count; int i;
                for (i = 0; i <= a - 1; i += 1)
                {
                    Int32 t = Convert.ToInt32(tb.Rows[i][0]);
                    if (t == Convert.ToInt32(Request.QueryString["cart_id"]))
                    {
                        int k = 1;//Convert.ToInt32(Session["quantity"]);
                        int k1 = Convert.ToInt32(tb.Rows[i][4]); // column no. of datatable for Qty.
                        k1 = k1 + k;  // adding qty.
                        tb.Rows[i][4] = k1; // adding with previous value.

                        GridView1.DataSource = tb; // displaying the records in Gridview
                        GridView1.DataBind();

                        lb_Footer_total = (Label)(GridView1.FooterRow.FindControl("lbl_total")); //*** binding footer control with total.
                        lb_Footer_total.Text = tb.Compute("sum(total)", "").ToString();
                        grdview(); // refreshing the data in gridview
                        return;
                    }
                }

            }
            catch
            { }

            DataRow r1; // declaring for Rows

            r1 = tb.NewRow(); // assigning and creating the  New Row

            r1[0] = Convert.ToInt32(r["id"]); // database columns name after fetching the records acc. to Product ID.
            r1[1] = r["title"].ToString();
            r1[2] = r["product_code"].ToString();
            r1[3] = Convert.ToInt32(r["our_price"]);
            //r1[4] = Session["color"]; // here you can use your column name using session. coming from product page
            r1[4] = 1; //default will be one

            tb.Rows.Add(r1); // Adding the rows

            GridView1.DataSource = tb; // displaying the records in Gridview
            GridView1.DataBind();

            for (int k = 0; k <= tb.Rows.Count - 1; k++)
            {
                txt_qty = (TextBox)(GridView1.Rows[k].FindControl("txt_qty")); // finding textbox for binding in G.View
                txt_qty.Text = (tb.Rows[k][4].ToString()); //*** this the 6th column of Temp. table for manipulating the Quantity of products ***//
            }

            dt.Dispose();

            lb_Footer_total = (Label)(GridView1.FooterRow.FindControl("lbl_total")); //*** binding footer control with total.
            lb_Footer_total.Text = tb.Compute("sum(total)", "").ToString();

            // Optional label out side the gridview.
            // lbl_total.Text = tb.Compute("sum(total)", "").ToString(); // computing the total of all products

        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            tb = (DataTable)Session["ss"];
            tb.Rows.RemoveAt(e.RowIndex); // deleting the current record in Temporary table
            grdview();
        }
        catch
        { }
    }

    private void grdview()
    {
        tb = (DataTable)Session["ss"];
        if (tb.Rows.Count == 0) // if no record found
        {
            lbl_total.Text = "Your Shopping Cart is Empty";

            GridView1.DataSource = tb;
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = tb;
            GridView1.DataBind();

            for (int k = 0; k <= tb.Rows.Count - 1; k++)
            {
                txt_qty = (TextBox)(GridView1.Rows[k].FindControl("txt_qty")); // finding drodown for binding in G.View
                // you can use any control i have used TEXTBOX for Qty u can use DropDownlist etc.
                txt_qty.Text = (tb.Rows[k][4].ToString()); //*** this the 6th column of Temp. table for manipulating the Quantity of products ***//

            }

            lb_Footer_total = (Label)(GridView1.FooterRow.FindControl("lbl_total")); //*** binding footer control with total.
            lb_Footer_total.Text = tb.Compute("sum(total)", "").ToString();

        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "abc") // I have used GridView Rowcommand to UPDATE the Product from shopping cart.
        {
            tb = (DataTable)Session["ss"];
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                txt_qty = (TextBox)(GridView1.Rows[i].FindControl("txt_qty"));
                tb.Rows[i][4] = txt_qty.Text; //*** this the 6th column of Temp. table for manipulating the Quantity of products ***//
            }
            grdview();
        }
    }

}
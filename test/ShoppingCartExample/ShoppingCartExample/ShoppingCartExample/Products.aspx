<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Products</title>
</head>
<body>
    <form id="form1" runat="server">
         <br />
        <div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                SelectCommand="SELECT [ProductID], [Name], [Description], [Price], [ImageUrl] FROM [Products]">
            </asp:SqlDataSource>
        </div>
        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" RepeatColumns="4"
            RepeatDirection="Horizontal">
            <ItemTemplate>
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# Eval("ImageUrl", "Images\\thumb_{0}") %>' PostBackUrl='<%# Eval("ProductID", "ProductDetails.aspx?ProductID={0}") %>' /><br />
                <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>'></asp:Label><br />
                <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price", "{0:C}") %>'></asp:Label><br />
                <br />
                <br />
            </ItemTemplate>
        </asp:DataList><br />
        <asp:HyperLink ID="CartLink" runat="server" NavigateUrl="~/UserCart.aspx">View Shopping Cart</asp:HyperLink><br />
        &nbsp;<br />
        .<br />
           </form>
</body>
</html>

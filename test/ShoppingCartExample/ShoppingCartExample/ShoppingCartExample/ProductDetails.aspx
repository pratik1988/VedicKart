<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductDetails.aspx.cs" Inherits="ProductDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Product Details</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT [ProductID], [Name], [Description], [Price], [ImageUrl] FROM [Products] WHERE ([ProductID] = @ProductID)">
            <SelectParameters>
                <asp:QueryStringParameter Name="ProductID" QueryStringField="ProductID" Type="Decimal" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1">
            <ItemTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("ImageUrl", "~/Images\\{0}") %>' /><br />
                <asp:Label ID="ImageUrlLabel" runat="server" Text='<%# Eval("ImageUrl") %>' Visible="False"></asp:Label><br />
                <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>'></asp:Label><br />
                <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>'></asp:Label><br />
                <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price", "{0:##0.00}" ) %>'></asp:Label><br />
                <br />
                <br />
            </ItemTemplate>
        </asp:DataList><br />
        <asp:Button ID="btnAdd" runat="server" OnClick="Button1_Click" Text="Add to Cart" /><br />
        <br />
        &nbsp;<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Products.aspx">Return to Products Page</asp:HyperLink>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Products" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" DataKeyField="id"
                CellPadding="15" Width="508px">
                <ItemTemplate>
                    <a href='Shopping_Cart.aspx?cart_id=<%# Eval("id") %>'>
                        <img alt="" src='<%#Eval("Image") %>' /><br />
                    </a>
                    <h4>
                        <asp:Label ID="lb" runat="server" Font-Bold="True" Font-Size="12pt" Text='<%# Eval("Title") %>'></asp:Label><br />
                        Product Code: <span><%# Eval("product_code") %></span></h4>
                    <span><del>&#2352;</del><%# Eval("Our_price") %> INR</span><br />
                    <a href="Shopping_Cart.aspx?cart_id=<%# Eval("id") %>">Add to Cart</a>


                </ItemTemplate>
            </asp:DataList>
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Shopping_Cart.aspx.cs" Inherits="Shopping_Cart" %>

<!DOCTYPE html>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Products.aspx">Continue Shopping</asp:LinkButton>
            <br />
            <br />
            <br />

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                OnRowDeleting="GridView1_RowDeleting" OnRowCommand="GridView1_RowCommand"
                ShowFooter="True">
                <Columns>

                    <asp:TemplateField HeaderText="Details">
                        <ItemTemplate>
                            <span><%# Eval("title") %></span> (<span><%# Eval("product_code") %></span>)
                            <br />

                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Item Price">
                        <ItemTemplate>
                            <del>र</del> <%# Eval("our_price") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:TextBox ID="txt_qty" runat="server"></asp:TextBox>
                        </ItemTemplate>
                        <FooterTemplate>
                            Total:
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Total">
                        <FooterTemplate>
                            <asp:Label ID="lbl_total" runat="server" Font-Bold="True"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <del>र</del> <%# Eval("Total") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <FooterTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="abc">Update</asp:LinkButton>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CommandName="delete" Style="text-align: right"
                                ImageUrl="~/images/close.jpg" Height="24px" Width="24px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle HorizontalAlign="Left" />

            </asp:GridView>
            <asp:Label ID="lbl_total" runat="server" ForeColor="#CC0000"></asp:Label>
        </div>
    </form>
</body>
</html>

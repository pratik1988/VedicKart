<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminMenu.ascx.cs" Inherits="UserControls_ADMIN_AdminMenu" %>
<ul class="dropdown">
    <li>
        <asp:LinkButton ID="hyperlink1" runat="server" PostBackUrl="~/ADMIN/DashBoard.aspx">Dashboard</asp:LinkButton>
    </li>
    <li>
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/ADMIN/CustomerDashboard.aspx">Customers DashBoard</asp:LinkButton>
        <%--<ul class="sub_menu">
            <li><a href="#">All-in-One Team Cart</a></li>
            <li><a href="#">Air &amp; Electrical Reels</a></li>
            <li><a href="#">Field Drags</a></li>
            <li><a href="#" class="right_arrow">Field Marking Equipment</a> </li>
            <a href="#" class="right_arrow">Field Tarps</a>
        </ul>--%>
    </li>
    <li>
        <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/ADMIN/OrderDashBoard.aspx">Orders DashBoard</asp:LinkButton>
    </li>
    <li>
        <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="~/ADMIN/ProductDashBoard.aspx">Products DashBoard</asp:LinkButton>
    </li>
</ul>

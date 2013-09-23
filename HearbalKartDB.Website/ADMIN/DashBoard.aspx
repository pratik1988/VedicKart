<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN/Admin.master" AutoEventWireup="true"
    CodeFile="DashBoard.aspx.cs" Inherits="ADMIN_DashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="Styles/css/popupstyle.css" rel="stylesheet" type="text/css" />
    <script src="Styles/js/lib.js" type="text/javascript"></script>
    <script src="Styles/js/main.js" type="text/javascript"></script>
    <div class="cph">
        <div class="section-title">
            <img src="../images/ico-dashboard.png" />
            Dashboard
        </div>
        <table class="dashboard">
            <tr>
                <td class="maincol">
                    <div class="section-header">
                        <div class="title">
                            <img src="../images/ico-stat1.gif" alt="" />
                            Store Statistics
                        </div>
                    </div>
                    <table class="stats">
                        <tbody>
                            <tr>
                                <td class="orderaveragereport">
                                    <div class="statisticsTitle">
                                        Order totals
                                    </div>
                                    <div class="adminContent">
                                        <asp:GridView ID="grdOrdtotal" CssClass="t-widget t-grid" runat="server" Width="100%" AutoGenerateColumns="False"
                                            RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle" CellPadding="0"
                                            CellSpacing="1" EmptyDataText="No record Found!" EmptyDataRowStyle-Font-Bold="true"
                                            EmptyDataRowStyle-HorizontalAlign="Center" EditRowStyle-VerticalAlign="Top" AllowPaging="true"
                                            RowStyle-CssClass="con" AlternatingRowStyle-CssClass="con-dark" GridLines="None"
                                            PageSize="10" BackColor="#ffffff" ShowHeader="true"
                                            OnRowDataBound="grdstaff_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                                                    <HeaderTemplate>
                                                        Order Status
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOrdStatus" runat="server" CssClass="t-alt"></asp:Label>
                                                    </ItemTemplate>
                                                    <AlternatingItemTemplate>
                                                        <asp:Label ID="lblOrdStatus" runat="server" CssClass="t-alt"></asp:Label>
                                                    </AlternatingItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                                                    <HeaderTemplate>
                                                        Today
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOrdStatustoday" runat="server" CssClass="t-alt"></asp:Label>
                                                    </ItemTemplate>
                                                    <AlternatingItemTemplate>
                                                        <asp:Label ID="lblOrdStatustoday" runat="server" CssClass="t-alt"></asp:Label>
                                                    </AlternatingItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                                                    <HeaderTemplate>
                                                        This Week
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOrdStatusweek" runat="server" CssClass="t-alt"></asp:Label>
                                                    </ItemTemplate>
                                                    <AlternatingItemTemplate>
                                                        <asp:Label ID="lblOrdStatusweek" runat="server" CssClass="t-alt"></asp:Label>
                                                    </AlternatingItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                                                    <HeaderTemplate>
                                                        This Month
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOrdStatusmonth" runat="server" CssClass="t-alt"></asp:Label>
                                                    </ItemTemplate>
                                                    <AlternatingItemTemplate>
                                                        <asp:Label ID="lblOrdStatusmonth" runat="server" CssClass="t-alt"></asp:Label>
                                                    </AlternatingItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                                                    <HeaderTemplate>
                                                        This Year
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOrdStatusyear" runat="server" CssClass="t-alt"></asp:Label>
                                                    </ItemTemplate>
                                                    <AlternatingItemTemplate>
                                                        <asp:Label ID="lblOrdStatusyear" runat="server" CssClass="t-alt"></asp:Label>
                                                    </AlternatingItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                                                    <HeaderTemplate>
                                                        All Time
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOrdStatusalltime" runat="server" CssClass="t-alt"></asp:Label>
                                                    </ItemTemplate>
                                                    <AlternatingItemTemplate>
                                                        <asp:Label ID="lblOrdStatusalltime" runat="server" CssClass="t-alt"></asp:Label>
                                                    </AlternatingItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EditRowStyle VerticalAlign="Top"></EditRowStyle>
                                            <EmptyDataRowStyle HorizontalAlign="Center" Font-Bold="True"></EmptyDataRowStyle>
                                            <EmptyDataTemplate>
                                                <table>
                                                    <tr>
                                                        <td colspan="3" align="center">
                                                            <b>No record found !</b>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </EmptyDataTemplate>                                       
                                            <PagerTemplate>
                                                <div class="t-grid-pager t-grid-bottom">
                                                        <div class="t-status">
                                                            <a class="t-icon t-refresh" href="#">Refresh</a></div>
                                                    </div>
                                            </PagerTemplate>
                                            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle"></RowStyle>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <table class="stats">
                        <tbody>
                            <tr>
                                <td class="orderstatistics">
                                    <div class="statisticsTitle">
                                        Incomplete orders
                                    </div>
                                    <table class="adminContent">
                                        <tr>
                                            <td>
                                                <div class="t-widget t-grid" id="incomplete-order-report-grid">
                                                    <table cellspacing="0">
                                                        <thead class="t-grid-header">
                                                            <tr>
                                                                <th class="t-header" scope="col">
                                                                    <span class="t-link">Item</span>
                                                                </th>
                                                                <th class="t-header" scope="col">
                                                                    <span class="t-link">Total</span>
                                                                </th>
                                                                <th class="t-header" scope="col">
                                                                    <span class="t-link">Count</span>
                                                                </th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    Total unpaid orders (pending payment status)
                                                                </td>
                                                                <td>
                                                                    $1,952.00
                                                                </td>
                                                                <td>
                                                                    3
                                                                </td>
                                                            </tr>
                                                            <tr class="t-alt">
                                                                <td>
                                                                    Total not yet shipped orders
                                                                </td>
                                                                <td>
                                                                    $3,454.56
                                                                </td>
                                                                <td>
                                                                    5
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Total incomplete orders (pending order status)
                                                                </td>
                                                                <td>
                                                                    $1,952.00
                                                                </td>
                                                                <td>
                                                                    3
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                    <div class="t-grid-pager t-grid-bottom">
                                                        <div class="t-status">
                                                            <a class="t-icon t-refresh" href="/Admin/Order/OrderIncompleteReport?incomplete-order-report-grid-size=0">
                                                                Refresh</a></div>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="customerstatistics">
                                    <div class="statisticsTitle">
                                        Registered customers</div>
                                    <table class="adminContent">
                                        <tr>
                                            <td>
                                                <div class="t-widget t-grid" id="registered-customers-grid">
                                                    <table cellspacing="0">
                                                        <thead class="t-grid-header">
                                                            <tr>
                                                                <th class="t-header" scope="col">
                                                                    <span class="t-link">Period</span>
                                                                </th>
                                                                <th class="t-header" scope="col">
                                                                    <span class="t-link">Count</span>
                                                                </th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    In the last 7 days
                                                                </td>
                                                                <td>
                                                                    0
                                                                </td>
                                                            </tr>
                                                            <tr class="t-alt">
                                                                <td>
                                                                    In the last 14 days
                                                                </td>
                                                                <td>
                                                                    0
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    In the last month
                                                                </td>
                                                                <td>
                                                                    0
                                                                </td>
                                                            </tr>
                                                            <tr class="t-alt">
                                                                <td>
                                                                    In the last year
                                                                </td>
                                                                <td>
                                                                    0
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                    <div class="t-grid-pager t-grid-bottom">
                                                        <div class="t-status">
                                                            <a class="t-icon t-refresh" href="#">Refresh</a></div>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <table class="stats">
                        <tr>
                            <td class="bestsellers">
                                <div class="statisticsTitle">
                                    Bestsellers by quantity</div>
                                <table class="adminContent">
                                    <tr>
                                        <td>
                                            <div class="t-widget t-grid" id="bestsellers-byquantity-grid">
                                                <div class="t-grid-pager t-grid-top">
                                                    <div class="t-status">
                                                        <a class="t-icon t-refresh" href="#">Refresh</a></div>
                                                    <div class="t-pager t-reset">
                                                        <a class="t-link t-state-disabled" href="#"><span class="t-icon t-arrow-first">first</span></a>
                                                        <a class="t-link t-state-disabled" href="#"><span class="t-icon t-arrow-prev">prev</span></a>
                                                        <div class="t-numeric">
                                                            <span class="t-state-active">1</span>
                                                        </div>
                                                        <a class="t-link t-state-disabled" href="#"><span class="t-icon t-arrow-next">next</span>
                                                        </a><a class="t-link t-state-disabled" href="#"><span class="t-icon t-arrow-last">last</span>
                                                        </a>
                                                    </div>
                                                    <div class="t-status-text">
                                                        Displaying items 0 - 0 of 0</div>
                                                </div>
                                                <table cellspacing="0">
                                                    <thead class="t-grid-header">
                                                        <tr>
                                                            <th class="t-header" scope="col">
                                                                <span class="t-link">Name</span>
                                                            </th>
                                                            <th class="t-header" scope="col">
                                                                <span class="t-link">Total quantity</span>
                                                            </th>
                                                            <th class="t-header" scope="col">
                                                                <span class="t-link">Total amount (excl tax)</span>
                                                            </th>
                                                            <th class="t-header" scope="col" style="text-align: center;">
                                                                <span class="t-link">View</span>
                                                            </th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr class="t-no-data">
                                                            <td colspan="4">
                                                                No records to display.
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <div class="t-grid-pager t-grid-bottom">
                                                    <div class="t-status">
                                                        <a class="t-icon t-refresh" href="#">Refresh</a></div>
                                                    <div class="t-pager t-reset">
                                                        <a class="t-link t-state-disabled" href="#"><span class="t-icon t-arrow-first">first</span></a>
                                                        <a class="t-link t-state-disabled" href="#"><span class="t-icon t-arrow-prev">prev</span></a>
                                                        <div class="t-numeric">
                                                            <span class="t-state-active">1</span></div>
                                                        <a class="t-link t-state-disabled" href="#"><span class="t-icon t-arrow-next">next</span></a><a
                                                            class="t-link t-state-disabled" href="#"><span class="t-icon t-arrow-last">last</span></a>
                                                    </div>
                                                    <div class="t-status-text">
                                                        Displaying items 0 - 0 of 0</div>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td class="bestsellers">
                                <div class="statisticsTitle">
                                    Bestsellers by amount
                                </div>
                                <table class="adminContent">
                                    <tr>
                                        <td>
                                            <div class="t-widget t-grid" id="bestsellers-byamount-grid">
                                                <div class="t-grid-pager t-grid-top">
                                                    <div class="t-status">
                                                        <a class="t-icon t-refresh" href="#">Refresh</a></div>
                                                    <div class="t-pager t-reset">
                                                        <a class="t-link t-state-disabled" href="#"><span class="t-icon t-arrow-first">first</span></a>
                                                        <a class="t-link t-state-disabled" href="#"><span class="t-icon t-arrow-prev">prev</span></a>
                                                        <div class="t-numeric">
                                                            <span class="t-state-active">1</span></div>
                                                        <a class="t-link t-state-disabled" href="#"><span class="t-icon t-arrow-next">next</span></a>
                                                        <a class="t-link t-state-disabled" href="#"><span class="t-icon t-arrow-last">last</span></a>
                                                    </div>
                                                    <div class="t-status-text">
                                                        Displaying items 0 - 0 of 0</div>
                                                </div>
                                                <table cellspacing="0">
                                                    <thead class="t-grid-header">
                                                        <tr>
                                                            <th class="t-header" scope="col">
                                                                <span class="t-link">Name</span>
                                                            </th>
                                                            <th class="t-header" scope="col">
                                                                <span class="t-link">Total quantity</span>
                                                            </th>
                                                            <th class="t-header" scope="col">
                                                                <span class="t-link">Total amount (excl tax)</span>
                                                            </th>
                                                            <th class="t-header" scope="col" style="text-align: center;">
                                                                <span class="t-link">View</span>
                                                            </th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr class="t-no-data">
                                                            <td colspan="4">
                                                                No records to display.
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <div class="t-grid-pager t-grid-bottom">
                                                    <div class="t-status">
                                                        <a class="t-icon t-refresh" href="#">Refresh</a></div>
                                                    <div class="t-pager t-reset">
                                                        <a class="t-link t-state-disabled" href="#"><span class="t-icon t-arrow-first">first</span></a><a
                                                            class="t-link t-state-disabled" href="#"><span class="t-icon t-arrow-prev">prev</span></a>
                                                        <div class="t-numeric">
                                                            <span class="t-state-active">1</span></div>
                                                        <a class="t-link t-state-disabled" href="#"><span class="t-icon t-arrow-next">next</span></a><a
                                                            class="t-link t-state-disabled" href="#"><span class="t-icon t-arrow-last">last</span></a></div>
                                                    <div class="t-status-text">
                                                        Displaying items 0 - 0 of 0</div>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
                <%--<td class="rightcol">
                    <div class="nop-news">
                        <div class="section-header">
                            <div class="title">
                                <img src="images/ico-news.gif" alt="" />
                                NopCommerce News
                            </div>
                        </div>
                        <div class="newsitem">
                            <div class="newstitle">
                                <a href='http://www.arvixe.com/nopcommerce_hosting?utm_campaign=premiumsponsorship&amp;utm_medium=showcase&amp;utm_source=nopcommerce.com'>
                                    Recommended hosting for your store</a>
                            </div>
                            <div class="newsdate">
                                7/1/2013
                            </div>
                            <div class="newsdetails">
                                Arvixe has been hosting thousands of personal, small business and enterprise websites
                                on a global level. Click <a href="http://www.arvixe.com/nopcommerce_hosting?utm_campaign=premiumsponsorship&utm_medium=showcase&utm_source=nopcommerce.com"
                                    target="_blank">here</a> for more info.
                            </div>
                            <div class="newstitle">
                                <a href='http://www.nopcommerce.com/userguide.aspx'>User Guide published</a>
                            </div>
                            <div class="newsdate">
                                5/1/2013
                            </div>
                            <div class="newsdetails">
                                nopCommerce User Guide is the definitive guide to installing, configuring, building,
                                maintaining an ecommerce site using the nopCommerce.
                            </div>
                            <div class="newstitle">
                                <a href='http://www.nopcommerce.com/copyrightremoval.aspx'>&quot;Powered by nopCommerce&quot;
                                    link</a>
                            </div>
                            <div class="newsdate">
                                7/16/2012
                            </div>
                            <div class="newsdetails">
                                Would you like to remove the "Powered by nopCommerce" link in the bottom of the
                                footer (public store)? Click <a href="http://www.nopcommerce.com/CopyrightRemoval.aspx">
                                    here</a> for more info.
                            </div>
                        </div>
                        <div class="adv">
                            <a id="nopcommerceNewsHideAdv" href="#">Hide advertisements</a>
                        </div>
                    </div>
                </td>--%>
            </tr>
        </table>
    </div>
</asp:Content>

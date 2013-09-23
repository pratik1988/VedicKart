<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN/Admin.master" AutoEventWireup="true"
    CodeFile="CustomerDashboard.aspx.cs" Inherits="ADMIN_CustomerDashboard" %>

<%@ Register Src="~/UserControls/ADMIN/Customers/UserType.ascx" TagName="usertype"
    TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/ADMIN/Customers/Gender.ascx" TagName="Gender"
    TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/ADMIN/Customers/CountryCityState.ascx" TagName="Country"
    TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/ADMIN/Products/ProdSupplement.ascx" TagName="Prodctsupplyment"
    TagPrefix="uc4" %>
<%@ Register Src="~/UserControls/ADMIN/Products/ProdType.ascx" TagName="Prodcttype"
    TagPrefix="uc5" %>
<%@ Register Src="~/UserControls/ADMIN/Products/ProdOffer.ascx" TagName="Prodctoffer"
    TagPrefix="uc6" %>
<%@ Register Src="~/UserControls/ADMIN/Customers/Customer.ascx" TagName="Customer"
    TagPrefix="uc7" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="cph">
        <div class="section-title">
            <img src="../images/ico-dashboard.png" />
            CustomerDashboard
        </div>
        <table class="stats">
            <tbody>
                <uc7:Customer ID="CustomerID" runat="server" />
            </tbody>
        </table>
        <table class="dashboard">
            <tr>
                <td class="maincol">
                    <table class="stats">
                        <tbody>
                            <tr>
                                <td class="customerstatistics">
                                    <uc1:usertype ID="usertypeID" runat="server" />
                                </td>
                                <td class="customerstatistics">
                                    <uc2:Gender ID="GenderID" runat="server" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </table>
        <table class="dashboard">
            <tr>
                <td class="maincol">
                    <table class="stats">
                        <tbody>
                            <tr>
                                <td class="customerstatistics">
                                    <uc3:Country ID="countryID" runat="server" />
                                </td>
                                <td class="customerstatistics">
                                    <uc4:Prodctsupplyment ID="ProdctsupplymentID" runat="server" />
                                </td>

                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </table>
        <table class="dashboard">
            <tr>
                <td class="maincol">
                    <table class="stats">
                        <tbody>
                            <tr>
                                <td class="customerstatistics">
                                    <uc5:Prodcttype ID="Prodtype" runat="server" />
                                </td>
                                <td class="customerstatistics">
                                    <uc6:Prodctoffer ID="ProdOffer" runat="server" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

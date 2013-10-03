<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN/Admin.master" AutoEventWireup="true"
    CodeFile="ProductDashBoard.aspx.cs" Inherits="ADMIN_ProductDashBoard" %>
     <%@ Register Src="~/UserControls/ADMIN/Products/ProdCategory.ascx" TagName="Prodctgry" TagPrefix="uc1" %>
    <%@ Register Src="~/UserControls/ADMIN/Products/ProdCompany.ascx"  TagName="Prodcomp" TagPrefix="uc2" %>
   <%@ Register Src="~/UserControls/ADMIN/Products/ProdMedicineFor.ascx" TagName="Prodctmedicine" TagPrefix="uc3" %>
   <%@ Register Src="~/UserControls/ADMIN/Products/ProdSupplement.ascx" TagName="Prodctsupplyment" TagPrefix="uc4" %>
   <%@ Register Src="~/UserControls/ADMIN/Products/ProdType.ascx" TagName="Prodcttype" TagPrefix="uc5" %>
   <%@ Register Src="~/UserControls/ADMIN/Products/ProdOffer.ascx" TagName="Prodctoffer" TagPrefix="uc6" %>
   <%@ Register Src="~/UserControls/ADMIN/Products/ProdTable.ascx" TagName="Prodct" TagPrefix="uc7" %>
<%@ Register Src="~/UserControls/ADMIN/Products/ProdSubCategory.ascx" TagName="Prodsubctg" TagPrefix="uc8" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="cph">
        <div class="section-title">
            <img src="../images/ico-dashboard.png" />
            ProductDashboard
        </div>
        <table class="stats">
                        <tbody>
                            <uc7:Prodct ID="prodd" runat="server" />
                        </tbody>
                    </table>
        <table class="dashboard">
            <tr>
                <td class="maincol">
                    <table class="stats">
                        <tbody>
                            <tr>
                                <td class="customerstatistics">
                               <uc1:Prodctgry ID="prodcategory" runat="server" />
                               
                                </td>
                                <td class="customerstatistics">
                                 <uc2:Prodcomp ID="prodcomp" runat="server" />
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
                               <uc8:Prodsubctg ID="prodsubctg" runat="server" />
                               
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
                              <uc3:Prodctmedicine ID="promedicine" runat="server" />
                               
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

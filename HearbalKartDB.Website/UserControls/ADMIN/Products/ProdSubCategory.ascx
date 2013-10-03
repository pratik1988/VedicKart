<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProdSubCategory.ascx.cs" Inherits="UserControls_ADMIN_Products_ProdSubCategory" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<style type="text/css">
    .imggrdstyle {
        height: 50px;
    }
</style>
<td class="orderaveragereport">
    <div class="statisticsTitle">
        Sub categories
       
        <asp:LinkButton ID="lnkAddNewSubctg" runat="server" OnClick="lnkAddNewSubctg_Click">Add New</asp:LinkButton>
    </div>
    <table class="adminContent">
        <asp:GridView ID="grdprodsubctg" CssClass="t-widget t-grid" runat="server" Width="100%"
            AutoGenerateColumns="False" RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle"
            CellPadding="0" CellSpacing="1" EmptyDataText="No record Found!" EmptyDataRowStyle-Font-Bold="true"
            EmptyDataRowStyle-HorizontalAlign="Center" EditRowStyle-VerticalAlign="Top" AllowPaging="true"
            RowStyle-CssClass="con" AlternatingRowStyle-CssClass="con-dark" GridLines="None"
            PageSize="10" BackColor="#ffffff" ShowHeader="true" OnRowDataBound="grdprodsubctg_RowDataBound">
            <AlternatingRowStyle CssClass="con-dark"></AlternatingRowStyle>
            <Columns>
                <asp:TemplateField>
                    <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                    <HeaderTemplate>
                        Category Name
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCategoryname" runat="server"></asp:Label>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <asp:Label ID="lblCategoryname" runat="server"></asp:Label>
                    </AlternatingItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                    <HeaderTemplate>
                        Parent Category Name
                   
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblProdparentctg" runat="server"></asp:Label>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <asp:Label ID="lblProdparentctg" runat="server"></asp:Label>
                    </AlternatingItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                    <HeaderTemplate>
                        IsActive
                   
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="IMGBTNProdsubCTGisActive" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="IMGBTNProdsubCTGisActive_Click"></asp:ImageButton>
                        <asp:HiddenField ID="HDFProdsubctgID" runat="server" />
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <asp:ImageButton ID="IMGBTNProdsubCTGisActive" runat="server" CssClass="t-alt" CommandArgument='<%# Eval("Id") %>' OnClick="IMGBTNProdsubCTGisActive_Click"></asp:ImageButton>
                        <asp:HiddenField ID="HDFProdsubctgID" runat="server" />
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
            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="con"></RowStyle>
        </asp:GridView>
    </table>
    <div id="lightSubprod" class="white_box_big" style="width: 700px;">
        <div class="add-address">
            <h3>
                <asp:Label ID="lblpopheaderprodsubctg" runat="server" />
            </h3>
            <a href="javascript:void(0);" onclick="document.getElementById('lightSubprod').style.display='none';document.getElementById('fadeprodsubctg').style.display='none'">
                <span class="cross1"></span></a>
        </div>
        <div id="errorpopheaderprodsubctg" runat="server">
        </div>
        <div class="mini-cart1">
            <div class="loginform1">
                <div class="loginouter1">
                    <span class="loginlabel1">ProductName:</span><span class="logininput1">
                        <asp:TextBox ID="TXTprodsubctg" runat="server" CssClass="textboxstyle" /></span>
                    <span class="loginlabel1">Parent Category:</span><span class="logininput1">
                        <asp:ListBox ID="lstprntctg" runat="server" SelectionMode="Multiple"></asp:ListBox></span>
                </div>
            </div>
        </div>
        <div class="cl">
        </div>
        <div class="add-adres-footer">
            <div class="loginbtn">
                <asp:LinkButton ID="btnSubmitprodsubctg" Text="Submit" runat="server" OnClick="btnSubmit_Click1" OnClientClick="return Checkprodsubctg();" />
            </div>
            <div class="loginfbbtn">
                <asp:LinkButton ID="btncancelprod" runat="server" Text="Cancel" />
            </div>
        </div>
        <!--add-adres-footer-->
    </div>
    <a onclick="document.getElementById('lightSubprod').style.display='none';document.getElementById('fadeprodsubctg').style.display='none'"
        href="javascript:void(0)" style="border: none;">
        <div id="fadeprodsubctg" class="black_overlay1" onclick="document.getElementById('lightSubprod').style.display='none';document.getElementById('fadeprodsubctg').style.display='none'">
        </div>
    </a>

    <script language="javascript" type="text/javascript">
        function ShowPOPUPprodsubctg(status) {
            var errorMessage = "";
            var isValid = false;

            jQuery('#<%=lblpopheaderprodsubctg.ClientID %>').text('Add Sub Category');
            //alert(status);
            if (status == 'true') {
                jQuery('#<%=TXTprodsubctg.ClientID %>').val('');
                jQuery("#<%= errorpopheaderprodsubctg.ClientID %>").hide();
            }
            else {
                jQuery('#<%=TXTprodsubctg.ClientID %>').val('');
                //alert(status);
            }
            document.getElementById('lightSubprod').style.display = 'block';
            document.getElementById('fadeprodsubctg').style.display = 'block';
            return isValid;
        }

        function ShowPOPUPupdateprodsubctg(status) {
            var errorMessage = "";
            var isValid = false;

            jQuery('#<%=lblpopheaderprodsubctg.ClientID %>').text('Update Sub Category');
            //alert(status);
            if (status == 'true') {
                //alert(status);
            }
            else {
                //alert(status);
            }
            document.getElementById('lightSubprod').style.display = 'block';
            document.getElementById('fadeprodsubctg').style.display = 'block';
            return isValid;
        }

        function Checkprodsubctg() {
            var errorMessage = "";
            var isValid = true;
            var islist = false;
            jQuery("#<%= TXTprodsubctg.ClientID %>").removeClass('textboxstyleerror');
            var TXTprodsubctg = jQuery("#<%= TXTprodsubctg.ClientID %>").val();
            if (TXTprodsubctg.length <= 0) {
                if (errorMessage.length > 0) {
                    errorMessage += "<br/>";
                }
                errorMessage += "Category is required.";
                jQuery("#<%= TXTprodsubctg.ClientID %>").addClass('textboxstyleerror');
                isValid = false;
            }

            var options = document.getElementById("<%=lstprntctg.ClientID%>").options;
            for (var i = 0; i < options.length; i++) {
                if (options[i].selected == true) {
                    islist = true;
                }
            }
            if (!islist) {
                if (errorMessage.length > 0) {
                    errorMessage += "<br/>";
                }
                errorMessage += "Select At list one value from Category";
                isValid = false;
            }
            if (!isValid) {
                jQuery("#<%= errorpopheaderprodsubctg.ClientID %>").show();
                jQuery("#<%= errorpopheaderprodsubctg.ClientID %>").removeClass('fk-msg-success');
                jQuery("#<%= errorpopheaderprodsubctg.ClientID %>").addClass('fk-err-all');
                jQuery("#<%= errorpopheaderprodsubctg.ClientID %>").html(errorMessage);
                jQuery("#<%= errorpopheaderprodsubctg.ClientID %>").addClass('fk-err-all');
                jQuery("#lightSubprod").addClass('white_box_big_error');
                return false;
            }
            else {
                jQuery("#<%= errorpopheaderprodsubctg.ClientID %>").html('');
                jQuery("#<%= errorpopheaderprodsubctg.ClientID %>").removeClass('fk-err-all');
                jQuery("#lightSubprod").removeClass('white_box_big_error');
                return true;
            }
        }
    </script>
</td>

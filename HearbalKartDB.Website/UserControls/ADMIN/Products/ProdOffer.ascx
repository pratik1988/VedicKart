<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProdOffer.ascx.cs" Inherits="UserControls_ADMIN_Products_ProdOffer" %>
<div class="statisticsTitle">
    Product Offer
    <asp:LinkButton ID="lnkAddNewprodoffer" runat="server" OnClick="lnkAddNewprodoffer_Click">Add New</asp:LinkButton>
</div>
<table class="adminContent">
    <asp:GridView ID="grdprodoffer" CssClass="t-widget t-grid" runat="server" Width="100%"
        AutoGenerateColumns="False" RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle"
        CellPadding="0" CellSpacing="1" EmptyDataText="No record Found!" EmptyDataRowStyle-Font-Bold="true"
        EmptyDataRowStyle-HorizontalAlign="Center" EditRowStyle-VerticalAlign="Top" AllowPaging="true"
        RowStyle-CssClass="con" AlternatingRowStyle-CssClass="con-dark" GridLines="None"
        PageSize="10" BackColor="#ffffff" ShowHeader="true" OnRowDataBound="grdprodoffer_RowDataBound">
        <AlternatingRowStyle CssClass="con-dark"></AlternatingRowStyle>
        <Columns>
            <asp:TemplateField>
                <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                <HeaderTemplate>
                    Offer %
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblProdOffer" runat="server"></asp:Label>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <asp:Label ID="lblProdOffer" runat="server"></asp:Label>
                </AlternatingItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                <HeaderTemplate>
                    IsActive
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:ImageButton ID="IMGBTNProdofferisActive" runat="server" CommandArgument='<%# Eval("Id") %>'
                        OnClick="IMGBTNcategoryisActive_Click"></asp:ImageButton>
                    <asp:HiddenField ID="HDFProdOfferID" runat="server" />
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <asp:ImageButton ID="IMGBTNProdofferisActive" runat="server" CssClass="t-alt" CommandArgument='<%# Eval("Id") %>'
                        OnClick="IMGBTNcategoryisActive_Click"></asp:ImageButton>
                    <asp:HiddenField ID="HDFProdOfferID" runat="server" />
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
<div id="lightprodoffer" class="white_box" style="width: 380px;">
    <div class="add-address">
        <h3>
            <asp:Label ID="lblpopheaderprodOffer" runat="server" />
        </h3>
        <a href="javascript:void(0);" onclick="document.getElementById('lightprodoffer').style.display='none';document.getElementById('fadeprodoffer').style.display='none'">
            <span class="cross"></span></a>
    </div>
    <div id="errorpopheaderprodoffer" runat="server">
    </div>
    <div class="mini-cart">
        <div class="loginform">
            <div class="loginouter">
                <span class="loginlabel">Name:</span><span class="logininput">
                    <asp:TextBox ID="TXTprodOffer" runat="server" Text="Submit" /></span>
            </div>
            <div class="loginouter" id="DIVIsActive" runat="server" style="display: none;">
                <span class="loginlabel">IsActive:</span><span class="logininput">
                    <asp:CheckBox ID="ChkIsActiveprodoffer" runat="server" /></span>
            </div>
        </div>
    </div>
    <div class="cl">
    </div>
    <div class="add-adres-footer">
        <div class="loginbtn">
            <asp:LinkButton ID="btnSubmitprodoffer" Text="Submit" runat="server" OnClientClick="return btnSubmitprodoffer();"
                OnClick="btnSubmit_Click1" />
        </div>
        <div class="loginfbbtn">
            <asp:LinkButton ID="btncancel" runat="server" OnClientClick="return ClosePOPUPprodoffer();"
                Text="Cancel" /></div>
    </div>
    <!--add-adres-footer-->
</div>
<a onclick="document.getElementById('lightprodoffer').style.display='none';document.getElementById('fadeprodoffer').style.display='none'"
    href="javascript:void(0)" style="border: none;">
    <div id="fadeprodoffer" class="black_overlay1" onclick="document.getElementById('lightprodoffer').style.display='none';document.getElementById('fadeprodoffer').style.display='none'">
    </div>
</a>
<script language="javascript" type="text/javascript">
    function btnSubmitprodoffer() {
        var errorMessage = "";
        var isValid = true;

        var txtorder = jQuery("#<%= TXTprodOffer.ClientID %>").val();

        if (txtorder.length <= 0) {
            if (errorMessage.length > 0) {
                errorMessage += "<br/>";
            }
            errorMessage += "ProductOffer is required.";
            isValid = false;
        }
        if (!isValid) {
            jQuery("#<%= errorpopheaderprodoffer.ClientID %>").show();
            jQuery("#<%= errorpopheaderprodoffer.ClientID %>").addClass('fk-err-all');
            jQuery("#<%= errorpopheaderprodoffer.ClientID %>").html(errorMessage);
            jQuery("#<%= errorpopheaderprodoffer.ClientID %>").addClass('fk-err-all');
            return false;
        }
        else {
            jQuery("#<%= errorpopheaderprodoffer.ClientID %>").html('');
            jQuery("#<%= errorpopheaderprodoffer.ClientID %>").removeClass('fk-err-all');
            return true;
        }
    }
    function ShowPOPUPprodoffer(status) {
        var errorMessage = "";
        var isValid = false;
        jQuery('#<%=btnSubmitprodoffer.ClientID %>').text('Submit');
        jQuery('#<%=lblpopheaderprodOffer.ClientID %>').text('Add Product Offer');
        //alert(status);
        if (status == 'true') {
            jQuery('#<%=TXTprodOffer.ClientID %>').val('');
            //alert(status);
        }
        else {
            jQuery('#<%=TXTprodOffer.ClientID %>').val('');
            jQuery("#<%= errorpopheaderprodoffer.ClientID %>").hide();
            //alert(status);
        }
        jQuery('#<%=DIVIsActive.ClientID %>').hide();
        document.getElementById('lightprodoffer').style.display = 'block';
        document.getElementById('fadeprodoffer').style.display = 'block';
        return isValid;
    }

    function ShowPOPUPprodofferUpdate(status) {
        var errorMessage = "";
        var isValid = false;
        //alert(status);
        jQuery('#<%=lblpopheaderprodOffer.ClientID %>').text('Update Product Offer');
        if (status == 'true') {
            //alert(status);
        }
        else {
            jQuery('#<%=TXTprodOffer.ClientID %>').val('');
            jQuery("#<%= errorpopheaderprodoffer.ClientID %>").hide();
            //alert(status);
        }
        document.getElementById('lightprodoffer').style.display = 'block';
        document.getElementById('fadeprodoffer').style.display = 'block';
        return isValid;
    }
    function ClosePOPUPprodoffer() {
        var errorMessage = "";
        var isValid = true;
        document.getElementById('lightprodoffer').style.display = 'none';
        document.getElementById('fadeprodoffer').style.display = 'none';
        return isValid;
    }
</script>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProdSupplement.ascx.cs" Inherits="UserControls_ADMIN_Products_ProdSupplement" %>
<div class="statisticsTitle">
    Product SupplymentType
    <asp:LinkButton ID="lnkAddNewprodsupplement" runat="server" OnClick="lnkAddNewprodsupplement_Click">Add New</asp:LinkButton>
</div>
<table class="adminContent">
    <asp:GridView ID="grdprodsupplementfor" CssClass="t-widget t-grid" runat="server" Width="100%"
        AutoGenerateColumns="False" RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle"
        CellPadding="0" CellSpacing="1" EmptyDataText="No record Found!" EmptyDataRowStyle-Font-Bold="true"
        EmptyDataRowStyle-HorizontalAlign="Center" EditRowStyle-VerticalAlign="Top" AllowPaging="true"
        RowStyle-CssClass="con" AlternatingRowStyle-CssClass="con-dark" GridLines="None"
        PageSize="10" BackColor="#ffffff" ShowHeader="true" OnRowDataBound="grdprodsupplementfor_RowDataBound">
        <AlternatingRowStyle CssClass="con-dark"></AlternatingRowStyle>
        <Columns>
            <asp:TemplateField>
                <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                <HeaderTemplate>
                    Supplement Name
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblSupplementname" runat="server"></asp:Label>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <asp:Label ID="lblSupplementname" runat="server"></asp:Label>
                </AlternatingItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                <HeaderTemplate>
                    IsActive
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:ImageButton ID="IMGBTNSupplementeisActive" runat="server" CommandArgument='<%# Eval("Id") %>'
                        OnClick="IMGBTNcategoryisActive_Click"></asp:ImageButton>
                    <asp:HiddenField ID="HDFsupplementID" runat="server" />
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <asp:ImageButton ID="IMGBTNSupplementeisActive" runat="server" CssClass="t-alt" CommandArgument='<%# Eval("Id") %>'
                        OnClick="IMGBTNcategoryisActive_Click"></asp:ImageButton>
                    <asp:HiddenField ID="HDFsupplementID" runat="server" />
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
<div id="lightsupplement" class="white_box" style="width: 380px;">
    <div class="add-address">
        <h3>
            <asp:Label ID="lblpopheadersupple" runat="server" /> </h3>
        <a href="javascript:void(0);" onclick="document.getElementById('lightsupplement').style.display='none';document.getElementById('fadesupplement').style.display='none'">
            <span class="cross"></span></a>
    </div>
    <div id="errorpopheadersuppli" runat="server">
    </div>
    <div class="mini-cart">
        <div class="loginform">
            <div class="loginouter">
                <span class="loginlabel">Name:</span><span class="logininput">
                    <asp:TextBox ID="TXTsupplyment" runat="server" Text="Submit" /></span>
            </div>
            <div class="loginouter" id="DIVIsActive" runat="server" style="display: none;">
                <span class="loginlabel">IsActive:</span><span class="logininput">
                    <asp:CheckBox ID="ChkIsActivesupply" runat="server" /></span>
            </div>
        </div>
    </div>
    <div class="cl">
    </div>
    <div class="add-adres-footer">
        <div class="loginbtn">
            <asp:LinkButton ID="btnSubmitsupply" Text="Submit" runat="server" OnClientClick="return Checkprodsupply();"
                OnClick="btnSubmit_Click1" />
        </div>
        <div class="loginfbbtn">
            <asp:LinkButton ID="btncancel" runat="server" OnClientClick="return ClosePOPUPsupply();"
                Text="Cancel" /></div>
    </div>
    <!--add-adres-footer-->
</div>
<a onclick="document.getElementById('lightsupplement').style.display='none';document.getElementById('fadesupplement').style.display='none'"
    href="javascript:void(0)" style="border: none;">
    <div id="fadesupplement" class="black_overlay1" onclick="document.getElementById('lightsupplement').style.display='none';document.getElementById('fadesupplement').style.display='none'">
    </div>
</a>
<script language="javascript" type="text/javascript">
    function Checkprodsupply() {
        var errorMessage = "";
        var isValid = true;

        var txtorder = jQuery("#<%= TXTsupplyment.ClientID %>").val();

        if (txtorder.length <= 0) {
            if (errorMessage.length > 0) {
                errorMessage += "<br/>";
            }
            errorMessage += "ProductSupplymentType is required.";
            isValid = false;
        }
        if (!isValid) {
            jQuery("#<%= errorpopheadersuppli.ClientID %>").show();
            jQuery("#<%= errorpopheadersuppli.ClientID %>").addClass('fk-err-all');
            jQuery("#<%= errorpopheadersuppli.ClientID %>").html(errorMessage);
            jQuery("#<%= errorpopheadersuppli.ClientID %>").addClass('fk-err-all');
            return false;
        }
        else {
            jQuery("#<%= errorpopheadersuppli.ClientID %>").html('');
            jQuery("#<%= errorpopheadersuppli.ClientID %>").removeClass('fk-err-all');
            return true;
        }
    }
    function ShowPOPUPSupply(status) {
        var errorMessage = "";
        var isValid = false;
        jQuery('#<%=btnSubmitsupply.ClientID %>').text('Submit');
        jQuery('#<%=lblpopheadersupple.ClientID %>').text('Add Product SupplymentType');
        //alert(status);
        if (status == 'true') {
            jQuery('#<%=TXTsupplyment.ClientID %>').val('');
            //alert(status);
        }
        else {
            jQuery('#<%=TXTsupplyment.ClientID %>').val('');
            jQuery("#<%= errorpopheadersuppli.ClientID %>").hide();
            //alert(status);
        }
        jQuery('#<%=DIVIsActive.ClientID %>').hide();
        document.getElementById('lightsupplement').style.display = 'block';
        document.getElementById('fadesupplement').style.display = 'block';
        return isValid;
    }

    function ShowPOPUPSupplyUpdate(status) {
        var errorMessage = "";
        var isValid = false;
        //alert(status);
        jQuery('#<%=lblpopheadersupple.ClientID %>').text('Update Product SupplymentType');
        if (status == 'true') {
            //alert(status);
        }
        else {
            jQuery('#<%=TXTsupplyment.ClientID %>').val('');
            jQuery("#<%= errorpopheadersuppli.ClientID %>").hide();
            //alert(status);
        }
        document.getElementById('lightsupplement').style.display = 'block';
        document.getElementById('fadesupplement').style.display = 'block';
        return isValid;
    }
    function ClosePOPUPsupply() {
        var errorMessage = "";
        var isValid = true;
        document.getElementById('lightsupplement').style.display = 'none';
        document.getElementById('fadesupplement').style.display = 'none';
        return isValid;
    }
</script>
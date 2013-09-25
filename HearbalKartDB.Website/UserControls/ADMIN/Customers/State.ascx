<%@ Control Language="C#" AutoEventWireup="true" CodeFile="State.ascx.cs" Inherits="UserControls_ADMIN_Customers_State" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<div class="statisticsTitle">
    Country
   
    <asp:LinkButton ID="lnkAddNewState" runat="server">Add New</asp:LinkButton>
</div>
<table class="adminContent">
    <asp:GridView ID="grdState" CssClass="t-widget t-grid" runat="server" Width="100%"
        AutoGenerateColumns="False" RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle"
        CellPadding="0" CellSpacing="1" EmptyDataText="No record Found!" EmptyDataRowStyle-Font-Bold="true"
        EmptyDataRowStyle-HorizontalAlign="Center" EditRowStyle-VerticalAlign="Top" AllowPaging="true"
        RowStyle-CssClass="con" AlternatingRowStyle-CssClass="con-dark" GridLines="None"
        PageSize="10" BackColor="#ffffff" ShowHeader="true">
        <AlternatingRowStyle CssClass="con-dark"></AlternatingRowStyle>
        <Columns>
            <asp:TemplateField>
                <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                <HeaderTemplate>
                    State
               
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblState" runat="server"></asp:Label>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <asp:Label ID="lblState" runat="server"></asp:Label>
                </AlternatingItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                <HeaderTemplate>
                    Country
               
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblCountryS" runat="server"></asp:Label>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <asp:Label ID="lblCountryS" runat="server"></asp:Label>
                </AlternatingItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                <HeaderTemplate>
                    Pin
               
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblStatePin" runat="server"></asp:Label>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <asp:Label ID="lblStatePin" runat="server"></asp:Label>
                </AlternatingItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                <HeaderTemplate>
                    IsActive
               
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:ImageButton ID="IMGBTNStateisActive" runat="server" CommandArgument='<%# Eval("Id") %>'></asp:ImageButton>
                    <asp:HiddenField ID="HDFStateID" runat="server" />
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <asp:ImageButton ID="IMGBTNStateisActive" runat="server" CssClass="t-alt" CommandArgument='<%# Eval("Id") %>'></asp:ImageButton>
                    <asp:HiddenField ID="HDFStateID" runat="server" />
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
<div id="lightSate" class="white_box" style="width: 380px;">
    <div class="add-address">
        <h3>
            <asp:Label ID="lblpopheaderState" runat="server" />
        </h3>
        <a href="javascript:void(0);" onclick="document.getElementById('lightSate').style.display='none';document.getElementById('fadeState').style.display='none'">
            <span class="cross"></span></a>
    </div>
    <div id="errorpopheaderState" runat="server">
    </div>
    <div class="mini-cart">
        <div class="loginform">
            <div class="loginouter">
                <span class="loginlabel">State:</span><span class="logininput">
                    <asp:TextBox ID="TXTState" runat="server" Text="Submit" CssClass="textboxstyle" /></span>
            </div>
            <div class="loginouter">
                <span class="loginlabel">Pin:</span><span class="logininput">
                    <asp:TextBox ID="TXTStatePIN" runat="server" Text="Submit" CssClass="textboxstyle" /></span>
            </div>
            <div class="loginouter">
                <span class="loginlabel">Country:</span><span class="logininput">
                    <asp:TextBox ID="DrpCountry" runat="server" Text="Submit" CssClass="textboxstyle" /></span>
            </div>
            <div class="loginouter" id="DIVIsActive" runat="server" style="display: none;">
                <span class="loginlabel">IsActive:</span><span class="logininput">
                    <asp:CheckBox ID="ChkIsActiveState" runat="server" /></span>
            </div>
        </div>
    </div>
    <div class="cl">
    </div>
    <div class="add-adres-footer">
        <div class="loginbtn">
            <asp:LinkButton ID="btnSubmitState" Text="Submit" runat="server" OnClientClick="return btnSubmitState();" />
        </div>
        <div class="loginfbbtn">
            <asp:LinkButton ID="btncancel" runat="server" OnClientClick="return ClosePOPUPState();"
                Text="Cancel" />
        </div>
    </div>
    <!--add-adres-footer-->
</div>
<a onclick="document.getElementById('lightSate').style.display='none';document.getElementById('fadeState').style.display='none'"
    href="javascript:void(0)" style="border: none;">
    <div id="fadeState" class="black_overlay1" onclick="document.getElementById('lightSate').style.display='none';document.getElementById('fadeState').style.display='none'">
    </div>
</a>
<script type="text/javascript">
    function btnSubmitState() {
        var errorMessage = "";
        var isValid = true;
        jQuery("#<%= TXTState.ClientID %>").removeClass('textboxstyleerror');
        jQuery("#<%= TXTStatePIN.ClientID %>").removeClass('textboxstyleerror');
        var txtorder = jQuery("#<%= TXTState.ClientID %>").val();
        var TXTStatePIN = jQuery("#<%= TXTStatePIN.ClientID %>").val();
        var DrpCountry = jQuery("#<%= DrpCountry.ClientID %>").val();
        if (DrpCountry == "0") {
            if (errorMessage.length > 0) {
                errorMessage += "<br/>";
            }
            errorMessage += 'Country is required.';
            isValid = false;
        }
        if (TXTStatePIN.length <= 0) {
            if (errorMessage.length > 0) {
                errorMessage += "<br/>";
            }
            errorMessage += "Pin is required.";
            jQuery("#<%= TXTStatePIN.ClientID %>").addClass('textboxstyleerror');
            isValid = false;
        }
        if (txtorder.length <= 0) {
            if (errorMessage.length > 0) {
                errorMessage += "<br/>";
            }
            errorMessage += "State is required.";
            jQuery("#<%= TXTState.ClientID %>").addClass('textboxstyleerror');
            isValid = false;
        }
        if (!isValid) {
            jQuery("#<%= errorpopheaderState.ClientID %>").show();
            jQuery("#<%= errorpopheaderState.ClientID %>").addClass('fk-err-all');
            jQuery("#<%= errorpopheaderState.ClientID %>").html(errorMessage);
            jQuery("#<%= errorpopheaderState.ClientID %>").addClass('fk-err-all');
            return false;
        }
        else {
            jQuery("#<%= errorpopheaderState.ClientID %>").html('');
            jQuery("#<%= errorpopheaderState.ClientID %>").removeClass('fk-err-all');
            return true;
        }
    }
    function ShowPOPUPCSC(status) {
        var errorMessage = "";
        var isValid = false;
        jQuery('#<%=btnSubmitState.ClientID %>').text('Submit');
        jQuery('#<%=lblpopheaderState.ClientID %>').text('Add States');
        //alert(status);
        if (status == 'true') {

            //alert(status);
        }
        else {
            jQuery('#<%=TXTState.ClientID %>').val('');
            jQuery("#<%= TXTStatePIN.ClientID %>").val('');
            vjQuery("#<%= DrpCountry.ClientID %>").val('0');
            jQuery("#<%= errorpopheaderState.ClientID %>").hide();
            //alert(status);
        }
        jQuery('#<%=DIVIsActive.ClientID %>').hide();
        document.getElementById('lightSate').style.display = 'block';
        document.getElementById('fadeState').style.display = 'block';
        return isValid;
    }

    function ShowPOPUPCSCUpdate(status) {
        var errorMessage = "";
        var isValid = false;
        //alert(status);
        jQuery('#<%=lblpopheaderState.ClientID %>').text('Update States');
        if (status == 'true') {
            //alert(status);
        }
        else {
            jQuery('#<%=TXTState.ClientID %>').val('');
            jQuery("#<%= errorpopheaderState.ClientID %>").hide();
            //alert(status);
        }
        document.getElementById('lightSate').style.display = 'block';
        document.getElementById('fadeState').style.display = 'block';
        return isValid;
    }
    function ClosePOPUPState() {
        var errorMessage = "";
        var isValid = true;
        document.getElementById('lightSate').style.display = 'none';
        document.getElementById('fadeState').style.display = 'none';
        return isValid;
    }
</script>

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CountryCityState.ascx.cs"
    Inherits="UserControls_ADMIN_Customers_CountryCityState" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<div class="statisticsTitle">
    Country
    <asp:LinkButton ID="lnkAddNewCsC" runat="server" OnClick="lnkAddNewCsC_Click">Add New</asp:LinkButton>
</div>
<table class="adminContent">
    <asp:GridView ID="grdCsC" CssClass="t-widget t-grid" runat="server" Width="100%"
        AutoGenerateColumns="False" RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle"
        CellPadding="0" CellSpacing="1" EmptyDataText="No record Found!" EmptyDataRowStyle-Font-Bold="true"
        EmptyDataRowStyle-HorizontalAlign="Center" EditRowStyle-VerticalAlign="Top" AllowPaging="true"
        RowStyle-CssClass="con" AlternatingRowStyle-CssClass="con-dark" GridLines="None"
        PageSize="10" BackColor="#ffffff" ShowHeader="true" OnRowDataBound="grdCsC_RowDataBound">
        <AlternatingRowStyle CssClass="con-dark"></AlternatingRowStyle>
        <Columns>
            <asp:TemplateField>
                <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                <HeaderTemplate>
                    Country
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblcountry" runat="server"></asp:Label>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <asp:Label ID="lblcountry" runat="server"></asp:Label>
                </AlternatingItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                <HeaderTemplate>
                    IsActive
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:ImageButton ID="IMGBTNCSCisActive" runat="server" CommandArgument='<%# Eval("Id") %>'
                        OnClick="IMGBTNCSCisActive_Click"></asp:ImageButton>
                    <asp:HiddenField ID="HDFCSCID" runat="server" />
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <asp:ImageButton ID="IMGBTNCSCisActive" runat="server" CssClass="t-alt" CommandArgument='<%# Eval("Id") %>'
                        OnClick="IMGBTNCSCisActive_Click"></asp:ImageButton>
                    <asp:HiddenField ID="HDFCSCID" runat="server" />
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
<div id="lightCSC" class="white_box" style="width: 380px;">
    <div class="add-address">
        <h3>
            <asp:Label ID="lblpopheaderCSC" runat="server" />
        </h3>
        <a href="javascript:void(0);" onclick="document.getElementById('lightCSC').style.display='none';document.getElementById('fadeCSC').style.display='none'">
            <span class="cross"></span></a>
    </div>
    <div id="errorpopheaderCSC" runat="server">
    </div>
    <div class="mini-cart">
        <div class="loginform">
            <div class="loginouter">
                <span class="loginlabel">Name:</span><span class="logininput">
                    <asp:TextBox ID="TXTCSC" runat="server" Text="Submit" CssClass="textboxstyle" /></span>
            </div>
            <div class="loginouter" id="DIVIsActive" runat="server" style="display: none;">
                <span class="loginlabel">IsActive:</span><span class="logininput">
                    <asp:CheckBox ID="ChkIsActiveCSC" runat="server" /></span>
            </div>
        </div>
    </div>
    <div class="cl">
    </div>
    <div class="add-adres-footer">
        <div class="loginbtn">
            <asp:LinkButton ID="btnSubmitCSC" Text="Submit" runat="server" OnClientClick="return btnSubmitCSC();"
                OnClick="btnSubmitCSC_Click" />
        </div>
        <div class="loginfbbtn">
            <asp:LinkButton ID="btncancel" runat="server" OnClientClick="return ClosePOPUPCSC();"
                Text="Cancel" /></div>
    </div>
    <!--add-adres-footer-->
</div>
<a onclick="document.getElementById('lightCSC').style.display='none';document.getElementById('fadeCSC').style.display='none'"
    href="javascript:void(0)" style="border: none;">
    <div id="fadeCSC" class="black_overlay1" onclick="document.getElementById('lightCSC').style.display='none';document.getElementById('fadeCSC').style.display='none'">
    </div>
</a>
<script language="javascript" type="text/javascript">
    function btnSubmitCSC() {
        var errorMessage = "";
        var isValid = true;
        jQuery("#<%= TXTCSC.ClientID %>").removeClass('textboxstyleerror');
        var txtorder = jQuery("#<%= TXTCSC.ClientID %>").val();

        if (txtorder.length <= 0) {
            if (errorMessage.length > 0) {
                errorMessage += "<br/>";
            }
            errorMessage += "Usertype is required.";
            jQuery("#<%= TXTCSC.ClientID %>").addClass('textboxstyleerror');
            isValid = false;
        }
        if (!isValid) {
            jQuery("#<%= errorpopheaderCSC.ClientID %>").show();
            jQuery("#<%= errorpopheaderCSC.ClientID %>").addClass('fk-err-all');
            jQuery("#<%= errorpopheaderCSC.ClientID %>").html(errorMessage);
            jQuery("#<%= errorpopheaderCSC.ClientID %>").addClass('fk-err-all');
            return false;
        }
        else {
            jQuery("#<%= errorpopheaderCSC.ClientID %>").html('');
            jQuery("#<%= errorpopheaderCSC.ClientID %>").removeClass('fk-err-all');
            return true;
        }
    }
    function ShowPOPUPCSC(status) {
        var errorMessage = "";
        var isValid = false;
        jQuery('#<%=btnSubmitCSC.ClientID %>').text('Submit');
        jQuery('#<%=lblpopheaderCSC.ClientID %>').text('Add Country');
        //alert(status);
        if (status == 'true') {
            jQuery('#<%=TXTCSC.ClientID %>').val('');
            //alert(status);
        }
        else {
            jQuery('#<%=TXTCSC.ClientID %>').val('');
            jQuery("#<%= errorpopheaderCSC.ClientID %>").hide();
            //alert(status);
        }
        jQuery('#<%=DIVIsActive.ClientID %>').hide();
        document.getElementById('lightCSC').style.display = 'block';
        document.getElementById('fadeCSC').style.display = 'block';
        return isValid;
    }

    function ShowPOPUPCSCUpdate(status) {
        var errorMessage = "";
        var isValid = false;
        //alert(status);
        jQuery('#<%=lblpopheaderCSC.ClientID %>').text('Update Country');
        if (status == 'true') {
            //alert(status);
        }
        else {
            jQuery('#<%=TXTCSC.ClientID %>').val('');
            jQuery("#<%= errorpopheaderCSC.ClientID %>").hide();
            //alert(status);
        }
        document.getElementById('lightCSC').style.display = 'block';
        document.getElementById('fadeCSC').style.display = 'block';
        return isValid;
    }
    function ClosePOPUPCSC() {
        var errorMessage = "";
        var isValid = true;
        document.getElementById('lightCSC').style.display = 'none';
        document.getElementById('fadeCSC').style.display = 'none';
        return isValid;
    }
</script>

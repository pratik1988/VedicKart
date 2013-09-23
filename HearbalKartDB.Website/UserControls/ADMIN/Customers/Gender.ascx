<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Gender.ascx.cs" Inherits="UserControls_ADMIN_Customers_Gender" %>
<div class="statisticsTitle">
    Gender
    <asp:LinkButton ID="lnkAddNewGender" runat="server" OnClick="lnkAddNewGender_Click">Add New</asp:LinkButton>
</div>
<table class="adminContent">
    <asp:GridView ID="grdgender" CssClass="t-widget t-grid" runat="server" Width="100%"
        AutoGenerateColumns="False" RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle"
        CellPadding="0" CellSpacing="1" EmptyDataText="No record Found!" EmptyDataRowStyle-Font-Bold="true"
        EmptyDataRowStyle-HorizontalAlign="Center" EditRowStyle-VerticalAlign="Top" AllowPaging="true"
        RowStyle-CssClass="con" AlternatingRowStyle-CssClass="con-dark" GridLines="None"
        PageSize="10" BackColor="#ffffff" ShowHeader="true" OnRowDataBound="grdgender_RowDataBound">
        <AlternatingRowStyle CssClass="con-dark"></AlternatingRowStyle>
        <Columns>
            <asp:TemplateField>
                <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                <HeaderTemplate>
                    Gender Name
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblGender" runat="server"></asp:Label>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <asp:Label ID="lblGender" runat="server"></asp:Label>
                </AlternatingItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                <HeaderTemplate>
                    IsActive
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:ImageButton ID="IMGBTNgenderisActive" runat="server" CommandArgument='<%# Eval("Id") %>'
                        OnClick="IMGBTNgenderisActive_Click"></asp:ImageButton>
                    <asp:HiddenField ID="HDFGenderID" runat="server" />
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <asp:ImageButton ID="IMGBTNgenderisActive" runat="server" CssClass="t-alt" CommandArgument='<%# Eval("Id") %>'
                        OnClick="IMGBTNgenderisActive_Click"></asp:ImageButton>
                    <asp:HiddenField ID="HDFGenderID" runat="server" />
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
<div id="lightgender" class="white_box" style="width: 380px;">
    <div class="add-address">
        <h3>
            <asp:Label ID="lblpopheaderGender" runat="server" />
        </h3>
        <a href="javascript:void(0);" onclick="document.getElementById('lightgender').style.display='none';document.getElementById('fadegender').style.display='none'">
            <span class="cross"></span></a>
    </div>
    <div id="errorpopheadergender" runat="server">
    </div>
    <div class="mini-cart">
        <div class="loginform">
            <div class="loginouter">
                <span class="loginlabel">Name:</span><span class="logininput">
                    <asp:TextBox ID="TXTGender" runat="server" Text="Submit" CssClass="textboxstyle" /></span>
            </div>
            <div class="loginouter" id="DIVIsActive" runat="server" style="display: none;">
                <span class="loginlabel">IsActive:</span><span class="logininput">
                    <asp:CheckBox ID="ChkIsActivegender" runat="server" /></span>
            </div>
        </div>
    </div>
    <div class="cl">
    </div>
    <div class="add-adres-footer">
        <div class="loginbtn">
            <asp:LinkButton ID="btnSubmitgender" Text="Submit" runat="server" OnClientClick="return btnSubmitgender();"
                OnClick="btnSubmitgender_Click" />
        </div>
        <div class="loginfbbtn">
            <asp:LinkButton ID="btncancel" runat="server" OnClientClick="return ClosePOPUPGender();"
                Text="Cancel" /></div>
    </div>
    <!--add-adres-footer-->
</div>
<a onclick="document.getElementById('lightgender').style.display='none';document.getElementById('fadegender').style.display='none'"
    href="javascript:void(0)" style="border: none;">
    <div id="fadegender" class="black_overlay1" onclick="document.getElementById('lightgender').style.display='none';document.getElementById('fadegender').style.display='none'">
    </div>
</a>
<script language="javascript" type="text/javascript">
    function btnSubmitgender() {
        var errorMessage = "";
        var isValid = true;
        jQuery("#<%= TXTGender.ClientID %>").removeClass('textboxstyleerror');
        var txtorder = jQuery("#<%= TXTGender.ClientID %>").val();

        if (txtorder.length <= 0) {
            if (errorMessage.length > 0) {
                errorMessage += "<br/>";
            }
            errorMessage += "Gender is required.";
            jQuery("#<%= TXTGender.ClientID %>").addClass('textboxstyleerror');
            isValid = false;
        }
        if (!isValid) {
            jQuery("#<%= errorpopheadergender.ClientID %>").show();
            jQuery("#<%= errorpopheadergender.ClientID %>").addClass('fk-err-all');
            jQuery("#<%= errorpopheadergender.ClientID %>").html(errorMessage);
            jQuery("#<%= errorpopheadergender.ClientID %>").addClass('fk-err-all');
            return false;
        }
        else {
            jQuery("#<%= errorpopheadergender.ClientID %>").html('');
            jQuery("#<%= errorpopheadergender.ClientID %>").removeClass('fk-err-all');
            return true;
        }
    }
    function ShowPOPUPgender(status) {
        var errorMessage = "";
        var isValid = false;
        jQuery('#<%=btnSubmitgender.ClientID %>').text('Submit');
        jQuery('#<%=lblpopheaderGender.ClientID %>').text('Add Gender');
        //alert(status);
        if (status == 'true') {
            jQuery('#<%=TXTGender.ClientID %>').val('');
            //alert(status);
        }
        else {
            jQuery('#<%=TXTGender.ClientID %>').val('');
            jQuery("#<%= errorpopheadergender.ClientID %>").hide();
            //alert(status);
        }
        jQuery('#<%=DIVIsActive.ClientID %>').hide();
        document.getElementById('lightgender').style.display = 'block';
        document.getElementById('fadegender').style.display = 'block';
        return isValid;
    }

    function ShowPOPUPgenderUpdate(status) {
        var errorMessage = "";
        var isValid = false;
        //alert(status);
        jQuery('#<%=lblpopheaderGender.ClientID %>').text('Update Gender');
        if (status == 'true') {
            //alert(status);
        }
        else {
            jQuery('#<%=TXTGender.ClientID %>').val('');
            jQuery("#<%= errorpopheadergender.ClientID %>").hide();
            //alert(status);
        }
        document.getElementById('lightgender').style.display = 'block';
        document.getElementById('fadegender').style.display = 'block';
        return isValid;
    }
    function ClosePOPUPGender() {
        var errorMessage = "";
        var isValid = true;
        document.getElementById('lightgender').style.display = 'none';
        document.getElementById('fadegender').style.display = 'none';
        return isValid;
    }
</script>
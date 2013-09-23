<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserType.ascx.cs" Inherits="UserControls_ADMIN_Customers_UserType" %>
<div class="statisticsTitle">
    UserType
    <asp:LinkButton ID="lnkAddNewusrtype" runat="server" OnClick="lnkAddNewusrtype_Click">Add New</asp:LinkButton>
</div>
<table class="adminContent">
    <asp:GridView ID="grdusrtype" CssClass="t-widget t-grid" runat="server" Width="100%"
        AutoGenerateColumns="False" RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle"
        CellPadding="0" CellSpacing="1" EmptyDataText="No record Found!" EmptyDataRowStyle-Font-Bold="true"
        EmptyDataRowStyle-HorizontalAlign="Center" EditRowStyle-VerticalAlign="Top" AllowPaging="true"
        RowStyle-CssClass="con" AlternatingRowStyle-CssClass="con-dark" GridLines="None"
        PageSize="10" BackColor="#ffffff" ShowHeader="true" OnRowDataBound="grdusrtype_RowDataBound">
        <AlternatingRowStyle CssClass="con-dark"></AlternatingRowStyle>
        <Columns>
            <asp:TemplateField>
                <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                <HeaderTemplate>
                    UserType Name
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblusertype" runat="server"></asp:Label>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <asp:Label ID="lblusertype" runat="server"></asp:Label>
                </AlternatingItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                <HeaderTemplate>
                    IsActive
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:ImageButton ID="IMGBTNusertypeisActive" runat="server" CommandArgument='<%# Eval("Id") %>'
                        OnClick="IMGBTNusertypeisActive_Click"></asp:ImageButton>
                    <asp:HiddenField ID="HDFusertypeID" runat="server" />
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <asp:ImageButton ID="IMGBTNusertypeisActive" runat="server" CssClass="t-alt" CommandArgument='<%# Eval("Id") %>'
                        OnClick="IMGBTNusertypeisActive_Click"></asp:ImageButton>
                    <asp:HiddenField ID="HDFusertypeID" runat="server" />
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
<div id="lightusertype" class="white_box" style="width: 380px;">
    <div class="add-address">
        <h3>
            <asp:Label ID="lblpopheaderusertype" runat="server" />
        </h3>
        <a href="javascript:void(0);" onclick="document.getElementById('lightusertype').style.display='none';document.getElementById('fadeusertype').style.display='none'">
            <span class="cross"></span></a>
    </div>
    <div id="errorpopheaderusertype" runat="server">
    </div>
    <div class="mini-cart">
        <div class="loginform">
            <div class="loginouter">
                <span class="loginlabel">Name:</span><span class="logininput">
                    <asp:TextBox ID="TXTusertype" runat="server" Text="Submit" CssClass="textboxstyle" /></span>
            </div>
            <div class="loginouter" id="DIVIsActive" runat="server" style="display: none;">
                <span class="loginlabel">IsActive:</span><span class="logininput">
                    <asp:CheckBox ID="ChkIsActiveusertype" runat="server" /></span>
            </div>
        </div>
    </div>
    <div class="cl">
    </div>
    <div class="add-adres-footer">
        <div class="loginbtn">
            <asp:LinkButton ID="btnSubmitusertype" Text="Submit" runat="server" OnClientClick="return btnSubmitusertype();"
                OnClick="btnSubmitusertype_Click" />
        </div>
        <div class="loginfbbtn">
            <asp:LinkButton ID="btncancel" runat="server" OnClientClick="return ClosePOPUPusertype();"
                Text="Cancel" /></div>
    </div>
    <!--add-adres-footer-->
</div>
<a onclick="document.getElementById('lightusertype').style.display='none';document.getElementById('fadeusertype').style.display='none'"
    href="javascript:void(0)" style="border: none;">
    <div id="fadeusertype" class="black_overlay1" onclick="document.getElementById('lightusertype').style.display='none';document.getElementById('fadeusertype').style.display='none'">
    </div>
</a>
<script language="javascript" type="text/javascript">
    function btnSubmitusertype() {
        var errorMessage = "";
        var isValid = true;
        jQuery("#<%= TXTusertype.ClientID %>").removeClass('textboxstyleerror');
        var txtorder = jQuery("#<%= TXTusertype.ClientID %>").val();

        if (txtorder.length <= 0) {
            if (errorMessage.length > 0) {
                errorMessage += "<br/>";
            }
            errorMessage += "Usertype is required.";
            jQuery("#<%= TXTusertype.ClientID %>").addClass('textboxstyleerror');
            isValid = false;
        }
        if (!isValid) {
            jQuery("#<%= errorpopheaderusertype.ClientID %>").show();
            jQuery("#<%= errorpopheaderusertype.ClientID %>").addClass('fk-err-all');
            jQuery("#<%= errorpopheaderusertype.ClientID %>").html(errorMessage);
            jQuery("#<%= errorpopheaderusertype.ClientID %>").addClass('fk-err-all');
            return false;
        }
        else {
            jQuery("#<%= errorpopheaderusertype.ClientID %>").html('');
            jQuery("#<%= errorpopheaderusertype.ClientID %>").removeClass('fk-err-all');
            return true;
        }
    }
    function ShowPOPUPusertype(status) {
        var errorMessage = "";
        var isValid = false;
        jQuery('#<%=btnSubmitusertype.ClientID %>').text('Submit');
        jQuery('#<%=lblpopheaderusertype.ClientID %>').text('Add User Type');
        //alert(status);
        if (status == 'true') {
            jQuery('#<%=TXTusertype.ClientID %>').val('');
            //alert(status);
        }
        else {
            jQuery('#<%=TXTusertype.ClientID %>').val('');
            jQuery("#<%= errorpopheaderusertype.ClientID %>").hide();
            //alert(status);
        }
        jQuery('#<%=DIVIsActive.ClientID %>').hide();
        document.getElementById('lightusertype').style.display = 'block';
        document.getElementById('fadeusertype').style.display = 'block';
        return isValid;
    }

    function ShowPOPUPusertypeUpdate(status) {
        var errorMessage = "";
        var isValid = false;
        //alert(status);
        jQuery('#<%=lblpopheaderusertype.ClientID %>').text('Update Usertype');
        if (status == 'true') {
            //alert(status);
        }
        else {
            jQuery('#<%=TXTusertype.ClientID %>').val('');
            jQuery("#<%= errorpopheaderusertype.ClientID %>").hide();
            //alert(status);
        }
        document.getElementById('lightusertype').style.display = 'block';
        document.getElementById('fadeusertype').style.display = 'block';
        return isValid;
    }
    function ClosePOPUPusertype() {
        var errorMessage = "";
        var isValid = true;
        document.getElementById('lightusertype').style.display = 'none';
        document.getElementById('fadeusertype').style.display = 'none';
        return isValid;
    }
</script>
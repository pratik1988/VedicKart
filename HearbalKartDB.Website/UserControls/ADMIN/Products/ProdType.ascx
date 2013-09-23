<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProdType.ascx.cs" Inherits="UserControls_ADMIN_Products_ProdType" %>
<div class="statisticsTitle">
    Product Type
    <asp:LinkButton ID="lnkAddNewprodtype" runat="server" OnClick="lnkAddNewprodtype_Click">Add New</asp:LinkButton>
</div>
<table class="adminContent">
    <asp:GridView ID="grdprodtype" CssClass="t-widget t-grid" runat="server" Width="100%"
        AutoGenerateColumns="False" RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle"
        CellPadding="0" CellSpacing="1" EmptyDataText="No record Found!" EmptyDataRowStyle-Font-Bold="true"
        EmptyDataRowStyle-HorizontalAlign="Center" EditRowStyle-VerticalAlign="Top" AllowPaging="true"
        RowStyle-CssClass="con" AlternatingRowStyle-CssClass="con-dark" GridLines="None"
        PageSize="10" BackColor="#ffffff" ShowHeader="true" OnRowDataBound="grdprodtype_RowDataBound">
        <AlternatingRowStyle CssClass="con-dark"></AlternatingRowStyle>
        <Columns>
            <asp:TemplateField>
                <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                <HeaderTemplate>
                    Type Name
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblProdType" runat="server"></asp:Label>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <asp:Label ID="lblProdType" runat="server"></asp:Label>
                </AlternatingItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                <HeaderTemplate>
                    IsActive
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:ImageButton ID="IMGBTNProdtypeisActive" runat="server" CommandArgument='<%# Eval("Id") %>'
                        OnClick="IMGBTNcategoryisActive_Click"></asp:ImageButton>
                    <asp:HiddenField ID="HDFProdTypeID" runat="server" />
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <asp:ImageButton ID="IMGBTNProdtypeisActive" runat="server" CssClass="t-alt" CommandArgument='<%# Eval("Id") %>'
                        OnClick="IMGBTNcategoryisActive_Click"></asp:ImageButton>
                    <asp:HiddenField ID="HDFProdTypeID" runat="server" />
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
<div id="lightprodtype" class="white_box" style="width: 380px;">
    <div class="add-address">
        <h3>
            <asp:Label ID="lblpopheaderprodtype" runat="server" />
        </h3>
        <a href="javascript:void(0);" onclick="document.getElementById('lightprodtype').style.display='none';document.getElementById('fadeprodtype').style.display='none'">
            <span class="cross"></span></a>
    </div>
    <div id="errorpopheaderprodtype" runat="server">
    </div>
    <div class="mini-cart">
        <div class="loginform">
            <div class="loginouter">
                <span class="loginlabel">Name:</span><span class="logininput">
                    <asp:TextBox ID="TXTprodType" runat="server" Text="Submit" /></span>
            </div>
            <div class="loginouter" id="DIVIsActive" runat="server" style="display: none;">
                <span class="loginlabel">IsActive:</span><span class="logininput">
                    <asp:CheckBox ID="ChkIsActiveprodtype" runat="server" /></span>
            </div>
        </div>
    </div>
    <div class="cl">
    </div>
    <div class="add-adres-footer">
        <div class="loginbtn">
            <asp:LinkButton ID="btnSubmitprodtype" Text="Submit" runat="server" OnClientClick="return Checkprodtype();"
                OnClick="btnSubmit_Click1" />
        </div>
        <div class="loginfbbtn">
            <asp:LinkButton ID="btncancel" runat="server" OnClientClick="return ClosePOPUPprodtype();"
                Text="Cancel" /></div>
    </div>
    <!--add-adres-footer-->
</div>
<a onclick="document.getElementById('lightprodtype').style.display='none';document.getElementById('fadeprodtype').style.display='none'"
    href="javascript:void(0)" style="border: none;">
    <div id="fadeprodtype" class="black_overlay1" onclick="document.getElementById('lightprodtype').style.display='none';document.getElementById('fadeprodtype').style.display='none'">
    </div>
</a>
<script language="javascript" type="text/javascript">
    function Checkprodtype() {
        var errorMessage = "";
        var isValid = true;

        var txtorder = jQuery("#<%= TXTprodType.ClientID %>").val();

        if (txtorder.length <= 0) {
            if (errorMessage.length > 0) {
                errorMessage += "<br/>";
            }
            errorMessage += "ProductType is required.";
            isValid = false;
        }
        if (!isValid) {
            jQuery("#<%= errorpopheaderprodtype.ClientID %>").show();
            jQuery("#<%= errorpopheaderprodtype.ClientID %>").addClass('fk-err-all');
            jQuery("#<%= errorpopheaderprodtype.ClientID %>").html(errorMessage);
            jQuery("#<%= errorpopheaderprodtype.ClientID %>").addClass('fk-err-all');
            return false;
        }
        else {
            jQuery("#<%= errorpopheaderprodtype.ClientID %>").html('');
            jQuery("#<%= errorpopheaderprodtype.ClientID %>").removeClass('fk-err-all');
            return true;
        }
    }
    function ShowPOPUPprodtype(status) {
        var errorMessage = "";
        var isValid = false;
        jQuery('#<%=btnSubmitprodtype.ClientID %>').text('Submit');
        jQuery('#<%=lblpopheaderprodtype.ClientID %>').text('Add Product Type');
        //alert(status);
        if (status == 'true') {
            jQuery('#<%=TXTprodType.ClientID %>').val('');
            //alert(status);
        }
        else {
            jQuery('#<%=TXTprodType.ClientID %>').val('');
            jQuery("#<%= errorpopheaderprodtype.ClientID %>").hide();
            //alert(status);
        }
        jQuery('#<%=DIVIsActive.ClientID %>').hide();
        document.getElementById('lightprodtype').style.display = 'block';
        document.getElementById('fadeprodtype').style.display = 'block';
        return isValid;
    }

    function ShowPOPUPprodtypeUpdate(status) {
        var errorMessage = "";
        var isValid = false;
        //alert(status);
        jQuery('#<%=lblpopheaderprodtype.ClientID %>').text('Update Product Type');
        if (status == 'true') {
            //alert(status);
        }
        else {
            jQuery('#<%=TXTprodType.ClientID %>').val('');
            jQuery("#<%= errorpopheaderprodtype.ClientID %>").hide();
            //alert(status);
        }
        document.getElementById('lightprodtype').style.display = 'block';
        document.getElementById('fadeprodtype').style.display = 'block';
        return isValid;
    }
    function ClosePOPUPprodtype() {
        var errorMessage = "";
        var isValid = true;
        document.getElementById('lightprodtype').style.display = 'none';
        document.getElementById('fadeprodtype').style.display = 'none';
        return isValid;
    }
</script>

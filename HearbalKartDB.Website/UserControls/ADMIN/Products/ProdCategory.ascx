<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProdCategory.ascx.cs"
    Inherits="UserControls_ADMIN_ProdCategory" %>
<div class="statisticsTitle">
    Product Category
    <asp:LinkButton ID="lnkAddNewordStats" runat="server" onclick="lnkAddNewordStats_Click">Add New</asp:LinkButton>
</div>
<table class="adminContent">
    <asp:GridView ID="grdprodCategory" CssClass="t-widget t-grid" runat="server" Width="100%"
        AutoGenerateColumns="False" RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle"
        CellPadding="0" CellSpacing="1" EmptyDataText="No record Found!" EmptyDataRowStyle-Font-Bold="true"
        EmptyDataRowStyle-HorizontalAlign="Center" EditRowStyle-VerticalAlign="Top" AllowPaging="true"
        RowStyle-CssClass="con" AlternatingRowStyle-CssClass="con-dark" GridLines="None"
        PageSize="10" BackColor="#ffffff" ShowHeader="true" OnRowDataBound="grdprodCategory_RowDataBound">
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
                    IsActive
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:ImageButton ID="IMGBTNcategoryisActive" runat="server" 
                        CommandArgument='<%# Eval("Id") %>' onclick="IMGBTNcategoryisActive_Click">
                    </asp:ImageButton>
                    <asp:HiddenField ID="HDFCategoryID" runat="server" />
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <asp:ImageButton ID="IMGBTNcategoryisActive" runat="server" CssClass="t-alt" CommandArgument='<%# Eval("Id") %>' onclick="IMGBTNcategoryisActive_Click">
                    </asp:ImageButton>
                    <asp:HiddenField ID="HDFCategoryID" runat="server" />
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
<div id="light" class="white_box" style="width: 380px;">
    <div class="add-address">
        <h3>
            Add product category</h3>
        <a href="javascript:void(0);" onclick="document.getElementById('light').style.display='none';document.getElementById('fade').style.display='none'">
            <span class="cross"></span></a>
    </div>
    <div id="errorpopupStatus" runat="server">
    </div>
    <div class="mini-cart">
        <div class="loginform">
            <div class="loginouter">
                <span class="loginlabel">Name:</span><span class="logininput">
                    <asp:TextBox ID="TXTcategory" runat="server" Text="Submit" /></span>
            </div>
            <div class="loginouter" id="DIVIsActive" runat="server" style="display: none;">
                <span class="loginlabel">IsActive:</span><span class="logininput">
                    <asp:CheckBox ID="ChkIsActive" runat="server" /></span>
            </div>
        </div>
    </div>
    <div class="cl">
    </div>
    <div class="add-adres-footer">
        <div class="loginbtn">
            <asp:LinkButton ID="btnSubmit" Text="Submit" runat="server" OnClientClick="return Checkprodcategory();"  OnClick="btnSubmit_Click1"/>
        </div>
        <div class="loginfbbtn">
            <asp:LinkButton ID="btncancel" runat="server" OnClientClick="return ClosePOPUP();"
                Text="Cancel" /></div>
    </div>
    <!--add-adres-footer-->
</div>
<a onclick="document.getElementById('light').style.display='none';document.getElementById('fade').style.display='none'"
    href="javascript:void(0)" style="border: none;">
    <div id="fade" class="black_overlay1" onclick="document.getElementById('light').style.display='none';document.getElementById('fade').style.display='none'">
    </div>
</a>
<script language="javascript" type="text/javascript">
    function ShowPOPUP(status) {
        var errorMessage = "";
        var isValid = false;
        jQuery('#<%=btnSubmit.ClientID %>').text('Submit');
        //alert(status);
        if (status == 'true') {
            jQuery('#<%=TXTcategory.ClientID %>').val('');
            //alert(status);
        }
        else {
            jQuery('#<%=TXTcategory.ClientID %>').val('');
            jQuery("#<%= errorpopupStatus.ClientID %>").hide();
            //alert(status);
        }
        jQuery('#<%=DIVIsActive.ClientID %>').hide();
        document.getElementById('light').style.display = 'block';
        document.getElementById('fade').style.display = 'block';
        return isValid;
    }

    function ShowPOPUPUpdate(status) {
        var errorMessage = "";
        var isValid = false;
        //alert(status);
        if (status == 'true') {
            //alert(status);
        }
        else {
            jQuery('#<%=TXTcategory.ClientID %>').val('');
            jQuery("#<%= errorpopupStatus.ClientID %>").hide();
            //alert(status);
        }
        document.getElementById('light').style.display = 'block';
        document.getElementById('fade').style.display = 'block';
        return isValid;
    }
    function ClosePOPUP() {
        var errorMessage = "";
        var isValid = true;
        document.getElementById('light').style.display = 'none';
        document.getElementById('fade').style.display = 'none';
        return isValid;
    }
    function Checkprodcategory() {
        var errorMessage = "";
        var isValid = true;

        var txtorder = jQuery("#<%= TXTcategory.ClientID %>").val();

        if (txtorder.length <= 0) {
            if (errorMessage.length > 0) {
                errorMessage += "<br/>";
            }
            errorMessage += "Category is required.";
            isValid = false;
        }
        if (!isValid) {
            jQuery("#<%= errorpopupStatus.ClientID %>").show();
            jQuery("#<%= errorpopupStatus.ClientID %>").addClass('fk-err-all');
            jQuery("#<%= errorpopupStatus.ClientID %>").html(errorMessage);
            jQuery("#<%= errorpopupStatus.ClientID %>").addClass('fk-err-all');
            return false;
        }
        else {
            jQuery("#<%= errorpopupStatus.ClientID %>").html('');
            jQuery("#<%= errorpopupStatus.ClientID %>").removeClass('fk-err-all');
            return true;
        }
    }
</script>

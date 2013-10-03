<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProdCompany.ascx.cs" Inherits="UserControls_ADMIN_ProdCompany" %>
<div class="statisticsTitle">
    Product Company
    <asp:LinkButton ID="lnkaddnewcomp" runat="server" OnClick="lnkaddnewcomp_Click">Add New</asp:LinkButton>
</div>
<table class="adminContent">
    <asp:GridView ID="grdprodcompany" CssClass="t-widget t-grid" runat="server" Width="100%"
        AutoGenerateColumns="False" RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle"
        CellPadding="0" CellSpacing="1" EmptyDataText="No record Found!" EmptyDataRowStyle-Font-Bold="true"
        EmptyDataRowStyle-HorizontalAlign="Center" EditRowStyle-VerticalAlign="Top" AllowPaging="true"
        RowStyle-CssClass="con" AlternatingRowStyle-CssClass="con-dark" GridLines="None"
        PageSize="10" BackColor="#ffffff" ShowHeader="true" OnRowDataBound="grdprodcompany_RowDataBound">
        <AlternatingRowStyle CssClass="con-dark"></AlternatingRowStyle>
        <Columns>
            <asp:TemplateField>
                <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                <HeaderTemplate>
                    Company Name
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblCompanyname" runat="server"></asp:Label>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <asp:Label ID="lblCompanyname" runat="server"></asp:Label>
                </AlternatingItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                <HeaderTemplate>
                    IsActive
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:ImageButton ID="IMGBTNcompanyisActive" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="IMGBTNcompanyisActive_Click">
                    </asp:ImageButton>
                    <asp:HiddenField ID="HDFCompanyID" runat="server" />
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <asp:ImageButton ID="IMGBTNcompanyisActive" runat="server" CssClass="t-alt" CommandArgument='<%# Eval("Id") %>' OnClick="IMGBTNcompanyisActive_Click" />
                    <asp:HiddenField ID="HDFCompanyID" runat="server" />
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
<div id="lightcomp" class="white_box" style="width: 380px;">
    <div class="add-address">
        <h3>
            <asp:Label ID="lblpopuphead" runat="server" /></h3>
        <a href="javascript:void(0);" onclick="document.getElementById('lightcomp').style.display='none';document.getElementById('Div4').style.display='none'">
            <span class="cross"></span></a>
    </div>
    <div id="errorpopupcompany" runat="server">
    </div>
    <div class="mini-cart">
        <div class="loginform">
            <div class="loginouter">
                <span class="loginlabel">Name:</span><span class="logininput">
                    <asp:TextBox ID="txtcompname" runat="server"/></span>
            </div>
            <div class="loginouter" id="DIVIsActivecomp" runat="server" style="display: none;">
                <span class="loginlabel">IsActive:</span><span class="logininput">
                    <asp:CheckBox ID="chkisactivecomp" runat="server" /></span>
            </div>
        </div>
    </div>
    <div class="cl">
    </div>
    <div class="add-adres-footer">
        <div class="loginbtn">
            <asp:LinkButton ID="btnsubmitcompany" Text="Submit" runat="server" OnClientClick="return Checkprodcomp();"
                OnClick="btnsubmitcompany_Click1" />
        </div>
        <div class="loginfbbtn">
            <asp:LinkButton ID="LinkButton3" runat="server" OnClientClick="return ClosePOPUPcomp();"
                Text="Cancel" /></div>
    </div>
    <!--add-adres-footer-->
</div>
<a onclick="document.getElementById('lightcomp').style.display='none';document.getElementById('fade').style.display='none'"
    href="javascript:void(0)" style="border: none;">
    <div id="Div4" class="black_overlay1" onclick="document.getElementById('lightcomp').style.display='none';document.getElementById('Div4').style.display='none'">
    </div>
</a>
<script language="javascript" type="text/javascript">
    function ShowPOPUPCompany(status) {
        var errorMessage = "";
        var isValid = false;
        jQuery('#<%=btnsubmitcompany.ClientID %>').text('Submit');
        jQuery('#<%=lblpopuphead.ClientID %>').text('Add Product Comapny');
        //alert(status);
        if (status == 'true') {
            jQuery('#<%=txtcompname.ClientID %>').val('');
            //alert(status);
        }
        else {
            jQuery('#<%=txtcompname.ClientID %>').val('');
            jQuery("#<%= errorpopupcompany.ClientID %>").hide();
            //alert(status);
        }
        jQuery('#<%=DIVIsActivecomp.ClientID %>').hide();
        document.getElementById('lightcomp').style.display = 'block';
        document.getElementById('Div4').style.display = 'block';
        return isValid;
    }

    function ShowPOPUPUpdatecomp(status) {
        var errorMessage = "";
        var isValid = false;
        //alert(status);
        jQuery('#<%=lblpopuphead.ClientID %>').text('');
        jQuery('#<%=lblpopuphead.ClientID %>').text('Update Product Comapny');
        if (status == 'true') {
            //alert(status);
        }
        else {
            jQuery('#<%=txtcompname.ClientID %>').val('');
            jQuery("#<%= errorpopupcompany.ClientID %>").hide();
            //alert(status);
        }
        document.getElementById('lightcomp').style.display = 'block';
        document.getElementById('Div4').style.display = 'block';
        return isValid;
    }
    function ClosePOPUPcomp() {
        var errorMessage = "";
        var isValid = true;
        document.getElementById('light').style.display = 'none';
        document.getElementById('fade').style.display = 'none';
        return isValid;
    }
   
    function Checkprodcomp() {
        var errorMessage = "";
        var isValid = true;

        var txtorder = jQuery("#<%= txtcompname.ClientID %>").val();

        if (txtorder.length <= 0) {
            if (errorMessage.length > 0) {
                errorMessage += "<br/>";
            }
            errorMessage += "CompanyName is required.";
            isValid = false;
        }
        if (!isValid) {
            jQuery("#<%= errorpopupcompany.ClientID %>").show();
            jQuery("#<%= errorpopupcompany.ClientID %>").addClass('fk-err-all');
            jQuery("#<%= errorpopupcompany.ClientID %>").html(errorMessage);
            jQuery("#<%= errorpopupcompany.ClientID %>").addClass('fk-err-all');
            return false;
        }
        else {
            jQuery("#<%= errorpopupcompany.ClientID %>").html('');
            jQuery("#<%= errorpopupcompany.ClientID %>").removeClass('fk-err-all');
            return true;
        }
    }
</script>

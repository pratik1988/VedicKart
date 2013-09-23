<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProdMedicineFor.ascx.cs"
    Inherits="UserControls_ADMIN_Products_ProdMedicineFor" %>
<div class="statisticsTitle">
    Product MedicineFor
    <asp:LinkButton ID="lnkAddNewprodmedicine" runat="server" OnClick="lnkAddNewprodmedicine_Click">Add New</asp:LinkButton>
</div>
<table class="adminContent">
    <asp:GridView ID="grdprodmedicnfr" CssClass="t-widget t-grid" runat="server" Width="100%"
        AutoGenerateColumns="False" RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle"
        CellPadding="0" CellSpacing="1" EmptyDataText="No record Found!" EmptyDataRowStyle-Font-Bold="true"
        EmptyDataRowStyle-HorizontalAlign="Center" EditRowStyle-VerticalAlign="Top" AllowPaging="true"
        RowStyle-CssClass="con" AlternatingRowStyle-CssClass="con-dark" GridLines="None"
        PageSize="10" BackColor="#ffffff" ShowHeader="true" OnRowDataBound="grdprodmedicnfr_RowDataBound">
        <AlternatingRowStyle CssClass="con-dark"></AlternatingRowStyle>
        <Columns>
            <asp:TemplateField>
                <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                <HeaderTemplate>
                    Medicine Name
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblmedicinename" runat="server"></asp:Label>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <asp:Label ID="lblmedicinename" runat="server"></asp:Label>
                </AlternatingItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                <HeaderTemplate>
                    IsActive
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:ImageButton ID="IMGBTNmedicineisActive" runat="server" CommandArgument='<%# Eval("Id") %>'
                        OnClick="IMGBTNcategoryisActive_Click"></asp:ImageButton>
                    <asp:HiddenField ID="HDFmedicineID" runat="server" />
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <asp:ImageButton ID="IMGBTNmedicineisActive" runat="server" CssClass="t-alt" CommandArgument='<%# Eval("Id") %>'
                        OnClick="IMGBTNcategoryisActive_Click"></asp:ImageButton>
                    <asp:HiddenField ID="HDFmedicineID" runat="server" />
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
<div id="lightmedine" class="white_box" style="width: 380px;">
    <div class="add-address">
        <h3>
            <asp:Label ID="lblpopheadermedi" runat="server" /> </h3>
        <a href="javascript:void(0);" onclick="document.getElementById('lightmedine').style.display='none';document.getElementById('fademedicine').style.display='none'">
            <span class="cross"></span></a>
    </div>
    <div id="errorpopupmedicine" runat="server">
    </div>
    <div class="mini-cart">
        <div class="loginform">
            <div class="loginouter">
                <span class="loginlabel">Name:</span><span class="logininput">
                    <asp:TextBox ID="TXTmedicine" runat="server" Text="Submit" /></span>
            </div>
            <div class="loginouter" id="DIVIsActive" runat="server" style="display: none;">
                <span class="loginlabel">IsActive:</span><span class="logininput">
                    <asp:CheckBox ID="ChkIsActivemedicine" runat="server" /></span>
            </div>
        </div>
    </div>
    <div class="cl">
    </div>
    <div class="add-adres-footer">
        <div class="loginbtn">
            <asp:LinkButton ID="btnSubmitmedicine" Text="Submit" runat="server" OnClientClick="return Checkprodcategorymedi();"
                OnClick="btnSubmit_Click1" />
        </div>
        <div class="loginfbbtn">
            <asp:LinkButton ID="btncancel" runat="server" OnClientClick="return ClosePOPUPmedi();"
                Text="Cancel" /></div>
    </div>
    <!--add-adres-footer-->
</div>
<a onclick="document.getElementById('lightmedine').style.display='none';document.getElementById('fademedicine').style.display='none'"
    href="javascript:void(0)" style="border: none;">
    <div id="fademedicine" class="black_overlay1" onclick="document.getElementById('lightmedine').style.display='none';document.getElementById('fademedicine').style.display='none'">
    </div>
</a>
<script language="javascript" type="text/javascript">
    function Checkprodcategorymedi() {
        var errorMessage = "";
        var isValid = true;

        var txtorder = jQuery("#<%= TXTmedicine.ClientID %>").val();

        if (txtorder.length <= 0) {
            if (errorMessage.length > 0) {
                errorMessage += "<br/>";
            }
            errorMessage += "ProdMedicine is required.";
            isValid = false;
        }
        if (!isValid) {
            jQuery("#<%= errorpopupmedicine.ClientID %>").show();
            jQuery("#<%= errorpopupmedicine.ClientID %>").addClass('fk-err-all');
            jQuery("#<%= errorpopupmedicine.ClientID %>").html(errorMessage);
            jQuery("#<%= errorpopupmedicine.ClientID %>").addClass('fk-err-all');
            return false;
        }
        else {
            jQuery("#<%= errorpopupmedicine.ClientID %>").html('');
            jQuery("#<%= errorpopupmedicine.ClientID %>").removeClass('fk-err-all');
            return true;
        }
    }
    function ShowPOPUPmedicine(status) {
        var errorMessage = "";
        var isValid = false;
        jQuery('#<%=btnSubmitmedicine.ClientID %>').text('Submit');
        jQuery('#<%=lblpopheadermedi.ClientID %>').text('Add Product MedicineFor');
        //alert(status);
        if (status == 'true') {
            jQuery('#<%=TXTmedicine.ClientID %>').val('');
            //alert(status);
        }
        else {
            jQuery('#<%=TXTmedicine.ClientID %>').val('');
            jQuery("#<%= errorpopupmedicine.ClientID %>").hide();
            //alert(status);
        }
        jQuery('#<%=DIVIsActive.ClientID %>').hide();
        document.getElementById('lightmedine').style.display = 'block';
        document.getElementById('fademedicine').style.display = 'block';
        return isValid;
    }

    function ShowPOPUPmedicineUpdate(status) {
        var errorMessage = "";
        var isValid = false;
        //alert(status);
        jQuery('#<%=lblpopheadermedi.ClientID %>').text('Update Product MedicineFor');
        if (status == 'true') {
            //alert(status);
        }
        else {
            jQuery('#<%=TXTmedicine.ClientID %>').val('');
            jQuery("#<%= errorpopupmedicine.ClientID %>").hide();
            //alert(status);
        }
        document.getElementById('lightmedine').style.display = 'block';
        document.getElementById('fademedicine').style.display = 'block';
        return isValid;
    }
    function ClosePOPUPmedi() {
        var errorMessage = "";
        var isValid = true;
        document.getElementById('lightmedine').style.display = 'none';
        document.getElementById('fademedicine').style.display = 'none';
        return isValid;
    }
</script>

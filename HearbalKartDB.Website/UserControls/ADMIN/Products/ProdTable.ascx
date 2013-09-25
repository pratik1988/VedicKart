<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProdTable.ascx.cs" Inherits="UserControls_ADMIN_Products_ProdTable" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<td class="orderaveragereport">
    <div class="statisticsTitle">
        Products
        <asp:LinkButton ID="lnkAddNewprod" runat="server" OnClick="lnkAddNewprod_Click">Add New</asp:LinkButton>
    </div>
    <table class="adminContent">
        <asp:GridView ID="grdprod" CssClass="t-widget t-grid" runat="server" Width="100%"
            AutoGenerateColumns="False" RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle"
            CellPadding="0" CellSpacing="1" EmptyDataText="No record Found!" EmptyDataRowStyle-Font-Bold="true"
            EmptyDataRowStyle-HorizontalAlign="Center" EditRowStyle-VerticalAlign="Top" AllowPaging="true"
            RowStyle-CssClass="con" AlternatingRowStyle-CssClass="con-dark" GridLines="None"
            PageSize="10" BackColor="#ffffff" ShowHeader="true" OnRowDataBound="grdprod_RowDataBound">
            <AlternatingRowStyle CssClass="con-dark"></AlternatingRowStyle>
            <Columns>
                <asp:TemplateField>
                    <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                    <HeaderTemplate>
                        Product
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Image ID="IMGProd" runat="server" ></asp:Image>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <asp:Image ID="IMGProd" runat="server" ></asp:Image>
                    </AlternatingItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                    <HeaderTemplate>
                        Item Name
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblProdname" runat="server"></asp:Label>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <asp:Label ID="lblProdname" runat="server"></asp:Label>
                    </AlternatingItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                    <HeaderTemplate>
                        Category Name
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblProdctg" runat="server"></asp:Label>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <asp:Label ID="lblProdctg" runat="server"></asp:Label>
                    </AlternatingItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                    <HeaderTemplate>
                        Company Name
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblProdcomp" runat="server"></asp:Label>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <asp:Label ID="lblProdcomp" runat="server"></asp:Label>
                    </AlternatingItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                    <HeaderTemplate>
                        Product Type
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblProdtype" runat="server"></asp:Label>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <asp:Label ID="lblProdtype" runat="server"></asp:Label>
                    </AlternatingItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                    <HeaderTemplate>
                        Product Supplement
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblProdsupp" runat="server"></asp:Label>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <asp:Label ID="lblProdsupp" runat="server"></asp:Label>
                    </AlternatingItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                    <HeaderTemplate>
                        Product MedicineFor
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblProdmedicinefor" runat="server"></asp:Label>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <asp:Label ID="lblProdmedicinefor" runat="server"></asp:Label>
                    </AlternatingItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                    <HeaderTemplate>
                        Item PurchaseCost
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblProdPcost" runat="server"></asp:Label>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <asp:Label ID="lblProdPcost" runat="server"></asp:Label>
                    </AlternatingItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                    <HeaderTemplate>
                        Item SellCost
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblProdScost" runat="server"></asp:Label>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <asp:Label ID="lblProdScost" runat="server"></asp:Label>
                    </AlternatingItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                    <HeaderTemplate>
                        Product Offer
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblProdoffer" runat="server"></asp:Label>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <asp:Label ID="lblProdoffer" runat="server"></asp:Label>
                    </AlternatingItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                    <HeaderTemplate>
                        IsActive
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="IMGBTNProdisActive" runat="server" CommandArgument='<%# Eval("Id") %>'
                            OnClick="IMGBTNProdisActive_Click"></asp:ImageButton>
                        <asp:HiddenField ID="HDFProdID" runat="server" />
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <asp:ImageButton ID="IMGBTNProdisActive" runat="server" CssClass="t-alt" CommandArgument='<%# Eval("Id") %>'
                            OnClick="IMGBTNProdisActive_Click"></asp:ImageButton>
                        <asp:HiddenField ID="HDFProdID" runat="server" />
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
    <div id="lightprod" class="white_box_big" style="width: 700px;">
        <div class="add-address">
            <h3>
                <asp:Label ID="lblpopheaderprod" runat="server" />
            </h3>
            <a href="javascript:void(0);" onclick="document.getElementById('lightprod').style.display='none';document.getElementById('fadeprod').style.display='none'">
                <span class="cross1"></span></a>
        </div>
        <div id="errorpopheaderprod" runat="server">
        </div>
        <div class="mini-cart1">
            <div class="loginform1">
                <div class="loginouter1">
                    <span class="loginlabel1">ProductName:</span><span class="logininput1">
                        <asp:TextBox ID="TXTprod" runat="server" Text="Submit" CssClass="textboxstyle" /></span>
                    <span class="loginlabel1">ProductImage:</span> <span class="logininput1">
                        <asp:TextBox ID="TXTProdimg" runat="server" CssClass="file" />
                        <div class="file_upload">
                            <asp:FileUpload ID="file_upload" runat="server" />
                        </div>
                    </span>
                    <%--<span class="loginlabel1">ProductImage:</span><span class="logininput1">
                        <asp:FileUpload ID="FileUpload1" runat="server"  CssClass="textboxstyle" /></span>--%>
                </div>
            </div>
            <div class="loginform1">
                <div class="loginouter1">
                    <span class="loginlabel1">Category</span><span class="logininput1">
                        <asp:DropDownList ID="DrpCategory" runat="server" />
                    </span><span class="loginlabel1">Company:</span> <span class="logininput1">
                        <asp:DropDownList ID="drpcompany" runat="server" />
                    </span>
                </div>
            </div>
            <div class="loginform1">
                <div class="loginouter1">
                    <span class="loginlabel1">Type</span><span class="logininput1">
                        <asp:DropDownList ID="Drptype" runat="server" />
                    </span><span class="loginlabel1">Supplement:</span> <span class="logininput1">
                        <asp:DropDownList ID="Drpsupplement" runat="server" />
                    </span>
                </div>
            </div>
            <div class="loginform1">
                <div class="loginouter1">
                    <span class="loginlabel1">Purchase Price</span><span class="logininput1">
                        <asp:TextBox ID="txtitmpurchase" runat="server" CssClass="textboxstyle" />
                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="txtitmpurchase"
                            ValidChars="-0123456789." runat="server">
                        </asp:FilteredTextBoxExtender>
                    </span><span class="loginlabel1">SellPrice:</span> <span class="logininput1">
                        <asp:TextBox ID="txtitmSell" runat="server" CssClass="textboxstyle" />
                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txtitmSell"
                            ValidChars="-0123456789." runat="server">
                        </asp:FilteredTextBoxExtender>
                    </span>
                </div>
            </div>
            <div class="loginform1">
                <div class="loginouter1">
                    <span class="loginlabel1">MedicineFor</span><span class="logininput1">
                        <asp:DropDownList ID="DrpmedicineFor" runat="server" />
                    </span><span class="loginlabel1">Offer:</span> <span class="logininput1">
                        <asp:DropDownList ID="DrpOffer" runat="server" />
                    </span>
                </div>
            </div>
        </div>
        <div class="cl">
        </div>
        <div class="add-adres-footer">
            <div class="loginbtn">
                <asp:LinkButton ID="btnSubmitprod" Text="Submit" runat="server" OnClientClick="return Checkprod();"
                    OnClick="btnSubmitprod_Click" />
            </div>
            <div class="loginfbbtn">
                <asp:LinkButton ID="btncancelprod" runat="server" Text="Cancel" /></div>
        </div>
        <!--add-adres-footer-->
    </div>
    <a onclick="document.getElementById('lightprod').style.display='none';document.getElementById('fadeprod').style.display='none'"
        href="javascript:void(0)" style="border: none;">
        <div id="fadeprod" class="black_overlay1" onclick="document.getElementById('lightprod').style.display='none';document.getElementById('fadeprod').style.display='none'">
        </div>
    </a>
    <script type="text/javascript">
        function SetFileName(fuID, txtID) {
            var arrFileName = document.getElementById(fuID).value.split('\\');
            document.getElementById(txtID).value = arrFileName[arrFileName.length - 1];
        }


        function ShowPOPUPprodUpdate(status) {
            var errorMessage = "";
            var isValid = false;
            //alert(status);
            jQuery('#<%=lblpopheaderprod.ClientID %>').text('Update Product');
            if (status == 'true') {
                //alert(status);
            }
            else {
                jQuery('#<%=TXTprod.ClientID %>').val('');
                jQuery("#<%= errorpopheaderprod.ClientID %>").hide();
                //alert(status);
            }
            document.getElementById('fadeprod').style.display = 'block';
            document.getElementById('lightprod').style.display = 'block';
            return isValid;
        }
    </script>
    <script language="javascript" type="text/javascript">
        function ShowPOPUPprodtable(status) {
            var errorMessage = "";
            var isValid = false;

            jQuery('#<%=lblpopheaderprod.ClientID %>').text('Add Products');
            //alert(status);
            if (status == 'true') {
                //alert(status);
            }
            else {
                var TXTProdimg = jQuery("#<%= TXTProdimg.ClientID %>").val('');
                var txtitmpurchase = jQuery("#<%= txtitmpurchase.ClientID %>").val('');
                var txtitmSell = jQuery("#<%= txtitmSell.ClientID %>").val('');
                var DrpCategory = jQuery("#<%= DrpCategory.ClientID %>").val('0');
                var drpcompany = jQuery("#<%= drpcompany.ClientID %>").val('0');
                var Drptype = jQuery("#<%= Drptype.ClientID %>").val('0');
                var Drpsupplement = jQuery("#<%= Drpsupplement.ClientID %>").val('0');
                var DrpmedicineFor = jQuery("#<%= DrpmedicineFor.ClientID %>").val('0');
                var DrpOffer = jQuery("#<%= DrpOffer.ClientID %>").val('0');
                jQuery('#<%=TXTprod.ClientID %>').val('');
                jQuery("#<%= errorpopheaderprod.ClientID %>").hide();
                //alert(status);
            }
            document.getElementById('lightprod').style.display = 'block';
            document.getElementById('fadeprod').style.display = 'block';
            return isValid;
        }

        function ShowPOPUPupdateprodtable(status) {
            var errorMessage = "";
            var isValid = false;

            jQuery('#<%=lblpopheaderprod.ClientID %>').text('Update Products');
            //alert(status);
            if (status == 'true') {
                //alert(status);
            }
            else {
                //alert(status);
            }
            document.getElementById('lightprod').style.display = 'block';
            document.getElementById('fadeprod').style.display = 'block';
            return isValid;
        }

        function Checkprod() {
            var errorMessage = "";
            var isValid = true;
            jQuery("#<%= TXTprod.ClientID %>").removeClass('textboxstyleerror');
            jQuery("#<%= TXTProdimg.ClientID %>").removeClass('textboxstyleerror');
            jQuery("#<%= txtitmpurchase.ClientID %>").removeClass('textboxstyleerror');
            jQuery("#<%= txtitmSell.ClientID %>").removeClass('textboxstyleerror');
            jQuery("#<%= DrpCategory.ClientID %>").removeClass('selecterror');
            jQuery("#<%= drpcompany.ClientID %>").removeClass('selecterror');
            jQuery("#<%= Drptype.ClientID %>").removeClass('selecterror');
            jQuery("#<%= Drpsupplement.ClientID %>").removeClass('selecterror');
            jQuery("#<%= DrpmedicineFor.ClientID %>").removeClass('selecterror');
            var TXTprod = jQuery("#<%= TXTprod.ClientID %>").val();
            var TXTProdimg = jQuery("#<%= TXTProdimg.ClientID %>").val();
            var txtitmpurchase = jQuery("#<%= txtitmpurchase.ClientID %>").val();
            var txtitmSell = jQuery("#<%= txtitmSell.ClientID %>").val();
            var DrpCategory = jQuery("#<%= DrpCategory.ClientID %>").val();
            var drpcompany = jQuery("#<%= drpcompany.ClientID %>").val();
            var Drptype = jQuery("#<%= Drptype.ClientID %>").val();
            var Drpsupplement = jQuery("#<%= Drpsupplement.ClientID %>").val();
            var DrpmedicineFor = jQuery("#<%= DrpmedicineFor.ClientID %>").val();
            if (DrpCategory == "0") {
                if (errorMessage.length > 0) {
                    errorMessage += "<br/>";
                }
                errorMessage += 'Category is required.';
                jQuery("#<%= DrpCategory.ClientID %>").addClass('selecterror');
                isValid = false;
            }

            if (drpcompany == "0") {
                if (errorMessage.length > 0) {
                    errorMessage += "<br/>";
                }
                errorMessage += 'Company is required.';
                isValid = false;
            }
            if (Drptype == "0") {
                if (errorMessage.length > 0) {
                    errorMessage += "<br/>";
                }
                errorMessage += 'Type is required.';
                jQuery("#<%= Drptype.ClientID %>").addClass('selecterror');
                isValid = false;
            }

            if (Drpsupplement == "0") {
                if (errorMessage.length > 0) {
                    errorMessage += "<br/>";
                }
                errorMessage += 'Supplyment is required.';
                jQuery("#<%= Drpsupplement.ClientID %>").addClass('selecterror');
                isValid = false;
            }
            if (DrpmedicineFor == "0") {
                if (errorMessage.length > 0) {
                    errorMessage += "<br/>";
                }
                errorMessage += 'MedicineFor is required.';
                jQuery("#<%= DrpmedicineFor.ClientID %>").addClass('selecterror');
                isValid = false;
            }
            if (TXTprod.length <= 0) {
                if (errorMessage.length > 0) {
                    errorMessage += "<br/>";
                }
                errorMessage += "Product is required.";
                jQuery("#<%= TXTprod.ClientID %>").addClass('textboxstyleerror');
                isValid = false;
            }
            if (TXTProdimg.length <= 0) {
                if (errorMessage.length > 0) {
                    errorMessage += "<br/>";
                }
                errorMessage += "Image is required.";
                jQuery("#<%= TXTProdimg.ClientID %>").addClass('textboxstyleerror');
                isValid = false;
            }
            if (txtitmpurchase.length <= 0) {
                if (errorMessage.length > 0) {
                    errorMessage += "<br/>";
                }
                errorMessage += "Purchase Amount is required.";
                jQuery("#<%= txtitmpurchase.ClientID %>").addClass('textboxstyleerror');
                isValid = false;
            }
            if (txtitmSell.length <= 0) {
                if (errorMessage.length > 0) {
                    errorMessage += "<br/>";
                }
                errorMessage += "Selling Amount is required.";
                jQuery("#<%= txtitmSell.ClientID %>").addClass('textboxstyleerror');
                isValid = false;
            }
            if (!isValid) {
                jQuery("#<%= errorpopheaderprod.ClientID %>").show();
                jQuery("#<%= errorpopheaderprod.ClientID %>").removeClass('fk-msg-success');
                jQuery("#<%= errorpopheaderprod.ClientID %>").addClass('fk-err-all');
                jQuery("#<%= errorpopheaderprod.ClientID %>").html(errorMessage);
                jQuery("#<%= errorpopheaderprod.ClientID %>").addClass('fk-err-all');
                jQuery("#lightprod").addClass('white_box_big_error');
                return false;
            }
            else {
                jQuery("#<%= errorpopheaderprod.ClientID %>").html('');
                jQuery("#<%= errorpopheaderprod.ClientID %>").removeClass('fk-err-all');
                jQuery("#lightprod").removeClass('white_box_big_error');
                return true;
            }
        }
    </script>
</td>

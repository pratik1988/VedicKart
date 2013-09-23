<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Customer.ascx.cs" Inherits="UserControls_ADMIN_Customers_Customer" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<td class="orderaveragereport">
    <div class="statisticsTitle">
        Customers
        <asp:LinkButton ID="lnkAddNewcust" runat="server" OnClick="lnkAddNewcust_Click">Add New</asp:LinkButton>
    </div>
    <table class="adminContent">
        <asp:GridView ID="grdcust" CssClass="t-widget t-grid" runat="server" Width="100%"
            AutoGenerateColumns="False" RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle"
            CellPadding="0" CellSpacing="1" EmptyDataText="No record Found!" EmptyDataRowStyle-Font-Bold="true"
            EmptyDataRowStyle-HorizontalAlign="Center" EditRowStyle-VerticalAlign="Top" AllowPaging="true"
            RowStyle-CssClass="con" AlternatingRowStyle-CssClass="con-dark" GridLines="None"
            PageSize="10" BackColor="#ffffff" ShowHeader="true" OnRowDataBound="grdcust_RowDataBound">
            <AlternatingRowStyle CssClass="con-dark"></AlternatingRowStyle>
            <Columns>
                <asp:TemplateField>
                    <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                    <HeaderTemplate>
                         Name
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblcustname" runat="server"></asp:Label>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <asp:Label ID="lblcustname" runat="server"></asp:Label>
                    </AlternatingItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                    <HeaderTemplate>
                       Email
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblemailID" runat="server"></asp:Label>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <asp:Label ID="lblemailID" runat="server"></asp:Label>
                    </AlternatingItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                    <HeaderTemplate>
                        User Type
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblcustType" runat="server"></asp:Label>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <asp:Label ID="lblcustType" runat="server"></asp:Label>
                    </AlternatingItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                    <HeaderTemplate>
                        Gender
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblcustGender" runat="server"></asp:Label>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <asp:Label ID="lblcustGender" runat="server"></asp:Label>
                    </AlternatingItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                    <HeaderTemplate>
                        FirstName
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblcustFname" runat="server"></asp:Label>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <asp:Label ID="lblcustFname" runat="server"></asp:Label>
                    </AlternatingItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                    <HeaderTemplate>
                        LastName
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblcustLname" runat="server"></asp:Label>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <asp:Label ID="lblcustLname" runat="server"></asp:Label>
                    </AlternatingItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                    <HeaderTemplate>
                        MobileNo
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblcustmobNo" runat="server"></asp:Label>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <asp:Label ID="lblcustmobNo" runat="server"></asp:Label>
                    </AlternatingItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                    <HeaderTemplate>
                        LandNo
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblcustlandNo" runat="server"></asp:Label>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <asp:Label ID="lblcustlandNo" runat="server"></asp:Label>
                    </AlternatingItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                    <HeaderTemplate>
                        IsActive
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="IMGBTNCustisActive" runat="server" CommandArgument='<%# Eval("Id") %>'
                            OnClick="IMGBTNCustisActive_Click"></asp:ImageButton>
                        <asp:HiddenField ID="HDFcustID" runat="server" />
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <asp:ImageButton ID="IMGBTNCustisActive" runat="server" CssClass="t-alt" CommandArgument='<%# Eval("Id") %>'
                            OnClick="IMGBTNCustisActive_Click"></asp:ImageButton>
                        <asp:HiddenField ID="HDFcustID" runat="server" />
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
    <div id="lightcust" class="white_box_big" style="width: 700px;">
        <div class="add-address">
            <h3>
                <asp:Label ID="lblpopheadercust" runat="server" />
            </h3>
            <a href="javascript:void(0);" onclick="document.getElementById('lightcust').style.display='none';document.getElementById('fadecust').style.display='none'">
                <span class="cross1"></span></a>
        </div>
        <div id="errorpopheadercust" runat="server">
        </div>
        <div class="mini-cart1">
            <div class="loginform1">
                <div class="loginouter1">
                    <span class="loginlabel1">Name:</span><span class="logininput1">
                        <asp:TextBox ID="TXTcust" runat="server" Text="Submit" CssClass="textboxstyle" /></span>
                    <span class="loginlabel1">EmailID:</span> <span class="logininput1">
                       <asp:TextBox ID="TXTcustEmail" runat="server" Text="Submit" CssClass="textboxstyle" />
                    </span>
                    <%--<span class="loginlabel1">ProductImage:</span><span class="logininput1">
                        <asp:FileUpload ID="FileUpload1" runat="server"  CssClass="textboxstyle" /></span>--%>
                </div>
            </div>
            <div class="loginform1">
                <div class="loginouter1">
                    <span class="loginlabel1">Password</span><span class="logininput1">
                        <asp:TextBox ID="txtcustPass" runat="server" Text="Submit" CssClass="textboxstyle" />
                    </span><span class="loginlabel1">UserType:</span> <span class="logininput1">
                        <asp:DropDownList ID="drpUserType" runat="server" />

                    </span>
                </div>
            </div>
            <div class="loginform1">
                <div class="loginouter1">
                    <span class="loginlabel1">Gender</span><span class="logininput1">
                        <asp:DropDownList ID="Drpgender" runat="server" />
                    </span><span class="loginlabel1">FirstName:</span> <span class="logininput1">
                          <asp:TextBox ID="txtcustfrstname" runat="server" Text="Submit" CssClass="textboxstyle" />
                    </span>
                </div>
            </div>
            <div class="loginform1">
                <div class="loginouter1">
                    <span class="loginlabel1">LastName</span><span class="logininput1">
                        <asp:TextBox ID="txtcustlastnme" runat="server" CssClass="textboxstyle" />
                    </span><span class="loginlabel1">MobileNo:</span> <span class="logininput1">
                        <asp:TextBox ID="txtcustMobileNo" runat="server" CssClass="textboxstyle" />
                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txtcustMobileNo"
                            ValidChars="-0123456789." runat="server">
                        </asp:FilteredTextBoxExtender>
                    </span>
                </div>
            </div>
            <div class="loginform1">
                <div class="loginouter1">
                    <span class="loginlabel1">LandNO</span><span class="logininput1">
                        <asp:TextBox ID="txtcustlandNo" runat="server" CssClass="textboxstyle" />
                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" TargetControlID="txtcustlandNo"
                            ValidChars="-0123456789." runat="server">
                        </asp:FilteredTextBoxExtender>
                    </span><span class="loginlabel1">IsActive:</span> <span class="logininput1">
                        <asp:CheckBox ID="chkcustizactive" runat="server" />
                    </span>
                </div>
            </div>
        </div>
        <div class="cl">
        </div>
        <div class="add-adres-footer">
            <div class="loginbtn">
                <asp:LinkButton ID="btnSubmitCust" Text="Submit" runat="server" OnClientClick="return Checkcust();"
                    OnClick="btnSubmitCust_Click" />
            </div>
            <div class="loginfbbtn">
                <asp:LinkButton ID="btncancelCust" runat="server" Text="Cancel" /></div>
        </div>
        <!--add-adres-footer-->
    </div>
    <a onclick="document.getElementById('lightcust').style.display='none';document.getElementById('fadecust').style.display='none'"
        href="javascript:void(0)" style="border: none;">
        <div id="fadecust" class="black_overlay1" onclick="document.getElementById('lightcust').style.display='none';document.getElementById('fadecust').style.display='none'">
        </div>
    </a>
    <script type="text/javascript">
        function SetFileName(fuID, txtID) {
            var arrFileName = document.getElementById(fuID).value.split('\\');
            document.getElementById(txtID).value = arrFileName[arrFileName.length - 1];
        }


        function ShowPOPUPprodUpdatecust(status) {
            var errorMessage = "";
            var isValid = false;
            //alert(status);
            jQuery('#<%=lblpopheadercust.ClientID %>').text('Update Product');
            if (status == 'true') {
                //alert(status);
            }
            else {
                jQuery('#<%=TXTcust.ClientID %>').val('');
                jQuery("#<%= errorpopheadercust.ClientID %>").hide();
                //alert(status);
            }
            document.getElementById('fadecust').style.display = 'block';
            document.getElementById('lightcust').style.display = 'block';
            return isValid;
        }
    </script>
    <script language="javascript" type="text/javascript">
        function ShowPOPUPCust(status) {
            var errorMessage = "";
            var isValid = false;

            jQuery('#<%=lblpopheadercust.ClientID %>').text('Add Customers');
            //alert(status);
            if (status == 'true') {
                //alert(status);
            }
            else {
                var TXTcustEmail = jQuery("#<%= TXTcustEmail.ClientID %>").val('');
                var txtcustlastnme = jQuery("#<%= txtcustlastnme.ClientID %>").val('');
                var txtcustMobileNo = jQuery("#<%= txtcustMobileNo.ClientID %>").val('');
                var txtcustPass = jQuery("#<%= txtcustPass.ClientID %>").val('');
                var drpUserType = jQuery("#<%= drpUserType.ClientID %>").val('0');
                var Drpgender = jQuery("#<%= Drpgender.ClientID %>").val('0');
                var txtcustfrstname = jQuery("#<%= txtcustfrstname.ClientID %>").val('');
                var txtcustlandNo = jQuery("#<%= txtcustlandNo.ClientID %>").val('');
                var chkcustizactive = jQuery("#<%= chkcustizactive.ClientID %>").val('');
                jQuery('#<%=TXTcust.ClientID %>').val('');
                jQuery("#<%= errorpopheadercust.ClientID %>").hide();
                //alert(status);
            }
            document.getElementById('lightcust').style.display = 'block';
            document.getElementById('fadecust').style.display = 'block';
            return isValid;
        }

        function ShowPOPUPupdateCust(status) {
            var errorMessage = "";
            var isValid = false;

            jQuery('#<%=lblpopheadercust.ClientID %>').text('Update Customer');
            //alert(status);
            if (status == 'true') {
                //alert(status);
            }
            else {
                //alert(status);
            }
            document.getElementById('lightcust').style.display = 'block';
            document.getElementById('fadecust').style.display = 'block';
            return isValid;
        }

        function Checkcust() {
            var errorMessage = "";
            var isValid = true;
            jQuery("#<%= TXTcust.ClientID %>").removeClass('textboxstyleerror');
            jQuery("#<%= TXTcustEmail.ClientID %>").removeClass('textboxstyleerror');
            jQuery("#<%= txtcustlastnme.ClientID %>").removeClass('textboxstyleerror');
            jQuery("#<%= txtcustMobileNo.ClientID %>").removeClass('textboxstyleerror');
            jQuery("#<%= txtcustPass.ClientID %>").removeClass('textboxstyleerror');
            jQuery("#<%= drpUserType.ClientID %>").removeClass('selecterror');
            jQuery("#<%= Drpgender.ClientID %>").removeClass('selecterror');
            jQuery("#<%= txtcustfrstname.ClientID %>").removeClass('textboxstyleerror');
            jQuery("#<%= txtcustlandNo.ClientID %>").removeClass('textboxstyleerror');
            var TXTcust = jQuery("#<%= TXTcust.ClientID %>").val();
            var TXTcustEmail = jQuery("#<%= TXTcustEmail.ClientID %>").val();
            var txtcustlastnme = jQuery("#<%= txtcustlastnme.ClientID %>").val();
            var txtcustMobileNo = jQuery("#<%= txtcustMobileNo.ClientID %>").val();
            var txtcustPass = jQuery("#<%= txtcustPass.ClientID %>").val();
            var drpUserType = jQuery("#<%= drpUserType.ClientID %>").val();
            var Drpgender = jQuery("#<%= Drpgender.ClientID %>").val();
            var txtcustfrstname = jQuery("#<%= txtcustfrstname.ClientID %>").val();
            var txtcustlandNo = jQuery("#<%= txtcustlandNo.ClientID %>").val();
            if (txtcustPass.length <= 0) {
                if (errorMessage.length > 0) {
                    errorMessage += "<br/>";
                }
                errorMessage += 'Password is required.';
                jQuery("#<%= txtcustPass.ClientID %>").addClass('textboxstyleerror');
                isValid = false;
            }

            if (drpUserType == "0") {
                if (errorMessage.length > 0) {
                    errorMessage += "<br/>";
                }
                errorMessage += 'UserType is required.';
                isValid = false;
            }
            if (Drpgender == "0") {
                if (errorMessage.length > 0) {
                    errorMessage += "<br/>";
                }
                errorMessage += 'Gender is required.';
                jQuery("#<%= Drpgender.ClientID %>").addClass('selecterror');
                isValid = false;
            }

            if (txtcustfrstname.length <= 0) {
                if (errorMessage.length > 0) {
                    errorMessage += "<br/>";
                }
                errorMessage += 'FirstName is required.';
                jQuery("#<%= txtcustfrstname.ClientID %>").addClass('textboxstyleerror');
                isValid = false;
            }
            if (txtcustlandNo.length <= 0) {
                if (errorMessage.length > 0) {
                    errorMessage += "<br/>";
                }
                errorMessage += 'LandNo is required.';
                jQuery("#<%= txtcustlandNo.ClientID %>").addClass('textboxstyleerror');
                isValid = false;
            }
            if (TXTcust.length <= 0) {
                if (errorMessage.length > 0) {
                    errorMessage += "<br/>";
                }
                errorMessage += "Name is required.";
                jQuery("#<%= TXTcust.ClientID %>").addClass('textboxstyleerror');
                isValid = false;
            }
            if (TXTcustEmail.length <= 0) {
                if (errorMessage.length > 0) {
                    errorMessage += "<br/>";
                }
                errorMessage += "Email is required.";
                jQuery("#<%= TXTcustEmail.ClientID %>").addClass('textboxstyleerror');
                isValid = false;
            }
            if (txtcustlastnme.length <= 0) {
                if (errorMessage.length > 0) {
                    errorMessage += "<br/>";
                }
                errorMessage += "LastName is required.";
                jQuery("#<%= txtcustlastnme.ClientID %>").addClass('textboxstyleerror');
                isValid = false;
            }
            if (txtcustMobileNo.length <= 0) {
                if (errorMessage.length > 0) {
                    errorMessage += "<br/>";
                }
                errorMessage += "MobileNo is required.";
                jQuery("#<%= txtcustMobileNo.ClientID %>").addClass('textboxstyleerror');
                isValid = false;
            }
            if (!isValid) {
                jQuery("#<%= errorpopheadercust.ClientID %>").show();
                jQuery("#<%= errorpopheadercust.ClientID %>").removeClass('fk-msg-success');
                jQuery("#<%= errorpopheadercust.ClientID %>").addClass('fk-err-all');
                jQuery("#<%= errorpopheadercust.ClientID %>").html(errorMessage);
                jQuery("#<%= errorpopheadercust.ClientID %>").addClass('fk-err-all');
                jQuery("#lightcust").addClass('white_box_big_error');
                return false;
            }
            else {
                jQuery("#<%= errorpopheadercust.ClientID %>").html('');
                jQuery("#<%= errorpopheadercust.ClientID %>").removeClass('fk-err-all');
                jQuery("#lightcust").removeClass('white_box_big_error');
                return true;
            }
        }
    </script>
</td>
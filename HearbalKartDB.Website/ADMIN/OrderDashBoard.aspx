<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN/Admin.master" AutoEventWireup="true"
    CodeFile="OrderDashBoard.aspx.cs" Inherits="ADMIN_OrderDashBoard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="cph">
        <div class="section-title">
            <img src="../images/ico-dashboard.png" />
            OrderDashboard
       
        </div>
        <table class="dashboard">
            <tr>
                <td class="maincol">
                    <table class="stats">
                        <tbody>
                            <tr>
                                <td class="orderstatistics">
                                    <div class="statisticsTitle">
                                        Order Status
                                       
                                        <asp:LinkButton ID="lnkAddNewordStats" OnClientClick="return ShowPOPUP(false);" runat="server">Add New</asp:LinkButton>
                                    </div>
                                    <table class="adminContent">
                                        <asp:GridView ID="grdOrdstatus" CssClass="t-widget t-grid" runat="server" Width="100%"
                                            AutoGenerateColumns="False" RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle"
                                            CellPadding="0" CellSpacing="1" EmptyDataText="No record Found!" EmptyDataRowStyle-Font-Bold="true"
                                            EmptyDataRowStyle-HorizontalAlign="Center" EditRowStyle-VerticalAlign="Top" AllowPaging="true"
                                            RowStyle-CssClass="con" AlternatingRowStyle-CssClass="con-dark" GridLines="None"
                                            PageSize="10" BackColor="#ffffff" ShowHeader="true" OnRowDataBound="grdOrdstatus_RowDataBound">
                                            <AlternatingRowStyle CssClass="con-dark"></AlternatingRowStyle>
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                                                    <HeaderTemplate>
                                                        Order Status
                                                   
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOrdStatusname" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <AlternatingItemTemplate>
                                                        <asp:Label ID="lblOrdStatusname" runat="server"></asp:Label>
                                                    </AlternatingItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderStyle CssClass="t-grid-header" HorizontalAlign="Center" />
                                                    <HeaderTemplate>
                                                        IsActive
                                                   
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="IMGBTNOrdStatusisActive" runat="server" CommandArgument='<%# Eval("Id") %>'
                                                            OnClick="IMGBTNOrdStatusisActive_Click"></asp:ImageButton>
                                                        <asp:HiddenField ID="HDFOrderStatsID" runat="server" />
                                                    </ItemTemplate>
                                                    <AlternatingItemTemplate>
                                                        <asp:ImageButton ID="IMGBTNOrdStatusisActive" runat="server" CssClass="t-alt" CommandArgument='<%# Eval("Id") %>'
                                                            OnClick="IMGBTNOrdStatusisActive_Click"></asp:ImageButton>
                                                        <asp:HiddenField ID="HDFOrderStatsID" runat="server" />
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
                                            <h3>Add Order Status</h3>
                                            <a href="javascript:void(0);" onclick="document.getElementById('light').style.display='none';document.getElementById('fade').style.display='none'">
                                                <span class="cross"></span></a>
                                        </div>
                                        <div id="errorPopup" runat="server">
                                        </div>
                                        <div class="mini-cart">
                                            <div class="loginform">
                                                <div class="loginouter">
                                                    <span class="loginlabel">Name:</span><span class="logininput">
                                                        <asp:TextBox ID="TXTOrdstas" runat="server" Text="Submit" /></span>
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
                                                <asp:LinkButton ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click1"
                                                    OnClientClick="return CheckOrderStatus();" />
                                            </div>
                                            <div class="loginfbbtn">
                                                <asp:LinkButton ID="btncancel" runat="server" OnClientClick="return ClosePOPUP();"
                                                    Text="Cancel" />
                                            </div>
                                        </div>
                                        <!--add-adres-footer-->
                                    </div>
                                    <a onclick="document.getElementById('light').style.display='none';document.getElementById('fade').style.display='none'"
                                        href="javascript:void(0)" style="border: none;">
                                        <div id="fade" class="black_overlay1" onclick="document.getElementById('light').style.display='none';document.getElementById('fade').style.display='none'">
                                        </div>
                                    </a>
                                </td>
                                <td class="customerstatistics">
                                    <div class="statisticsTitle">
                                        Registered customers
                                    </div>
                                    <table class="adminContent">
                                        <tr>
                                            <td>
                                                <div class="t-widget t-grid" id="registered-customers-grid">
                                                    <table cellspacing="0">
                                                        <thead class="t-grid-header">
                                                            <tr>
                                                                <th class="t-header" scope="col">
                                                                    <span class="t-link">Period</span>
                                                                </th>
                                                                <th class="t-header" scope="col">
                                                                    <span class="t-link">Count</span>
                                                                </th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr>
                                                                <td>In the last 7 days
                                                                </td>
                                                                <td>0
                                                                </td>
                                                            </tr>
                                                            <tr class="t-alt">
                                                                <td>In the last 14 days
                                                                </td>
                                                                <td>0
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>In the last month
                                                                </td>
                                                                <td>0
                                                                </td>
                                                            </tr>
                                                            <tr class="t-alt">
                                                                <td>In the last year
                                                                </td>
                                                                <td>0
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                    <div class="t-grid-pager t-grid-bottom">
                                                        <div class="t-status">
                                                            <a class="t-icon t-refresh" href="#">Refresh</a>
                                                        </div>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <script language="javascript" type="text/javascript">
        function ShowPOPUP(status) {
            var errorMessage = "";
            var isValid = false;
            jQuery('#<%=btnSubmit.ClientID %>').text('Submit');
            //alert(status);
            if (status == 'true') {
                jQuery('#<%=TXTOrdstas.ClientID %>').val('');
                //alert(status);
            }
            else {
                jQuery('#<%=TXTOrdstas.ClientID %>').val('');
                jQuery("#<%= errorPopup.ClientID %>").hide();
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
                jQuery('#<%=TXTOrdstas.ClientID %>').val('');
                jQuery("#<%= errorPopup.ClientID %>").hide();
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
        function CheckOrderStatus() {
            var errorMessage = "";
            var isValid = true;

            var txtorder = jQuery("#<%= TXTOrdstas.ClientID %>").val();

            if (txtorder.length <= 0) {
                if (errorMessage.length > 0) {
                    errorMessage += "<br/>";
                }
                errorMessage += "OrderStatus is required.";
                isValid = false;
            }
            if (!isValid) {
                jQuery("#<%= errorPopup.ClientID %>").show();
                jQuery("#<%= errorPopup.ClientID %>").addClass('fk-err-all');
                jQuery("#<%= errorPopup.ClientID %>").html(errorMessage);
                jQuery("#<%= errorPopup.ClientID %>").addClass('fk-err-all');
                return false;
            }
            else {
                jQuery("#<%= errorPopup.ClientID %>").html('');
                jQuery("#<%= errorPopup.ClientID %>").removeClass('fk-err-all');
                return true;
            }
        }
    </script>
</asp:Content>

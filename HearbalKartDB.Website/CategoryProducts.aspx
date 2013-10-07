<%@ Page Title="" Language="C#" MasterPageFile="~/Mainmaster.master" AutoEventWireup="true" CodeFile="CategoryProducts.aspx.cs" Inherits="CategoryProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $(function () {
            var stickyRibbonTop = $('#menuID').offset().top;

            $(window).scroll(function () {
                if ($(window).scrollTop() > stickyRibbonTop) {
                    $('#menuID').css({ position: 'fixed', top: '21px' });
                } else {
                    
                    $('#menuID').css({ position: 'static', top: '0px', width: '250px' });

                }
            });
        });
    </script>
    <div class="container_prtion">
        <div class="left_portion" id="menuID" >
            <div class="refinedcontentdd">
                <asp:DataList ID="MnuDtlst" runat="server" OnItemDataBound="MnuDtlst_ItemDataBound">
                    <ItemTemplate>
                        <div class="divli" style="margin: 5px 0px 10px 0; width: 184px;">
                    <h3 class="searchfilterheader" style="width: 178px; padding: 5px 0; border-bottom: 1px dotted #666; font: bold 13px Arial; color: #000; letter-spacing: 1px;">
                        <asp:Label ID="lblmnuheader" runat="server"/>
                            <div style="float: right; color: #5e5e5e;">
                                <a onclick="#)">
                                    <img border="0" style="margin: 5px 0 0 0;" src="images/collapse_minus.png" id="ïmgcollapse_minus"></a>
                            </div>
                    </h3>
                    <div style="margin: 0px;" class="NcatSelul tinyscrl">
                        <div style="width: 2px; background: none repeat scroll 0% 0% rgb(158, 158, 158);" class="scrollbar disable">
                            <div style="width: 4px; height: 23px;" class="track">
                                <div style="width: 6px; top: 0px; height: 23px;" class="thumb">
                                    <div class="end">&nbsp;</div>
                                </div>
                            </div>
                        </div>
                        <div style="height: 23px;" class="viewport">
                                    <div class="overview" style="top: 0px;">
                                        <div style="margin: 0px; display: block;" class="NcatSelulli">
                                            <asp:DataList ID="MnuDlstsub" runat="server" class="NcatSelulli" RepeatDirection="Vertical" RepeatColumns="1" OnItemDataBound="MnuDlstsub_ItemDataBound">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkbx" runat="server" style="float: left; margin-right: 10px;" class="checkboxcolorcode ColorCheckbox" />
                                                    <label class="ColorCheckboxdeselect">
                                                        &nbsp;
                                                    </label>
                                                    <asp:HyperLink ID="Hyperlnk"  relmselect="apparels" style="width: 130px; float: left;" class="RefineByLink" runat="server"/>
                                                </ItemTemplate>
                                            </asp:DataList>
                                            </a>
                                        </div>
                                    </div>
                                </div>
                        </div>
                    </div>
                </div>
                    </ItemTemplate>
                </asp:DataList>
                
            </div>
        </div>
        <div class="right_portion_inner">
            <div id="banner-fade_inner">
                <!-- start Basic Jquery Slider -->
                <ul class="bjqs">
                    <li>
                        <img src="images/nemo.jpg" title="Automatically generated caption"></li>
                    <li>
                        <img src="images/up.jpg" title="Automatically generated caption"></li>
                    <li>
                        <img src="images/walle.jpg" title="Automatically generated caption"></li>
                </ul>
                <!-- end Basic jQuery Slider -->
            </div>
            <div style="color: #585858; font: normal 16px Arial; margin: 10px 0px; letter-spacing: 0px; float: left; width: 714px;">
                <b>
                    <asp:LinkButton ID="prodCtgName" runat="server" /></b>&nbsp;
                    <span style="font: italic 14px Arial;">
                        <asp:Label ID="TtlProds" runat="server" /></span>
            </div>
            <asp:Repeater runat="server" ID="rptProdByctg" OnItemDataBound="rptProdByctg_ItemDataBound">
                <ItemTemplate>
                    <div class="product-details">
                        <div class="img_prtion">
                            <a href="#">
                                <asp:Image ID="prodImgCtg" runat="server" /></a>
                        </div>
                        <div class="product_title">
                            <asp:LinkButton ID="lnkprodName" runat="server" Text="test"></asp:LinkButton>
                        </div>
                        <div class="price_range">
                            <span class="red">
                                <asp:Label ID="lblitmsell" runat="server" />

                            </span>
                            <span class="cut">
                                <asp:Label ID="lblitmpurchase" runat="server" />

                            </span>
                            <span class="red_off">(38% off)</span>
                        </div>

                        <input class="addcartinner" type="button" value="Add To Cart">
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>


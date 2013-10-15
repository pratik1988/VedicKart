<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <%@ Register Src="~/UserControls/HOME/Header.ascx" TagName="Header" TagPrefix="uc2" %>
    <%@ Register Src="~/UserControls/HOME/Cart.ascx" TagName="Prodcart" TagPrefix="cart" %>
    <div class="categoryPosWrapper mar_25_btm">
        <asp:DataList runat="server" ID="rptctg" RepeatDirection="Vertical" OnItemDataBound="rptctg_ItemDataBound">
            <ItemTemplate>
                <div id="475-header" class="greyBor widgetHeader">
                    <div class="headerTxt lfloat">
                        <a href="http://matrix.snapdeal.com:8081/products/home-furnishing" class="catHeaderLink">
                            <h2>
                                <asp:LinkButton ID="lnkCtgName" runat="server" OnClick="lnkCtgName_Click" CommandArgument='<%# Eval("Id") %>'></asp:LinkButton></h2>
                        </a>
                    </div>
                    <div id="icoHeaderArrow" class="lfloat rightArrow"></div>
                </div>
                <div class="widgetCont" id="475-widgetCont">
                    <div class="widgetDataDisplay lfloat" id="475-widgetDataDisplay">
                        <div class="product_grid_row" style="">
                            <asp:DataList runat="server" ID="rptctglqd" RepeatDirection="Horizontal" OnItemDataBound="rptctglqd_ItemDataBound" OnItemCommand="rptctglqd_ItemCommand">
                                <ItemTemplate>
                                    <div id="1240385452" class="product_grid_cont gridLayout4" style="height: 447px;">
                                        <a >
                                            <div class="product-image bannerHover ">
                                                <asp:Image BorderWidth="0" ID="IMGLqdProd" src="http://www.appelsiini.net/projects/lazyload/img/grey.gif"
                                data-original='<%# "ImageHandler.ashx?ImID="+ Eval("Id") %>' style="opacity: 1;" runat="server" CssClass="lazy" />
                                                <div class="widgetTextWrapper">
                                                    <div class="textLinks white"><a title="Bed Sheets @ 299" href="http://www.snapdeal.com/products/home-kitchen-bed-linen?q=Price:299,299">Bed Sheets @ 299</a></div>
                                                    <div class="textLinks white"><a title="Bed Sheets @ 399" href="http://www.snapdeal.com/products/home-kitchen-bed-linen?q=Price:399,400|Type_s:Bed%20Sheets">Bed Sheets @ 399</a></div>
                                                    <div class="textLinks white"><a title="Bed Sheets @ 499" href="http://www.snapdeal.com/products/home-kitchen-bed-linen?q=Price:499,499|Type_s:Bed%20Sheets|Brand:Birla%20Century^Cenizas^DAISY^Desi%20Connection^Home%20Candy^Jorss^LALI%20PRINTS^LWF^Mesmerization^Pompe%20Wonder">Bed Sheets @ 499</a></div>
                                                    <div class="textLinks white"><a title="Premium Bed Sheets" href="http://www.snapdeal.com/products/home-kitchen-bed-linen?q=Brand:American%20Swan^Birla%20Century^Bombay%20Dyeing^House%20This!^Little%20India^Portico^Portico%20New%20York^Skap^Sleepwell^Spaces^Stellar%20home%20USA^Stoa%20Paris^Story@Home^Swayam^Resole%20Italy&amp;sort=bstslr">Premium Bed Sheets</a></div>
                                                    <div class="textLinks white"><a title="Bed Sheet Combos" href="http://www.snapdeal.com/products/home-kitchen-bed-linen?q=Occasion_s:Combos">Bed Sheet Combos</a></div>
                                                </div>
                                            </div>
                                            <div class="product_grid_cont_heading">
                                                <asp:HyperLink ID="lnkProdLqdName" runat="server" />
                                            </div>
                                            <div style="background-position: 0px -162px;" pos="4.5" class="ratingStarsSmall ratingStarsBelowTitle"><span>(4)</span></div>
                                            <script type="text/javascript">
                                                var ratingState = true;
                                            </script>
                                            <div class="product_grid_cont_price_outer">
                                                <div class="product_price ">
                                                    <span class="originalprice ">Rs <asp:Label ID="lblLqdprodSum" runat="server" /></span> Rs 36800
                                                </div>
                                                <div class="product_discount_outer ">
                                                    <div class="product_discount">
                                                        24%
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="cashBack"><span>Insta Cashback :</span><span class="cashBackPrice"> Rs 750</span></div>
                                            <div class="freebie-ico">Freebie</div>
                                            <div class="cod-ico">Cash on Delivery Available</div>
                                            <div class="freebie-ico"><asp:LinkButton ID="addcartID" runat="server" CssClass="addcart" CommandName="addtocart" Text="Add To Cart" /></div>
                                        </a>
                                    </div>
                                    <div class="lclear"></div>
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>

    </div>
</asp:Content>


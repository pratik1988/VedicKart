<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="UserControls_HOME_Header" %>
<script type="text/javascript">
    var aliceImageHost = 'http://static.jabong.com';
    var aliceStaticHost = 'http://static.jabong.com';
    var globalConfig = {};
</script>

    <script type="text/javascript">
        $(function () {
            var stickyRibbonTop = $('#ng').offset().top;

            $(window).scroll(function () {
                if ($(window).scrollTop() > stickyRibbonTop) {
                    $('#ng').css({ position: 'fixed', top: '0px' });
                } else {
                    $('#ng').css({ position: 'static', top: '0px', width: '1050px' });
                }
            });
        });
    </script>
<div class="top_header">
    <div class="left_menus">
        <ul>
            <li><a href="#">Home</a></li>
            <li><a href="#">New Product</a></li>
            <li><a href="#">Sitemap</a></li>
            <li><a href="#">Conatct Us</a></li>
        </ul>
    </div>
    <div class="top_rightprtion">
        <div class="login">
            <asp:LinkButton ID="lnkAddNewordStats" runat="server" OnClick="btnSubmitLgn_Click">Login</asp:LinkButton>
        </div>
        <div class="cart">
            <img src="images/cart.png" /><span class="qty">12</span> <span class="price">$12,000</span>
        </div>
        <div class="youracc">
            Your Account
                    <select class="acc">
                        <option>$</option>
                    </select>
        </div>
        <div class="countries">
            <img src="images/country.jpg" />
        </div>
    </div>
</div>
<div class="bottom_header">
    <div class="logo">
        <img src="images/logo_3.png" />
    </div>
    <div class="header_rightprtion">
        <div class="call_us">Call Us : <span>123-567-1111</span></div>
        <div class="searchh">
            <input type="text" name="search" class="search" value="Search" />
        </div>
    </div>
</div>
<div class="navigation" id="ng">
    <ul id="navigation" class="fl">
        <li class="new-arrival-tab" id="new-arrival-menu-item">
            <a href="#" id="cat_2"
                class=" sel-cat-jewellery"
                data-gaq-event="mainnav1!#!New_Arrivals!#!main">
                <span class="nav-subTxt">Diseases</span>
            </a>
            <div class="drop-menu leftalignedmenu nav-layer fsm new-arrival-bg">
                <div class="new-ar-sm-container">
                    <asp:Repeater ID="rptmnctg" runat="server" OnItemDataBound="rptmnctg_ItemDataBound">
                        <ItemTemplate>
                            <div class="box unit size1of3">
                                <div class="new-arrival-sub-menu">
                                    <p class="text-777 text13">
                                        <asp:LinkButton ID="lnkmainCTG" runat="server" /></p>
                                    <div class="line mts">
                                        <ul>
                                            <asp:Repeater ID="rptsubctg" runat="server" OnItemDataBound="rptsubctg_ItemDataBound">
                                                <ItemTemplate>
                                                <li>
                                                    <p class="text-777 text13"><asp:LinkButton ID="lnksubctg" runat="server" /></p>
                                                    <ul>
                                                        <li>gdsfhg</li>
                                                        <li>gdsfhg</li>
                                                        <li>gdsfhg</li>
                                                    </ul>
                                                </li>
                                                    </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <%--<div id="new-arrival">
                    <div class="new-arrival-shadow ">&nbsp;</div>
                    <ul class="new-main">
                        <li class="">
                            <a data-gaq-event="mainnav1!#!New_Arrivals!#!Brand-Desigual-image"
                                href="http://www.jabong.com/desigual/?sort=whatsnew&dir=desc&source=topnav">
                                <img data-src="//static4.jassets.com/images/jabong/menu/NewArrival_Desigual_1.jpg"
                                    height="118" alt=""
                                    title="">
                                <span class="new-arrival-shop" style="display: none;">&nbsp;</span>
                            </a>

                        </li>
                        <li class="">
                            <a data-gaq-event="mainnav1!#!New_Arrivals!#!Brand-Puma-image"
                                href="http://www.jabong.com/Puma/?source=topnav">
                                <img data-src="//static1.jassets.com/images/jabong/menu/NewArrival_Puma.jpg"
                                    height="118" alt=""
                                    title="">
                                <span class="new-arrival-shop" style="display: none;">&nbsp;</span>
                            </a>

                        </li>
                        <li class="">
                            <a data-gaq-event="mainnav1!#!New_Arrivals!#!Brand-Wrangler-image"
                                href="http://www.jabong.com/Wrangler/?source=topnav">
                                <img data-src="//static4.jassets.com/images/jabong/menu/NewArrival_Wrangler.jpg"
                                    height="118" alt=""
                                    title="">
                                <span class="new-arrival-shop" style="display: none;">&nbsp;</span>
                            </a>

                        </li>
                        <li class="last-no-mar">
                            <a data-gaq-event="mainnav1!#!New_Arrivals!#!Brand-Baggit-image"
                                href="http://www.jabong.com/baggit/?sort=whatsnew&dir=desc&source=topnav">
                                <img data-src="//static4.jassets.com/images/jabong/menu/NewArrival_Baggit.jpg"
                                    height="118" alt=""
                                    title="">
                                <span class="new-arrival-shop" style="display: none;">&nbsp;</span>
                            </a>

                        </li>
                        <br class="clear" />
                    </ul>
                </div>--%>
            </div>
        </li>
    </ul>
</div>


<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="UserControls_HOME_Header" %>
<%@ Register Src="~/UserControls/HOME/Cart.ascx" TagName="Prodcart" TagPrefix="cart" %>
<%@ Register Src="~/UserControls/HOME/login.ascx" TagName="Prodlogin" TagPrefix="login" %>
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
                $('#cartpos').css({ position: 'static', top: '0px' , margin: '0px 0 0' });
                $('#navigation').css({ position: 'fixed', margin: '-3px 0 0' });
                $('.nav-layer').css({ top: '30px' })
                

            } else {
                $('#ng').css({ position: 'static', width: '978px' });
                $('#cartpos').css({ position: 'static', margin: '0px 0 0' });
                $('#navigation').css({ position: 'static', margin: '7px 0 0' });
                $('.nav-layer').css({top:'100px'})
            }
        });
    });
</script>
<div class="header-topbar">
    <div class="logo unit">
        <a class="fk-inline-block logo-img-link" href="/">
            <img title="Online Herbal Shopping India | Vedickart.com" alt="Vedickart.com: Online Herbal Shopping India" src="images/logo_3.png" class="logo-img">
        </a>
    </div>
    <div class="searchbar unit">
        <form autocomplete="off" action="/search" id="fk-header-search-form" method="GET" onsubmit="return submitSearchBarForm();">
            <div class="search-bar-wrap">
                <div class="search-bar">
                    <div class="search-bar">
                        <div class="unit search-bar-text-wrap">
                            <span class="search-bar-icon"></span>
                            <input type="text" x-webkit-speech="" id="fk-top-search-box" value="" placeholder="Search for a product, category or brand" class="search-bar-text fk-font-13 ac_input" name="q" autocomplete="off">

                            <select onchange="javascript:selectMItem(this);" class="search-select" id="fk-search-select">
                                <option displaystr="All Categories" data-storeurl="/search" data-storeid="search.flipkart.com" value="search.flipkart.com">All Categories</option>
                                <option displaystr="Clothing" data-storeurl="/clothing/pr" data-storeid="2oq" value="2oq">Clothing</option>
                                <option displaystr="Footwear" data-storeurl="/footwear/pr" data-storeid="osp" value="osp">Footwear</option>
                                <option displaystr="Mobiles &amp; Accessories" data-storeurl="/mobiles-accessories/pr" data-storeid="tyy" value="tyy">Mobiles &amp; Accessories</option>
                                <option displaystr="Computers" data-storeurl="/computers/pr" data-storeid="6bo" value="6bo">Computers</option>
                                <option displaystr="Watches, Bags &amp; Wallets" data-storeurl="/bags-wallets-belts/pr" data-storeid="reh" value="reh">Watches, Bags &amp; Wallets</option>
                                <option displaystr="Cameras &amp; Accessories" data-storeurl="/cameras-accessories/pr" data-storeid="jek" value="jek">Cameras &amp; Accessories</option>
                                <option displaystr="Books, Pens &amp; Stationery" data-storeurl="/books/pr" data-storeid="bks" value="bks">Books, Pens &amp; Stationery</option>
                                <option displaystr="Home &amp; Kitchen" data-storeurl="/home-kitchen/pr" data-storeid="j9e" value="j9e">Home &amp; Kitchen</option>
                                <option displaystr="Beauty &amp; Personal Care" data-storeurl="/beauty-and-personal-care/pr" data-storeid="t06" value="t06">Beauty &amp; Personal Care</option>
                                <option displaystr="Games &amp; Consoles" data-storeurl="/gaming/pr" data-storeid="4rr" value="4rr">Games &amp; Consoles</option>
                                <option displaystr="TVs &amp; Video Players" data-storeurl="/tv-audio-video-players/pr" data-storeid="ckf" value="ckf">TVs &amp; Video Players</option>
                                <option displaystr="Home Audio &amp; MP3 Players" data-storeurl="/computers/audio-players/pr" data-storeid="6bo,ord" value="6bo,ord">Home Audio &amp; MP3 Players</option>
                                <option displaystr="Music, Movies &amp; Posters" data-storeurl="/music-movies-posters/pr" data-storeid="4kt" value="4kt">Music, Movies &amp; Posters</option>
                                <option displaystr="Baby Care &amp; Toys" data-storeurl="/baby-care/pr" data-storeid="kyh" value="kyh">Baby Care &amp; Toys</option>
                                <option displaystr="Sports &amp; Fitness" data-storeurl="/sports-fitness/pr" data-storeid="dep" value="dep">Sports &amp; Fitness</option>
                                <option displaystr="eBooks" data-storeurl="/ebooks/pr" data-storeid="ixq" value="ixq">eBooks</option>
                            </select>

                            <input type="hidden" value="search.flipkart.com" id="header_sid" name="sid">
                            <input type="hidden" name="as" value="off" id="as">
                            <input type="hidden" name="as-show" value="off" id="as-show">
                        </div>
                        <div class="unit search-bar-submit-wrap">
                            <input type="submit" value="Search" class="search-bar-submit fk-font-13 fk-font-bold">

                            <input type="hidden" value="start" id="searchTracker" name="otracker">
                            <input type="hidden" value="579fedf1-9ea5-4e92-a9a0-85d545b4a9bb" name="ref">
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>
    <div class="header-links unitExt">
        <ul class="link-list fk-font-11 fk-text-center">
            <li><a href="/s/contact">24x7<br>
                Customer Care</a></li>
            <li><asp:LinkButton ID="LinkButton1" OnClientClick="return ShowLogin(true);" runat="server" Text="Login">Signup</asp:LinkButton></li>
            <li class="no-border"><asp:LinkButton ID="lnklogin" OnClientClick="return ShowLogin(true);" runat="server" Text="Login">Login</asp:LinkButton></li>
        </ul>
    </div>
</div>
<%--<div class="menubar" id="ng">--%>
<div class="navigation" id="ng">
    <ul id="navigation" class="fl">
        <li class="new-arrival-tab" id="new-arrival-menu-item">
            <a class="test" href="/ayurveda/">Ayurveda</a>
            <h6 class="ayurveda"> Medicines, Facepack... </h6>
            </a>
            <div class="drop-menu leftalignedmenu nav-layer fsm new-arrival-bg">
                <div class="new-ar-sm-container">
                    <asp:Repeater ID="rptmnctg" runat="server" OnItemDataBound="rptmnctg_ItemDataBound">
                        <ItemTemplate>
                            <div class="box unit size1of3">
                                <div class="new-arrival-sub-menu">
                                    <p class="text-777 text13">
                                        <asp:LinkButton ID="lnkmainCTG" runat="server" />
                                    </p>
                                    <div class="line mts">
                                        <ul>
                                            <asp:Repeater ID="rptsubctg" runat="server" OnItemDataBound="rptsubctg_ItemDataBound">
                                                <ItemTemplate>
                                                    <li>
                                                        <p class="text-777 text13">
                                                            <asp:LinkButton ID="lnksubctg" runat="server" />
                                                        </p>
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
            </div>
        </li>
    </ul>
    <div class="nav-mycart-outer fnt-tahoma" id="cartpos" onclick="return ShowCart(true);">
        <span id="cartItemQtyId" class="fill-cart"><asp:Label ID="txtcartitm" runat="server" /></span>
        <span class="cart-text">My Cart</span>
    </div>
<div id="signin_box" style="display: none;">
            <login:Prodlogin ID="loginpop" runat="server" />
        </div>
    <div id="cart-layout-div" class="cart-overlay">
            <cart:Prodcart ID="cartprod" runat="server" />
        </div>
</div>
<%--<div class="top_header">
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
            <div class="login">
                </div>
        </div>
        <div id="signin_box" style="display: none;">
            <login:Prodlogin ID="loginpop" runat="server" />
        </div>
        <div class="cart">
            <img src="images/cart.png" onclick="return ShowCart(true);" /><span class="qty"></span>
            <span class="price">
                <asp:Label ID="lbltotalSum" runat="server" /></span>
        </div>
        <div id="cart-layout-div" class="cart-overlay">
            <cart:Prodcart ID="cartprod" runat="server" />
        </div>
        <div id="fade" class="black_overlay1">
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
</div>--%>

<script language="javascript" type="text/javascript">
    function CloseCart() {
        var errorMessage = "";
        var isValid = true;
        document.getElementById('cart-layout-div').style.display = 'none';
        return isValid;
    }

    function ShowCart(status) {
        var errorMessage = "";
        var isValid = false;
        document.getElementById('cart-layout-div').style.display = 'block';
        return isValid;
    }
    function ShowLogin(status) {
        var errorMessage = "";
        var isValid = false;
        document.getElementById('signin_box').style.display = 'block';
        return isValid;
    }
</script>

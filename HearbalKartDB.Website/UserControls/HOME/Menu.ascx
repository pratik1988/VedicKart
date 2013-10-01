<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="UserControls_HOME_Menu" %>
<link rel="stylesheet" type="text/css" href="../../Testing/menucss.css" />
<script type="text/javascript">
    var aliceImageHost = 'http://static.jabong.com';
    var aliceStaticHost = 'http://static.jabong.com';
    var globalConfig = {};
</script>
<script src="http://static.jabong.com/js/live/alice-1380124456.js" type="text/javascript"></script>
<%--<div class="l-pageWrapper">
    &nbsp;<div id="nav-wrapper">
        <div class="navigation">
            <ul id="navigation" class="fl">
                <li class="new-arrival-tab" id="new-arrival-menu-item"><a href="http://www.jabong.com/new-arrivals/?source=topnav" id="cat_2"
                    class=" sel-cat-jewellery"
                    data-gaq-event="mainnav1!#!New_Arrivals!#!main">
                    <span class="nav-subTxt">Just In</span>
                </a>
                    <div class="drop-menu leftalignedmenu nav-layer fsm new-arrival-bg">
                        <div class="new-ar-sm-container">
                            <div class="box unit size1of3">
                                <div class="new-arrival-sub-menu">
                                    <p class="text-777 text13">MEN</p>
                                    <div class="line mts">
                                        <ul>
                                            <li><a href="http://www.jabong.com/men/shoes/new-products/?source=topnav"
                                                data-gaq-event="mainnav1!#!New_Arrivals!#!Men-Shoes">Shoes</a></li>
                                            <li><a href="http://www.jabong.com/men/clothing/new-products/?source=topnav"
                                                data-gaq-event="mainnav1!#!New_Arrivals!#!Men-Clothing">Clothing</a></li>
                                            <li><a href="http://www.jabong.com/men/accessories/new-products/?source=topnav"
                                                data-gaq-event="mainnav1!#!New_Arrivals!#!Men-Accessories">Accessories</a></li>
                                            <li><a href="http://www.jabong.com/men/accessories/mens-watches/new-products/?source=topnav"
                                                data-gaq-event="mainnav1!#!New_Arrivals!#!Men-Watches">Watches</a></li>
                                            <li><a href="http://www.jabong.com/men/bags/new-products/?source=topnav"
                                                data-gaq-event="mainnav1!#!New_Arrivals!#!Men-Bags">Bags</a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <div class="box unit size1of3">
                                <div class="new-arrival-sub-menu">
                                    <p class="text-777 text13">WOMEN</p>
                                    <div class="line mts">
                                        <ul>
                                            <li><a href="http://www.jabong.com/women/shoes/new-products/?source=topnav"
                                                data-gaq-event="mainnav1!#!New_Arrivals!#!Women-Shoes">Shoes</a></li>
                                            <li><a href="http://www.jabong.com/women/clothing/new-products/?source=topnav"
                                                data-gaq-event="mainnav1!#!New_Arrivals!#!Women-Clothing">Clothing</a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <div class="box unit size1of3">
                                <div class="new-arrival-sub-menu">
                                    <p class="text-777 text13">KIDS</p>
                                    <div class="line mts">
                                        <ul>
                                            <li><a href="http://www.jabong.com/kids/shoes/new-products/?source=topnav"
                                                data-gaq-event="mainnav1!#!New_Arrivals!#!Kids-Shoes">Shoes</a></li>
                                            <li><a href="http://www.jabong.com/kids/clothing/boys-clothing/new-products/?source=topnav"
                                                data-gaq-event="mainnav1!#!New_Arrivals!#!Kids-Boys_Clothing">Boys Clothing</a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <div class="box unit size1of3">
                                <div class="new-arrival-sub-menu">
                                    <p class="text-777 text13">HOME & FURNITURE</p>
                                    <div class="line mts">
                                        <ul>
                                            <li><a href="http://www.jabong.com/home-living/furniture/new-products/?source=topnav"
                                                data-gaq-event="mainnav1!#!New_Arrivals!#!Home_&_furniture-Furniture">Furniture</a></li>
                                            <li><a href="http://www.jabong.com/home-living/home-furnishing/new-products/?source=topnav"
                                                data-gaq-event="mainnav1!#!New_Arrivals!#!Home_&_furniture-Furnishing">Furnishing</a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <div class="box unit size1of3">
                                <div class="new-arrival-sm-lst">
                                    <p class="text-777 text13">SPORTS</p>
                                    <div class="line mts">
                                        <ul>
                                            <li><a href="http://www.jabong.com/sports/sports-shoes/new-products/?source=topnav"
                                                data-gaq-event="mainnav1!#!New_Arrivals!#!Sports-Shoes">Shoes</a></li>
                                            <li><a href="http://www.jabong.com/sports/sports-wear/new-products/?source=topnav"
                                                data-gaq-event="mainnav1!#!New_Arrivals!#!Sports-Clothing">Clothing</a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <br class="clear" />
                        </div>
                        <div id="new-arrival">
                            <div class="new-arrival-shadow ">&nbsp;</div>
                            <ul class="new-main">
                                <li class="">
                                    <a data-gaq-event="mainnav1!#!New_Arrivals!#!Brand-Desigual-image"
                                        href="http://www.jabong.com/desigual/?sort=whatsnew&dir=desc&source=topnav" style="position: relative;">
                                        <img data-src="//static4.jassets.com/images/jabong/menu/NewArrival_Desigual_1.jpg" width="237"
                                            height="118" alt=""
                                            title="">
                                        <span class="new-arrival-shop" style="display: none;">&nbsp;</span>
                                    </a>

                                </li>
                                <li class="">
                                    <a data-gaq-event="mainnav1!#!New_Arrivals!#!Brand-Puma-image"
                                        href="http://www.jabong.com/Puma/?source=topnav" style="position: relative;">
                                        <img data-src="//static1.jassets.com/images/jabong/menu/NewArrival_Puma.jpg" width="237"
                                            height="118" alt=""
                                            title="">
                                        <span class="new-arrival-shop" style="display: none;">&nbsp;</span>
                                    </a>

                                </li>
                                <li class="">
                                    <a data-gaq-event="mainnav1!#!New_Arrivals!#!Brand-Wrangler-image"
                                        href="http://www.jabong.com/Wrangler/?source=topnav" style="position: relative;">
                                        <img data-src="//static4.jassets.com/images/jabong/menu/NewArrival_Wrangler.jpg" width="237"
                                            height="118" alt=""
                                            title="">
                                        <span class="new-arrival-shop" style="display: none;">&nbsp;</span>
                                    </a>

                                </li>
                                <li class="last-no-mar">
                                    <a data-gaq-event="mainnav1!#!New_Arrivals!#!Brand-Baggit-image"
                                        href="http://www.jabong.com/baggit/?sort=whatsnew&dir=desc&source=topnav" style="position: relative;">
                                        <img data-src="//static4.jassets.com/images/jabong/menu/NewArrival_Baggit.jpg" width="237"
                                            height="118" alt=""
                                            title="">
                                        <span class="new-arrival-shop" style="display: none;">&nbsp;</span>
                                    </a>

                                </li>
                                <br class="clear" />
                            </ul>
                        </div>
                    </div>
                </li>
                <li><a class="" href="http://www.jabong.com/men/?source=topnav" data-gaq-event="mainnav1!#!Men!#!main">Men</a><div class="drop-menu" style="display: none;">
                    <ul class="fleft cat-main">
                        <li>
                            <a href="http://www.jabong.com/men/shoes/?source=topnav" data-gaq-event="mainnav1!#!Men!#!Shoes"><span class="NavArrow"></span>Shoes</a>
                            <div class="cat-content">
                                <div id="category" class="fleft list-column">
                                    <div class="menu">
                                        <p class="shop-by-category"></p>
                                        <ul>
                                            <li><a href="http://www.jabong.com/men/shoes/men-sports-shoes/?source=topnav" data-gaq-event="mainnav1!#!Men!#!Shoes-Category-Sports_Shoes">Sports Shoes</a></li>
                                            <li><a href="http://www.jabong.com/men/shoes/men-sneakers/?source=topnav" data-gaq-event="mainnav1!#!Men!#!Shoes-Category-Sneakers">Sneakers</a></li>
                                        </ul>
                                    </div>
                                </div>
                                <div id="brand" class="fleft list-column">
                                    <div class="menu">
                                        <p class="shop-by-brand"></p>
                                        <ul>
                                            <li><a href="http://www.jabong.com/men/shoes/Nike/?source=topnav" data-gaq-event="mainnav1!#!Men!#!Shoes-Brand-Nike">Nike</a></li>
                                            <li><a href="http://www.jabong.com/men/shoes/Adidas/?source=topnav" data-gaq-event="mainnav1!#!Men!#!Shoes-Brand-Adidas">Adidas</a></li>
                                            <li><a href="http://www.jabong.com/men/shoes/Puma/?source=topnav" data-gaq-event="mainnav1!#!Men!#!Shoes-Brand-Puma">Puma</a></li>
                                        </ul>
                                    </div>
                                </div>
                                <div id="ocassion" class="fleft list-column last">
                                    <div class="menu  menu-last">
                                        <p class="shop-by-collection"></p>
                                        <ul>
                                            <li><a href="http://www.jabong.com/men/shoes/Puma/?sort=discount&dir=desc&source=topnav" data-gaq-event="mainnav1!#!Men!#!Shoes-Collection-Puma_Upto_30%_off">Puma Upto 30% off</a></li>
                                            <li><a href="http://www.jabong.com/Adidas/?sort=discount&dir=desc&source=topnav" data-gaq-event="mainnav1!#!Men!#!Shoes-Collection-Adidas_Upto_30%_OFF_">Adidas Upto 30% OFF </a></li>
                                        </ul>
                                    </div>
                                    <div class="text-center">
                                        <a href="http://www.jabong.com/men/shoes/men-sneakers/Puma/?price=1399-1599&source=topnav" data-gaq-event="mainnav1!#!Men!#![child-image]">
                                            <img width="250" height="160" data-src="//static1.jassets.com/images/jabong/menu/Men_Shoes_5.jpg" /></a>
                                    </div>
                                </div>
                                <br class="clear" />
                            </div>
                        </li>
                        <li>
                            <a href="http://www.jabong.com/men/clothing/?source=topnav" data-gaq-event="mainnav1!#!Men!#!Clothing"><span class="NavArrow"></span>Clothing</a>
                            <div class="cat-content">
                                <div id="Div1" class="fleft list-column">
                                    <div class="menu">
                                        <p class="shop-by-category"></p>
                                        <ul>
                                            <li><a href="http://www.jabong.com/men/clothing/mens-shirts/?source=topnav" data-gaq-event="mainnav1!#!Men!#!Clothing-Category-Casual_&_Formal_Shirts">Casual & Formal Shirts</a></li>
                                            <li><a href="http://www.jabong.com/men/clothing/mens-t-shirts/?source=topnav" data-gaq-event="mainnav1!#!Men!#!Clothing-Category-Tshirts_&_Polos">Tshirts & Polos</a></li>
                                            <li><a href="http://www.jabong.com/men/clothing/mens-jeans/?source=topnav" data-gaq-event="mainnav1!#!Men!#!Clothing-Category-Jeans">Jeans</a></li>
                                        </ul>
                                    </div>
                                </div>
                                <div id="Div2" class="fleft list-column">
                                    <div class="menu">
                                        <p class="shop-by-brand"></p>
                                        <ul>
                                            <li><a href="http://www.jabong.com/men/clothing/United-Colors-of-Benetton/?source=topnav" data-gaq-event="mainnav1!#!Men!#!Clothing-Brand-Benetton_(UCB)">Benetton (UCB)</a></li>
                                            <li><a href="http://www.jabong.com/men/clothing/Nike/?source=topnav" data-gaq-event="mainnav1!#!Men!#!Clothing-Brand-Nike">Nike</a></li>
                                            <li><a href="http://www.jabong.com/men/clothing/Us_Polo_Assn/?source=topnav" data-gaq-event="mainnav1!#!Men!#!Clothing-Brand-US_Polo_Assn">US Polo Assn</a></li>
                                            <li><a href="http://www.jabong.com/men/clothing/Wrangler/?source=topnav" data-gaq-event="mainnav1!#!Men!#!Clothing-Brand-Wrangler">Wrangler</a></li>
                                        </ul>
                                    </div>
                                </div>
                                <div id="Div3" class="fleft list-column last">
                                    <div class="menu  menu-last">
                                        <p class="shop-by-collection"></p>
                                        <ul>
                                            <li><a href="http://www.jabong.com/men/clothing/mens-t-shirts/?price=0-599&source=topnav" data-gaq-event="mainnav1!#!Men!#!Clothing-Collection-Tees_Starting_299">Tees Starting 299</a></li>
                                            <li><a href="http://www.jabong.com/men/clothing/mens-shirts/men-formal-shirts/?source=topnav" data-gaq-event="mainnav1!#!Men!#!Clothing-Collection-Formal_Shirts_Starting_519">Formal Shirts Starting 519</a></li>
                                        </ul>
                                    </div>
                                    <div class="text-center">
                                        <a href="http://www.jabong.com/men/clothing/online-sale/?source=topnav" data-gaq-event="mainnav1!#!Men!#![child-image]">
                                            <img width="250" height="160" data-src="//static4.jassets.com/images/jabong/menu/Men_Apparel_5.jpg" /></a>
                                    </div>
                                </div>
                                <br class="clear" />
                            </div>
                        </li>
                    </ul>
                </div>
                </li>
                <li id="shop-by-brand-menu-item">
                    <a href="http://www.jabong.com/brands/?source=topnav" id="A2"
                        class=" sel-cat-jewellery"
                        data-gaq-event="mainnav1!#!Top_Brands!#!main">
                        <span class="nav-subTxt">Top Brands</span>
                    </a>
                    <div class="drop-menu leftalignedmenu shop-by-brands-bg" style="display: none;">
                        <div id="shopby-brand" class="shopby-brand">
                            <div class="shop-all-brands">
                                <div class="bs-shop   sbb-bor-bott-none">
                                    <a href="http://www.jabong.com/Proline/?source=topnav"
                                        data-gaq-event="mainnav1!#!Top_Brands!#!Brand-Proline-image">
                                        <img data-src="//static1.jassets.com/images/jabong/menu/17proline.jpg" width="118" height="88"
                                            alt="" vspace="0" hspace="0" />
                                    </a>
                                </div>
                                <div class="bs-shop   sbb-bor-bott-none">
                                    <a href="http://www.jabong.com/Allen_Solly/?source=topnav"
                                        data-gaq-event="mainnav1!#!Top_Brands!#!Brand-Allen_Solly-image">
                                        <img data-src="//static4.jassets.com/images/jabong/menu/18allensolly.jpg" width="118" height="88"
                                            alt="" vspace="0" hspace="0" />
                                    </a>
                                </div>
                                <div class="bs-shop   sbb-bor-bott-none">
                                    <a href="http://www.jabong.com/vero-moda/?source=topnav"
                                        data-gaq-event="mainnav1!#!Top_Brands!#!Brand-Veromoda-image">
                                        <img data-src="//static3.jassets.com/images/jabong/menu/19Veromoda.jpg" width="118" height="88"
                                            alt="" vspace="0" hspace="0" />
                                    </a>
                                </div>
                                <div class="bs-shop   sbb-bor-bott-none">
                                    <a href="http://www.jabong.com/Ray-Ban/?source=topnav"
                                        data-gaq-event="mainnav1!#!Top_Brands!#!Brand-Ray_Ban-image">
                                        <img data-src="//static3.jassets.com/images/jabong/menu/20Rayban.jpg" width="118" height="88"
                                            alt="" vspace="0" hspace="0" />
                                    </a>
                                </div>
                                <div class="bs-shop   sbb-bor-bott-none">
                                    <a href="http://www.jabong.com/Hidesign/?source=topnav"
                                        data-gaq-event="mainnav1!#!Top_Brands!#!Brand-Hidesign-image">
                                        <img data-src="//static2.jassets.com/images/jabong/menu/21Hidesign.jpg" width="118" height="88"
                                            alt="" vspace="0" hspace="0" />
                                    </a>
                                </div>
                                <div class="bs-shop   sbb-bor-bott-none">
                                    <a href="http://www.jabong.com/desigual/?source=topnav"
                                        data-gaq-event="mainnav1!#!Top_Brands!#!Brand-Desigual-image">
                                        <img data-src="//static2.jassets.com/images/jabong/menu/22Desigual.jpg" width="118" height="88"
                                            alt="" vspace="0" hspace="0" />
                                    </a>
                                </div>
                                <div class="bs-shop   sbb-bor-bott-none">
                                    <a href="http://www.jabong.com/steve-madden/?source=topnav"
                                        data-gaq-event="mainnav1!#!Top_Brands!#!Brand-Steve_Madden-image">
                                        <img data-src="//static1.jassets.com/images/jabong/menu/23Steavmaden.jpg" width="118" height="88"
                                            alt="" vspace="0" hspace="0" />
                                    </a>
                                </div>
                                <div class="bs-shop  sbb-bor-rit-none  sbb-bor-bott-none">
                                    <a href="http://www.jabong.com/brands/?source=topnav"
                                        data-gaq-event="mainnav1!#!Top_Brands!#!Top_Brands-image">
                                        <img data-src="//static4.jassets.com/images/jabong/menu/all-brands.jpg" width="118" height="88"
                                            alt="" vspace="0" hspace="0" />
                                    </a>
                                </div>
                                <br class="clear">
                            </div>
                        </div>
                    </div>
                </li>
                <li class="border-right-none" id="saletab"><a href="http://www.jabong.com/online-sale/?source=topnav" title="Sale"
                    class="active"
                    data-gaq-event="mainnav1!#!Sale!#!main">
                    <span class="sale-icon">Sale</span>
                </a>
                    <div class="drop-menu nav-layer fsm new-arrival-bg leftalignedmenu">
                        <div class="new-ar-sm-container">
                            <div class="box unit size1of3">
                                <div class="new-arrival-sub-menu">
                                    <p class="text-777 text13">MEN</p>
                                    <div class="line mts">
                                        <ul>
                                            <li><a href="http://www.jabong.com/men/shoes/?special_price=1&cmpgp=men-shoes-size&source=topnav"
                                                data-gaq-event="mainnav1!#!Sale!#!Men-Shoes">Shoes</a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <div class="box unit size1of3">
                                <div class="new-arrival-sub-menu">
                                    <p class="text-777 text13">WOMEN</p>
                                    <div class="line mts">
                                        <ul>
                                            <li><a href="http://www.jabong.com/women/shoes/online-sale/?cmpgp=women-shoes-size&source=topnav"
                                                data-gaq-event="mainnav1!#!Sale!#!Women-Shoes">Shoes</a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>

                            <br class="clear" />
                        </div>
                        <div class="new-arrival-shadow ">&nbsp;</div>
                        <div class="sale-menu">
                            <div class="sale-img">
                                <a href="http://www.jabong.com/all-products/?special_price=1&cmpgp=eoss&source=topnav"
                                    data-gaq-event="mainnav1!#!Sale!#!Sale-upto70-image">
                                    <img data-src="//static2.jassets.com/images/jabong/menu/Sale_upto_70_off_7.jpg" width="479"
                                        height="120" alt="Sale-upto70-image"
                                        title="Sale upto 70%">
                                </a>
                            </div>
                            <div class="sale-img">
                                <a href="http://www.jabong.com/online-sale/?source=topnav"
                                    data-gaq-event="mainnav1!#!Sale!#!Sale-offers-image">
                                    <img data-src="//static4.jassets.com/images/jabong/menu/Bundles_4.jpg" width="479"
                                        height="120" alt="Sale-offers-image"
                                        title="Super Saver Offers">
                                </a>
                            </div>
                        </div>
                    </div>
                </li>
            </ul>
        </div>
    </div>

</div>--%>
<ul>
    <li><a href="#" class="active">Home</a></li>
    <li><a href="#">About Us</a></li>
    <li><a href="#">Lorem</a></li>
    <li><a href="#">Lorem ipsum</a></li>
    <li><a href="#">Lorem ipsum</a></li>
    <li><a href="#">Lorem ipsum</a></li>
    <li><a href="#">Lorem ipsum</a></li>
    <li><a href="#">Lorem ipsum</a></li>
    <li><a href="#">Contact Us</a></li>
</ul>

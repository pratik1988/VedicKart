<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="UserControls_HOME_Header" %>
<script type="text/javascript">
    var aliceImageHost = 'http://static.jabong.com';
    var aliceStaticHost = 'http://static.jabong.com';
    var globalConfig = {};
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
        <img src="images/logo.png" />
    </div>
    <div class="header_rightprtion">
        <div class="call_us">Call Us : <span>123-567-1111</span></div>
        <div class="searchh">
            <input type="text" name="search" class="search" value="Search" />
        </div>
    </div>
</div>
<div class="navigation">
    <ul id="navigation" class="fl">
        <li class="new-arrival-tab" id="new-arrival-menu-item">
            <a href="#" id="cat_2"
                class=" sel-cat-jewellery"
                data-gaq-event="mainnav1!#!New_Arrivals!#!main">
                <span class="nav-subTxt">Diseases</span>
            </a>
            <div class="drop-menu leftalignedmenu nav-layer fsm new-arrival-bg">
                <div class="new-ar-sm-container">
                    <div class="box unit size1of3">
                        <div class="new-arrival-sub-menu">
                            <p class="text-777 text13">MEN</p>
                            <div class="line mts">
                                <ul>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Men-Shoes">Liquid</a></li>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Men-Clothing">Solid</a></li>

                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="box unit size1of3">
                        <div class="new-arrival-sub-menu">
                            <p class="text-777 text13">WOMEN</p>
                            <div class="line mts">
                                <ul>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Men-Shoes">Liquid</a></li>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Men-Clothing">Solid</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="box unit size1of3">
                        <div class="new-arrival-sub-menu">
                            <p class="text-777 text13">Brands</p>
                            <div class="line mts">
                                <ul>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Kids-Shoes">Patanjali</a></li>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Kids-Boys_Clothing">Test</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="box unit size1of3">
                        <div class="new-arrival-sub-menu">
                            <p class="text-777 text13">Diseases</p>
                            <div class="line mts">
                                <ul>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Home_&_furniture-Furniture">Heart Diseases</a></li>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Home_&_furniture-Furnishing">Skin Diseases</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="new-arrival">
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
                </div>
            </div>
        </li>
        <li class="new-arrival-tab" id="Li1">
            <a href="#" id="A1"
                class=" sel-cat-jewellery"
                data-gaq-event="mainnav1!#!New_Arrivals!#!main">
                <span class="nav-subTxt">Health & WellNess</span>
            </a>
            <div class="drop-menu leftalignedmenu nav-layer fsm new-arrival-bg">
                <div class="new-ar-sm-container">
                    <div class="box unit size1of3">
                        <div class="new-arrival-sub-menu">
                            <p class="text-777 text13">MEN</p>
                            <div class="line mts">
                                <ul>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Men-Shoes">Liquid</a></li>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Men-Clothing">Solid</a></li>

                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="box unit size1of3">
                        <div class="new-arrival-sub-menu">
                            <p class="text-777 text13">WOMEN</p>
                            <div class="line mts">
                                <ul>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Men-Shoes">Liquid</a></li>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Men-Clothing">Solid</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="box unit size1of3">
                        <div class="new-arrival-sub-menu">
                            <p class="text-777 text13">Brands</p>
                            <div class="line mts">
                                <ul>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Kids-Shoes">Patanjali</a></li>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Kids-Boys_Clothing">Test</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="box unit size1of3">
                        <div class="new-arrival-sub-menu">
                            <p class="text-777 text13">Diseases</p>
                            <div class="line mts">
                                <ul>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Home_&_furniture-Furniture">Heart Diseases</a></li>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Home_&_furniture-Furnishing">Skin Diseases</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="new-arrival">
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
                </div>
            </div>
        </li>
        <li class="new-arrival-tab" id="Li2">
            <a href="#" id="A2"
                class=" sel-cat-jewellery"
                data-gaq-event="mainnav1!#!New_Arrivals!#!main">
                <span class="nav-subTxt">Organ Care</span>
            </a>
            <div class="drop-menu leftalignedmenu nav-layer fsm new-arrival-bg">
                <div class="new-ar-sm-container">
                    <div class="box unit size1of3">
                        <div class="new-arrival-sub-menu">
                            <p class="text-777 text13">MEN</p>
                            <div class="line mts">
                                <ul>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Men-Shoes">Liquid</a></li>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Men-Clothing">Solid</a></li>

                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="box unit size1of3">
                        <div class="new-arrival-sub-menu">
                            <p class="text-777 text13">WOMEN</p>
                            <div class="line mts">
                                <ul>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Men-Shoes">Liquid</a></li>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Men-Clothing">Solid</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="box unit size1of3">
                        <div class="new-arrival-sub-menu">
                            <p class="text-777 text13">Brands</p>
                            <div class="line mts">
                                <ul>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Kids-Shoes">Patanjali</a></li>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Kids-Boys_Clothing">Test</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="box unit size1of3">
                        <div class="new-arrival-sub-menu">
                            <p class="text-777 text13">Diseases</p>
                            <div class="line mts">
                                <ul>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Home_&_furniture-Furniture">Heart Diseases</a></li>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Home_&_furniture-Furnishing">Skin Diseases</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="new-arrival">
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
                </div>
            </div>
        </li>
        <li class="new-arrival-tab" id="Li3">
            <a href="#" id="A3"
                class=" sel-cat-jewellery"
                data-gaq-event="mainnav1!#!New_Arrivals!#!main">
                <span class="nav-subTxt">Body Care</span>
            </a>
            <div class="drop-menu leftalignedmenu nav-layer fsm new-arrival-bg">
                <div class="new-ar-sm-container">
                    <div class="box unit size1of3">
                        <div class="new-arrival-sub-menu">
                            <p class="text-777 text13">MEN</p>
                            <div class="line mts">
                                <ul>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Men-Shoes">Liquid</a></li>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Men-Clothing">Solid</a></li>

                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="box unit size1of3">
                        <div class="new-arrival-sub-menu">
                            <p class="text-777 text13">WOMEN</p>
                            <div class="line mts">
                                <ul>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Men-Shoes">Liquid</a></li>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Men-Clothing">Solid</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="box unit size1of3">
                        <div class="new-arrival-sub-menu">
                            <p class="text-777 text13">Brands</p>
                            <div class="line mts">
                                <ul>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Kids-Shoes">Patanjali</a></li>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Kids-Boys_Clothing">Test</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="box unit size1of3">
                        <div class="new-arrival-sub-menu">
                            <p class="text-777 text13">Diseases</p>
                            <div class="line mts">
                                <ul>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Home_&_furniture-Furniture">Heart Diseases</a></li>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Home_&_furniture-Furnishing">Skin Diseases</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="new-arrival">
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
                </div>
            </div>
        </li>
        <li class="new-arrival-tab" id="Li4">
            <a href="#" id="A4"
                class=" sel-cat-jewellery"
                data-gaq-event="mainnav1!#!New_Arrivals!#!main">
                <span class="nav-subTxt">Men</span>
            </a>
            <div class="drop-menu leftalignedmenu nav-layer fsm new-arrival-bg">
                <div class="new-ar-sm-container">
                    <div class="box unit size1of3">
                        <div class="new-arrival-sub-menu">
                            <p class="text-777 text13">MEN</p>
                            <div class="line mts">
                                <ul>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Men-Shoes">Liquid</a></li>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Men-Clothing">Solid</a></li>

                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="box unit size1of3">
                        <div class="new-arrival-sub-menu">
                            <p class="text-777 text13">WOMEN</p>
                            <div class="line mts">
                                <ul>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Men-Shoes">Liquid</a></li>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Men-Clothing">Solid</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="box unit size1of3">
                        <div class="new-arrival-sub-menu">
                            <p class="text-777 text13">Brands</p>
                            <div class="line mts">
                                <ul>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Kids-Shoes">Patanjali</a></li>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Kids-Boys_Clothing">Test</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="box unit size1of3">
                        <div class="new-arrival-sub-menu">
                            <p class="text-777 text13">Diseases</p>
                            <div class="line mts">
                                <ul>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Home_&_furniture-Furniture">Heart Diseases</a></li>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Home_&_furniture-Furnishing">Skin Diseases</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="new-arrival">
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
                </div>
            </div>
        </li>
        <li class="new-arrival-tab" id="Li5">
            <a href="#" id="A5"
                class=" sel-cat-jewellery"
                data-gaq-event="mainnav1!#!New_Arrivals!#!main">
                <span class="nav-subTxt">Women</span>
            </a>
            <div class="drop-menu leftalignedmenu nav-layer fsm new-arrival-bg">
                <div class="new-ar-sm-container">
                    <div class="box unit size1of3">
                        <div class="new-arrival-sub-menu">
                            <p class="text-777 text13">MEN</p>
                            <div class="line mts">
                                <ul>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Men-Shoes">Liquid</a></li>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Men-Clothing">Solid</a></li>

                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="box unit size1of3">
                        <div class="new-arrival-sub-menu">
                            <p class="text-777 text13">WOMEN</p>
                            <div class="line mts">
                                <ul>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Men-Shoes">Liquid</a></li>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Men-Clothing">Solid</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="box unit size1of3">
                        <div class="new-arrival-sub-menu">
                            <p class="text-777 text13">Brands</p>
                            <div class="line mts">
                                <ul>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Kids-Shoes">Patanjali</a></li>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Kids-Boys_Clothing">Test</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="box unit size1of3">
                        <div class="new-arrival-sub-menu">
                            <p class="text-777 text13">Diseases</p>
                            <div class="line mts">
                                <ul>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Home_&_furniture-Furniture">Heart Diseases</a></li>
                                    <li><a href="#"
                                        data-gaq-event="mainnav1!#!New_Arrivals!#!Home_&_furniture-Furnishing">Skin Diseases</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="new-arrival">
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
                </div>
            </div>
        </li>
    </ul>
</div>
<%--<div id="lightCSC" class="white_box" style="width: 380px;">
    <div class="add-address">
        <h3>
            <asp:Label ID="lblpopheader" runat="server" />
        </h3>
        <a href="javascript:void(0);" onclick="document.getElementById('lightCSC').style.display='none';document.getElementById('fadeCSC').style.display='none'">
            <span class="cross"></span></a>
    </div>
    <div id="errorpopheader" runat="server">
    </div>
    <div class="mini-cart">
        <div class="loginform">
            <div class="loginouter">
                <span class="loginlabel">Email:</span><span class="logininput">
                    <asp:TextBox ID="TXTEmail" runat="server" Text="Submit" CssClass="textboxstyle" /></span>
            </div>
            <div class="loginouter">
                <span class="loginlabel">Password:</span><span class="logininput">
                    <asp:TextBox ID="TXTPassword" runat="server" TextMode="Password" CssClass="textboxstyle" /></span>
            </div>
        </div>
    </div>
    <div class="cl">
    </div>
    <div class="add-adres-footer">
        <div class="loginbtn">
            <asp:LinkButton ID="btnSubmitLgn" Text="Submit" runat="server" OnClientClick="return btnSubmitLgn();" OnClick="btnSubmitLgn_Click" />
        </div>
        <div class="loginfbbtn">
            <asp:LinkButton ID="btncancel" runat="server" OnClientClick="document.getElementById('lightCSC').style.display='none';document.getElementById('fadeCSC').style.display='none'"
                Text="Cancel" />
        </div>
    </div>
    <!--add-adres-footer-->
</div>
<a onclick="document.getElementById('lightCSC').style.display='none';document.getElementById('fadeCSC').style.display='none'"
    href="javascript:void(0)" style="border: none;">
    <div id="fadeCSC" class="black_overlay1" onclick="document.getElementById('lightCSC').style.display='none';document.getElementById('fadeCSC').style.display='none'">
    </div>
</a>
<script language="javascript" type="text/javascript">
    function btnSubmitLgn() {
        var errorMessage = "";
        var isValid = true;
        jQuery("#<%= TXTEmail.ClientID %>").removeClass('textboxstyleerror');
        var txtemail = jQuery("#<%= TXTEmail.ClientID %>").val();
        var TXTPassword = jQuery("#<%= TXTPassword.ClientID %>").val();
        if (txtemail.length <= 0) {
            if (errorMessage.length > 0) {
                errorMessage += "<br/>";
            }
            errorMessage += "Email is required.";
            jQuery("#<%= TXTEmail.ClientID %>").addClass('textboxstyleerror');
            isValid = false;
        }
        if (TXTPassword.length <= 0) {
            if (errorMessage.length > 0) {
                errorMessage += "<br/>";
            }
            errorMessage += "Password is required.";
            jQuery("#<%= TXTPassword.ClientID %>").addClass('textboxstyleerror');
            isValid = false;
        }
        if (!isValid) {
            jQuery("#<%= errorpopheader.ClientID %>").show();
            jQuery("#<%= errorpopheader.ClientID %>").addClass('fk-err-all');
            jQuery("#<%= errorpopheader.ClientID %>").html(errorMessage);
            jQuery("#<%= errorpopheader.ClientID %>").addClass('fk-err-all');
            return false;
        }
        else {
            jQuery("#<%= errorpopheader.ClientID %>").html('');
            jQuery("#<%= errorpopheader.ClientID %>").removeClass('fk-err-all');
            return true;
        }
    }
    function ShowPOPUPCSC(status) {
        var errorMessage = "";
        var isValid = false;
        jQuery('#<%=btnSubmitLgn.ClientID %>').text('Login');
        jQuery('#<%=lblpopheader.ClientID %>').text('Login');
        //alert(status);
        if (status == 'true') {
            jQuery('#<%=TXTEmail.ClientID %>').val('');
            //alert(status);
        }
        else {
            jQuery('#<%=TXTEmail.ClientID %>').val('');
            jQuery("#<%= errorpopheader.ClientID %>").hide();
            //alert(status);
        }
        document.getElementById('lightCSC').style.display = 'block';
        document.getElementById('fadeCSC').style.display = 'block';
        return isValid;
    }
    function ClosePOPUP() {
        var errorMessage = "";
        var isValid = true;
        document.getElementById('lightCSC').style.display = 'none';
        document.getElementById('fadeCSC').style.display = 'none';
        return isValid;
    }
</script>--%>


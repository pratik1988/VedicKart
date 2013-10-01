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
            <asp:LinkButton ID="lnkAddNewordStats" runat="server" OnClick="btnSubmitLgn_Click">Login</asp:LinkButton></div>
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
        <li class="new-arrival-tab" id="new-arrival-menu-item"><a href="#" id="cat_2"
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
                                href="http://www.jabong.com/desigual/?sort=whatsnew&dir=desc&source=topnav" >
                                <img data-src="//static4.jassets.com/images/jabong/menu/NewArrival_Desigual_1.jpg"
                                    height="118" alt=""
                                    title="">
                                <span class="new-arrival-shop" style="display: none;">&nbsp;</span>
                            </a>

                        </li>
                        <li class="">
                            <a data-gaq-event="mainnav1!#!New_Arrivals!#!Brand-Puma-image"
                                href="http://www.jabong.com/Puma/?source=topnav" >
                                <img data-src="//static1.jassets.com/images/jabong/menu/NewArrival_Puma.jpg" 
                                    height="118" alt=""
                                    title="">
                                <span class="new-arrival-shop" style="display: none;">&nbsp;</span>
                            </a>

                        </li>
                        <li class="">
                            <a data-gaq-event="mainnav1!#!New_Arrivals!#!Brand-Wrangler-image"
                                href="http://www.jabong.com/Wrangler/?source=topnav" >
                                <img data-src="//static4.jassets.com/images/jabong/menu/NewArrival_Wrangler.jpg" 
                                    height="118" alt=""
                                    title="">
                                <span class="new-arrival-shop" style="display: none;">&nbsp;</span>
                            </a>

                        </li>
                        <li class="last-no-mar">
                            <a data-gaq-event="mainnav1!#!New_Arrivals!#!Brand-Baggit-image"
                                href="http://www.jabong.com/baggit/?sort=whatsnew&dir=desc&source=topnav" >
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
        <%--<li>
            <a class="" href="http://www.jabong.com/men/?source=topnav" data-gaq-event="mainnav1!#!Men!#!main">Men</a>
            <div class="drop-menu" style="display: none;">
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
        </li>--%>
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


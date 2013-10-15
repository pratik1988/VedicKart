<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Cart.ascx.cs" Inherits="UserControls_HOME_Cart" %>
<div class="cart-cont-outer fnt-tahoma">
    <div class="cart-scroll" id="emptycart" runat="server">
        <div style="padding-bottom: 9px" class="cart-cont">
            <div class="mycart-outer">
                <div style="float: left"><span class="fill-cart empty-cart">0</span><span class="cart-text">My Cart</span></div>
                <div style="float: right">
                    <div onclick="return CloseCart();" class="cart-skip">close</div>
                </div>
            </div>
            <div class="empty-shopping-cart">
                <span class="heading-cart">Your Shopping Cart is empty!</span>
                <span class="categories-text">Browse Categories</span>
                <div class="productCategoriesOuter overhid">
                    <div class="productCategoriesBox lfloat" style="height: 296px;">
                        <div class="productCatList"><a href="/products/mobiles">Mobiles &amp; Tablets</a></div>
                        <div class="productCatList"><a href="/products/computers">Computers &amp; Peripherals</a></div>
                        <div class="productCatList"><a href="/products/cameras">Cameras &amp; Accessories</a></div>
                        <div class="productCatList"><a href="/products/gaming">Gaming</a></div>
                        <div class="productCatList"><a href="/products/electronic">TVs, Audio &amp; Video</a></div>
                        <div class="productCatList"><a href="/products/appliances">Appliances</a></div>
                        <div class="productCatList"><a href="/products/men-apparel">Men's Apparel</a></div>
                        <div class="productCatList"><a href="/products/women-apparel">Women's Apparel</a></div>
                        <div class="productCatList"><a href="/products/mens-footwear">Men's Footwear</a></div>
                        <div class="productCatList"><a href="/products/womens-footwear">Women's Footwear</a></div>
                    </div>
                    <div class="productCategoriesBox lfloat" style="height: 296px;">
                        <div class="productCatList"><a href="/products/lifestyle-watches">Watches</a></div>
                        <div class="productCatList"><a href="/products/bags">Bags &amp; Luggage</a></div>
                        <div class="productCatList"><a href="/products/eyewear">Eyewear</a></div>
                        <div class="productCatList"><a href="/products/fashion">Fashion Accessories</a></div>
                        <div class="productCatList"><a href="/products/jewelry">Fashion Jewellery</a></div>
                        <div class="productCatList"><a href="/products/beauty">Beauty &amp; Personal Care</a></div>
                        <div class="productCatList"><a href="/products/jewellery-precious">Precious Jewellery</a></div>
                        <div class="productCatList"><a href="/products/perfumes-beauty">Fragrances</a></div>
                        <div class="productCatList"><a href="/products/health">Health &amp; Nutrition</a></div>
                        <div class="productCatList"><a href="/products/home-kitchen">Home &amp; Kitchen</a></div>
                    </div>
                    <div class="productCategoriesBox lfloat" style="height: 296px;">
                        <div class="productCatList"><a href="/products/furniture">Furniture</a></div>
                        <div class="productCatList"><a href="/products/kitchen-bathroom-fittings">Kitchen &amp; Bathroom Fittings</a></div>
                        <div class="productCatList"><a href="/products/home-furnishing">Home Furnishing</a></div>
                        <div class="productCatList"><a href="/products/books">Books</a></div>
                        <div class="productCatList"><a href="/products/stationery">Stationery &amp; Office Supplies</a></div>
                        <div class="productCatList"><a href="/products/sports-hobbies">Sports &amp; Fitness</a></div>
                        <div class="productCatList"><a href="/products/hobbies">Hobbies</a></div>
                        <div class="productCatList"><a href="/products/kids-toys">Toys &amp; Games</a></div>
                        <div class="productCatList"><a href="/products/kids-decor">Kids Decor</a></div>
                        <div class="productCatList"><a href="/products/baby-care">Baby Care</a></div>
                    </div>
                    <div class="productCategoriesBox lfloat" style="height: 296px;">
                        <div class="productCatList"><a href="/products/automotive">Automotive</a></div>
                        <div class="productCatList"><a href="/products/kids-footwear">Kids Footwear</a></div>
                        <div class="productCatList"><a href="/products/musical-instruments">Musical Instruments</a></div>
                        <div class="productCatList"><a href="/products/entertainment">Movies &amp; Music</a></div>
                        <div class="productCatList"><a href="/products/boys-clothing">Boys Clothing</a></div>
                        <div class="productCatList"><a href="/products/girls-clothing">Girls Clothing</a></div>
                        <div class="productCatList"><a href="/products/baby-clothing">Infant Wear</a></div>
                        <div class="productCatList"><a href="/products/home-kitchen-home-decoratives">Home Decoratives</a></div>
                        <div class="productCatList"><a href="/products/gifts">Gifting &amp; Events</a></div>
                        <div class="productCatList"><a href="/products/women-ethnicwear">Women's Ethnic Wear</a></div>
                    </div>
                </div>
                <div onclick="return CloseCart();" class="start-shoping-button-outer proceed-button"><span>Start Shopping Now</span></div>
            </div>
        </div>
    </div>
    <div class="cart-scroll" id="fillcart" runat="server">
        <div class="cart-cont">
            <div class="mycart-outer">
                <div style="float: left;">
                    <span class="fill-cart">
                        <asp:Label ID="hrdttlitems" runat="server" /></span><span class="cart-text">My Cart</span>
                </div>
                <div style="float: right;">
                    <div onclick="return CloseCart();" class="cart-skip">close</div>
                </div>
            </div>
            <div id="cart-message" style="display: block;">
                <div class="cart-msj cart-success" style="display: none;">
                    <span class="cart_success_msj_heading">Nokia Lumia 520 White added to your cart</span>You have now 2 Items in your cart.

                </div>
                <div class="cart-msj cart-error">
                    <span class="cart_success_msj_heading">Nokia Lumia 925 removed from your cart</span>
                    You have now 1 Items in your cart.
                </div>
            </div>
            <div class="cart-item-outer cart-item-wbor">
                <div class="cart-item-bg">
                    <asp:DataList runat="server" ID="dlstcartlist" RepeatDirection="Vertical"
                        RepeatColumns="1" CssClass="cart-item-bg" Width="100%" OnItemDataBound="dlstcartlist_ItemDataBound" OnItemCommand="dlstcartlist_ItemCommand">
                        <HeaderTemplate>
                            <div class="cart-item-heading-bg">
                                <div class="cart-items">Item(s)</div>
                                <div class="cart-description1">Description</div>
                                <div class="cart-price">Unit Price</div>
                                <div class="cart-quantity">Quantity</div>
                                <div class="cart-total1">Sub Total</div>
                                <div class="cart-remove"></div>
                            </div>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div style="position: relative">
                                <div class="sold-tag sold-"></div>
                                <div class="cart-item-cont ">
                                    <div class="cart-items">
                                        <asp:Image ID="imgcart" runat="server" Width="48" border="0" class="items-image" />
                                    </div>
                                    <div class="cart-description1 des-">
                                        <%--Nokia Lumia 925--%>
                                        <asp:Label runat="server" ID="lblitmname" />
                                    </div>
                                    <div class="cart-price"><strong><%--Rs 28350--%><asp:Label ID="itmcost" runat="server" /></strong> </div>
                                    <div class="cart-quantity">
                                        <asp:DropDownList ID="drpquantity" runat="server" CssClass="quantity-list">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="cart-total1">
                                        <strong>
                                            <asp:Label ID="lblttlcost" runat="server" /></strong><div style="font-size: 11px;">
                                                Offer Discount: (-)
                                                <asp:Label ID="lbldiscount" runat="server" />
                                            </div>
                                    </div>
                                    <div class="cart-remove">
                                        <span id="cart-item-remove-1889911654">
                                            <asp:LinkButton ID="imgremove" runat="server" Text="" CssClass="remove-cart" CommandName="Delete"></asp:LinkButton>

                                        </span>
                                    </div>
                                </div>
                            </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>
        </div>
        <div class="cart-total-outer">
            <div class="cart-total-summary">
                Cart Summary (<span class="cart-text"><asp:Label ID="cartttlitemsres" runat="server" /> &nbsp;Item(s)</span>)<br>
                <span class="promo-text">(You can use your Promo Codes and SD Cash during Payment)</span>
            </div>
            <div align="right" class="cart-total-payment-text">
                <span style="font-size: 14px;">Shipping Charges: <span class="total-text">Rs 0</span></span><br>
                Payable Amount: <span class="total-text">Rs <asp:Label ID="lblttlamnt" runat="server" /></span>
            </div>
        </div>
        <div style="background-color: #fff" class="cart-payment-outer" id="checkout-cart">
            <div class="payment-button-outer">
                <div class="proceed-button"><span><a href="/checkout?cartId=2fab4c50-8146-4a9f-ac2b-979474a61f2d">Proceed to Payment</a></span></div>
                <div onclick="return CloseCart();" class="continue-button"><span>Add more item(s) to cart</span></div>
            </div>
        </div>
        <div id="cross-selling-carousel"></div>
    </div>
</div>
<script language="javascript" type="text/javascript">
    function CloseCart() {
        var errorMessage = "";
        var isValid = true;
        document.getElementById('cart-layout-div').style.display = 'none';
        return isValid;
    }
</script>

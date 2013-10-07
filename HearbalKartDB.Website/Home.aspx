<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <style type="text/css">
        .imggrdstyle {
            height: 200px;
        }
        .command
        {
            display: none;
        }
        .product_listing td {
        vertical-align:top;
        }
    </style>
    <script language="javascript" type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("li").mouseover(function () { jQuery(this).css({ "background-color": "#fff" }); jQuery(this).find(".command").show() });
            jQuery("li").mouseout(function () { jQuery(this).css({ "background-color": "" }); jQuery(this).find(".command").hide() });
        });
    </script>

    <div class="right_portion">
        <asp:DataList runat="server" ID="rptctg" RepeatDirection="Vertical" OnItemDataBound="rptctg_ItemDataBound">
            <ItemTemplate>
                <div class="heading">
                    <asp:LinkButton ID="lnkCtgName" runat="server" OnClick="lnkCtgName_Click" CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
                </div>
                <div class="product_listing">
                    <ul>

                        <asp:DataList runat="server" ID="rptctglqd" RepeatDirection="Horizontal" RepeatColumns="3" OnItemDataBound="rptctglqd_ItemDataBound">
                            <ItemTemplate>
                                <li id="carousel" class="elastislide-list">
                                    <asp:Image ID="IMGLqdProd" runat="server" CssClass="imggrdstyle" />
                                        <div class="content" style="z-index: 700;">
                                            <h2>
                                                <asp:HyperLink ID="lnkProdLqdName" runat="server" /></h2>
                                            <div class="command" >
                                            <ul class="desciption">
                                                <li>Aids in Digestion</li>
                                                <li>Relieves from Gas &amp; Flatulence</li>
                                                <li>Improves Appetite</li>
                                                <li>Nice Tangy Taste</li>
                                            </ul>
                                                </div>
                                        </div>
                                        
                                        <ul class="pricing">
                                            <li class="buyat">
                                                <asp:Label ID="lblLqdprodSum" runat="server" /></li>
                                            <li class="stars">
                                                <img src="images/2.png" /></li>
                                        </ul>
                                    <div class="command" >
                                        <input type="button" value="Add To Cart" class="addcart" />
                                            </div>
                                </li>
                            </ItemTemplate>
                        </asp:DataList>

                    </ul>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
    <script type="text/javascript" src="scripts/jquery.elastislide.js"></script>

    <script type="text/javascript">
        $('#carousel').elastislide();
    </script>
    <script type="text/javascript">

        $('#carousel1').elastislide();

    </script>
</asp:Content>


<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testingthirdaspx.aspx.cs"
    Inherits="Testing_testingthirdaspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        /*<<<<<<<<<<popup>>>>>>>>>>>*/
        .black_overlay1, .black_overlay2
        {
            display: none;
            position: fixed;
            top: 0%;
            left: 0%;
            width: 100%;
            height: 100%;
            background-color: black;
            z-index: 1001;
            -moz-opacity: 0.6;
            opacity: .60;
            filter: alpha(opacity=60);
        }
        .white_box
        {
            display: none;
            position: fixed;
            top: 25%;
            left: 35%;
            -moz-box-shadow: 0px 0px 8px 2px #333;
            -webkit-box-shadow: 0px 0px 8px 2px #333;
            box-shadow: 0px 0px 8px 2px #333;
             padding: 15px 12px 13px;
            border-radius: 9px 9px 9px 9px;
            background-color: white;
            z-index: 1002;
            overflow: auto;
        }
        .white_box .add-address
        {
            border-bottom: 1px solid #ccc;
            float: left;
            padding: 0 0 10px 0;
        }
        .white_box .add-address h3
        {
            font-size: 16px;
            color: #373737;
            float: left;
            width: 340px;
            margin: 0px;
            padding: 0px;
        }
        #light.white_box .add-address h2
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 20px;
            color: #5AC706;
            text-align: center;
            border-bottom: 1px solid #DDDDDD;
            padding-bottom: 10px;
            float: none;
            margin: 0 0 10px 0;
        }
        .cross
        {
            background: url("cross.png") no-repeat scroll 0 0 transparent;
            float: right;
            height: 21px;
            width: 22px;
            margin: -6px 0 0 0;
        }
        body header #headerwrapper #headerright .add-address a
        {
            border: none;
            float: left;
        }
        .white_box .add-adres-footer
        {
            margin: 0px;
            padding: 5px 0 0;
            float: left;
        }
        body header #headerwrapper #headerright .white_box .add-adres-footer a
        {
            color: #fff;
            border: none;
            font-size: 11px;
        }
        .mini-cart
        {
            margin: 0;
            padding: 5px;
            width: 382px;
            z-index: 9999;
            float: left;
        }
        .mini-cart .popupheading
        {
            color: #373737;
            border-bottom: 1px solid #D2D2D2;
            width: 369px;
            text-align: left;
            font-size: 17px;
            line-height: 45px;
            padding: 0 0 0 16px;
        }
        .loginform
        {
            width: 380px;
            margin: 0px;
            padding: 3px 0 11px;
            float: left;
            border-bottom: 1px solid #D2D2D2;
        }
        .loginouter
        {
            float: left;
            width: 380px;
             margin: 0 0 8px;
            padding: 0px;
        }
        .loginouter .loginlabel
        {
            color: #373737;
            float: left;
            font-size: 14px;
           margin: 3px 6px 0 0;
            padding: 0;
            width: 73px;
            text-align: right;
        }
        .loginouter .logininput
        {
            float: left;
            margin: 0;
            padding: 0;
            width: 295px;
        }
        .loginouter .logininput input
        {
            border: 1px solid #DDDDDD;
            border-radius: 4px 4px 4px 4px;
            min-height: 20px;
            width: 230px;
        }
        .rememberme
        {
            float: left;
            margin: 0px;
            padding: 0px;
            color: #373737;
            font-size: 12px;
        }
        .lostpas
        {
            float: right;
            margin: 0 41px 0 0;
            padding: 0px;
        }
        #headerwrapper #headerright .loginouter .lostpas a
        {
            color: #373737;
            font-size: 11px;
            border: none;
            text-decoration: underline;
        }
        .loginbtn
        {
            background: url("../images/miximgbtn.png") no-repeat scroll left -137px transparent;
            margin: 2px 18px 0 0;
            padding: 4px 0;
            float: left;
            border-radius: 4px 4px 4px 4px;
            width: 70px;
        }
        .loginfbbtn
        {
            background: url("../images/miximgsitebtn.png") no-repeat scroll left top transparent;
            margin: 0px;
            width: 149px;
            padding: 4px 0;
            float: left;
        }
        .logintwbtn
        {
            background: url("../images/miximgsitebtn.png") no-repeat scroll left -34px transparent;
            margin: 0px;
            padding: 4px 0;
            float: left;
            width: 121px;
        }
    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <a href="javascript:void(0)" onclick="document.getElementById('light').style.display='block';document.getElementById('fade').style.display='block'"
        style="color: #ffffff;">login</a>
    <div id="light" class="white_box" style="width: 380px;">
        <div class="add-address">
            <h3>
                Login To Website</h3>
            <a href="javascript:void(0);" onclick="document.getElementById('light').style.display='none';document.getElementById('fade').style.display='none'">
                <span class="cross"></span></a>
        </div>
        <div class="mini-cart">
            <div class="loginform">
                <div class="loginouter">
                    <span class="loginlabel">Email :</span><span class="logininput"><input type="text"
                        value="" name="email"></span>
                </div>
                <div class="loginouter">
                    <span class="loginlabel">Password :</span><span class="logininput"><input type="text"
                        value="" name="email"></span>
                </div>
                <div class="loginouter">
                    <span class="rememberme">
                        <input type="checkbox" name="rememberme" value="">
                        Remember Me</span> <span class="lostpas"><a href="#">Forget Password?</a></span>
                </div>
            </div>
        </div>
        <div class="cl">
        </div>
        <div class="add-adres-footer">
            <div class="loginbtn">
                <a href="#">Login</a></div>
            <div class="loginfbbtn">
                <a href="#">Using Facebook</a></div>
            <div class="logintwbtn">
                <a href="#">Twitter</a></div>
        </div>
        <!--add-adres-footer-->
    </div>
    <a onclick="document.getElementById('light').style.display='none';document.getElementById('fade').style.display='none'"
        href="javascript:void(0)" style="border: none;">
        <div id="fade" class="black_overlay1" onclick="document.getElementById('light').style.display='none';document.getElementById('fade').style.display='none'">
        </div>
    </a>
    </form>
</body>
</html>

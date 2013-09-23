﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestingPOPUp.aspx.cs" Inherits="Testing_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .pop-up {position:absolute; top:0; left:-500em}
.pop-up:target {position:static; left:0;}
.popBox {
  background:#ffffff;

  /* alternatively fixed width / height and negative margins from 50% */
  position:absolute; left:30%; right:30%; top:30%; bottom:30%;

  z-index:1;
  /* padding:1%; removed 17/07/2012 */
  border:1px solid #3a3a3a;

  /* CSS3 rounded corners, drop-shadow and opacity fade in */
  -moz-border-radius:12px;
  border-radius:12px;
  -webkit-box-shadow:2px 2px 4px #3a3a3a;
  -moz-box-shadow:2px 2px 4px #3a3a3a;
  box-shadow:2px 2px 4px #3a3a3a;
  opacity:0;
  -webkit-transition: opacity 0.5s ease-in-out;
  -moz-transition: opacity 0.5s ease-in-out;
  -o-transition: opacity 0.5s ease-in-out;
  -ms-transition: opacity 0.5s ease-in-out;
  transition: opacity 0.5s ease-in-out;
}
:target .popBox {position:fixed; opacity:1;}

.popBox:hover {box-shadow:3px 3px 6px #5a5a5a;}
.lightbox {display:none; text-indent:-200em; background:#000; opacity:0.4; width:100%; height:100%; position:fixed; top:0; left:0; bottom:0; right:0;}
:target .lightbox {display:block}
  .close {
  position:absolute; top:-0.75em; right:-0.75em; display:block; width:1em; height:1em;
  font:bold large/1 arial, sans-serif; text-align:center; text-decoration:none;
  background:#000; border:3px solid #fff; color:#fff;
  -moz-border-radius: 1em;
  -webkit-border-radius: 1em;
  border-radius: 1em;
  -moz-box-shadow: 0 0 1px 1px #3a3a3a;
  -webkit-box-shadow: 0 0 1px 1px #3a3a3a;
  box-shadow: 0 0 1px 1px #3a3a3a;
}
.close:before {content:"X"}
.close:hover {box-shadow:0 0 1px 1px #c00; background:#c00;}
.close span {text-indent:-200em; display:block;}
/* .popScroll {max-height:99%; overflow-y:scroll;} removed 17/07/2012 */
.popScroll {position:absolute; top:9%; left:3%; right:3%; bottom:9%; overflow-y:auto; *overflow-y:scroll; padding-right:0.5em}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <ul id="links">
        <li><a href="#pop1">Pop-up One</a></li>
        <li><a href="#pop2">Pop-up Two</a></li>
        <li><a href="#pop3">Pop-up Three</a></li>
    </ul>
    <div id="pop2" class="pop-up">
        <div class="popBox">
            <div class="popScroll">
                <h2>
                    Pop-up Two</h2>
                <p>
                    Blah, blah, blah. Yada, yada, yada.</p>
            </div>
            <a href="" class="close"><span>Close</span></span></a>
        </div>
        <a href="#links" class="lightbox">Back to links</a>
    </div>
    </form>
</body>
</html>

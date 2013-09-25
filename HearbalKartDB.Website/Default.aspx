<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="HearbalKartDB.Website._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Page</title>
    <script type="text/javascript">

        function DisplayBox() {

            document.getElementById('boxdiv').style.display = 'block';

            document.getElementById('outerdiv').style.display = 'block';
        }

        function CloseBox() {

            document.getElementById('boxdiv').style.display = 'none';

            document.getElementById('outerdiv').style.display = 'none';

        }

    </script>
    <style type="text/css">
        .black_overlay {
            display: none;
            position: absolute;
            top: 0%;
            left: 0%;
            width: 100%;
            height: 100%;
            background-color: black;
            z-index: 1001;
            -moz-opacity: 0.8;
            opacity: .80;
            filter: alpha(opacity=80);
        }

        .white_content {
            display: none;
            position: absolute;
            top: 25%;
            left: 35%;
            width: 35%;
            padding: 0px;
            border: 0px solid #a6c25c;
            background-color: white;
            z-index: 1002;
            overflow: auto;
        }

        .headertext {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 14px;
            color: #f19a19;
            font-weight: bold;
        }

        .textfield {
            border: 1px solid black;
            width: 135px;
        }

        .buttonclass {
            background-color: blue;
            color: White;
            font-size: 11px;
            font-weight: bold;
            border: 1px solid #7f9db9;
            width: 68px;
        }
    </style>
    <%-- <meta http-equiv="REFRESH" content="5; URL=/HearbalKartDB.Website/admin/">
    .--%>
</head>
<body>
    <form id="form1" runat="server">
        <a href="javascript:void(0)" onclick="javascript:DisplayBox();">Click here to display</a>
        <div id="boxdiv" class="white_content">
            <table cellpadding="0" cellspacing="0" border="0" style="background-color: Yellow;"
                width="100%">
                <tr>
                    <td height="16px"></td>
                </tr>
                <tr>
                    <td style="padding-left: 16px; padding-right: 16px; padding-bottom: 16px">
                        <table align="center" border="0" cellpadding="0" cellspacing="0" style="background-color: #fff">
                            <div id="Div1" class="white_content">
                                <table border="0" cellpadding="0" cellspacing="0" style="background-color: Yellow;"
                                    width="100%">
                                    <tr>
                                        <td height="16px"></td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 16px; padding-right: 16px; padding-bottom: 16px">
                                            <table align="center" border="0" cellpadding="0" cellspacing="0" style="background-color: #fff"
                                                width="100%">
                                                <tr>
                                                    <td align="center" class="headertext" colspan="2">Login Form
                                                </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;
                                                </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <table>
                                                            <tr>
                                                                <td align="right">Username:
                                                            </td>
                                                                <td>
                                                                    <asp:TextBox ID="TxtUser" runat="server" CssClass="textfield"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="10px"></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">Password:
                                                            </td>
                                                                <td>
                                                                    <asp:TextBox ID="Txtpass" runat="server" CssClass="textfield" TextMode="Password"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="10px"></td>
                                                            </tr>
                                                            <tr>
                                                                <td></td>
                                                                <td>
                                                                    <%--<input type="submit" value="Log in" class="btn btn-primary" />--%>
                                                                    <asp:Button ID="btnSub" runat="server" Text="Submit" class="btn btn-primary" OnClick="btnSub_Click" />
                                                                    <input type="reset" value="Cancel" class="btn btn-primary" />
                                                                    <input class="buttonclass" onclick="javascript: CloseBox();" type="button" value="Close" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="10px"></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                    </td>
                </tr>
            </table>
            <div align="center" class=" headertext">
                <asp:Label ID="lblmessage" runat="server"></asp:Label>
            </div>
        </div>
        <div id="outerdiv" class="black_overlay">
        </div>
    </form>
</body>
</html>

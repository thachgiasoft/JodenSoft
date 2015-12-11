<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="myPortal.Web.WWWRoot.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>报表门户</title>
    <meta http-equiv="content-type" content="text/html;charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <link href="Css/login.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.8.1.min.js"></script>
    <script type="text/javascript">
        $(function () {
            if (top.window != window) {
                top.window.location.href = window.location.href;
                return;
            }

            document.getElementById("login1_UserName").focus();
        });

        function checkValue() {
            var name = document.getElementById("login1_UserName").value;
            if (name == "") {
                document.getElementById("lblMsg").innerHTML = "用户名不能为空.";
                return false;
            }
            var password = document.getElementById("login1_Password").value;
            if (password == "") {
                document.getElementById("lblMsg").innerHTML = "密码不能为空.";
                return false;
            }

            return true;
        }

        function saveWeb() {
            window.external.AddFavorite('<%=url %>', 'myPortal');
            return false;
        }
    </script>
    <style type="text/css">
        .Login
        {
            border: solid 1px maroon;
            background: url(../cti/img/btn_bg.gif) repeat-x 0 -6px;
            color: #3333ff;
            padding-top: 2px;
            height: 21px;
            width: 60px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="width: 10%; height: 100px;">
                            
                        </td>
                        <td style="width: 90%; text-align: right; vertical-align: bottom;">
                            <span style="color: Maroon; font-size: 24px; font-weight: bold; margin-right: 10px">
                                企业信息查询平台</span>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="3" style="background-color: Maroon" />
        </tr>
        <tr>
            <td height="40" style="text-align: left;">
                <span style="color: Maroon; font-size: 20px; font-weight: bold; margin-left: 10px">
                </span>
            </td>
        </tr>
        <tr>
            <td>
                <div>
                    <div class="divMain">
                        <div class="divInput">
                            <table>
                                <tr>
                                    <td colspan="2">
                                        <asp:Login ID="login1" OnAuthenticate="login1_Authenticate" runat="server">
                                            <LayoutTemplate>
                                                <table id="tableLogin">
                                                    <tr>
                                                        <td style="width: 40px;">
                                                            <asp:Label ID="lblUserName" runat="server" Text="用户" ForeColor="Maroon"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="UserName" autocomplete="off" runat="server" CssClass="text" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblPassword" runat="server" Text="密码" ForeColor="Maroon"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="Password" TextMode="Password" runat="server" CssClass="text" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="text-align: right;">
                                                            <asp:Button ID="Login" CommandName="Login" runat="server" Text="登录" CssClass="Login"
                                                                ForeColor="Black" OnClientClick="return checkValue();" />&nbsp;&nbsp;
                                                            <asp:Button ID="btnSave" runat="server" Text="收藏网站" ForeColor="Black" CssClass="Login"
                                                                OnClientClick="return saveWeb();" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </LayoutTemplate>
                                        </asp:Login>
                                    </td>
                                </tr>
                            </table>
                            <div style="width: 100%; text-align: left;">
                                <asp:Label ID="lblMsg" runat="server" ForeColor="Maroon"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                &nbsp;
            </td>
        </tr>
    </table>
    <div>
    </div>
    <input type="hidden" id="txtWinHeight" name="txtWinHeight" />
    <input type="hidden" id="txtIEVersion" name="txtIEVersion" />
    </form>
    <script type="text/javascript" src="js/Login.js"></script>
</body>
</html>

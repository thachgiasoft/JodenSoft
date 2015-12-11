<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="CttSoft.Web.WWWRoot.Welcome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>欢迎使用 myPortal</title>
    <meta http-equiv="content-type" content="text/html;charset=utf-8" />
    <link href="Css/common.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="js/jquery-1.8.1.min.js"></script>
    <script type="text/javascript">
        $(function () {
            setTimeout(function () {
                location.href = "BulletinView.aspx";
            }, 3000);
        });
    </script>
</head>
<body>
    <div class="wrap">
        <div id="tip" class="tip">
            <div class="tip_t">
                <h4>
                    <asp:Label ID="lblWelcome" runat="server" Text="欢迎使用..."></asp:Label></h4>
                <br />
                <span>
                    <asp:Label ID="lblWelcome2" runat="server" Text="欢迎使用 myPortal" /></span>
            </div>
            <div class="tip_m">
                <h5>
                </h5>
                <p>
                    <asp:Label ID="lblJump" runat="server" Text="3秒后自动跳转..." />
                    <br />
                    <br />
                    <br />
                </p>
            </div>
        </div>
    </div>
</body>
</html>

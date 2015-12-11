<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BulletinView.aspx.cs" Inherits="myPortal.Web.WWWRoot.BulletinView"
       %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>系统公告</title>
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
    <link href="Css/common.css?<%=System.DateTime.Now.Ticks %>" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="js/jquery-1.8.1.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $.ajax({
                async: true,
                url: "Handlers/BulletinHandler.ashx",
                success: function (data, textStatus) {
                    $("#d_h1").empty();
                    $("#d_h1").append(data);
                    $("li.b_item").css("cursor", "pointer");
                    $("li.b_item").hover(function () { $(this).addClass("hover") }, function () { $(this).removeClass("hover"); });
                    $("li.b_item").bind("click", function () { $(this).children(".b_item_c").toggle(); $(this).children("a.b_collapse").toggleClass("collapsed"); });
                }
            });
        });
    </script>
</head>
<body>
    <div class="wrap">
        <form id="form1" runat="server">
        <div class="h_line">
            <a href="javascript://;" id="_h1" class="h_n">
                <asp:Label ID="Label1" runat="server" Text="公告信息" ></asp:Label></a>
        </div>
        <div class="c" id="d_h1">
            <div>
                <img src="img/skin1/nav_loading.gif" alt="" />
                <asp:Label ID="Label2" runat="server" Text="正在读取公告，请稍候..." ></asp:Label></div>
        </div>
        </form>
    </div>
</body>
</html>

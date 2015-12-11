<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TopFrame.aspx.cs" Inherits="myPortal.Web.WWWRoot.TopFrame" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script type="text/javascript" src="js/jquery-1.8.1.min.js"></script>
    <script type="text/javascript" src="js/marqueue.js"></script>
    <link rel="stylesheet" href="css/common.css" type="text/css" />
    <title></title>
    <script type="text/javascript">
        var preClassName = "man_nav_0";
        function _g(eid) {
            return document.getElementById(eid);
        }
        function list_sub_nav(Id, menuName) {
            var eid = "man_nav_" + Id;
            if (preClassName != "") {
                _g(preClassName).className = "bg_image";
            }
            if (_g(eid).className == "bg_image") {
                _g(eid).className = "bg_image_on";
                preClassName = eid;
                var leftwin = window.top.leftFrame.getSubItems(Id, menuName);
            }
        }



        $(function () {

            $(this).keydown(function () {
                if (window.event.keyCode == 27)//ESC 
                {
                    window.event.keyCode = 8;
                }
                if (event.keyCode == 8)//后退键 
                {
                    event.keyCode = 0;
                    event.cancelBubble = true;
                    return false;
                }
            });


        });
    </script>
    <style media="all" type="text/css">
        .header_content
        {
            height: 54px;
            overflow: hidden;
        }
        .logo, .text_left, #user_info
        {
            float: left;
        }
        .nav_return
        {
            list-style-type: none;
        }
        .nav_return li
        {
            float: left;
        }
        #nav ul
        {
            list-style-type: none;
        }
        .nav_return li
        {
            float: left;
            margin-left: 20px;
        }
        #nav_b
        {
            height: 31px;
            overflow: hidden;
            background: url(img/skin1/nav_bg_.gif) repeat-x;
            position: relative;
        }
        #user_info
        {
            width: 220px;
            background: url(img/skin1/nav_bg.gif) no-repeat;
            height: 25px;
            padding: 10px 0 0 10px;
            overflow: hidden;
        }
        #nav
        {
            height: 30px;
            padding: 7px 0 0;
            position: relative;
        }
        .bg_image
        {
            background: url(img/skin1/nav_btn_bg.gif) -72px 0;
        }
        .bg_image_on
        {
            background: url(img/skin1/nav_btn_bg.gif);
        }
        #nav ul li
        {
            float: left;
            margin-left: 1px;
            cursor: pointer;
            padding-top: 5px;
            width: 73px;
            height: 19px;
            text-align: center;
        }
        #nav_endle
        {
            position: absolute;
            right: 0;
            top: 0;
            background: url(img/skin1/nav_bg.gif) -308px 0;
            display: block;
            width: 2px;
            height: 31px;
            margin: 0;
            padding: 0;
        }
        #bulletin
        {
            position: absolute;
            right: 80px;
            top: 8px;
            width: 400px;
            height: 45px;
            overflow: hidden;
        }
        #bulletin #bcontainer
        {
            width: 400px;
            border: none;
        }
        #bulletin #bcontainer li.b_item
        {
            height: 15px;
            border: none;
            margin: 0;
            padding: 0;
        }
        li.b_item a
        {
            font-size: 12px;
            font-weight: normal;
        }
        li.b_item span
        {
        }
        #nav_scroll_container
        {
            position: absolute;
            top: 2px;
            right: 0;
            width: 20px;
            height: 12px;
        }
        .scroll_btn
        {
            text-indent: -200px;
            float: left;
            width: 8px;
            height: 12px;
            background-image: url(img/skin1/scroll.gif);
            overflow: hidden;
            margin-right: 2px;
        }
        #scroll_left
        {
            background-position: -36px 0;
        }
    </style>
</head>
<body>
    <div class="header_content">
        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="padding: 0;
            margin: 0; background: url(img/frame/banner_bg.jpg) repeat-x; height: 58px;">
            <tr>
                <td style="background: url(img/frame/EsquelBk.png) repeat-x;">
                    <img alt="" src="img/frame/EsquelTopImg.png" />
                </td>
            </tr>
        </table>
    </div>
    <div id="nav_b">
        <div id="user_info">
            <asp:Label ID="lblWelcome" runat="server" Text="欢迎，" /><a href="#"><%=sUserName %></a></div>
        <div id="nav">
            <ul>
                <li id="man_nav_0" onclick="list_sub_nav(0,'基本操作');" class="bg_image_on">
                    <asp:Label ID="lblBasicOperation" runat="server" Text="基本操作"></asp:Label></li>
                <%=Menus %>
            </ul>
        </div>
        <div id="nav_scroll_container" class="hide">
            <a href="javascript:void(0);" id="scroll_left" onclick="javascript:scroll(-1);" class="scroll_btn">
                &lt;&lt;</a> <a href="javascript:void(0);" id="scroll_right" onclick="javascript:scroll(1);"
                    class="scroll_btn">&gt;&gt;</a>
        </div>
    </div>
</body>
</html>

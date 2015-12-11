<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainFrame.aspx.cs" Inherits="myPortal.Web.WWWRoot.MainFrame" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="css/common.css" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.8.1.min.js"></script>
    <script type="text/javascript" src="js/jquery.cookie.js"></script>
    <script type="text/javascript" src="js/jsonSerializer.js"></script>
    <script type="text/javascript" src="js/tabs.js?<%=System.DateTime.Now.Ticks %>"></script>
    <title></title>
    <script type="text/javascript">
        window.onresize = function () {
            var pageHeight = document.documentElement.clientHeight;
            $(".tabp").height(pageHeight - 35);
        }

        $(function () {
            tab = new Tabs($("#tabHeaders"), $("#tabPages"));
            changeFrame("欢迎页", 0, 0, "Welcome.aspx");

            var pageHeight = document.documentElement.clientHeight;
            $(".tabp").height(pageHeight - 35);
        });

    </script>
    <style type="text/css">
        body
        {
            margin-top: 2px;
        }
        #tabs
        {
            border: solid 1px #a4d5f6;
        }
        #tabHeaders
        {
            list-style-type: none;
            display: block;
        }
        .tabh
        {
            cursor: pointer;
            float: left;
            font-size: 12px;
            position: relative;
            padding: 4px 5px 0;
            margin: 6px 0 0 2px;
            color: #3399ff;
            height: 20px;
            background: url(img/skin1/tab_h_bg.gif) repeat-x 0 -24px;
        }
        .tabh_s
        {
            background: url(img/skin1/tab_h_bg.gif) repeat-x 0 0;
        }
        .tabh_l
        {
            position: absolute;
            left: 0;
            top: 0;
            display: block;
            background: url(img/skin1/tab_h_bg.gif) no-repeat 0 -48px;
            width: 2px;
            height: 24px;
        }
        .tabh_r
        {
            position: absolute;
            right: 0;
            top: 0;
            display: block;
            background: url(img/skin1/tab_h_bg.gif) no-repeat -2px -48px;
            width: 2px;
            height: 24px;
            _right: -2px;
        }
        .tabp
        {
            width: 100%;
            height: <%=frameWinHeight %>px;
            display: none;
        }
        .tabp_s
        {
            display: block;
        }
        #tabHC
        {
            background: url(img/skin1/tab_bg.gif) repeat-x;
            background-position: 0 -32px;
            height: 30px;
        }
        #tools
        {
            height: 16px;
            overflow: hidden;
            position: absolute;
            top: 10px;
            right: 1px;
            padding-top: 2px;
            width: 70px;
        }
        #tools a
        {
            height: 16px;
            text-indent: -1000px;
            float: left;
            overflow: hidden;
        }
        #tools a.t_btn:hover
        {
            border-bottom: solid 1px #ccc;
            border-right: solid 1px #ccc;
            border-top: solid 1px transparent;
        }
        #t_collapse, #t_expand, #t_fav, #t_refresh, #t_dept, #t_back, #t_forward
        {
            background-image: url(img/skin1/tools.gif);
            background-repeat: no-repeat;
        }
        #t_collapse
        {
            background-position: 0 -48px;
            width: 14px;
        }
        #t_expand
        {
            background-position: 0 -64px;
            width: 12px;
            display: none;
        }
        #t_back
        {
            background-position: 1px -96px;
            width: 18px;
        }
        #t_forward
        {
            background-position: 1px -80px;
            width: 18px;
        }
        #t_fav
        {
            width: 18px;
            background-position: 1px 0;
        }
        #t_refresh
        {
            width: 18px;
            background-position: 1px -16px;
        }
        #t_dept
        {
            width: 18px;
            background-position: 1px -32px;
        }
        .b_pop
        {
            position: absolute;
            display: none;
            width: 300px;
            height: 0px;
            right: 2px;
            padding: 10px;
            overflow: hidden;
            bottom: 1px;
        }
        .b_pop
        {
            border: solid 1px #a4d5f6;
            background: #fff url(img/skin1/tab_bg.gif) repeat-x;
            background-position: 0 -32px;
            font-size: 14px;
        }
        .b_pop a
        {
            font-weight: bold;
        }
        .b_pop div
        {
            margin: 10px;
            overflow: hidden;
        }
    </style>
</head>
<body>
    <div id="tabs">
        <div id="tabHC">
            <ul id="tabHeaders">
            </ul>
        </div>
        <div id="tabPages">
        </div>
    </div>
</body>
</html>

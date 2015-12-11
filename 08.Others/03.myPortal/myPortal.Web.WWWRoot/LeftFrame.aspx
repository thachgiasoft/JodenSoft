<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeftFrame.aspx.cs" Inherits="myPortal.Web.WWWRoot.LeftFrame" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
    <link rel="stylesheet" href="css/common.css" type="text/css" />
    <title></title>
    <script type="text/javascript" src="js/jquery-1.8.1.min.js"></script>
    <script type="text/javascript" src="js/jquery.cookie.js"></script>
    <script type="text/javascript" src="js/jsonSerializer.js"></script>
    <style type="text/css" media="all">
        body
        {
            margin: 2px 0 2px 1px;
        }
        #left_content
        {
            border-left: solid 1px #a4d5f6;
            border-right: solid 1px #a4d5f6;
            height: 1000px;
            padding-top: 40px;
        }
        #top
        {
            background: url(img/skin1/nav2_bg.gif);
            height: 25px;
            position: absolute;
            top: 2px;
            left: 1px;
            width: 179px;
            padding-top: 10px;
            padding-left: 20px;
            font-size: 13px;
            font-weight: bold;
            color: #4ea5ff;
        }
        #bottom
        {
            background: url(img/skin1/nav2_bg.gif) no-repeat 0 -38px;
            height: 2px;
            position: absolute;
            bottom: 0;
            left: 1px;
            width: 199px;
            _bottom: -13px;
        }
        #main_nav
        {
            margin-left: 10px;
            overflow: auto;
        }
        .list_title
        {
            background: url(img/skin1/list_title.gif) no-repeat;
        }
        .list_title_onclick
        {
            background: url(img/skin1/list_title_onclick.gif) no-repeat;
        }
        .list_title, .list_title_onclick
        {
            clear: both;
            height: 22px;
            width: 140px;
            padding: 3px 0 0 30px;
            font-weight: bold;
            color: #0099CC;
            margin-top: 10px;
            cursor: pointer;
        }
        .list_detail
        {
            margin: 0 auto;
        }
        .list_detail li
        {
            list-style-image: url(img/skin1/direct_blue.gif);
            list-style-position: inside;
            padding: 0 0 0 10px;
            margin-top: 2px;
        }
    </style>
</head>
<script type="text/javascript">
    var preid = 0;
    var curid = 0;
    var basicOptions = '';
    function _g(eid) {
        return document.getElementById(eid);
    }

    function getSubItems(Id, menuName) {
        _g("menuTitle").innerHTML = menuName;

        if (preid == 0) {
            basicOptions = _g("right_main_nav").innerHTML;
            preid = 1;
        }

        if (Id == 0) {
            _g("right_main_nav").innerHTML = basicOptions;
            curid = Id;
        }
        else {
            $("#nav_loading").css("display", "block");

            $.get("Handlers/NavHandlers.ashx", { "mid": Id },
                function (data) {
                    $("#right_main_nav").empty();
                    $("#right_main_nav").append(data);
                    $("#nav_loading").css("display", "none");
                    curid = Id;
                    checkhidestate(Id);
                });
        }
    }

    function checkhidestate(Id) {
        var lm_hidestate = readhidesetting();
        var len = $("#right_main_nav>div.list_detail").length;
        if (len <= 1) return;

        if (!lm_hidestate['lm_hide_' + Id]) {
            updatehidestate(Id);
            return;
        }

        var setting = lm_hidestate['lm_hide_' + Id];
        var idx = 0;

        $("#right_main_nav>div.list_detail").each(function () {
            if (setting.charAt(idx) == '1') {
                hideorshow($(this).attr('id'));
            }
            idx++;
        });

    }

    function updatehidestate(Id) {
        var setting = '';
        $("#right_main_nav>div.list_detail").each(function () {
            if ($(this).css("display") == 'none')
                setting = setting + '1';
            else
                setting = setting + '0';
        });
        var lm_hidestate = readhidesetting();
        lm_hidestate["lm_hide_" + Id] = setting;
        x = jsonSerializer.encode(lm_hidestate);
        $.cookie('lm_hide', x, { expires: 7 });
    }

    function readhidesetting() {
        var x = $.cookie('lm_hide');
        var lm_hidestate;
        if (!x) {
            lm_hidestate = {};
        }
        else {
            lm_hidestate = jsonSerializer.decode(x);
            if (!lm_hidestate)
                lm_hidestate = {};
        }

        return lm_hidestate;
    }

    function changeframe(title, openMode, id, src) {
        window.top.manFrame.changeFrame(title, openMode, id, src);
    }

    function hideorshow(divid) {
        subsortid = "sub_sort_" + divid.substring(11);
        if (_g(divid).style.display == "none") {
            _g(divid).style.display = "block";
            _g(subsortid).className = "list_title";
        }
        else {
            _g(divid).style.display = "none";
            _g(subsortid).className = "list_title_onclick"
        }

        if ($("#right_main_nav>div.list_detail").length > 1)
            updatehidestate(curid);
    }

    function ShowWindows() {
        var url = "Default.aspx";
        var w = screen.availWidth;
        var h = screen.availHeight;
        window.top.location = url;
    }

    $(document).ready(function () {
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
<body>
    <div id="top">
        <span id="menuTitle">
            <asp:Label ID="lblMenuBasicOperation" runat="server" Text="基本操作"></asp:Label></span>
        <em id="nav_loading">
            <img src="img/skin1/nav_loading.gif" alt="" /></em>
    </div>
    <div id="left_content">
        <div id="main_nav">
            <div id="right_main_nav">
                <div id="sub_sort_0" class="list_title" onclick="hideorshow('sub_detail_0')">
                    <span>
                        <asp:Label ID="lblGroupBasicOperation" runat="server" Text="基本操作" /></span></div>
                <div id="sub_detail_0" class="list_detail">
                    <ul>
                        <li id="item_03" onclick="changeframe('系统公告',0,0,'bulletinView.aspx')"><a href="javascript:void(0);">
                            <asp:Label ID="lblSysAnnouncement" runat="server" Text="系统公告" /></a></li>
                        <li id="item_02" onclick="changeframe('修改密码',0,0,'changepass.aspx')"><a href="javascript:void(0);">
                            <asp:Label ID="lblChangePassword" runat="server" Text="修改密码" /></a></li>
                        <li id="item_01" onclick="if(window.confirm('确定要重新登录吗?')){ShowWindows();}"><a href="javascript:void(0);">
                            <asp:Label ID="lblRelogin" runat="server" Text="重新登录" /></a></li>
                        <li id="item_00" onclick="if(window.confirm('确定要退出系统吗?')){changeframe('退出系统',0,0,'logout.aspx')}">
                            <a href="javascript:void(0);">
                                <asp:Label ID="lblExitSystem" runat="server" Text="退出系统" /></a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <div id="bottom">
    </div>
</body>
</html>

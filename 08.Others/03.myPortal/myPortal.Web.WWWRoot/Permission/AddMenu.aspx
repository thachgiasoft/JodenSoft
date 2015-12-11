<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMenu.aspx.cs" Inherits="myPortal.Web.WWWRoot.Permission.AddMenu"    %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>菜单信息</title>
    <meta http-equiv="content-type" content="text/html;charset=utf-8" />
    <link href="../Css/common.css" type="text/css" rel="stylesheet" />
    <link href="../Css/redmond/jquery-ui-1.8.23.custom.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.8.1.min.js" type="text/javascript"></script>
    <script src="../js/jquery-ui-1.8.23.custom.min.js" type="text/javascript"></script>
    <script src="../js/Common.js" type="text/javascript"></script>
    <script src="../js/jquery.cookie.js" type="text/javascript"></script>
    <script src="../js/jQuery.common.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            headline();
            listhover();
            $("#MenuTree").dialog({
                autoOpen: false,
                resizable: false,
                width: 400,
                minHeight: 200,
                position: 'top',
                modal: true,
                draggable: true,
                closeOnEscape: true,
                buttons: {
                    "确定": function () {
                        var v = "";
                        var title = "";
                        if ($(":radio[name='radio_menu']:checked").length > 0) {
                            v = $(":radio[name='radio_menu']:checked").val();
                            title = $(":radio[name='radio_menu']:checked").attr("title");
                        }
                        else {
                            v = "";
                            title = ""
                        }
                        $("#txtParentId").val(v);
                        $("#txtParentMenuName").val(title);
                        $(this).dialog("close");
                    },
                    "清空": function () {
                        $("#txtParentId").val("");
                        $("#txtParentMenuName").val("");
                        $(this).dialog("close");
                    },
                    "取消": function () {
                        $(this).dialog("close");
                    }
                }
            });

            $("#btnQueryParent").click(function () {
                $("#radio_menu_" + $("#txtParentId").val()).attr("checked", "checked");
                $("#radio_menu_" + $("#txtMenuId").val()).remove();
                $("#MenuTree").dialog("open");
                return false;
            });
        });        
    </script>
    <style type="text/css">
        #m_menu
        {
            position: absolute;
            left: 400px;
            border: solid 1px #a4d5f6;
            display: none;
            background: #eef5fa;
            padding: 10px;
            max-height: 400px;
            overflow: auto;
            min-width: 260px;
        }
        .cur
        {
            font-weight: bold;
            color: #f00;
        }
    </style>
</head>
<body>
    <div class="wrap">
        <form id="form1" runat="server">
        <div class="h_line">
            <a href="javascript://;" id="_h2" class="h_n">
            <asp:Label ID="lblInfo" runat="server"
                Text="菜单信息" ></asp:Label></a>
        </div>
        <div class="c" id="d_h2">
            <table class="det_t">
                <tr>
                    <td class="th w_p15">
                        <asp:Label ID="lblName" runat="server" Text="名称" 
                            ></asp:Label><span class="red">*</span>
                    </td>
                    <td class="w_p35">
                        <asp:TextBox ID="txtMenuName" MaxLength="45" CssClass="n_txt w_p99" 
                            runat="server" ></asp:TextBox>
                    </td>
                    <td class="th w_p15">
                        <asp:Label ID="lblParentMenu" runat="server" Text="上级菜单" 
                            ></asp:Label>
                    </td>
                    <td class="w_p35">
                        <table class="buttonedit">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtParentMenuName" CssClass="n_txt w_p99" runat="server" 
                                        ReadOnly="True" ></asp:TextBox>
                                    <input type="hidden" id="txtParentId" value="" runat="server" />
                                </td>
                                <td class="w_20">
                                    <input id="btnQueryParent" type="button" class="searchbtn w_99" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="th w_p15">
                        <asp:Label ID="lblURL" runat="server" Text="URL" 
                            ></asp:Label>
                    </td>
                    <td class="w_p35">
                        <asp:TextBox ID="txtURL" MaxLength="350" CssClass="n_txt w_p99" runat="server" 
                            ></asp:TextBox>
                    </td>
                    <td class="th w_p15">
                        <asp:Label ID="lblSort" runat="server" Text="排序" 
                            ></asp:Label><span class="red">*</span>
                    </td>
                    <td class="w_p35">
                        <asp:TextBox CssClass="n_txt w_p99" MaxLength="9" ID="txtSort" runat="server" 
                            onkeyup="this.value=this.value.replace(/[^\d]+?/g,'')" 
                            ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="th w_p15">
                        <asp:Label ID="lblMenuLevel" runat="server" Text="菜单级别" 
                            ></asp:Label><span class="red">*</span>
                    </td>
                    <td class="w_p35">
                        <asp:DropDownList ID="ddlLevel" runat="server" CssClass="w_p99 n_txt" 
                            >
                        </asp:DropDownList>
                    </td>
                    <td class="th w_p15">
                        <asp:Label ID="lblOpenMode" runat="server" Text="打开方式" 
                            ></asp:Label><span class="red">*</span>
                    </td>
                    <td class="w_p35">
                        <asp:DropDownList ID="ddlOpenMode" runat="server" CssClass="w_p99 n_txt" 
                            >
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <% if (hasError)
               { %>
            <div class="err_tips m_10">
                <p>
                    操作发生错误!</p>
                <p>
                   </p>
                <%=errorMsg %>
            </div>
            <%} %>
            <div class="f_r m_10">
                <asp:Button ID="buttonOK" runat="server" Text="确认" OnClick="buttonOK_Click" 
                    CssClass="n_btn w_60"  />
                <input type="button" class="n_btn w_60" value="取消" onclick="javascript:history.go(-1);" />
            </div>
            <input type="hidden" id="txtMenuId" value="" runat="server" />
        </div>
        <div id="MenuTree" title="选择上级菜单" style="display: none">
            <div id="divtree" style="background-color: White; overflow: auto; height: 300px;">
                <asp:TreeView ID="treeMenus" runat="server" Width="100%" ShowLines="True" 
                    >
                </asp:TreeView>
            </div>
        </div>
        </form>
    </div>
</body>
</html>

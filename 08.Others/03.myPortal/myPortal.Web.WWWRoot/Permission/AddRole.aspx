<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRole.aspx.cs" Inherits="myPortal.Web.WWWRoot.Permission.AddRole" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>角色管理</title>
    <meta http-equiv="content-type" content="text/html;charset=utf-8" />
    <link href="../Css/common.css" type="text/css" rel="stylesheet" />
    <link href="../Css/jquery.treeview.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.8.1.min.js" type="text/javascript"></script>
    <script src="../js/jquery.treeview.js" type="text/javascript"></script>
    <script src="../js/jquery.cookie.js" type="text/javascript"></script>
    <script src="../js/Common.js" type="text/javascript"></script>
    <script type="text/javascript">
        function recursive(o, checked) {
            o.nextAll("ul").find(">li input").each(function () {
                $(this).attr("checked", checked);
                recursive($(this), checked);
            });
        }

        function recursiveUp(o) {
            var t = o.parent().parent().parent().find(">input");

            if (t.attr("checked"))
                return;

            if (t.length > 0) {
                t.attr("checked", true);
                recursiveUp(t);
            }
        }

        $(function () {
            headline();
            listhover();

            $("#tree-dept").treeview({ persist: "cookie", cookieId: "tree-dept" });
            $("input[name='cb_permission']").bind("click", function () {
                var x = $(this).attr("checked");
                recursive($(this), x);
                if (x) recursiveUp($(this));
            });
            $("#t-permission").treeview({ persist: "cookie", cookieId: "t-permission" });
        });

    </script>
</head>
<body>
    <div class="wrap">
        <form id="form1" runat="server">
        <div class="h_line">
            <a href="javascript://;" id="_h2" class="h_n">
                <asp:Label ID="lblInfo" runat="server" Text="角色信息"></asp:Label></a>
        </div>
        <div class="c" id="d_h2">
            <table class="det_t">
                <tr>
                    <td class="th w_p15">
                        <asp:Label ID="lblName" runat="server" Text="名称"></asp:Label><span class="red">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRoleName" MaxLength="45" CssClass="n_txt w_p99" runat="server"></asp:TextBox>
                    </td>
                    <td class="th w_p15">
                        <asp:Label ID="lblSort" runat="server" Text="排序"></asp:Label><span class="red">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSort" MaxLength="9" CssClass="n_txt w_p99" runat="server" onkeyup="this.value=this.value.replace(/[^\d]+?/g,'')"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="th">
                        <asp:Label ID="lblDisable" runat="server" Text="禁用(选中表示禁用)"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:CheckBox ID="cbxIsActive" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="th">
                        <asp:Label ID="lblRemark" runat="server" Text="备注"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:TextBox CssClass="n_txt w_p99" TextMode="MultiLine" MaxLength="350" ID="txtDes"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="th">
                        <asp:Label ID="lblRight" runat="server" Text="角色权限"></asp:Label><span class="red">*</span>
                    </td>
                    <td colspan="3">
                        <div class="tree_container">
                            <%if (!bIsAdministrator)
                              {%>
                            <%=BuildPermissionTree("t-permission")%>
                            <%} %>
                        </div>
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
                <asp:Button ID="buttonOK" runat="server" Text="确认" OnClick="buttonOK_Click" CssClass="n_btn w_60" />
                <asp:Button ID="btnCancel" runat="server" CssClass="n_btn w_60" Text="取消" OnClick="btnCancel_Click" />
            </div>
            <input type="hidden" id="txtId" runat="server" />
        </div>
        </form>
    </div>
</body>
</html>

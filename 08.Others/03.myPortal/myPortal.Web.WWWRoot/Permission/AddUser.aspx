<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="myPortal.Web.WWWRoot.Permission.AddUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>用户管理</title>
    <meta http-equiv="content-type" content="text/html;charset=utf-8" />
    <link href="../Css/common.css" type="text/css" rel="stylesheet" />
    <link href="../Css/redmond/jquery-ui-1.8.23.custom.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.8.1.min.js" type="text/javascript"></script>
    <script src="../js/jquery-ui-1.8.23.custom.min.js" type="text/javascript"></script>
    <script src="../js/jquery.cookie.js" type="text/javascript"></script>
    <script src="../js/Common.js" type="text/javascript"></script>
    <script src="../js/jQuery.common.js" type="text/javascript"></script>
    <script type="text/javascript">
        var currOrg;
        function BindbtnDeleteCurrClick() {
            $("input[name='btnDeleteCurr']").unbind("click");
            $("input[name='btnDeleteCurr']").click(function () {
                if (confirm('确定要删除当前数据吗?')) {
                    var clickRow = $(this).parents("tr")[0];
                    $(clickRow).remove();
                }
            });
        }

        function Bindtxtriddblclick() {
            $("input[name='btnQueryRole']").unbind("click");
            $("input[name='btnQueryRole']").click(function () {
                currOrg = $(this).parent().parent().find("input[name='txtrid']");
                $("#RoleList").load("../Handlers/AddUserRoleList.aspx #RoleList",
                function () {
                    var id = $(currOrg).attr("title");
                    $(":radio[name='radio_role']").each(function () { $(this).attr("checked", false) });
                    $("#radio_role_" + id).attr("checked", "checked");
                });
                $("#RoleList").dialog("open");
            });
        }

        $(function () {
            headline();
            listhover();

            BindbtnDeleteCurrClick();
            Bindtxtriddblclick();

            $("#ddlCompany").change(function () {
                $("#orgRoleList tr").each(function (i) {
                    var chk = $(this).find("input[type='checkbox'][name='cb_iid']");
                    if (chk.attr('type') == "checkbox")
                        $(this).remove();
                });
            });

            var row = "<tr class='line'>" +
            "<td class='center w_20'><input type='checkbox' name='cb_iid' /></td>" +
            "<td class='center'> " +
                "<table class='buttonedit'>" +
                    "<tr>" +
                        "<td>" +
                            "<input type='text' name='txtrid' class='n_txt w_p99 center' readonly='readonly' />" +
                        "</td>" +
                        "<td class=' w_20'>" +
                            "<input name='btnQueryRole' type='button' class='searchbtn w_20' />" +
                        "</td>" +
                    "</tr>" +
                "</table>" +
            "</td>" +
            "<td class='center w_60'><input name='btnDeleteCurr' type='button' value='删除' class='n_btn w_60'/></td>" +
            "</tr>";


            $("#btnAddOrgRole").click(function () {
                var rownum = $("#orgRoleList tr[class='line']").length - 1;
                $(row).insertAfter($("#orgRoleList tr[class='line']:eq(" + rownum + ")"));

                BindbtnDeleteCurrClick();
                Bindtxtriddblclick();
                listhover();
            });

            $("#btnDeleteOrgRole").click(function () {
                if (confirm('确定要删除角色？')) {
                    $("#orgRoleList tr").each(function (i) {
                        var chk = $(this).find("input[type='checkbox'][name='cb_iid']");
                        if (chk.attr("checked")) {
                            $(this).remove();
                        }
                    });
                }
            });

            $("#RoleList").dialog({
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
                        var value = "";
                        var title = "";
                        if ($(":radio[name='radio_role']:checked").length > 0) {
                            title = $(":radio[name='radio_role']:checked").val();
                            value = $(":radio[name='radio_role']:checked").attr("title");
                        }
                        else {
                            value = "";
                            title = ""
                        }
                        $(currOrg).val(value);
                        $(currOrg).attr("title", title);
                        $(this).dialog("close");
                    },
                    "清空": function () {
                        $(currOrg).val("");
                        $(currOrg).attr("title", "");
                        $(this).dialog("close");
                    },
                    "取消": function () {
                        $(this).dialog("close");
                    }
                }
            });
        });

        function GetUor() {
            if ($.trim($("#txtUserNo").val()) == "") {
                alert("请输入用户名.");
                $("#txtUserNo").focus();
                return false;
            }

            if ($.trim($("#txtUserName").val()) == "") {
                alert("请输入用户姓名.");
                $("#txtUserName").focus();
                return false;
            }

            if ($.trim($("#ddlCompany").val()) == "-1") {
                alert("请选择公司.");
                $("#ddlCompany").focus();
                return false;
            }
            if ($.trim($("#txtEmail").val()) == "") {
                alert("请输入邮箱.");
                $("#txtEmail").focus();
                return false;
            }

            var myreg = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;

            if (!myreg.test($("#txtEmail").val())) {
                alert("邮箱格式错误.");
                $("#txtEmail").focus();
                return false;
            }

            //取角色列表
            result = "";
            success = true;
            $("input[name='txtrid']").each(function () {
                if ($(this).attr("title") == null || $(this).attr("title").length == 0) {
                    alert("请配置角色.");
                    success = false;
                    return false;
                }
                else
                    success = true;
                if (success)
                    result = result + ',' + $(this).attr("title");
            });
            if (!success) return false;
            result = result.substring(1);
            $("#txtRoles").val(result);

            return true;
        }
    </script>
</head>
<body>
    <div class="wrap">
        <form id="form1" runat="server">
        <div class="h_line">
            <a href="javascript://;" id="_h2" class="h_n">
                <asp:Label ID="lblUserManagement" runat="server" Text="用户管理"></asp:Label></a>
        </div>
        <div class="c" id="d_h2">
            <table class="det_t">
                <tr>
                    <td class="FieldEditTitle w_p15">
                        <asp:Label ID="lblUserNo" runat="server" Text="用户名"></asp:Label><span class="red">*</span>
                    </td>
                    <td class="w_p35">
                        <asp:TextBox ID="txtUserNo" MaxLength="45" CssClass="n_txt w_p98" runat="server"></asp:TextBox>
                    </td>
                    <td class="FieldEditTitle w_p15">
                        <asp:Label ID="lblUserName" runat="server" Text="姓名"></asp:Label><span class="red">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserName" MaxLength="45" CssClass="n_txt w_p98" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="FieldEditTitle">
                        <asp:Label ID="lblDisabled" runat="server" Text="禁用(选中表示禁用)"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="cbxUsable" runat="server" />
                    </td>
                    <td class="FieldEditTitle ">
                        <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label><span class="red">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" MaxLength="90" CssClass="n_txt w_p98" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="FieldEditTitle ">
                        <asp:Label ID="lblRemark" runat="server" Text="备注"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtRemark" MaxLength="350" CssClass="n_txt w_p99" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear" />
        <div class="h_line">
            <a href="javascript://;" id="_userOrgRole" class="h_n">
                <asp:Label ID="lblUserOrgRole" runat="server" Text="用户角色管理"></asp:Label></a>
        </div>
        <div class="c" id="d_userOrgRole">
            <table class="c_t" id="orgRoleList">
                <tr class="line">
                    <td class="th w_20">
                    </td>
                    <td class="th">
                        <asp:Label ID="lblRole" runat="server" Text="角色名称"></asp:Label>
                    </td>
                    <td class="th w_60">
                        <asp:Label ID="lblOperate" runat="server" Text="操作"></asp:Label>
                    </td>
                </tr>
                <asp:Repeater ID="repOrgRoles" runat="server">
                    <ItemTemplate>
                        <tr class="line">
                            <td class="center w_20">
                                <input type="checkbox" name="cb_iid" />
                            </td>
                            <td class="center ">
                                <table class="buttonedit">
                                    <tr>
                                        <td>
                                            <input type="text" name="txtrid" readonly="readonly" class="n_txt w_p99 center" value='<%# Eval("iRoleId") %>.<%# myPortal.Web.DicHelper.CalcRole(Eval("iRoleId")) %>'
                                                title='<%# Eval("iRoleId") %>' />
                                        </td>
                                        <td class="w_20">
                                            <%if (!bIsSystemUser)
                                              {%>
                                            <input name="btnQueryRole" type="button" class="searchbtn w_20" />
                                            <%} %>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td class="center w_60">
                                <%if (!bIsSystemUser)
                                  {%>
                                <input name="btnDeleteCurr" type="button" value="删除" class="n_btn w_60" />
                                <%} %>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <input id="txtOrgs" type="hidden" runat="server" />
            <input id="txtRoles" type="hidden" runat="server" />
            <div class="f_r m_10">
                <input type="button" class="n_btn w_60" value="全选" onclick="javascript:$('input[name=cb_iid]').selectAll();" />
                <input type="button" class="n_btn w_60" value="反选" onclick="javascript:$('input[name=cb_iid]').reverseAll();" />
                <%if (!bIsSystemUser)
                  {%>
                <input type="button" id="btnAddOrgRole" class="n_btn w_100" value="添加行" />
                <input type="button" id="btnDeleteOrgRole" class="n_btn w_100" value="删除" />
                <%} %>
            </div>
        </div>
        <div id="RoleList" title="选择角色" style="display: none; height: 200px;">
        </div>
        <div class="clear" />
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
            <asp:Button ID="buttonOK" runat="server" Text="保存用户" OnClick="buttonOK_Click" CssClass="n_btn w_80"
                OnClientClick="return GetUor();" />
            <asp:Button ID="btnCancel" runat="server" Text="取消" CssClass="n_btn w_80" OnClick="btnCancel_Click" />
        </div>
        </form>
    </div>
</body>
</html>

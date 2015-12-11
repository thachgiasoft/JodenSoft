<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserManage.aspx.cs" Inherits="myPortal.Web.WWWRoot.Permission.UserManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>用户管理</title>
    <meta http-equiv="content-type" content="text/html;charset=utf-8" />
    <link href="../Css/common.css" type="text/css" rel="stylesheet" />
    <script src="../js/jquery-1.8.1.min.js" type="text/javascript"></script>
    <script src="../js/Common.js" type="text/javascript"></script>
    <script src="../js/jQuery.common.js" type="text/javascript"></script>
    <script type="text/javascript">
        function confirm_delete(id) {
            if (confirm('确定要禁用选中的数据吗?')) {
                $("input[name='cb_id']").attr("checked", false);
                $("input[value='" + id + "']").attr("checked", true);
                form1.submit();
            }
        }
        function confirm_deleteSelected() {
            var count = 0;
            $("input[name='cb_id']").each(function () {
                if (this.checked)
                    count += 1;
            });
            if (count > 0) {
                return confirm('确定要禁用选中的数据吗?');
            }
            else {
                alert("请选择要禁用的数据.");
                return false;
            }
        }
        function butReset() {
            $("#txtUserNo").val("");
            $("#txtUserName").val("");
        }
        $(function () {
            headline();
            listhover();
        });
    </script>
</head>
<body>
    <div class="wrap">
        <form id="form1" runat="server">
        <div class="h_line">
            <a href="javascript://;" id="_h2" class="h_n">
                <asp:Label ID="lblQueryUser" runat="server" Text="用户查询"></asp:Label></a>
        </div>
        <div class="c" id="d_h2">
            <table class="det_t">
                <tr>
                    <td class="th w_p15">
                        <asp:Label ID="lblqUserNo" runat="server" Text="用户名"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserNo" runat="server" class="n_txt w_p99"></asp:TextBox>
                    </td>
                    <td class="th w_p15">
                        <asp:Label ID="lblqUserName" runat="server" Text="用户姓名"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server" class="n_txt w_p99"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <div class="f_r m_10">
                <input type="button" class="n_btn w_60" value="重置" onclick="butReset()" />
                <asp:Button ID="bntQuery" class="n_btn w_60" runat="server" Text="查询" OnClick="bntQuery_Click" />
            </div>
        </div>
        <div class="clear" />
        <div class="h_line">
            <a href="javascript://;" id="_h1" class="h_n">
                <asp:Label ID="lblInfo" runat="server" Text="用户信息"></asp:Label></a>
        </div>
        <div class="c" id="d_h1">
            <div>
                <table class="cus_t">
                    <tr>
                        <td class="th">
                            <asp:Label ID="lblCheck" runat="server" Text="选择"></asp:Label>
                        </td>
                        <td class="th">
                            <asp:Label ID="lblIden" runat="server" Text="序号"></asp:Label>
                        </td>
                        <td class="th">
                            <asp:Label ID="lblUserNo" runat="server" Text="用户名"></asp:Label>
                        </td>
                        <td class="th">
                            <asp:Label ID="lblUserName" runat="server" Text="用户姓名"></asp:Label>
                        </td>
                        <td class="th">
                            <asp:Label ID="lblEmail" runat="server" Text="邮箱"></asp:Label>
                        </td>
                        <td class="th">
                            <asp:Label ID="lblDisable" runat="server" Text="禁用"></asp:Label>
                        </td>
                        <td class="th">
                            <asp:Label ID="Label3" runat="server" Text="系统用户"></asp:Label>
                        </td>
                        <td class="th">
                            <asp:Label ID="Label2" runat="server" Text="备注"></asp:Label>
                        </td>
                        <td class="th">
                            <asp:Label ID="Label1" runat="server" Text="操作"></asp:Label>
                        </td>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="center">
                                    <input type="checkbox" name="cb_id" value='<%# Eval("iIden") %>' />
                                </td>
                                <td class="center">
                                    <%#Eval("iIden") %>
                                </td>
                                <td class="center">
                                    <%#Eval("sUserNo")%>
                                </td>
                                <td class="center">
                                    <%#Eval("sUserName")%>
                                </td>
                                <td class="center">
                                    <%#Eval("sEmail")%>
                                </td>
                                <td class="center">
                                    <%# Convert.ToBoolean(Eval("bUsable")) ? "" : "禁用"%>
                                </td>
                                <td class="center">
                                    <%# Convert.ToBoolean(Eval("bIsSystem")) ? "是" : "否"%>
                                </td>
                                <td>
                                    <%#Eval("sRemark")%>
                                </td>
                                <td>
                                    <a href="javascript://" class="imgbtn_mod" title="" onclick='javascript:location.href=&#039;AddUser.aspx?Action=m&amp;iUserId=<%# Eval("iIden") %>&#039;;return false;'>
                                    </a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <ctt:PageControl ID="MyPageControl" runat="server" OnPageChanged="MyPageControl_PageChanged" />
            </div>
        </div>
        <div class="clear">
        </div>
        <div>
            <% if (hasError)
               { %>
            <div class="err_tips m_10">
                <p>
                    操作发生错误!
                </p>
                <p>
                </p>
                <%=errorMsg %>
            </div>
            <%} %>
        </div>
        <div class="clear">
        </div>
        <div class="f_r m_10">
            <input type="button" class="n_btn w_60" value="全选" onclick="javascript:$('input[name=cb_id]').selectAll();" />
            <input type="button" class="n_btn w_60" value="反选" onclick="javascript:$('input[name=cb_id]').reverseAll();" />
            <input type="button" onclick="javascript:location.href='AddUser.aspx';" value="添加"
                class="n_btn w_60" />
            <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="禁用" OnClientClick="return confirm_deleteSelected();"
                CssClass="n_btn w_60" />
            <input type="button" class="n_btn w_60" value="刷新" onclick="javascript:location.reload();" />
        </div>
        </form>
    </div>
</body>
</html>

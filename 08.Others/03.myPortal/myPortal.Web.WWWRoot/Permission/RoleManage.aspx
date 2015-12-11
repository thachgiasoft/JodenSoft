<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleManage.aspx.cs" Inherits="myPortal.Web.WWWRoot.Permission.RoleManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>角色管理</title>
    <meta http-equiv="content-type" content="text/html;charset=utf-8" />
    <link href="../Css/common.css" type="text/css" rel="stylesheet" />
    <script src="../js/jquery-1.8.1.min.js" type="text/javascript"></script>
    <script src="../js/Common.js" type="text/javascript"></script>
    <script src="../js/jQuery.common.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {
            headline();
            listhover();
        });

        function batch_delete() {
            if ($("input:checked").length <= 0) {
                alert("请选择要禁用的数据.");
                return false;
            }

            return confirm('确定要禁用选中的数据吗?');
        }

        function butReset() {
            $("#txtRoleName").val("");
            $("#ddlCompany").val("-1");
        }
    </script>
</head>
<body>
    <div class="wrap">
        <form id="form1" runat="server">
        <div class="h_line">
            <a href="javascript://;" id="_h2" class="h_n">
                <asp:Label ID="lblQueryRole" runat="server" Text="角色查询"></asp:Label></a>
        </div>
        <div class="c" id="d_h2">
            <table class="det_t">
                <tr>
                    <td class="th w_p15">
                        <asp:Label ID="lblRoleName" runat="server" Text="角色名"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRoleName" runat="server" class="n_txt w_p99"></asp:TextBox>
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
                <asp:Label ID="lflInfo" runat="server" Text="角色信息"></asp:Label></a>
        </div>
        <div class="c" id="d_h1">
            <div>
                <table class="cus_t">
                    <tr>
                        <td class="th">
                            <asp:Label ID="lblCheck" runat="server" Text="选择"></asp:Label>
                        </td>
                        <td class="th">
                            <asp:Label ID="lblIden" runat="server" Text="角色编号"></asp:Label>
                        </td>
                        <td class="th">
                            <asp:Label ID="lblRoleName2" runat="server" Text="角色名称"></asp:Label>
                        </td>
                        <td class="th">
                            <asp:Label ID="lblRemark" runat="server" Text="角色说明"></asp:Label>
                        </td>
                        <td class="th">
                            <asp:Label ID="lblSort" runat="server" Text="角色排序"></asp:Label>
                        </td>
                        <td class="th">
                            <asp:Label ID="Label1" runat="server" Text="内置管理员"></asp:Label>
                        </td>
                        <td class="th">
                            <asp:Label ID="lblDisable" runat="server" Text="禁用"></asp:Label>
                        </td>
                        <td class="th w_60">
                            <asp:Label ID="lblOperate" runat="server" Text="操作"></asp:Label>
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
                                    <%#Eval("sName")%>
                                </td>
                                <td>
                                    <%#Eval("sRemark")%>
                                </td>
                                <td class="center">
                                    <%#Eval("iSort")%>
                                </td>
                                <td class="center">
                                    <%#Convert.ToBoolean(Eval("bIsAdministrator")) ? "是" : "否"%>
                                </td>
                                <td class="center">
                                    <%#Convert.ToBoolean(Eval("IsActive")) ? "" : "禁用"%>
                                </td>
                                <td>
                                    <a href='javascript://' class='imgbtn_mod' title='' onclick='goto_url(&#039;addRole.aspx?Action=m&amp;iRoleId=<%# Eval("iIden") %>&#039;);'>
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
                    操作发生错误!</p>
                <%=errorMsg %>
            </div>
            <%} %>
        </div>
        <div class="clear">
        </div>
        <div class="f_r m_10">
            <input type="button" class="n_btn w_60" value="全选" onclick="javascript:$('input[name=cb_id]').selectAll();" />
            <input type="button" class="n_btn w_60" value="反选" onclick="javascript:$('input[name=cb_id]').reverseAll();" />
            <input type="button" onclick="javascript:location.href='addRole.aspx';" value="添加"
                class="n_btn w_60" />
            <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="禁用" OnClientClick="javascript:return batch_delete();"
                CssClass="n_btn w_60" />
            <asp:Button ID="btnRefresh" CssClass="n_btn w_60" Text="刷新" runat="server" OnClick="btnRefresh_Click" />
        </div>
        </form>
    </div>
</body>
</html>

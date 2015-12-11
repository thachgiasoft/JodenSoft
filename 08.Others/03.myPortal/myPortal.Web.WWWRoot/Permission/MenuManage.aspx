<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuManage.aspx.cs" Inherits="myPortal.Web.WWWRoot.Permission.MenuManage"
       %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>菜单管理</title>
    <link href="../Css/common.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.8.1.min.js" type="text/javascript"></script>
    <script src="../js/Common.js" type="text/javascript"></script>
    <script src="../js/jQuery.common.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function confirm_delete(id) {
            if (confirm('确定要删除选中的数据吗?')) {
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
                return confirm('确定要删除选中的数据吗?');
            }
            else {
                alert("请选择要删除的数据.");
                return false;
            }
        }

        function GotoAddMenu() {
            location.href = 'AddMenu.aspx?iParentId=<%=iParentId %>';
        }

        $(document).ready(function () {
            headline();
            listhover();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table style="width: 100%;">
        <tr>
            <td style="width: 25%; vertical-align: top;">
                <div style="width: 100%; float: left;">
                    <div style="margin-top: 10px; margin-left: 5px; margin-right: 5px;">
                        <table class="k_t">
                            <tr>
                                <td class="k_h">
                                    <asp:Label ID="lblMenuTree" runat="server" Text="菜单树" ></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div id="divtree" style="background-color: White; overflow: auto; height: <%=WorkspaceHeight %>px;">
                                        <asp:TreeView ID="treeMenus" runat="server" Width="100%" ShowLines="True" >
                                        </asp:TreeView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
            <td style="width: 75%; vertical-align: top;">
                <div style="width: 100%; float: right;">
                    <div class="h_line">
                        <a href="javascript://;" id="_h1" class="h_n">
                            <%=path%>
                        </a>
                    </div>
                    <div class="c" id="d_h1">
                        <div class="f_r m_10">
                            <input type="button" class="n_btn w_60" value="全选"
                                onclick="javascript:$('input[name=cb_id]').selectAll();" />
                            <input type="button" class="n_btn w_60" value="反选"
                                onclick="javascript:$('input[name=cb_id]').reverseAll();" />
                            <input type="button" onclick="javascript:GotoAddMenu();" value="添加"
                                class="n_btn w_60" />
                            <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="删除" OnClientClick="return confirm_deleteSelected();"
                                CssClass="n_btn w_60"  />
                            <input type="button" class="n_btn w_60" value="刷新"
                                onclick="javascript:location.reload();" />
                            <input type="button" class="n_btn w_80" value="顶级菜单"
                                onclick="javascript:location.href='MenuManage.aspx?iParentId=0';" />
                        </div>
                        <table class="cus_t">
                            <tr>
                                <td class="th w_20">
                                </td>
                                <td class="th w_60">
                                    <asp:Label ID="lblIden" runat="server" Text="序号" ></asp:Label>
                                </td>
                                <td class="th">
                                    <asp:Label ID="lblName" runat="server" Text="名称" ></asp:Label>
                                </td>
         
                                <td class="th w_40">
                                    <asp:Label ID="lblSort" runat="server" Text="排序" ></asp:Label>
                                </td>
                                <td class="th">
                                    <asp:Label ID="lblURL" runat="server" Text="URL" ></asp:Label>
                                </td>
                                <td class="th">
                                    <asp:Label ID="lblMenuLevel" runat="server" Text="菜单级别" ></asp:Label>
                                </td>
                                <td class="th">
                                    <asp:Label ID="lblOpenMode" runat="server" Text="打开方式" ></asp:Label>
                                </td>
                                <td class="th w_60">
                                    <asp:Label ID="lblOperate" runat="server" Text="操作" ></asp:Label>
                                </td>
                            </tr>
                            <asp:Repeater ID="repMenus" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td class="center">
                                            <input type="checkbox" name="cb_id" value='<%# Eval("iIden") %>' />
                                        </td>
                                        <td class="center ">
                                            <%#Eval("iIden")%>
                                        </td>
                                        <td class="center ">
                                            <%#Eval("sName") %>
                                        </td>
                  
                                        <td class="center ">
                                            <%#Eval("iSort") %>
                                        </td>
                                        <td>
                                            <%#Eval("sURL") %>
                                        </td>
                                        <td class="center ">
                                            <%#myPortal.Foundation.Utils.EnumHelper.GetEnumDescription<myPortal.Foundation.MenuLevel>(Eval("iLevel")) %>
                                        </td>
                                        <td class="center ">
                                            <%#myPortal.Foundation.Utils.EnumHelper.GetEnumDescription<myPortal.Foundation.MenuOpenMode>( Eval("iOpenMode")) %>
                                        </td>
                                        <td>
                                            <a href="javascript://" class="imgbtn_del" title="" onclick='javascript:confirm_delete(<%# Eval("iIden") %>);'>
                                            </a><a href="javascript://" class="imgbtn_mod" title="" onclick='javascript:location.href="AddMenu.aspx?Action=m&iMenuId=<%# Eval("iIden") %>&iParentId=<%=iParentId %>";return false;'>
                                            </a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    <div>
                        <% if (hasError)
                           { %>
                        <div class="err_tips m_10">
                            <p>
                                操作发生错误!
                            </p>
                            <%=errorMsg %>
                        </div>
                        <%} %>
                    </div>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

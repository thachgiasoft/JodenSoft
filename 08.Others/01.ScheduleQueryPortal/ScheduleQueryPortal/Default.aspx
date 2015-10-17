<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ScheduleQueryPortal.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>进度查询配置</title>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jQuery.common.js" type="text/javascript"></script>
    <script src="Scripts/Common.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            headline();
            listhover();
        });

        function confirm_deleteSelected() {
            var count = 0;
            $("input[name='cb_bid']").each(function () {
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
        
    </script>
</head>
<body>
    <div class="wrap">
        <form id="form1" runat="server">
        <h1>
            进度查询配置</h1>
        <div class="h_line">
            <a href="javascript://;" id="_h1" class="h_n">进度查询列表</a>
        </div>
        <div class="c" id="d_h1">
            <div>
                <table class="cus_t">
                    <tr>
                        <td class="th">
                            选择
                        </td>
                        <td class="th">
                            序号
                        </td>
                        <td class="th">
                            查询名称
                        </td>
                        <td class="th">
                            子查询列表
                        </td>
                        <td class="th">
                            翻页时间间隔
                        </td>
                        <td class="th">
                            操作
                        </td>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="center middle w_40">
                                    <input type="checkbox" name="cb_bid" value='<%# Eval("iIden") %>' />
                                </td>
                                <td class="center middle w_60">
                                    <%#Eval("iIden") %>
                                </td>
                                <td class="middle">
                                    <a href='ScheduleViewer.aspx?Iden=<%#Eval("iIden") %>'>
                                        <%#Eval("sName")%></a>
                                </td>
                                <td class="middle">
                                    <%#Eval("sChildName")%>
                                </td>
                                <td class="center middle w_150">
                                    <%#Eval("iTimeInterval")%>&nbsp;秒
                                </td>
                                <td class="center middle w_160">
                                    <a href='AddScheduleQuery.aspx?Action=m&Iden=<%#Eval("iIden") %>' title="修改进度查询">修改进度查询</a>
                                    &nbsp; <a href='AddScheduleQueryHdr.aspx?QueryId=<%#Eval("iIden") %>' title="添加子查询">
                                        添加子查询</a>
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
                        操作发生错误!</p>
                    <%=errorMsg %>
                </div>
                <%} %>
            </div>
            <div class="f_r m_10">
                <input type="button" class="n_btn w_60" value="全选" onclick="javascript:$('input[name=cb_bid]').selectAll();" />
                <input type="button" class="n_btn w_60" value="反选" onclick="javascript:$('input[name=cb_bid]').reverseAll();" />
                <input type="button" onclick="javascript:location.href='AddScheduleQuery.aspx';"
                    value="添加" class="n_btn w_60" />
                <asp:Button ID="btnDelete" runat="server" Text="删除" OnClientClick="javascript:return confirm_deleteSelected();"
                    CssClass="n_btn w_60" OnClick="btnDelete_Click" />
            </div>
        </div>
        </form>
    </div>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BulletinManage.aspx.cs"
    Inherits="myPortal.Web.WWWRoot.Bulletin.BulletinManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>公告管理</title>
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
    <link href="../Css/common.css" type="text/css" rel="stylesheet" />
    <link href="../Css/redmond/jquery-ui-1.8.23.custom.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../js/jquery-1.8.1.min.js"></script>
    <script type="text/javascript" src="../js/jquery-ui-1.8.23.custom.min.js"></script>
    <script src="../js/Common.js" type="text/javascript"></script>
    <script src="../js/jQuery.common.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            headline();
            listhover();

            $("#txtDateStart").ShowDatePicker();
            $("#txtDateEnd").ShowDatePicker();
        });

        function confirm_delete(id) {
            if (confirm('确定要删除选中的数据吗?')) {
                $("input[name='cb_bid']").attr("checked", false);
                $("input[value='" + id + "']").attr("checked", true);
                form1.submit();
            }
        }

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
        <div class="h_line">
            <a href="javascript://;" id="_h2" class="h_n">
                <asp:Label ID="lblNoticeQuery" runat="server" Text="公告查询"></asp:Label></a>
        </div>
        <div class="c" id="d_h2">
            <table class="det_t">
                <tr>
                    <td class="th w_p15">
                        <asp:Label ID="lblPublishedTime" runat="server" Text="发布时间"></asp:Label>
                    </td>
                    <td>
                        <input type="text" runat="Server" class="date_txt" id="txtDateStart" />&nbsp; ——
                        <input type="text" runat="Server" class="date_txt" id="txtDateEnd" />&nbsp;
                        <input type="hidden" runat="Server" name="st" id="st" value="" />
                        <input type="hidden" runat="Server" name="et" id="et" value="" />
                    </td>
                </tr>
                <tr>
                    <td class="th w_p15">
                        <asp:Label ID="lblNoticeTitle" runat="server" Text="公告标题"></asp:Label>
                    </td>
                    <td>
                        <input type="text" runat="Server" name="txtQuery" id="txtQuery" class="n_txt w_p98" />
                    </td>
                </tr>
            </table>
            <div class="f_r m_10">
                <asp:Button ID="btnQuery" runat="server" Text="查询" CssClass="n_btn w_60" OnClick="btnQuery_Click" />
            </div>
        </div>
        <div class="clear" />
        <div class="h_line">
            <a href="javascript://;" id="_h1" class="h_n">
                <asp:Label ID="lblNoticeInfo" runat="server" Text="公告信息"></asp:Label></a>
        </div>
        <div class="c" id="d_h1">
            <div class="pager">
                <%=pageStr %></div>
            <asp:DataGrid ID="gridBulletin" GridLines="None" CssClass="cus_t" AllowPaging="True"
                runat="server" AutoGenerateColumns="False">
                <PagerStyle Mode="NumericPages" Visible="false" />
                <Columns>
                    <asp:TemplateColumn HeaderText="" HeaderStyle-CssClass="th w_20">
                        <ItemTemplate>
                            <input type="checkbox" name="cb_bid" value='<%# Eval("iIden") %>' />
                        </ItemTemplate>
                        <HeaderStyle CssClass="th w_20"></HeaderStyle>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="序号" HeaderStyle-CssClass="th w_60" ItemStyle-CssClass="center">
                        <ItemTemplate>
                            <%#Eval("iIden") %>
                        </ItemTemplate>
                        <HeaderStyle CssClass="th w_60"></HeaderStyle>
                        <ItemStyle CssClass="center"></ItemStyle>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="标题" HeaderStyle-CssClass="th" ItemStyle-CssClass="left">
                        <ItemTemplate>
                            <%#Eval("sTitle") %>
                        </ItemTemplate>
                        <HeaderStyle CssClass="th"></HeaderStyle>
                        <ItemStyle CssClass="left"></ItemStyle>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="发布时间" HeaderStyle-CssClass="th w_110" ItemStyle-CssClass="center">
                        <ItemTemplate>
                            <%#Eval("tCreateTime") %>
                        </ItemTemplate>
                        <HeaderStyle CssClass="th w_110"></HeaderStyle>
                        <ItemStyle CssClass="center"></ItemStyle>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="生效时间" HeaderStyle-CssClass="th w_110" ItemStyle-CssClass="center">
                        <ItemTemplate>
                            <%#Eval("tStartTime") %>
                        </ItemTemplate>
                        <HeaderStyle CssClass="th w_110"></HeaderStyle>
                        <ItemStyle CssClass="center"></ItemStyle>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="失效时间" HeaderStyle-CssClass="th w_110" ItemStyle-CssClass="center">
                        <ItemTemplate>
                            <%#Eval("tEndTime") %>
                        </ItemTemplate>
                        <HeaderStyle CssClass="th w_110"></HeaderStyle>
                        <ItemStyle CssClass="center"></ItemStyle>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="操作" HeaderStyle-CssClass="th w_60" ItemStyle-CssClass="center">
                        <ItemTemplate>
                            <a href="javascript://" class="imgbtn_del" title="" onclick='javascript:confirm_delete(<%# Eval("iIden") %>);'>
                                <asp:Label ID="lblDeleteNotice" runat="server" Text="删除"></asp:Label></a>
                            <a href="javascript://" class="imgbtn_mod" title="" onclick='javascript:location.href=&#039;addbulletin.aspx?Action=m&amp;iBulletinId=<%# Eval("iIden") %>&#039;;return false;'>
                                <asp:Label ID="lblUpdateNotice" runat="server" Text="修改"></asp:Label></a>
                        </ItemTemplate>
                        <HeaderStyle CssClass="th w_60"></HeaderStyle>
                        <ItemStyle CssClass="center"></ItemStyle>
                    </asp:TemplateColumn>
                </Columns>
            </asp:DataGrid>
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
                <input type="button" onclick="javascript:location.href='addbulletin.aspx';" value="添加"
                    class="n_btn w_60" />
                <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="删除" OnClientClick="javascript:return confirm_deleteSelected();"
                    CssClass="n_btn w_60" />
                <input type="button" class="n_btn w_60" value="刷新" onclick="javascript:location.reload();" />
            </div>
        </div>
        </form>
    </div>
</body>
</html>

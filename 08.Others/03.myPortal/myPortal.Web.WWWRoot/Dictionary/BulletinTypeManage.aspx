<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BulletinTypeManage.aspx.cs"
    Inherits="myPortal.Web.WWWRoot.Dictionary.BulletinTypeManage"  
     %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>公告类型管理</title>
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
    <link href="../Css/common.css" type="text/css" rel="stylesheet" />
    <link href="../Css/redmond/jquery-ui-1.8.23.custom.css" type="text/css" rel="stylesheet" />
    <script src="../js/jquery-1.8.1.min.js" type="text/javascript"></script>
    <script src="../js/jquery-ui-1.8.23.custom.min.js" type="text/javascript"></script>
    <script src="../js/Common.js" type="text/javascript"></script>
    <script src="../js/jQuery.common.js" type="text/javascript"></script>
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
                return confirm('确定要禁用选中的数据吗?');
            }
            else {
                alert("请选择要禁用的数据.");
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
                <asp:Label ID="lblNoticeTypeQuery" runat="server" Text="公告类型查询" ></asp:Label></a>
        </div>
        <div class="c" id="d_h2">
            <table class="det_t">
                <tr>
                    <td class=" th w_p15">
                        <asp:Label ID="lblNoticeType" runat="server" Text="公告类型" ></asp:Label>
                    </td>
                    <td>
                        <input type="text" name="t" id="txtQuery" class="n_txt w_p99" runat="server" />
                    </td>
                </tr>
            </table>
            <div class="f_r m_10">
                <asp:Button ID="btnQuery" runat="server" Text="查询"
                    CssClass="n_btn w_60" OnClick="btnQuery_Click"  />
            </div>
        </div>
        <div class="clear" />
        <div class="h_line">
            <a href="javascript://;" id="_h1" class="h_n">
                <asp:Label ID="lblNoticeTypeList" runat="server" Text="公告类型列表" ></asp:Label></a>
        </div>
        <div class="c" id="d_h1">
            <div class="pager">
                <%=pageStr %></div>
            <asp:DataGrid ID="grid" GridLines="None" CssClass="cus_t" AllowPaging="True" runat="server"
                AutoGenerateColumns="False" >
                <PagerStyle Mode="NumericPages" Visible="false" />
                <Columns>
                    <asp:TemplateColumn HeaderText="" HeaderStyle-CssClass="th w_20">
                        <ItemTemplate>
                            <input type="checkbox" name="cb_bid" value='<%# Eval("iIden") %>' />
                        </ItemTemplate>
                        <HeaderStyle CssClass="th w_20"></HeaderStyle>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="序号" HeaderStyle-CssClass="th w_60"
                        ItemStyle-CssClass="center">
                        <ItemTemplate>
                            <%#Eval("iIden") %>
                        </ItemTemplate>
                        <HeaderStyle CssClass="th w_60"></HeaderStyle>
                        <ItemStyle CssClass="center"></ItemStyle>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="公告类型" HeaderStyle-CssClass="th " ItemStyle-CssClass="center">
                        <ItemTemplate>
                            <%#Eval("sName")%>
                        </ItemTemplate>
                        <HeaderStyle CssClass="th "></HeaderStyle>
                        <ItemStyle CssClass="center"></ItemStyle>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="排序" HeaderStyle-CssClass="th "
                        ItemStyle-CssClass="center">
                        <ItemTemplate>
                            <%#Eval("iSort")%>
                        </ItemTemplate>
                        <HeaderStyle CssClass="th "></HeaderStyle>
                        <ItemStyle CssClass="center"></ItemStyle>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="是否禁用?"
                        HeaderStyle-CssClass="th " ItemStyle-CssClass="center">
                        <ItemTemplate>
                            <%#Convert.ToBoolean(Eval("bUsable")) ? "" : "禁用"%>
                        </ItemTemplate>
                        <HeaderStyle CssClass="th "></HeaderStyle>
                        <ItemStyle CssClass="center"></ItemStyle>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="操作"
                        HeaderStyle-CssClass="th w_60" ItemStyle-CssClass="center">
                        <ItemTemplate>
                            <a href="javascript://" class="imgbtn_mod" title="修改" onclick='javascript:location.href=&#039;AddBulletinType.aspx?Action=m&amp;iIden=<%# Eval("iIden") %>&#039;;return false;'>
                                <asp:Label ID="lblTableButtonModify" runat="server" Text="修改" ></asp:Label></a>
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
                <input type="button" class="n_btn w_60" value="全选"
                    onclick="javascript:$('input[name=cb_bid]').selectAll();" />
                <input type="button" class="n_btn w_60" value="反选"
                    onclick="javascript:$('input[name=cb_bid]').reverseAll();" />
                <input type="button" onclick="javascript:location.href='AddBulletinType.aspx';" value="添加"
                    class="n_btn w_60" />
                <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="禁用" OnClientClick="javascript:return confirm_deleteSelected();"
                    CssClass="n_btn w_60"  />
                <input type="button" class="n_btn w_60" value="刷新"
                    onclick="javascript:location.reload();" />
            </div>
        </div>
        </form>
    </div>
</body>
</html>

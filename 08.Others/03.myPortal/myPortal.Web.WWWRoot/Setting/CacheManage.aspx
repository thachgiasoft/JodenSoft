<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CacheManage.aspx.cs" Inherits="myPortal.Web.WWWRoot.Setting.CacheManage"
       %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>缓存管理</title>
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
                <asp:Label ID="lblQuery" runat="server" Text="缓存信息查询" ></asp:Label></a>
        </div>
        <div class="c" id="d_h2">
            <table class="det_t">
                <tr>
                    <td class="th w_p15">
                        <asp:Label ID="lblName" runat="server" Text="Cash Name" ></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" class="n_txt w_p98" ></asp:TextBox>
                    </td>
                </tr>
            </table>
            <div class="f_r m_10">
                <asp:Button ID="btnQuery" CssClass="n_btn w_60" runat="server" Text="查询" OnClick="btnQuery_Click"
                     />
            </div>
        </div>
        <div class="clear" />
        <div class="h_line">
            <a href="javascript://;" id="_h1" class="h_n">
                <asp:Label ID="lblInfo" runat="server" Text="缓存列表信息" ></asp:Label></a>
        </div>
        <div class="c" id="d_h1">
            <asp:DataGrid ID="grid" GridLines="None" CssClass="cus_t" runat="server" AutoGenerateColumns="False"
                >
                <PagerStyle Mode="NumericPages" Visible="false" />
                <Columns>
                    <asp:TemplateColumn HeaderText="" HeaderStyle-CssClass="th w_20">
                        <ItemTemplate>
                            <input type="checkbox" name="cb_bid" value='<%# Eval("Key") %>' />
                        </ItemTemplate>
                        <HeaderStyle CssClass="th w_20"></HeaderStyle>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Cache Key" HeaderStyle-CssClass="th ">
                        <ItemTemplate>
                            <%#Eval("Key")%>
                        </ItemTemplate>
                        <HeaderStyle CssClass="th "></HeaderStyle>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Cach Name" HeaderStyle-CssClass="th ">
                        <ItemTemplate>
                            <%#Eval("Name")%>
                        </ItemTemplate>
                        <HeaderStyle CssClass="th "></HeaderStyle>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="操作"
                        HeaderStyle-CssClass="th w_40" ItemStyle-CssClass="center">
                        <ItemTemplate>
                            <a href="javascript://" class="imgbtn_del" title="" onclick='javascript:confirm_delete(&#039;<%# Eval("Key") %>&#039;);'>
                            </a>
                        </ItemTemplate>
                        <HeaderStyle CssClass="th w_40"></HeaderStyle>
                        <ItemStyle CssClass="center"></ItemStyle>
                    </asp:TemplateColumn>
                </Columns>
            </asp:DataGrid>
            <div class="f_r m_10">
                <input type="button" class="n_btn w_60" value="全选"
                    onclick="javascript:$('input[name=cb_bid]').selectAll();" />
                <input type="button" class="n_btn w_60" value="反选"
                    onclick="javascript:$('input[name=cb_bid]').reverseAll();" />
                <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="删除" OnClientClick="javascript:return confirm_deleteSelected();"
                    CssClass="n_btn w_60"  />
                <input type="button" class="n_btn w_60" value="刷新"
                    onclick="javascript:location.reload();" />
            </div>
        </div>
        </form>
    </div>
</body>
</html>

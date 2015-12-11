<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBulletinType.aspx.cs"
    Inherits="myPortal.Web.WWWRoot.Dictionary.AddBulletinType"    %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>公告类型</title>
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
    </script>
</head>
<body>
    <div class="wrap">
        <form id="form1" runat="server">
        <div class="h_line">
            <a href="javascript://;" id="_h1" class="h_n">
                <asp:Label ID="lblNoticeTypeInfo" runat="server" Text="公告类型信息" 
                ></asp:Label></a>
        </div>
        <div class="c" id="d_h1">
            <table class="c_t">
                <tr>
                    <td class="th w_p15">
                        <asp:Label ID="lblNoticeType" runat="server" Text="公告类型" 
                            ></asp:Label><span class="red">*</span>
                    </td>
                    <td class="w_p35">
                        <asp:TextBox ID="txtName" CssClass="n_txt w_p99" MaxLength="45" runat="server" 
                            ></asp:TextBox>
                    </td>
                    <td class="th w_p15">
                        <asp:Label ID="lblSort" runat="server" Text="排序" 
                            ></asp:Label><span class="red">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSort" MaxLength="9" CssClass="n_txt w_p99" runat="server" 
                            onkeyup="this.value=this.value.replace(/[^\d]+?/g,'')" 
                            ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="th w_p15">
                        <asp:Label ID="lblDisable" runat="server" Text="禁用(选中表示禁用)" 
                            ></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:CheckBox ID="cbxIsActive" runat="server" 
                             />
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
                <input type="button" class="n_btn w_60" value="取消"
                    onclick="javascript:location.href='BulletinTypeManage.aspx';" />
            </div>
        </div>
        </form>
    </div>
</body>
</html>

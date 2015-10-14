<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddScheduleQuery.aspx.cs"
    Inherits="ScheduleQueryPortal.AddScheduleQuery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="wrap">
        <form id="form1" runat="server">
        <div class="h_line">
            <a href="javascript://;" id="_h1" class="h_n">进度查询信息 </a>
        </div>
        <div class="c" id="d_h1">
            <table class="c_t">
                <tr>
                    <td class="th w_p15">
                        进度查询名称<span class="red">*</span>
                    </td>
                    <td class="w_p35">
                        <asp:TextBox ID="txtName" runat="server" MaxLength="45" CssClass="n_txt w_p99"></asp:TextBox>
                    </td>
                    <td class="th w_p15">
                        翻页时间间隔(秒)<span class="red">*</span>
                    </td>
                    <td class="w_p35">
                        <asp:TextBox ID="txtTimeInterval" runat="server" CssClass="n_txt w_p99" onkeyup="this.value=this.value.replace(/[^\d]+?/g,'')"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <% if (hasError)
               { %>
            <div class="err_tips m_10">
                <p>
                    输入或操作发生错误!</p>
                <p>
                </p>
                <%=errorMsg %>
            </div>
            <%} %>
            <div class="f_r m_10">
                <asp:Button ID="buttonOK" runat="server" Text="确认" OnClick="buttonOK_Click" CssClass="n_btn w_60" />
                <input type="button" class="n_btn w_60" value="返回" onclick="javascript:location.href='Default.aspx';" />
            </div>
        </div>
        </form>
    </div>
</body>
</html>

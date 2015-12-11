<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBulletin.aspx.cs" Inherits="myPortal.Web.WWWRoot.Bulletin.AddBulletin"    %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>发布公告</title>
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

            $("#txtDateStart").ShowDatePicker();
            $("#txtDateEnd").ShowDatePicker();

        });

        function checkinput() {
            if ($("#txtTitle").val() == '') {
                alert('请输入标题.');
                return false;
            }
        }
    </script>
</head>
<body>
    <div class="wrap">
        <form id="form1" runat="server" onsubmit="javascript:return checkinput();">
        <div class="h_line">
            <a href="javascript://;" id="_h1" class="h_n">
                <asp:Label ID="lblHeader" runat="server" Text="公告信息" 
                ></asp:Label></a>
        </div>
        <div class="c" id="d_h1">
            <table class="c_t">
                <tr>
                    <td class="th w_p15">
                        <asp:Label ID="lblTitle" runat="server" Text="公告标题" 
                            ></asp:Label><span class="red">*</span>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtTitle" MaxLength="45" runat="server" CssClass="n_txt w_p99" 
                            ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="th">
                        <asp:Label ID="lblActiveTime" runat="server" Text="生效时间" 
                            ></asp:Label><span class="red">*</span>
                    </td>
                    <td class="w_p35">
                        <input type="text" class="date_txt" id="txtDateStart" runat="server" />
                        <select id="ddlStartHour" class="n_txt w_40" runat="server">
                            <option value="00">00</option>
                            <option value="01">01</option>
                            <option value="02">02</option>
                            <option value="03">03</option>
                            <option value="04">04</option>
                            <option value="05">05</option>
                            <option value="06">06</option>
                            <option value="07">07</option>
                            <option value="08">08</option>
                            <option value="09">09</option>
                            <option value="10">10</option>
                            <option value="11">11</option>
                            <option value="12">12</option>
                            <option value="13">13</option>
                            <option value="14">14</option>
                            <option value="15">15</option>
                            <option value="16">16</option>
                            <option value="17">17</option>
                            <option value="18">18</option>
                            <option value="19">19</option>
                            <option value="20">20</option>
                            <option value="21">21</option>
                            <option value="22">22</option>
                            <option value="23">23</option>
                        </select>
                    </td>
                    <td class="th">
                        <asp:Label ID="lblAeadTime" runat="server" Text="失效时间" 
                            ></asp:Label><span class="red">*</span>
                    </td>
                    <td>
                        <input type="text" class="date_txt" id="txtDateEnd" runat="server" />
                        <select id="ddlEndHour" class="n_txt w_40" runat="server">
                            <option value="00">00</option>
                            <option value="01">01</option>
                            <option value="02">02</option>
                            <option value="03">03</option>
                            <option value="04">04</option>
                            <option value="05">05</option>
                            <option value="06">06</option>
                            <option value="07">07</option>
                            <option value="08">08</option>
                            <option value="09">09</option>
                            <option value="10">10</option>
                            <option value="11">11</option>
                            <option value="12">12</option>
                            <option value="13">13</option>
                            <option value="14">14</option>
                            <option value="15">15</option>
                            <option value="16">16</option>
                            <option value="17">17</option>
                            <option value="18">18</option>
                            <option value="19">19</option>
                            <option value="20">20</option>
                            <option value="21">21</option>
                            <option value="22">22</option>
                            <option value="23">23</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td class="th">
                        <asp:Label ID="lblNoticeType" runat="server" Text="公告类型" 
                            ></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlBulletinType" CssClass="n_txt w_p98" runat="server" 
                            >
                        </asp:DropDownList>
                    </td>
                    <td class="th">
                        <asp:Label ID="lblNoticeLevel" runat="server" Text="公告级别" 
                            ></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlBulletinLevel" CssClass="n_txt w_p98" runat="server" 
                            >
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="th">
                        <asp:Label ID="lblNoticeContent" runat="server" Text="公告内容" 
                            ></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:TextBox TextMode="MultiLine" Rows="15" MaxLength="350" runat="server" CssClass="n_txt w_p99"
                            ID="txtContent" ></asp:TextBox>
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
                <input type="button" class="n_btn w_60" value="取消" onclick="javascript:location.href='BulletinManage.aspx';" />
            </div>
        </div>
        </form>
    </div>
</body>
</html>

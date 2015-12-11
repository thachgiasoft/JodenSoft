<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePass.aspx.cs" Inherits="myPortal.Web.WWWRoot.ChangePass"    %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>修改密码</title>
    <meta http-equiv="content-type" content="text/html;charset=utf-8" />
    <link href="Css/common.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript">
        function checkinput() {
            if (document.getElementById("txtOrignalPass").value == "") {
                alert("<%=Resources.GlobalResources.PasswordCanNotBeEmpty%>");
                document.getElementById("txtOrignalPass").focus();
                return false;
            }
            if (document.getElementById("txtNewPass").value == "") {
                alert("<%=Resources.GlobalResources.PasswordCanNotBeEmpty%>");
                document.getElementById("txtOrignalPass").focus();
                return false;
            }
            if (document.getElementById("txtNewPass").value != document.getElementById("txtRepass").value) {
                alert("<%=Resources.GlobalResources.TwoInputPasswordMustBeConsistent %>");
                document.getElementById("txtOrignalPass").focus();
                return false;
            }
        }
    </script>
</head>
<body>
    <div class="wrap">
        <form id="form1" runat="server">
        <div class="h_line">
            <a href="javascript://;" id="_h1" class="h_n">
                <asp:Label ID="lblChangePassHeadline" runat="server" Text="修改密码" 
                ></asp:Label></a>
        </div>
        <div class="c" id="d_h1">
            <table class="nor_t mar_auto">
                <tr>
                    <td class="FieldEditTitle w_100">
                        <asp:Label ID="lblOriginalPwd" runat="server" Text="原密码" 
                            ></asp:Label><span class="red">*</span>
                    </td>
                    <td>
                        <asp:TextBox TextMode="Password" CssClass="n_txt w_200" ID="txtOrignalPass" 
                            runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="FieldEditTitle">
                        <asp:Label ID="lblNewPwd" runat="server" Text="新密码" 
                            ></asp:Label><span class="red">*</span>
                    </td>
                    <td>
                        <asp:TextBox TextMode="Password" CssClass="n_txt w_200" ID="txtNewPass" 
                            runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="FieldEditTitle">
                        <asp:Label ID="lblNewPwdConfirm" runat="server" Text="密码确认" 
                            ></asp:Label><span class="red">*</span>
                    </td>
                    <td>
                        <asp:TextBox TextMode="Password" CssClass="n_txt w_200" ID="txtRepass" 
                            runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="center">
                        <asp:Button ID="btnOk" runat="server" OnClick="btnOk_Click" OnClientClick="javascript:return checkinput();"
                            CssClass="n_btn w_60" Text="确定"  />
                    </td>
                </tr>
            </table>
        </div>
        </form>
    </div>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUserRoleList.aspx.cs"
    Inherits="myPortal.Web.WWWRoot.Handlers.AddUserRoleList"    %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="RoleList" style="height: 300px;">
        <table class="c_t">
            <tr>
                <td class="th w_p15">
                    <asp:Label ID="lblRoleName" runat="server" Text="角色名称" 
                        ></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtRoleName" runat="server" 
                        ></asp:TextBox>
                </td>
                <td  class="w_60">
                    <input id="btnQueryRole" type="button" value="查询"class="n_btn w_60" onclick="$('#RoleList').load('../Handlers/AddUserRoleList.aspx #RoleList',{ 'sRoleName': $('#txtRoleName').val() }); " />
                </td>
            </tr>
        </table>
        <div style="height: 200px; overflow: auto;">
            <table class="cus_t">
                <tr>
                    <td class="th w_20">
                    </td>
                    <td class="th">
                        <asp:Label ID="lblRoleName2" runat="server" Text="角色名称" 
                            ></asp:Label>
                    </td>
                </tr>
                <asp:Repeater ID="rptRole" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td class="center">
                                <input type='radio' id='radio_role_<%# Eval("iIden") %>' name='radio_role' value='<%# Eval("iIden") %>'
                                    title='<%# Eval("iIden") %>.<%# Eval("sName") %>' />
                            </td>
                            <td class="center">
                                <%#Eval("iIden") %>.<%# Eval("sName") %></td>
                            
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </div>
    </form>
</body>
</html>

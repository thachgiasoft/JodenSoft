<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddScheduleQueryHdr.aspx.cs"
    Inherits="ScheduleQueryPortal.AddScheduleQueryHdr" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jQuery.common.js" type="text/javascript"></script>
    <script src="Scripts/Common.js" type="text/javascript"></script>
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
            <a href="javascript://;" id="_h1" class="h_n">子查询信息 </a>
        </div>
        <div class="c" id="d_h1">
            <table class="c_t">
                <tr>
                    <td class="th w_p15">
                        子进度查询名称<span class="red">*</span>
                    </td>
                    <td class="w_p35">
                        <asp:TextBox ID="txtName" runat="server" MaxLength="45" CssClass="n_txt w_p99"></asp:TextBox>
                    </td>
                    <td class="th w_p15">
                        进度查询ID<span class="red">*</span>
                    </td>
                    <td class="w_p35">
                        <asp:TextBox ID="txtQueryId" runat="server" CssClass="n_txt w_p99" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="th w_p15">
                        页面行数<span class="red">*</span>
                    </td>
                    <td class="w_p35">
                        <asp:TextBox ID="txtPageSize" runat="server" CssClass="n_txt w_p99" onkeyup="this.value=this.value.replace(/[^\d]+?/g,'')"></asp:TextBox>
                    </td>
                    <td class="th w_p15">
                        字体大小<span class="red">*</span>
                    </td>
                    <td class="w_p35">
                        <asp:TextBox ID="txtFontSize" runat="server" CssClass="n_txt w_p99" onkeyup="this.value=this.value.replace(/[^\d]+?/g,'')"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="th w_p15">
                        查询语句<span class="red">*</span>
                    </td>
                    <td class="w_p35" colspan="3">
                        <textarea id="txtSQL" cols="20" rows="5" class="n_txt w_p99" runat="server"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <div class="f_r m_10">
            <asp:Button ID="buttonOK" runat="server" Text="保存" OnClick="buttonOK_Click" CssClass="n_btn w_60" />
            <%if (this.IsModifyAction)
              { %>
            <asp:Button ID="btnDelete" runat="server" Text="删除" CssClass="n_btn w_60" OnClick="btnDelete_Click"
                OnClientClick="javascript:return confirm('确定要删除吗?');" />
            <%} %>
            <input type="button" class="n_btn w_60" value="返回" onclick="javascript:location.href='Default.aspx';" />
        </div>
        <div class="clear" />
        <div class="h_line">
            <a href="javascript://;" id="_h2" class="h_n">子查询字段 </a>
        </div>
        <div class="c" id="d_h2">
            <asp:GridView ID="GridViewField" runat="server" AutoGenerateColumns="False" CssClass="cus_t"
                DataKeyNames="iIden" OnRowEditing="GridViewField_RowEditing" OnRowCancelingEdit="GridViewField_RowCancelingEdit"
                OnRowDataBound="GridViewField_RowDataBound" OnRowUpdating="GridViewField_RowUpdating">
                <Columns>
                    <asp:BoundField DataField="iIden" HeaderText="序号" ReadOnly="true">
                        <HeaderStyle CssClass="w_40" />
                        <ItemStyle CssClass="center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="sFieldName" HeaderText="字段名" ReadOnly="true"></asp:BoundField>
                    <asp:TemplateField HeaderText="标题">
                        <ItemTemplate>
                            <%# Eval("sCaption")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:HiddenField ID="hidQueryHdrId" runat="server" Value='<%# Eval("iQueryHdrId") %>' />
                            <asp:TextBox ID="txtCaption" runat="server" Text='<%# Eval("sCaption") %>' CssClass="n_txt w_p98"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="是否显示">
                        <EditItemTemplate>
                            <asp:CheckBox ID="chkShow" runat="server" Checked='<%# Bind("bShow") %>' />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("bShow") %>' Enabled="false" />
                        </ItemTemplate>
                        <HeaderStyle CssClass="w_60" />
                        <ItemStyle CssClass="center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="列宽">
                        <ItemTemplate>
                            <%# Eval("iWidth")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtWidth" runat="server" Text='<%#Eval("iWidth") %>' CssClass="n_txt w_p97"
                                onkeyup="this.value=this.value.replace(/[^\d]+?/g,'')"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle CssClass="center" />
                        <HeaderStyle CssClass="w_80" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="允许换行">
                        <EditItemTemplate>
                            <asp:CheckBox ID="chkAllowWarp" runat="server" Checked='<%# Bind("bAllowWarp") %>' />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%# Bind("bAllowWarp") %>' Enabled="false" />
                        </ItemTemplate>
                        <HeaderStyle CssClass="w_60" />
                        <ItemStyle CssClass="center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="水平对齐">
                        <ItemTemplate>
                            <%#CalcHorizontalAlignment( Eval("sHorizontalAlignment"))%>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:HiddenField ID="hidHorizontalAlignment" runat="server" Value='<%# Eval("sHorizontalAlignment") %>' />
                            <asp:DropDownList ID="ddlHorizontalAlignment" runat="server" CssClass="n_txt w_p98">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <HeaderStyle CssClass="w_80" />
                        <ItemStyle CssClass="center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="垂直对齐">
                        <ItemTemplate>
                            <%#CalcVerticalAlignment( Eval("sVerticalAlignment"))%>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:HiddenField ID="hidVerticalAlignment" runat="server" Value='<%# Eval("sVerticalAlignment") %>' />
                            <asp:DropDownList ID="ddlVerticalAlignment" runat="server" CssClass="n_txt w_p98">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <HeaderStyle CssClass="w_80" />
                        <ItemStyle CssClass="center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="排序">
                        <ItemTemplate>
                            <%# Eval("iSortIndex")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtSortIndex" runat="server" CssClass="n_txt w_p97" Text='<%# Eval("iSortIndex") %>'
                                onkeyup="this.value=this.value.replace(/[^\d]+?/g,'')"></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderStyle CssClass="w_80" />
                        <ItemStyle CssClass="center" />
                    </asp:TemplateField>
                    <asp:CommandField HeaderText="操作" ShowEditButton="True" ShowHeader="True">
                        <HeaderStyle CssClass="w_80" />
                        <ItemStyle CssClass="center" />
                    </asp:CommandField>
                </Columns>
            </asp:GridView>
            <div class="f_r m_10">
                <%if (this.IsModifyAction)
                  { %>
                <asp:Button ID="Button1" runat="server" Text="获取字段列表" CssClass="n_btn w_100" OnClick="btnGetFields_Click" />
                <asp:Button ID="Button2" runat="server" Text="删除字段列表" CssClass="n_btn w_100" OnClientClick="javascript:return confirm('确定要删除吗?');"
                    OnClick="btnDeleteAllFields_Click" />
                <%} %>
            </div>
        </div>
        <div class="clear" />
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
        </form>
    </div>
</body>
</html>

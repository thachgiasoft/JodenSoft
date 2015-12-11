<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PageControl.ascx.cs"
    Inherits="myPortal.Web.WWWRoot.Controls.PageControl" %>
<link href="../Css/common.css" rel="stylesheet" type="text/css" />
<div id="divPageControl" style="padding-top: 2px;" class="divPageControl">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td style="vertical-align: middle; white-space: nowrap;">
                <asp:ImageButton ID="btnFirst" runat="server" ImageUrl="~/img/common/btn_first.gif"
                    OnClick="btnFirst_Click" meta:resourcekey="btnFirstResource1" />
                <asp:ImageButton ID="btnPrevious" runat="server" ImageUrl="~/img/common/btn_previous.gif"
                    OnClick="btnPrevious_Click" meta:resourcekey="btnPreviousResource1" />
                <asp:ImageButton ID="btnNext" runat="server" ImageUrl="~/img/common/btn_next.gif"
                    OnClick="btnNext_Click" meta:resourcekey="btnNextResource1" />
                <asp:ImageButton ID="btnLast" runat="server" ImageUrl="~/img/common/btn_last.gif"
                    OnClick="btnLast_Click" meta:resourcekey="btnLastResource1" />
            </td>
            <td style="text-align: right; vertical-align: middle; white-space: nowrap;">
                <asp:Label ID="lblAll" runat="server" Text="共" 
                    meta:resourcekey="lblAllResource1"></asp:Label>&nbsp;<asp:Label ID="lblTotalPages"
                    runat="server" Text="0" ForeColor="DarkBlue" 
                    meta:resourcekey="lblTotalPagesResource1"></asp:Label>&nbsp;<asp:Label 
                    ID="lblPage" runat="server" Text="页" meta:resourcekey="lblPageResource1"></asp:Label>&nbsp;<asp:Label
                    ID="lblTotalRows" runat="server" Text="0" ForeColor="DarkBlue" 
                    meta:resourcekey="lblTotalRowsResource1"></asp:Label>
                <asp:Label ID="lblRecords" runat="server" Text="个" 
                    meta:resourcekey="lblRecordsResource1"></asp:Label>&nbsp;/&nbsp;<asp:Label ID="lblCurrent" runat="server" Text="当前第" 
                    meta:resourcekey="lblCurrentResource1"></asp:Label>&nbsp;<asp:Label
                    ID="lblCurrentPage" runat="server" Text="0" ForeColor="DarkBlue" 
                    meta:resourcekey="lblCurrentPageResource1"></asp:Label>&nbsp;
                <asp:Label ID="lblPage1" runat="server" Text="页" 
                    meta:resourcekey="lblPage1Resource1"></asp:Label>&nbsp;/&nbsp;<asp:Label
                    ID="lblGoto" runat="server" Text="跳至" meta:resourcekey="lblGotoResource1"></asp:Label><input id="txtGotoPageNumber" type="text"
                        class="n_txt" style="width: 50px;" onkeypress="if ((event.keyCode<48 || event.keyCode>57)) event.returnValue=false;"
                        runat="server" />&nbsp;<asp:Label ID="lblPage2" runat="server" Text="页" 
                    meta:resourcekey="lblPage2Resource1"></asp:Label>
            </td>
            <td style="white-space: nowrap; width: 30px; vertical-align: bottom; text-align: right;">
                <asp:ImageButton ID="btnGoto" runat="server" ImageUrl="~/img/common/go.gif" OnClick="btnGoto_Click"
                    CssClass="btnGoto" meta:resourcekey="btnGotoResource1" />
            </td>
        </tr>
    </table>
</div>

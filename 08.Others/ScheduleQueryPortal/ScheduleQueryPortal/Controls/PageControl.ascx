<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PageControl.ascx.cs"
    Inherits="ScheduleQueryPortal.Controls.PageControl" %>
<link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
<div id="divPageControl" style="padding-top: 2px;" class="divPageControl">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td style="vertical-align: middle; white-space: nowrap;">
                &nbsp;</td>
            <td style="text-align: right; vertical-align: middle; white-space: nowrap;">
                <asp:Label ID="lblAll" runat="server" Text="共" 
                    meta:resourcekey="lblAllResource1"></asp:Label>&nbsp;<asp:Label ID="lblTotalPages"
                    runat="server" Text="0" ForeColor="DarkBlue" 
                    meta:resourcekey="lblTotalPagesResource1"></asp:Label>&nbsp;<asp:Label 
                    ID="lblPage" runat="server" Text="页" meta:resourcekey="lblPageResource1"></asp:Label>&nbsp;<asp:Label
                    ID="lblTotalRows" runat="server" Text="0" ForeColor="DarkBlue" 
                    meta:resourcekey="lblTotalRowsResource1"></asp:Label>&nbsp;
                <asp:Label ID="lblRecords" runat="server" Text="个" 
                    meta:resourcekey="lblRecordsResource1"></asp:Label>&nbsp;/&nbsp;<asp:Label ID="lblCurrent" runat="server" Text="当前第" 
                    meta:resourcekey="lblCurrentResource1"></asp:Label>&nbsp;<asp:Label
                    ID="lblCurrentPage" runat="server" Text="0" ForeColor="DarkBlue" 
                    meta:resourcekey="lblCurrentPageResource1"></asp:Label>&nbsp;
                <asp:Label ID="lblPage1" runat="server" Text="页" 
                    meta:resourcekey="lblPage1Resource1"></asp:Label>&nbsp;</td>
            <td style="white-space: nowrap; width: 30px; vertical-align: bottom; text-align: right;">
                &nbsp;</td>
        </tr>
    </table>
</div>

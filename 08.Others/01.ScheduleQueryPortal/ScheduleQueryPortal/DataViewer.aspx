<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataViewer.aspx.cs" Inherits="ScheduleQueryPortal.DataViewer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divDataViewer">
        <asp:GridView ID="GridView" runat="server" CssClass="cus_t" AutoGenerateColumns="False"
            OnRowDataBound="GridView_RowDataBound">
        </asp:GridView>
        <ctt:PageControl ID="PageControl1" runat="server" />
        <input runat="server" id="hidTotalPage" type="hidden" />
        <input runat="server" id="hidPageIndex" type="hidden" />
        <input runat="server" id="hidChildQueryCount" type="hidden" />
        <input runat="server" id="hidChildQueryIndex" type="hidden" />
        <div>
            <% if (hasError)
               { %>
            <div class="err_tips m_10">
                <p>
                    出错了!!!
                </p>
                <%=errorMsg %>
            </div>
            <%} %>
        </div>
    </div>
    </form>
</body>
</html>

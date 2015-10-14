<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScheduleViewer.aspx.cs"
    Inherits="ScheduleQueryPortal.ScheduleViewer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>进度查询</title>
    <link href="Styles/Site.css?123" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.timers.js" type="text/javascript"></script>
    <script src="Scripts/jQuery.common.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            loadData();
            $("body").everyTime("<%=iTimeInterval %>", "ScheduleQuery", loadData, 0, true);
        });

        function loadData() {
            var ChildQueryCount = $("#hidChildQueryCount").val();
            if (ChildQueryCount == undefined || ChildQueryCount == "") ChildQueryCount = 1;

            var ChildQueryIndex = $("#hidChildQueryIndex").val();
            if (ChildQueryIndex == undefined || ChildQueryIndex == "") ChildQueryIndex = 0;

            var totalPage = $("#hidTotalPage").val();
            if (totalPage == undefined || totalPage == "") totalPage = 1;

            var pageIndex = $("#hidPageIndex").val();
            if (pageIndex == undefined || pageIndex == "") pageIndex = 0;

            pageIndex = Number(pageIndex) + 1;

            if (Number(pageIndex) > Number(totalPage)) {
                pageIndex = 1;
                ChildQueryIndex = Number(ChildQueryIndex) + 1;
                if (ChildQueryIndex + 1 > Number(ChildQueryCount)) {
                    ChildQueryIndex = 0;
                }
            }

            $("#divData").load("DataViewer.aspx #divDataViewer", { "QueryId": "<%=QueryId %>", "ChildQueryIndex": ChildQueryIndex, "PageIndex": pageIndex });

        }
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divData">
    </div>
    </form>
</body>
</html>

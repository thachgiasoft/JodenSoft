<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkSpace.aspx.cs" Inherits="myPortal.Web.WWWRoot.WorkSpace"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
     <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <link rel="stylesheet" href="css/common.css" type="text/css" />
    <script src="js/jquery-1.8.1.min.js" type="text/javascript"></script>
    <title>myPortal</title>
    <script type="text/javascript">
        $(document).ready(function () {
            $(this).keydown(function () {
                if (window.event.keyCode == 27)//ESC 
                {
                    window.event.keyCode = 8;
                }
                if (event.keyCode == 8)//后退键 
                {
                    event.keyCode = 0;
                    event.cancelBubble = true;
                    return false;
                }
            });
        });
    </script>
</head>
<frameset rows="0,87,*,14" cols="*" frameborder="no" border="0" framespacing="0"> 
  <frame src="RefreshSessionState.aspx"></frame> 
  <frame src="topframe.aspx" name="topFrame" frameborder="no" scrolling="No" noresize="noresize" id="topFrame" title="topFrame" />
  <frameset cols="199,7,*" id="myFrame" name="myFrame" frameborder="no" border="0" framespacing="0">
    <frame src="leftframe.aspx?wh=<%=Request["wh"] %>&iv=<%=Request["iv"] %>" name="leftFrame" frameborder="no" scrolling="No" noresize="noresize" id="leftFrame" title="leftFrame" />
	<frame src="switchframe.html" name="midFrame" frameborder="no" scrolling="No" noresize="noresize" id="midFrame" title="midFrame" />
    <frame src="mainframe.aspx?wh=<%=Request["wh"] %>&iv=<%=Request["iv"] %>" name="manFrame" frameborder="no" id="manFrame" title="manFrame" />    
  </frameset>
  <frame src="bottom.htm" name="bptFrame" frameborder="no" scrolling="No" noresisze="noresize" id="botFrame"></frame>
</frameset>

<noframes>
</noframes>
</html>

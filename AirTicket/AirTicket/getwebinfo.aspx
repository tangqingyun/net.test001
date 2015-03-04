<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="getwebinfo.aspx.cs" Inherits="AirTicket.getwebinfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="Scripts/jquery-1.7.1.min.js"></script>
    <script type="text/javascript">
        $(function () {


                
        });

        function fnload(t)
        {
            var src = $(t).attr("src");
            alert(window.location.hash);
        }
    </script>
</head>
<body>
    <p><input type="button" value="获取" onclick="getinfo(this)"/></p>
    <iframe src="aa.aspx" style="width:80%;height:500px;"  onload="fnload(this)"></iframe>
</body>
</html>

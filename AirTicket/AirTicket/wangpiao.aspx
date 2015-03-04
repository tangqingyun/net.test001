<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wangpiao.aspx.cs" Inherits="AirTicket.wangpiao" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="Scripts/jquery-1.7.1.min.js"></script>
    <script type="text/javascript">
     

        //%u4E2D%u56FD%u4EBA
        //%u4e2d%u56fd%u4eba
        //tangqingyuncx%40qq.com unescape("tangqingyuncx%40qq.com")

        $(function () {
            var random = Math.random();
            var uname = escape("tangqingyuncx@qq.com");
            var upwd = escape("tangqingyun");
            
            var loginnums = 0;
          

            return false;
            $.getJSON("http://member.wangpiao.com/ajax/ajaxlogin.aspx?uname=" + uname + "&upwd=" + upwd + "&loginnums=" + loginnums + "&chkcode=&usave=false&zip=" + random + "&format=json&jsoncallback=?", function (data) {
                if (data.istrue) {
                    location.href = "http://www.wangpiao.com";
                } else {
                    alert("登陆失败!");
                }
            });
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      
    </div>
    </form>
</body>
</html>

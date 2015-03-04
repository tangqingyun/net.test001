<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wandafilm.aspx.cs" Inherits="AirTicket.wandafilm" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form2" method="post" runat="server" action="http://www.wandafilm.com/login.do?m=ajaxLogin">
        <p><input type="hidden" name="autoLogin"  value="true" /></p>
        <p><input type="hidden" name="code"  value="" /></p>
        <p><input type="text" name="email"  value="15901473139" /></p>
        <p><input type="password" name="password"  value="a123456" /></p>
        <p><input type="submit" name="" value="登陆" /></p>
    </form>
</body>
</html>

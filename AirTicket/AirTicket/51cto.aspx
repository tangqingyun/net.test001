<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="51cto.aspx.cs" Inherits="AirTicket._51cto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form action="http://home.51cto.com/index.php?s=/Index/doLogin" method="post">

 <p>账　号： <input name="email" type="text" class="login_shuru1" onfocus="this.className='login_shuru2';if (this.value=='用户名/注册邮箱') {this.value=''}" onblur="this.className='login_shuru1';if (this.value=='') {this.value='用户名/注册邮箱'}" value="tamny@sohu.com"/></p>
<p>密　码：
<input name="passwd" type="password" value="tangqingyun" class="login_shuru1" onfocus="this.className='login_shuru2'" onblur="this.className='login_shuru1'" />
<input name="reback" type="hidden" value="http%3A%2F%2Fdown.51cto.com" />
<%--<input style="margin-right:10px;" name="button" type="image" src="http://home.51cto.com/public/themes/blue/images/index_login_denglu.gif" />--%>
    <input type="submit" value="登陆" />
</p>



    </form>
</body>
</html>

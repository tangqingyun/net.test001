<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Demo.aspx.cs" Inherits="AirTicket.Demo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" action="https://accounts.ctrip.com/member/login.aspx" runat="server">
     <input type="hidden" name="loginType" value="0" />
     <input type="hidden" name="hidToken" id="hidToken" value="MjAxMy03LTIgMTM6MTA6MzA=" />
    <input type="hidden" name="hidUid" id="hidUid" />
    <input type="hidden" name="hidServerName" id="hidServerName" value="http://accounts.ctrip.com" />
    <input type="hidden" id="needCheckServerSession" name="needCheckServerSession" value="F" />
    <input type="hidden" id="hdnToken" name ="hdnToken" value="MjAxMy03LTIgMTM6MTA6MzA=" />
    <input type="hidden" id="hidGohome" name="hidGohome" value="gohome" />
    <input type="hidden" id="hidVerifyCodeLevel" name="hidVerifyCodeLevel" value="N" />
    <input type="hidden" id="hidMask" name="hidMask" value="F" />

     用户名：<input type="text" name="txtUserName" value="tqyitweb@163.com" /><br />
     密码：<input type="password" name="txtPwd" value="tangqingyun" /><br />
        <input type="submit" name="" value=" 登陆 " />
    </form>
</body>
</html>

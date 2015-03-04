<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xiecheng.aspx.cs" Inherits="AirTicket.xiecheng" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>携程网-登陆</title>
    <script src="jquery-1.4.2.min.js"></script>
    <script>
        $(function () {
           //$("#btnSubmit").click();

           // $("form").submit();
        });

    </script>
</head>
<body class="bodynobackground">

<form name='Form1' method='post' action='https://accounts.ctrip.com/member/login.aspx?BackUrl=http%3A%2F%2Fflights.ctrip.com%2F&responsemethod=get' id='Form1'>
<input type='hidden' name='__EVENTTARGET' value='' />
<input type='hidden' name='__EVENTARGUMENT'  value='' />
<input type='hidden' name='loginType' value='0'/>
<input type='hidden' name='signin_logintype' value=''/>
<input type='hidden' name='done' value=''/>
<input type='hidden' name ='hdnToken' value='MjAxMy03LTIgMTM6MTA6MzA=' />
<input type='hidden' name='hidGohome' value='gohome' />
<input type='hidden' name='hidVerifyCodeLevel' value='N' />
<input type='hidden' name='txtUserName' value='tqyitweb@163.com'   />
<input type='hidden' name='txtPwd' value='tangqingyun' />
<p>
<input type='submit' name='btnSubmit' value='登录'  id="btnSubmit"/></p>
</form>	

</body>
</html>

<%@ Page Language='C#' AutoEventWireup='true' CodeBehind='yongche.aspx.cs' Inherits='AirTicket.yongche' %>

<!DOCTYPE html>

<html xmlns='http://www.w3.org/1999/xhtml'>
<head runat='server'>
<meta http-equiv='Content-Type' content='text/html; charset=utf-8'/>
    <title> 易到用车-登陆</title>
    <script src='jquery-1.4.2.min.js'></script>
    <script>
        $(function () {
         //   $('#form').submit();
         
        });

    </script>

</head>
<body>
<form action='https://www.yongche.com/login/?source=login&done=http%3A%2F%2Fwww.yongche.com' method='post' id='form'>
<input type='text'  name='login'  placeholder='用户名/手机' value='15901473139'/>
<input type='text'  name='password' value ='tangqingyun' />
<!--<input type='hidden' name='bind' value=''/>
<input type='hidden' name='src' value=''/>
<input type='hidden' name='code' value=''/>
<input type='hidden' name='done' value=''/>-->
    <p>
<input type='submit'  value='登　录' name='login_submit' id='login_submit'/>
 </p>
    </form>
</body>
</html>

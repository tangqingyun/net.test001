<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="12306.aspx.cs" Inherits="AirTicket._12306" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<meta http-equiv="X-UA-Compatible" content="IE=7" />
<meta name="Robots"   content="none"/>
<meta http-equiv="Expires" content="0"/>
<meta http-equiv="Cache-Control"  content="no-cache"/> 
<meta http-equiv="pragma"  content="no-cache"/> 
<title>登录</title>
 
<link  href="http://www.12306.cn/otsweb/css/style.css" rel="stylesheet"  type="text/css"/>
<link  href="http://www.12306.cn/otsweb/css/newsty.css" rel="stylesheet"  type="text/css"/>
<link  href="http://www.12306.cn/otsweb/css/contact.css" rel="stylesheet"  type="text/css"/>
<link href="http://www.12306.cn/otsweb/css/validation.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" type="text/css" href="http://www.12306.cn/otsweb/css/easyui.css"/>
<link rel="stylesheet" type="text/css" href="http://www.12306.cn/otsweb/css/suggest.css"/>
<link href="http://www.12306.cn/otsweb/css/ots_common.css" rel="stylesheet" type="text/css" />
<link rel="shortcut icon" href="http://www.12306.cn/mormhweb/images/favicon.ico"/>

<script src="jquery-1.4.2.min.js" type="text/javascript"></script>
<%--<script src="https://www.12306.cn/otsweb/jquery-1.4.2.min.js" type="text/javascript"></script>

<script src="Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>--%>
 
<script type="text/javascript">
    $(document).ready(function () {
  
    });
</script>
    <style type="text/css"> 
body {
	background: url("images/mainBG.jpg") repeat-y scroll center top #EEF3FA;
	font-family: Verdana, Arial, Helvetica, sans-serif, "";
}
</style>
</head>
<body>
  
<script src="Scripts/login.js" type="text/javascript"></script>

<%--<script src="https://www.12306.cn/otsweb/login.js?version=5.85" type="text/javascript"></script>--%>
<script type="text/javascript">
    $(document).ready(function () {
        $("#refundFlag").val('Y');
    });
    var ctx = '/otsweb';
</script>

<div class="conWrap">

    	<form name="loginForm" id="loginForm" method="post" action="https://dynamic.12306.cn/otsweb/loginAction.do?method=login">

<input type="hidden" name="loginRand" id="loginRand" value="<%=loginRand %>"/>
<input type="hidden" name="refundLogin" id="refundLogin" value="N" />
<input type="hidden" name="refundFlag" id="refundFlag" value="Y" />
<input type="hidden" name="nameErrorFocus" id="nameErrorFocus" value="" />
<input type="text" name="loginUser.user_name" value="tamny@sohu.com" id="UserName" style=" width:220px;" class="input_txt"/> <br />
<input type="password" name="user.password" value="" id="password" style=" width:220px;" class="input_txt"/><br />
<input type="hidden" name="passwordErrorFocus" id="passwordErrorFocus" value="" />
<input type="text" name="randCode" maxlength="4" value="" id="randCode" style="width:110px;" class="input_txt"/><img height="26" src="https://dynamic.12306.cn/otsweb/passCodeAction.do?rand=sjrand"
													onclick="this.src=this.src+'&'+Math.random();"
													title="单击刷新验证码" id="img_rrand_code"/>
<br />
<input type="hidden" name="randErrorFocus" id="randErrorFocus" value="" />
<input type="checkbox" style="line-height: 15px;" name="refundLoginCheck" id="refundLoginCheck" value="N" /><br />
<input type="submit" value="登陆" /><br />
<a style="z-index: 10000;" href="javascript:;" class="button_a"
onclick="checkAysnSuggest();" id="subLink"><span><ins>登录</ins>
</span> </a> <a href="registAction.do?method=findPwdInit"
class="bluetext"><u>忘记用户名/密码？</u> </a>  </form>


<script type="text/javascript">
   // $("#randCode").val("");
    $("#password").val("_tamny2tamny_");
</script>
</body>
</html>
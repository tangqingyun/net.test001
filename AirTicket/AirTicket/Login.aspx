 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 
 
 
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
    <script src="jquery-1.4.2.min.js"></script>
<%--<script src="https://www.12306.cn/otsweb/jquery-1.4.2.min.js" type="text/javascript"></script>

<script src="Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>--%>
 
<script type="text/javascript">
    $(document).ready(function () {
        if (parent.notLogin == undefined) {
            //   parent.location='/otsweb' + '/main.jsp';
            return;
        }
        var isHide = "false";
        if (isHide == "true") {
            if (parent.hideMenu) {
                //parent.hideMenu();
            }
        } else {
            if (parent.showMenu) {
                parent.showMenu();
            }
        }
        var clicktitle = '登录';
        if (parent.clickMenu && clicktitle !== '') {
            parent.clickMenu('登录');
        }


        var isLogin = false
        var u_name = '';
        if (isLogin) {
            parent.hasLogin(u_name);
        } else {
            parent.notLogin();
        }
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
  
   <a href="C:\Users\Administrator\Desktop\Login\fdsafdsafdsf.html" >12306登陆</a>

<%--<script src="https://www.12306.cn/otsweb/login.js?version=5.85" type="text/javascript"></script>--%>
<script type="text/javascript">
    $(document).ready(function () {
        $("#refundFlag").val('Y');
    });
    var ctx = '/otsweb';
</script>

<div class="conWrap">
	<!--header -->
 
	<!--header end-->
	<!--con -->
	<div class="enter_w">
		<div class="enter_top">
			<div class="enter_left">
				<div class="enter_from">
					<ul>
						<li class="enter_logo"><img
							src="https://dynamic.12306.cn/otsweb/images/enter_font1.jpg" /></li>
						<form name="loginForm" id="loginForm" method="post" action="https://dynamic.12306.cn/otsweb/loginAction.do?method=login">
							<li><table width="100%" border="0" cellspacing="0"
									cellpadding="0">
									<input type="hidden" name="loginRand" id="loginRand"
										value="" />
									<input type="hidden" name="refundLogin" id="refundLogin"
										value="" />
									<input type="hidden" name="refundFlag" id="refundFlag"
										value="Y" />
									<tr>
										<td width="71">登录名：</td>
										<td width="236"><input type="text" name="loginUser.user_name" value="tamny@sohu.com" id="UserName" style=" width:220px;" class="input_txt"> <br /> <span
											class="login_error" id="nameSpan"></span> <input
											type="hidden" name="nameErrorFocus" id="nameErrorFocus"
											value="" /></td>
										<td width="143">&nbsp;</td>
									</tr>
									<tr>
										<td>密&nbsp;&nbsp;&nbsp;码：</td>
										<td><input type="password" name="user.password" value="" id="password" style=" width:220px;" class="input_txt"/> <br /> <span
											class="login_error" id="passwordSpan"></span> <input
											type="hidden" name="passwordErrorFocus"
											id="passwordErrorFocus" value="" /></td>
										<td>&nbsp;</td>
									</tr>
									<tr>
										<td>验证码：</td>
										<td><div class="yz_left" style="">
												<input type="text" name="randCode" maxlength="4" value="" id="randCode" style="width:110px;" class="input_txt">
												<input type="hidden" name="randErrorFocus"
													id="randErrorFocus" value="" />
											</div>
											<div class="yz_r">
												<img height="26" src="https://dynamic.12306.cn/otsweb/passCodeAction.do?rand=sjrand"
													onclick="this.src=this.src+'&'+Math.random();"
													title="单击刷新验证码" id="img_rrand_code"></img>
											</div></td>
										<td><a href="#" onclick="javascript:refreshImg();"
											class="bluetext"><u>看不清，换一张</u> </a></td>
									</tr>
 
									
										<tr>
											<td style="line-height: 15px;">&nbsp;</td>
											<td colspan="2" style="line-height: 15px;"><font
												size="1">每日7:00-23:00办理购票、改签和退<br/>
												票等业务，并不晚于开车前2小时。
											</font> <br>
											
											
												<div style="padding-top: 4px;">
 
													
													
														<input type="checkbox" style="line-height: 15px;"
															name="refundLoginCheck" id="refundLoginCheck" value="Y" />
													
													退票登录 <font size="1"><font>&nbsp;&nbsp;</font>
														仅限退票使用</font>
												</div>
												</td>
										</tr>
 
										<tr>
											<td style="line-height: 20px;">&nbsp;</td>
											<td style="line-height: 20px;"><span style="color: red;"
												id="randCodeSpan"></span> </td>
											<td style="line-height: 20px;">&nbsp;</td>
										</tr>
									
 
									
 
									<tr>
										<td>&nbsp;</td>
										<td >
                                            <input type="submit" value="登陆" />
                                            <a style="z-index: 10000;" href="javascript:;" class="button_a"
											onclick="checkAysnSuggest();" id="subLink"><span><ins>登录</ins>
											</span> </a> <a href="registAction.do?method=findPwdInit"
											class="bluetext"><u>忘记用户名/密码？</u> </a></td>
										<td></td>
									</tr>
 
								</table></li>
						</form>
					</ul>
				</div>
			</div>
		
		</div>
	</div>
</div>

<script type="text/javascript">
    $("#randCode").val("");
    $("#password").val("_tamny2tamny_");
</script>
</body>
</html>


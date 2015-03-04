<%@ Page Language='C#' AutoEventWireup='true' CodeBehind='gewara.aspx.cs' Inherits='AirTicket.gewara' %>

<!DOCTYPE html>

<html xmlns='http://www.w3.org/1999/xhtml'>
<head runat='server'>
<meta http-equiv='Content-Type' content='text/html; charset=utf-8'/>
    <title>格瓦拉-登陆</title>
  <script src='jquery-1.4.2.min.js'></script>
    <script type="text/javascript">
        $(function () {

            //alert(new Date().getTime());
            //$("http://www.gewara.com/getCaptchaId.xhtml?r=" + new Date().getTime(),function (data) {
            //    alert(data);
            //});

            //$('#loginForm').submit();
            //$("#sbmit").click(function () {
            //    //var code = $("input[name=captcha]").val();
            //    //$.post("gewara.aspx", { "dopost": "validate", "code": code }, function (data) {
            //    ////    alert(data);
            //    //});
            //   // return false;
            //});
        });
        </script>
</head>
<body>
    <!--action='http://www.gewara.com/cas/check_user.xhtml' -->

   <form method='post' id='loginForm' action="http://www.gewara.com/cas/check_user.xhtml">
<input type='hidden' name='TARGETURL' value='/'/>
<div class='info_list'>
<label class='username'>
用户名：<input class='G_input' type='text' value='15901473139' name='j_username'/>
</label>
</div>
<div class='info_list'>
<label class='password'>
密码：<input class='G_input' type='password' value='tangqingyun' name='j_password'/>
</label>
</div>
<div class='info_list clear'>
<input type='hidden' name='captchaId' value='<%=random%>' />
<label class='verify'>
验证码：<input type='text' class='G_input captcha'  name='captcha' />
</label>
<img id='myLoginCaptchaImg' width='80' height='30' src='http://www.gewara.com/captcha.xhtml?captchaId=<%=random%>&r=1372816880881'  onclick='refreshCaptcha(this)'  style='cursor: pointer;border:1px solid #ccc;'  alt='看不清楚，请点击换一张图片'/>
</div>
<%-- <input type="hidden" name="success"  value="false" />--%>
<input type='submit' value='登&nbsp;&nbsp;&nbsp;录' name="submit" class='W_btn_g' id='sbmit'/>

       
					
</form>

 


<script type='text/javascript'>
    var random = "<%=random%>";
    function refreshCaptcha(obj)
    {
        obj.src = "http://www.gewara.com/captcha.xhtml?captchaId=" + random + "&r=" + new Date().getTime();
    }
</script>

</body>
</html>

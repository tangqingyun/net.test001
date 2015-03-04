<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EjoyLogin.aspx.cs" Inherits="AirTicket.LoginPage.EjoyLogin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
  
    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <%--<script src="../Scripts/BizLogin.js" type="text/javascript"></script>--%>
    <script type="text/javascript">


        $(function () {
            $("#LoginForm").submit();
            alert("登陆成功！");
            location.href = "/LoginPage/EjoyStep1.aspx";
            //Biz.Login.Register.Demo();
            //Biz.Login.AZLoginCheck.Check();
            //$.ajax({
            //    url: "http://secure.ejoy365.com/Customer/Login.aspx?ReturnUrl=http%3a%2f%2fsecure.ejoy365.com%2fRecharge%2fRechargeStep1.aspx",
            //    type: "POST",
            //    data: { "action": "Get", "name": "qingyun", "pwd": "123456" },
            //    async: true,
            //    beforeSend: function () {
            //        //alert("beforeSend");
            //    },
            //    success: function (result) {
            //        //alert(result);
            //    },
            //    complete: function () {
            //        //alert("complete");
            //    },
            //    error: function (XMLHttpRequest, textStatus, errorThrown) {
            //        //alert(errorThrown);
            //    }
            //});

            //var datas = { "cardNumber": "1000113200006467035", "areaID": "32", "areaID": "32", "areaName": "%u6C5F%u82CF", "mobilePhone": "13260184476", "orderAmt": "100", "payTypeSysNo": "67" };
            //$.post("http://secure.ejoy365.com/recharge/RechargeStep2.aspx", datas, function (data) {
            //    alert(data);
            //});

        });

    </script>
</head>
<body>
    <form  method="post" action="http://secure.ejoy365.com/Customer/Login.aspx?ReturnUrl=http%3a%2f%2fsecure.ejoy365.com%2fRecharge%2fRechargeStep1.aspx" id="LoginForm" style="display:none;">
     <input type="hidden" id="action" name="action" value="Get" />
     <table>
         <tr>
             <td>您的用户名：</td>
             <td><input  type="text" name="name" value="kfc"/></td>
         </tr>
            <tr>
             <td>您的密码：</td>
             <td><input  type="text" name="pwd" value="000000"/></td>
         </tr>
     </table>
    </form>
</body>
</html>

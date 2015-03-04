<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EjoyStep1.aspx.cs" Inherits="AirTicket.LoginPage.EjoyStep1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../Scripts/jquery-1.7.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#NextStep").click(function () {
                $("#Form1").submit();
            });
           
        });

    </script>
</head>
<body>
    

    <form id="Form1" action="http://secure.ejoy365.com/recharge/RechargeStep2.aspx" method="post">
        <input type="hidden" name="areaName" value="江苏" />
       <table style="margin:0 auto;width:80%">
           <tr>
               <td align="right">选择地区：</td>
               <td><select id="area" name="areaID" class="input147">            
                    <option value='11'>北京</option>                
                    <option value='37'>山东</option>                
                    <option value='31'>上海</option>                
                    <option value='53'>云南</option>                
                    <option value='41'>河南</option>                
                    <option value='51'>四川</option>                
                    <option value='44'>广东</option>                
                    <option value='90'>深圳</option>                
                    <option value='32' selected="selected">江苏</option>                
                    <option value='42'>湖北</option>                
                    <option value='13'>河北</option>                
                    <option value='36'>江西</option>                
                    <option value='46'>海南</option>                
                    <option value='34'>安徽</option>                
                    <option value='45'>广西</option>                
                    <option value='35'>福建</option>                
                    <option value='52'>贵州</option>                
                    <option value='14'>山西</option>                
                    <option value='12'>天津</option>                
        </select></td>
           </tr>

            <tr>
               <td align="right">加油卡号：</td>
               <td><input id="cardNumber" name="cardNumber" type="text" maxlength="19" value="1000113200006467035" /></td>
           </tr>

            <tr>
               <td align="right">手机号：</td>
               <td><input id="mobilePhone" name="mobilePhone" type="text" class="input147" value='13260184476' />（到账短信通知）</td>
           </tr>

            <tr>
               <td align="right">充值金额：</td>
               <td><select id="orderAmt" name="orderAmt" class="input147">            
                    <option value='100'>100元</option>                
                    <option value='200'>200元</option>                
                    <option value='500'>500元</option>                
                    <option value='800'>800元</option>                
                    <option value='1000'>1000元</option>                
                    <option value='1500'>1500元</option>                
                    <option value='2000'>2000元</option>                
                    <option value='2500'>2500元</option>                
                    <option value='3000'>3000元</option>                
                    <option value='5000'>5000元</option>                
                    <option value='10000'>10000元</option>                
                    <option value='20000'>20000元</option>                
                    <option value='50000'>50000元</option>                
        </select></td>
           </tr>

           <tr>
               <td align="right">支付方式：</td>
               <td><input type="radio" name="payTypeSysNo" value="67" checked="checked" />在线支付(暂不支持交行)
            <input type="radio" name="payTypeSysNo" value="74" />山东石油VIP卡</td>
           </tr>

           <tr>
               <td colspan="2" align="center"><br /><input type="button" value="下一步" id="NextStep" style="width:100px;"/></td>
           </tr>
       </table>


    <dl>
        <dd>
            <p>验证码<input id="validateCode" name="validateCode" type="text" /><img id="validatorImage" src="http://secure.ejoy365.com/Common/ImageValidator.aspx?Type=register" height="26px" width="73px"  class="fl" /><a id="changeValidateCode" class="word_blue" href="javascript:void(0);">看不清？</a></p>
            
        </dd>
    </dl>
    </form>
</body>
</html>

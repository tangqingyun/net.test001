<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberInfo.aspx.cs" Inherits="AirTicket.MemberInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        table {
        border-collapse:collapse;border:1px solid blue;width:80%;}
        td {font-size:13px;padding:2px;
        border:1px solid #ccc;}
        .infoone td {
        padding:10px 0px;border:none;}
        .minfo {
       padding:8px; border:none;}
    </style>
</head>
<body>


<table>

<tr><td colspan="4">会员基本信息</td></tr>

<tr>
        <td   class="minfo" >
            <table style="width:100%;">
                 <tr class="infoone">
                    <td>会员卡号：4654654645【车友会金卡】</td>
                    <td>卡激活时间：2013/6/20 10:25:26</td>
                    <td>最后呼入时间：2013/6/25 10:00:00</td>
                    <td><input type="button" value="修改客户信息" /></td>
                </tr>
            </table>
        </td>

    </tr>



<tr>
   <td class="minfo" >
     <table style="width:100%;">
        <tr>
            <td rowspan="4" width="10%" align="center">
                张小然<br/>女 26岁
     </td>
        </tr>
         <tr>
             <td>手机号：13800138000</td>
             <td>证件类型：身份证</td>
             <td>证件号：110106199901075129</td>
             <td>邮箱：zhangxiaoran@uni2uni.co</td>
         </tr>

            <tr>
             <td>公司：联嘉云</td>
             <td>职位：产品经理</td>
             <td>地址：北京市朝阳区东三环中路82号金长安大厦C座17层</td><td>邮编：10010</td>
         </tr>

            <tr>
             <td>银行卡卡号：4816990002043832</td>
             <td>所属银行：中国银行</td>
             <td>有效期：02/15</td>
                <td>验证码：88</td>
         </tr>
    </table>

            </td>
        </tr>


<tr>
   <td class="minfo" >
     <table style="width:100%;">
       <tr><td colspan="4">会员服务</td></tr>
         <tr>
             <td>
                 <ul>
                     <li>机票</li>
                     <li>火车票</li>
                     <li>酒店</li>
                     <li>租车</li>
                     <li>购物服务</li>
                     <li>电影票</li>
                 </ul>

             </td>
         </tr>
    </table>

            </td>
        </tr>
</table>





    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>

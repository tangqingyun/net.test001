<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeftClubOrderDetail.aspx.cs" Inherits="AirTicket.MYCard.LeftClubOrderDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>生活会服务订单详情</title>
    <style type="text/css">
        table {
        width:90%;margin:0 auto; border-collapse:collapse}
        table td {
        border:1px solid #ccc;padding:3px;}

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table>
         <tr>
             <td colspan="8">订单信息</td>
         </tr>

          <tr>
             <td>预订单号：</td>
              <td>21545645694</td>
              <td>订单号：</td>
              <td>51355004897</td>
              <td>订单状态：</td>
              <td>执行中</td>
         </tr>
     </table>

        <table>
         <tr><td colspan="8">会员信息</td></tr>
          <tr>
             <td>姓名：</td>
              <td>21545645694</td>
              <td>手机号码：</td>
              <td>51355004897</td>
              <td>Email：</td>
              <td>执行中</td>
              <td>收货城市：</td>
              <td>执行中</td>
         </tr>
     </table>

         <table>
         <tr><td colspan="8">功能操作</td></tr>
          <tr>
             <td><input type="button" value=" 退出 " /></td>
         </tr>
     </table>

        <table>
         <tr><td colspan="8">订单执行</td></tr>
          <tr>
            <td>执行月份</td>
           <td>需执行日期</td>
           <td>商品名称</td>
           <td>执行类型</td>
           <td>执行状态</td>
           <td>执行人</td>
           <td>执行时间</td>
           <td>操作</td>
         </tr>
            <% for(int i=0;i<10;i++) { %>
           <tr>
               <td>2013-6</td>
               <td></td>
               <td></td>
               <td></td>
               <td></td>
               <td></td>
               <td></td>
               <td></td>
          </tr>
            <%} %>

     </table>

        <table>
         <tr><td colspan="8">工单记录</td></tr>
            <tr>
                <td colspan="8">
                    <input type="button" value="新建工单" />
                    全部工单(100) <a href="#">未结案工单</a>

                </td></tr>
          <tr>
            <td>操作</td>
           <td>工单编号</td>
           <td>工单分类</td>
           <td>内容描述    </td>
           <td>处理意见</td>
           <td>工单状态</td>
           <td>处理人</td>
           <td>记录时间</td>
         </tr>
     

     </table>

    </form>
</body>
</html>

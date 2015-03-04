<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LifeClubOrderList.aspx.cs" Inherits="AirTicket.MYCard.LifeClubOrderList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>生活会服务订单列表</title>
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
             <td colspan="8">生活会服务订单</td>
         </tr>

          <tr>
             <td>订单号：</td>
              <td><asp:TextBox ID="tbOrderID" runat="server"></asp:TextBox></td>
              <td>会员卡卡号：</td>
              <td><asp:TextBox ID="tbMemCardId" runat="server"></asp:TextBox></td>
              <td>姓名：</td>
              <td><asp:TextBox ID="tbName" runat="server"></asp:TextBox></td>
              <td>手机号码：</td>
              <td><asp:TextBox ID="tbPhone" runat="server"></asp:TextBox></td>
         </tr>
        
           <tr>
             <td>激活时间：</td>
              <td>
                  <asp:TextBox ID="tbActiveStartDatetime" runat="server" Width="80"></asp:TextBox>
                  -<asp:TextBox ID="tbActiveEndDatetime" runat="server" Width="80"></asp:TextBox>
              </td>
              <td>收货城市：</td>
              <td><asp:TextBox ID="tbCity" runat="server"></asp:TextBox></td>
              <td>执行次数：</td>
              <td><asp:TextBox ID="tbTime" runat="server"></asp:TextBox></td>
              <td>需执行日期：</td>
              <td> <asp:TextBox ID="tbExecuteSTime" runat="server" Width="80"></asp:TextBox>
                  -<asp:TextBox ID="tbExecuteETime" runat="server" Width="80"></asp:TextBox></td>
         </tr>

           <tr>
             <td>订单状态：</td>
              <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
              <td>占用人：</td>
              <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
              <td colspan="4" align="right">
                  <input type="button" value=" 查询 "/>&nbsp;&nbsp;
                  <input type="button" value=" 重置 "/>&nbsp;&nbsp;
              </td>
         </tr>

     </table>

        <table style="margin-top:10px;">
            <tr>
                <td>排序：
                    <asp:DropDownList ID="ddl_sort" runat="server">
                        <asp:ListItem>激活时间</asp:ListItem>
                    </asp:DropDownList>
                      <asp:DropDownList ID="ddl_order" runat="server">
                        <asp:ListItem>升序</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;
                    每页显示：
                    <asp:DropDownList ID="ddl_size" runat="server">
                        <asp:ListItem>20</asp:ListItem>
                    </asp:DropDownList>

                </td>
            </tr>
        </table>

        <table style="margin-top:10px;">
            <tr>
                <td>订单号</td>
                <td>会员卡卡号</td>
                <td>姓名</td>
                <td>手机号码</td>
                <td>激活时间</td>
                <td>收货城市</td>
                <td>执行次数</td>
                <td>需执行日期</td>
                <td>订单状态</td>
                <td>占用人</td>
                <td width="10%">操作</td>
            </tr>

            <% for(int i=0;i<10;i++) { %>
            <tr>
                <td>300303</td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td>
                    <input type="button"  value="查看" />&nbsp;&nbsp;
                    <input type="button"  value="占用" />
                </td>
            </tr>
            <%} %>
        </table>

    </form>
</body>
</html>

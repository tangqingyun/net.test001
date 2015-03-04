<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestGoodsDataInsert.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        table {
            border-collapse:collapse;
            border:1px solid #808080;width:80%;margin:0 auto;}
            table tr td {border:1px solid #808080; font-size:13px;
            }
        p {
        padding:0px;margin:0px;margin-top:2px;}
    </style>
</head>
<body>
    <table>
        <tr>
            <td>ID</td>
            <td>商品名称</td>
            <td>商品编码</td>
            <td>产品分类编码</td>
            <td>产品分类名称</td>
        </tr>

        <%
            if (dt != null) {
            for (int i = 0; i < dt.Rows.Count;i++ )
            {
                if (i == 0)
                    continue;
             %>
        <tr>
            <td><%=(i).ToString() %></td>
            <td><%=dt.Rows[i][0] %></td>
            <td><%=dt.Rows[i][1] %></td>
            <td><%=dt.Rows[i][2] %></td>
            <td><%=dt.Rows[i][3] %></td>
        </tr>
        <% } }%>
    </table>
</body>
</html>

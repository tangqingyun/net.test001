<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsDataImport.aspx.cs" Inherits="TestGoodsDataInsert.GoodsDataImport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        table { margin:0 auto;
        border-collapse:collapse;}
        table td {
        border:1px solid #ccc;padding:2px;font-size:13px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
      <table>
          <tr>
              <td>ID</td>
              <td>商品名称</td>
              <td>商品CODE</td>
              <td>产品名称</td>
              <td>品牌名称</td>
              <td>产品分类属性数量</td>
              <td>操作</td>
          </tr>
          <asp:Repeater ID="BindData" runat="server">
              <ItemTemplate>
                   <tr>
                      <td><%#Container.ItemIndex+1 %></td>
                      <td><%#Eval("GoodName") %></td>
                      <td><%#Eval("GoodCode") %></td>
                      <td><%#Eval("ProductName") %></td>
                      <td><%#Eval("BrandName") %></td>
                      <td align="center"><%#Eval("ProductCategoryRelNum") %></td>
                      <td>
                          <input type="button" class="btn" value="创建商品参数" code="<%#Eval("GoodCode") %>"/>
                      </td>
                  </tr>
              </ItemTemplate>
          </asp:Repeater>
         

      </table>
    </form>
    <script src="Script/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".btn").click(function () {
                var code = $(this).attr("code");
                alert(code);
            });
        });
    </script>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BankTerminfo.aspx.cs" Inherits="TestGoodsDataInsert.BankTerminfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="LoadInfo" Text="加载银行终端数据" runat="server" OnClick="LoadInfo_Click" /> &nbsp;&nbsp;
    <asp:DropDownList ID="bindData" runat="server"></asp:DropDownList>
    </div>
    </form>
</body>
</html>

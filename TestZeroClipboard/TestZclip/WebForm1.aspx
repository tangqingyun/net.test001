<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TestZclip.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="jquery-1.6.2.min.js"  type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <p id="content">7879798</p>
    <div>
    <input type="button" id="copy-button" value=" Copy " />
    </div>
    </form>

    <script type="text/javascript">
        
        //纯js操作剪贴板
        $(function () {        
            $("#copy-button").live("click", function () {             
                clipboardData.setData("Text", $("#content").text());
                alert($("#content").text());
            });
            
        });
    </script>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AutoLogin.aspx.cs" Inherits="AirTicket.AutoLogin"  ResponseEncoding="gb2312"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312"/>
    <title>�Զ���½</title>
    <script src="jquery-1.4.2.min.js" type="text/javascript"></script>
</head>
<body>
    <%
        string str = Regex.Match("15864602", "/^[0-9]*$/").Value;
        Response.Write(str);
         %>
    <div style="width:90%; margin:0 auto;">
        <p style="text-align:left;">
            <input type="button" value ="һ�Ե�½" id="etao"/>&nbsp;&nbsp;
            <input type="button" value ="Я�̵�½" id="ctrip"/>&nbsp;&nbsp;
            <input type="button" value ="�׵��ó�" id="yongche"/>&nbsp;&nbsp;
            <input type="button" value ="��������½" id="gewara"/>&nbsp;&nbsp;
            <input type="button" value ="12306��½" id="12306"/>&nbsp;&nbsp;
            <input type="button" value ="�׽ݳ�ֵ" id="ejoy"/>&nbsp;&nbsp;
        </p>
        <div>
            <iframe id="iframeid"  name="iframeid" src="etao.aspx" width="100%" height="600px"></iframe>
        </div>
    </div>
    <script type="text/javascript">

        $(function () {

            $("input[type='button']").click(function () {
                var name = $(this).attr("id");
                switch (name) {
                    case "etao":
                        $("#iframeid").attr("src", "etao.aspx");
                        break;
                    case "ctrip":
                        $("#iframeid").attr("src", "xiecheng.aspx");
                        break;
                    case "yongche":
                        $("#iframeid").attr("src", "yongche.aspx");
                        break;
                    case "gewara":
                        $("#iframeid").attr("src", "gewara.aspx");
                        break;
                    case "12306":
                        $("#iframeid").attr("src", "12306.aspx");
                        break;
                    case "ejoy":
                        window.open("/LoginPage/EjoyLogin.aspx");
                        //$("#iframeid").attr("src", "");
                        break;
                    default:

                }
            });

        });

    </script>
</body>
</html>

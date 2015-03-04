<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Uni2UniDownLoad.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="jquery-1.6.2.min.js"  type="text/javascript"></script>
    
</head>
<body>

<iframe id="Uni2Uni" name="Uni2Uni" src="Uni2Uni.aspx" style="border: 1px solid red; width: 95%; height: 600px; margin-top: 20px;" onload="funload(this);"></iframe>

    <script type="text/javascript">
    
        $(function () {
            document.domain = "uni2uni.com";
        });

        function funload(obj) {
            //window.frames["Uni2Uni"].document.domain = "uni2uni.com";
            var links = $(window.frames["Uni2Uni"].document).find("a");
            alert(links.length);
            links.click(function () {
                var link = $(this).attr("href").replace("product.uni2uni.com", "localhost:6417");
                alert(link);
                //location.href = $(this).attr("href");
            });
           // alert("dddddd");
            //links.click(function () {
            //    alert($(this).attr("href"));
            //    return false;
            //});

            //  alert($(obj).attr("src"));
        }

    </script>
</body>
</html>

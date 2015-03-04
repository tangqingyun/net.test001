<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestZborad.aspx.cs" Inherits="TestZclip.TestZborad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="/ZeroClipboard/jquery-1.5.1.min.js"></script>
    <script type="text/javascript" src="/ZeroClipboard/ZeroClipboard.js"></script>
    
</head>
<body>
    <input class="btncopy" id="btncopy1" type="button" value="copy1868" />
    <input class="btncopy" id="btncopy2" type="button" value="copy2cc" />
    <input class="btncopy" id="btncopy3" type="button" value="copy3c" />
    <input class="btncopy" id="btncopy4" type="button" value="copy4e" />
    <input class="btncopy" id="btncopy5" type="button" value="copy589" />
    <input class="btncopy" id="btncopy6" type="button" value="copy6555555555" />
    <br /><br />
    <textarea name="disConten" id="disConten" cols="50" rows="5" ></textarea>
    <script type="text/javascript">

        $(function () {
            //设置ZeroClipboard.swf的路径    
            ZeroClipboard.setMoviePath("ZeroClipboard/ZeroClipboard.swf");
            
            $("input[id^=btncopy]").each(function () {

                var obj = $(this);
                var clip = new ZeroClipboard.Client();
                clip.setHandCursor(true);

                var id = obj.attr("id");
                var content = obj.val();
                clip.setText(content);
                clip.glue(id);

                clip.addEventListener("onMouseOver", function (client) {
                    //  alert(client.id);  //client 这个句柄会得到一个剪贴板对象作为参数
                });
               

                //这个是复制成功后的提示      
                clip.addEventListener('complete', function (client, text) {
                    $("#disConten").text(text);
                  //  alert('以下地址已成功复制到剪贴板：' + text);
                });
                
            });

        });

    </script>
</body>
</html>

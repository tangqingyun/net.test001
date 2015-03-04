<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Zborad.aspx.cs" Inherits="TestZclip.ZeroClipboard.Zborad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" src="jquery-1.5.1.min.js"></script>
	<script type="text/javascript" src="ZeroClipboard.js"></script>
    	<style type="text/css">
		body { font-family:arial,sans-serif; font-size:9pt; }
		
		div.multiple {
			float: left;
			background-color: white;
			width:200px; height:200px;border:1px solid red;
			border:1px solid #ccc;
			margin:5px;
			cursor: pointer;
			font-size: 14pt;
		}
		
		div.multiple.hover {
			background-color: #ddd;
		}		
	</style>

</head>
<body>
<input class="btncopy" type="button" value="copy1" copytext="复制的内容1" />
<input class="btncopy" type="button" value="copy2" copytext="复制的内容2" />
<input class="btncopy" type="button" value="copy3" copytext="复制的内容3" />
<input class="btncopy" type="button" value="copy4" copytext="复制的内容4" />
<input class="btncopy" type="button" value="copy5" copytext="复制的内容5" />
<input class="btncopy" type="button" value="copy6" copytext="复制的内容6" />

<div class="multiple"></div>

    <script type="text/javascript">
        var clip = null;
        $(function () {
            clip = new ZeroClipboard.Client();
            clip.setHandCursor(true);

            $('.btncopy').mouseover(function () {
                var content = $(this).val();             
                clip.setText(content);

              
                if (clip.div) {
                    clip.receiveEvent('mouseout', null);
                    clip.reposition(this);
                }
                else {
                    clip.glue(this);
                }

                clip.receiveEvent('mouseover', null);
                clip.addEventListener('complete', function (client, text) {
                    alert('以下地址已成功复制到剪贴板：' + text);
                });
                return false;
            });
        });


	</script>

</body>
</html>

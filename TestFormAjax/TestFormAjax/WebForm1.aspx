<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TestFormAjax.WebForm1" EnableViewState="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="jquery.form.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" method="post" action="WebForm1.aspx">
     <p><input type="text" name="name" value="" /></p>
     <p><input type="text" name="pwd" value="" /></p>
     <p>
         <input type="radio" name="rad" value="0" /> 是
         <input type="radio" name="rad" value="1" /> 否

     </p>
     <p>
         <input type="hidden" name="dopost" value="true" />
         <input type="submit" name="" value="提交" /></p>

    </form>
    <div id="upbox"></div>
    <script type="text/javascript">
        $(function () {
            var a = [0];
            b = a;
            b[0] = 2;
            alert(b+a);

            $("#form1").submit(function () {
               
                $(this).ajaxSubmit({
                    target: "#upbox", //指明页面中由服务器响应进行更新的元素 默认值：null
                    //url: "",//指定提交表单数据的URL 默认值：表单的action属性值
                    //type: "post",//指定提交表单数据的方法（method）：“GET”或“POST”。
                    //dataType:"",//期望返回的数据类型。null、“xml”、“script”或者“json”其中之一
                    beforeSubmit: function () {
                       // alert("提交前");
                    },
                    success: function (data) {
                        alert(data);
                    }
                });

                return false;
            });
        });

    </script>
</body>
   
</html>

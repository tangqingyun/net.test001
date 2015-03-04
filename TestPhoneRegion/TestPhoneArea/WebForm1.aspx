<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TestPhoneArea.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <%--<script src="jquery-1.6.2.min.js" type="text/javascript"></script>--%>
  
    <script src="jquery-1.7.1.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
    <%
      //  string unicodeBytes = "\u6e56\u5357";//"\u90b5\u9633"
       // string sss = "\u90b5\u9633";
        //var barray = System.Text.Encoding.GetEncoding("").GetBytes(unicodeBytes);
      string str="{\"code\":1,\"data\":{\"province\":\"\u6e56\u5357\",\"city\":\"\u90b5\u9633\",\"sp\":\"\u79fb\u52a8\"}}";
    //  string pattern = ""\"[^\"]*""";//<b>[\s\S]*?</b>
     // 
     // string  state=str.Substring(str.IndexOf(":")+1,1);
      //Response.Write(unicodeBytes);
    
     // string pattern = @"""[\s\S]*?""";
     // MatchCollection mc = Regex.Matches(str, pattern, RegexOptions.IgnoreCase);
    //  Response.Write(mc[0].Value);
       
        //Response.Write(HttpUtility.UrlDecode(unicodeBytes));
        //char[] asciiChars = new char[Encoding.Unicode.GetCharCount(unicodeBytes, 0, unicodeBytes.Length)]; 
        //Encoding.Unicode.GetChars(unicodeBytes, 0, unicodeBytes.Length, asciiChars, 0); string asciiString = new string(asciiChars);
        
         %>
    <script type="text/javascript">

        $(function () {
           
          
            var json = { "code": 0, "data": { "province": "", "city": "\u5317\u4eac", "sp": "\u8054\u901a" } };
            //alert(json.data.city);
         
            //$("body").append(json.data.province);
         
            // { "Province": "\"\\u5317\\u4eac\"", "City": "\"\\u5317\\u4eac\"", "Town": "", "TelePhone": "18611772708" }
          
            try {

            } catch (error) {

            }
          
            //$.getJSON("http://cx.shouji.360.cn/phonearea.php?number=15273919791&callback=?",function (result) {
            //   alert(result.data);
            //});

            //$.ajax({
            //    url: "http://cx.shouji.360.cn/phonearea.php?number=15273919791&callback=?",
            //    dataType: "jsonp",
            //    jsonpCallback: "person",
            //    success: function () {
            //        //alert(data.name + " is a a" + data.sex);
            //    }
            //});

                       
            //var url = "http://cx.shouji.360.cn/phonearea.php";
            //$.get("http://cx.shouji.360.cn/phonearea.php", { number: "15273919791" }, function (result) {
            //       alert(result);
            //       if (result.code == '0') {
            //           // $('#phoneinfo').html(result.data.province + ' ' + result.data.city + ' ' + result.data.sp);
            //           alert(result.data.province);
            //       }
            //       else {
            //           // $('#phoneinfo').html('未知');
            //       }
            //   });
          
        });


    </script>
</body>
    
</html>

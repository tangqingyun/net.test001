<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AutocompleteTest.Default" %>

<%@ Register Src="~/Autocomplete.ascx" TagPrefix="uc1" TagName="Autocomplete" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>    
 <script type="text/javascript" src="jscript/jquery.js"></script>
<%--<script type='text/javascript' src='jscript/jquery.bgiframe.min.js'></script>
<script type='text/javascript' src='jscript/jquery.ajaxQueue.js'></script>
<script type='text/javascript' src='jscript/thickbox-compressed.js'></script>--%>
<script type='text/javascript' src='jscript/jquery.autocomplete.js'></script>
<%--<link rel="stylesheet" type="text/css" href="css/main.css" />--%>
<link rel="stylesheet" type="text/css" href="css/jquery.autocomplete.css" />

    <script type="text/javascript">
        $(function () {

        //    function format(mail) {
        //        return mail.name + " &lt;" + mail.to + "&gt";
        //    }

        //    $("#email").autocomplete('Default.aspx', {
        //        multiple: false,
        //        dataType: "json",
        //        parse: function (data) {
        //            return $.map(data, function (row) {
        //                return {
        //                    data: row,
        //                    value: row.name,
        //                    //result: row.name + " <" + row.to + ">"
        //                    result: row.name
        //                }
        //            });
        //        },
        //        formatItem: function (item) {                   
        //            return item.name;
        //        }
        //    }).result(function (e, item) {
        //        //$("#email").val(item.to);
        //        $("#content").append("<p>selected " +format(item)+ "</p>");
        //    });

        });


    </script>

</head>
<body>
   <%-- <div id="content">
        <form autocomplete="off">
       <label>E-Mail (remote json):</label>
      <input type="text" id="email" size="50" name="email" />
            </form>
    </div>--%>
    <uc1:Autocomplete runat="server" id="Autocomplete" />
</body>
</html>

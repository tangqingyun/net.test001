<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="semo.aspx.cs" Inherits="AirTicket.semo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
       <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
    <script type="text/javascript">

        window.usingNamespace = function (a) {
            var ro = window;
            if (!(typeof (a) === "string" && a.length != 0)) {
                return ro;
            }
            var co = ro;
            var nsp = a.split(".");
            for (var i = 0; i < nsp.length; i++) {
                var cp = nsp[i];
                if (!ro[cp]) {
                    ro[cp] = {};
                };
                co = ro = ro[cp];
            };
            return co;
        };

        usingNamespace("Web.Utils")["Converter"] = {
            ToFloat: function (v) {
                if (!v || (v.length == 0)) {
                    return 0;
                };
                return parseFloat(v);
            },
            Demo: function (message) {
                alert(message);
            }
        };

        Web.Utils.Converter.Demo("dfadfasfdsf");

    </script>
</body>
</html>

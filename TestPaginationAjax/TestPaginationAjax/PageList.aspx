<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageList.aspx.cs" Inherits="TestPaginationAjax.PageList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="pagination/css/pagination.css" rel="stylesheet" />
    <script src="pagination/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="pagination/jquery.ui.pagination.js" type="text/javascript"></script>
</head>
<body>
    <div class="pagination" id="pagination1" style="padding: 0; margin: 0 0 0; font-weight: initial;"></div>

    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
    <script type="text/javascript">
        $(function () {
            $("#pagination1").ajaxPagination(100, 20, 1, "");
        });


        function pageList(pageIndex, pageSize, nopage)
        {
           
        }
    </script>


</body>
</html>

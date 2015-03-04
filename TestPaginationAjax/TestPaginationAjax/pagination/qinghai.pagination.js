jQuery.fn.extend({
    ajaxPagination: function (quantity, pageSize, pageIndex, ajaxFun ) {
        var pageTotal = Math.ceil(quantity / pageSize);
        if (pageTotal == 0)
            pageTotal = 1;
        var pageUtil = 4;
        pageIndex = parseInt(pageIndex);
        //var prevClass = "class='prevnext'";
        //var nextClass = "class='prevnext'";
        if (pageIndex <= 1) {
            pageIndex = 1;
            //prevClass = "class='prevnext disabled'";
        }
        if (pageIndex >= pageTotal) {
            pageIndex = pageTotal;
            //nextClass = "class='prevnext disabled'";
        }

        var pageHtml = "<a href='javascript:" + ajaxFun + "(1," + pageSize +  ");' title=\"首页\">首页</a>";
//        if (pageIndex == 1) {
//            pageHtml += "<a href='javascript:void(0);' title=\"Previous Page\">&laquo; Previous</a>";
//        }
//        else {
//            pageHtml += "<a href='javascript:" + ajaxFun + "(" + (pageIndex - 1) + "," + pageSize +  ");'>&laquo; Previous</a>";
//        }
        var bpage;
        var apage;
        if (pageTotal - pageIndex < pageUtil / 2) {
            bpage = (pageUtil - pageTotal + pageIndex);
            apage = pageUtil - bpage;
        }
        else if (pageIndex <= pageUtil / 2) {
            bpage = pageIndex - 1;
            apage = pageUtil - bpage;
        }
        else {
            bpage = pageUtil / 2;
            apage = pageUtil / 2;
        }
        for (var i = 1; i <= pageTotal; i++) {

            if (i == pageIndex) {
                pageHtml += "<span class=\"disabled\">" + i + "</span>";
            }
            else if ((i >= pageIndex - bpage && i < pageIndex) || (i <= pageIndex + apage && i > pageIndex)) {
                if (i == pageIndex - bpage && pageIndex - bpage > 1) {
                    pageHtml += "...";
                }
                pageHtml += "<a href='javascript:" + ajaxFun + "(" + i + "," + pageSize +  ");' title='" + i + "' >" + i + "</a>";
                if (i == pageIndex + apage && pageIndex + apage < pageTotal) {
                    pageHtml += "...";
                }
            }
        }
//        if (pageIndex == pageTotal) {
//            pageHtml += "<a href='javascript:void(0);' title=\"Previous Page\">Next &raquo;</a>";
//        }
//        else {
//            pageHtml += "<a href='javascript:" + ajaxFun + "(" + (pageIndex + 1) + "," + pageSize +  ");' " + ">Next &raquo;</a>"; //next link HTML
//        }
        pageHtml += "<a href='javascript:" + ajaxFun + "(" + pageTotal + "," + pageSize +   ");' title=\"末页\">末页</a>";
        $(this).html(pageHtml);
    }
})
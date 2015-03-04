using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestPaginationAjax
{
    /// <summary>
    /// PageList1 的摘要说明
    /// </summary>
    public class PageList1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
             


        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
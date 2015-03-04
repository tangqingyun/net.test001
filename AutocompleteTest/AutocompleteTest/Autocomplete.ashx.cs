using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace AutocompleteTest
{
    /// <summary>
    /// Autocomplete1 的摘要说明
    /// </summary>
    public class Autocomplete1 : IHttpHandler
    {

        HttpRequest Request;
        HttpResponse Response;
        IList<ResultData> listData = new List<ResultData>();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Request = context.Request;
            Response = context.Response;

            string action=Request.QueryString["action"];
            string parameter = Request.QueryString["q"];
            if (parameter == null)
                return;

            switch (action.ToLower())
            {
                case "emplyee":
                    listData= LoadEmplyee();
                    break;

            }
            string jsonData = new JavaScriptSerializer().Serialize(listData);
            Response.Write(jsonData);         
        }

      
        public IList<ResultData> LoadEmplyee()
        {
             listData = new List<ResultData>() { 
             new ResultData(){ key=Guid.NewGuid(),name="zhangsan"},
             new ResultData(){ key=Guid.NewGuid(),name="lishi"},
             new ResultData(){ key=Guid.NewGuid(),name="wwww"},
            };
            System.Threading.Thread.Sleep(3000);
            return listData;
        }

        
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class ResultData
    {
        public Guid key { set; get; }
        public string name { set; get; }
    }

}



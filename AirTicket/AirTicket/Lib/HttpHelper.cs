using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirTicket.Lib
{
    public class HttpHelper
    {
        public static string SendPost(string requestUrl) {

            return null;
        }


    }


    public class HttpHeader
    {
        private string contentType;
        public string ContentType
        {
            get { return contentType; }
            set { contentType = value; }
        }

        private string accept;
        public string Accept
        {
            get { return accept; }
            set {
                
                accept = value; 
            }
        }

        private string userAgent;
        public string UserAgent
        {
            get { return userAgent; }
            set { userAgent = value; }
        }

        private string method;
        public string Method
        {
            get { return method; }
            set { method = value; }
        }

        private int maxTry;
        public int MaxTry
        {
            get { return maxTry; }
            set { maxTry = value; }
        }
    }

}
using mshtml;
using SHDocVw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Login51CTO
{

    public class CTO51
    {
        const string LOGIN_URL = "http://home.51cto.com/index.php?s=/Index/index/reback/http%253A%252F%252Fdown.51cto.com";
        const string DOWN_HOME_INDEX = "http://down.51cto.com/";

        /// <summary>
        /// 51CTO网站
        /// </summary>
        /// <returns></returns>
        public static string WO51CTO()
        {
            string msg = string.Empty;
            try
            {
                HTMLDocument doc = IExplorerHelper.GetHTMLDocumentByLocationURL(LOGIN_URL);
                if (doc == null) {
                    return GetDownPeas();
                }
                IHTMLElementCollection inputCollection = doc.getElementsByTagName("input");
                string uname = "tamny@sohu.com";
                string upwd = "tangqingyun";
                HTMLInputElement button = null;
                foreach (HTMLInputElement element in inputCollection)
                {
                    switch (element.name)
                    {
                        case "email":
                            element.value = uname;
                            break;
                        case "passwd":
                            element.value = upwd;
                            break;
                        case "button":
                            button = element;
                            break;
                    }
                }
                if (button != null)
                {
                    button.click();
                    msg = GetDownPeas();
                }
            }
            catch (Exception ex)
            {
                msg= ex.Message;
            }
            return msg;   
        }
        /// <summary>
        /// 领取下载豆
        /// </summary>
        /// <returns></returns>
        private static string GetDownPeas()
        {
            string msg = string.Empty;
            HTMLDocument doc = IExplorerHelper.GetHTMLDocumentByLocationURL(DOWN_HOME_INDEX,5000);
            try
            {
                IHTMLElement ld = doc.getElementById("ld");
                if (ld == null)
                {
                    msg = "您今天已领取过下载豆！";
                }
                else{
                    ld.click();
                    msg = "领豆成功！";
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

    }
}

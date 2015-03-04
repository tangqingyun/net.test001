using mshtml;
using SHDocVw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;


namespace Login51CTO
{
    class Program
    {
        static void Main(string[] args)
        {
             LoginEjoy365();
            RechargeStep1();
            //Console.Write("请输入登陆网站的代号 a(51cto), b(enjoy365) \r\n");
            //string text = Console.ReadLine();
            //string msg = string.Empty;
            //switch (text.ToLower())
            //{
            //    case "a": msg = CTO51.WO51CTO(); break;
            //    default:
            //        break;
            //}
            //Console.Write(msg);
            //Console.ReadKey();
        }

        /// <summary>
        /// 用户登陆
        /// </summary>
        public static void Login()
        {
            string loginUrl = "http://home.51cto.com/index.php?s=/Index/index/reback/http%253A%252F%252Fdown.51cto.com";
            IWebBrowser2 ielogin = new InternetExplorer();
            if (ielogin.ReadyState != tagREADYSTATE.READYSTATE_COMPLETE)
            {
                ielogin.Visible = true;
                object nil = new object();
                ielogin.Navigate(loginUrl, ref nil, ref nil, ref nil, ref nil);
                //try
                //{
                //对 COM 组件的调用返回了错误 HRESULT E_FAIL
                HTMLDocument doc = (HTMLDocument)ielogin.Document;
                HTMLInputElement button = null;
                IHTMLElementCollection inputCollection = doc.getElementsByTagName("input");
                string uname = "";
                string upwd = "";
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
                    Console.WriteLine(uname + ":)登陆成功！");
                }

                // Console.WriteLine("sucess");
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}

            }
            Console.WriteLine("sucess");
        }

        /// <summary>
        /// 领取下载豆
        /// </summary>
        public static void GetDownPeas()
        {
            string homeUrl = "http://down.51cto.com/";
            object nil = new object();
            InternetExplorer iehome = new InternetExplorer();
            iehome.Visible = true;
            iehome.Navigate(homeUrl, ref nil, ref nil, ref nil, ref nil);
            try
            {
                HTMLDocument doc2 = (HTMLDocument)iehome.Document;
                IHTMLElement ld = doc2.getElementById("ld");
                if (ld == null)
                {
                    Console.WriteLine("您今天已领取过下载豆！");
                    return;
                }
                ld.click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //HTMLAnchorElement alink = creditsspan.children() as HTMLAnchorElement;
        }

        public static SHDocVw.InternetExplorer GetWindowObject(String ieWindowName)
        {
            if (ieWindowName == String.Empty || ieWindowName.Equals(""))
            {
                return null;
            }
            SHDocVw.InternetExplorer v_ie = null;
            SHDocVw.ShellWindows sws = new SHDocVw.ShellWindows();
            foreach (SHDocVw.InternetExplorer iew in sws)
            {
                Console.Write(iew.LocationURL + "\r\n");
                //MessageBox.Show(iw.LocationName);
                /*
                 * 将获取到的窗口URL和输入的要控制的部分URl比较，如果包含，则说明此窗口是需要被控制的，将其句柄返回即可。
                 */
                //MessageBox.Show(iew.LocationURL);
                if (iew.LocationURL.Contains(ieWindowName))
                {
                    v_ie = iew;
                }
            }
            return v_ie;
        }

        public static bool Login51CTO()
        {
            SHDocVw.InternetExplorer iew = GetWindowObject("http://home.51cto.com/index.php?s=/Index/index/reback/http%253A%252F%252Fdown.51cto.com");
            HTMLDocument doc = (HTMLDocument)iew.Document;
            HTMLInputElement button = null;
            IHTMLElementCollection inputCollection = doc.getElementsByTagName("input");
            string uname = "tamny@sohu.com";
            string upwd = "tangqingyun";
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
                Console.WriteLine(uname + ":)登陆成功！");
            }
            return true;
        }

        public static bool LoginEjoy365()
        {
            HTMLDocument doc = IExplorerHelper.GetHTMLDocumentByLocationURL("http://secure.ejoy365.com/Customer/Login.aspx?ReturnUrl=http%3a%2f%2fsecure.ejoy365.com%2fRecharge%2fRechargeStep1.aspx");
            HTMLInputElement name = (HTMLInputElement)doc.getElementById("name");
            HTMLInputElement pwd = (HTMLInputElement)doc.getElementById("pwd");
            name.value = "kfc";
            pwd.value = "000000";
            IHTMLElementCollection links = doc.links;
            HTMLLinkElement loginLink = null;
            foreach (HTMLLinkElement a in links)
            {
                string s = a.getAttributeNode("class").nodeValue;
                if (a.getAttributeNode("class").nodeValue == "button buttonB")
                {
                    loginLink = a;
                }
            }
            loginLink.click();
            return true;
        }

        public static bool RechargeStep1()
        {
            System.Threading.Thread.Sleep(1000);
            HTMLDocument doc = IExplorerHelper.GetHTMLDocumentByLocationURL("http://secure.ejoy365.com/Recharge/RechargeStep1.aspx",2000);
            HTMLSelectElement area = doc.getElementById("area") as HTMLSelectElement;
            HTMLInputElement cardNumber = doc.getElementById("cardNumber") as HTMLInputElement;
            HTMLInputElement confirmCardNumber = doc.getElementById("confirmCardNumber") as HTMLInputElement;
            HTMLInputElement mobilePhone = doc.getElementById("mobilePhone") as HTMLInputElement;
            HTMLSelectElement orderAmt = doc.getElementById("orderAmt") as HTMLSelectElement;
            cardNumber.value = confirmCardNumber.value = "1000113200009948300";
            mobilePhone.value = "15901473139";
            HTMLLinkElement next = doc.getElementById("next") as HTMLLinkElement;
            string areaID = "32";
            string amount = "200";

            IExplorerHelper.SelectOptionElement(area, areaID);
            IExplorerHelper.SelectOptionElement(orderAmt, amount);
            
            IHTMLElementCollection inputCollection = doc.getElementsByTagName("input");           
            return true;
        }


    }


}

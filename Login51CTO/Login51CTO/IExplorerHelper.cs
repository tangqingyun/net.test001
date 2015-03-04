using mshtml;
using SHDocVw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Login51CTO
{
    public sealed class IExplorerHelper
    {
        const int DEFAULT_Millisecond = 2000;
        /// <summary>
        /// 根据名称获取IE进程句柄
        /// </summary>
        /// <param name="ieWindowName"></param>
        /// <returns></returns>
        public static SHDocVw.InternetExplorer WindowObjectByName(String ieWindowName)
        {
            if (ieWindowName == String.Empty || ieWindowName.Equals(""))
            {
                return null;
            }
            SHDocVw.InternetExplorer v_ie = null;
            SHDocVw.ShellWindows sws = new SHDocVw.ShellWindows();
            foreach (SHDocVw.InternetExplorer iew in sws)
            {
                if (iew.Name.Contains(ieWindowName))
                {
                    v_ie = iew;
                }
            }
            return v_ie;
        }
        /// <summary>
        /// 根据URL获取IE进程句柄
        /// </summary>
        /// <param name="ieWindowName"></param>
        /// <returns></returns>
        public static SHDocVw.InternetExplorer WindowObjectByLocationURL(String url)
        {
            if (url == String.Empty || url.Equals(""))
            {
                return null;
            }
            SHDocVw.InternetExplorer iewObject = null;
            SHDocVw.ShellWindows sws = new SHDocVw.ShellWindows();
            foreach (SHDocVw.InternetExplorer iew in sws)
            {
                if (iew.LocationURL.Contains(url))
                {
                    iewObject = iew;
                }
            }
            return iewObject;
        }

        public static SHDocVw.InternetExplorer GetWindowObjectByLocationURL(String URL, int? millisecond=null)
        {
           var wdow= WindowObjectByLocationURL(URL);
           if (wdow==null) {
               InternetExplorer ie = IExplorerHelper.WindowObjectByLocationURL(URL);
               if (ie == null)
               {
                   IWebBrowser2 ielogin = new InternetExplorer();
                   ielogin.Visible = true;
                   object nil = new object();
                   ielogin.Navigate(URL, ref nil, ref nil, ref nil, ref nil);
                   System.Threading.Thread.Sleep(millisecond == null ? DEFAULT_Millisecond : millisecond.Value);
               }
               wdow = WindowObjectByLocationURL(URL);
           }
           return wdow;
        }

        /// <summary>
        /// 获取文档对象
        /// </summary>
        /// <param name="url">文档url</param>
        /// <param name="millisecond">延迟打开毫秒</param>
        /// <returns></returns>
        public static HTMLDocument GetHTMLDocumentByLocationURL(string url, int? millisecond=null)
        {
            SHDocVw.InternetExplorer iew = GetWindowObjectByLocationURL(url, millisecond);
            if (iew == null)
                return null;
            HTMLDocument doc = (HTMLDocument)iew.Document;
            return doc;
        }

        /// <summary>
        /// 根据下拉列表值获取option
        /// </summary>
        /// <param name="select"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IHTMLOptionElement GetOptionElementByValue(HTMLSelectElement select, string value)
        {
            HTMLElementCollection options = select.options as HTMLElementCollection;
            foreach (IHTMLOptionElement option in options)
            {
                if (option.value == value)
                {
                    return option;
                }
            }
            return null;
        }
        /// <summary>
        /// 根据value选中option
        /// </summary>
        /// <param name="select"></param>
        /// <param name="value"></param>
        public static void SelectOptionElement(HTMLSelectElement select, string value)
        {
            IHTMLOptionElement AreaOption = IExplorerHelper.GetOptionElementByValue(select, value);
            AreaOption.selected = true;
        }

    }
}

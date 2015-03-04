using mshtml;
using SHDocVw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TestAutoTestTool
{
    class Program
    {
        static void Main(string[] args)
        {
            //SHDocVw.WebBrowser web = new WebBrowser();
           
            InternetExplorer IE = new InternetExplorer();
            IE.Visible = true; 
            object nil = new object(); 
            string CnblogUrl = "http://www.cnblogs.com";    // 打开IE并且打开博客园主页   
            //string url = "http://admin.5a360.com/default.aspx?randomx=62";
            IE.Navigate(CnblogUrl, ref nil, ref nil, ref nil, ref nil);
            
            Console.WriteLine("主页已打开");
            Thread.Sleep(3000);   
            // 设置IE左上角的位置    
            IE.Top = 10;    IE.Left = 10;    
            // 设置IE的高度和宽度    
            IE.Height = 800;   
            IE.Width = 1000;
            // 获取DOM对象   
            HTMLDocument doc = (HTMLDocument)IE.Document;
            // 博客园主页上的搜索Textbox的id是 "zzk_q"   
            HTMLInputElement SearchTextBox = (HTMLInputElement)doc.getElementById("zzk_q");
            SearchTextBox.value = "小坦克";

            IHTMLElementCollection colletions = doc.getElementsByTagName("input");
            foreach (HTMLInputElement itm in colletions)
            {
                
                if (itm.className == "search_btn")
                {
                    itm.click();
                    return ;
                }
            }
            Console.WriteLine("搜索完成");
            Console.ReadKey();
        }
    }
}

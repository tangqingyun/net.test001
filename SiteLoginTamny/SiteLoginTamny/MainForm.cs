using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SiteLoginTamny
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            string address = "http://home.51cto.com/index.php?s=/Index/index/reback/http%253A%252F%252Fdown.51cto.com";
            webBrowser.Navigate(address);

        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            HtmlElementCollection elementCollection=webBrowser.Document.GetElementsByTagName("input");
            HtmlElement button = null;
            foreach (HtmlElement element in elementCollection)
            {
                string name = element.GetAttribute("name");
                switch (name)
                {
                    case "email":
                        element.InnerText = "tamny@sohu.com";
                        break;
                    case "passwd":
                        element.InnerText = "tangqingyun";
                        break;
                    case "button":
                        button = element;
                        break;
                    default:
                        break;
                }
            }

            button.InvokeMember("click");
        }

    }

}

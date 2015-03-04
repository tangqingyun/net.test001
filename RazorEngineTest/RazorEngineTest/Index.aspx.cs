using RazorEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RazorEngineTest
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //string template = "welcome @Model.Name";
            //string result = Razor.Parse(template, new { Name = "zhangsan" });

            string index_path = @"C:\Users\Administrator\Desktop\测试项目\RazorEngineTest\RazorEngineTest\index.html";
            string header_path = @"C:\Users\Administrator\Desktop\测试项目\RazorEngineTest\RazorEngineTest\header.html";
            var header = System.IO.File.ReadAllText(header_path, Encoding.UTF8);
            Razor.Compile(header, "header.html"); //将head.html内容预变成为heade变量，对应到index.html中的include

            var index = System.IO.File.ReadAllText(index_path, Encoding.UTF8);

            var list = new List<Student>()
            {
                 new Student(){ Name="张三" },
                 new Student(){ Name="李四" },
                 new Student(){ Name="王五" },
            };
            Razor.SetTemplateBase(typeof(CustomTemplateBase<>));//设置自定义模板
            var result = Razor.Parse(index, new { Name = "zhang", StudentList = list });
            Response.Write(result);
        }
    }

    public class Student {
        public string Name { get; set; }
    }

    public class Entity {
        public List<Student> StudentList { set; get; }
        public string Name { set; get; }
        public string Title { set; get; }
    }
}
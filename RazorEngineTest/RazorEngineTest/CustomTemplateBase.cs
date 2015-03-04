using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RazorEngineTest
{
    /// <summary>
    /// 自定义razor原有模板，增加一些自定义的全局方法
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class CustomTemplateBase<T> : TemplateBase<T>
    {
        public string StringUpper(string str) {
            return str.ToUpper();
        }

    }
}
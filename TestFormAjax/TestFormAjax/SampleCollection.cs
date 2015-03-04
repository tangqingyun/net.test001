using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestFormAjax
{
    public class SampleCollection<T>
    {
        private T[] arr = new T[100];
        public T this[int i]
        {
            get { return arr[i]; }
            set { arr[i] = value; }
        }
    }
}
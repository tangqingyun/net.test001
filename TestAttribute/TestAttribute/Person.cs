using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestAttribute
{
    [Serializable]
    [DataBase(DatabaseName="ERP_Goods")]
    public class Person
    {
        public Guid ID { set; get; }
        public string Name { set; get; }
    }
}

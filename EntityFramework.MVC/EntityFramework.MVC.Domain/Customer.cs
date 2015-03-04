using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFramework.MVC.Domain
{
    /// <summary>
    /// 客户实体类  
    /// </summary>
    public class Customer
    {
        public string IDCardNumber { get; set; }
        public string CustomerName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestPhoneRegion
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneService ps = new PhoneService();
            try
            {
                var s=ps.GetMobilePhone360Info("");
                PhoneInfo phone = ps.GetMobilePhoneInfo("13790467800");
                string json = "{\"Phone\":\"" + phone.PhoneCode + "\",\"province\":\"" + phone.Province + "\",\"city\":\"" + phone.City + "\",\"town\":\"\"}";
                Console.WriteLine(json); 
            }
            catch (Exception)
            {
                Console.WriteLine("远程服务异常！");
            }
            Console.ReadKey();
        }


    }
}

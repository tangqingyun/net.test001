using IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
    public class User : IPerson
    {


        public string Speek()
        {
            return "user";
        }
    }
}

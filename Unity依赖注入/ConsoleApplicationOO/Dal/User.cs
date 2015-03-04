using IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
    public class User:IPerson
    {

        public string Speak(string name)
        {
            return "我是用户";
        }
    }
}

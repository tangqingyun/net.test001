using IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
    public class Person : IPerson
    {
        public string Speak(string name)
        {
            return "hello world";
        }
    }
}

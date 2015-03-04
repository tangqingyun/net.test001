using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestEnum
{
    class Program
    {
        static void Main(string[] args)
        {
            string sss=Enum.GetName(typeof(Color), 2);
            object o=Enum.Parse(typeof(Color), "2");
            Color e ;
            Enum.TryParse<Color>("2", out e);
            Console.WriteLine(e);
            Console.ReadKey();
        }
    }

    public enum Color
    {
        Blue = 1,
        Yellow = 2,
        Black = 3
    }
}

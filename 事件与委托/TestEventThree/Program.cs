using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestEventThree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("大门打开！");
            Dog dog = new Dog();
            Host host = new Host(dog);
            dog.OnAlarm();
            Console.ReadKey();
        }
    }
}

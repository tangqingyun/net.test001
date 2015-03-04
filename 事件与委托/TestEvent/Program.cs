using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            //不带参数的事件
            //Console.WriteLine("请输入字母");           
            //SenderRequest c1 = new SenderRequest();                     
            //c1.OnUserRequestEvent += new SenderRequest.UserRequest(c1_OnUserRequest);//委托实例化后绑定到事件   
            //c1.run();

            //带参数的事件
            Console.WriteLine("请输入字母");
            SenderRequestArgs sra = new SenderRequestArgs();
            sra.OnUserRequestEvent += sra_OnUserRequestEvent;
            sra.run();

            Console.ReadKey();
        }

        static void sra_OnUserRequestEvent(object sender, OnUserRequestEventArgs e)
        {
            Console.WriteLine("你触发了事件！输入的字符为：" + e.Name);
        }

        private static void c1_OnUserRequest(object sender,  EventArgs e)
        {
            //事件处理方法               
            Console.WriteLine("你触发了事件！");
           
        }

    }

    /// <summary>
    /// 发送请求
    /// </summary>
    public class SenderRequest
    {
        public delegate void UserRequest(object sender, EventArgs args);//定义委托
        public event UserRequest OnUserRequestEvent;//定义委托类型的事件;
        public void run()
        {
            while (true)
            {
                if (Console.ReadLine() == "a")
                {
                    //事件监听   
                    OnUserRequestEvent(this, new EventArgs()); //产生事件    
                }
            }
        }
    }

    public class SenderRequestArgs
    {
        public delegate void UserRequest(object sender, OnUserRequestEventArgs args);//定义委托
        public event UserRequest OnUserRequestEvent;//定义委托类型的事件;
        public void run()
        {
            while (true)
            {
                string a = Console.ReadLine();              
                OnUserRequestEventArgs cargs = new OnUserRequestEventArgs();
                cargs.Name = a;
                //事件监听  
                OnUserRequestEvent(this, cargs); //产生事件    
            }
        }
    }

    public class Receiver
    {
        public Receiver(Sender sender)
        {
            sender.Event += new Sender.EventHandler(OnEvent);
        }
        private void OnEvent(object sender)
        {
            Console.WriteLine("接收");
            Console.Read();
        }

    }

    public class Sender
    {
        public delegate void EventHandler(object sender);
        public event EventHandler Event;
        public void TriggerEvent()
        {
            Console.WriteLine("触发");
            Event(this);
        }
    }

}

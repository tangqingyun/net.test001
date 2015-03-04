using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestEventTwo
{
    public class MemberBll
    {
        MemberDao dao;
        public MemberBll()
        {
            dao = new MemberDao();
            dao.LogEvent += dao_LogEvent;
           
        }

        public bool Add()
        {
            bool bol= dao.Add();
            return bol;
        }

        void dao_LogEvent(object sender, LogEventArgs args)
        {
            Console.WriteLine("日志写入成功！操作人："+args.Creater+"\r\n操作时间："+args.InsertDate);
        }

    }
}

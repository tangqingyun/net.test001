using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestAttribute
{
    [Serializable]
    [DataBase(DatabaseName="ERP_Goods")]
    public class Member
    {
        public Guid MemberID { set; get; }
        public string RealName { set; get; }
    }
}

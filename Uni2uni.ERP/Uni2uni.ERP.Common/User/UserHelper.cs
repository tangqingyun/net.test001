using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uni2uni.ERP.Common.User
{
    public class UserHelper
    {
        public static UserInfo GetUserInfo()
        {
            return new UserInfo() { 
             UserId=new Guid(),
              UserName="admin"
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestNHibernate.Domain
{
    public class User
    {
        public virtual Guid ID{set;get;}

        public virtual string UserName { set; get; }

        public virtual string Sex{set;get;}

    }
}

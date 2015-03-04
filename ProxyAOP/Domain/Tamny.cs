using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    /// <summary>
    /// tamny
    /// </summary>
    public class Tamny
    {
        public string Name { set; get; }
        public int Age { set; get; }
        public string[] Book { set; get; }
        public IList<Friend> FriendList { set; get; }
    }
}

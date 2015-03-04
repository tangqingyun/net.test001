using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yun.shop.domain
{
    public class BaseStandardEntity
    {
        public DateTime CreateDate { set; get; }
        public Guid Creater { set; get; }

        protected void SetAboutInfo()
        {
            CreateDate = DateTime.Now;
            Creater = new Guid();
        }
    }
}

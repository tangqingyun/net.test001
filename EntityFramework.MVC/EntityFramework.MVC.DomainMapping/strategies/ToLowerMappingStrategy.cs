using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFramework.MVC.DomainMapping.strategies
{
    public class ToLowerMappingStrategy : IMappingStrategy<string>
    {
        #region Implementation of IMappingStrategy<string>

        public string To(string from)
        {
            return from.ToLowerInvariant();
        }

        #endregion
    }
}

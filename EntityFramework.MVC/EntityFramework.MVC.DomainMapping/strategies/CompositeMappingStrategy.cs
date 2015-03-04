using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFramework.MVC.DomainMapping.strategies
{
    public class CompositeMappingStrategy<T> : IMappingStrategy<T>
    {
        public IList<IMappingStrategy<T>> Strategies { get; set; }

        public T To(T from)
        {
            return Strategies.Aggregate(from, (current, strategy) => strategy.To(current));
        }
    }
}

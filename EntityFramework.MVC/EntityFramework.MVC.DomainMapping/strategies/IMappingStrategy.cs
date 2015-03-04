using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFramework.MVC.DomainMapping.strategies
{
    public interface IMappingStrategy<T>
    {
        T To(T from);
    }
}

using AopAlliance.Intercept;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uni2uni.ERP.Resource.Attribute;

namespace Uni2Uni.ERP.AOP
{
    public class AroundAdvice : IMethodInterceptor
    {
        public object Invoke(IMethodInvocation invocation)
        {
            object result = invocation.Proceed();
            return result;
        }
    }
}

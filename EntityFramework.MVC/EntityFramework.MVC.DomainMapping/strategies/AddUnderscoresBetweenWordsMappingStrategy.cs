using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFramework.MVC.DomainMapping.strategies
{
    public class AddUnderscoresBetweenWordsMappingStrategy : IMappingStrategy<string>
    {
        #region Implementation of IMappingStrategy<string>

        public string To(string from)
        {
            var chars = from.ToCharArray();
            var sb = new StringBuilder(chars.Length);

            var prev = 'A';
            foreach (var c in chars)
            {
                if (c != '_' && char.IsUpper(c) && !char.IsUpper(prev))
                {
                    sb.Append('_');
                }
                sb.Append(c);
                prev = c;
            }

            return sb.ToString();
        }

        #endregion
    }
}

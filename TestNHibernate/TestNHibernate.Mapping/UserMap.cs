using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestNHibernate.Domain;

namespace TestNHibernate.Mapping
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("User");
            DynamicUpdate();
            Id(x => x.ID).Not.Nullable();
            Map(x => x.UserName).Not.Nullable();
            Map(x => x.Sex).Not.Nullable();
        }

    }
}

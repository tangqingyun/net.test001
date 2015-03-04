using EntityFramework.MVC.Domain;
using EntityFramework.MVC.DomainMapping.strategies;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;

namespace EntityFramework.MVC.DomainMapping
{
    public class EntityMappingBase<TEntity> : EntityTypeConfiguration<TEntity>, IMapping
        where TEntity : class , IEntity
    {
        protected static readonly Lazy<IMappingStrategy<string>> AddUnderscoresBetweenWordsThenToLowerMappingStrategy =
            new Lazy<IMappingStrategy<string>>(() => new CompositeMappingStrategy<string>
            {
                Strategies = new IMappingStrategy<string>[]
                                                                      {
                                                                          new AddUnderscoresBetweenWordsMappingStrategy()
                                                                          ,
                                                                          new ToLowerMappingStrategy()
                                                                      }
            });

        protected static readonly Lazy<IMappingStrategy<string>> ColumnNameMappingStrategy =
            new Lazy<IMappingStrategy<string>>(() => new CompositeMappingStrategy<string>
            {
                Strategies = new List<IMappingStrategy<string>>(new[]
                                                                                                 {
                                                                                                     new AddPrefixMappingStrategy
                                                                                                         (typeof (TEntity
                                                                                                              ).Name),
                                                                                                     AddUnderscoresBetweenWordsThenToLowerMappingStrategy
                                                                                                         .Value
                                                                                                 })
            });

        public EntityMappingBase()
            : this(null)
        {

        }

        public EntityMappingBase(IMappingStrategy<string> tableNameMappingStrategy)
        {
            if (tableNameMappingStrategy != null)
            {
                ToTable(tableNameMappingStrategy.To(typeof(TEntity).Name));
            }
        }

        #region Implementation of IMapping

        public void RegistTo(ConfigurationRegistrar configurationRegistrar)
        {
            configurationRegistrar.Add(this);
        }

        #endregion
    }
}

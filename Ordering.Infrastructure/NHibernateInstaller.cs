using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using Ordering.Domain;
using Ordering.Infrastructure.Maps;

namespace Ordering.Infrastructure
{
    public static class NHibernateInstaller
    {
        public static IServiceCollection AddNHibernate(this IServiceCollection services, string cnString)
        {
            var sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(cnString))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<OrderMap>().Conventions.Add(ForeignKey.EndsWith("Id")))
                .BuildSessionFactory();

            services.AddSingleton<ISessionFactory>(sessionFactory);

            services.AddSingleton<IUnitOfWorkProvider, UnitOfWorkProvider>();

            return services;
        }
    }
}

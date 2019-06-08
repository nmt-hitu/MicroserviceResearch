
using Autofac;
using Ordering.API.Application.Commands;
using Ordering.API.Application.Queries;
using Ordering.Domain;
using Ordering.Domain.AggregatesModel.OrderAggregate;
using Ordering.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Ordering.API.Infrastructure.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        public string QueriesConnectionString { get; }

        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;

        }

        protected override void Load(ContainerBuilder builder)
        {

            builder.Register(c => new ProductQueries(QueriesConnectionString))
                .As<IProductQueries>()
                .InstancePerLifetimeScope();

            builder.RegisterType<OrderRepository>()
                .As<IOrderRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(CreateOrderCommandHandler).GetTypeInfo().Assembly);
                //.AsClosedTypesOf(typeof(IIntegrationEventHandler<>));

        }
    }
}

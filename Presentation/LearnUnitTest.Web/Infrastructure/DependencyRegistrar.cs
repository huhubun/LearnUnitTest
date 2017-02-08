using Autofac;
using Autofac.Integration.Mvc;
using LearnUnitTest.Core.Data;
using LearnUnitTest.Core.Domain.Users;
using LearnUnitTest.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnUnitTest.Web.Infrastructure
{
    public static class DependencyRegistrar
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //
            builder.Register(c =>
            {
                return new object();
            }).As<IRepository<User>>().InstancePerLifetimeScope();

            //
            builder.RegisterType<UserService>().InstancePerLifetimeScope();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
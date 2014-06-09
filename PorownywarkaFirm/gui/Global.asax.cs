using Aplikacja;
using Autofac;
using Autofac.Integration.Mvc;
using Dane;
using gui.Controllers;
using gui.Hubs;
using IAplikacja;
using IDane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace gui
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoFacBuilder();
        }
        
        private static void AutoFacBuilder()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<ZbiorDanych>().As<IZbiorDanych>().InstancePerRequest();
            builder.RegisterType<ZbiorFunkcji>().As<IZbiorFunkcji>().InstancePerRequest();
            builder.RegisterType<MessageBus_Hub>().As<IMessage>().InstancePerRequest();
            
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}

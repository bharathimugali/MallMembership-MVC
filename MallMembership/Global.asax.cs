using Autofac;
using Autofac.Integration.Mvc;
using MallMembership.App_Start;
using MallMembership.BusinessLayer;
using MallMembership.Controllers;
using MallMembership.CustomBinder;
using MallMemebership.DataLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MallMembership
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ModelBinderProviders.BinderProviders.Insert(0, new XMLToObjectModelBinderProvider());
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Insert(0,new CustomViewEngine());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            builder.RegisterType<AddressBusiness>().As<IAddressBusiness>().InstancePerRequest(); ;
            builder.RegisterType<AddressDL>().As<IAddressDL>().InstancePerRequest();

            builder.RegisterType<ApplicantBusiness>().As<IApplicantBusiness>().InstancePerRequest(); ;
            builder.RegisterType<ApplicantDL>().As<IApplicantDL>().InstancePerRequest();
           
            builder.RegisterType<EmploymentBusiness>().As<IEmploymentBusiness>().InstancePerRequest(); ;
            builder.RegisterType<EmploymentDL>().As<IEmploymentDL>().InstancePerRequest();

            builder.RegisterType<EmploymentController>();
            builder.RegisterType<AddressController>();
            builder.RegisterType<ApplicantController>();
            builder.RegisterType<MembershipController>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}

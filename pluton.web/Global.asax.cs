using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using pluton.web.App_Start;
using pluton.web.Data;
using pluton.web.Infrastructure;
using pluton.web.Infrastructure.Attributes;
using pluton.web.Migrations;

namespace pluton.web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            GlobalFilters.Filters.Add(new LanguageReplacerAttribute());
            GlobalFilters.Filters.Add(new ActionsLoggingAttribute());
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<PlutonContext, Configuration>());    
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
  
            Mappings.Init();
        }
    }
}
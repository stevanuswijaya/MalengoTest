using MalengoTestApplication.Bootstrapper;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace MalengoTestApplication
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            Bootstrapper.Bootstrapper.RegisterDependencies();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(DependencyContainer.Container);
        }
    }
}
using MalengoTestApplication.BusinessLogic;
using MalengoTestApplication.BusinessLogic.Interface;
using Microsoft.Practices.Unity;

namespace MalengoTestApplication.Bootstrapper
{
    public class Bootstrapper
    {
        public static void RegisterDependencies()
        {
            DependencyContainer.Container.RegisterType<IPalindromeFactory, PalindromeFactory>(new HierarchicalLifetimeManager());
        }
    }
}
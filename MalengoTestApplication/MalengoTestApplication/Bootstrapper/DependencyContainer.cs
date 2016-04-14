using Microsoft.Practices.Unity;

namespace MalengoTestApplication.Bootstrapper
{
    public static class DependencyContainer
    {
        public static UnityContainer Container;
        static DependencyContainer()
        {
            Container = new UnityContainer();
        }
    }
}
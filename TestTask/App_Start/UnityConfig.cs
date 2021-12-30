using System.Web.Mvc;
using TestTask.Services;
using Unity;
using Unity.Mvc5;

namespace TestTask
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IItemsRepository, ItemsRepository>();
            container.RegisterType<IManageItems, ManageItems>();
            container.RegisterType<IRandomValueGenerate, GenerateRandomValues>();
            container.RegisterType<IGetPath, ManageFilePath>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
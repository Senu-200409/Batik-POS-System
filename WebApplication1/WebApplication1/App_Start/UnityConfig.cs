using System.Web.Mvc;
using POS_System.Controllers;
using POS_System.DataAccess;
using Unity;
using Unity.Mvc5;
using POS_System.Interfaces;
using POS_System.DataAccess;


namespace POS_System
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // Register your interfaces and implementations
            container.RegisterType<IUser, DAUser>();
            container.RegisterType<ICategories, DACategories>();
            container.RegisterType<ISubCategories, DASubCategories>();
            container.RegisterType<IProducts, DAProducts>();
            container.RegisterType<IBills, DABills>();
            container.RegisterType<IBillItems, DABillItems>();
            

            // Set the dependency resolver for MVC
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}

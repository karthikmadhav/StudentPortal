using CRM.BusinessLayer.Interfaces;
using CRM.BusinessLayer.Services;
using CRM.DataAccessLayer.Interfaces;
using CRM.DataAccessLayer.Providers;
using System;

using Unity;
using Unity.Lifetime;

namespace CRMPresentation
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();

            //Business Layer interfaces registration
            container.RegisterType<ILeadSource, LeadSourceService>(new PerResolveLifetimeManager());
            container.RegisterType<IIndustryCategory, IndustryCategoryService>(new PerResolveLifetimeManager());
            container.RegisterType<ICustomerDetails, CustomerService>(new PerResolveLifetimeManager());
            //container.RegisterType<IProduct, ProductService>(new PerResolveLifetimeManager());
            //container.RegisterType<IProduct, ProductService1>(new PerResolveLifetimeManager());

            //Multiple Concrete Implementation 
            container.RegisterType<IProduct, ProductService>("ProductService");
            container.RegisterType<IProduct, ProductService1>("ProductService1");




            //Data Access Layer Interface registration
            container.RegisterType<ILeadProvider, LeadSourceProvider>(new PerResolveLifetimeManager());
            container.RegisterType<IIndustryCategoryProvider, IndustryCategoryProviders>(new PerResolveLifetimeManager());
            container.RegisterType<ICustomerProvider, CustomerDetailsProvider>(new PerResolveLifetimeManager());



        }
    }
}

using System.Reflection;
using System.Web.Mvc;
using AdDataAggregation.AdDataServiceReference;
using AdDataAggregation.Services;
using AutoMapper;
using FilterPlugins;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace AdDataAggregation.App_Start
{
    public static class IOC
    {
        public static void Initialize()
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Register your types, for instance:
            container.Register<IDataService, DataService>( Lifestyle.Scoped );
            container.RegisterSingleton<IAdDataService>( WCFServiceFactory.Build );
            container.RegisterSingleton<IMapper>( AutoMapper.Mapper.Instance );
            container.RegisterCollection<IDataFilter>( DataFilterTypeRegistry.FilterTypes );

            // This is an extension method from the integration package.
            container.RegisterMvcControllers( Assembly.GetExecutingAssembly() );

            container.Verify();

            DependencyResolver.SetResolver( new SimpleInjectorDependencyResolver( container ) );
        }
    }
}
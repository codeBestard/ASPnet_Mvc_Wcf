using System;
using System.Collections.Generic;
using System.Linq;
using FilterPlugins;


namespace AdDataAggregation.Services
{
    /// <summary>
    /// Plugin registry, The lazy function is optional if you want to deploy plugin dlls without rebooting the web server
    /// </summary>
    public sealed class DataFilterTypeRegistry
    {
        private static readonly Lazy<IEnumerable<Type>> _filterTypes =
                     new Lazy<IEnumerable<Type>>(
                ( ) =>
                {
                    var assemblies          = AppDomain.CurrentDomain.GetAssemblies();
                    var supportedAssemblies = assemblies.Where( asm => asm.GetName().Name.StartsWith( "FilterPlugins" ) );

                    var types = from asm in supportedAssemblies
                                from t in asm.GetTypes()
                                where
                                    !ReferenceEquals(t, null) &&
                                    typeof( IDataFilter ).IsAssignableFrom( t ) &&                  // has IDataFilter interface
                                    !ReferenceEquals( t.GetConstructor( Type.EmptyTypes ) , null )  // has constructor
                                select t;
                    return types;

                } );

        public static IEnumerable<Type> FilterTypes => _filterTypes.Value;
    }
}
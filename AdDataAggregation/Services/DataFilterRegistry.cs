using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AdDataAggregation.FilterPlugins;


namespace AdDataAggregation.Services
{
    /// <summary>
    /// Plugin Mode
    /// </summary>
    public sealed class DataFilterTypeRegistry
    {
        private static readonly Lazy<IEnumerable<Type>> _filterTypes =
                     new Lazy<IEnumerable<Type>>(
                ( ) =>
                {
                    var types = from t in Assembly.GetExecutingAssembly().GetTypes()
                                where
                                    !ReferenceEquals(t, null) &&
                                    !ReferenceEquals(t.BaseType, null) &&
                                    t.BaseType == typeof(BaseDataFilter) 
                                select t;
                    return types;

                } );

        public static IEnumerable<Type> FilterTypes => _filterTypes.Value;
    }
}
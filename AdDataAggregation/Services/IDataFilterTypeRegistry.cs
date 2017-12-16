using System;
using System.Collections.Generic;

namespace AdDataAggregation.Services
{
    public interface IDataFilterTypeRegistry
    {
        IEnumerable<Type> FilterTypes { get; }
    }
}
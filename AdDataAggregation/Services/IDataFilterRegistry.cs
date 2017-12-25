using System;
using System.Collections.Generic;
using FilterPlugins;

namespace AdDataAggregation.Services
{
    public interface IDataFilterRegistry
    {
        IDataFilter FindFilterPlugin(string type = "");
    }
}
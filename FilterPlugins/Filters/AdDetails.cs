using System.Collections.Generic;
using AdModels;


namespace FilterPlugins.Filters
{
    public sealed class AdDetails : IDataFilter
    {
        public string @Type { get; } = "AdDetails";

        public IEnumerable<AdDTO> Filter( IEnumerable<AdDTO> data )
        {
            return data;
        }
    }
}
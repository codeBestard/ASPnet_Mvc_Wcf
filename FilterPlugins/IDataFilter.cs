using System.Collections.Generic;
using System.Linq;
using AdModels;

namespace FilterPlugins
{
    public interface IDataFilter
    {
        string @Type { get; }
        IEnumerable<AdDTO> Filter( IEnumerable<AdDTO> data );
    }
    
    public class NullFilter : IDataFilter
    {
        public static readonly IDataFilter Instance = new NullFilter(  );

        public string @Type { get; } = "NULL";
        private NullFilter()
        {
        }

        public IEnumerable<AdDTO> Filter( IEnumerable<AdDTO> data ) => Enumerable.Empty<AdDTO>();
    }
}

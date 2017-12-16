using System.Collections.Generic;
using System.Threading.Tasks;
using AdDataAggregation.Models;

namespace AdDataAggregation.Services
{
    public interface IDataService
    {
        IEnumerable<AdDTO> GetAdData(string type = "");
    }
}

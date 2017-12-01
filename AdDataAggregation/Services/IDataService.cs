using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AdDataAggregation.Models;

namespace AdDataAggregation.Services
{
    public interface IDataService
    {
        IEnumerable<AdDTO> GetAll( );
        IEnumerable<AdDTO> GetCoverAds( );

        IEnumerable<AdDTO> GetTop5AdsForEachBrand();

        IEnumerable<AdDTO> GetTop5BrandsWithMostCoverage();
    }
}

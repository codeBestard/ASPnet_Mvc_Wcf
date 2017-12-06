using System;
using System.Collections.Generic;
using System.Linq;
using AdDataAggregation.AdDataServiceReference;
using AdDataAggregation.Models;
using AutoMapper;

namespace AdDataAggregation.Services
{
    public sealed class DataService : IDataService
    {
        private readonly IAdDataService _serviceClient;

        public DataService( IAdDataService serviceClient)
        {
            _serviceClient = serviceClient;
        }
        
        public IEnumerable<AdDTO> GetAdData(string type = "")
        {
            var result = Enumerable.Empty<AdDTO>();

            switch( type )
            {
                case "AdDetails":
                    result = GetAll();
                    break;
                case "CoverAds":
                    result = GetCoverAds();
                    break;
                case "Top5AdsForEachBrand":
                    result = GetTop5AdsForEachBrand();
                    break;
                case "Top5BrandsWithMostCoverage":
                    result = GetTop5BrandsWithMostCoverage();
                    break;
            }

            return result;
        }

        private IEnumerable<AdDTO> GetAll( )
        {
            var data   = _serviceClient.GetAdDataByDateRange(new DateTime(2011, 1, 1), new DateTime(2011, 4, 1));

            var result = Mapper.Map<IEnumerable<AdDTO>>(data.ToList());

            return result;
        }

        private IEnumerable<AdDTO> GetCoverAds( )
        {
            const string position = "cover";

            var data   = this.GetAll();

            var result = from ad in data
                         where
                            position.Equals(ad.Position, StringComparison.OrdinalIgnoreCase)
                            &&
                            ad.NumPages >= .5m
                         orderby ad.BrandName
                         select ad;
            return result;
        }

        private IEnumerable<AdDTO> GetTop5AdsForEachBrand( )
        {
            var data   = this.GetAll();

            var result = data.OrderByDescending(ad => ad.NumPages)
                            .GroupBy(ad => ad.BrandName)
                            .SelectMany(g => g.Take(5))
                            .OrderByDescending(ad => ad.NumPages)
                            .ThenBy(ad => ad.BrandName);

            return result;
        }

        private IEnumerable<AdDTO> GetTop5BrandsWithMostCoverage()
        {
            var data   = this.GetAll();

            var result = data.OrderByDescending(ad => ad.NumPages)
                            .GroupBy(ad => ad.BrandName)
                            .Select(g => g.First())
                            .Take(5)
                            .OrderByDescending( ad => ad.NumPages )
                            .ThenBy( ad => ad.BrandName );

            return result;
        }
    }
}
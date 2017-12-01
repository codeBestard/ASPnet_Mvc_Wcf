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

        //public DataService( )
        //    : this( new AdDataServiceClient() )
        //{

        //}
        public IEnumerable<AdDTO> GetAll( )
        {
            var data   = _serviceClient.GetAdDataByDateRange(new DateTime(2011, 1, 1), new DateTime(2011, 4, 1));

            var result = Mapper.Map<IEnumerable<AdDTO>>(data.ToList());

            return result;
        }

        public IEnumerable<AdDTO> GetCoverAds( )
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

        public IEnumerable<AdDTO> GetTop5AdsForEachBrand( )
        {
            var data   = this.GetAll();

            var result = data.OrderByDescending(ad => ad.NumPages)
                            .GroupBy(ad => ad.BrandName)
                            .SelectMany(g => g.Take(5));

            return result;
        }

        public IEnumerable<AdDTO> GetTop5BrandsWithMostCoverage()
        {
            var data   = this.GetAll();

            var result = data.OrderByDescending(ad => ad.NumPages)
                            .GroupBy(ad => ad.BrandName)
                            .Select(g => g.First())
                            .Take(5);

            return result;
        }
    }
}
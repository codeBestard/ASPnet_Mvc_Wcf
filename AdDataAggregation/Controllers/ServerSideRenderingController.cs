using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AdDataAggregation.Services;
using System.Linq.Dynamic;
using AdModels;

namespace AdDataAggregation.Controllers
{
    public class ServerSideRenderingController : Controller
    {
        private readonly IDataService _dataService;

        public ServerSideRenderingController( IDataService dataService )
        {
            _dataService = dataService;
        }

        public ActionResult Index(
            string type = "AdDetails" ,
            int page = 1,
            string sort = "BrandName",
            string sortdir="asc",
            string search = "" )
        {
            const int pageSize = 50;
            if (page < 1)
            {
                page = 1;
            }

            var skip = (page * pageSize) - pageSize;

            (IEnumerable<AdDTO> adResult, int total) = GetAds(type, sort, sortdir, skip, pageSize);

            ViewBag.totalRecord = total;
            ViewBag.search      = search;
            ViewBag.type        = type;

            return View(adResult);
        }

        private (IEnumerable<AdDTO> adResult, int total) GetAds(
            string type, 
            string sort,
            string sortdir,
            int skip,
            int pageSize)
        {
            var ads = _dataService.GetAdData(type);

            var list = ads.ToList();

            var total = list.Count;

            var result = list.OrderBy( $"{sort} {sortdir}" );
            if (pageSize > 0)
            {
                result = result.Skip(skip).Take(pageSize);
            }

            return (result, total);
        }

       
    }
    
}

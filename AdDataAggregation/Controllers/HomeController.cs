using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdDataAggregation.Services;

namespace AdDataAggregation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataService _dataService;

        //public HomeController( )
        //    :this(new DataService())
        //{
        //}

        public HomeController(IDataService dataService)
        {
            _dataService = dataService;
        }


        public ActionResult Index( )
        {
            return View();
        }

        public JsonResult AdDetails( )
        {
            var result = _dataService.GetAll();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CoverAds( )
        {
            var result = _dataService.GetCoverAds();

            return Json( result , JsonRequestBehavior.AllowGet );
        }

        public JsonResult Top5AdsForEachBrand( )
        {
            var result = _dataService.GetTop5AdsForEachBrand();

            return Json( result , JsonRequestBehavior.AllowGet );
        }

        public JsonResult Top5BrandsWithMostCoverage( )
        {
            var result = _dataService.GetTop5BrandsWithMostCoverage();

            return Json( result , JsonRequestBehavior.AllowGet );
        }
    }
}
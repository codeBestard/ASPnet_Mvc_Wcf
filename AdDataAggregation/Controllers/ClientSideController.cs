using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdDataAggregation.Services;

namespace AdDataAggregation.Controllers
{
    public class ClientSideController : Controller
    {

        private readonly IDataService _dataService;

        public ClientSideController( IDataService dataService )
        {
            _dataService = dataService;
        }
        // GET: ClientSide
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult AdDetails( string type = "" )
        {
            var result = _dataService.GetAdData( type );

            return Json( result , JsonRequestBehavior.AllowGet );
        }
    }
}
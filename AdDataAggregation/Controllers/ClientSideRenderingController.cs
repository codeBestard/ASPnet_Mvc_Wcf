using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AdDataAggregation.Services;

namespace AdDataAggregation.Controllers
{
    public class ClientSideRenderingController : Controller
    {

        private readonly IDataService _dataService;

        public ClientSideRenderingController( IDataService dataService )
        {
            _dataService = dataService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> AdDetails( string type = "" )
        {
            var result = await _dataService.GetAdDataAsync( type );

            return Json( result , JsonRequestBehavior.AllowGet );
        }
    }
}
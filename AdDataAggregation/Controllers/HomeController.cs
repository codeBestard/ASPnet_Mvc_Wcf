using System.Web.Mvc;
using AdDataAggregation.Services;

namespace AdDataAggregation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataService _dataService;

        public HomeController(IDataService dataService)
        {
            _dataService = dataService;
        }


        public ActionResult Index( )
        {
            return View();
        }

        public JsonResult AdDetails( string type = "")
        {
            var result = _dataService.GetAdData(type);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
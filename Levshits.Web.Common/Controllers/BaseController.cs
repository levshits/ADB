using System.Web.Mvc;

namespace Levshits.Web.Common.Controllers
{
    public abstract class BaseController : Controller
    {
        public string Text1 { get; set; }
        [HttpGet]
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}
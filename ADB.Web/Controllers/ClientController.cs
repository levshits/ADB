using System.Web.Mvc;
using Levshits.Web.Common.Controllers;

namespace ADB.Web.Controllers
{
    public class ClientController: BaseController
    {
        public string Text { get; set; }
        public override ActionResult Index()
        {
            return Content(Text+Text1);
        }
    }
}
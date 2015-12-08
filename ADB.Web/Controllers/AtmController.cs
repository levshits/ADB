using System.Web.Mvc;
using ADB.Web.Models;
using Levshits.Web.Common.Controllers;

namespace ADB.Web.Controllers
{
    public class AtmController: BaseController
    {
        public override ActionResult Index()
        {
            var model = new CardEntryModel();
            return View(model);
        }
    }
}
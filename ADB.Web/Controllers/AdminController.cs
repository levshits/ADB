using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ADB.Common.Dto;
using ADB.Common.Item;
using ADB.Common.Requests;
using ADB.Web.Models;
using AutoMapper;
using Levshits.Data.Common;
using Levshits.Web.Common.Controllers;

namespace ADB.Web.Controllers
{
    public class AdminController: BaseController
    {
        public override ActionResult Index()
        {
            var model = new CloseDayModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult CloseDay(CloseDayModel model)
        {
            if (ModelState.IsValid)
            {
                CommandBus.ExecuteCommand(new CloseDayRequest {Value = model.DayToClose});
                return RedirectToAction("Index");
            }
            return View("Index", model);
        }

    }
}
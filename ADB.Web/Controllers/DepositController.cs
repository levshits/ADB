using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ADB.Common.Dto;
using ADB.Common.Item;
using ADB.Common.Requests;
using ADB.Web.Models;
using AutoMapper;
using Levshits.Data.Common;
using Levshits.Web.Common.Controllers;

namespace ADB.Web.Controllers
{
    public class DepositController: BaseController
    {
        public override ActionResult Index()
        {
            var result = CommandBus.ExecuteCommand<IList<DepositContractListItemModel>>(new DepositContractListRequest { Paging = new PagingOptions() });

            var model = Mapper.Map<List<DepositContractListItemModel>>(result.TypedResult) ?? new List<DepositContractListItemModel>();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new DepositContractModel();

            InitializeModel(model);
            return View(model);
        }

        private void InitializeModel(DepositContractModel model)
        {
            var clients = CommandBus.ExecuteCommand<IList<LookupItem>>(new ClientLookupListRequest());
            model.ClientsLookupItems = clients.TypedResult ?? new List<LookupItem>();
        }

        [HttpPost]
        public ActionResult Save(DepositContractModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = Mapper.Map<DepositContractDto>(model);
                var result = CommandBus.ExecuteCommand(new SaveDepositContractRequest { Value = dto });
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                ViewBag.Errors = "Ошибка вставки \n" + string.Join("\n", result.Errors.Select(x => x.Description));
            }
            InitializeModel(model);
            return View("Create", model);
        }
    }
}
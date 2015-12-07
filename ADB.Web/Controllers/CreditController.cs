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
    public class CreditController: BaseController
    {
        public override ActionResult Index()
        {
            var result = CommandBus.ExecuteCommand<IList<CreditContractListItem>>(new CreditContractListRequest { Paging = new PagingOptions() });

            var model = Mapper.Map<List<CreditContractListItemModel>>(result.TypedResult) ?? new List<CreditContractListItemModel>();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new CreditContractModel();

            InitializeModel(model);
            return View(model);
        }

        private void InitializeModel(CreditContractModel model)
        {
            var clients = CommandBus.ExecuteCommand<IList<LookupItem>>(new ClientLookupListRequest());
            model.ClientsLookupItems = clients.TypedResult ?? new List<LookupItem>();
        }

        [HttpPost]
        public ActionResult Save(CreditContractModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = Mapper.Map<CreditContractDto>(model);
                var result = CommandBus.ExecuteCommand(new SaveCreditContractRequest { Value = dto });
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
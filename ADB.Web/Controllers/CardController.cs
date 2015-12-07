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
    public class CardController: BaseController
    {
        public override ActionResult Index()
        {
            var result = CommandBus.ExecuteCommand<IList<CardListItem>>(new CardListRequest { Paging = new PagingOptions() });

            var model = Mapper.Map<List<CardListItemModel>>(result.TypedResult) ?? new List<CardListItemModel>();
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new CardFirstStepModel();
            InitializeModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CardFirstStepModel model)
        {
            if (ModelState.IsValid)
            {
                var cardModel = new CardModel
                {
                    ClientId = model.ClientId
                };
                InitializeModel(cardModel);
                return View("Save", cardModel);
            }
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult Save(CardModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = Mapper.Map<CardDto>(model);
                var result = CommandBus.ExecuteCommand(new SaveCardRequest { Value = dto });
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                ViewBag.Errors = "Ошибка вставки \n" + string.Join("\n", result.Errors.Select(x => x.Description));

            }
            InitializeModel(model);
            return View("Save", model);
        }
        private void InitializeModel(CardModel model)
        {
            var accounts = CommandBus.ExecuteCommand<IList<LookupItem>>(new AccountLookupListRequest {Value = model.ClientId});
            model.AccountLookupItems = accounts.TypedResult ?? new List<LookupItem>();
        }

        private void InitializeModel(CardFirstStepModel model)
        {
            var clients = CommandBus.ExecuteCommand<IList<LookupItem>>(new ClientLookupListRequest());
            model.ClientsLookupItems = clients.TypedResult ?? new List<LookupItem>();
        }
    }
}
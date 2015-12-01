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
    public class ClientController: BaseController
    {
        public override ActionResult Index()
        {
            var result = CommandBus.ExecuteCommand<IList<ClientListItem>>(new ClientListRequest {Paging = new PagingOptions()});

            var model = Mapper.Map<List<ClientListItemModel>>(result.TypedResult) ?? new List<ClientListItemModel>();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new ClientModel();

            InitializeModel(model);
            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult Save(ClientModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = Mapper.Map<ClientDto>(model);
                var result = CommandBus.ExecuteCommand(new SaveClientRequest() {Value = dto});
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                ViewBag.Errors = "Ошибка вставки \n"+string.Join("\n", result.Errors.Select(x => x.Description));
            }
            InitializeModel(model);
            return View("Edit",model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = CommandBus.ExecuteCommand<ClientDto>(new ClientByIdRequest { Value = id });
            var model = Mapper.Map<ClientModel>(result.TypedResult);
            InitializeModel(model);
            return View(model);
        }

        private void InitializeModel(ClientModel model)
        {
            var cities = CommandBus.ExecuteCommand<IList<LookupItem>>(new CityListRequest());
            model.ResidenceSities = cities.TypedResult;
        }

        public ActionResult Delete(int id)
        {
            var result = CommandBus.ExecuteCommand<ClientDto>(new DeleteClientByIdRequest { Value = id });
            return RedirectToAction("Index");
        }
    }
}
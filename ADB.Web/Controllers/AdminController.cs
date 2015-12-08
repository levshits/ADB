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
            var result = CommandBus.ExecuteCommand<IList<AccountListItem>>(new AccountListRequest { Paging = new PagingOptions() });

            var model = Mapper.Map<List<AccountListItemModel>>(result.TypedResult) ?? new List<AccountListItemModel>();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var result = CommandBus.ExecuteCommand<IList<AccountDto>>(new AccountRequest { Value = id });

            var model = Mapper.Map<AccountModel>(result.TypedResult);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
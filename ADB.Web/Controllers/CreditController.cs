using System.Collections.Generic;
using System.Web.Mvc;
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

        public ActionResult Create()
        {
            throw new System.NotImplementedException();
        }
    }
}
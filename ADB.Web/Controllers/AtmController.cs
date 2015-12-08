using System.Web.Mvc;
using ADB.Common.Dto;
using ADB.Common.Requests;
using ADB.Web.Models;
using ADB.Web.Models.Enumerations;
using Levshits.Logic.Common;
using Levshits.Web.Common.Controllers;

namespace ADB.Web.Controllers
{
    public class AtmController: BaseController
    {
        public bool IsPinChecked {
            get { return (bool) Session[PinCheckedKey]; }
            set { Session[PinCheckedKey] = value; } }

        public int PinFailCount
        {
            get { return (int) Session[PinFailCountKey]; }
            set { Session[PinFailCountKey] = value; }
        }

        public CardDto CardDto
        {
            get { return Session[CardEntityKey] as CardDto; }
            set { Session[CardEntityKey] = value; }
        }
        public string LastActionUrl
        {
            get { return Session[LastActionUrlKey] as string; }
            set { Session[LastActionUrlKey] = value; }
        }
        public override ActionResult Index()
        {
            CardDto = null;
            var model = new CardEntryModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(CardEntryModel model)
        {
            if (ModelState.IsValid)
            {
                ExecutionResult<CardDto> result = CommandBus.ExecuteCommand(new CardRequest() {Value = model.Number}) as ExecutionResult<CardDto>;
                if (result != null && result.Success && result.TypedResult!=null)
                {
                    CardDto = result.TypedResult;
                    IsPinChecked = false;
                    return RedirectToAction("Menu");

                }
            }
            return View(model);
        }

        public const string CardEntityKey = "26258A2D-09BC-4943-B1DB-24FC81E50A07";
        public const string PinCheckedKey = "242060E7-8080-4764-BE9E-F1EA61A43502";
        public const string PinFailCountKey = "2B1A666B-4021-439D-B3AA-A1B21AAA010C";
        public const string LastActionUrlKey = "5E08259A-DF76-459D-B64F-026F84B22E09";

        public ActionResult Menu()
        {
            IsPinChecked = false;
            return View();
        }

        public ActionResult Balance()
        {
            if (IsPinChecked)
            {
                ExecutionResult<CardDto> result = CommandBus.ExecuteCommand(new CardRequest() { Value = CardDto.Number }) as ExecutionResult<CardDto>;
                if (result != null && result.Success && result.TypedResult != null)
                {
                    CardDto = result.TypedResult;
                    var model = new BalanceModel()
                    {
                        Value = CardDto.AccountIdObject.Balance,
                        CurrencyType = (CurrencyTypeEnum) CardDto.AccountIdObject.CurrencyType
                    };
                    return View(model);

                }
                return RedirectToAction("Index");
            }
            LastActionUrl = Url.Action("Balance");
            PinFailCount = 0;
            return RedirectToAction("CheckPin");
        }

        public ActionResult Cash()
        {
            if (IsPinChecked)
            {
                ExecutionResult<CardDto> result = CommandBus.ExecuteCommand(new CardRequest() { Value = CardDto.Number }) as ExecutionResult<CardDto>;
                if (result != null && result.Success && result.TypedResult != null)
                {
                    CardDto = result.TypedResult;
                    var model = new CashModel()
                    {
                        CurrencyType = (CurrencyTypeEnum)CardDto.AccountIdObject.CurrencyType
                    };
                    return View(model);

                }
                return RedirectToAction("Index");
            }
            LastActionUrl = Url.Action("Cash");
            PinFailCount = 0;
            return RedirectToAction("CheckPin");
        }

        [HttpPost]
        public ActionResult Cash(CashModel model)
        {
            if (ModelState.IsValid)
            {
                var result = CommandBus.ExecuteCommand(new CashRequest {AccountId = CardDto.AccountId, Summ = model.Value});
                if (result.Success)
                {
                    return View("Success");
                }
                return View("Fail");
            }
            IsPinChecked = false;
            return RedirectToAction("Cash");
        }

        public ActionResult CheckPin()
        {
            var model = new PinModel {FailCount = PinFailCount};
            return View(model);
        }

        [HttpPost]
        public ActionResult CheckPin(PinModel model)
        {
            if (ModelState.IsValid)
            {
                IsPinChecked = true;
                return Redirect(LastActionUrl);
            }
            PinFailCount++;
            if (PinFailCount > 3)
            {
                return RedirectToAction("Index");
            }
            model.FailCount = PinFailCount;
            return View(model);
        }
    }
}
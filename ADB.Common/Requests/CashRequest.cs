using Levshits.Logic.Common;

namespace ADB.Common.Requests
{
    public class CashRequest: RequestBase
    {
        public int AccountId { get; set; }
        public decimal Summ { get; set; }
    }
}
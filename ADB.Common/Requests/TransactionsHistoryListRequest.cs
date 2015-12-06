using Levshits.Data.Common;
using Levshits.Logic.Common;

namespace ADB.Common.Requests
{
    public class TransactionsHistoryListRequest: RequestBase
    {
        public PagingOptions Paging { get; set; }
    }
}
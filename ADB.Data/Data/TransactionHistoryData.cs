using ADB.Data.Entity;
using Levshits.Data;
using Levshits.Data.Data;

namespace ADB.Data.Data
{
    public class TransactionHistoryData: BaseData<TransactionHistoryEntity>
    {
        public TransactionHistoryData(DataProvider dataProvider) : base(dataProvider)
        {
        }
    }
}
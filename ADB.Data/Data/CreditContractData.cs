using ADB.Data.Entity;
using Levshits.Data;
using Levshits.Data.Data;

namespace ADB.Data.Data
{
    public class CreditContractData: BaseData<CreditContractEntity>
    {
        public CreditContractData(DataProvider dataProvider) : base(dataProvider)
        {
        }
    }
}
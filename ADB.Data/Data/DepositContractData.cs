using ADB.Data.Entity;
using Levshits.Data;
using Levshits.Data.Data;

namespace ADB.Data.Data
{
    public class DepositContractData: BaseData<DepositContractEntity>
    {
        public DepositContractData(DataProvider dataProvider) : base(dataProvider)
        {
        }
    }
}
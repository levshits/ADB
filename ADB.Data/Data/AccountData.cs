using ADB.Data.Entity;
using Levshits.Data;
using Levshits.Data.Data;

namespace ADB.Data.Data
{
    public class AccountData: BaseData<AccountEntity>
    {
        public AccountData(DataProvider dataProvider) : base(dataProvider)
        {
        }
    }
}
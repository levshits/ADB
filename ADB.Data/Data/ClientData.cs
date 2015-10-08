using ADB.Data.Entity;
using Levshits.Data;
using Levshits.Data.Data;

namespace ADB.Data.Data
{
    public class ClientData: BaseData<ClientEntity>
    {
        public ClientData(DataProvider dataProvider) : base(dataProvider)
        {
        }
    }
}
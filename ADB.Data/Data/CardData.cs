using ADB.Data.Entity;
using Levshits.Data;
using Levshits.Data.Data;

namespace ADB.Data.Data
{
    public class CardData: BaseData<CardEntity>
    {
        public CardData(DataProvider dataProvider) : base(dataProvider)
        {
        }
    }
}
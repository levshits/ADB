using ADB.Data.Entity;
using Levshits.Logic;
using Levshits.Logic.Common;

namespace ADB.Logic.Blo
{
    public class CreditContractBlo:BloBase<CreditContractEntity>
    {
        public CreditContractBlo(Repository repository) : base(repository)
        {
        }

        public override void Init()
        {
        }

        public override int Priority { get; }
    }
}
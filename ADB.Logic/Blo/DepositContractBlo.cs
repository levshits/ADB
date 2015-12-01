using ADB.Data.Entity;
using Levshits.Logic;
using Levshits.Logic.Common;

namespace ADB.Logic.Blo
{
    public class DepositContractBlo:BloBase<DepositContractEntity>
    {
        public DepositContractBlo(Repository repository) : base(repository)
        {
        }

        public override void Init()
        {
            
        }

        public override int Priority { get; }
    }
}
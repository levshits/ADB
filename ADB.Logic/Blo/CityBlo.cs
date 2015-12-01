using System.Collections.Generic;
using ADB.Common.Immutable;
using ADB.Common.Item;
using ADB.Common.Requests;
using ADB.Data.Common;
using ADB.Data.Entity;
using Levshits.Logic;
using Levshits.Logic.Common;

namespace ADB.Logic.Blo
{
    public class CityBlo : BloBase<CityEntity>
    {
        protected AdbRepository AdbRepository => (AdbRepository) Repository;
        public override int Priority => PriorityLevels.FIRST_LEVEL;

        public CityBlo(Repository repository) : base(repository)
        {
        }

        public ExecutionResult<IList<LookupItem>> GetClientListItems(CityListRequest request, ExecutionContext context)
        {
            return new ExecutionResult<IList<LookupItem>> {TypedResult = AdbRepository.CityData.Cities()};
        }

        public override void Init()
        {
            RegisterCommand<CityListRequest>(GetClientListItems);
        }

       
    }
}
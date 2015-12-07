using System.Collections.Generic;
using ADB.Common.Dto;
using ADB.Common.Immutable;
using ADB.Common.Item;
using ADB.Common.Requests;
using ADB.Data.Common;
using ADB.Data.Entity;
using AutoMapper;
using Levshits.Logic;
using Levshits.Logic.Common;

namespace ADB.Logic.Blo
{
    public class CardBlo: BloBase<CardEntity>
    {
        public AdbRepository AdbRepository => (AdbRepository) Repository;

        public CardBlo(Repository repository) : base(repository)
        {
        }

        public override void Init()
        {
            RegisterCommand<CardListRequest>(GetCardsList);
            RegisterCommand<SaveCardRequest>(SaveCard);
        }

        private ExecutionResult SaveCard(SaveCardRequest request, ExecutionContext context)
        {
            ExecutionResult<CardEntity> result = context.PreviousResult as ExecutionResult<CardEntity>;
            CardDto dto = request.Value as CardDto;
            if (dto == null)
            {
                return null;
            }
            var entity = Mapper.Map<CardEntity>(dto);
            var id = AdbRepository.CardData.Save(entity);
            entity.Number = $"{id:0000000000000000}";
            AdbRepository.CardData.Save(entity);
            return new ExecutionResult();
        }

        private ExecutionResult GetCardsList(CardListRequest request, ExecutionContext context)
        {
            return new ExecutionResult<IList<CardListItem>> { TypedResult = AdbRepository.CardData.Cards(request.Paging)};
        }

        public override int Priority => PriorityLevels.FIRST_LEVEL;
    }
}
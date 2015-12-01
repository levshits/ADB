﻿using ADB.Data.Entity;
using Levshits.Logic;
using Levshits.Logic.Common;

namespace ADB.Logic.Blo
{
    public class AccountBlo: BloBase<AccountEntity>
    {
        public AccountBlo(Repository repository) : base(repository)
        {
        }

        public override void Init()
        {
            
        }

        public override int Priority { get; }
    }
}
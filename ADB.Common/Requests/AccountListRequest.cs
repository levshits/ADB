﻿using Levshits.Data.Common;
using Levshits.Logic.Common;

namespace ADB.Common.Requests
{
    public class AccountListRequest: RequestBase
    {
        public PagingOptions Paging { get; set; }
    }
}
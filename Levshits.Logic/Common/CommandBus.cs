using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Levshits.Logic.Interfaces;

namespace Levshits.Logic.Common
{
    public class CommandBus: ICommandBus
    {
        public ExecutingResult ExecuteCommand(RequestBase request)
        {
            throw new NotImplementedException();
        }

        public ExecitingResult<T> ExecuteCommand<T>(RequestBase request)
        {
            throw new NotImplementedException();
        }
    }
}

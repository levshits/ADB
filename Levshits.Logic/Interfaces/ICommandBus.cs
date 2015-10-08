using System.Runtime.InteropServices.ComTypes;
using Levshits.Logic.Common;

namespace Levshits.Logic.Interfaces
{
    public interface ICommandBus
    {
        ExecutingResult ExecuteCommand(RequestBase request);
        ExecitingResult<T> ExecuteCommand<T>(RequestBase request);
    }
}
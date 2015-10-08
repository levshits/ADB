using System.Collections.Generic;
using Levshits.Logic.Common.Errors;

namespace Levshits.Logic.Common
{
    public class ExecutingResult
    {
        public bool Success { get; set; }
        public object Result { get; set; }
        public List<ErrorBase> Errors { get; set; } 
    }

    public class ExecitingResult<T> : ExecutingResult
    {
        public T TypedResult { get { return (T) Result; } set { Result = value; } }   
    }
}
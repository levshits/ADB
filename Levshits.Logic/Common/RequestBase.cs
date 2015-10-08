using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levshits.Logic.Common
{
    public class RequestBase
    {
        public Object Value { get; set; }
    }

    public class RequestBase<T>
    {
        public T Value { get; set; }    
    }
}

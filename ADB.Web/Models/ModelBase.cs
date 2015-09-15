using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADB.Web.Models
{
    public class ModelBase
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
    }
}
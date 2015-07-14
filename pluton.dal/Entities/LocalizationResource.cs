using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mars.Common;

namespace pluton.dal.Entities
{
    public class LocalizationResource : EntityBase<Guid>
    {
        public string Name { get; set; }
        public string Culture { get; set; }
        public string Value { get; set; }
        public DateTime DateTime { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mars.Common;

namespace pluton.dal.Entities
{
    public class Country : EntityBase<Guid>
    {
        public string CountryShort { get; set; } // nullable:NO// CharLength:255
        public string CountryLong { get; set; } // CharLength:255
        public string Pole { get; set; } // CharLength:255
        public bool Enabled { get; set; }
        public string Region { get; set; } // CharLength:5
        public int ZipPadding { get; set; } // nullable:NO
        public string Language { get; set; } // CharLength:50
        public string LanguageShort { get; set; } // CharLength:10
    }
}

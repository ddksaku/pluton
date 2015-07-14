using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Common.Repositories
{
    public interface IEntity
    {
        bool IsDeleted { get; set; }
    }
}

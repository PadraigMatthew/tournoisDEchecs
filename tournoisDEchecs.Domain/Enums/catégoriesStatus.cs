using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tournoisDEchecs.Domain.Enums
{
    [Flags]
    public enum categoriesStatus
    {
        Junior = 1,
        Senior = 2,
        Veteran = 4,
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInvestigations
{
    interface IMain
    {
        IList<Guid> MyList { get; set; }
    }
}

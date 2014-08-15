using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInvestigations
{
    class ClassA : IMain
    {
        public HashSet<Guid> MyHash { get; set; }
        public IList<Guid> MyList { get; set; }
    }
}

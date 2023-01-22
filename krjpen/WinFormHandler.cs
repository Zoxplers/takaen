using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace krjpen
{
    abstract class WinFormHandler
    {
        internal abstract Size Size { get; set; }
        internal abstract Point Location { get; set; }
    }
}

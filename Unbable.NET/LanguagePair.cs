using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unbable.NET
{
    public class LanguagePair
    {
        public Language Source { get; set; }
        public Language Target { get; set; }

        public String ToString()
        {
            return String.Format("%s -> %s", Source.Name, Target.Name);
        }
    }
}

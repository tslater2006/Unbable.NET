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
            return String.Format("{0} -> {1}", Source.Name, Target.Name);
        }
    }
}

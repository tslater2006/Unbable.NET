using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unbable.NET
{
    public class Language
    {
        public String ShortName { get; set; }
        public String Name { get; set; }

        public String ToString()
        {
            return String.Format("%s [%s]", Name, ShortName);
        }
    }
}

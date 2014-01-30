using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unbable.NET
{
    public class Tone
    {
        public String Name { get; set; }
        public String Description { get; set; }

        public String ToString()
        {
            return String.Format("{0} - {1}",Name,Description);
        }
    }
}

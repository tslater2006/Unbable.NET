using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unbable.NET
{
    public class Translation
    {
        /* 
         * self.uid = uid
        self.text = text
        self.translation = translation
        self.source_language = source_language
        self.target_language = target_language
        self.status = status
        self.translators = translators
        self.topics = topics*/

        public String UID { get; set; }
        public String Text { get; set; }
        public Language Source { get; set; }
        public Language Target { get; set; }
        public String Status { get; set; }
        public List<Translator> Translators { get; set; }
        public List<Topic> Topics { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndependentProject.Models
{
    class AutoComplete
    {
    }

    public class RESULT
    {
        public string name { get; set; }
        public string type { get; set; }
        public string c { get; set; }
        public string zmw { get; set; }
        public string tz { get; set; }
        public string tzs { get; set; }
        public string l { get; set; }
        public string ll { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
    }

    public class AutoCompleteRootObject
    {
        public List<RESULT> RESULTS { get; set; }
    }
}

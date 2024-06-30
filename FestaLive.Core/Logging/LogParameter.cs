using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestaLive.Core.Logging
{
    public class LogParameter
    {
        public string Name { get; set; }
        public object Value { get; set; } // product Nesnesi
        public string Type { get; set; } // product tipi
    }
}

using FestaLive.Core.Entities.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestaLive.Entities.Concrete
{
    public class Footer : IEntity
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string EMail { get; set; }
        public string Location { get; set; }
    }
}

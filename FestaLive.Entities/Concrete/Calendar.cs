using FestaLive.Core.Entities.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestaLive.Entities.Concrete
{
    public class Calendar : IEntity
    {
        public int Id { get; set; }
        public DateTime EventDate { get; set; }
        public List<Event> Events { get; set; }
    }
}

using FestaLive.Core.Entities.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestaLive.Entities.Concrete
{
    public class Event : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Time { get; set; }
        public string Artist { get; set; }
        public DateTime EventDate { get; set; }
    }
}

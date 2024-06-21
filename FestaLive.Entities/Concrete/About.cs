using FestaLive.Core.Entities.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestaLive.Entities.Concrete
{
    public class About : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Subtitle { get; set; }
        public string PartyDescription { get; set; }
        public string IconUrl { get; set; }
        public string MomentTitle { get; set; }
        public string MomentDescription { get; set; }
    }
}

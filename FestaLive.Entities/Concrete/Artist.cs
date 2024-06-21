using FestaLive.Core.Entities.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestaLive.Entities.Concrete
{
    public class Artist : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string MusicGenre { get; set; }
        public string ImageUrl { get; set; }
        public string YoutubeChannel { get; set; }
    }
}

using FestaLive.Core.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestaLive.Entities.Concrete
{
    public class SocialMedia : IEntity
    {
        public int Id { get; set; }
        public string PlatformName { get; set; }
        public string IconUrl { get; set; }
        public string Url { get; set; }
    }
}

using FestaLive.Core.DataAccess.Abstract;
using FestaLive.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestaLive.DataAccess.Abstract
{
    public interface IArtistDal : IEntityRepository<Artist>
    {
        List<Artist> FilterArtists(string name, DateTime? birthdate, string musicGenre, string youtubeChannel);
    }
}

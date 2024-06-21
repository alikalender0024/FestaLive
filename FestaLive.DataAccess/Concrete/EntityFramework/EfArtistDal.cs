using FestaLive.Core.DataAccess.Concrete.EntityFramework;
using FestaLive.DataAccess.Abstract;
using FestaLive.DataAccess.Concrete.Context;
using FestaLive.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestaLive.DataAccess.Concrete.EntityFramework
{
    public class EfArtistDal : EfEntityRepositoryBase<Artist, FestaLiveContext>, IArtistDal
    {
        FestaLiveContext context = new FestaLiveContext();
        public List<Artist> FilterArtists(string name, DateTime? birthdate, string musicGenre, string youtubeChannel)
        {
            var query = context.Artists.AsQueryable();

            // Filtreleme işlemleri
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(a => a.Name.Contains(name));
            }

            if (birthdate.HasValue)
            {
                query = query.Where(a => a.Birthdate == birthdate.Value);
            }

            if (!string.IsNullOrEmpty(musicGenre))
            {
                query = query.Where(a => a.MusicGenre == musicGenre);
            }

            if (!string.IsNullOrEmpty(youtubeChannel))
            {
                query = query.Where(a => a.YoutubeChannel == youtubeChannel);
            }

            return query.ToList();
        }
    }
}

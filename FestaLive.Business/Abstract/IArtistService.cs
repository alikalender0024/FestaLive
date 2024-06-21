using FestaLive.Core.Utilities.Results;
using FestaLive.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestaLive.Business.Abstract
{
    public interface IArtistService
    {
        IResult Add(Artist artist);
        IResult Delete(Artist artist);
        IResult Update(Artist artist);
        IDataResult<Artist> GetById(int artistId);
        IDataResult<List<Artist>> GetAll();
    }
}

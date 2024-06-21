using FestaLive.Business.Abstract;
using FestaLive.Core.Utilities.Results;
using FestaLive.DataAccess.Abstract;
using FestaLive.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace FestaLive.Business.Concrete
{
    public class ArtistManager : IArtistService
    {
        private readonly IArtistDal _artistDal;

        public ArtistManager(IArtistDal artistDal)
        {
            _artistDal = artistDal;
        }

        public IResult Add(Artist artist)
        {
            _artistDal.Add(artist);
            return new SuccessResult("Artist added successfully");
        }

        public IResult Delete(Artist artist)
        {
            _artistDal.Delete(artist);
            return new SuccessResult("Artist deleted successfully");
        }

        public IDataResult<List<Artist>> GetAll()
        {
            var artists = _artistDal.GetAll();
            return new SuccessDataResult<List<Artist>>(artists);
        }

        public IDataResult<Artist> GetById(int artistId)
        {
            var artist = _artistDal.Get(a => a.Id == artistId);
            if (artist != null)
            {
                return new SuccessDataResult<Artist>(artist);
            }
            return new ErrorDataResult<Artist>("Artist not found");
        }

        public IResult Update(Artist artist)
        {
            _artistDal.Update(artist);
            return new SuccessResult("Artist updated successfully");
        }
    }
}

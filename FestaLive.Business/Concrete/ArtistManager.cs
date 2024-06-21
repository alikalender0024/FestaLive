using FestaLive.Business.Abstract;
using FestaLive.Business.Constants.Messages;
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
            return new SuccessResult(ArtistMessages.ArtistAddedSuccessfully);
        }

        public IResult Delete(int artistId)
        {
            var deletedEntity = GetById(artistId);
            _artistDal.Delete(deletedEntity.Data);
            return new SuccessResult(ArtistMessages.ArtistDeletedSuccessfully);
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
            return new ErrorDataResult<Artist>(ArtistMessages.ArtistNotFound);
        }

        public IResult Update(Artist artist)
        {
            _artistDal.Update(artist);
            return new SuccessResult(ArtistMessages.ArtistUpdatedSuccessfully);
        }
    }
}

using FestaLive.Business.Abstract;
using FestaLive.Business.Constants.Messages;
using FestaLive.Business.ValidationRules.FluentValidation;
using FestaLive.Core.Aspects.Autofac.Logging;
using FestaLive.Core.Aspects.Autofac.Validation;
using FestaLive.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using FestaLive.Core.Utilities.Results;
using FestaLive.DataAccess.Abstract;
using FestaLive.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace FestaLive.Business.Concrete
{
    [LogAspect(typeof(FileLogger))]
    public class ArtistManager(IArtistDal artistDal) : IArtistService
    {
        private readonly IArtistDal _artistDal = artistDal;

        [ValidationAspect(typeof(ArtistValidator))]
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

        public IDataResult<List<Artist>> FilterArtists(string? name, DateTime? birthdate, string? musicGenre, string? youtubeChannel)
        {
            var filteredArtists = _artistDal.FilterArtists(name, birthdate, musicGenre, youtubeChannel);
            return new SuccessDataResult<List<Artist>>(filteredArtists);

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

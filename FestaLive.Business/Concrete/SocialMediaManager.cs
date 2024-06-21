using FestaLive.Business.Abstract;
using FestaLive.Business.Constants.Messages;
using FestaLive.Core.Utilities.Results;
using FestaLive.DataAccess.Abstract;
using FestaLive.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace FestaLive.Business.Concrete
{
    public class SocialMediaManager(ISocialMediaDal socialMediaDal) : ISocialMediaService
    {
        private readonly ISocialMediaDal _socialMediaDal = socialMediaDal;

        public IResult Add(SocialMedia socialMedia)
        {
            _socialMediaDal.Add(socialMedia);
            return new SuccessResult(SocialMediaMessages.SocialMediaAddedSuccessfully);
        }

        public IResult Delete(int socialMediaId)
        {
            var existingSocialMedia = GetById(socialMediaId);
            _socialMediaDal.Delete(existingSocialMedia.Data);
            return new SuccessResult(SocialMediaMessages.SocialMediaDeletedSuccessfully);
        }

        public IDataResult<List<SocialMedia>> GetAll()
        {
            var socialMedias = _socialMediaDal.GetAll();
            return new SuccessDataResult<List<SocialMedia>>(socialMedias, SocialMediaMessages.SocialMediasListed);
        }

        public IDataResult<SocialMedia> GetById(int socialMediaId)
        {
            var socialMedia = _socialMediaDal.Get(s => s.Id == socialMediaId);
            if (socialMedia != null)
            {
                return new SuccessDataResult<SocialMedia>(socialMedia);
            }
            return new ErrorDataResult<SocialMedia>(SocialMediaMessages.SocialMediaNotFound);
        }

        public IResult Update(SocialMedia socialMedia)
        {
            _socialMediaDal.Update(socialMedia);
            return new SuccessResult(SocialMediaMessages.SocialMediaUpdatedSuccessfully);
        }
    }
}

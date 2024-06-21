using FestaLive.Business.Abstract;
using FestaLive.Business.Constants.Messages;
using FestaLive.Core.Utilities.Results;
using FestaLive.DataAccess.Abstract;
using FestaLive.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace FestaLive.Business.Concrete
{
    public class AboutManager(IAboutDal aboutDal) : IAboutService
    {
        private readonly IAboutDal _aboutDal = aboutDal;

        public IResult Add(About about)
        {
            _aboutDal.Add(about);
            return new SuccessResult(AboutMessages.AboutAddedSuccessfully);
        }

        public IResult Delete(int aboutId)
        {
            var deletedAbout = GetById(aboutId);
            _aboutDal.Delete(deletedAbout.Data);
            return new SuccessResult(AboutMessages.AboutDeletedSuccessfully); 

        }

        public IDataResult<List<About>> GetAll()
        {
            var abouts = _aboutDal.GetAll();
            return new SuccessDataResult<List<About>>(abouts);
        }

        public IDataResult<About> GetById(int aboutId)
        {
            var about = _aboutDal.Get(a => a.Id == aboutId);
            if (about != null)
            {
                return new SuccessDataResult<About>(about);
            }
            return new ErrorDataResult<About>(AboutMessages.AboutNotFound);
        }

        public IResult Update(About about)
        {
            _aboutDal.Update(about);
            return new SuccessResult(AboutMessages.AboutUpdatedSuccessfully);
        }
    }
}

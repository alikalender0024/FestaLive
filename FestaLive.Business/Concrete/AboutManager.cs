using FestaLive.Business.Abstract;
using FestaLive.Business.BusinessAspect;
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
    [LogAspect(typeof(DatabaseLogger))]
    [LogAspect(typeof(FileLogger))]
    public class AboutManager(IAboutDal aboutDal) : IAboutService
    {
        private readonly IAboutDal _aboutDal = aboutDal;
        [ValidationAspect(typeof(AboutValidator))]
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
       // [SecuredOperation("About.List,Admin")]
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

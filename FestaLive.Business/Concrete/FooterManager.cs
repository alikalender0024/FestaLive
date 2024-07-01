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
    public class FooterManager(IFooterDal footerDal) : IFooterService
    {
        private readonly IFooterDal _footerDal = footerDal;

        [ValidationAspect(typeof(FooterValidator))]
        public IResult Add(Footer footer)
        {
            _footerDal.Add(footer);
            return new SuccessResult(FooterMessages.FooterAddedSuccessfully);
        }

        public IResult Delete(int footerId)
        {
            var existingFooter = GetById(footerId);

            _footerDal.Delete(existingFooter.Data);
            return new SuccessResult(FooterMessages.FooterDeletedSuccessfully);
        }

        public IDataResult<List<Footer>> GetAll()
        {
            var footers = _footerDal.GetAll();
            return new SuccessDataResult<List<Footer>>(footers, FooterMessages.FooterListed);
        }

        public IDataResult<Footer> GetById(int footerId)
        {
            var footer = _footerDal.Get(f => f.Id == footerId);
            if (footer != null)
            {
                return new SuccessDataResult<Footer>(footer);
            }
            return new ErrorDataResult<Footer>(FooterMessages.FootersNotFound);
        }

        public IResult Update(Footer footer)
        {
            _footerDal.Update(footer);
            return new SuccessResult(FooterMessages.FooterUpdatedSuccessfully);
        }
    }
}

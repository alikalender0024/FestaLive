using FestaLive.Business.Abstract;
using FestaLive.Business.Constants.Messages;
using FestaLive.Core.Utilities.Results;
using FestaLive.DataAccess.Abstract;
using FestaLive.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace FestaLive.Business.Concrete
{
    public class FooterManager : IFooterService
    {
        private readonly IFooterDal _footerDal;

        public FooterManager(IFooterDal footerDal)
        {
            _footerDal = footerDal;
        }

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

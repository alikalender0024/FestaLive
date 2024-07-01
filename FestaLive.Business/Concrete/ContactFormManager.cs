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
    public class ContactFormManager(IContactFormDal contactFormDal) : IContactFormService
    {
        private readonly IContactFormDal _contactFormDal = contactFormDal;

        [ValidationAspect(typeof(ContactFormValidator))]
        public IResult Add(ContactForm contactForm)
        {
            _contactFormDal.Add(contactForm);
            return new SuccessResult(ContactFormMessages.ContactFormAddedSuccessfully);
        }

        public IResult Delete(int contactFormId)
        {
            var contactFormToDelete = GetById(contactFormId);
            _contactFormDal.Delete(contactFormToDelete.Data);
            return new SuccessResult(ContactFormMessages.ContactFormDeletedSuccessfully);
        }

        public IDataResult<List<ContactForm>> GetAll()
        {
            var contactForms = _contactFormDal.GetAll();
            return new SuccessDataResult<List<ContactForm>>(contactForms);
        }

        public IDataResult<ContactForm> GetById(int contactFormId)
        {
            var contactForm = _contactFormDal.Get(c => c.Id == contactFormId);
            if (contactForm != null)
            {
                return new SuccessDataResult<ContactForm>(contactForm);
            }
            return new ErrorDataResult<ContactForm>(ContactFormMessages.ContactFormNotFound);
        }

        public IResult Update(ContactForm contactForm)
        {
            _contactFormDal.Update(contactForm);
            return new SuccessResult(ContactFormMessages.ContactFormUpdatedSuccessfully);
        }
    }
}

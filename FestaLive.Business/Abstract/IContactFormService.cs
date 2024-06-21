using FestaLive.Core.Utilities.Results;
using FestaLive.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestaLive.Business.Abstract
{
    public interface IContactFormService
    {
        IResult Add(ContactForm  contactForm);
        IResult Delete(int contactFormId);
        IResult Update(ContactForm contactForm);
        IDataResult<ContactForm> GetById(int contactFormId);
        IDataResult<List<ContactForm>> GetAll();
    }
}

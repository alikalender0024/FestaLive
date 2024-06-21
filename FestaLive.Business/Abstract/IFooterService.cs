using FestaLive.Core.Utilities.Results;
using FestaLive.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestaLive.Business.Abstract
{
    public interface IFooterService
    {
        IResult Add(Footer  footer);
        IResult Delete(int footerId);
        IResult Update(Footer footer);
        IDataResult<Footer> GetById(int footerId);
        IDataResult<List<Footer>> GetAll();
    }
}

using FestaLive.Core.Utilities.Results;
using FestaLive.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestaLive.Business.Abstract
{
    public interface IAboutService
    {
        IResult Add(About  about);
        IResult Delete(int aboutId);
        IResult Update(About about);
        IDataResult<About> GetById(int aboutId);
        IDataResult<List<About>> GetAll();
    }
}

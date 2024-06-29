using FestaLive.Core.Entities.Concrete;
using FestaLive.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestaLive.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetOperationClaims(User user);
        IDataResult<List<User>> GetAll();
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        IDataResult<User> GetById(int userId);
        IDataResult<User> GetByMail(string mail);
    }
}

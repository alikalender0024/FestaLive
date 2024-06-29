using FestaLive.Core.DataAccess.Concrete.EntityFramework;
using FestaLive.Core.Entities.Concrete;
using FestaLive.DataAccess.Abstract;
using FestaLive.DataAccess.Concrete.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestaLive.DataAccess.Concrete.EntityFramework
{

    public class EfUserDal : EfEntityRepositoryBase<User, FestaLiveContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new FestaLiveContext())
            {
                var result = from userOperationClaim in context.UserOperationClaims
                             join operationClaim in context.OperationClaims
                             on userOperationClaim.OperationClaimId equals operationClaim.Id
                             where userOperationClaim.UserId==user.Id
                             select new OperationClaim
                             {
                                 Id = operationClaim.Id,
                                 Name=operationClaim.Name
                             };
                return result.ToList();
            }

        }
    }
}
using FestaLive.Core.DataAccess.Abstract;
using FestaLive.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestaLive.DataAccess.Abstract
{
    public interface IPlanDal : IEntityRepository<Plan>
    {
    }
}

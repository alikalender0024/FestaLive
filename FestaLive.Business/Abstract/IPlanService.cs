using FestaLive.Core.Utilities.Results;
using FestaLive.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestaLive.Business.Abstract
{
    public interface IPlanService
    {
        IResult Add(Plan  plan);
        IResult Delete(int planId);
        IResult Update(Plan plan);
        IDataResult<Plan> GetById(int planId);
        IDataResult<List<Plan>> GetAll();
    }
}

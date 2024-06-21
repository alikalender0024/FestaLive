using FestaLive.Core.Utilities.Results;
using FestaLive.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestaLive.Business.Abstract
{
    public interface IFeatureService
    {
        IResult Add(Feature  feature);
        IResult Delete(int featureId);
        IResult Update(Feature feature);
        IDataResult<Feature> GetById(int featureId);
        IDataResult<List<Feature>> GetAll();
    }
}

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
    public class FeatureManager(IFeatureDal featureDal) : IFeatureService
    {
        private readonly IFeatureDal _featureDal = featureDal;

        [ValidationAspect(typeof(FeatureValidator))]
        public IResult Add(Feature feature)
        {
            _featureDal.Add(feature);
            return new SuccessResult(FeatureMessages.FeatureAddedSuccessfully);
        }

        public IResult Delete(int featureId)
        {
            var existingFeature = GetById(featureId);
            _featureDal.Delete(existingFeature.Data);
            return new SuccessResult(FeatureMessages.FeatureDeletedSuccessfully);

        }

        public IDataResult<List<Feature>> GetAll()
        {
            var features = _featureDal.GetAll();
            return new SuccessDataResult<List<Feature>>(features, FeatureMessages.FeatureListed);
        }

        public IDataResult<Feature> GetById(int featureId)
        {
            var feature = _featureDal.Get(f => f.Id == featureId);
            if (feature != null)
            {
                return new SuccessDataResult<Feature>(feature, FeatureMessages.FeatureListed);
            }
            return new ErrorDataResult<Feature>(FeatureMessages.FeatureNotFound);
        }

        public IResult Update(Feature feature)
        {
            _featureDal.Update(feature);
            return new SuccessResult(FeatureMessages.FeatureUpdatedSuccessfully);
        }
    }
}

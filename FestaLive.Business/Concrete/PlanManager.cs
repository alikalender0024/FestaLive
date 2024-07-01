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
    public class PlanManager(IPlanDal planDal) : IPlanService
    {
        private readonly IPlanDal _planDal = planDal;

        [ValidationAspect(typeof(PlanValidator))]
        public IResult Add(Plan plan)
        {
            _planDal.Add(plan);
            return new SuccessResult(PlanMessages.PlanAddedSuccessfully);
        }

        public IResult Delete(int planId)
        {
            var existingPlan = GetById(planId);
            _planDal.Delete(existingPlan.Data);
            return new SuccessResult(PlanMessages.PlanDeletedSuccessfully);
        }

        public IDataResult<List<Plan>> GetAll()
        {
            var plans = _planDal.GetAll();
            return new SuccessDataResult<List<Plan>>(plans, PlanMessages.PlansListed);
        }

        public IDataResult<Plan> GetById(int planId)
        {
            var plan = _planDal.Get(p => p.Id == planId);
            if (plan != null)
            {
                return new SuccessDataResult<Plan>(plan);
            }
            return new ErrorDataResult<Plan>(PlanMessages.PlanNotFound);
        }

        public IResult Update(Plan plan)
        {
            _planDal.Update(plan);
            return new SuccessResult(PlanMessages.PlanUpdatedSuccessfully);
        }
    }
}

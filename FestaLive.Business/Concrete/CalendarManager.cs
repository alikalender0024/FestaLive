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
    public class CalendarManager(ICalendarDal calendarDal) : ICalendarService
    {
        private readonly ICalendarDal _calendarDal = calendarDal;

        [ValidationAspect(typeof(CalendarValidator))]
        public IResult Add(Calendar calendar)
        {
            _calendarDal.Add(calendar);
            return new SuccessResult(CalendarMessages.CalendarEventAddedSuccessfully);
        }

        public IResult Delete(int calendarId)
        {
            var calendar = GetById(calendarId);

            _calendarDal.Delete(calendar.Data);
            return new SuccessResult(CalendarMessages.CalendarEventDeletedSuccessfully);

        }

        public IDataResult<List<Calendar>> GetAll()
        {
            var calendars = _calendarDal.GetAll();
            return new SuccessDataResult<List<Calendar>>(calendars);
        }

        public IDataResult<Calendar> GetById(int calendarId)
        {
            var calendar = _calendarDal.Get(c => c.Id == calendarId);
            if (calendar != null)
            {
                return new SuccessDataResult<Calendar>(calendar);
            }
            return new ErrorDataResult<Calendar>(CalendarMessages.CalendarEventNotFound);
        }

        public IResult Update(Calendar calendar)
        {
            _calendarDal.Update(calendar);
            return new SuccessResult(CalendarMessages.CalendarEventUpdatedSuccessfully);
        }
    }
}

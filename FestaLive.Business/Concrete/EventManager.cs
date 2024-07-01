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
    public class EventManager(IEventDal eventDal) : IEventService
    {
        private readonly IEventDal _eventDal = eventDal;

        [ValidationAspect(typeof(EventValidator))]
        public IResult Add(Event @event)
        {
            _eventDal.Add(@event);
            return new SuccessResult(EventMessages.EventAddedSuccessfully);
        }

        public IResult Delete(int eventId)
        {
            var eventToDelete = GetById(eventId);
            {
                _eventDal.Delete(eventToDelete.Data);
                return new SuccessResult(EventMessages.EventDeletedSuccessfully);

            }
        }
        public IDataResult<List<Event>> GetAll()
        {
            var events = _eventDal.GetAll();
            return new SuccessDataResult<List<Event>>(events);
        }

        public IDataResult<Event> GetById(int eventId)
        {
            var @event = _eventDal.Get(e => e.Id == eventId);
            if (@event != null)
            {
                return new SuccessDataResult<Event>(@event);
            }
            return new ErrorDataResult<Event>(EventMessages.EventNotFound);
        }

        public IResult Update(Event @event)
        {

            _eventDal.Update(@event);
            return new SuccessResult(EventMessages.EventUpdatedSuccessfully);

        }
    }
}

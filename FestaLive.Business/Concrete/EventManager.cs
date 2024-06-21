using FestaLive.Business.Abstract;
using FestaLive.Business.Constants.Messages;
using FestaLive.Core.Utilities.Results;
using FestaLive.DataAccess.Abstract;
using FestaLive.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace FestaLive.Business.Concrete
{
    public class EventManager : IEventService
    {
        private readonly IEventDal _eventDal;

        public EventManager(IEventDal eventDal)
        {
            _eventDal = eventDal;
        }

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

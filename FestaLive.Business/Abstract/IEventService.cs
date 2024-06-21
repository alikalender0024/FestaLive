using FestaLive.Core.Utilities.Results;
using FestaLive.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestaLive.Business.Abstract
{
    public interface IEventService
    {
        IResult Add(Event  @event);
        IResult Delete(int eventId);
        IResult Update(Event @event);
        IDataResult<Event> GetById(int eventId);
        IDataResult<List<Event>> GetAll();
    }
}

using FestaLive.Core.Utilities.Results;
using FestaLive.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestaLive.Business.Abstract
{
    public interface ICalendarService
    {
        IResult Add(Calendar  calendar);
        IResult Delete(int calendarId);
        IResult Update(Calendar calendar);
        IDataResult<Calendar> GetById(int calendarId);
        IDataResult<List<Calendar>> GetAll();
    }
}

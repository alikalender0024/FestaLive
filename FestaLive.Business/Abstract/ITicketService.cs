using FestaLive.Core.Utilities.Results;
using FestaLive.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestaLive.Business.Abstract
{
    public interface ITicketService
    {
        IResult Add(Ticket  ticket);
        IResult Delete(int ticketId);
        IResult Update(Ticket ticket);
        IDataResult<Ticket> GetById(int ticketId);
        IDataResult<List<Ticket>> GetAll();
    }
}

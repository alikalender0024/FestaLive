using FestaLive.Business.Abstract;
using FestaLive.Business.Constants.Messages;
using FestaLive.Core.Utilities.Results;
using FestaLive.DataAccess.Abstract;
using FestaLive.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace FestaLive.Business.Concrete
{
    public class TicketManager(ITicketDal ticketDal) : ITicketService
    {
        private readonly ITicketDal _ticketDal = ticketDal;

        public IResult Add(Ticket ticket)
        {
            _ticketDal.Add(ticket);
            return new SuccessResult(TicketMessages.TicketAddedSuccessfully);
        }

        public IResult Delete(int ticketId)
        {
            var existingTicket = GetById(ticketId);

            _ticketDal.Delete(existingTicket.Data);
            return new SuccessResult(TicketMessages.TicketDeletedSuccessfully);

        }

        public IDataResult<List<Ticket>> GetAll()
        {
            var tickets = _ticketDal.GetAll();
            return new SuccessDataResult<List<Ticket>>(tickets, TicketMessages.TicketsListed);
        }

        public IDataResult<Ticket> GetById(int ticketId)
        {
            var ticket = _ticketDal.Get(t => t.Id == ticketId);
            if (ticket != null)
            {
                return new SuccessDataResult<Ticket>(ticket);
            }
            return new ErrorDataResult<Ticket>(TicketMessages.TicketNotFound);
        }

        public IResult Update(Ticket ticket)
        {
            _ticketDal.Update(ticket);
            return new SuccessResult(TicketMessages.TicketUpdatedSuccessfully);
        }
    }
}

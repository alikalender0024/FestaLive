using FestaLive.Business.Abstract;
using FestaLive.Business.BusinessAspect;
using FestaLive.Business.Constants.Messages;
using FestaLive.Business.ValidationRules.FluentValidation;
using FestaLive.Core.Aspects.Autofac.Caching;
using FestaLive.Core.Aspects.Autofac.Logging;
using FestaLive.Core.Aspects.Autofac.Performance;
using FestaLive.Core.Aspects.Autofac.Transaction;
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
    public class TicketManager(ITicketDal ticketDal) : ITicketService
    {
        private readonly ITicketDal _ticketDal = ticketDal;
        [CacheRemoveAspect(pattern: "ITicketService.Get")]
        [ValidationAspect(typeof(TicketValidator))]
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
        [PerformanceAspect(1)]
        [SecuredOperation("Ticket.Getall,Admin")]
        [CacheAspect(duration: 1)]
        public IDataResult<List<Ticket>> GetAll()
        {
            var tickets = _ticketDal.GetAll();
            return new SuccessDataResult<List<Ticket>>(tickets, TicketMessages.TicketsListed);
        }
        [TransactionScopeAspect]
        public IResult TransactionalOperation(Ticket ticket)
        {
            _ticketDal.Update(ticket);
            _ticketDal.Add(ticket);
            return new SuccessResult(TicketMessages.TicketUpdatedSuccessfully);
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

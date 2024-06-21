using FestaLive.Core.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestaLive.Entities.Concrete
{
    public class Ticket : IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string TicketType { get; set; }
        public int NumberOfTickets { get; set; }
        public string PhoneAdditionalRequest { get; set; }
    }
}

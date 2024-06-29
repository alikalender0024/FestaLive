using FestaLive.Business.Abstract;
using FestaLive.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace FestaLive.WebUI.Controllers
{
    public class TicketController(ITicketService ticketService) : Controller
    {
        private readonly ITicketService _ticketService = ticketService;

        public IActionResult Buy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BuyTicket(Ticket ticket)
        {
                _ticketService.Add(ticket);
                return RedirectToAction("Index", "Default");
        }
    }
}

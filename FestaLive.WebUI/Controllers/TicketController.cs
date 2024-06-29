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
        public IActionResult TicketList()
        {
            var result = _ticketService.GetAll().Data;
            return View(result);
        }

        public IActionResult UpdateTicket(int id)
        {
            var ticket = _ticketService.GetById(id).Data;
            return View(ticket);
        }

        [HttpPost]
        public IActionResult UpdateTicket(Ticket ticket)
        {
            _ticketService.Update(ticket);
            return RedirectToAction("TicketList");
        }

        [HttpPost]
        public IActionResult DeleteTicket(int id)
        {
            _ticketService.Delete(id);
            return RedirectToAction("TicketList");
        }
    }
}
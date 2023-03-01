using BusinessLayer;
using CommanLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartTech.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SmartTech.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        TicketBL business = new TicketBL();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var ticketCL = new List<TicketCL>();
            try
            {
                ticketCL = business.GetTickets();
                return View(ticketCL);
            }
            catch(Exception)
            {
                throw;
            }
            
        }

        public IActionResult CreateTicket()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTicket(TicketCL ticketCL)
        {
            if(ModelState.IsValid)
            {
                Random generator = new Random();
                int RandomNo = generator.Next(100000, 999999);

                var username = User.Identity.Name;

                ticketCL.TicketNo = RandomNo;
                ticketCL.UserName = username;

                business.CreateTicket(ticketCL);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult TicketDetails()
        {
            var ticketCL = new List<TicketCL>();
            var UserAuthoCL = new List<UserAuthoCL>();
            try
            {

                return View();
            }
            catch(Exception)
            {
                throw;
            }

        }

        [HttpPost]
        public IActionResult CreateDescription(TicketCL ticketCL)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("TicketDetails");
            }
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

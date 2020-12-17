using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Data.Entities;
using WebApplication2.Models;
using WebApplication2.Services;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
      //  private readonly ILogger<HomeController> _logger;
        private readonly IMailService _mailService;
        private readonly IApplicationRepository _repository;
       // private readonly ApplicationDbContext _context;

        public HomeController(IMailService mailService, IApplicationRepository repository)
        {
            _mailService = mailService;
            _repository = repository;
           // _context = context;
        }


        public IActionResult Index()
        {
            var results = _repository.GetAllProducts();
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                //send email
                _mailService.SendMessage("matt@gmaiol.com", model.Subject, $"From:{model.Name} - {model.Email}, Message:{model.Message}");
                ViewBag.UserMessage = "Mail sent";
                ModelState.Clear();
            }


            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About Us";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Shop() 
        {
           // var results =  _repository.GetAllProducts();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

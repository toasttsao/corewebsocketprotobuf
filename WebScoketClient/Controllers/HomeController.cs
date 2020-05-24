using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebScoketClient.Models;
using WebScoketClient.Services;

namespace WebScoketClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGenerateJwtTokenService _generateJwt;
        public HomeController(ILogger<HomeController> logger, IGenerateJwtTokenService generateJwt)
        {
            _logger = logger;
            _generateJwt = generateJwt;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignalrClient()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Login([FromForm]string username)
        {
          var ss =  _generateJwt.GenerateJwtToken(username);
            
            
            return Ok(ss);
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}
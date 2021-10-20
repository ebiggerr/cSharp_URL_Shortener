using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using cSharp_URL_Shortener.Models;
using cSharp_URL_Shortener.Services;

namespace cSharp_URL_Shortener.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRedirectsService _IRedirectsService;
        private readonly IStatisticsService _statisticsService;

        public HomeController(ILogger<HomeController> logger,
            IRedirectsService redirectsService,
            IStatisticsService statisticsService)
        {
            _logger = logger;
            _IRedirectsService = redirectsService;
            _statisticsService = statisticsService;
        }

        [Route("/{shortenLink}")]
        [HttpGet]
        public IActionResult Index(string shortenLink)
        {
            string originalUrl = null;
            
            if (shortenLink == null)
            {
                return View("Create");
            }

            var redirect= _IRedirectsService.GetByShortenLink(shortenLink).Result;

            originalUrl = redirect.URL;
            
            // add stats
            _statisticsService.Add(redirect.Id);

            if (originalUrl == null)
            {
                return View("Error");
            }

            //return View();
            return Redirect(originalUrl);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}
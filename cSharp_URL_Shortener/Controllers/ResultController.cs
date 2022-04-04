using cSharp_URL_Shortener.Models;
using Microsoft.AspNetCore.Mvc;

namespace cSharp_URL_Shortener.Controllers
{
    public class ResultController: Controller
    {
        [Route("/Result")]
        public IActionResult Index(string ResultString)
        { 
            
            return View("Result", new Result(ResultString));
        }
    }
}
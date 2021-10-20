using System;
using System.Collections.Generic;
using cSharp_URL_Shortener.Models.Redirect;
using cSharp_URL_Shortener.Services;
using Microsoft.AspNetCore.Mvc;

namespace cSharp_URL_Shortener.Controllers
{
    public class CreateController: Controller
    {
        private static readonly List<int> Numbers = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9, 0};  
        private static readonly List<char> Characters = new List<char>()   
        {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',   
            'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B',   
            'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',   
            'Q', 'R', 'S',  'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '_'};

        private readonly IRedirectsService _redirectsService;

        public CreateController(IRedirectsService redirectsService)
        {
            _redirectsService = redirectsService;
        }

        //Default controller, the so call 'entry point'
        public IActionResult Index()
        {
            return Redirect("/Home/Create");
        }

        //User creating shortened link
        public IActionResult Create(CreateRedirectDto input)
        {
            // initialize
            var redirect = Models.Redirect.Redirect.Create("",
                input.URL);
            
            // User do not have preferred suffix
            if (input.ShortenLink is null or "")
            {
                redirect.ShortenLink = GenerateShort();
            }
            else
            {
                redirect.ShortenLink = input.ShortenLink;
            }

            _redirectsService.Create(redirect);

            //TODO revise needed, it should show the result to user
            return View("Error");
        }

        public static string GenerateShort()
        {
            string result = null;
            
            Random rand = new Random();  
            // run the loop till I get a string of 10 characters  
            for (int i = 0; i < 11; i++) {  
                // Get random numbers, to get either a character or a number...  
                int random = rand.Next(0, 3);  
                if(random == 1) {  
                    // use a number  
                    random = rand.Next(0, Numbers.Count);  
                    result += Numbers[random].ToString();  
                } else {  
                    random = rand.Next(0, Characters.Count);  
                    result += Characters[random].ToString();  
                }  
            }  
            return result;
        }
    }
}
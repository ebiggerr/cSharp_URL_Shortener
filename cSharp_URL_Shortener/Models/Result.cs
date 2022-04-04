using System;

namespace cSharp_URL_Shortener.Models
{
    public class Result
    {
        public string ResultString { get; set; }

        public Result(string resultString)
        {
            ResultString = resultString ?? throw new ArgumentNullException(nameof(resultString));
        }
    }
}
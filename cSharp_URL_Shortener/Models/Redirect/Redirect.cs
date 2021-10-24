using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace cSharp_URL_Shortener.Models.Redirect
{
    [Table("Redirects")]
    public class Redirect: FullAuditedEntity
    {
        public string ShortenLink { get; set; }

        public string URL { get; set; }

        //public Statistics Statistics { get; set; }

        public Redirect()
        {
        }

        protected Redirect(string shortenLink, string url)
        {
            Id = Guid.NewGuid();
            CreationTime = DateTime.Now;
            ShortenLink = shortenLink;
            URL = CheckAndValidate(url);
        }

        public static Redirect Create(string shortenLink, string url)
        {
            return new Redirect(shortenLink, url);
        }

        public static string CheckAndValidate(string urlInput)
        {
            if (urlInput.StartsWith("www"))
            {
                return "https://" + urlInput;
            }

            /*if (urlInput.StartsWith("https://"))
            {
                return urlInput;
            }*/

            return urlInput;
        }

    }
}
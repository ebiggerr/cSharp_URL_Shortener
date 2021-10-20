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
            Id = new Guid();
            CreationTime = DateTime.Now;
            ShortenLink = shortenLink;
            URL = url;
        }

        public static Redirect Create(string shortenLink, string url)
        {
            return new Redirect(shortenLink, url);
        }

    }
}
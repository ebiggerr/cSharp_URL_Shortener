namespace cSharp_URL_Shortener.Models.Redirect
{
    public class CreateRedirectDto
    {
        public string ShortenLink { get; set; }

        public string URL { get; set; }

        public CreateRedirectDto()
        {
        }

        public CreateRedirectDto(string shortenLink, string url)
        {
            ShortenLink = shortenLink;
            URL = url;
        }
    }
}
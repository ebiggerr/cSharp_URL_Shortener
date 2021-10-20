namespace cSharp_URL_Shortener.Models.Redirect
{
    public class CreateRedirectDto
    {
        // The result, shortened link
        public string ShortenLink { get; set; }

        // The link that user want to make it short
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
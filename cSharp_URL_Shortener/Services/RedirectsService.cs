using System.Threading.Tasks;
using cSharp_URL_Shortener.Models.Redirect;
using cSharp_URL_Shortener.Repository;

namespace cSharp_URL_Shortener.Services
{
    public class RedirectsService
    {
        private readonly RedirectsRepo _redirectsRepo;

        public RedirectsService(RedirectsRepo redirectsRepo)
        {
            _redirectsRepo = redirectsRepo;
        }

        public async Task<Redirect> GetByShortenLink(string shortenLink)
        {
            return await _redirectsRepo.GetByShortenLink(shortenLink);
        }

        public async Task<Redirect> Create(CreateRedirectDto input)
        {
            var redirect = Redirect.Create(input.ShortenLink, input.URL);
            
            return await _redirectsRepo.Save(redirect);
        }
    }
}
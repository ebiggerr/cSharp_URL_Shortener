using System.Threading.Tasks;
using cSharp_URL_Shortener.Models.Redirect;
using cSharp_URL_Shortener.Repository;

namespace cSharp_URL_Shortener.Services
{
    public class RedirectsService: IRedirectsService
    {
        private readonly IRedirectsRepo _iRedirectsRepo;

        public RedirectsService(IRedirectsRepo redirectsRepo)
        {
            _iRedirectsRepo = redirectsRepo;
        }

        public async Task<Redirect> GetByShortenLink(string shortenLink)
        {
            return await _iRedirectsRepo.GetByShortenLink(shortenLink);
        }

        public async Task<Redirect> Create(Redirect input)
        {
            return await _iRedirectsRepo.Save(input);
        }
    }
}
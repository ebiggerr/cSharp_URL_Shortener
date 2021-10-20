using System.Threading.Tasks;
using cSharp_URL_Shortener.Models.Redirect;

namespace cSharp_URL_Shortener.Services
{
    public interface IRedirectsService
    {
        Task<Redirect> GetByShortenLink(string shortenLink);

        Task<Redirect> Create(Redirect input);
    }
}
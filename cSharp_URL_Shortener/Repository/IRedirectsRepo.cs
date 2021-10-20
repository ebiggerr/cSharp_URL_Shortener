using System.Threading.Tasks;
using cSharp_URL_Shortener.Models.Redirect;

namespace cSharp_URL_Shortener.Repository
{
    public interface IRedirectsRepo
    {
        Task<Redirect> GetByShortenLink(string shortenLink);
        
        Task<Redirect> Save(Redirect input);
    }
}
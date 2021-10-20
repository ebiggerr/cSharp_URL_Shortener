using System.Threading.Tasks;
using cSharp_URL_Shortener.Models;

namespace cSharp_URL_Shortener.Repository
{
    public interface IStatisticsRepo
    {
        Task<Statistics> Save(Statistics input);
    }
}
using System;
using System.Threading.Tasks;
using cSharp_URL_Shortener.Models;

namespace cSharp_URL_Shortener.Services
{
    public interface IStatisticsService
    {
        Task<Statistics> Add(Guid RedirectId);
    }
}
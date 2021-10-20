using System;
using System.Threading.Tasks;
using cSharp_URL_Shortener.Models;
using cSharp_URL_Shortener.Repository;

namespace cSharp_URL_Shortener.Services
{
    public class StatisticsService: IStatisticsService
    {
        private readonly IStatisticsRepo _statisticsRepo;

        public StatisticsService(IStatisticsRepo statisticsRepo)
        {
            _statisticsRepo = statisticsRepo;
        }

        public async Task<Statistics> Add(Guid redirectId)
        {
            var entity = new Statistics(redirectId, DateTime.Now);

            await _statisticsRepo.Save(entity);

            return entity;
        }
    }
}
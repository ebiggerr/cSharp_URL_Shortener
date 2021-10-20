using System.Threading.Tasks;
using cSharp_URL_Shortener.EF;
using cSharp_URL_Shortener.Models;

namespace cSharp_URL_Shortener.Repository
{
    public class StatisticsRepo: IStatisticsRepo
    {
        private readonly cSharp_URL_ShortenerDbContext _context;

        public StatisticsRepo(cSharp_URL_ShortenerDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Statistics> Save(Statistics input)
        {
            _context.Add(input);
            await _context.SaveChangesAsync();
            
            return input;
        }
    }
}
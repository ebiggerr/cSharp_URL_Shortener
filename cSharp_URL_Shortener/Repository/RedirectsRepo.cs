using System.Linq;
using System.Threading.Tasks;
using cSharp_URL_Shortener.EF;
using cSharp_URL_Shortener.Models.Redirect;
using Microsoft.EntityFrameworkCore;

namespace cSharp_URL_Shortener.Repository
{
    public class RedirectsRepo
    {
        private readonly cSharp_URL_ShortenerDbContext _context;

        public RedirectsRepo(cSharp_URL_ShortenerDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Redirect> GetByShortenLink(string shortenLink)
        {
            return await _context.Redirects.FirstOrDefaultAsync( x => x.ShortenLink == shortenLink);
        }

        public async Task<Redirect> Save(Redirect entity)
        {
            _context.Add(entity);

            await _context.SaveChangesAsync();

            return entity;
        }
        
    }
}
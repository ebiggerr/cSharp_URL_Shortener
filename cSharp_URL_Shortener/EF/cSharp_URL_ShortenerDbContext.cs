using System;
using cSharp_URL_Shortener.Models;
using cSharp_URL_Shortener.Models.Redirect;
using Microsoft.EntityFrameworkCore;

namespace cSharp_URL_Shortener.EF
{
    public class cSharp_URL_ShortenerDbContext: DbContext, IcSharp_URL_ShortenerDbContext
    {
        
        public cSharp_URL_ShortenerDbContext(DbContextOptions<cSharp_URL_ShortenerDbContext> options)
        : base(options)
        {
            
        }
        
        public DbSet<Redirect> Redirects { get; set; }
        public DbSet<Statistics> Statistics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Indexing
            modelBuilder.Entity<Redirect>()
                .HasIndex(x => x.ShortenLink)
                .IsUnique();
            
            /*modelBuilder.Entity<Redirect>()
                .HasRequired<Statistics>(x => x.Redirect)
                .WithMany(y => y.Redirects)
                .HasForeignKey<Guid>(z => z.RedirectId);*/     
        }
    }
}
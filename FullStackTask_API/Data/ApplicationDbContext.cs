using FullStackTask_API.Model;
using Microsoft.EntityFrameworkCore;

namespace FullStackTask_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<Drzava> Drzava { get; set; }
        public DbSet<Naselje> Naselje { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drzava>().HasData(
                
            new Drzava
            {
                Id = 1,
                Naziv = "Hrvatska",
                CreatedDate = new DateTime(2024, 2, 13)
            },

            new Drzava
            {
                Id = 2,
                Naziv = "Slovenija",
                CreatedDate = new DateTime(2024, 2, 13)
            },
            new Drzava
            {
                Id = 3,
                Naziv = "Italija",
                CreatedDate = new DateTime(2024, 2, 10)
            },
            new Drzava
            {
                Id = 4,
                Naziv = "Austrija",
                CreatedDate = new DateTime(2024, 2, 15)
            },
            new Drzava
            {
                Id = 5,
                Naziv = "Francuska",
                CreatedDate = new DateTime(2024, 2, 18)
            });

            modelBuilder.Entity<Naselje>().HasData(
            new Naselje
            {
                Id = 1,
                DrzavaId = 1,
                PostanskiBroj = 10000,
                Naziv = "Dubrava",
                CreatedDate = new DateTime()
            },
            new Naselje
            {
                Id = 2,
                DrzavaId = 2,
                PostanskiBroj = 2000,
                Naziv = "Dobova",
                CreatedDate = new DateTime()
            },
            new Naselje
            {
                Id = 3,
                DrzavaId = 5,
                PostanskiBroj = 5623,
                Naziv = "Pariz",
                CreatedDate = new DateTime()
            });

        }
    }
}

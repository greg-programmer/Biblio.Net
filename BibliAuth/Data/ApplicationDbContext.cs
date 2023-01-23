using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BibliAuth.Models;

namespace BibliAuth.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Auteur> Auteur { get; set; }
        public DbSet<Livre> Livre { get; set; }
        public DbSet<Genre> Genre { get; set; }
    }
}
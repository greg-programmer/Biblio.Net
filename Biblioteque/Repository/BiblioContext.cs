using Biblioteque.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Biblioteque.Repository
{
    public class BiblioContext : DbContext
    {
        private string connectionString = string.Empty;
        public BiblioContext(DbContextOptions options) : base(options)
        {
            //var builder = new ConfigurationBuilder();
            //builder.AddJsonFile("appsettings.json", optional: false);
            //var configuration = builder.Build();
            //connectionString = configuration.GetConnectionString("SQLConnection").ToString();

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Livre>()
                 .HasMany(left => left.Auteurs)
                 .WithMany(right => right.Livres)
                 .UsingEntity(join => join.ToTable("Auteur_Livre"));
            modelBuilder.Entity<Livre>()
                .HasMany(left => left.Genres)
                .WithMany(right => right.Livres)
                .UsingEntity(join => join.ToTable("Genre_Livre"));
            /*modelBuilder.Entity<GenreLivre>().HasKey(lg => new { lg.Livre_Id, lg.Genre_Id });
              modelBuilder.Entity<GenreLivre>().HasOne<Genre>(lg => lg.Genres).WithMany(lg => lg.GenreLivres).HasForeignKey(lg => lg.Genre_Id);
              modelBuilder.Entity<GenreLivre>().HasOne<Livre>(lg => lg.Livres).WithMany(lg => lg.GenreLivres).HasForeignKey(lg => lg.Livre_Id);


              modelBuilder.Entity<AuteurLivre>().HasKey(lg => new {lg.Livre_Id, lg.Auteur_Id });
              modelBuilder.Entity<AuteurLivre>().HasOne<Auteur>(la => la.Auteurs).WithMany(la => la.AuteurLivres).HasForeignKey(lg => lg.Auteur_Id);
              modelBuilder.Entity<AuteurLivre>().HasOne<Livre>(lg => lg.Livres).WithMany(lg => lg.AuteurLivres).HasForeignKey(lg => lg.Livre_Id);*/
        }
             
        public DbSet<Livre> Livres { get; set; }
        public DbSet<Auteur> Auteurs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        
        //public DbSet<GenreLivre> GenreLivres { get; set; }
        //public DbSet<AuteurLivre> AuteurLivres { get; set; }
    }
}

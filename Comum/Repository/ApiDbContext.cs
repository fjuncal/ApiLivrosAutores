using Comum.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace Comum.Repository
{
    public sealed class ApiDbContext : DbContext
    {
        public DbSet<Models.Autor> Autor { get; set; }
        public DbSet<Models.Livro> Livro { get; set; }

        public DbSet<AutorLivro> AutorLivro { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
            //irá criar o banco e a estrutura de tabelas necessárias
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(@"host=localhost;database=LivroApi;user id=postgres;password=admin;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*
            modelBuilder.Entity<Models.Autor>().HasKey(t => t.Id);
            modelBuilder.Entity<Models.Livro>().HasKey(t => t.Id);
            modelBuilder.Entity<AutorLivro>().HasKey(sc => new { sc.AutorId, sc.LivroId });
            */

            modelBuilder.Entity<AutorLivro>()
                .HasOne(b => b.Livro)
                .WithMany(ba => ba.AutorLivroList)
                .HasForeignKey(bi => bi.LivroId);

            modelBuilder.Entity<AutorLivro>()
                .HasOne(b => b.Autor)
                .WithMany(ba => ba.AutorLivroList)
                .HasForeignKey(bi => bi.AutorId);
        }
        
        
    }
}
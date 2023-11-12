using Challenge_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Challenge_2.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Receitas> Receitas {get;set;}
        public DbSet<Despesas> Despesas {get;set;}
    }
}
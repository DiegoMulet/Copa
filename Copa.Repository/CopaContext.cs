using Copa.Domain;
using Microsoft.EntityFrameworkCore;

namespace Copa.Repository
{
    public class CopaContext : DbContext
    {
        public CopaContext(DbContextOptions<CopaContext> options) : base(options){}

        public DbSet<Selecao> Selecoes { get; set; }
        public DbSet<Chave> Chaves { get; set; }
    }
}
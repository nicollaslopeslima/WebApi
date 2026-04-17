using Microsoft.EntityFrameworkCore;

namespace WebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {  
        }

        public DbSet<Models.EmpresaModel> Empresas { get; set; }
        public DbSet<Models.JogoModel> Jogos { get; set; }
    }
}

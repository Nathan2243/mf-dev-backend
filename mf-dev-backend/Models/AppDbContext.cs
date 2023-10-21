using Microsoft.EntityFrameworkCore;

namespace mf_dev_backend.Models

{
    // AppDBContext é uma classe que foi criada para herdar todo o conteudo de Banco de dados, que seria DbContext
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Veiculo> Veiculos { get; set; }
    }
}

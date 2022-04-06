using consultaCliente.Dominios;
using consultaCliente.Shared;
using Microsoft.EntityFrameworkCore;

namespace consultaCliente.Database {
    public class DataContext : DbContext {

        public DataContext(DbContextOptions<DataContext> options) : base(options) {

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<PlanoVip> PlanosVips { get; set; }
    }
}

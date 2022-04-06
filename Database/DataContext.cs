using consultaCliente.Adm.Modelo;
using consultaCliente.Compartilhado;
using consultaCliente.Modelos;
using Microsoft.EntityFrameworkCore;

namespace consultaCliente.Database {
    public class DataContext : DbContext {

        public DataContext(DbContextOptions<DataContext> options) : base(options) {

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<PlanoVip> PlanosVips { get; set; }
        public DbSet<Gestor> Gestores { get; set; }
    }
}

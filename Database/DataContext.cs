using consultaCliente.Dominios;
using Microsoft.EntityFrameworkCore;

namespace consultaCliente.Database {
    public class DataContext : DbContext {

        public DataContext(DbContextOptions<DataContext> options) : base(options) {

        }

        public DbSet<User> Users { get; set; }
      

    }
}

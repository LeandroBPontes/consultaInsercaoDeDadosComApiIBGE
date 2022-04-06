using consultaCliente.Dominios;
using System;
using System.Collections.Generic;


namespace consultaConsulta.Repositories.Contracts {
    public interface IRepositorioBase : IDisposable {
            IEnumerable<Cliente> Get();
            Cliente GetByID(int id);
            void Insert(Cliente model);
            void Delete(int id);
            void Update(Cliente model);
    }
}

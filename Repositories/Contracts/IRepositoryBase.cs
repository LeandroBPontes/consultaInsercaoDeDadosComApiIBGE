using consultaCliente.Dominios;
using System;
using System.Collections.Generic;


namespace consultaConsulta.Repositories.Contracts {
    public interface IRepositoryBase : IDisposable {
            IEnumerable<User> Get();
            User GetByID(int id);
            void Insert(User model);
            void Delete(int id);
            void Update(User model);
    }
}

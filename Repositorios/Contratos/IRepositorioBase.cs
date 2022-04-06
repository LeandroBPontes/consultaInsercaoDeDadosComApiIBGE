using System;
using System.Collections.Generic;


namespace consultaCliente.Repositorios.Contratos {
    public interface IRepositorioBase<TEntidade, TPrimary> : IDisposable {
            IEnumerable<TEntidade> Get();
            TEntidade GetByID(TPrimary id);
            void Insert(TEntidade model);
            void Delete(TPrimary id);
            void Update(TEntidade model);
    }
}

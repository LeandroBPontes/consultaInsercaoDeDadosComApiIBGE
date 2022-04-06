using consultaCliente.Compartilhado;
using consultaCliente.Modelos;
using consultaCliente.Repositorios.Contratos;

namespace consultaCliente.Dominios {
    public class PlanoVipDominio {
   
        private readonly IRepositorioBase<PlanoVip, int> _repositorioPlanoVip;
        public PlanoVipDominio(IRepositorioBase<Cliente, int> repositorio, IRepositorioBase<PlanoVip, int> repositorioPlanoVip) {
            _repositorioPlanoVip = repositorioPlanoVip;
        }

        public void inserePlanoVip(PlanoVip model) {
             _repositorioPlanoVip.Insert(model);
        } 
    }
}

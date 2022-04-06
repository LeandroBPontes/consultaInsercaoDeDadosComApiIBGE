
using consultaCliente.Modelos;

namespace consultaCliente.Compartilhado {
    public class PosCadastro {
        public bool Cadastrado { get; set; }
        public bool OferecerPlanoVip { get; set; }
        public void MensagemPosCadastro(Cliente model) {
            if(model.RendaMensal != null && model.RendaMensal >= 6000) {
                this.Cadastrado = true;
                //oferece plano vip
                this.OferecerPlanoVip = true;
            }
            else {
                this.Cadastrado = true;
                //nao oferece plano vip
                this.OferecerPlanoVip = false;
            }

        }

    }
}

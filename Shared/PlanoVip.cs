
using consultaCliente.Dominios;
using System.ComponentModel.DataAnnotations.Schema;

namespace consultaCliente.Shared {
    public class PlanoVip {
        public double Preco => 50000;
        public string Descricao => "O Plano Vip possui muitos benefícios além dos já obtidos. Não perca!";

        [ForeignKey("IdCliente")]
        public virtual Cliente Cliente { get; set; }
        public int IdCliente { get; set; }
    }
}

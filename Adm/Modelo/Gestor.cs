using System.ComponentModel.DataAnnotations;

namespace consultaCliente.Adm.Modelo {
    public class Gestor {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Este campo é obragatório")]
        [MaxLength(50, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        public string NomeCompleto{ get; set; }
    }
}

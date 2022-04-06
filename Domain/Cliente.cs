

using System.ComponentModel.DataAnnotations;

namespace consultaCliente.Dominios {
    public class Cliente {
        /* Dados da Pessoa: NomeCompleto, DataNascimento, CPF.
         Dados do endereço da Pessoa: Logradouro, Bairro, CEP, Cidade, UF, Complemento.
         Dados financeiros da pessoa: Renda mensal.*/
        public int? Id { get; set; }

        [Required(ErrorMessage = "Este campo é obragatório")]
        [MaxLength(50, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "Este campo é obragatório")]
        public string DataNascimento { get; set; }

        [Required(ErrorMessage = "Este campo é obragatório")]
        [MaxLength(10, ErrorMessage = "Este campo deve conter 10 numeros")]
        [MinLength(10, ErrorMessage = "Este campo deve conter 10 numeros")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Este campo é obragatório")]
        [MaxLength(50, ErrorMessage = "Este campo deve conter entre 5 e 20 caracteres")]
        [MinLength(5, ErrorMessage = "Este campo deve conter entre 5 e 20 caracteres")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Este campo é obragatório")]
        [MaxLength(30, ErrorMessage = "Este campo deve conter entre 2 e 30 caracteres")]
        [MinLength(2, ErrorMessage = "Este campo deve conter entre 2 e 30 caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Este campo é obragatório")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Este campo é obragatório")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Este campo é obragatório")]
        public string UF { get; set; }

        [Required(ErrorMessage = "Este campo é obragatório")]
        [MaxLength(30, ErrorMessage = "Este campo deve conter entre 3 e 30 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 30 caracteres")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Este campo é obragatório")]
        public int? RendaMensal { get; set; }

    }
}

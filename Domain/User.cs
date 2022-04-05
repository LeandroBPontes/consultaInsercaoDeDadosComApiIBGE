

namespace consultaCliente.Dominios {
    public class User {
        /* Dados da Pessoa: NomeCompleto, DataNascimento, CPF.
         Dados do endereço da Pessoa: Logradouro, Bairro, CEP, Cidade, UF, Complemento.
         Dados financeiros da pessoa: Renda mensal.*/
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Complemento { get; set; }
        public int RendaMensal { get; set; }

    }
}

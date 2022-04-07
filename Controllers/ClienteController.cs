using consultaCliente.Modelos;
using consultaCliente.Repositorios.Contratos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using consultaCliente.Compartilhado;
using consultaCliente.Dominios;

namespace consultaCliente.Controllers {
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : CrudController<Cliente, int> {

        private readonly IRepositorioBase<Cliente, int> _repositorio;
        private readonly PlanoVipDominio _dominio;
        public ClienteController(PlanoVipDominio dominio, IRepositorioBase<Cliente, int> repositorio) :base(repositorio) {
            _dominio = dominio;
            _repositorio = repositorio;
        }

        [HttpGet("BuscarUfsIBGE")]
        public List<UF> ListarUFS() {

            string url = "https://servicodados.ibge.gov.br/api/v1/localidades/estados";
            string json = (new System.Net.WebClient()).DownloadString(url);

            var ufs = JsonConvert.DeserializeObject<List<UF>>(json);

            return ufs;
        }

        [HttpGet("{Uf}")]
        public List<Municipio> ListarCidades(int Uf) {

            string url = $"https://servicodados.ibge.gov.br/api/v1/localidades/estados/{Uf}/municipios";
            string json = (new System.Net.WebClient()).DownloadString(url);

            var municipio = JsonConvert.DeserializeObject<List<Municipio>>(json);

            return municipio;
        }

        [HttpGet("PlanoVip")]
        public ActionResult<PlanoVip> ListarBeneficios() {
            var beneficios = new PlanoVip();
            return beneficios;
        }

        [HttpPost("ClienteInserePlanoVip")]
        public ActionResult InserirCPlanoVip(PlanoVip model) {
            if (!ModelState.IsValid)
                return BadRequest();

            try {
                _dominio.inserePlanoVip(model);
                return Ok("Plano Vip inserido com sucesso!");
            }
            catch {
                return BadRequest("Ocorreu um Problema!");
            }

        }

        [HttpPost("InsereVerifica")]
        public ActionResult InserirCliente(Cliente model) {
            if (!ModelState.IsValid)
                return BadRequest();

            //validacao CPF
            var cpf = new ValidaCPF();
            var retorno = cpf.IsCpf(model.CPF);

            if (retorno) {
                var mensagem = new PosCadastro();

                try {
                    _repositorio.Insert(model);
                    mensagem.MensagemPosCadastro(model);
                    return Ok(mensagem);
                }
                catch {
                    return BadRequest();
                }

            }
            return BadRequest("O CPF não é válido!");
        }

        [HttpGet("ObterEnderecoCliente/{id}")]
        public ActionResult<Cliente> ObterEnderecoClientePorId(int id) {

            var objeto = _repositorio.GetByID(id);

            if (objeto == null)
                return NotFound();
            else {
                var enderecoCliente = new Cliente();

                //Atualizando dados do endereco
                enderecoCliente.Bairro = objeto.Bairro;
                enderecoCliente.Logradouro = objeto.Logradouro;
                enderecoCliente.CEP = objeto.CEP;
                enderecoCliente.Cidade = objeto.Cidade;
                enderecoCliente.UF = objeto.UF;
                enderecoCliente.Complemento = objeto.Complemento;
                return Ok(enderecoCliente);
            }
        }

        [HttpPut("AlteraEnderecoCliente/{id}")]
        public IActionResult AtualizarEnderecoCliente(int id, [FromBody] Cliente model) {

            if (!ModelState.IsValid)
                return BadRequest();

            var objeto = _repositorio.GetByID(id);

            if (objeto == null)
                return NotFound();

            //Atualizando dados do endereco
            objeto.Bairro = model.Bairro;
            objeto.Logradouro = model.Logradouro;
            objeto.CEP = model.CEP;
            objeto.Cidade = model.Cidade;
            objeto.UF = model.UF;
            objeto.Complemento = model.Complemento;

            try {
                _repositorio.Update(objeto);
                return NoContent();
            }
            catch {
                return BadRequest("Ocorreu um erro ao atualizar seu endereço, tente novamente mais tarde");
            }     
        }
    }

}

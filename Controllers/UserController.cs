using consultaCliente.Domain;
using consultaCliente.Dominios;
using consultaCliente.Shared;
using consultaConsulta.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace consultaCliente.Controllers {
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase {

        private readonly IRepositoryBase _repositorio;
        public UserController(IRepositoryBase repositorio) {
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

        [HttpGet]
        public ActionResult<User> Get() {
            var users = _repositorio.Get();
            return Ok(users);
        }

        [HttpPost("AceitaPlanoVip")]
        public ActionResult ConfirmarPlanoVip(User model) {
            return Ok();
        }

        [HttpPost]
        public ActionResult Inserir(User model) {
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
    }

}

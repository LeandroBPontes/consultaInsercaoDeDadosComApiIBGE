using consultaCliente.Dominios;
using consultaCliente.Shared;
using consultaConsulta.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace consultaCliente.Controllers {
    public class UserController : ControllerBase{
        private readonly IRepositoryBase _repositorio;

        public UserController(IRepositoryBase repositorio) {
            _repositorio = repositorio;
        }


        [HttpGet("BuscarDadosIBGE")]
        public List<User> BuscarDadosIBGE() {

            string url = "https://servicodados.ibge.gov.br/api/v1/localidades/municipios";
            string json = (new System.Net.WebClient()).DownloadString(url);

            var municipios = JsonConvert.DeserializeObject<List<User>>(json);

            return municipios;
        }

        [HttpGet]
        public ActionResult<User> Get() {
            var users = _repositorio.Get();
            return Ok(users);
        }
        

        [HttpPost]
        public ActionResult Inserir([FromBody] User model) {
            if (!ModelState.IsValid)
                return BadRequest();
          
            var mensagem = new PosCadastro();
            _repositorio.Insert(model);
            return Ok(mensagem);

        }

        //[HttpGet("ListarUFS")]
        //public ActionResult<User> GetUFS() {
        //    var users = _repositorio.Get();
        //    return Ok(users);
        //}

        //[HttpGet("ListarUFS")]
        //public ActionResult<User> GetCidades() {
        //    var users = _repositorio.Get();
        //    return Ok(users);
        //}


    }
}

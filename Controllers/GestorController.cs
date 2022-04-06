using consultaCliente.Adm.Modelo;
using consultaCliente.Modelos;
using consultaCliente.Repositorios.Contratos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace consultaCliente.Controllers {
    public class GestorController : CrudController<Gestor, int> {

        //private readonly IRepositorioBase<Gestor, int> _repositorio;
        private readonly IRepositorioBase<Cliente, int> _repositorioCliente;

        public GestorController(IRepositorioBase<Gestor, int> repositorio, IRepositorioBase<Cliente, int> repositorioCliente) : base(repositorio) {
            _repositorioCliente = repositorioCliente;
        }

        [HttpGet("ListarClientesPorData/{DataInicial}/{DataFinal}")]
        public ActionResult<Cliente> ListarClientes(DateTime DataInicial, DateTime DataFinal) {

            var clientes = _repositorioCliente.Get().Where(x=>x.DataCadastro >= DataInicial && x.DataCadastro <= DataFinal);
            return Ok(clientes);
        }

        [HttpGet("ListarClientesPorData/{RendaMensal}")]
        public ActionResult<Cliente> ListarClientes(Decimal RendaMensal) {

            var clientes = _repositorioCliente.Get().Where(x => x.RendaMensal >= RendaMensal);
            return Ok(clientes);
        }
    }
}

using consultaCliente.Repositorios.Contratos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace consultaCliente.Controllers {
    public abstract class CrudController<TEntidade, TPrimary> : ControllerBase {

        private readonly IRepositorioBase<TEntidade, TPrimary> _repositorio;

        public CrudController(IRepositorioBase<TEntidade, TPrimary> repositorio) {
            _repositorio = repositorio;
        }

        [HttpGet]
        public ActionResult<TEntidade> Get() {
            var obj = _repositorio.Get();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public ActionResult<TEntidade> ObterPorId(TPrimary id) {
            var objeto = _repositorio.GetByID(id);

            if (objeto == null)
                return NotFound();
            else {
                return Ok(objeto);
            }
        }

        [HttpPost]
        public IActionResult Inserir([FromBody] TEntidade model) {
            if (!ModelState.IsValid)
                return BadRequest();

            _repositorio.Insert(model);
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(TPrimary id, [FromBody] TEntidade model) {
            if (!ModelState.IsValid)
                return BadRequest();

            var objeto = _repositorio.GetByID(id);

            if (objeto == null)
                return NotFound();

            _repositorio.Update(objeto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(TPrimary id) {
            var objeto = _repositorio.GetByID(id);

            if (objeto == null)
                return NotFound();

            _repositorio.Delete(id);

            return NoContent();
        }
    }
}



using Ftec.ProjetosWeb.RedeSocial.Dominio.Entidades;
using Ftec.ProjetosWeb.RedeSocial.Dominio.Repositorio;
using Ftec.ProjetosWeb.RedeSocial.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Ftec.ProjetosWeb.RedeSocial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurtidasController : ControllerBase
    {
        private readonly ICurtidasRepository _repositorio;

        public CurtidasController()
        {
            _repositorio = new CurtidasRepositorio(""); // ou injete a string de conexão se preferir
        }

        [HttpGet("{id}")]
        public ActionResult<Curtida> Get(Guid id)
        {
            var curtida = _repositorio.Procurar(id);
            if (curtida == null)
                return NotFound();

            return Ok(curtida);
        }

        [HttpGet("post/{IdPostPai}")]
        public ActionResult<List<Curtida>> GetPorPost(Guid IdPostPai)
        {
            var curtidas = _repositorio.ProcurarTodosDoPost(IdPostPai);
            return Ok(curtidas);
        }

        [HttpGet("post/{IdPostPai}/count")]
        public ActionResult<int> Contar(Guid IdPostPai)
        {
            var total = _repositorio.ContarTodos(IdPostPai);
            return Ok(total);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Curtida curtida)
        {
            if (curtida == null)
                return BadRequest("Dados inválidos");

            curtida.Id = Guid.NewGuid();
            curtida.DataCurtida = DateTime.Now;

            _repositorio.InserirCurtida(curtida);

            return CreatedAtAction(nameof(Get), new { id = curtida.Id }, curtida);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Curtida curtida)
        {
            if (curtida == null || curtida.Id != id)
                return BadRequest("Dados inconsistentes");

            _repositorio.AlterarReacao(curtida);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var sucesso = _repositorio.ExcluirCurtida(id);
            if (!sucesso)
                return NotFound();

            return NoContent();
        }
    }
}

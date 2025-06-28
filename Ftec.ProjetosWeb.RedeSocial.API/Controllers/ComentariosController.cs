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
    public class ComentariosController : ControllerBase
    {
        private readonly IComentariosRepository _repositorio;

        public ComentariosController()
        {
            // Pode injetar via DI futuramente
            _repositorio = new ComentariosRepositorio(""); // Se quiser, passe a string de conexão aqui
        }

        [HttpGet("{id}")]
        public ActionResult<Comentario> Get(Guid id)
        {
            var comentario = _repositorio.Procurar(id);
            if (comentario == null)
                return NotFound();

            return Ok(comentario);
        }

        [HttpGet("post/{idPost}")]
        public ActionResult<List<Comentario>> GetPorPost(Guid idPost)
        {
            var comentarios = _repositorio.ProcurarTodosDoPost(idPost);
            return Ok(comentarios);
        }

        [HttpGet("post/{idPost}/count")]
        public ActionResult<int> Contar(Guid idPost)
        {
            var total = _repositorio.ContarTodos(idPost);
            return Ok(total);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Comentario comentario)
        {
            if (comentario == null)
                return BadRequest("Dados inválidos");

            comentario.Id = Guid.NewGuid();
            comentario.DataComentario = DateTime.Now;

            _repositorio.InserirComentario(comentario);

            return CreatedAtAction(nameof(Get), new { id = comentario.Id }, comentario);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Comentario comentario)
        {
            if (comentario == null || comentario.Id != id)
                return BadRequest("Dados inconsistentes");

            _repositorio.EditarComentario(comentario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var sucesso = _repositorio.ExcluirComentario(id);
            if (!sucesso)
                return NotFound();

            return NoContent();
        }
    }
}

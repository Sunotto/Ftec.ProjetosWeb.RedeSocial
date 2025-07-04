using Ftec.ProjetosWeb.RedeSocial.Aplicacao;
using Ftec.ProjetosWeb.RedeSocial.Aplicacao.DTO;
using Ftec.ProjetosWeb.RedeSocial.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Ftec.ProjetosWeb.RedeSocial.API.Controllers
{
    /// <summary>
    /// API para gerenciamento dos comentários.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private readonly ComentariosAplicacao _comentariosAplicacao;

        /// <summary>
        /// Construtor da controller Comentarios.
        /// </summary>
        /// <param name="comentariosAplicacao">Serviço de aplicação para comentários.</param>
        public ComentariosController(ComentariosAplicacao comentariosAplicacao)
        {
            _comentariosAplicacao = comentariosAplicacao;
        }

        /// <summary>
        /// Obtém um comentário pelo seu Id.
        /// </summary>
        /// <param name="id">Id do comentário.</param>
        /// <returns>Retorna o comentário encontrado.</returns>
        [HttpGet("{id}")]
        public ActionResult<ComentarioDTO> Get(Guid id)
        {
            var comentario = _comentariosAplicacao.Procurar(id);
            if (comentario == null)
                return NotFound();

            return Ok(comentario);
        }

        /// <summary>
        /// Obtém todos os comentários de um post específico.
        /// </summary>
        /// <param name="idPost">Id do post.</param>
        /// <returns>Lista de comentários.</returns>
        [HttpGet("post/{idPost}")]
        public ActionResult<List<ComentarioDTO>> GetPorPost(Guid idPost)
        {
            var comentarios = _comentariosAplicacao.ProcurarTodosDoPost(idPost);
            return Ok(comentarios);
        }

        /// <summary>
        /// Conta o total de comentários de um post.
        /// </summary>
        /// <param name="idPost">Id do post.</param>
        /// <returns>Total de comentários.</returns>
        [HttpGet("post/{idPost}/count")]
        public ActionResult<int> Contar(Guid idPost)
        {
            var total = _comentariosAplicacao.ProcurarTodosDoPost(idPost)?.Count ?? 0;
            return Ok(total);
        }

        /// <summary>
        /// Insere um novo comentário.
        /// </summary>
        /// <param name="model">Dados para criação do comentário.</param>
        /// <returns>Id do comentário criado.</returns>
        [HttpPost]
        public ActionResult<Guid> Post([FromBody] ComentarioCreateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var dto = new ComentarioDTO
            {
                IdPost = model.IdPost,
                IdUsuario = model.IdUsuario,
                Conteudo = model.Conteudo,
                IdComentarioPai = model.IdComentarioPai ?? Guid.Empty,
                DataComentario = DateTime.Now
            };

            var idCriado = _comentariosAplicacao.InserirComentario(dto);
            return CreatedAtAction(nameof(Get), new { id = idCriado }, idCriado);
        }

        /// <summary>
        /// Atualiza um comentário existente.
        /// </summary>
        /// <param name="id">Id do comentário.</param>
        /// <param name="model">Dados atualizados do comentário.</param>
        /// <returns>Status da operação.</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ComentarioCreateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var dto = new ComentarioDTO
            {
                Id = id,
                IdPost = model.IdPost,
                IdUsuario = model.IdUsuario,
                Conteudo = model.Conteudo,
                IdComentarioPai = model.IdComentarioPai ?? Guid.Empty,
                DataComentario = DateTime.Now
            };

            _comentariosAplicacao.EditarComentario(dto);
            return NoContent();
        }

        /// <summary>
        /// Exclui um comentário pelo Id.
        /// </summary>
        /// <param name="id">Id do comentário.</param>
        /// <returns>Status da exclusão.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var dto = new ComentarioDTO { Id = id };
            var excluido = _comentariosAplicacao.ExcluirComentario(dto);
            if (!excluido)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Insere uma resposta a um comentário.
        /// </summary>
        /// <param name="model">Dados da resposta.</param>
        /// <returns>Id da resposta criada.</returns>
        [HttpPost("responder")]
        public ActionResult<Guid> ResponderComentario([FromBody] ComentarioCreateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model.IdComentarioPai == null || model.IdComentarioPai == Guid.Empty)
                return BadRequest("IdComentarioPai é obrigatório para resposta.");

            var dto = new ComentarioDTO
            {
                IdPost = model.IdPost,
                IdUsuario = model.IdUsuario,
                Conteudo = model.Conteudo,
                IdComentarioPai = model.IdComentarioPai.Value,
                DataComentario = DateTime.Now
            };

            var idResposta = _comentariosAplicacao.ResponderComentario(dto);
            return CreatedAtAction(nameof(Get), new { id = idResposta }, idResposta);
        }
    }
}

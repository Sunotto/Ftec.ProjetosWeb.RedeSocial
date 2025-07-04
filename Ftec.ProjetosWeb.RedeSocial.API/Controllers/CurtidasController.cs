using Ftec.ProjetosWeb.RedeSocial.API.Models;
using Ftec.ProjetosWeb.RedeSocial.Aplicacao.DTO;
using Ftec.ProjetosWeb.RedeSocial.Aplicacao;

using Microsoft.AspNetCore.Mvc;

/// <summary>
/// API para gerenciamento das curtidas.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CurtidasController : ControllerBase
{
    private readonly CurtidasAplicacao _curtidasAplicacao;

    /// <summary>
    /// Construtor da controller Curtidas.
    /// </summary>
    /// <param name="curtidasAplicacao">Serviço de aplicação para curtidas.</param>
    public CurtidasController(CurtidasAplicacao curtidasAplicacao)
    {
        _curtidasAplicacao = curtidasAplicacao;
    }

    /// <summary>
    /// Obtém uma curtida pelo seu Id.
    /// </summary>
    /// <param name="id">Id da curtida.</param>
    /// <returns>Retorna a curtida encontrada.</returns>
    [HttpGet("{id}")]
    public ActionResult<CurtidaDTO> Get(Guid id)
    {
        var curtida = _curtidasAplicacao.Procurar(id);
        if (curtida == null)
            return NotFound();

        return Ok(curtida);
    }

    /// <summary>
    /// Obtém todas as curtidas de um post.
    /// </summary>
    /// <param name="idPost">Id do post.</param>
    /// <returns>Lista de curtidas.</returns>
    [HttpGet("post/{idPost}")]
    public ActionResult<List<CurtidaDTO>> GetPorPost(Guid idPost)
    {
        var curtidas = _curtidasAplicacao.ProcurarTodosDoPost(idPost);
        return Ok(curtidas);
    }

    /// <summary>
    /// Conta o total de curtidas em um post.
    /// </summary>
    /// <param name="idPost">Id do post.</param>
    /// <returns>Total de curtidas.</returns>
    [HttpGet("post/{idPost}/count")]
    public ActionResult<int> Contar(Guid idPost)
    {
        var curtidas = _curtidasAplicacao.ProcurarTodosDoPost(idPost);
        return Ok(curtidas?.Count ?? 0);
    }

    /// <summary>
    /// Insere uma nova curtida.
    /// </summary>
    /// <param name="model">Dados para criação da curtida.</param>
    /// <returns>Id da curtida criada.</returns>
    [HttpPost]
    public ActionResult<Guid> Post([FromBody] CurtidaCreateModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var dto = new CurtidaDTO
        {
            IdUsuario = model.IdUsuario,
            IdPostPai = model.IdPostPai,
            Reacao = (TipoReacao)model.Reacao,
            DataCurtida = DateTime.Now
        };

        var idCriado = _curtidasAplicacao.InserirCurtida(dto);
        return CreatedAtAction(nameof(Get), new { id = idCriado }, idCriado);
    }

    /// <summary>
    /// Atualiza uma curtida existente.
    /// </summary>
    /// <param name="id">Id da curtida.</param>
    /// <param name="model">Dados atualizados da curtida.</param>
    /// <returns>Status da operação.</returns>
    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] CurtidaCreateModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var dto = new CurtidaDTO
        {
            Id = id,
            IdUsuario = model.IdUsuario,
            IdPostPai = model.IdPostPai,
            Reacao = (TipoReacao)model.Reacao,
            DataCurtida = DateTime.Now
        };

        _curtidasAplicacao.AlterarReacao(dto);
        return NoContent();
    }

    /// <summary>
    /// Exclui uma curtida pelo Id.
    /// </summary>
    /// <param name="id">Id da curtida.</param>
    /// <returns>Status da exclusão.</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var dto = new CurtidaDTO { Id = id };
        var excluido = _curtidasAplicacao.ExcluirCurtida(dto);
        if (!excluido)
            return NotFound();

        return NoContent();
    }
}

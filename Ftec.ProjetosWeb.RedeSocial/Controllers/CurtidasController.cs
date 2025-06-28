using Ftec.ProjetosWeb.RedeSocial.Aplicacao;
using Ftec.ProjetosWeb.RedeSocial.Aplicacao.DTO;
using Ftec.ProjetosWeb.RedeSocial.Dominio.Repositorio;
using Ftec.ProjetosWeb.RedeSocial.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ftec.ProjetosWeb.RedeSocial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurtidasController : ControllerBase
    {
        private ICurtidasRepository curtidaRepository;
        private CurtidasAplicacao aplicacao;
        public CurtidasController()
        {
            string strConexao = "Server=127.0.0.1;Port=5432;Database=postgres; User Id=postgres;Password=tangduva123;";
            curtidaRepository = new CurtidasRepositorio(strConexao);
            aplicacao = new CurtidasAplicacao(curtidaRepository);
        }

        [HttpGet]
        public List<CurtidaDTO> Get()
        {
            return aplicacao.ProcurarTodosDoPost();
        }

        [HttpPost]
        public void Post(CurtidaDTO curtidaDTO)
        {
            aplicacao.InserirCurtida(curtidaDTO);
        }

        [HttpPut]
        public void Put(CurtidaDTO curtidaDTO)
        {
            aplicacao.AlterarReacao(curtidaDTO);
        }

        [HttpDelete]    
        public void Delete(CurtidaDTO curtidaDTO)
        {
            aplicacao.ExcluirCurtida(curtidaDTO);
        }

    }
}

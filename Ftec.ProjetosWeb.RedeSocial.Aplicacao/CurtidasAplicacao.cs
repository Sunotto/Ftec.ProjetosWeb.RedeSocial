using Ftec.ProjetosWeb.RedeSocial.Aplicacao.Adapter;
using Ftec.ProjetosWeb.RedeSocial.Aplicacao.DTO;
using Ftec.ProjetosWeb.RedeSocial.Dominio.Entidades;
using Ftec.ProjetosWeb.RedeSocial.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.ProjetosWeb.RedeSocial.Aplicacao
{
    public class CurtidasAplicacao
    {
        private ICurtidasRepository CurtidasRepository;

        public CurtidasAplicacao(ICurtidasRepository curtidasRepository)
        {
            this.CurtidasRepository = curtidasRepository;
        }

        public List<CurtidaDTO> ProcurarTodosDoPost(Guid id)
        {
            var curtidas = CurtidasRepository.ProcurarTodosDoPost(id);
            return CurtidasAdapter.ParaDTO(curtidas);
        }
        public Guid InserirCurtida(CurtidaDTO curtida)
        {
            if (curtida == null)
            {
                throw new ApplicationException("Curtida não existe!");
            }

            curtida.Id = Guid.NewGuid();

            var curtidaEntidade = CurtidasAdapter.ParaDomain(curtida);
            CurtidasRepository.InserirCurtida(curtidaEntidade);

            return curtida.Id;
        }
        public void AlterarReacao(CurtidaDTO curtida)
        {
            var curtidaEntidade = CurtidasAdapter.ParaDomain(curtida);
            CurtidasRepository.AlterarReacao(curtidaEntidade);
        }

        public bool ExcluirCurtida(CurtidaDTO curtida)
        {
            return CurtidasRepository.ExcluirCurtida(curtida.Id);
        }

        public CurtidaDTO Procurar(Guid id)
        {
            var curtida = CurtidasRepository.Procurar(id);
            return CurtidasAdapter.ParaDTO(curtida);
        }

        public List<CurtidaDTO> ProcurarTodosDoPost()
        {
            throw new NotImplementedException();
        }
    }
}

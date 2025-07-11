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
    public class ComentariosAplicacao
    {
        private IComentariosRepository ComentariosRepository;

        public ComentariosAplicacao(IComentariosRepository comentariosRepository)
        {
            this.ComentariosRepository = comentariosRepository;
        }

        public List<ComentarioDTO> ProcurarTodosDoPost(Guid id)
        {
            var comentarios = ComentariosRepository.ProcurarTodosDoPost(id);
            return ComentariosAdapter.ParaDTO(comentarios);
        }
        public Guid InserirComentario(ComentarioDTO comentario)
        {
            if (comentario == null)
            {
                throw new ApplicationException("Comentário não existe!");
            }

            comentario.Id = Guid.NewGuid();

            var comentarioEntidade = ComentariosAdapter.ParaDomain(comentario);
            ComentariosRepository.InserirComentario(comentarioEntidade);

            return comentario.Id;
        }
        public void EditarComentario(ComentarioDTO comentario)
        {
            var comentarioEntidade = ComentariosAdapter.ParaDomain(comentario);
            ComentariosRepository.EditarComentario(comentarioEntidade);
        }

        public bool ExcluirComentario(ComentarioDTO comentario)
        {
            return ComentariosRepository.ExcluirComentario(comentario.Id);
        }
        public ComentarioDTO Procurar(Guid id)
        {
            var comentario = ComentariosRepository.Procurar(id);
            return ComentariosAdapter.ParaDTO(comentario);
        }

    }
}

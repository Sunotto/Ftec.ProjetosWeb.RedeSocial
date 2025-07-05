using Ftec.ProjetosWeb.RedeSocial.Aplicacao.DTO;
using Ftec.ProjetosWeb.RedeSocial.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.ProjetosWeb.RedeSocial.Aplicacao.Adapter
{
    public static class ComentariosAdapter
    {
        public static List<ComentarioDTO> ParaDTO(List<Comentario> comentarios)
        {
            List<ComentarioDTO> comentarios1 = new List<ComentarioDTO>();

            foreach (Comentario comentario in comentarios)
            {
                comentarios1.Add(ParaDTO(comentario));
            }

            return comentarios1;
        }
        public static List<Comentario> ParaDomain(List<ComentarioDTO> comentarios)
        {
            List<Comentario> comentarios1 = new List<Comentario>();

            foreach (ComentarioDTO comentario in comentarios)
            {
                comentarios1.Add(ParaDomain(comentario));
            }

            return comentarios1;
        }
        public static Comentario ParaDomain(ComentarioDTO comentario)
        {
            return new Comentario()
            {
                Id = comentario.Id,
                IdPost = comentario.IdPost,
                IdUsuario = comentario.IdUsuario,
                Conteudo = comentario.Conteudo,
                DataComentario = comentario.DataComentario,
                IdComentarioPai = comentario.IdComentarioPai
            };
        }
        public static ComentarioDTO ParaDTO(Comentario comentario)
        {
            if (comentario == null)
            {
                return null;
            }
            else
            {
                return new ComentarioDTO()
                {
                    Id = comentario.Id,
                    IdPost = comentario.IdPost,
                    IdUsuario = comentario.IdUsuario,
                    Conteudo = comentario.Conteudo,
                    DataComentario = comentario.DataComentario,
                    IdComentarioPai = comentario.IdComentarioPai
                };
            }                
        }
    }
}

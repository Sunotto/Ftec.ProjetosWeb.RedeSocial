using Ftec.ProjetosWeb.RedeSocial.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.ProjetosWeb.RedeSocial.Dominio.Repositorio
{
    public interface IComentariosRepository
    {
        List<Comentario> ProcurarTodosDoPost(Guid IdPost); //procurar comentarios por id de post
        Comentario Procurar(Guid id);
        void InserirComentario(Comentario comentario);
        void EditarComentario(Comentario comentario);
        bool ExcluirComentario(Guid id);
    }
}

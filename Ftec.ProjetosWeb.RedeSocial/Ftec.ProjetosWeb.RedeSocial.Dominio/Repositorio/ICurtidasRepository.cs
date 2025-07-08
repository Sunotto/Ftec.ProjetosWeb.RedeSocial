using Ftec.ProjetosWeb.RedeSocial.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.ProjetosWeb.RedeSocial.Dominio.Repositorio
{
    public interface ICurtidasRepository
    {
        List<Curtida> ProcurarTodosDoPost(Guid IdPost); //procurar todas as curtidas por id de post/comentario
<<<<<<< HEAD
=======
        Curtida Procurar(Guid id);
>>>>>>> ad807142b91324e15ecfa35451bf53e0a7cf3cb6
        void InserirCurtida(Curtida curtida);
        void AlterarReacao(Curtida curtida);
        bool ExcluirCurtida(Guid id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.ProjetosWeb.RedeSocial.Aplicacao.DTO
{
    public class ComentarioDTO
    {
        public Guid Id { get; set; }
        public Guid IdPost { get; set; }
        public Guid IdUsuario { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataComentario { get; set; }
        public Guid IdComentarioPai { get; set; }
        
    }
}

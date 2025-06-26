using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.ProjetosWeb.RedeSocial.Dominio.Entidades
{
    public class Comentario
    {
        public Guid Id { get; set; }
        public Guid IdPost { get; set; }
        public Guid IdUsuario { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataComentario { get; set; }
        public Guid IdComentarioPai { get; set; }
        public Comentario()
        {
            this.Id = Guid.NewGuid();
            this.IdPost = Guid.Empty;
            this.IdUsuario = Guid.Empty;
            this.Conteudo = string.Empty;
            this.DataComentario = DateTime.MinValue;
            this.IdComentarioPai = Guid.Empty;
        }
    }
}

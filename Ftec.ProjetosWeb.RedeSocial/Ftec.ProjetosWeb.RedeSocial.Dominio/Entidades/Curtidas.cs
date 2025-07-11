using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.ProjetosWeb.RedeSocial.Dominio.Entidades
{
    public class Curtida
    {
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public DateTime DataCurtida { get; set; }
        public TipoReacao Reacao { get; set; }
        public Guid IdPostPai { get; set; }
        public Curtida()
        {
            this.Id = Guid.NewGuid();
            this.IdUsuario = Guid.Empty;
            this.DataCurtida = DateTime.MinValue;
<<<<<<< HEAD
            this.Reacao = TipoReacao.Curtir;
=======
            this.Reacao = TipoReacao.Like;
>>>>>>> ad807142b91324e15ecfa35451bf53e0a7cf3cb6
            this.IdPostPai = Guid.Empty;
        }
    }
}

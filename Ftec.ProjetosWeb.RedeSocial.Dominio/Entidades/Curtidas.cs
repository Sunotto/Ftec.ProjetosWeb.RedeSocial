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
            this.Reacao = TipoReacao.Curtir;
            this.IdPostPai = Guid.Empty;
        }
    }
}

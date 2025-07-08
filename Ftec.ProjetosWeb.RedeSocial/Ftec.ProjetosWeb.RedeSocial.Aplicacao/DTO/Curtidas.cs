using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.ProjetosWeb.RedeSocial.Aplicacao.DTO
{
    public class CurtidaDTO
    {
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public DateTime DataCurtida { get; set; }
        public TipoReacao Reacao { get; set; }
        public Guid IdPostPai { get; set; }
        
    }
}

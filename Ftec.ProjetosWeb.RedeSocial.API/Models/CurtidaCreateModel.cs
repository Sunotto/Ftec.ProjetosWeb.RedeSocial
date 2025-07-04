using System;
using System.ComponentModel.DataAnnotations;
using Ftec.ProjetosWeb.RedeSocial.Dominio.Entidades; // para o enum TipoReacao

namespace Ftec.ProjetosWeb.RedeSocial.API.Models
{
    public class CurtidaCreateModel
    {
        [Required]
        public Guid IdUsuario { get; set; }

        [Required]
        public Guid IdPostPai { get; set; }

        [Required]
        public TipoReacao Reacao { get; set; }
    }
}

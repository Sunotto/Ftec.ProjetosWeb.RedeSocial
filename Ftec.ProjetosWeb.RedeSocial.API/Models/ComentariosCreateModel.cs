using System;
using System.ComponentModel.DataAnnotations;

namespace Ftec.ProjetosWeb.RedeSocial.API.Models
{
    public class ComentarioCreateModel
    {
        [Required]
        public Guid IdPost { get; set; }

        [Required]
        public Guid IdUsuario { get; set; }

        [Required]
        public string Conteudo { get; set; }

        // Opcional — usado somente se for resposta a outro comentário
        public Guid? IdComentarioPai { get; set; }
    }
}

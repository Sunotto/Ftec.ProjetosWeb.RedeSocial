using Ftec.ProjetosWeb.RedeSocial.Aplicacao.DTO;
using Web.Models;

public class FeedCompletoViewModel
{
    public List<FeedItemViewModel> Feed { get; set; }
    public List<ComentarioViewModel> Comentarios { get; set; }
    public List<CurtidaViewModel> Curtidas { get; set; }
    public List<UsuarioViewModel> Usuarios { get; set; }
}
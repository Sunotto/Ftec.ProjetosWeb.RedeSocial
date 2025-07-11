namespace Web.Models
{
    public class ComentarioViewModel
    {
        public Guid Id { get; set; }
        public Guid IdPost { get; set; }
        public Guid IdUsuario { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataComentario { get; set; }
        public Guid IdComentarioPai { get; set; }

    }
}

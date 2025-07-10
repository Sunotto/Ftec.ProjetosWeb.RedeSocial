namespace Web.Models
{
    public class UsuarioViewModel
    {
        public Guid Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Username { get; set; }
        public string Telefone { get; set; }
        public string Genero { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
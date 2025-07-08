namespace Web.Models
{
    public class SignUpViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string NomeCompleto { get; set; }
        public string Telefone { get; set; }
        public string Genero { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }  // Pode ser uma URL ou base64
        public string Token { get; set; } // Se sua API gerar isso no servidor, pode deixar null
    }
}

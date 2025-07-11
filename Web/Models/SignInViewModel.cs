using System.ComponentModel.DataAnnotations;

public class SignInViewModel
{
    [Required(ErrorMessage = "O nome de usuário é obrigatório.")]
    public string Username { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória.")]
    public string Password { get; set; } // Renomeado de Senha para consistência
}
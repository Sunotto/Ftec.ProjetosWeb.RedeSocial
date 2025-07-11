using System;
using System.Collections.Generic; // Necessário para List<T>
using Web.Models;

namespace Web.Models
{

    // Classe para gerar os dados mockados de usuários
    public static class UsuarioDataMock
    {
        public static List<UsuarioViewModel> GetMockUsuarios()
        {
            var mockUsuarios = new List<UsuarioViewModel>
            {
                new UsuarioViewModel
                {
                    Id = Guid.Parse("1a2b3c4d-1111-2222-3333-abcdef123456"),
                    NomeCompleto = "Ana Clara Silva",
                    Email = "ana.silva@example.com",
                    Senha = "senha_segura123", // Em um cenário real, a senha nunca seria exposta em um DTO de retorno
                    Username = "anaclara",
                    Telefone = "51987654321",
                    Genero = "Feminino",
                    Descricao = "Entusiasta de tecnologia e amante de gatos. 🐱",
                    Foto = "/assets/images/users/user-1.jpg", // Exemplo de caminho de foto
                    DataNascimento = new DateTime(1995, 10, 20)
                },
                new UsuarioViewModel
                {
                    Id = Guid.Parse("5e6f7a8b-4444-5555-6666-abcdef123457"),
                    NomeCompleto = "Bruno Costa Lima",
                    Email = "bruno.lima@example.com",
                    Senha = "outra_senha_forte",
                    Username = "brunocosta",
                    Telefone = "51912345678",
                    Genero = "Masculino",
                    Descricao = "Desenvolvedor full-stack, apaixonado por inovação e café. ☕",
                    Foto = "/assets/images/users/user-2.jpg",
                    DataNascimento = new DateTime(1990, 5, 15)
                },
                new UsuarioViewModel
                {
                    Id = Guid.Parse("9c0d1e2f-7777-8888-9999-abcdef123458"),
                    NomeCompleto = "Carla Dias Souza",
                    Email = "carla.souza@example.com",
                    Senha = "minhasenhafacil",
                    Username = "carladias",
                    Telefone = "51998761234",
                    Genero = "Feminino",
                    Descricao = "Designer UX/UI buscando sempre a melhor experiência. ✨",
                    Foto = "/assets/images/users/user-3.jpg",
                    DataNascimento = new DateTime(1998, 3, 8)
                },
                new UsuarioViewModel
                {
                    Id = Guid.Parse("0a1b2c3d-aaaa-bbbb-cccc-abcdef123459"),
                    NomeCompleto = "Daniel Pereira Rocha",
                    Email = "daniel.rocha@example.com",
                    Senha = "senha_daniel",
                    Username = "dan_rocha",
                    Telefone = "51981234567",
                    Genero = "Não Binário",
                    Descricao = "Cientista de dados e entusiasta de esportes ao ar livre. 🚴‍♂️",
                    Foto = "/assets/images/users/user-4.jpg",
                    DataNascimento = new DateTime(1993, 11, 2)
                }
            };
            return mockUsuarios;
        }

        public static UsuarioViewModel GetMockUsuarioById(Guid id)
        {
            return GetMockUsuarios().FirstOrDefault(u => u.Id == id);
        }

        public static UsuarioViewModel GetMockUsuarioByUsername(string username)
        {
            return GetMockUsuarios().FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }
    }
}
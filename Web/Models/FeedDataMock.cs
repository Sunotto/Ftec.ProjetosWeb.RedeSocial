using System;
using System.Collections.Generic; // Necessário para List<T>

namespace Web.Models
{

    // Classe ou método para gerar os dados mockados
    public static class FeedDataMock
    {
        public static List<FeedItemViewModel> GetMockFeedItems()
        {
            var mockItems = new List<FeedItemViewModel>
            {
                new FeedItemViewModel
                {
                    Id = Guid.Parse("a1b2c3d4-e5f6-7890-1234-567890abcdef"),
                    UserId = Guid.Parse("1a2b3c4d-5e6f-7890-abcd-ef1234567890"),
                    ContentId = Guid.Parse("00112233-4455-6677-8899-aabbccddeeff"),
                    PublishedAt = DateTime.Now.AddHours(-2),
                    TextPreview = "Olha só que post incrível eu fiz hoje! 🎉 Muita coisa boa para compartilhar.",
                    LikeCount = 42,
                    CommentCount = 15
                },
                new FeedItemViewModel
                {
                    Id = Guid.Parse("b1c2d3e4-f5a6-8901-2345-67890abcdef1"),
                    UserId = Guid.Parse("2b3c4d5e-6f7a-8901-bcde-f12345678901"),
                    ContentId = Guid.Parse("11223344-5566-7788-99aa-bbccddeeff00"),
                    PublishedAt = DateTime.Now.AddDays(-1),
                    TextPreview = "Dia produtivo de estudos e trabalho. Foco total nos objetivos! 📚",
                    LikeCount = 105,
                    CommentCount = 28
                },
                new FeedItemViewModel
                {
                    Id = Guid.Parse("c1d2e3f4-a5b6-9012-3456-7890abcdef12"),
                    UserId = Guid.Parse("3c4d5e6f-7a8b-9012-cdef-123456789012"),
                    ContentId = Guid.Parse("22334455-6677-8899-aabb-ccddeeff0011"),
                    PublishedAt = DateTime.Now.AddDays(-3),
                    TextPreview = "Relembrando essa viagem incrível! Saudade de explorar novos lugares. ✈️",
                    LikeCount = 230,
                    CommentCount = 50
                },
                new FeedItemViewModel
                {
                    // CORREÇÃO AQUI: 'g' foi substituído por 'e' (ou qualquer outro caractere hexadecimal válido)
                    Id = Guid.Parse("d1e2f3e4-a5b6-c7d8-e9f0-1234567890ab"), // <-- Corrigido!
                    UserId = Guid.Parse("4d5e6f7a-8b9c-0123-4567-890123456789"),
                    ContentId = Guid.Parse("33445566-7788-99aa-bbcc-ddeeff001122"),
                    PublishedAt = DateTime.Now.AddMinutes(-45),
                    TextPreview = "Que tal um bom café para começar o dia? ☕ Energia recarregada!",
                    LikeCount = 70,
                    CommentCount = 20
                }
            };
            return mockItems;
        }
    }
}
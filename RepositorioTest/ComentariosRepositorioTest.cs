using System.Runtime.CompilerServices;
using Ftec.ProjetosWeb.RedeSocial.Dominio.Entidades;
using Ftec.ProjetosWeb.RedeSocial.Repositorio;

namespace RepositorioTest
{
    [TestClass]
    public class ComentariosRepositorioTest
    {
        [TestMethod]
        public void InserirTeste()
        {
            var comentario = new Comentario();
            var comentarioRepositorio = new ComentariosRepositorio("Server=191.242.230.255;Port=5432;Database=curtida; User Id=postgres;Password=12345678");
            try
            {
                comentario.Id = Guid.NewGuid();
                comentario.IdPost = Guid.Empty;
                comentario.IdUsuario = Guid.Empty;
                comentario.Conteudo = "Olá mundo";
                comentario.DataComentario = DateTime.Now;
                comentario.IdComentarioPai = Guid.Empty;

                comentarioRepositorio.InserirComentario(comentario);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }
        [TestMethod]
        public void ExcluirTeste()
        {
            var comentario = new Comentario();
            var comentarioRepositorio = new ComentariosRepositorio("Server=191.242.230.255;Port=5432;Database=curtida; User Id=postgres;Password=12345678");
            try
            {
                comentario.Id = Guid.NewGuid();
                comentario.IdPost = Guid.Empty;
                comentario.IdUsuario = Guid.Empty;
                comentario.Conteudo = "Olá mundo";
                comentario.DataComentario = DateTime.Now;
                comentario.IdComentarioPai = Guid.Empty;

                comentarioRepositorio.InserirComentario(comentario);
                comentarioRepositorio.ExcluirComentario(comentario.Id);
                var comentarioRetorno = comentarioRepositorio.Procurar(comentario.Id);

                Assert.IsTrue(comentarioRetorno == null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void ProcurarTeste()
        {
            var comentario = new Comentario();
            var comentarioRepositorio = new ComentariosRepositorio("Server=191.242.230.255;Port=5432;Database=curtida; User Id=postgres;Password=12345678");
            try
            {
                comentario.Id = Guid.NewGuid();
                comentario.IdPost = Guid.Empty;
                comentario.IdUsuario = Guid.Empty;
                comentario.Conteudo = "Olá mundo";
                comentario.DataComentario = DateTime.Now;
                comentario.IdComentarioPai = Guid.Empty;

                comentarioRepositorio.InserirComentario(comentario);
                var comentarioRetorno = comentarioRepositorio.Procurar(comentario.Id);

                Assert.IsTrue(comentarioRetorno != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void ProcurarTodosTeste()
        {
            var comentario = new Comentario();
            var comentarioRepositorio = new ComentariosRepositorio("Server=191.242.230.255;Port=5432;Database=curtida; User Id=postgres;Password=12345678");
            try
            {
                comentario.Id = Guid.NewGuid();
                comentario.IdPost = Guid.Empty;
                comentario.IdUsuario = Guid.Empty;
                comentario.Conteudo = "Olá mundo";
                comentario.DataComentario = DateTime.Now;
                comentario.IdComentarioPai = Guid.Empty;

                comentarioRepositorio.InserirComentario(comentario);
                var comentarios = comentarioRepositorio.ProcurarTodosDoPost(comentario.IdPost);

                Assert.IsTrue(comentarios.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void EditarTeste()
        {
            var comentario = new Comentario()
            {
                Id = Guid.NewGuid(),
                IdPost = Guid.Empty,
                IdUsuario = Guid.Empty,
                Conteudo = "Olá mundo",
                DataComentario = DateTime.Now,
                IdComentarioPai = Guid.Empty,
            };

            var comentarioRepositorio = new ComentariosRepositorio("Server=191.242.230.255;Port=5432;Database=curtida; User Id=postgres;Password=12345678");
            try
            {
                comentarioRepositorio.InserirComentario(comentario);
                comentario.Conteudo = "Adeus Mundo!";
                comentarioRepositorio.EditarComentario(comentario);

                comentario = comentarioRepositorio.Procurar(comentario.Id);
                Assert.IsTrue(comentario.Conteudo.Equals("Adeus Mundo!"));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        public void ContarTodosTest()
        {
            var repo = new ComentariosRepositorio("Server=191.242.230.255;Port=5432;Database=curtida; User Id=postgres;Password=12345678"); // passe a string de conexão aqui, se necessário
            var comentario = new Comentario()
            {
                Id = Guid.NewGuid(),
                IdPost = Guid.NewGuid(),
                IdUsuario = Guid.NewGuid(),
                Conteudo = "Comentário para teste de contagem",
                DataComentario = DateTime.Now,
                IdComentarioPai = Guid.Empty
            };

            repo.InserirComentario(comentario);

            int total = repo.ContarTodos(comentario.IdPost);

            Assert.IsTrue(total > 0, "O total de comentários deveria ser maior que 0.");
        }
    }
}
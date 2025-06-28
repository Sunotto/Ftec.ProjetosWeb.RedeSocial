using Ftec.ProjetosWeb.RedeSocial.Dominio.Entidades;
using Ftec.ProjetosWeb.RedeSocial.Repositorio;

namespace RepositorioTest
{
    [TestClass]
    public class CurtidasRepositorioTest
    {
        [TestMethod]
        public void InserirTeste()
        {
            var curtida = new Curtida();
            var curtidaRepositorio = new CurtidasRepositorio("");
            try
            {
                curtida.Id = Guid.NewGuid();
                curtida.IdUsuario = Guid.Empty;
                curtida.DataCurtida = DateTime.Now;
                curtida.Reacao = TipoReacao.Love;
                curtida.IdPostPai = Guid.Empty;

                curtidaRepositorio.InserirCurtida(curtida);
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
            var curtida = new Curtida();
            var curtidaRepositorio = new CurtidasRepositorio("");
            try
            {
                curtida.Id = Guid.NewGuid();
                curtida.IdUsuario = Guid.Empty;
                curtida.DataCurtida = DateTime.Now;
                curtida.Reacao = TipoReacao.Love;
                curtida.IdPostPai = Guid.Empty;

                curtidaRepositorio.InserirCurtida(curtida);
                curtidaRepositorio.ExcluirCurtida(curtida.Id);
                var curtidaRetorno = curtidaRepositorio.Procurar(curtida.Id);

                Assert.IsTrue(curtidaRetorno == null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void ProcurarTeste()
        {
            var curtida = new Curtida();
            var curtidaRepositorio = new CurtidasRepositorio("");
            try
            {
                curtida.Id = Guid.NewGuid();
                curtida.IdUsuario = Guid.Empty;
                curtida.DataCurtida = DateTime.Now;
                curtida.Reacao = TipoReacao.Love;
                curtida.IdPostPai = Guid.Empty;

                curtidaRepositorio.InserirCurtida(curtida);
                var curtidaRetorno = curtidaRepositorio.Procurar(curtida.Id);

                Assert.IsTrue(curtidaRetorno != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        public void ProcurarTodosTeste()
        {
            var curtida = new Curtida();
            var curtidaRepositorio = new CurtidasRepositorio("");
            try
            {
                curtida.Id = Guid.NewGuid();
                curtida.IdUsuario = Guid.Empty;
                curtida.DataCurtida = DateTime.Now;
                curtida.Reacao = TipoReacao.Love;
                curtida.IdPostPai = Guid.Empty;

                curtidaRepositorio.InserirCurtida(curtida);
                var curtidas = curtidaRepositorio.ProcurarTodosDoPost(curtida.IdPostPai);

                Assert.IsTrue(curtidas.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void AlterarTeste()
        {
            var curtida = new Curtida()
            {
                Id = Guid.NewGuid(),
                IdUsuario = Guid.Empty,
                DataCurtida = DateTime.Now,
                Reacao = TipoReacao.Love,
                IdPostPai = Guid.Empty
            };

            var curtidaRepositorio = new CurtidasRepositorio("");
            try
            {
                curtidaRepositorio.InserirCurtida(curtida);
                curtida.Reacao = TipoReacao.HaHa;
                curtidaRepositorio.AlterarReacao(curtida);

                curtida = curtidaRepositorio.Procurar(curtida.Id);
                Assert.IsTrue(curtida.Reacao.Equals(TipoReacao.HaHa));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        public void ContarTodosTest()
        {
            var repo = new CurtidasRepositorio(""); // passe a string de conexão aqui, se necessário
            var curtida = new Curtida()
            {
                Id = Guid.NewGuid(),
                IdUsuario = Guid.NewGuid(),
                IdPostPai = Guid.NewGuid(),
                DataCurtida = DateTime.Now,
                Reacao = TipoReacao.Like
            };

            repo.InserirCurtida(curtida);

            int total = repo.ContarTodos(curtida.IdPostPai);

            Assert.IsTrue(total > 0, "O total de curtidas deveria ser maior que 0.");
        }
        
    }
}
using Ftec.ProjetosWeb.RedeSocial.Dominio.Entidades;
using Ftec.ProjetosWeb.RedeSocial.Dominio.Repositorio;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.ProjetosWeb.RedeSocial.Repositorio
{
    public class ComentariosRepositorio : IComentariosRepository
    {
        private string strConexao;
        public ComentariosRepositorio(string strConexao)
        {
            this.strConexao = "Server=127.0.0.1;Port=5432;Database=postgres; User Id=postgres;Password=tangduva123;";
        }

        public void EditarComentario(Comentario comentario)
        {
            using (var conexao = new NpgsqlConnection(strConexao))
            {
                conexao.Open();
                using (var transacao = conexao.BeginTransaction())
                {
                    try
                    {
                        NpgsqlCommand cmd = new NpgsqlCommand();
                        cmd.Connection = conexao;
                        cmd.Transaction = transacao;
                        cmd.CommandText = "UPDATE public.comentarios " +
<<<<<<< HEAD
                                          " SET conteudo = @conteudo, " +
=======
                                          " SET conteudo = @conteudo " +
>>>>>>> ad807142b91324e15ecfa35451bf53e0a7cf3cb6
                                          " WHERE id_comentario = @id_comentario";
                        cmd.Parameters.AddWithValue("conteudo", comentario.Conteudo);
                        cmd.Parameters.AddWithValue("id_comentario", comentario.Id);
                        cmd.ExecuteNonQuery();

                        cmd.Parameters.Clear();
                        transacao.Commit();
                    }
                    catch (Exception ex)
                    {
                        transacao.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public bool ExcluirComentario(Guid id)
        {
            using (var conexao = new NpgsqlConnection(strConexao))
            {
                conexao.Open();
                using (var transacao = conexao.BeginTransaction())
                {
                    try
                    {
                        NpgsqlCommand cmd = new NpgsqlCommand();
                        cmd.Connection = conexao;
                        cmd.Transaction = transacao;
                        cmd.CommandText = " DELETE FROM public.comentarios " +
                                          " Where id_comentario = @id_comentario";
                        cmd.Parameters.AddWithValue("id_comentario", id);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                        transacao.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transacao.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public void InserirComentario(Comentario comentario)
        {
            using (var conexao = new NpgsqlConnection(strConexao))
            {
                conexao.Open();
                using (var transacao = conexao.BeginTransaction())
                {
                    try
                    {
                        NpgsqlCommand cmd = new NpgsqlCommand();
                        cmd.Connection = conexao;
                        cmd.Transaction = transacao;
                        cmd.CommandText = "INSERT INTO public.comentarios " +
                                          " (id_comentario, id_post, id_usuario, conteudo, data_comentario, id_comentario_pai) " +
                                          " VALUES(@id_comentario, @id_post, @id_usuario, @conteudo, @data_comentario, @id_comentario_pai)";
                        cmd.Parameters.AddWithValue("id_comentario", comentario.Id);
                        cmd.Parameters.AddWithValue("id_post", comentario.IdPost);
                        cmd.Parameters.AddWithValue("id_usuario", comentario.IdUsuario);
                        cmd.Parameters.AddWithValue("conteudo", comentario.Conteudo);
                        cmd.Parameters.AddWithValue("data_comentario", comentario.DataComentario);
                        cmd.Parameters.AddWithValue("id_comentario_pai", comentario.IdComentarioPai);
                        cmd.ExecuteNonQuery();

                        transacao.Commit();
                    }
                    catch (Exception ex)
                    {
                        transacao.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public List<Comentario> ProcurarTodosDoPost(Guid IdPost)
        {
            List<Comentario> TodosComentarios = new List<Comentario>();

            try
            {
                using (var con = new NpgsqlConnection(strConexao))
                {
                    con.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM comentarios WHERE id_post = @id_post";
                    cmd.Parameters.AddWithValue("@id_post", IdPost);
                    var leitor = cmd.ExecuteReader();
                    while (leitor.Read())
                    {
                        var comentario = new Comentario()
                        {
<<<<<<< HEAD
                            Id = Guid.Parse(leitor["id"].ToString()),
=======
                            Id = Guid.Parse(leitor["id_comentario"].ToString()),
>>>>>>> ad807142b91324e15ecfa35451bf53e0a7cf3cb6
                            IdPost = Guid.Parse(leitor["id_post"].ToString()),
                            IdUsuario = Guid.Parse(leitor["id_usuario"].ToString()),
                            Conteudo = leitor["conteudo"].ToString(),
                            DataComentario = Convert.ToDateTime(leitor["data_comentario"].ToString()),
                            IdComentarioPai = Guid.Parse(leitor["id_comentario_pai"].ToString()),
                        };
                        TodosComentarios.Add(comentario);
                    }
                    leitor.Close();
                }
                return TodosComentarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
<<<<<<< HEAD
=======
        public Comentario Procurar(Guid Id)
        {
            Comentario comentario = null;
            try
            {
                using (var con = new NpgsqlConnection(strConexao))
                {
                    con.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM comentarios WHERE id_comentario = @id_comentario";
                    cmd.Parameters.AddWithValue("@id_comentario", Id);
                    var leitor = cmd.ExecuteReader();

                    while (leitor.Read())
                    {
                        comentario = new Comentario()
                        {
                            Id = Guid.Parse(leitor["id_comentario"].ToString()),
                            IdPost = Guid.Parse(leitor["id_post"].ToString()),
                            IdUsuario = Guid.Parse(leitor["id_usuario"].ToString()),
                            Conteudo = leitor["conteudo"].ToString(),
                            DataComentario = Convert.ToDateTime(leitor["data_comentario"].ToString()),
                            IdComentarioPai = Guid.Parse(leitor["id_comentario_pai"].ToString()),
                        };
                    }

                    leitor.Close();
                }
                return comentario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
>>>>>>> ad807142b91324e15ecfa35451bf53e0a7cf3cb6
    }
}

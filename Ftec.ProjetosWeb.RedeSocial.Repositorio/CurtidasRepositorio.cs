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
    public class CurtidasRepositorio : ICurtidasRepository
    {
        private string strConexao;
        public CurtidasRepositorio(string strConexao)
        {
            this.strConexao = "Server=127.0.0.1;Port=5432;Database=postgres; User Id=postgres;Password=tangduva123;";
        }
        public void AlterarReacao(Curtida curtida)
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
                        cmd.CommandText = "UPDATE public.curtidas " +
                                          " SET tipo_reacao = @tipo_reacao " +
                                          " WHERE id_curtida = @id_curtida";
                        cmd.Parameters.AddWithValue("tipo_reacao", (int)curtida.Reacao);
                        cmd.Parameters.AddWithValue("id_curtida", curtida.Id);
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

        public bool ExcluirCurtida(Guid id)
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
                        cmd.CommandText = " DELETE FROM public.curtidas " +
                                          " Where id_curtida = @id_curtida";
                        cmd.Parameters.AddWithValue("id_curtida", id);
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

        public void InserirCurtida(Curtida curtida)
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
                        cmd.CommandText = "INSERT INTO public.curtidas " +
                                          " (id_curtida, id_usuario, data_curtida, tipo_reacao, id_post_pai) " +
                                          " VALUES(@id_curtida, @id_usuario, @data_curtida, @tipo_reacao, @id_post_pai)";
                        cmd.Parameters.AddWithValue("id_curtida", curtida.Id);
                        cmd.Parameters.AddWithValue("id_usuario", curtida.IdUsuario);
                        cmd.Parameters.AddWithValue("data_curtida", curtida.DataCurtida);
                        cmd.Parameters.AddWithValue("tipo_reacao", (int)curtida.Reacao);
                        cmd.Parameters.AddWithValue("id_post_pai", curtida.IdPostPai);
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

        public Curtida Procurar(Guid Id)
        {
            Curtida curtida = null;
            try
            {
                using (var con = new NpgsqlConnection(strConexao))
                {
                    con.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM curtidas WHERE id_curtida = @id_curtida";
                    cmd.Parameters.AddWithValue("@id_curtida", Id);
                    var leitor = cmd.ExecuteReader();

                    while (leitor.Read())
                    {
                        curtida = new Curtida()
                        {
                            Id = Guid.Parse(leitor["id_curtida"].ToString()),
                            IdUsuario = Guid.Parse(leitor["id_usuario"].ToString()),
                            DataCurtida = Convert.ToDateTime(leitor["data_curtida"].ToString()),
                            Reacao = Enum.Parse<TipoReacao>(leitor["tipo_reacao"].ToString()),
                            IdPostPai = Guid.Parse(leitor["id_post_pai"].ToString()),
                        };
                    }
                    
                    leitor.Close();
                }
                return curtida;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Curtida> ProcurarTodosDoPost(Guid IdPost)
        {
            List<Curtida> TodasCurtidas = new List<Curtida>();

            try
            {
                using (var con = new NpgsqlConnection(strConexao))
                {
                    con.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM curtidas WHERE id_post = @id_post";
                    cmd.Parameters.AddWithValue("@id_post", IdPost);
                    var leitor = cmd.ExecuteReader();
                    while (leitor.Read())
                    {
                        var curtida = new Curtida()
                        {
                            Id = Guid.Parse(leitor["id_curtida"].ToString()),
                            IdUsuario = Guid.Parse(leitor["id_usuario"].ToString()),
                            DataCurtida = Convert.ToDateTime(leitor["data_curtida"].ToString()),
                            Reacao = Enum.Parse<TipoReacao>(leitor["tipo_reacao"].ToString()),
                            IdPostPai = Guid.Parse(leitor["id_post_pai"].ToString()),
                        };
                        TodasCurtidas.Add(curtida);
                    }
                    leitor.Close();
                }
                return TodasCurtidas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

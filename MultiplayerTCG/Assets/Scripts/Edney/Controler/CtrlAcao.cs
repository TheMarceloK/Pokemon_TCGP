using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using PokemonTCGP_01.DAO.Model;


namespace PokemonTCGP_01.DAO.Controller
{
    public class CtrlAcao : DAO
    {
        public int inserir(Acao acao)
        {
            String sql = "INSERT INTO ACAO(JOGADA, ALVO, EFEITO, VALOREFEITO) " +
                "VALUES (@JOGADA, @ALVO, @EFEITO, @VALOREFEITO) SELECT SCOPE_IDENTITY() ";
            cmd = new SqlCommand(sql, conectar());

            par = new SqlParameter("@JOGADA", acao.jogada);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@ALVO", acao.alvo);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@EFEITO", acao.efeito);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@VALOREFEITO", acao.valorEfeito);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            reader = cmd.ExecuteReader();

            reader.Read();
            String pk = reader.GetValue(0).ToString();
            return Int32.Parse(pk);
        }

        public void alterar(Acao acao)
        {
            String sql = "UPDATE ACAO SET JOGADA=@JOGADA, ALVO=@ALVO, EFEITO=@EFEITO, VALOREFEITO=@VALOREFEITO " +
                "WHERE COD = @COD ";
            cmd = new SqlCommand(sql, conectar());

            par = new SqlParameter("@COD", acao.cod);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@JOGADA", acao.jogada);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@ALVO", acao.alvo);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@EFEITO", acao.efeito);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@VALOREFEITO", acao.valorEfeito);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            cmd.ExecuteNonQuery();
        }

        public void excluir(Acao acao)
        {
            String sql = "DELETE FROM ACAO " +
                "WHERE COD = @COD";

            cmd = new SqlCommand(sql, conectar());

            par = new SqlParameter("@COD", acao.cod);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            cmd.ExecuteNonQuery();
        }

        public Acao consultarPorCod(int cod)
        {
            String sql = "SELECT COD, NOME FROM ACAO " +
                "WHERE COD = @COD";
            cmd = new SqlCommand(sql, conectar());
            par = new SqlParameter("@COD", cod);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Acao acao = new Acao();
                acao.cod = Int32.Parse(reader.GetValue(reader.GetOrdinal("COD")).ToString());
                acao.efeito = reader.GetValue(reader.GetOrdinal("EFEITO")).ToString();
                


                return acao;
            }
            return null;
        }

        public List<Acao> listar()
        {
            String sql = "SELECT COD, NOME FROM ACAO " +
                "ORDER BY NOME";

            cmd = new SqlCommand(sql, conectar());

            reader = cmd.ExecuteReader();

            List<Acao> acoes = new List<Acao>();

            Acao acao;


            while (reader.Read())
            {
                acao = new Acao();

                acao.cod = Int32.Parse(reader.GetValue(reader.GetOrdinal("COD")).ToString());
                acao.efeito = reader.GetValue(reader.GetOrdinal("CARTA")).ToString();

                acoes.Add(acao);
            }
            return acoes;
        }
    }
}
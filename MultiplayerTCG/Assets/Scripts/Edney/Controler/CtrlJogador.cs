using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using PokemonTCGP_01.DAO.Model;

namespace PokemonTCGP_01.DAO.Controller
{
    public class CtrlJogador : DAO
    {
        #region CRUD
        public void inserir(Jogador jogador)
        {
            String sql = "INSERT INTO JOGADOR(NOME, USUARIO, SENHA, BARALHOS) " +
                "VALUES (@NOME, @USUARIO, @SENHA, @BARALHOS)";
            cmd = new SqlCommand(sql, conectar());

            par = new SqlParameter("@NOME", jogador.nome);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);
           
            par = new SqlParameter("@USUARIO", jogador.usuario);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@SENHA", jogador.senha);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@BARALHOS", jogador.baralhos);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            cmd.ExecuteNonQuery();
        }

        public void alterar(Jogador jogador)
        {
            String sql = "UPDATE JOGADOR SET NOME = @NOME, USUARIO = @USUARIO, SENHA = @SENHA, BARALHOS = @BARALHOS " + "WHERE COD = @COD";
            cmd = new SqlCommand(sql, conectar());

            par = new SqlParameter("@COD", jogador.cod);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@NOME", jogador.nome);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@USUARIO", jogador.usuario);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@SENHA", jogador.senha);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@BARALHOS", jogador.baralhos);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            cmd.ExecuteNonQuery();
        }

        public void excluir(Jogador jogador)
        {
            String sql = "DELETE FROM JOGADOR " +
                "WHERE COD = @COD";
            cmd = new SqlCommand(sql, conectar());

            par = new SqlParameter("@COD", jogador.cod);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);


            cmd.ExecuteNonQuery();
        }
        #endregion

        public Jogador consultarPorCod(int cod)
        {
            String sql = "SELECT COD, NOME FROM TIPO " +
                "WHERE COD = @COD";
            cmd = new SqlCommand(sql, conectar());
            par = new SqlParameter("@COD", cod);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Jogador jogador = new Jogador();
                jogador.cod = Int32.Parse(reader.GetValue(reader.GetOrdinal("COD")).ToString());
                jogador.nome = reader.GetValue(reader.GetOrdinal("NOME")).ToString();
                jogador.usuario = reader.GetValue(reader.GetOrdinal("USUARIO")).ToString();
                

                return jogador;
            }
            return null;
        }
        public List<Jogador> listar()
        {
            String sql = "SELECT COD, NOME FROM TIPO " +
                "ORDER BY NOME";

            cmd = new SqlCommand(sql, conectar());

            reader = cmd.ExecuteReader();

            List<Jogador> jogadores = new List<Jogador>();

            Jogador jogador;


            while (reader.Read())
            {
                jogador = new Jogador();

                jogador.cod = Int32.Parse(reader.GetValue(reader.GetOrdinal("COD")).ToString());
                jogador.nome = reader.GetValue(reader.GetOrdinal("NOME")).ToString();
                jogador.usuario = reader.GetValue(reader.GetOrdinal("USUARIO")).ToString();

                jogadores.Add(jogador);
            }
            return jogadores;
        }
    }
}
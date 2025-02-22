using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using PokemonTCGP_01.DAO.Model;

namespace PokemonTCGP_01.DAO.Controller
{
    public class CtrlBaralho : DAO
    {
        public int inserir(Baralho baralho)
        {
            String sql = "INSERT INTO BARALHO(NOME, ATIVO, JOGADOR, CARTAS) " +
                "VALUES (@NOME, @ATIVO, @JOGADOR, @CARTAS) SELECT SCOPE_IDENTITY() ";
            cmd = new SqlCommand(sql, conectar());

            par = new SqlParameter("@NOME", baralho.nome);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@ATIVO", baralho.ativo);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@JOGADOR", baralho.jogador);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@CARTAS", baralho.cartas);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            reader = cmd.ExecuteReader();

            reader.Read();
            String pk = reader.GetValue(0).ToString();
            return Int32.Parse(pk);
        }

        public void alterar(Baralho baralho)
        {
            String sql = "UPDATE BARALHO SET NOME=@NOME, ATIVO=@ATIVO, JOGADOR=@JOGADOR, CARTAS=@CARTAS " +
                "WHERE COD = @COD";

            cmd = new SqlCommand(sql, conectar());

            par = new SqlParameter("@COD", baralho.cod);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@NOME", baralho.nome);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@ATIVO", baralho.ativo);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@JOGADOR", baralho.jogador);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@CARTAS", baralho.cartas);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            

            cmd.ExecuteNonQuery();
        }

        public void excluir(Baralho baralho)
        {
            String sql = "DELETE FROM BARALHO " +
                "WHERE COD = @COD";

            cmd = new SqlCommand(sql, conectar());

            par = new SqlParameter("@COD", baralho.cod);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            cmd.ExecuteNonQuery();
        }

        public Baralho consultarPorCod(int cod)
        {
            String sql = "SELECT COD, NOME FROM BARALHO " +
                "WHERE COD = @COD";
            cmd = new SqlCommand(sql, conectar());
            par = new SqlParameter("@COD", cod);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Baralho baralho = new Baralho();
                baralho.cod = Int32.Parse(reader.GetValue(reader.GetOrdinal("COD")).ToString());
                baralho.nome = reader.GetValue(reader.GetOrdinal("NOME")).ToString();
                

                return baralho;
            }
            return null;
        }
        public List<Baralho> listar()
        {
            String sql = "SELECT COD, NOME FROM BARALHO " +
                "ORDER BY NOME";

            cmd = new SqlCommand(sql, conectar());

            reader = cmd.ExecuteReader();

            List<Baralho> baralhos = new List<Baralho>();

            Baralho baralho;


            while (reader.Read())
            {
                baralho = new Baralho();

                baralho.cod = Int32.Parse(reader.GetValue(reader.GetOrdinal("COD")).ToString());
                //Baralho.carta = reader.GetValue(reader.GetOrdinal("CARTA")).ToString();

                baralhos.Add(baralho);
            }
            return baralhos;
        }

    }
}

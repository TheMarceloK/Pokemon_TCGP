using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using PokemonTCGP_01.DAO.Model;

namespace PokemonTCGP_01.DAO.Controller
{
    public class CtrlPartida : DAO
    {
        public int inserir(Partida partida)
        {
            String sql = "INSERT INTO PARTIDA(DATA, BARALHO1, BARALHO2) " +
                "VALUES (@DATA, @BARALHO1, @BARALHO2) SELECT SCOPE_IDENTITY() ";
            cmd = new SqlCommand(sql, conectar());

            par = new SqlParameter("@DATA", partida.data);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@BARALHO1", partida.baralho01);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@BARALHO2", partida.baralho02);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            reader = cmd.ExecuteReader();

            reader.Read();
            String pk = reader.GetValue(0).ToString();
            return Int32.Parse(pk);
        }

        public void alterar(Partida partida)
        {
            String sql = "UPDATE PARTIDA SET DATA=@DATA, BARALHO1=@BARALHO1, BARALHO2=@BARALHO2 " +
                "WHERE COD = @COD ";
            cmd = new SqlCommand(sql, conectar());

            par = new SqlParameter("@COD", partida.cod);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@DATA", partida.data);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@BARALHO1", partida.baralho01);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@BARALHO2", partida.baralho02);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            cmd.ExecuteNonQuery();

        }

        public void excluir(Partida partida)
        {
            String sql = "DELETE FROM PARTIDA " +
                "WHERE COD = @COD";

            cmd = new SqlCommand(sql, conectar());

            par = new SqlParameter("@COD", partida.cod);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            cmd.ExecuteNonQuery();
        }

        public Partida consultarPorCod(int cod)
        {
            String sql = "SELECT COD, NOME FROM PARTIDA " +
                "WHERE COD = @COD";
            cmd = new SqlCommand(sql, conectar());
            par = new SqlParameter("@COD", cod);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Partida partida = new Partida();
                partida.cod = Int32.Parse(reader.GetValue(reader.GetOrdinal("COD")).ToString());
                
                return partida;
            }
            return null;
        }

        public List<Partida> listar()
        {
            String sql = "SELECT COD, NOME FROM PARTIDA " +
                "ORDER BY NOME";

            cmd = new SqlCommand(sql, conectar());

            reader = cmd.ExecuteReader();

            List<Partida> partidas = new List<Partida>();

            Partida partida;


            while (reader.Read())
            {
                partida = new Partida();

                partida.cod = Int32.Parse(reader.GetValue(reader.GetOrdinal("COD")).ToString());
                
                partidas.Add(partida);
            }
            return partidas;
        }
    }
}
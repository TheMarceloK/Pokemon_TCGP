using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using PokemonTCGP_01.DAO.Model;

namespace PokemonTCGP_01.DAO.Controller
{
    public class CtrlJogada : DAO
    {
        public int inserir(Jogada jogada)
        {
            String sql = "INSERT INTO JOGADA(ITEM, PARTIDA, LOCALCARTA, DANO, ENERGIA ) " +
                "VALUES (@ITEM, @PARTIDA, @LOCALCARTA, @DANO, @ENERGIA) SELECT SCOPE_IDENTITY() ";
            cmd = new SqlCommand(sql, conectar());

            par = new SqlParameter("@ITEM", jogada.item);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@PARTIDA", jogada.partida);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@LOCALCARTA", jogada.localCarta);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@DANO", jogada.dano);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@ENERGIA", jogada.energia);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            reader = cmd.ExecuteReader();

            reader.Read();
            String pk = reader.GetValue(0).ToString();
            return Int32.Parse(pk);
        }

        public void alterar(Jogada jogada)
        {
            String sql = "UPDATE JOGADA SET ITEM=@ITEM, PARTIDA=@PARTIDA, LOCALCARTA=@LOCALCARTA, DANO=@DANO, ENERGIA=@ENERGIA " +
                "WHERE COD = @COD ";
            cmd = new SqlCommand(sql, conectar());

            par = new SqlParameter("@COD", jogada.cod);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@ITEM", jogada.item);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@PARTIDA", jogada.partida);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@LOCALCARTA", jogada.localCarta);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@DANO", jogada.dano);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@ENERGIA", jogada.energia);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            cmd.ExecuteNonQuery();
        }

        public void excluir(Jogada jogada)
        {
            String sql = "DELETE FROM JOGADA " +
                "WHERE COD = @COD";

            cmd = new SqlCommand(sql, conectar());

            par = new SqlParameter("@COD", jogada.cod);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            cmd.ExecuteNonQuery();
        }

        public Jogada consultarPorCod(int cod)
        {
            String sql = "SELECT COD, NOME FROM JOGADA " +
                "WHERE COD = @COD";
            cmd = new SqlCommand(sql, conectar());
            par = new SqlParameter("@COD", cod);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Jogada jogada = new Jogada();
                jogada.cod = Int32.Parse(reader.GetValue(reader.GetOrdinal("COD")).ToString());
                jogada.localCarta = Int32.Parse(reader.GetValue(reader.GetOrdinal("LOCALCARTA")).ToString());
                jogada.dano = Int32.Parse(reader.GetValue(reader.GetOrdinal("DANO")).ToString());
                jogada.energia = Int32.Parse(reader.GetValue(reader.GetOrdinal("ENERGIA")).ToString());

                return jogada;
            }
            return null;
        }

        public List<Jogada> listar()
        {
            String sql = "SELECT COD, NOME FROM JOGADA " +
                "ORDER BY NOME";

            cmd = new SqlCommand(sql, conectar());

            reader = cmd.ExecuteReader();

            List<Jogada> jogadas = new List<Jogada>();

            Jogada jogada;


            while (reader.Read())
            {
                jogada = new Jogada();

                jogada.cod = Int32.Parse(reader.GetValue(reader.GetOrdinal("COD")).ToString());
                jogada.localCarta = Int32.Parse(reader.GetValue(reader.GetOrdinal("LOCALCARTA")).ToString());
                jogada.dano = Int32.Parse(reader.GetValue(reader.GetOrdinal("DANO")).ToString());
                jogada.energia = Int32.Parse(reader.GetValue(reader.GetOrdinal("ENERGIA")).ToString());

                jogadas.Add(jogada);
            }
            return jogadas;
        }
    }
}
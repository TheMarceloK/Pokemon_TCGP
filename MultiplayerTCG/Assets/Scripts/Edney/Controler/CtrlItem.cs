using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using PokemonTCGP_01.DAO.Model;

namespace PokemonTCGP_01.DAO.Controller
{
    public class CtrlItem : DAO
    {
        public int inserir(Item item)
        {
            String sql = "INSERT INTO ITEM(BARALHO, CARTA) " +
                "VALUES (@BARALHO, @CARTA) SELECT SCOPE_IDENTITY() ";
            cmd = new SqlCommand(sql, conectar());

            par = new SqlParameter("@BARALHO", item.baralho);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@CARTA", item.carta);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            reader = cmd.ExecuteReader();

            reader.Read();
            String pk = reader.GetValue(0).ToString();
            return Int32.Parse(pk);
        }

        public void alterar(Item item)
        {
            String sql = "UPDATE ITEM SET BARALHO=@BARALHO, CARTA=@CARTA " +
                "WHERE COD = @COD";

            cmd = new SqlCommand(sql, conectar());

            par = new SqlParameter("@BARALHO", item.baralho);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@CARTA", item.carta);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@COD", item.cod);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            cmd.ExecuteNonQuery();
        }

        public void excluir(Item item)
        {
            String sql = "DELETE FROM ITEM " +
                "WHERE COD = @COD";

            cmd = new SqlCommand(sql, conectar());

            par = new SqlParameter("@COD", item.cod);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            cmd.ExecuteNonQuery();
        }

        public Item consultarPorCod(int cod)
        {
            String sql = "SELECT COD, NOME FROM ITEM " +
                "WHERE COD = @COD";
            cmd = new SqlCommand(sql, conectar());
            par = new SqlParameter("@COD", cod);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Item item = new Item();
                item.cod = Int32.Parse(reader.GetValue(reader.GetOrdinal("COD")).ToString());
                //item.carta = reader.GetValue(reader.GetOrdinal("CARTA")).ToString();

                return item;
            }
            return null;
        }
        public List<Item> listar()
        {
            String sql = "SELECT COD, NOME FROM ITEM " +
                "ORDER BY NOME";

            cmd = new SqlCommand(sql, conectar());

            reader = cmd.ExecuteReader();

            List<Item> itens = new List<Item>();

            Item item;


            while (reader.Read())
            {
                item = new Item();

                item.cod = Int32.Parse(reader.GetValue(reader.GetOrdinal("COD")).ToString());
                //item.carta = reader.GetValue(reader.GetOrdinal("CARTA")).ToString();

                itens.Add(item);
            }
            return itens;
        }

    }
}
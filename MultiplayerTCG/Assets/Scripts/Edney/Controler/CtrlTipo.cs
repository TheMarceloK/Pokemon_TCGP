using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using PokemonTCGP_01.DAO.Model;

namespace PokemonTCGP_01.DAO.Controller
{
    public class CtrlTipo : DAO
    {
        #region "Manipulação de Dados"
        public int inserir (Tipo tipo)
        {
            String sql = "INSERT INTO TIPO(NOME) " +
                "VALUES (@NOME) SELECT SCOPE_IDENTITY()";
            cmd = new SqlCommand(sql, conectar());

            par = new SqlParameter("@NOME", tipo.nome);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            reader = cmd.ExecuteReader();

            reader.Read();
            String pk = reader.GetValue(0).ToString();
            return Int32.Parse(pk);
        }
        public void alterar (Tipo tipo)
        {
            String sql = "UPDATE TIPO SET NOME=@NOME " +
                "WHERE COD = @COD";
            
            cmd = new SqlCommand(sql, conectar());

            par = new SqlParameter("@NOME", tipo.nome);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@COD", tipo.cod);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            cmd.ExecuteNonQuery();
        }
        public void excluir(Tipo tipo)
        {
            String sql = "DELETE FROM TIPO " +
                "WHERE COD = @COD";

            cmd = new SqlCommand(sql, conectar());

            par = new SqlParameter("@COD", tipo.cod);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            cmd.ExecuteNonQuery();
        }

        #endregion
        
        
        #region "consultas"

        public Tipo consultarPorCod (int cod)
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
                Tipo tipo = new Tipo();
                tipo.cod = Int32.Parse(reader.GetValue(reader.GetOrdinal("COD")).ToString());
                tipo.nome = reader.GetValue(reader.GetOrdinal("NOME")).ToString();

                return tipo;
            }
            return null;
        }
        public List<Tipo> listar()
        {
            String sql = "SELECT COD, NOME FROM TIPO " +
                "ORDER BY NOME";

            cmd = new SqlCommand(sql, conectar());
            
            reader = cmd.ExecuteReader();

            List<Tipo> tipos = new List<Tipo>();

            Tipo tipo;

            
            while (reader.Read())
            {
                tipo = new Tipo();

                tipo.cod = Int32.Parse(reader.GetValue(reader.GetOrdinal("COD")).ToString());
                tipo.nome = reader.GetValue(reader.GetOrdinal("NOME")).ToString();

                tipos.Add(tipo);
            }
            return tipos;
        }
        #endregion

    }
}
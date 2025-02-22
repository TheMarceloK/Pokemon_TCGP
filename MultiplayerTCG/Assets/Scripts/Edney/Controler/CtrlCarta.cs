using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using PokemonTCGP_01.DAO.Model;

namespace PokemonTCGP_01.DAO.Controller
{
    public class CtrlCarta : DAO
    {
        public int inserir(Carta carta)
        {
            String sql = "INSERT INTO CARTA(NOME, IMAGEM, HP, ATAQUENOME, ATAQUECUSTO, ATAQUEDANO, ATAQUEEFEITO, RECUO, EFEITO, ESTAGIO, TIPO) " +
                "VALUES (@NOME, @IMAGEM, @HP, @ATAQUENOME, @ATAQUECUSTO, @ATAQUEDANO, @ATAQUEEFEITO, @RECUO, @EFEITO, @ESTAGIO, @TIPO) SELECT SCOPE_IDENTITY() ";
            cmd = new SqlCommand(sql, conectar());

            par = new SqlParameter("@NOME", carta.nome);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@IMAGEM", carta.imagem);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@HP", carta.hp);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@ATAQUENOME", carta.ataqueNome);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@ATAQUECUSTO", carta.ataqueCusto);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@ATAQUEDANO", carta.ataqueDano);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@ATAQUEEFEITO", carta.ataqueEfeito);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@RECUO", carta.recuo);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@EFEITO", carta.efeito);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@ESTAGIO", carta.estagio);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@TIPO", carta.tipo);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            reader = cmd.ExecuteReader();

            reader.Read();
            String pk = reader.GetValue(0).ToString();
            return Int32.Parse(pk);
        }

        public void alterar(Carta carta)
        {
            String sql = "UPDATE CARTA SET(NOME=@NOME, IMAGEM=@IMAGEM, HP=@HP, ATAQUENOME=@ATAQUENOME, ATAQUECUSTO=@ATAQUECUSTO, ATAQUEDANO=@ATAQUEDANO, ATAQUEEFEITO=@ATAQUEEFEITO, RECUO=@RECUO, EFEITO=@EFEITO, ESTAGIO=@ESTAGIO, TIPO=@TIPO) " +
                "WHERE COD = @COD ";
            cmd = new SqlCommand(sql, conectar());

            par = new SqlParameter("@COD", carta.cod);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@NOME", carta.nome);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@IMAGEM", carta.imagem);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@HP", carta.hp);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@ATAQUENOME", carta.ataqueNome);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@ATAQUECUSTO", carta.ataqueCusto);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@ATAQUEDANO", carta.ataqueDano);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@ATAQUEEFEITO", carta.ataqueEfeito);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@RECUO", carta.recuo);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@EFEITO", carta.efeito);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@ESTAGIO", carta.estagio);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@TIPO", carta.tipo);
            par.SqlDbType = System.Data.SqlDbType.VarChar;
            cmd.Parameters.Add(par);

            cmd.ExecuteNonQuery();
        }

        public void excluir(Carta carta)
        {
            String sql = "DELETE FROM CARTA " +
                "WHERE COD = @COD";

            cmd = new SqlCommand(sql, conectar());

            par = new SqlParameter("@COD", carta.cod);
            par.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(par);

            cmd.ExecuteNonQuery();
        }

        public Carta consultarPorCod(int cod)
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
                Carta carta = new Carta();
                carta.cod = Int32.Parse(reader.GetValue(reader.GetOrdinal("COD")).ToString());
                carta.nome = reader.GetValue(reader.GetOrdinal("NOME")).ToString();
                carta.imagem = reader.GetValue(reader.GetOrdinal("IMAGEM")).ToString();
                carta.hp = Int32.Parse(reader.GetValue(reader.GetOrdinal("HP")).ToString());
                carta.ataqueNome = reader.GetValue(reader.GetOrdinal("ATAQUENOME")).ToString();
                carta.ataqueDano = Int32.Parse(reader.GetValue(reader.GetOrdinal("ATAQUEDANO")).ToString());
                carta.ataqueCusto = Int32.Parse(reader.GetValue(reader.GetOrdinal("ATAQUECUSTO")).ToString());
                carta.ataqueEfeito = reader.GetValue(reader.GetOrdinal("ATAQUEEFEITO")).ToString();
                carta.recuo = Int32.Parse(reader.GetValue(reader.GetOrdinal("RECUO")).ToString());
                carta.efeito = reader.GetValue(reader.GetOrdinal("EFEITO")).ToString();
                carta.estagio = Int32.Parse(reader.GetValue(reader.GetOrdinal("ESTAGIO")).ToString());
                //carta.tipo = reader.GetValue(reader.GetOrdinal("EFEITO")).ToString();


                return carta;
            }
            return null;
        }

        public List<Carta> listar()
        {
            String sql = "SELECT COD, NOME FROM CARTA " +
                "ORDER BY NOME";

            cmd = new SqlCommand(sql, conectar());

            reader = cmd.ExecuteReader();

            List<Carta> cartas = new List<Carta>();

            Carta carta;


            while (reader.Read())
            {
                carta = new Carta();

                carta.cod = Int32.Parse(reader.GetValue(reader.GetOrdinal("COD")).ToString());
                carta.nome = reader.GetValue(reader.GetOrdinal("NOME")).ToString();
                carta.imagem = reader.GetValue(reader.GetOrdinal("IMAGEM")).ToString();
                carta.hp = Int32.Parse(reader.GetValue(reader.GetOrdinal("HP")).ToString());
                carta.ataqueNome = reader.GetValue(reader.GetOrdinal("ATAQUENOME")).ToString();
                carta.ataqueDano = Int32.Parse(reader.GetValue(reader.GetOrdinal("ATAQUEDANO")).ToString());
                carta.ataqueCusto = Int32.Parse(reader.GetValue(reader.GetOrdinal("ATAQUECUSTO")).ToString());
                carta.ataqueEfeito = reader.GetValue(reader.GetOrdinal("ATAQUEEFEITO")).ToString();
                carta.recuo = Int32.Parse(reader.GetValue(reader.GetOrdinal("RECUO")).ToString());
                carta.efeito = reader.GetValue(reader.GetOrdinal("EFEITO")).ToString();
                carta.estagio = Int32.Parse(reader.GetValue(reader.GetOrdinal("ESTAGIO")).ToString());

                cartas.Add(carta);
            }
            return cartas;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using UnityEngine;


namespace PokemonTCGP_01.DAO.Controller
{
    public class DAO
    {
        public SqlParameter par; // é utilizado pra evitar sql injection, transformando oq for inserido em texto
        public SqlCommand cmd; // variavel onde vai colocar os comandos sql (insert, delete...)
        public SqlDataReader reader; // valor que é retornado em uma consulta

        public SqlConnection conectar()
        {
            try
            {
                //String conexao = ConfigurationManager.ConnectionStrings["Banco"].ConnectionString;
                string conexao = "Server=localhost;Database=PokemonDB;User Id=sa;Password=ifrj;";

                SqlConnection conn = new SqlConnection(conexao);
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao conectar ao banco de dados: " + ex.Message);
                throw new Exception("Erro ao conectar ao banco de dados.", ex);
            }
        }


    }
}
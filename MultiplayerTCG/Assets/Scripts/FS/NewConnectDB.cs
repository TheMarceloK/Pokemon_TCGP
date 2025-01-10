


using System;
using System.Text;
using System.Data.SqlClient;
using System.Linq.Expressions;
using UnityEngine;

public class NewConnectDB
{
    public SqlParameter par;
    public SqlCommand cmd;
    public SqlDataReader reader;

    
    public SqlConnection conectar()
    {
        try
        {
            Debug.Log("Conectado!!!!!!!!!!!!!!!!!!!!!");
            String conexao = "Data Source=localhost;" +
                             "Initial Catalog=POKEMON_2024_02;" +
                             "User ID=sa;" +
                             "Password=SuaSenhaForte123!";
            SqlConnection conn = new SqlConnection(conexao);
            conn.Open();
            
            return conn;
        }catch(Exception ex)
        {
            Debug.LogError("Erro ao conectar ao banco de dados: " + ex.Message);
        }
        return null;
    }
}

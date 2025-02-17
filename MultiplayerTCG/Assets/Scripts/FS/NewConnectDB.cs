


using System;
using System.Text;
using System.Data.SqlClient;
using System.Security.Cryptography;
using UnityEngine;
// using System.Md5;
public class NewConnectDB
{
    public SqlParameter par;
    public SqlCommand cmd;
    public SqlDataReader reader;

    
    public SqlConnection conectar()
    {
        try
        {
            //Debug.Log("Conectado!!!!!!!!!!!!!!!!!!!!!");
            //byte[] conexao = Encoding.UTF8.GetBytes("Data Source=localhost;" +
            //                 "Initial Catalog=POKEMON_2024_02;" +
            //                 "User ID=sa;" +
            //                 "Password=SuaSenhaForte123!");

            //SqlConnection conn = new SqlConnection(Encoding.UTF8.GetString(conexao));

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

    public static string HashMd5(string input){
        MD5 md5Hash = MD5.Create();

        byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

        StringBuilder sBuilder = new StringBuilder();

        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }

        return sBuilder.ToString();

    }

}

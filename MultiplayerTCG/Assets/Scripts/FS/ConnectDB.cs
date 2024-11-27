using System.Data.SqlClient;
using UnityEngine;

public class ConnectDB : MonoBehaviour
{
    private string connectionString = "Data Source=localhost;Initial Catalog=POKEMON_2024_02;User ID=sa;Password=SuaSenhaForte123!";

    void Start()
    {
        ConnectToDatabase();
    }

    void ConnectToDatabase()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
               
                connection.Open();
                Debug.Log("Conexão estabelecida com sucesso!");
                // Execute suas consultas SQL aqui
            }
            catch (SqlException e)
            {
                Debug.LogError("Erro ao conectar ao banco de dados: " + e.Message);
            }
        }
    }
}

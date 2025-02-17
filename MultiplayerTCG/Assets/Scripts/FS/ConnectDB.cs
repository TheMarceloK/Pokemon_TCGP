
using System;
using System.Data.SqlClient;
using UnityEngine;

public class ConnectDB : MonoBehaviour
{
    private string connectionString = "Data Source=localhost;Initial Catalog=POKEMON_2024_02;User ID=sa;Password=SuaSenhaForte123!";
    [SerializeField] GameObject connecter;
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
                connecter.SetActive(true);
                // Execute suas consultas SQL aqui
                SqlCommand command = new SqlCommand("SELECT * FROM TIPO", connection);
                SqlDataReader reader = command.ExecuteReader();
                Debug.Log(reader);
                
            }
            catch (SqlException e)
            {
                Debug.LogError("Erro ao conectar ao banco de dados: " + e.Message);
            }
        }
    }
}
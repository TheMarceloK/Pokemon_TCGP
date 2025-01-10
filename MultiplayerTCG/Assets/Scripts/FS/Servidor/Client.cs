using System;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class Client : MonoBehaviour
{
    private TcpClient client;
    private NetworkStream stream;
    private string playerId;

    void Start()
    {
        client = new TcpClient();
        client.BeginConnect("127.0.0.1", 7777, new AsyncCallback(OnConnect), null);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Exemplo de ação do jogador
        {
            SendMessageToServer($"{playerId} fez uma jogada!");
        }
    }

    void OnConnect(IAsyncResult ar)
    {
        if (client.Connected)
        {
            Debug.Log("Connected to server");
            stream = client.GetStream();
            byte[] buffer = new byte[1024];
            stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnDataReceived), buffer);
        }
    }

    void SendMessageToServer(string message)
    {
        if (client.Connected)
        {
            byte[] requestData = Encoding.ASCII.GetBytes(message);
            stream.BeginWrite(requestData, 0, requestData.Length, null, null);
        }
    }

    void OnDataReceived(IAsyncResult ar)
    {
        byte[] buffer = (byte[])ar.AsyncState;
        int bytesRead = stream.EndRead(ar);
        string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
        if (response != "")
        {
            Debug.Log("Received from server: " + response);
        }
        

        // identificação mensagem do jogador
        if (response == "Player 1" || response == "Player 2")
        {
            playerId = response;
            Debug.Log("Player ID set to: " + playerId);
        }

        // Continuar lendo dados do servidor
        stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnDataReceived), buffer);
    }

    void OnApplicationQuit()
    {
        client.Close();
    }
}

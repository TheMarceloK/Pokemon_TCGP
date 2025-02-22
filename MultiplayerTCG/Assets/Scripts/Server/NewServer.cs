using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

public class NewServer : MonoBehaviour
{
    private TcpListener server;
    private TcpClient player1;
    private TcpClient player2;

    void Start()
    {
        server = new TcpListener(IPAddress.Any, 5000);
        server.Start();
        Debug.Log("Server started on port 5000");
        server.BeginAcceptTcpClient(new AsyncCallback(OnClientConnect), null);
    }

    void OnClientConnect(IAsyncResult ar)
    {
        TcpClient client = server.EndAcceptTcpClient(ar);
        Debug.Log("Client connected");

        if (player1 == null)
        {
            player1 = client;
            Debug.Log("Player 1 connected");
        }
        else if (player2 == null)
        {
            player2 = client;
            Debug.Log("Player 2 connected");
            StartGame();
        }

        // Continuar aceitando mais clientes
        server.BeginAcceptTcpClient(new AsyncCallback(OnClientConnect), null);

        // Iniciar a leitura de dados do cliente
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1024];
        stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnDataReceived), Tuple.Create(client, buffer));
    }

    private void StartGame()
    {
        int coinFlip = Random.Range(0, 2);

        if (coinFlip == 0)
        {
            SendMessageToClient(player1, "StartTurn:0");
            SendMessageToClient(player2, "StartTurn:1");
        }
        else
        {
            SendMessageToClient(player1, "StartTurn:1");
            SendMessageToClient(player2, "StartTurn:0");
        }
    }

    void OnDataReceived(IAsyncResult ar)
    {
        var state = (Tuple<TcpClient, byte[]>)ar.AsyncState;
        TcpClient client = state.Item1;
        byte[] buffer = state.Item2;

        NetworkStream stream = client.GetStream();
        int bytesRead = stream.EndRead(ar);

        if (bytesRead > 0)
        {
            string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Debug.Log("Received message: " + message);

            // Enviar a mensagem para o outro jogador
            if (client == player1 && player2 != null)
            {
                SendMessageToClient(player2, message);
            }
            else if (client == player2 && player1 != null)
            {
                SendMessageToClient(player1, message);
            }

            // Continuar lendo dados do cliente
            stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnDataReceived), Tuple.Create(client, buffer));
        }
    }

    void SendMessageToClient(TcpClient client, string message)
    {
        if (client == null) return;

        NetworkStream stream = client.GetStream();
        byte[] responseData = Encoding.ASCII.GetBytes(message);
        stream.Write(responseData, 0, responseData.Length);
    }

    void OnApplicationQuit()
    {
        server.Stop();
    }
}

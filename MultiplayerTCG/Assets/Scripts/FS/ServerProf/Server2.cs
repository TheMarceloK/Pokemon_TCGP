using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
public class Server2 : MonoBehaviour
{
    TcpListener listener = null;
    int porta = 7777;
    GameController controle = new GameController();
    bool rodando = true;
    private void Start()
    {
        IPAddress enderecoServidor = IPAddress.Parse("127.0.0.1");
        listener = new TcpListener (enderecoServidor, porta);
        listener.Start ();
    }
    //  private void Start()
    //     {
    //         TcpListener listener = null;
    //         int porta = 7777;
    //         GameController controle = new GameController();
    //         bool rodando = true;

    //         try
    //         {
    //             IPAddress enderecoServidor = IPAddress.Parse("127.0.0.1");
    //             listener = new TcpListener (enderecoServidor, porta);
    //             listener.Start ();

    //             while (rodando)
    //             {
    //                 if (!controle.estaPronto())
    //                 {
    //                     Debug.Log("Aguardando conexoes");
    //                     TcpClient cliente = listener.AcceptTcpClient();
    //                     controle.adicionaJogador (cliente);
    //                 } else
    //                 {
    //                     controle.jogar();
    //                 }
    //             }


    //         } catch (SocketException se)
    //         {
    //             Debug.LogError("Erro de rede: {0}" + se);
    //         }
    //     }
    private void Update()
    {
        Debug.Log("Aguardando conexoes");
        TcpClient cliente = listener.AcceptTcpClient();
        controle.adicionaJogador (cliente);
        // if (!controle.estaPronto())
        // {
        //     Debug.Log("Aguardando conexoes");
        //     TcpClient cliente = listener.AcceptTcpClient();
        //     controle.adicionaJogador (cliente);
        // } else
        // {
        //     controle.jogar();
        // }
    }
}

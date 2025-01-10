using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Sockets;
using System.IO;
using System.Threading;
public class Player : MonoBehaviour
    {
        public int id { get; set; }
        GameController controleJogo;
        TcpClient cliente;

        StreamReader reader = null;
        StreamWriter writer = null;

        Thread thread;


        public Player(GameController controleJogo, int id, TcpClient cliente) {
            this.id = id;
            this.controleJogo = controleJogo;
            this.cliente = cliente;

            NetworkStream stream = cliente.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);

            thread = new Thread(run);
            thread.Start();
        }

        public void run ()
        {
            String dados = null;
            dados = reader.ReadLine(); 

            while (dados != null)
            {
                Debug.Log("Recebido do id " + id + " | Mensagem: " + dados);

                foreach (Player jogador in controleJogo.jogadores)
                {
                    //if (this.id != jogador.id)
                    //{
                        jogador.enviar(dados);
                    //}
                }
                dados = reader.ReadLine();
            }
            cliente.Close();
        }


        public void enviar (String mensagem)
        {
            Debug.Log("Enviando para o id: " + id + " | Mensagem: " + mensagem);
            writer.WriteLine(mensagem);
            writer.Flush();
        }
    }
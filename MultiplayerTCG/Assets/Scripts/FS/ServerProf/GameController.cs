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

public class GameController : MonoBehaviour
    {
        const int MAXIMO = 2;
        int id = 0;
        bool pronto = false;
        bool aguardando = false;
        public Player[] jogadores;

        public bool estaPronto()
        {
            return pronto;
        }

        public GameController()
        {
            jogadores = new Player[MAXIMO];
        }

        public void adicionaJogador(TcpClient cliente)
        {
            if (this.id > MAXIMO - 1)
            {
                desconectarJogador(cliente);
                return;
            }
            int id = proximoId();
            jogadores[id] = new Player(this, id, cliente);
        }

        private void desconectarJogador(TcpClient cliente)
        {
            NetworkStream stream = cliente.GetStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine("Servidor lotado!");
            writer.Flush();
            writer.Close();
            Debug.Log("Servidor lotado!");
        }

        private int proximoId()
        {
            return this.id++;
        }

        public void jogar()
        {
            if (!aguardando)
            {
                iniciarJogo();
                this.aguardando = true;
            }
        }

        private void iniciarJogo()
        {

        }
    }

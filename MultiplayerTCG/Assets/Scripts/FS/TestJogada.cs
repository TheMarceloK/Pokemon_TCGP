using System;
using UnityEditor;
using UnityEngine;

public class TestJogada : MonoBehaviour
{
    private JogadaController jogadacontroller;
    private void Start()
    {
        jogadacontroller = new JogadaController();
        Jogada jogada = new Jogada
        {
            baralho = 1,
            carta = 1,
            dano = 30,
            partida = 1,
            local_carta = 1,
            energia = 0
        };
        
        // Debug.Log(jogada.dano);
        // jogadacontroller.CreateJogada(jogada);
        Debug.Log("Criando jogada: "+jogadacontroller.CreateJogada(jogada).cod);
        
    }

}
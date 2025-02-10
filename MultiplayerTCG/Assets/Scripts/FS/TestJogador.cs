using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestJogador : MonoBehaviour
{
    private JogadorController jogadorController;
    private Jogador jogador;
    
    
    // Start is called before the first frame update
    void Start()
    {
        jogadorController = new JogadorController();
        jogador = new Jogador();
        // jogador.nome = "Jogador";
        jogador.usuario = "Jogador123";
        jogador.senha = "123";
        // jogadorController.CreatePlayer(jogador);

        jogador = jogadorController.CheckPlayer(jogador.usuario, jogador.senha);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Usuario: " + jogador.cod);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    
public class TestCartas :MonoBehaviour
{
    private void Start()
    {

        
        
        
        CartaController cartaController = new CartaController();
        
        // List<Carta> cartas = new List<Carta>();
        // cartas = cartaController.GetCartas(1);
        //
        // Debug.Log(cartas.Count);
        
        Carta cartaBulbasaur = new Carta
        {
            nome = "Bulbasaur",
            imagem = "bulbasaur.png",
            hp = 70,
            ataqueNome = "Chicote de Vinha",
            ataqueCusto = 2,
            ataqueDano = 45,
            ataqueEfeito = "Pode envenenar o oponente.",
            recuo = 1,
            efeito = "Nenhum",
            estagio = 1,
            tipo = 3
        };
        
        // cartaController.CreateCarta(cartaBulbasaur);



    }


    
}

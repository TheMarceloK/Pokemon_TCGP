using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBaralho : MonoBehaviour
{
    private BaralhoController baralhoController;
    private Baralho baralho;
    
    
    // Start is called before the first frame update
    void Start()
    {
        baralhoController = new BaralhoController();
        baralho = new Baralho();
        baralho.nome = "Baralho2";
        baralho.jogador = 1;
        Debug.Log(baralho);

        // baralhoController.CreateBaralho(baralho);
        List<Baralho> baralhos = new List<Baralho>();
        baralhos = baralhoController.GetBaralhos(baralho.jogador);
        Debug.Log(baralhos[0].nome);

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Usuario: " + jogador.cod);
    }
}
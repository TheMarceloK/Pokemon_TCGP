using System;
using UnityEngine;


public class TesteTipo : MonoBehaviour
{
    
    private TipoController TipoController;

    private void Start()
    {
        TipoController = new TipoController();
        Debug.Log("Nome do tipo 2: "+TipoController.consultarPorCod(2).nome);
        
    }

    private void Update()
    {
        // Debug.Log("Nome do tipo 2: "+TipoController.consultarPorCod(2).nome);
    }
}

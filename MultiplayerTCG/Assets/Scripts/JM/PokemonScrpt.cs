using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonScrpt : MonoBehaviour
{
    [SerializeField] PokemonData data;
    int currentLife;

    // Start is called before the first frame update
    void Start()
    {
        currentLife = data.maxLife;
    }

    public void TakeDamage(int amountOfDamage, out bool died)
    {
        died = false;
        currentLife -= amountOfDamage;
        if(currentLife < 0)
        {
            died = true;
            Faint();
        }
    }

    private void Faint()
    {

    }
}

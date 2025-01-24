using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokemonScrpt : MonoBehaviour
{
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Text _lifeText;

    PokemonData _data;
    int damageTaken;

    // Start is called before the first frame update
    public void Inicialize(PokemonData data)
    {
        _data = data;
        damageTaken = 0;
        _spriteRenderer.sprite = _data.cardArt;
    }

    public void TakeDamage(int amountOfDamage, out bool died)
    {
        died = false;
        damageTaken += amountOfDamage;
        UpdateLifeText();
        if(damageTaken > _data.MaxLife)
        {
            died = true;
            Faint();
        }
    }

    private void UpdateLifeText()
    {
        _lifeText.text = "" + (_data.MaxLife - damageTaken);
    }

    private void Faint()
    {
        Destroy(gameObject);
    }
}

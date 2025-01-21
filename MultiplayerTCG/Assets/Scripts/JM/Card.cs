using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    CardData _data;

    bool _canUse;

    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] SpriteRenderer _spriteHolvered;

    public void InicializeCard(CardData data)
    {
        _data = data;
        _spriteRenderer.sprite = _data.cardArt;
        _spriteHolvered.sprite = _data.cardArt;
    }

    public void SetUsability(bool usability)
    {
        _canUse = usability;
    }

    public void ShowHolveredImage(bool holvered)
    {
        _spriteRenderer.gameObject.SetActive(!holvered);
        _spriteHolvered.gameObject.SetActive(holvered);
    }

    private void Update()
    {
        
    }

    public void UseCard()
    {
        if (!_canUse)
            return;

        if (_data.GetType() == ScriptableObject.CreateInstance<PokemonData>().GetType())
        {
            PokemonData pokemon = (PokemonData) _data;

            Debug.Log(pokemon.pokemonName);
        }

        Destroy(gameObject);
    }
}

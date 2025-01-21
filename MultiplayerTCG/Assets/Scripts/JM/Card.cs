using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    CardData _data;

    bool _canUse;

    [SerializeField] SpriteRenderer _spriteRenderer;

    public void InicializeCard(CardData data)
    {
        _data = data;
        _spriteRenderer.sprite = _data.cardArt;
    }

    public void SetUsability(bool usability)
    {
        _canUse = usability;
    }

    private void Update()
    {
        
    }

    public void UseCard()
    {
        if (!_canUse)
            return;

        Debug.Log(_data.ID);

        if (_data.GetType() == ScriptableObject.CreateInstance<PokemonData>().GetType())
        {
            PokemonData pokemon = (PokemonData) _data;

            Debug.Log(pokemon.pokemonName);
        }

        Destroy(gameObject);
    }
}

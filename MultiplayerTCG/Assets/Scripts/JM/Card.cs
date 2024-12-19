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
        Debug.Log(_data.effect);
    }

    public void SetUsability(bool usability)
    {
        _canUse = usability;
    }

    public void UseCard()
    {
        if (!_canUse)
            return;

        if (_data.pokemonID >= 0)
        {
            
        }

        Debug.Log(_data.effect);
        Destroy(gameObject);
    }

}

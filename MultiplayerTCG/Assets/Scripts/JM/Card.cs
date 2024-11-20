using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Card : MonoBehaviour
{
    CardData _data;

    [SerializeField] SpriteRenderer _spriteRenderer;

    public void InicializeCard(CardData data)
    {
        _data = data;

        Debug.Log(_data.effect);

        _spriteRenderer.sprite = _data.cardArt;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            UseCard();
        }
    }

    public void UseCard()
    {
        Debug.Log(_data.effect);
        Destroy(gameObject);
    }

}

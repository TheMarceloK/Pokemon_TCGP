using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    CardData _data;

    public CardData Data => _data; 

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
}

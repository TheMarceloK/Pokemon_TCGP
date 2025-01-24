using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class Deck : MonoBehaviour
{
    [SerializeField] CardData[] unshuffledCards;
    List<CardData> cards = new List<CardData>();

    public void StartGame()
    {
        foreach (CardData card in unshuffledCards)
        {
            cards.Add(card);
        }

        //Shuffle();
    }

    public void Shuffle()
    {
        //Embaralha as Cartas do deck
        cards = cards.OrderBy(_ =>  new Random().Next()).ToList();
    }

    public void DrawCard(out CardData cardDrown)
    {
        if(cards.Count <= 0)
        {
            cardDrown = null;
            return;
        }
        int cardSelected;

        //Use only when using Shuffle(). Card pick is always from the top 
        //cardSelected = 0;

        //Does not need to Shuffle(). Card pick does not follow deck order
        cardSelected = UnityEngine.Random.Range(0, cards.Count);

        cardDrown = cards[cardSelected];
        cards.RemoveAt(cardSelected);
    }
}

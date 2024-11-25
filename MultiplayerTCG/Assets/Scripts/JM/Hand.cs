using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] GameObject cardPrefab;

    List<Card> handCards = new List<Card>();

    int numOfCards;

    public void AddCard(CardData cardToAdd)
    {
        GameObject newCard = Instantiate(cardPrefab,transform.position + (transform.right * numOfCards), transform.rotation);

        Card newCardScrpt = newCard.GetComponent<Card>();

        newCardScrpt.InicializeCard(cardToAdd);

        handCards.Add(newCardScrpt);

        numOfCards++;
    }

    public void RemoveCard(Card cardToRemove)
    {
        handCards.Remove(cardToRemove);
    }

    public void SetHandCardsUsability(bool usability)
    {
        foreach (Card card in handCards)
        {
            card.SetUsability(usability);
        }
    }
}

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
        GameObject newCard = Instantiate(cardPrefab,transform.position, transform.rotation);

        Card newCardScrpt = newCard.GetComponent<Card>();

        newCardScrpt.InicializeCard(cardToAdd);

        handCards.Add(newCardScrpt);

        ArrangeCards();
    }

    public void RemoveCard(Card cardToRemove)
    {
        handCards.Remove(cardToRemove);
        ArrangeCards();
    }

    public void ArrangeCards()
    {
        for (int i = 0; i < handCards.Count; i++)
        {
            handCards[i].transform.position = transform.position + new Vector3(i, 0, 0.1f * i);
        }
    }

    public void SetHandCardsUsability(bool usability)
    {
        foreach (Card card in handCards)
        {
            card.SetUsability(usability);
        }
    }
}

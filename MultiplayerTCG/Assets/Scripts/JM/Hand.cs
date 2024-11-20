using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] GameObject cardPrefab;

    int numOfCards;

    public void AddCard(CardData cardToAdd)
    {
         GameObject newCard = Instantiate(cardPrefab,transform.position + (transform.right * numOfCards), transform.rotation);

        Card newCardScrtppspwefiuigfeaiiaeriaeivbi = newCard.GetComponent<Card>();

        newCardScrtppspwefiuigfeaiiaeriaeivbi.InicializeCard(cardToAdd);

        numOfCards++;
    }
}

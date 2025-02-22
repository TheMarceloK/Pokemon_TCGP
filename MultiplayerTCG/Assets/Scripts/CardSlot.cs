using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSlot : MonoBehaviour
{
    public bool isOccupied = false; // Indica se o slot est� ocupado
    private GameObject currentCard; // Refer�ncia para a carta atual no slot

    public void PlaceCard(GameObject card)
    {
        if (!isOccupied)
        {
            // Coloca a carta no slot
            currentCard = card;
            card.transform.position = transform.position;
            isOccupied = true;
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Slot j� est� ocupado!");
        }
    }

    public void RemoveCard(GameObject card)
    {
        // Verifica se a carta a ser removida � a atual no slot
        if (currentCard == card)
        {
            currentCard = null;
            isOccupied = false;
            gameObject.SetActive(true);
        }
    }
}



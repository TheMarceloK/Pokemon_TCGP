using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseReader : MonoBehaviour
{
    [SerializeField] PlayerController controller;
    [SerializeField] LayerMask cardLayerMask;

    private void Update()
    {
        if (GenerateRaycast(out Card cardHit))
        {
            if (controller.IsMyTurn && Input.GetMouseButtonDown(0))
            {
                CardClicked(cardHit);
            }
            CardHolvered(cardHit);
        }
        
    }

    public void CardClicked(Card cardClicked)
    {
        controller.CardUsedFromHand(cardClicked);
        cardClicked.UseCard();
    }

    public void CardHolvered(Card cardHolvered)
    {

    }

    private bool GenerateRaycast(out Card cardHit)
    {
        cardHit = null;
        Transform cameraTransform = Camera.main.transform;
        if (Physics.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), cameraTransform.forward, out RaycastHit hit, 15f, cardLayerMask))
        {
            if(hit.collider.TryGetComponent(out Card card))
            {
                cardHit = card;
                return true;
            }
        }
        return false;
    }
}

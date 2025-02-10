using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseReader : MonoBehaviour
{
    [SerializeField] PlayerController controller;
    [SerializeField] LayerMask cardLayerMask, slotLayerMask;

    Card lastCard;

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

        if (GenerateRaycast(out BoardSlot slotClicked))
        {
            if (controller.IsMyTurn && Input.GetMouseButtonDown(0))
            {
                SlotClicked(slotClicked);
            }
        }

        if (lastCard != null)
            CardUnHolver(cardHit);

        lastCard = cardHit;
    }

    public void CardClicked(Card cardClicked)
    {
        controller.CardUsedFromHand(cardClicked);
    }

    public void SlotClicked(BoardSlot slotClicked)
    {
        controller.SlotClicked(slotClicked);
    }

    public void CardHolvered(Card cardHolvered)
    {
        cardHolvered.ShowHolveredImage(true);
    }

    public void CardUnHolver(Card cardHolvered)
    {
        if (cardHolvered != lastCard)
        {
            lastCard.ShowHolveredImage(false);
        }
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

    private bool GenerateRaycast(out BoardSlot slotHit)
    {
        slotHit = null;
        Transform cameraTransform = Camera.main.transform;
        if (Physics.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), cameraTransform.forward, out RaycastHit hit, 15f, slotLayerMask))
        {
            if (hit.collider.TryGetComponent(out BoardSlot slot))
            {
                slotHit = slot;
                return true;
            }
        }
        return false;
    }
}

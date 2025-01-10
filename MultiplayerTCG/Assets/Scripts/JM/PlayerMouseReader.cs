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
        if (controller.IsMyTurn && Input.GetMouseButtonDown(0))
        {
            GenerateRaycast();
        }
    }

    private void GenerateRaycast()
    {
        Transform cameraTransform = Camera.main.transform;
        if (Physics.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), cameraTransform.forward, out RaycastHit hit, 15f, cardLayerMask))
        {
            if(hit.collider.TryGetComponent(out Card card))
            {
                card.UseCard();
            }
        }
    }
}

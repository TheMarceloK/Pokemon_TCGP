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
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, 15f, cardLayerMask))
        {

        }
    }
}


using System;
using UnityEditor;
using UnityEngine;

public class TestItem :MonoBehaviour
{
    private void Start()
    {
        
        ItemController itemController = new ItemController();
        Item item = new Item
        {
            baralho = 2,
            carta = 5
        };
        
        itemController.AddCardInDack(item);
        




    }
}

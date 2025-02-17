using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MensagerSender : MonoBehaviour
{
    [SerializeField] private Client _client;


    public void SendMensageToServer(string mensage)
    {
        _client.SendMessageToServer(mensage);
    }
}

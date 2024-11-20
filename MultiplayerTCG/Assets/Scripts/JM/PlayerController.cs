using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Deck playerDeck;
    [SerializeField] Hand hand;

    bool isMyTurn;

    public delegate void OnPlayerFinishTurn();
    public static OnPlayerFinishTurn onPlayerFinishTurn;


    public void StartGame()
    {
        playerDeck.StartGame();
    }

    public void StartTurn()
    {
        isMyTurn = true;
        DrawCard();
    }

    public void DrawCard()
    {
        playerDeck.DrawCard(out CardData card);

        if(card == null)
        {
            Debug.Log("Acabou as cartas");
            return;
        }

        hand.AddCard(card);
    }

    public void FinishTurn()
    {
        isMyTurn = false;
    }

    private void Update()
    {
        if (!isMyTurn)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            onPlayerFinishTurn?.Invoke();
        }
    }
}

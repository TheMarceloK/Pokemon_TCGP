using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Deck _playerDeck;
    [SerializeField] Hand _hand;
    [SerializeField] BoardManager _board;


    bool _isMyTurn;

    public delegate void OnPlayerFinishTurn();
    public static OnPlayerFinishTurn onPlayerFinishTurn;


    public bool IsMyTurn => _isMyTurn;

    #region TurnStuff

    public void StartGame()
    {
        _playerDeck.StartGame();
    }

    public void StartTurn()
    {
        _isMyTurn = true;
        
        DrawCard();
        _hand.SetHandCardsUsability(_isMyTurn);
    }

    public void DrawCard()
    {
        _playerDeck.DrawCard(out CardData card);

        if(card == null)
        {
            Debug.Log("Acabou as cartas");
            return;
        }

        _hand.AddCard(card);
    }

    public void FinishTurn()
    {
        _isMyTurn = false;
        _hand.SetHandCardsUsability(_isMyTurn);
    }

    public void ExecuteTurnActions()
    {
        if (!_isMyTurn)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            onPlayerFinishTurn?.Invoke();
        }
    }

    #endregion

    public void CardUsedFromHand(Card cardUsed)
    {
        if (!IsMyTurn)
            return;

        
        UseCard(cardUsed.Data, out bool isCardPlayed);


        if (isCardPlayed)
        {
            _hand.RemoveCardFromHand(cardUsed);
            
        }
    }

    public void UseCard(CardData data, out bool isCardPlayed)
    {
        isCardPlayed = false;

        if (data.GetType() == ScriptableObject.CreateInstance<PokemonData>().GetType())
        {
            PokemonData pokemon = (PokemonData)data;

            _board.PlayPokemon(pokemon, out bool isPokemonPlayed);
            isCardPlayed = isPokemonPlayed;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Deck _playerDeck;
    [SerializeField] Hand _hand;
    [SerializeField] BoardManager _board;

    public PlayerController _enemyPlayer;

    bool _isMyTurn;
    bool _energyUsed;
    bool _attacked;

    public delegate void OnPlayerFinishTurn();
    public static OnPlayerFinishTurn onPlayerFinishTurn;


    public bool IsMyTurn => _isMyTurn;

    #region TurnStuff

    public void StartGame(PlayerController enemyPlayer)
    {
        _enemyPlayer = enemyPlayer;
        _playerDeck.StartGame();
        _energyUsed = false;
        _attacked = false;
    }

    public void StartTurn()
    {
        _isMyTurn = true;
        _energyUsed = false;
        _attacked = false;
        
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

    #region Cards

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
    #endregion

    #region Slots

    public void ReciveAttack(int damage) { 
        _board.ReciveAttack(damage);
    }

    public void SlotClicked(BoardSlot slotClicked)
    {
        if (slotClicked.IsSlotEmpty())
            return;

        if (!_energyUsed)
        {
            slotClicked.AddEnergy(out bool energyAddedSuccessfuly);
            _energyUsed = energyAddedSuccessfuly;
            return;
        }

        if(!_attacked && slotClicked.IsActiveSlot(out int damage) && slotClicked.HasEnergyToAttack()){
            
            _enemyPlayer.ReciveAttack(damage);
            _attacked = true;
        }

    }

    #endregion
}

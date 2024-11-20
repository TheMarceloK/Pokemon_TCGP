using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TurnManager : MonoBehaviour
{

    [SerializeField] PlayerSpawner spawner;
    PlayerController[] _players;

    PlayerController _currentPlayer;

    private void Start()
    {
        _players = new PlayerController[2];

        _players[0] = spawner.PlayerA;
        _players[1] = spawner.PlayerB;

        _players[0].StartGame();
        _players[1].StartGame();

        _currentPlayer = _players[Random.Range(0,2)];

        StartTurn();
    }

    private void OnEnable()
    {
        PlayerController.onPlayerFinishTurn += FinishTurn;
    }

    private void OnDisable()
    {
        PlayerController.onPlayerFinishTurn -= FinishTurn;
    }

    public void StartTurn()
    {
        Debug.Log("Turno de " + _currentPlayer.gameObject.name);
        _currentPlayer.StartTurn();
    }

    public void FinishTurn()
    {
        Debug.Log("Terminou " + _currentPlayer.gameObject.name);
        _currentPlayer.FinishTurn();
        ChangePlayer();
    }

    private void ChangePlayer()
    {
        if(_currentPlayer == _players[0])
            _currentPlayer = _players[1];
        else
            _currentPlayer = _players[0];

        Invoke("StartTurn", 1f);
    }
}

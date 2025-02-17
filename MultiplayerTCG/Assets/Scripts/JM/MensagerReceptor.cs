using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MensagerReceptor : MonoBehaviour
{
    [SerializeField] TurnManager _turnManager;
    [SerializeField] Text debbuger;

    public PlayerController _player;

    private Dictionary<string, Action<int[]>> commands;

    public void Start()
    {
        commands = new Dictionary<string, Action<int[]>>
        {
            { "StartTurn", VerifyWhoStarts },
            { "FinishTurn", ChangeCurrentPlayer },
            { "ReciveAttack", ReciveAttack },
            { "PlayedCard", EnemyPlayedPokemon },
            { "UpdateLife", EnemyPokemonChangedLife },
            { "EnergyAdded", EnemyAddedEnergy }
        };
    }

    public void ReciveMensage(string response)
    {
        string[] parts = response.Split(':');
        string command = parts[0];
        string[] parametersString = parts.Length > 1 ? parts[1].Split(',') : new string[0];

        int[] parameters = new int[parametersString.Length];
            
        for (int i = 0; i < parametersString.Length; i++)
        {
            parameters[i] = int.Parse(parametersString[i]);

        }

        if (commands.TryGetValue(command, out Action<int[]> action))
        {
            action.Invoke(parameters);
        }
        else
        {
            Debug.LogWarning($"Comando não reconhecido: {command}");
        }
    }

    public void ChangeCurrentPlayer(int[] parameters)
    {
        _turnManager.ChangePlayer();
    }

    void VerifyWhoStarts(int[] parameters)
    {
        if (parameters[0]==0)
            _turnManager.StartGame(true);
        else
            _turnManager.StartGame(false);
    }

    void ReciveAttack(int[] damage)
    {
        _player.ReciveAttack(damage[0]);
    }

    void EnemyPlayedPokemon(int[] parameters)
    {
        _player.PutPokemonOnEnemyBoard(parameters);
    }

    void EnemyAddedEnergy(int[] parameters)
    {
        _player.EnemyAddedEnergy(parameters);
    }

    void EnemyPokemonChangedLife(int[] parameters)
    {
        _player.EnemyPokemonChangedLife(parameters);
    }
}

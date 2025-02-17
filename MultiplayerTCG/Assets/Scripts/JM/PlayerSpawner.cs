using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] GameObject _playerPrefab;
    [SerializeField] Transform postion;

    public PlayerController Player;

    private void Awake()
    {
        GameObject newPlayer = Instantiate(_playerPrefab, postion.position, postion.rotation);

        newPlayer.name = "Player A";

        Player = newPlayer.GetComponent<PlayerController>();
    }
}

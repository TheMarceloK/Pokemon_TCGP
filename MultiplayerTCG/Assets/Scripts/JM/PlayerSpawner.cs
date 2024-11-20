using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] GameObject _playerPrefab;
    [SerializeField] Transform postionA, positionB;

    public PlayerController PlayerA, PlayerB;

    private void Awake()
    {
        GameObject newPlayer = Instantiate(_playerPrefab, postionA.position, postionA.rotation);

        newPlayer.name = "Player A";

        PlayerA = newPlayer.GetComponent<PlayerController>();

        newPlayer = Instantiate(_playerPrefab, positionB.position, positionB.rotation);

        newPlayer.name = "Player B";

        PlayerB = newPlayer.GetComponent<PlayerController>();
    }
}

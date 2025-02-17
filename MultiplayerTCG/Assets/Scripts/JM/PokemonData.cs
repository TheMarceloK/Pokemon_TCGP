using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/Pokemon")]
public class PokemonData : CardData
{
    public GameObject PokemonPrefab;
    public GameObject EnemyPrefab;
    public int PokemonID;
    public int MaxLife;
    public string AttackName;
    public int AttackDamage;
    public int AttackCost;
    public int RetreatCost;
    public string Effect;
    public int Stage;
    public int Type;
}

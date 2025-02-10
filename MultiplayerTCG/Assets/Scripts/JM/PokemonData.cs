using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/Pokemon")]
public class PokemonData : CardData
{
    public GameObject PokemonPrefab;
    public int PokemonID;
    public int MaxLife;
    public string AttackName;
    public int AttackDamage;
    public int AttackCost;
}

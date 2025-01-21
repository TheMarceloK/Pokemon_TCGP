using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/Pokemon")]
public class PokemonData : CardData
{
    public GameObject pokemonPrefab;
    public string pokemonName;
    public int maxLife;
}

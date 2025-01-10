using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/Pokemon")]
public class PokemonData : ScriptableObject
{
    public int ID;
    public GameObject pokemonPrefab;
    public int maxLife;
}

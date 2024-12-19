using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/Card")]
public class CardData : ScriptableObject
{
    public int ID;
    public Sprite cardArt;
    public string effect;
    public int pokemonID = -1;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/Card")]
public class CardData : ScriptableObject
{
    public int ID;
    public Sprite cardArt;

    //CardData todos tem

    //Os tipos diferentes vem dos outros tipos de Data como PokemonData e ItensData

    //Assim as cartas enquanto na mão e no deck não fazem nada, por serem apenas CardData

    //Mas quando jogadas elas ganham a forma do tipo quardado 
}

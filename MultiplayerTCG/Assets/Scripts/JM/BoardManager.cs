using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] BoardSlot[] slots;

    public BoardSlot[] Slots => slots;

    private void Start()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].SetSlotID(i);
        }
    }

    public void PlayPokemon(PokemonData data, out bool isPokemonPlayed, out int boardID)
    {
        isPokemonPlayed = false;
        boardID = -1;

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].IsSlotEmpty())
            {
                slots[i].AddPokemonToSlot(data);
                boardID = i;
                isPokemonPlayed=true;
                return;
            }
        }
    }

    public void ReciveAttack(int damage)
    {
        slots[0].PokemonTakeDamage(damage, out bool pokemonDied);
    }

    public void ReciveAttack(int damage,int slotToHit)
    {
        slots[slotToHit].PokemonTakeDamage(damage, out bool pokemonDied);
    }



}

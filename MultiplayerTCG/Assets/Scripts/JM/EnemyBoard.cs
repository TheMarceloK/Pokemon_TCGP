using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoard : MonoBehaviour
{
    [SerializeField] EnemySlots[] slots;

    [SerializeField] PokemonData data;

    private void Start()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].SetSlotID(i);
        }
    }

    public void PutPokemon(int boardID, int pokemonID)
    {
        slots[boardID].AddPokemonToSlot(data);

        SetLife(boardID,data.MaxLife);
        SetEnergy(boardID, 0);
        SetName(boardID, data.name);

    }

    public void SetLife(int slot, int i)
    {
        slots[slot].UpdateTextLife(i);
    }

    public void SetEnergy(int slot, int i)
    {
        slots[slot].UpdateTextEnergy(i);
    }

    public void SetName(int slot, string name)
    {
        slots[slot].UpdateTextName(name);
    }
}

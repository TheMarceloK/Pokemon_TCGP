using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoardSlot : MonoBehaviour
{
    protected PokemonData CurrentPokemonData;
    protected PokemonScrpt CurrentPokemonInSlot;

    protected int SlotID;

    public void AddPokemonToSlot(PokemonData pokemonData)
    {
        CurrentPokemonData = pokemonData;

        GameObject newPokemon = Instantiate(CurrentPokemonData.pokemonPrefab, transform);
        CurrentPokemonInSlot = newPokemon.GetComponent<PokemonScrpt>();
    }

    public void AddPokemonToSlot(PokemonData pokemonData, PokemonScrpt existingPokemon)
    {
        CurrentPokemonData = pokemonData;

        CurrentPokemonInSlot = existingPokemon;
        CurrentPokemonInSlot.transform.position = transform.position;
        CurrentPokemonInSlot.transform.SetParent(transform);
    }

    public void PokemonTakeDamage(int amountOfDamage)
    {
        CurrentPokemonInSlot.TakeDamage(amountOfDamage, out bool died);
    }

    public void SetSlotID(int id)
    {
        SlotID = id;
    }
}

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

        GameObject newPokemon = Instantiate(CurrentPokemonData.PokemonPrefab, transform);
        CurrentPokemonInSlot = newPokemon.GetComponent<PokemonScrpt>();

        CurrentPokemonInSlot.Inicialize(pokemonData);
    }

    public void AddPokemonToSlot(PokemonData pokemonData, PokemonScrpt existingPokemon)
    {
        CurrentPokemonData = pokemonData;

        CurrentPokemonInSlot = existingPokemon;
        CurrentPokemonInSlot.transform.position = transform.position;
        CurrentPokemonInSlot.transform.SetParent(transform);
    }

    public bool CanAddPokemon()
    {
        return CurrentPokemonInSlot == null;
    }

    public bool CanAddPokemon(int evolutionID)
    {
        if (evolutionID == 0)
            return CanAddPokemon();

        return CurrentPokemonData.PokemonID == evolutionID;
    }

    public void PokemonTakeDamage(int amountOfDamage, out bool pokemonDied)
    {
        CurrentPokemonInSlot.TakeDamage(amountOfDamage, out bool died);
        pokemonDied = died;
    }

    public void SetSlotID(int id)
    {
        SlotID = id;
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BoardSlot : MonoBehaviour
{
    PokemonData CurrentPokemonData;
    PokemonScrpt CurrentPokemonInSlot;

    [SerializeField] Text energyQuantity;
    [SerializeField] GameObject energyCanvas;
    

    public int SlotID;

    void UpdateTextEnergy()
    {
        energyCanvas.SetActive(CurrentPokemonInSlot != null);
        if(CurrentPokemonInSlot != null)
        {
            energyQuantity.text = CurrentPokemonInSlot.Energy.ToString();
        }

    }

    public int HowMuckEnergy()
    {
        return CurrentPokemonInSlot.Energy;
    }

    public int HowMuchLife()
    {
        return CurrentPokemonInSlot.CurrentLife;
    }

    public void AddPokemonToSlot(PokemonData pokemonData)
    {
        CurrentPokemonData = pokemonData;

        GameObject newPokemon = Instantiate(CurrentPokemonData.PokemonPrefab, transform);
        CurrentPokemonInSlot = newPokemon.GetComponent<PokemonScrpt>();

        CurrentPokemonInSlot.Inicialize(pokemonData);
        UpdateTextEnergy();
    }

    public void AddPokemonToSlot(PokemonData pokemonData, PokemonScrpt existingPokemon)
    {
        CurrentPokemonData = pokemonData;

        CurrentPokemonInSlot = existingPokemon;
        CurrentPokemonInSlot.transform.position = transform.position;
        CurrentPokemonInSlot.transform.SetParent(transform);

        UpdateTextEnergy();
    }

    public bool IsSlotEmpty()
    {
        return CurrentPokemonInSlot == null;
    }

    public bool CanAddPokemon(int evolutionID)
    {
        if (evolutionID == 0)
            return IsSlotEmpty();

        return CurrentPokemonData.PokemonID == evolutionID;
    }

    public void PokemonTakeDamage(int amountOfDamage, out bool pokemonDied)
    {
        CurrentPokemonInSlot.TakeDamage(amountOfDamage, out bool died);
        pokemonDied = died;

        UpdateTextEnergy();
    }

    public void AddEnergy(out bool added)
    {
        added = false;
        if (CurrentPokemonInSlot != null)
        {
            CurrentPokemonInSlot.AddEnergy();
            UpdateTextEnergy();
            added = true;
        }
    }

    public bool HasEnergyToAttack()
    {
        return CurrentPokemonInSlot.Energy >= CurrentPokemonData.AttackCost;
    }

    public bool IsActiveSlot(out int damage)
    {
        damage = CurrentPokemonInSlot.Data.AttackDamage;
        return SlotID == 0;
    }

    public void SetSlotID(int id)
    {
        SlotID = id;
    }
}

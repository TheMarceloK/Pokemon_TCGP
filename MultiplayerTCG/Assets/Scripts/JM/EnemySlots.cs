using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemySlots : MonoBehaviour
{
    PokemonData CurrentPokemonData;

    [SerializeField] Text energyQuantity;
    [SerializeField] Text hp;
    [SerializeField] Text nameText;
    [SerializeField] GameObject energyCanvas;
    [SerializeField] GameObject hpCanvas;
    [SerializeField] GameObject nameCanvas;

    int SlotID;
    bool hasPokemon;

    public void UpdateTextEnergy(int value)
    {
        energyCanvas.SetActive(value >= 0);

        energyQuantity.text = value.ToString();
    }

    public void UpdateTextLife(int value)
    {
        hpCanvas.SetActive(value >= 0);

        hp.text = value.ToString();
    }

    public void UpdateTextName(string name)
    {
        nameCanvas.SetActive(name != "");

        nameText.text = name;
    }
    public void AddPokemonToSlot(PokemonData pokemonData)
    {
        CurrentPokemonData = pokemonData;

        GameObject newPokemon = Instantiate(CurrentPokemonData.EnemyPrefab, transform);

        SpriteRenderer _spriteRenderer = newPokemon.GetComponent<SpriteRenderer>();

        _spriteRenderer.sprite = pokemonData.cardArt;

        hasPokemon = true;
    }

    public void SetSlotID(int id)
    {
        SlotID = id;
    }

    public bool IsSlotEmpty()
    {
        return !hasPokemon;
    }
}

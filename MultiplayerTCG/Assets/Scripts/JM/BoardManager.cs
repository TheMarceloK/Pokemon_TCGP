using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] BoardSlot[] slots;

    private void Start()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].SetSlotID(i);
        }
    }

    public void ReciveAttack(int damage)
    {
        slots[0].PokemonTakeDamage(damage);
    }

    public void ReciveAttack(int damage,int slotToHit)
    {
        slots[slotToHit].PokemonTakeDamage(damage);
    }

}

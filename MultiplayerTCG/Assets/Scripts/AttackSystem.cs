using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    public static AttackSystem Instance; // Singleton para f�cil acesso
    public Card attackingCard; // Carta que est� atacando

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetAttackingCard(Card card)
    {
        if (card.isOnTable) // Apenas cartas na mesa podem atacar
        {
            attackingCard = card;
            Debug.Log("Carta " + card.name + " est� pronta para atacar!");
        }
        else
        {
            Debug.Log("Voc� n�o pode atacar com uma carta que n�o est� na mesa.");
        }
    }

    public void PerformAttack(Card targetCard)
    {
        if (attackingCard != null && targetCard != null)
        {
            // Verifica se ambas as cartas est�o na mesa e s�o de jogadores diferentes
            if (attackingCard.isOnTable && targetCard.isOnTable && attackingCard.isPlayerCard != targetCard.isPlayerCard)
            {
                Debug.Log(attackingCard.name + " atacou " + targetCard.name + " causando " + attackingCard.damage + " de dano.");
                targetCard.TakeDamage(attackingCard.damage);
                attackingCard = null; // Reseta a carta atacante ap�s o ataque
            }
            else
            {
                Debug.Log("Voc� n�o pode atacar esta carta.");
            }
        }
    }
}


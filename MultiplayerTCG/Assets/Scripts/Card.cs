using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private bool isSelected = false;
    private CardSlot currentSlot;

    // Atributos de vida, dano e estado
    public int health = 10;
    public int damage = 5;
    public bool isPlayerCard; // Identifica se � do jogador ou do advers�rio
    public bool isOnTable = false; // Verifica se a carta est� na mesa

    void Update()
    {
        if (isSelected && Input.GetMouseButtonDown(0)) // Detecta clique no espa�o
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                CardSlot slot = hit.collider.GetComponent<CardSlot>();
                if (slot != null && !isOnTable) // Permite colocar a carta na mesa
                {
                    // Se j� est� em um slot, remove a carta do slot anterior
                    if (currentSlot != null)
                    {
                        currentSlot.RemoveCard(gameObject);
                    }

                    // Coloca a carta no novo slot
                    slot.PlaceCard(gameObject);
                    currentSlot = slot; // Atualiza o slot atual
                    isOnTable = true; // Marca a carta como estando na mesa
                    isSelected = false; // Cancela a sele��o
                }
            }
        }
    }

    private void OnMouseDown()
    {
        // Quando a carta est� na mesa, ela pode ser selecionada para atacar
        if (isOnTable)
        {
            if (AttackSystem.Instance != null && AttackSystem.Instance.attackingCard != null)
            {
                // Realiza o ataque se a carta clicada for alvo
                AttackSystem.Instance.PerformAttack(this);
            }
            else
            {
                // Seleciona a carta para atacar
                isSelected = true;
                Debug.Log("Carta selecionada!");
                AttackSystem.Instance.SetAttackingCard(this);
            }
        }
        else
        {
            // Quando n�o est� na mesa, apenas permite a sele��o para coloca��o
            isSelected = true;
            Debug.Log("Selecione um slot para colocar a carta na mesa.");
        }
    }

    // M�todo para receber dano
    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log(gameObject.name + " recebeu " + amount + " de dano. Vida restante: " + health);

        if (health <= 0)
        {
            DestroyCard();
        }
    }

    // M�todo para destruir a carta
    private void DestroyCard()
    {
        Debug.Log(gameObject.name + " foi destru�da!");

        // Libera o slot, se estiver em um
        if (currentSlot != null)
        {
            currentSlot.RemoveCard(gameObject);
            currentSlot = null;
        }

        if (!isPlayerCard)
        {
            GameManager.Instance.AddPlayerScore(); // Pontua��o para o jogador
            Destroy(gameObject);
        }
        else
        {
            GameManager.Instance.AddOpponentScore(); // Pontua��o para o advers�rio
            Destroy(gameObject);
        }
    }
}


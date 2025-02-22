using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    // Lista de prefabs de cartas que podem ser instanciadas
    public List<GameObject> cardPrefabs;

    // Array de slots onde as cartas ser�o instanciadas
    public GameObject[] slots;

    void Start()
    {
        // Verifica se h� prefabs de cartas na lista
        if (cardPrefabs == null || cardPrefabs.Count == 0)
        {
            Debug.LogError("Nenhum prefab de carta foi atribu�do na lista.");
            return;
        }

        // Itera sobre cada slot e instancia uma carta aleat�ria
        foreach (GameObject slot in slots)
        {
            if (slot != null)
            {
                // Escolhe um prefab aleat�rio da lista
                GameObject randomCardPrefab = cardPrefabs[Random.Range(0, cardPrefabs.Count)];

                // Instancia a carta no slot
                GameObject cardInstance = Instantiate(randomCardPrefab, slot.transform.position, slot.transform.rotation);

                //// Define o slot como pai da carta (opcional)
                //cardInstance.transform.SetParent(slot.transform);
            }
        }
    }
    public void BuyRandomCard()
    {
        // Verifica se h� slots dispon�veis
        foreach (GameObject slot in slots)
        {
            if (slot.transform.childCount == 0) // Verifica se o slot est� vazio
            {
                // Escolhe um prefab aleat�rio da lista
                GameObject randomCardPrefab = cardPrefabs[Random.Range(0, cardPrefabs.Count)];

                // Instancia a carta no slot
                GameObject cardInstance = Instantiate(randomCardPrefab, slot.transform.position, slot.transform.rotation);

                // Define o slot como pai da carta
                cardInstance.transform.SetParent(slot.transform);

                // Sai do loop ap�s instanciar a carta
                return;
            }
        }

        // Se n�o houver slots dispon�veis, exibe uma mensagem
        Debug.Log("N�o h� slots dispon�veis para novas cartas.");
    }
}
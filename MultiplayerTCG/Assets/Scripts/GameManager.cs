using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int playerScore = 0;    // Pontua��o do jogador
    public int opponentScore = 0; // Pontua��o do advers�rio
    public int maxScore = 3;      // Pontua��o necess�ria para vencer

    [Header("UI Elements")]
    public TextMeshProUGUI playerScoreText;    // Texto para mostrar a pontua��o do jogador
    public TextMeshProUGUI opponentScoreText;  // Texto para mostrar a pontua��o do advers�rio
    public TextMeshProUGUI victoryMessageText; // Texto para mostrar a mensagem de vit�ria

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

    private void Start()
    {
        // Inicializa o texto da pontua��o
        UpdateScoreUI();
        victoryMessageText.gameObject.SetActive(false); // Oculta a mensagem de vit�ria inicialmente
    }

    /// <summary>
    /// Incrementa a pontua��o do jogador.
    /// </summary>
    public void AddPlayerScore()
    {
        playerScore++;
        Debug.Log("Jogador ganhou 1 ponto! Pontua��o atual: " + playerScore);
        UpdateScoreUI();
        CheckVictory("Jogador", playerScore);
    }

    /// <summary>
    /// Incrementa a pontua��o do advers�rio.
    /// </summary>
    public void AddOpponentScore()
    {
        opponentScore++;
        Debug.Log("Advers�rio ganhou 1 ponto! Pontua��o atual: " + opponentScore);
        UpdateScoreUI();
        CheckVictory("Advers�rio", opponentScore);
    }

    /// <summary>
    /// Atualiza o texto da pontua��o na interface do usu�rio.
    /// </summary>
    private void UpdateScoreUI()
    {
        playerScoreText.text = "Jogador: " + playerScore.ToString();
        opponentScoreText.text = "Advers�rio: " + opponentScore.ToString();
    }

    /// <summary>
    /// Verifica se algu�m alcan�ou a pontua��o m�xima.
    /// </summary>
    private void CheckVictory(string winner, int score)
    {
        if (score >= maxScore)
        {
            Debug.Log(winner + " venceu o jogo!");
            EndGame(winner);
        }
    }

    /// <summary>
    /// Finaliza o jogo e exibe a mensagem de vit�ria.
    /// </summary>
    private void EndGame(string winner)
    {
        // Exibe a mensagem de vit�ria
        victoryMessageText.text = "Parab�ns, " + winner + " venceu!";
        victoryMessageText.gameObject.SetActive(true);

        // Aqui voc� pode implementar l�gica adicional, como travar o jogo ou retornar ao menu.
    }
}

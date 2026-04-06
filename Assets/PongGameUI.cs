using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PongGameUI : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] TextMeshProUGUI playerScoreText;
    [SerializeField] TextMeshProUGUI opponentScoreText;
    [SerializeField] TextMeshProUGUI instructionText;

    void Start()
    {
        if (gameManager == null)
        {
            gameManager = FindFirstObjectByType<GameManager>();
        }

        gameManager.startGame.AddListener(HideInstruction);
        gameManager.finishGame.AddListener(ShowInstruction);
    }

    void Update()
    {
        playerScoreText.text = gameManager.playerScore.ToString();
        opponentScoreText.text = gameManager.opponentScore.ToString();
    }

    void HideInstruction()
    {
        instructionText.gameObject.SetActive(false);
    }

    void ShowInstruction()
    {
        instructionText.gameObject.SetActive(true);
    }
}
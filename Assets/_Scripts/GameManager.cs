using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinText;

    public float pontosPorSegundo = 10f;

    private float pontuacao = 0f;
    private int moedas = 0;

    void Update()
    {
        pontuacao += pontosPorSegundo * Time.deltaTime;

        AtualizarInterface();
    }

    public void AdicionarMoeda()
    {
        moedas++;
        AtualizarInterface();
    }

    void AtualizarInterface()
    {
        scoreText.text = "Pontos: " +
            Mathf.FloorToInt(pontuacao);

        coinText.text = "Moedas: " + moedas;
    }
}
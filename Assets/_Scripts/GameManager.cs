
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinText;

    public float pontosPorSegundo = 10f;

    private float pontuacao = 0f;
    private int moedas = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += AoCarregarCena;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= AoCarregarCena;
    }

    private void AoCarregarCena(
        Scene cena,
        LoadSceneMode modo)
    {
        // Garante que o jogo não fique pausado
        Time.timeScale = 1f;

        if (cena.name == "Jogo")
        {
            // Reinicia os valores da partida
            pontuacao = 0f;
            moedas = 0;

            // Procura os textos da nova cena
            GameObject pontos =
                GameObject.Find("ScoreText");

            GameObject moedasUI =
                GameObject.Find("CoinText");

            scoreText = pontos != null
                ? pontos.GetComponent<TextMeshProUGUI>()
                : null;

            coinText = moedasUI != null
                ? moedasUI.GetComponent<TextMeshProUGUI>()
                : null;

            AtualizarInterface();
        }
        else
        {
            scoreText = null;
            coinText = null;
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "Jogo")
            return;

        pontuacao += pontosPorSegundo * Time.deltaTime;

        AtualizarInterface();
    }

    public void AdicionarMoeda()
    {
        moedas++;
        AtualizarInterface();
    }

    private void AtualizarInterface()
    {
        if (scoreText != null)
        {
            scoreText.text = "Pontos: " +
                Mathf.FloorToInt(pontuacao);
        }

        if (coinText != null)
        {
            coinText.text = "Moedas: " + moedas;
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Security;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Interface")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI coinText;

    [Header("Nome da cena atual")]
    [SerializeField] private string gameNameScene = "Game";

    [Header("Pontuação")]
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

    // NOVO: configura a primeira cena
    private void Start()
    {
        ConfigurarCena(SceneManager.GetActiveScene());
    }

    private void AoCarregarCena(
        Scene cena,
        LoadSceneMode modo)
    {
        ConfigurarCena(cena);
    }

    // NOVO: centraliza a configuração da cena
    private void ConfigurarCena(Scene cena)
    {
        Time.timeScale = 1f;

        if (cena.name == gameNameScene)
        {
            pontuacao = 0f;
            moedas = 0;

            ConectarInterface();
            AtualizarInterface();
        }
        else
        {
            scoreText = null;
            coinText = null;
        }
    }

    // NOVO: procura os textos da gameplay

    private void ConectarInterface()
    {
        TextMeshProUGUI[] textos = FindObjectsOfType<TextMeshProUGUI>(true);

        scoreText = null;
        coinText = null;

        foreach (TextMeshProUGUI texto in textos)
        {
            if (texto.gameObject.name == "ScoreText")
            {
                scoreText = texto;
            }

            if (texto.gameObject.name == "CoinText")
            {
                coinText = texto;
            }
        }

        if (scoreText == null)
        {
            Debug.LogWarning("ScoreText não encontrado!");
        }

        if (coinText == null)
        {
            Debug.LogWarning("CoinText não encontrado!");
        }
    }


    private void Update()
    {
        if (SceneManager.GetActiveScene().name != gameNameScene)
            return;

        pontuacao += pontosPorSegundo * Time.deltaTime;

        if (scoreText == null || coinText == null)
        {
            ConectarInterface();
        }

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


using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Interface")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinText;

    [Header("Pontuação")]
    public float pontosPorSegundo = 10f;

    private float pontuacao = 0f;
    private int moedas = 0;

    private bool partidaAtiva = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        if (Instance == this)
        {
            SceneManager.sceneLoaded += AoCarregarCena;
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= AoCarregarCena;
    }

    private void Start()
    {
        // Configura a primeira cena caso o evento
        // sceneLoaded não tenha sido recebido.
        if (!partidaAtiva &&
            SceneManager.GetActiveScene().name == "Jogo")
        {
            IniciarPartida();
        }
    }

    private void AoCarregarCena(
        Scene cena,
        LoadSceneMode modo)
    {
        if (cena.name == "Jogo")
        {
            IniciarPartida();
        }
        else
        {
            partidaAtiva = false;
            scoreText = null;
            coinText = null;
        }
    }

    private void IniciarPartida()
    {
        Time.timeScale = 1f;

        pontuacao = 0f;
        moedas = 0;

        partidaAtiva = true;

        ConectarInterface();
        AtualizarInterface();

        Debug.Log("GameManager: partida iniciada!");
    }

    private void ConectarInterface()
    {
        scoreText = null;
        coinText = null;

        TextMeshProUGUI[] textos =
            FindObjectsOfType<TextMeshProUGUI>(true);

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
            Debug.LogWarning(
                "GameManager: ScoreText não encontrado!"
            );
        }

        if (coinText == null)
        {
            Debug.LogWarning(
                "GameManager: CoinText não encontrado!"
            );
        }
    }

    private void Update()
    {
        if (!partidaAtiva)
            return;

        // Aumenta os pontos continuamente
        pontuacao += pontosPorSegundo * Time.deltaTime;

        // Tenta reconectar os textos caso estejam vazios
        if (scoreText == null || coinText == null)
        {
            ConectarInterface();
        }

        AtualizarInterface();
    }

    public void AdicionarMoeda()
    {
        if (!partidaAtiva)
            return;

        moedas++;

        Debug.Log("Moedas coletadas: " + moedas);

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

    public void PararPartida()
    {
        partidaAtiva = false;
    }
}

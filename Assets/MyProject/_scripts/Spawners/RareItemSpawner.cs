
using UnityEngine;

[System.Serializable]
public class VariacaoRara
{
    public string id;
    public Sprite imagem;
}

public class RareItemSpawner : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject coletavelRaroPrefab;

    [Header("Raridade")]
    public float tempoEntreTentativas = 10f;

    [Range(0, 100)]
    public int chanceDeAparecer = 5;

    [Header("Pistas")]
    public float[] posicoesPistas = { -3.5f, 0f, 3.5f };

    [Header("Sete itens raros")]
    public VariacaoRara[] variacoes = new VariacaoRara[7];

    private float contador = 0f;

    void Update()
    {
        contador += Time.deltaTime;

        if (contador >= tempoEntreTentativas)
        {
            TentarGerarColetavel();
            contador = 0f;
        }
    }

    void TentarGerarColetavel()
    {
        if (coletavelRaroPrefab == null ||
            variacoes.Length == 0 ||
            posicoesPistas.Length == 0)
        {
            return;
        }

        int sorteio = Random.Range(0, 100);

        if (sorteio >= chanceDeAparecer)
            return;

        // Escolher uma das sete variações
        int indice = Random.Range(0, variacoes.Length);

        VariacaoRara escolhida = variacoes[indice];

        if (escolhida == null ||
            string.IsNullOrEmpty(escolhida.id) ||
            escolhida.imagem == null)
        {
            Debug.LogWarning("Variação rara incompleta!");
            return;
        }


        // Verificar se o item já foi desbloqueado
        if (InventoryManager.Instance != null &&
            InventoryManager.Instance.PossuiItem(escolhida.id))
        {
            // Segundo sorteio: 0 ou 1
            int segundoSorteio = Random.Range(0, 2);

            // 1 = Não gerar o item repetido
            if (segundoSorteio == 1)
            {
                Debug.Log(
                    "Spawn cancelado: item repetido " +
                    escolhida.id
                );

                return;
            }
        }


        // Escolher uma das três pistas
        int pista = Random.Range(0, posicoesPistas.Length);

        float posicaoX = posicoesPistas[pista];

        Vector3 posicao = new Vector3(
            posicaoX,
            transform.position.y,
            0f
        );


        GameObject novoItem = Instantiate(
            coletavelRaroPrefab,
            posicao,
            Quaternion.identity
        );

        // Configurar qual item foi gerado
        ItemRaroColetavel coletavel =
            novoItem.GetComponent<ItemRaroColetavel>();

        if (coletavel != null)
        {
            coletavel.Configurar(escolhida.id);
        }
        else
        {
            Debug.LogError(
                "Prefab sem ItemRaroColetavel!"
            );
        }

        // Aplicar o sprite da variação
        SpriteRenderer renderizador =
            novoItem.GetComponentInChildren<SpriteRenderer>();

        if (renderizador != null)
        {
            renderizador.sprite = escolhida.imagem;
        }
    }
}

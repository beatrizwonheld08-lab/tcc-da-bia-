using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float tempoEntreMoedas = 1.5f;
    public float[] posicoesPistas = { -3.5f, 0f, 3.5f };

    private float contador;

    void Update()
    {
        contador += Time.deltaTime;

        if (contador >= tempoEntreMoedas)
        {
            CriarMoeda();
            contador = 0f;
        }
    }

    void CriarMoeda()
    {
        int pista = Random.Range(0, posicoesPistas.Length);

        float posicaoX = posicoesPistas[pista];

        Vector3 posicao = new Vector3(
            posicaoX,
            5f,
            0f
        );

        Instantiate(coinPrefab, posicao, Quaternion.identity);
    }
}

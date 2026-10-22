using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float tempoEntreMoedas = 1.5f;

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
        int pista = Random.Range(-1, 2);
        float posicaoX = pista * 2f;

        Vector3 posicao = new Vector3(
            posicaoX,
            5f,
            0f
        );

        Instantiate(coinPrefab, posicao, Quaternion.identity);
    }
}

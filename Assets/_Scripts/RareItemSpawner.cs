using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class RareItemSpawner : MonoBehaviour
{
    public GameObject coletavelRaroPrefab;

    public float tempoEntreTentativas = 10f;

    [Range(0f, 100f)]
    public float chanceDeAparecer = 10f;

    public float distanciaEntrePistas = 2f;

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
        float sorteio = Random.Range(0f, 100f);

        if (sorteio < chanceDeAparecer)
        {
            int pista = Random.Range(-1, 2);

            float posicaoX = pista * distanciaEntrePistas;

            Vector3 posicao = new Vector3(
                posicaoX,
                transform.position.y,
                0f
            );

            Instantiate(
                coletavelRaroPrefab,
                posicao,
                Quaternion.identity
            );
        }
    }
}

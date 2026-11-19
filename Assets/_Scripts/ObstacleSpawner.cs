using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;

    public float tempoEntreObstaculos = 1.5f;

    public float[] posicoesPistas = { -3.5f, 0f, 3.5f };

    private float contador;

    void Update()
    {
        contador += Time.deltaTime;

        if (contador >= tempoEntreObstaculos)
        {
            CriarObstaculo();
            contador = 0f;
        }
    }

    void CriarObstaculo()
    {
        int pista = Random.Range(0, posicoesPistas.Length);

        float posicaoX = posicoesPistas[pista];

        Vector3 posicao = new Vector3(
            posicaoX,
            transform.position.y,
            0
        );

        Instantiate(obstaclePrefab, posicao, Quaternion.identity);
    }
}
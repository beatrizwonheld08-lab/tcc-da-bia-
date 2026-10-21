using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;

    public float tempoEntreObstaculos = 1.5f;

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
        int pista = Random.Range(-1, 2);

        float posicaoX = pista * 2f;

        Vector3 posicao = new Vector3(
            posicaoX,
            transform.position.y,
            0
        );

        Instantiate(obstaclePrefab, posicao, Quaternion.identity);
    }
}
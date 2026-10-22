using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    public float velocidade = 4f;

    void Update()
    {
        transform.Translate(
            Vector2.down * velocidade * Time.deltaTime
        );

        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}

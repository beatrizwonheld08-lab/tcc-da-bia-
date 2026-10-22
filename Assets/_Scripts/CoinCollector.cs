using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public int moedas = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            moedas++;

            Debug.Log("Moedas coletadas: " + moedas);

            Destroy(other.gameObject);
        }
    }
}

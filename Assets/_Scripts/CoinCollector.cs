using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            gameManager.AdicionarMoeda();

            Destroy(other.gameObject);
        }
    }
}
